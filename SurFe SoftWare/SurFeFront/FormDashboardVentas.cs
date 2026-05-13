using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

// Alias para resolver ambigüedad con iTextSharp
using GdiRect = System.Drawing.Rectangle;
using GdiColor = System.Drawing.Color;
using GdiFont = System.Drawing.Font;
using iDoc = iTextSharp.text.Document;
using iPhrase = iTextSharp.text.Phrase;
using iParagraph = iTextSharp.text.Paragraph;
using iPdfTable = iTextSharp.text.pdf.PdfPTable;
using iPdfCell = iTextSharp.text.pdf.PdfPCell;
using iPdfWriter = iTextSharp.text.pdf.PdfWriter;
using iFontFactory = iTextSharp.text.FontFactory;
using iBaseColor = iTextSharp.text.BaseColor;
using iTextSharp.text;

namespace SurFeFront
{
    public partial class FormDashboardVentas : Form
    {
        // ── Paleta ───────────────────────────────────────────────────────────
        private readonly GdiColor C_BG = GdiColor.FromArgb(13, 17, 27);
        private readonly GdiColor C_SURFACE = GdiColor.FromArgb(22, 28, 45);
        private readonly GdiColor C_CARD = GdiColor.FromArgb(30, 38, 60);
        private readonly GdiColor C_ACCENT = GdiColor.FromArgb(56, 189, 248);
        private readonly GdiColor C_ACCENT2 = GdiColor.FromArgb(99, 102, 241);
        private readonly GdiColor C_GREEN = GdiColor.FromArgb(34, 197, 94);
        private readonly GdiColor C_ORANGE = GdiColor.FromArgb(251, 146, 60);
        private readonly GdiColor C_TEXT = GdiColor.FromArgb(226, 232, 240);
        private readonly GdiColor C_SUBTEXT = GdiColor.FromArgb(100, 116, 139);
        private readonly GdiColor C_BORDER = GdiColor.FromArgb(51, 65, 85);
        private readonly GdiColor C_ROW_ALT = GdiColor.FromArgb(26, 34, 52);

        // ── Datos ─────────────────────────────────────────────────────────────
        private DataTable dtFacturas = new DataTable();
        private DataTable dtFiltrado = new DataTable();

        // ── Controles ─────────────────────────────────────────────────────────
        private Panel pnlTop, pnlFiltros, pnlKPIs, pnlGrafico, pnlGrid, pnlBottom, pnlChart, pnlTipo;
        private ComboBox cmbTipoFactura, cmbMes, cmbAnio, cmbCliente;
        private DataGridView dgv;
        private Button btnFiltrar, btnLimpiar, btnExportarPDF;

        // ── Stats ─────────────────────────────────────────────────────────────
        private decimal totalVentas = 0;
        private int cantFacturas = 0;
        private decimal ticketPromedio = 0;
        private decimal mayorVenta = 0;
        private Dictionary<string, decimal> ventasPorMes = new Dictionary<string, decimal>();
        private Dictionary<string, decimal> ventasPorTipo = new Dictionary<string, decimal>();

        private string ConString =>
            System.Configuration.ConfigurationManager
                  .ConnectionStrings["conexionDB"].ConnectionString;

        // ════════════════════════════════════════════════════════════════════
        //  CONSTRUCTOR
        // ════════════════════════════════════════════════════════════════════
        public FormDashboardVentas()
        {
            // NO llamamos InitializeComponent() porque el form es 100% código
            // Si el designer generó un .Designer.cs vacío, está bien así.
            this.SuspendLayout();

            this.Text = "Dashboard de Ventas";
            this.Size = new Size(1280, 820);
            this.MinimumSize = new Size(1100, 700);
            this.BackColor = C_BG;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Font = new GdiFont("Segoe UI", 9f);
            this.DoubleBuffered = true;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;

            ConstruirUI();

            this.ResumeLayout(false);

            CargarFiltros();
            CargarDatos();
        }

        // ════════════════════════════════════════════════════════════════════
        //  CONSTRUCCIÓN DE LA UI
        // ════════════════════════════════════════════════════════════════════
        private void ConstruirUI()
        {
            // ── Header ──────────────────────────────────────────────────────
            pnlTop = new Panel { Dock = DockStyle.Top, Height = 64, BackColor = C_SURFACE };
            pnlTop.Paint += PnlTop_Paint;

            // ── Filtros ──────────────────────────────────────────────────────
            pnlFiltros = new Panel
            {
                Dock = DockStyle.Top,
                Height = 68,
                BackColor = C_SURFACE,
                Padding = new Padding(16, 10, 16, 10)
            };
            pnlFiltros.Paint += (s, e) =>
            {
                using (var p = new Pen(C_BORDER, 1))
                {
                    e.Graphics.DrawLine(p, 0, 0, pnlFiltros.Width, 0);
                    e.Graphics.DrawLine(p, 0, pnlFiltros.Height - 1, pnlFiltros.Width, pnlFiltros.Height - 1);
                }
            };
            ConstruirFiltros();

            // ── KPIs ────────────────────────────────────────────────────────
            pnlKPIs = new Panel { Dock = DockStyle.Top, Height = 110, BackColor = C_BG, Padding = new Padding(16, 10, 16, 10) };
            pnlKPIs.Paint += PnlKPIs_Paint;
            pnlKPIs.Resize += (s, e) => pnlKPIs.Invalidate();

            // ── Centro: gráficos + grilla ────────────────────────────────────
            var pnlCentro = new Panel { Dock = DockStyle.Fill, BackColor = C_BG };

            pnlGrafico = new Panel { Dock = DockStyle.Left, Width = 420, BackColor = C_BG, Padding = new Padding(16, 8, 8, 8) };
            ConstruirGrafico();

            pnlGrid = new Panel { Dock = DockStyle.Fill, BackColor = C_BG, Padding = new Padding(8, 8, 16, 8) };
            ConstruirGrid();

            pnlCentro.Controls.Add(pnlGrid);
            pnlCentro.Controls.Add(pnlGrafico);

            // ── Bottom ───────────────────────────────────────────────────────
            pnlBottom = new Panel { Dock = DockStyle.Bottom, Height = 46, BackColor = C_SURFACE };
            ConstruirBottom();

            // ── Ensamblar ────────────────────────────────────────────────────
            this.Controls.Add(pnlCentro);
            this.Controls.Add(pnlKPIs);
            this.Controls.Add(pnlFiltros);
            this.Controls.Add(pnlTop);
            this.Controls.Add(pnlBottom);
        }

        // ── HEADER ──────────────────────────────────────────────────────────
        private void PnlTop_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Línea acento inferior
            using (var p = new Pen(C_ACCENT, 2))
                g.DrawLine(p, 0, pnlTop.Height - 1, pnlTop.Width, pnlTop.Height - 1);

            // Barras decorativas
            using (var br = new SolidBrush(C_ACCENT))
                g.FillRectangle(br, 20, 20, 4, 24);
            using (var br = new SolidBrush(C_ACCENT2))
                g.FillRectangle(br, 28, 28, 4, 16);

            // Título
            using (var f = new GdiFont("Segoe UI", 16f, FontStyle.Bold))
            using (var br = new SolidBrush(C_TEXT))
                g.DrawString("DASHBOARD DE VENTAS", f, br, 42, 14);

            using (var f = new GdiFont("Segoe UI", 8f))
            using (var br = new SolidBrush(C_SUBTEXT))
                g.DrawString("Análisis y seguimiento de facturación", f, br, 44, 40);
        }

        // ── FILTROS ─────────────────────────────────────────────────────────
        private void ConstruirFiltros()
        {
            int x = 16, y = 16;

            void Agregar(string lbl, ComboBox c, int w)
            {
                var label = new Label
                {
                    Text = lbl,
                    AutoSize = false,
                    Width = w,
                    Height = 16,
                    Location = new Point(x, y),
                    ForeColor = C_SUBTEXT,
                    Font = new GdiFont("Segoe UI", 7.5f),
                    BackColor = GdiColor.Transparent
                };
                c.Location = new Point(x, y + 18);
                c.Width = w; c.Height = 28;
                pnlFiltros.Controls.Add(label);
                pnlFiltros.Controls.Add(c);
                x += w + 12;
            }

            cmbTipoFactura = CrearCombo();
            cmbMes = CrearCombo();
            cmbAnio = CrearCombo();
            cmbCliente = CrearCombo();

            Agregar("Tipo de Factura", cmbTipoFactura, 130);
            Agregar("Mes", cmbMes, 110);
            Agregar("Año", cmbAnio, 90);
            Agregar("Cliente", cmbCliente, 200);

            btnFiltrar = CrearBoton("⚲  FILTRAR", C_ACCENT);
            btnFiltrar.Location = new Point(x, y + 14);
            btnFiltrar.Size = new Size(110, 30);
            btnFiltrar.Click += (s, e) => CargarDatos();
            pnlFiltros.Controls.Add(btnFiltrar);

            x += 118;
            btnLimpiar = CrearBoton("✕  LIMPIAR", C_SURFACE);
            btnLimpiar.ForeColor = C_SUBTEXT;
            btnLimpiar.FlatAppearance.BorderColor = C_BORDER;
            btnLimpiar.FlatAppearance.BorderSize = 1;
            btnLimpiar.Location = new Point(x, y + 14);
            btnLimpiar.Size = new Size(100, 30);
            btnLimpiar.Click += (s, e) =>
            {
                cmbTipoFactura.SelectedIndex = 0;
                cmbMes.SelectedIndex = 0;
                cmbAnio.SelectedIndex = 0;
                cmbCliente.SelectedIndex = 0;
                CargarDatos();
            };
            pnlFiltros.Controls.Add(btnLimpiar);
        }

        private ComboBox CrearCombo()
        {
            return new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat,
                BackColor = C_CARD,
                ForeColor = C_TEXT,
                Font = new GdiFont("Segoe UI", 9f)
            };
        }

        private Button CrearBoton(string texto, GdiColor bg)
        {
            var b = new Button
            {
                Text = texto,
                FlatStyle = FlatStyle.Flat,
                BackColor = bg,
                ForeColor = C_BG,
                Font = new GdiFont("Segoe UI", 9f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            b.FlatAppearance.BorderSize = 0;
            return b;
        }

        // ── KPIs ─────────────────────────────────────────────────────────────
        private void PnlKPIs_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int pad = 16, gap = 12;
            int cardW = (pnlKPIs.Width - pad * 2 - gap * 3) / 4;
            int h = 86, y = 10;

            DrawKPI(g, pad, y, cardW, h, "TOTAL VENTAS", "$" + totalVentas.ToString("N0"), C_ACCENT, "▲");
            DrawKPI(g, pad + (cardW + gap), y, cardW, h, "FACTURAS", cantFacturas.ToString(), C_ACCENT2, "#");
            DrawKPI(g, pad + 2 * (cardW + gap), y, cardW, h, "TICKET PROMEDIO", "$" + ticketPromedio.ToString("N0"), C_GREEN, "≈");
            DrawKPI(g, pad + 3 * (cardW + gap), y, cardW, h, "MAYOR VENTA", "$" + mayorVenta.ToString("N0"), C_ORANGE, "★");
        }

        private void DrawKPI(Graphics g, int x, int y, int w, int h, string titulo, string valor, GdiColor acento, string icono)
        {
            // Card fondo
            using (var path = RoundedPath(new GdiRect(x, y, w, h), 10))
            {
                using (var br = new SolidBrush(C_CARD))
                    g.FillPath(br, path);
                using (var pen = new Pen(C_BORDER, 1))
                    g.DrawPath(pen, path);
            }

            // Barra acento izquierda
            using (var br = new SolidBrush(acento))
                g.FillRectangle(br, x, y + 18, 3, h - 36);

            // Ícono círculo
            using (var br = new SolidBrush(GdiColor.FromArgb(30, acento)))
                g.FillEllipse(br, x + w - 42, y + 12, 30, 30);
            using (var f = new GdiFont("Segoe UI", 12f))
            using (var br = new SolidBrush(acento))
                g.DrawString(icono, f, br, x + w - 38, y + 15);

            // Título
            using (var f = new GdiFont("Segoe UI", 7.5f))
            using (var br = new SolidBrush(C_SUBTEXT))
                g.DrawString(titulo, f, br, x + 12, y + 12);

            // Valor
            using (var f = new GdiFont("Segoe UI", 15f, FontStyle.Bold))
            using (var br = new SolidBrush(C_TEXT))
                g.DrawString(valor, f, br, x + 10, y + 32);
        }

        // ── GRÁFICOS ─────────────────────────────────────────────────────────
        private void ConstruirGrafico()
        {
            var lblBar = new Label
            {
                Text = "VENTAS POR MES",
                Dock = DockStyle.Top,
                Height = 26,
                ForeColor = C_SUBTEXT,
                Font = new GdiFont("Segoe UI", 8f, FontStyle.Bold),
                BackColor = GdiColor.Transparent,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(4, 0, 0, 0)
            };

            pnlChart = new Panel { Dock = DockStyle.Top, Height = 170, BackColor = GdiColor.Transparent };
            pnlChart.Paint += PnlChart_Paint;
            pnlChart.Resize += (s, e) => pnlChart.Invalidate();

            var lblTipo = new Label
            {
                Text = "POR TIPO DE FACTURA",
                Dock = DockStyle.Top,
                Height = 26,
                ForeColor = C_SUBTEXT,
                Font = new GdiFont("Segoe UI", 8f, FontStyle.Bold),
                BackColor = GdiColor.Transparent,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(4, 0, 0, 0)
            };

            pnlTipo = new Panel { Dock = DockStyle.Top, Height = 140, BackColor = GdiColor.Transparent };
            pnlTipo.Paint += PnlTipo_Paint;
            pnlTipo.Resize += (s, e) => pnlTipo.Invalidate();

            // Orden inverso porque Dock.Top apila de abajo hacia arriba
            pnlGrafico.Controls.Add(pnlTipo);
            pnlGrafico.Controls.Add(lblTipo);
            pnlGrafico.Controls.Add(pnlChart);
            pnlGrafico.Controls.Add(lblBar);
        }

        private void PnlChart_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int pw = pnlChart.Width - 16, ph = pnlChart.Height - 10;

            using (var path = RoundedPath(new GdiRect(8, 0, pw, ph), 10))
            using (var br = new SolidBrush(C_CARD))
                g.FillPath(br, path);
            using (var path = RoundedPath(new GdiRect(8, 0, pw, ph), 10))
            using (var pen = new Pen(C_BORDER, 1))
                g.DrawPath(pen, path);

            if (ventasPorMes == null || ventasPorMes.Count == 0) return;

            var keys = ventasPorMes.Keys.ToList();
            var vals = ventasPorMes.Values.ToList();
            decimal mx = vals.Max();
            if (mx == 0) return;

            int n = keys.Count;
            int padL = 52, padR = 12, padT = 12, padB = 28;
            int chartW = pw - padL - padR;
            int chartH = ph - padT - padB;
            int baseY = padT + chartH;
            int barW = Math.Max(6, chartW / n - 4);

            // Líneas guía horizontales
            for (int gi = 1; gi <= 4; gi++)
            {
                int lineY = baseY - (int)(chartH * gi / 4.0);
                using (var pen = new Pen(GdiColor.FromArgb(25, 255, 255, 255), 1))
                    g.DrawLine(pen, 8 + padL, lineY, 8 + padL + chartW, lineY);
                using (var f = new GdiFont("Segoe UI", 6.5f))
                using (var br = new SolidBrush(C_SUBTEXT))
                    g.DrawString("$" + (mx * gi / 4m).ToString("N0"), f, br, 10, lineY - 8);
            }

            // Barras con gradiente usando dos puntos
            for (int i = 0; i < n; i++)
            {
                int bh = Math.Max(2, (int)(chartH * vals[i] / mx));
                int bx = 8 + padL + i * (chartW / n) + (chartW / n - barW) / 2;
                int by = baseY - bh;

                // LinearGradientBrush con dos puntos PointF (sin Rectangle ni LinearGradientMode)
                var ptTop = new PointF(bx, by);
                var ptBottom = new PointF(bx, by + bh);
                using (var grad = new LinearGradientBrush(ptTop, ptBottom, C_ACCENT, C_ACCENT2))
                {
                    g.FillRectangle(grad, bx, by, barW, bh);
                }

                string mes = keys[i].Length >= 3 ? keys[i].Substring(0, 3) : keys[i];
                using (var f = new GdiFont("Segoe UI", 6.5f))
                using (var br = new SolidBrush(C_SUBTEXT))
                    g.DrawString(mes, f, br, bx - 1, baseY + 4);
            }
        }

        private void PnlTipo_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int pw = pnlTipo.Width - 16, ph = pnlTipo.Height - 6;

            using (var path = RoundedPath(new GdiRect(8, 0, pw, ph), 10))
            using (var br = new SolidBrush(C_CARD))
                g.FillPath(br, path);
            using (var path = RoundedPath(new GdiRect(8, 0, pw, ph), 10))
            using (var pen = new Pen(C_BORDER, 1))
                g.DrawPath(pen, path);

            if (ventasPorTipo == null || ventasPorTipo.Count == 0) return;

            var tipos = ventasPorTipo.Keys.ToList();
            var montos = ventasPorTipo.Values.ToList();
            decimal tot = montos.Sum();
            if (tot == 0) return;

            GdiColor[] colores = { C_ACCENT, C_ACCENT2, C_GREEN, C_ORANGE, GdiColor.FromArgb(236, 72, 153) };
            int yy = 14, xStart = 20, trackW = pw - 70;

            for (int i = 0; i < tipos.Count && i < colores.Length; i++)
            {
                float pct = (float)(montos[i] / tot);
                int fw = (int)(trackW * pct);

                using (var br = new SolidBrush(colores[i]))
                    g.FillEllipse(br, xStart, yy + 4, 8, 8);

                using (var f = new GdiFont("Segoe UI", 8f))
                using (var br = new SolidBrush(C_TEXT))
                    g.DrawString(tipos[i], f, br, xStart + 13, yy + 1);

                // Track
                using (var br = new SolidBrush(GdiColor.FromArgb(25, 255, 255, 255)))
                    g.FillRectangle(br, xStart, yy + 18, trackW, 5);
                if (fw > 0)
                    using (var br = new SolidBrush(colores[i]))
                        g.FillRectangle(br, xStart, yy + 18, fw, 5);

                using (var f = new GdiFont("Segoe UI", 7f))
                using (var br = new SolidBrush(C_SUBTEXT))
                    g.DrawString((pct * 100).ToString("N0") + "%", f, br, xStart + trackW + 6, yy + 1);

                yy += 30;
            }
        }

        // ── GRILLA ──────────────────────────────────────────────────────────
        private void ConstruirGrid()
        {
            var lblTitle = new Label
            {
                Text = "DETALLE DE FACTURAS   —   doble clic para abrir PDF",
                Dock = DockStyle.Top,
                Height = 26,
                ForeColor = C_SUBTEXT,
                Font = new GdiFont("Segoe UI", 8f, FontStyle.Bold),
                BackColor = GdiColor.Transparent,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(4, 0, 0, 0)
            };

            dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = C_CARD,
                GridColor = C_BORDER,
                BorderStyle = BorderStyle.None,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToResizeRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Font = new GdiFont("Segoe UI", 9f)
            };

            dgv.ColumnHeadersDefaultCellStyle.BackColor = C_SURFACE;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = C_ACCENT;
            dgv.ColumnHeadersDefaultCellStyle.Font = new GdiFont("Segoe UI", 8.5f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = C_SURFACE;
            dgv.ColumnHeadersHeight = 36;
            dgv.EnableHeadersVisualStyles = false;

            dgv.DefaultCellStyle.BackColor = C_CARD;
            dgv.DefaultCellStyle.ForeColor = C_TEXT;
            dgv.DefaultCellStyle.SelectionBackColor = GdiColor.FromArgb(40, 56, 189, 248);
            dgv.DefaultCellStyle.SelectionForeColor = C_TEXT;
            dgv.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);
            dgv.RowTemplate.Height = 34;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = C_ROW_ALT;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = C_TEXT;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = GdiColor.FromArgb(40, 56, 189, 248);

            dgv.CellDoubleClick += Dgv_CellDoubleClick;
            dgv.CellFormatting += Dgv_CellFormatting;

            pnlGrid.Controls.Add(dgv);
            pnlGrid.Controls.Add(lblTitle);
        }

        // ── BOTTOM ───────────────────────────────────────────────────────────
        private void ConstruirBottom()
        {
            btnExportarPDF = CrearBoton("⬇  EXPORTAR PDF", C_ACCENT2);
            btnExportarPDF.Size = new Size(150, 30);
            btnExportarPDF.Location = new Point(16, 8);
            btnExportarPDF.Click += BtnExportarPDF_Click;

            var lblInfo = new Label
            {
                Text = "SurFe · Sistema de Gestión Comercial",
                AutoSize = true,
                ForeColor = C_SUBTEXT,
                Font = new GdiFont("Segoe UI", 8f),
                BackColor = GdiColor.Transparent
            };
            lblInfo.Location = new Point(pnlBottom.Width - 270, 14);
            lblInfo.Anchor = AnchorStyles.Right | AnchorStyles.Top;

            pnlBottom.Paint += (s, e) =>
            {
                using (var p = new Pen(C_BORDER, 1))
                    e.Graphics.DrawLine(p, 0, 0, pnlBottom.Width, 0);
            };

            pnlBottom.Controls.Add(btnExportarPDF);
            pnlBottom.Controls.Add(lblInfo);
        }

        // ════════════════════════════════════════════════════════════════════
        //  CARGA DE DATOS Y FILTROS
        // ════════════════════════════════════════════════════════════════════
        private void CargarFiltros()
        {
            try
            {
                using (var con = new SqlConnection(ConString))
                {
                    con.Open();

                    cmbTipoFactura.Items.Clear();
                    cmbTipoFactura.Items.Add(new ComboItem("Todos", null));
                    var dt1 = Query(con, "SELECT id, descripcion FROM tipo_factura ORDER BY descripcion");
                    foreach (DataRow r in dt1.Rows)
                        cmbTipoFactura.Items.Add(new ComboItem(r["descripcion"].ToString(), r["id"].ToString()));
                    cmbTipoFactura.SelectedIndex = 0;

                    cmbMes.Items.Clear();
                    cmbMes.Items.Add(new ComboItem("Todos", null));
                    string[] meses = { "Enero","Febrero","Marzo","Abril","Mayo","Junio",
                                       "Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre" };
                    for (int m = 1; m <= 12; m++)
                        cmbMes.Items.Add(new ComboItem(meses[m - 1], m.ToString()));
                    cmbMes.SelectedIndex = 0;

                    cmbAnio.Items.Clear();
                    cmbAnio.Items.Add(new ComboItem("Todos", null));
                    var dt2 = Query(con, "SELECT DISTINCT YEAR(fecha) AS a FROM factura WHERE fecha IS NOT NULL ORDER BY a DESC");
                    foreach (DataRow r in dt2.Rows)
                        cmbAnio.Items.Add(new ComboItem(r["a"].ToString(), r["a"].ToString()));
                    cmbAnio.SelectedIndex = 0;

                    cmbCliente.Items.Clear();
                    cmbCliente.Items.Add(new ComboItem("Todos", null));
                    var dt3 = Query(con, "SELECT id_cliente, razon_social FROM cliente WHERE anulado = 0 ORDER BY razon_social");
                    foreach (DataRow r in dt3.Rows)
                        cmbCliente.Items.Add(new ComboItem(r["razon_social"].ToString(), r["id_cliente"].ToString()));
                    cmbCliente.SelectedIndex = 0;
                }
            }
            catch (Exception ex) { Error("Error cargando filtros: " + ex.Message); }
        }

        private void CargarDatos()
        {
            try
            {
                var parametros = new List<SqlParameter>();
                var conds = new List<string>();

                if (cmbTipoFactura.SelectedItem is ComboItem tf && tf.Value != null)
                { conds.Add("f.tipo_documento = @tipo"); parametros.Add(new SqlParameter("@tipo", tf.Value)); }

                if (cmbMes.SelectedItem is ComboItem me && me.Value != null)
                { conds.Add("MONTH(f.fecha) = @mes"); parametros.Add(new SqlParameter("@mes", int.Parse(me.Value))); }

                if (cmbAnio.SelectedItem is ComboItem an && an.Value != null)
                { conds.Add("YEAR(f.fecha) = @anio"); parametros.Add(new SqlParameter("@anio", int.Parse(an.Value))); }

                if (cmbCliente.SelectedItem is ComboItem cl && cl.Value != null)
                { conds.Add("f.id_cliente = @cliente"); parametros.Add(new SqlParameter("@cliente", cl.Value)); }

                string where = conds.Count > 0 ? "WHERE " + string.Join(" AND ", conds) : "";

                string sql = $@"
                    SELECT
                        f.id_factura                    AS [N° Factura],
                        c.razon_social                  AS [Cliente],
                        td.descripcion                  AS [Tipo],
                        CONVERT(varchar, f.fecha, 103)  AS [Fecha],
                        f.total                         AS [Total],
                        f.location                      AS [__location]
                    FROM factura f
                    JOIN cliente      c  ON f.id_cliente    = c.id_cliente
                    JOIN tipo_factura td ON f.tipo_documento = td.id
                    {where}
                    ORDER BY f.fecha DESC";

                using (var con = new SqlConnection(ConString))
                {
                    con.Open();
                    var cmd = new SqlCommand(sql, con);
                    foreach (var p in parametros) cmd.Parameters.Add(p);
                    dtFacturas = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dtFacturas);
                }

                dtFiltrado = dtFacturas.Copy();
                dgv.DataSource = dtFiltrado;

                if (dgv.Columns.Contains("__location"))
                    dgv.Columns["__location"].Visible = false;

                if (dgv.Columns.Contains("Total"))
                {
                    dgv.Columns["Total"].DefaultCellStyle.Format = "N2";
                    dgv.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (dgv.Columns.Contains("N° Factura"))
                    dgv.Columns["N° Factura"].FillWeight = 50;

                CalcularEstadisticas();
                pnlKPIs.Invalidate();
                pnlChart?.Invalidate();
                pnlTipo?.Invalidate();
            }
            catch (Exception ex) { Error("Error cargando datos: " + ex.Message); }
        }

        private void CalcularEstadisticas()
        {
            ventasPorMes = new Dictionary<string, decimal>();
            ventasPorTipo = new Dictionary<string, decimal>();
            totalVentas = ticketPromedio = mayorVenta = 0;
            cantFacturas = 0;

            if (dtFacturas.Rows.Count == 0) return;

            var totales = dtFacturas.AsEnumerable()
                .Where(r => !r.IsNull("Total"))
                .Select(r => Convert.ToDecimal(r["Total"])).ToList();

            totalVentas = totales.Sum();
            cantFacturas = dtFacturas.Rows.Count;
            ticketPromedio = totales.Count > 0 ? totales.Average() : 0;
            mayorVenta = totales.Count > 0 ? totales.Max() : 0;

            string[] nm = { "", "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic" };

            ventasPorMes = dtFacturas.AsEnumerable()
                .Where(r => !r.IsNull("Total") && !r.IsNull("Fecha"))
                .GroupBy(r =>
                {
                    var p = r["Fecha"].ToString().Split('/');
                    if (p.Length == 3 && int.TryParse(p[1], out int mes) && int.TryParse(p[2], out int anio))
                        return nm[mes] + " " + (anio % 100);
                    return "?";
                })
                .ToDictionary(g => g.Key, g => g.Sum(r => Convert.ToDecimal(r["Total"])));

            ventasPorTipo = dtFacturas.AsEnumerable()
                .Where(r => !r.IsNull("Total"))
                .GroupBy(r => r["Tipo"].ToString())
                .ToDictionary(g => g.Key, g => g.Sum(r => Convert.ToDecimal(r["Total"])));
        }

        // ════════════════════════════════════════════════════════════════════
        //  EVENTOS GRILLA
        // ════════════════════════════════════════════════════════════════════
        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string loc = dgv.Rows[e.RowIndex].Cells["__location"]?.Value?.ToString() ?? "";

            if (string.IsNullOrEmpty(loc))
            {
                MessageBox.Show("Esta factura no tiene PDF asociado.", "Sin PDF",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Normalizamos la ruta antes de pasarla al PDFView
            loc = System.IO.Path.GetFullPath(loc);

            if (!System.IO.File.Exists(loc))
            {
                MessageBox.Show("No se encontró el archivo:\n" + loc,
                    "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            new PDFView(loc).ShowDialog();
        }

        private void Dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0 || e.Value == null) return;
            if (dgv.Columns[e.ColumnIndex].Name != "Tipo") return;
            string t = e.Value.ToString().ToUpper();
            if (t.Contains("A")) e.CellStyle.ForeColor = C_ORANGE;
            else if (t.Contains("B")) e.CellStyle.ForeColor = C_ACCENT;
            else if (t.Contains("C")) e.CellStyle.ForeColor = C_GREEN;
            else if (t.Contains("E")) e.CellStyle.ForeColor = GdiColor.FromArgb(236, 72, 153);
        }

        // ════════════════════════════════════════════════════════════════════
        //  EXPORTAR PDF
        // ════════════════════════════════════════════════════════════════════
        private void BtnExportarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "VentasDashboard_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".pdf");

                using (var stream = new FileStream(ruta, FileMode.Create))
                {
                    // Usamos iTextSharp con los alias para evitar ambigüedad
                    var doc = new iDoc(PageSize.A4.Rotate(), 20, 20, 30, 20);
                    iPdfWriter.GetInstance(doc, stream);
                    doc.Open();

                    var fTit = iFontFactory.GetFont(iFontFactory.HELVETICA_BOLD, 16, new iBaseColor(56, 189, 248));
                    var fSub = iFontFactory.GetFont(iFontFactory.HELVETICA, 9, new iBaseColor(100, 116, 139));
                    var fHdr = iFontFactory.GetFont(iFontFactory.HELVETICA_BOLD, 8, new iBaseColor(255, 255, 255));
                    var fCell = iFontFactory.GetFont(iFontFactory.HELVETICA, 8, new iBaseColor(30, 30, 30)); // texto oscuro    
                    var fTot = iFontFactory.GetFont(iFontFactory.HELVETICA_BOLD, 10, new iBaseColor(56, 189, 248));

                    doc.Add(new iParagraph("DASHBOARD DE VENTAS", fTit));
                    doc.Add(new iParagraph(
                        "Generado: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") +
                        "   |   Registros: " + dtFiltrado.Rows.Count, fSub));
                    doc.Add(new iParagraph(" "));

                    // KPIs
                    var tKPI = new iPdfTable(4) { WidthPercentage = 100 };
                    void AddKpi(string lbl, string val, iBaseColor col)
                    {
                        var cell = new iPdfCell();
                        cell.AddElement(new iParagraph(lbl, iFontFactory.GetFont(iFontFactory.HELVETICA, 7, new iBaseColor(100, 116, 139))));
                        cell.AddElement(new iParagraph(val, iFontFactory.GetFont(iFontFactory.HELVETICA_BOLD, 13, col)));
                        cell.BackgroundColor = new iBaseColor(30, 38, 60);
                        cell.BorderColor = new iBaseColor(51, 65, 85);
                        cell.Padding = 8;
                        tKPI.AddCell(cell);
                    }
                    AddKpi("TOTAL VENTAS", "$" + totalVentas.ToString("N0"), new iBaseColor(56, 189, 248));
                    AddKpi("FACTURAS", cantFacturas.ToString(), new iBaseColor(99, 102, 241));
                    AddKpi("TICKET PROMEDIO", "$" + ticketPromedio.ToString("N0"), new iBaseColor(34, 197, 94));
                    AddKpi("MAYOR VENTA", "$" + mayorVenta.ToString("N0"), new iBaseColor(251, 146, 60));
                    doc.Add(tKPI);
                    doc.Add(new iParagraph(" "));

                    // Tabla facturas
                    string[] cols = { "N° Factura", "Cliente", "Tipo", "Fecha", "Total" };
                    var tbl = new iPdfTable(cols.Length) { WidthPercentage = 100 };
                    tbl.SetWidths(new float[] { 1f, 3f, 1f, 1.5f, 1.5f });

                    foreach (var col in cols)
                    {
                        tbl.AddCell(new iPdfCell(new iPhrase(col, fHdr))
                        {
                            BackgroundColor = new iBaseColor(22, 28, 45),
                            Padding = 6
                        });
                    }

                    bool alt = false;
                    foreach (DataRow row in dtFacturas.Rows)
                    {
                        // Saltear filas donde el N° de factura esté vacío
                        if (row.IsNull("N° Factura") || string.IsNullOrWhiteSpace(row["N° Factura"].ToString()))
                            continue;

                        var bg = alt ? new iBaseColor(240, 244, 248) : new iBaseColor(255, 255, 255);

                        string nroFactura = row["N° Factura"]?.ToString() ?? "";
                        string cliente = row["Cliente"]?.ToString() ?? "";
                        string tipo = row["Tipo"]?.ToString() ?? "";
                        string fecha = row["Fecha"]?.ToString() ?? "";
                        string total = "";

                        if (!row.IsNull("Total"))
                            total = "$" + Convert.ToDecimal(row["Total"]).ToString("N2");

                        foreach (string v in new[] { nroFactura, cliente, tipo, fecha, total })
                        {
                            tbl.AddCell(new iPdfCell(new iPhrase(v, fCell))
                            {
                                BackgroundColor = bg,
                                BorderColor = new iBaseColor(51, 65, 85),
                                Padding = 5
                            });
                        }
                        alt = !alt;
                    }
                    doc.Add(tbl);
                    doc.Add(new iParagraph(" "));
                    doc.Add(new iParagraph("TOTAL: $" + totalVentas.ToString("N2"), fTot));
                    doc.Close();
                }

                new PDFView(ruta).ShowDialog();
            }
            catch (Exception ex) { Error("Error exportando PDF: " + ex.Message); }
        }

        // ════════════════════════════════════════════════════════════════════
        //  HELPERS
        // ════════════════════════════════════════════════════════════════════
        private GraphicsPath RoundedPath(GdiRect r, int radius)
        {
            var path = new GraphicsPath();
            path.AddArc(r.X, r.Y, radius * 2, radius * 2, 180, 90);
            path.AddArc(r.Right - radius * 2, r.Y, radius * 2, radius * 2, 270, 90);
            path.AddArc(r.Right - radius * 2, r.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(r.X, r.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();
            return path;
        }

        private DataTable Query(SqlConnection con, string sql)
        {
            var dt = new DataTable();
            new SqlDataAdapter(new SqlCommand(sql, con)).Fill(dt);
            return dt;
        }

        private void Error(string msg) =>
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    // ── Clase auxiliar para los ComboBox ─────────────────────────────────────
    public class ComboItem
    {
        public string Text { get; }
        public string Value { get; }
        public ComboItem(string text, string value) { Text = text; Value = value; }
        public override string ToString() => Text;
    }
}