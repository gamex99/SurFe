using ScottPlot;
using ScottPlot.WinForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Color = System.Drawing.Color;
using Label = System.Windows.Forms.Label;
using Panel = System.Windows.Forms.Panel;
using Orientation = ScottPlot.Orientation;

namespace SurFeFront
{
    public partial class TestChartTop10productos : Form
    {
        readonly FormsPlot FormsPlot1 = new FormsPlot() { Dock = DockStyle.Fill };

        private System.Windows.Forms.Timer _animTimer;
        private double _animProgress = 0;
        private double[] _finalValues;
        private string[] _finalLabels;
        private byte[] _plotClaroCache;

        public TestChartTop10productos()
        {
            InitializeComponent();
            AplicarTemaOscuro();
            panelGrafico.Controls.Add(FormsPlot1);
            ConfigurarFiltrosIniciales();
            CargarDatos();
        }

        // ════════════════════════════════════════════
        //  TEMA OSCURO
        // ════════════════════════════════════════════
        private void AplicarTemaOscuro()
        {
            this.BackColor = Color.FromArgb(18, 18, 30);
            panelTop.BackColor = Color.FromArgb(28, 28, 45);
            panelFiltros.BackColor = Color.FromArgb(28, 28, 45);
            panelKpis.BackColor = Color.FromArgb(28, 28, 45);
            panelGrafico.BackColor = Color.FromArgb(18, 18, 30);

            lblTitulo.ForeColor = Color.FromArgb(120, 180, 255);
            lblSubtitulo.ForeColor = Color.FromArgb(160, 160, 200);

            foreach (Label lbl in new[] { lblMes, lblAnio, lblTop, lblPeriodo })
                lbl.ForeColor = Color.FromArgb(160, 160, 200);

            foreach (System.Windows.Forms.ComboBox cmb in new[] { cmbMes, cmbAnio, cmbTop })
            {
                cmb.BackColor = Color.FromArgb(38, 38, 58);
                cmb.ForeColor = Color.White;
            }
            foreach (System.Windows.Forms.RadioButton rb in new[] { rbMensual, rbAnual })
            {
                rb.ForeColor = Color.FromArgb(160, 160, 200);
                rb.BackColor = Color.FromArgb(28, 28, 45);
            }

            btnActualizar.BackColor = Color.FromArgb(60, 100, 200);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.FlatAppearance.BorderColor = Color.FromArgb(80, 120, 220);

            btnExportarPDF.BackColor = Color.FromArgb(180, 60, 60);
            btnExportarPDF.ForeColor = Color.White;
            btnExportarPDF.FlatStyle = FlatStyle.Flat;
            btnExportarPDF.FlatAppearance.BorderColor = Color.FromArgb(200, 80, 80);

            foreach (Panel card in new[] { cardTotal, cardPromedio, cardMaximo })
                card.BackColor = Color.FromArgb(38, 38, 58);

            foreach (Label lbl in new[] { lblTotalVal, lblPromedioVal, lblMaximoVal,
                                          lblTotalTxt, lblPromedioTxt, lblMaximoTxt })
                lbl.ForeColor = Color.White;
        }

        // ════════════════════════════════════════════
        //  FILTROS INICIALES
        // ════════════════════════════════════════════
        private void ConfigurarFiltrosIniciales()
        {
            for (int i = 2020; i <= DateTime.Now.Year; i++) cmbAnio.Items.Add(i);
            cmbAnio.SelectedItem = DateTime.Now.Year;

            cmbMes.DataSource = System.Globalization.CultureInfo.CurrentCulture
                .DateTimeFormat.MonthNames.Where(m => !string.IsNullOrEmpty(m)).ToList();
            cmbMes.SelectedIndex = DateTime.Now.Month - 1;

            cmbTop.Items.AddRange(new object[] { "Top 5", "Top 10", "Top 20" });
            cmbTop.SelectedIndex = 1;

            rbMensual.CheckedChanged += (s, e) => cmbMes.Enabled = rbMensual.Checked;
            rbAnual.CheckedChanged += (s, e) => cmbMes.Enabled = !rbAnual.Checked;

            btnActualizar.Click += (s, e) => CargarDatos();
            btnExportarPDF.Click += BtnExportarPDF_Click;
        }

        // ════════════════════════════════════════════
        //  CARGA DE DATOS
        // ════════════════════════════════════════════
        private void CargarDatos()
        {
            int top = int.Parse(cmbTop.SelectedItem.ToString().Split(' ')[1]);

            var values = new List<double>();
            var labels = new List<string>();

            string connectionString = System.Configuration.ConfigurationManager
                .ConnectionStrings["conexionDB"].ConnectionString;

            // Consulta original — usa la columna [vendidos] directo de [producto]
            string query = $@"
        SELECT TOP {top}
            [detalle],
            [vendidos]
        FROM [dbo].[producto]
        WHERE [vendidos] > 0
        ORDER BY [vendidos] DESC";

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                        {
                            labels.Add(reader.GetString(0));
                            values.Add(Convert.ToDouble(reader.GetValue(1)));
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
                return;
            }

            if (values.Count == 0)
            {
                MessageBox.Show("Sin datos para mostrar.", "Sin Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Invertir: mayor queda arriba
            values.Reverse();
            labels.Reverse();

            _finalValues = values.ToArray();
            _finalLabels = labels.ToArray();

            ActualizarKpis(_finalValues, _finalLabels);
            IniciarAnimacion();
        
        }

        // ════════════════════════════════════════════
        //  KPIs
        // ════════════════════════════════════════════
        private void ActualizarKpis(double[] vals, string[] labs)
        {
            lblTotalVal.Text = vals.Sum().ToString("N0");
            lblPromedioVal.Text = vals.Average().ToString("N1");
            int idxMax = Array.IndexOf(vals, vals.Max());
            string nombreTop = labs[idxMax].Length > 18
                ? labs[idxMax].Substring(0, 18) + "…"
                : labs[idxMax];
            lblMaximoVal.Text = $"{nombreTop}\n({vals.Max():N0})";
        }

        // ════════════════════════════════════════════
        //  ANIMACIÓN
        // ════════════════════════════════════════════
        private void IniciarAnimacion()
        {
            _animProgress = 0;
            _animTimer?.Stop();
            _animTimer = new System.Windows.Forms.Timer { Interval = 16 };
            _animTimer.Tick += (s, e) =>
            {
                _animProgress += 0.045;
                if (_animProgress >= 1.0) { _animProgress = 1.0; _animTimer.Stop(); }
                double t = 1 - Math.Pow(1 - _animProgress, 3);
                DibujarGrafico(_finalValues.Select(v => v * t).ToArray(), claro: false);
            };
            _animTimer.Start();
        }

        // ════════════════════════════════════════════
        //  DIBUJO DEL GRÁFICO
        // ════════════════════════════════════════════
        private void DibujarGrafico(double[] values, bool claro)
        {
            var plot = claro ? new ScottPlot.Plot() : FormsPlot1.Plot;
            plot.Clear();

            // ── Tema ──
            if (claro)
            {
                plot.FigureBackground.Color = ScottPlot.Color.FromHex("#FFFFFF");
                plot.DataBackground.Color = ScottPlot.Color.FromHex("#F5F7FF");
                plot.Axes.Color(ScottPlot.Color.FromHex("#333355"));
                plot.Grid.MajorLineColor = ScottPlot.Color.FromHex("#DDDDEE");
            }
            else
            {
                plot.FigureBackground.Color = ScottPlot.Color.FromHex("#12121E");
                plot.DataBackground.Color = ScottPlot.Color.FromHex("#1C1C2D");
                plot.Axes.Color(ScottPlot.Color.FromHex("#A0A0C8"));
                plot.Grid.MajorLineColor = ScottPlot.Color.FromHex("#2A2A42");
            }

            // ── Gradiente por ranking (azul → dorado, mayor = dorado) ──
            var barItems = new ScottPlot.Bar[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                double ratio = values.Length > 1 ? (double)i / (values.Length - 1) : 1;
                int r = (int)(58 + ratio * (245 - 58));
                int g = (int)(111 + ratio * (166 - 111));
                int b = (int)(216 + ratio * (35 - 216));

                barItems[i] = new ScottPlot.Bar
                {
                    Position = i,
                    Value = values[i],
                    FillColor = ScottPlot.Color.FromHex($"#{r:X2}{g:X2}{b:X2}"),
                    Label = _animProgress >= 1.0 ? values[i].ToString("N0") : string.Empty,
                    Orientation = Orientation.Horizontal
                };
            }
            plot.Add.Bars(barItems);

            // ── Línea de promedio vertical ──
            if (_animProgress >= 1.0)
            {
                double promedio = _finalValues.Average();
                var vline = plot.Add.VerticalLine(promedio);
                vline.Color = ScottPlot.Color.FromHex(claro ? "#CC3333" : "#FF6B6B");
                vline.LineWidth = 2;
                vline.LinePattern = ScottPlot.LinePattern.Dashed;

                var txt = plot.Add.Text($"Prom: {promedio:N1}", promedio, values.Length - 0.3);
                txt.LabelFontColor = ScottPlot.Color.FromHex(claro ? "#CC3333" : "#FF6B6B");
                txt.LabelFontSize = 9;
            }

            // ── Eje Y con nombres de productos ──
            var tickGen = new ScottPlot.TickGenerators.NumericManual();
            for (int i = 0; i < _finalLabels.Length; i++)
            {
                string nombre = _finalLabels[i].Length > 24
                    ? _finalLabels[i].Substring(0, 24) + "…"
                    : _finalLabels[i];
                tickGen.AddMajor(i, nombre);
            }
            plot.Axes.Left.TickGenerator = tickGen;
            plot.Axes.Left.TickLabelStyle.ForeColor =
                ScottPlot.Color.FromHex(claro ? "#333355" : "#A0A0C8");

            // ── Límites ──
            plot.Axes.SetLimitsX(0, _finalValues.Max() * 1.25);
            plot.Axes.SetLimitsY(-0.5, values.Length - 0.5);
            plot.Axes.Bottom.Label.Text = "Unidades Vendidas";
            plot.Axes.Bottom.Label.ForeColor =
                ScottPlot.Color.FromHex(claro ? "#333355" : "#A0A0C8");

            if (!claro)
                FormsPlot1.Refresh();
            else
                _plotClaroCache = plot.GetImageBytes(900, 520);
        }

        // ════════════════════════════════════════════
        //  EXPORTAR PDF → PDFView
        // ════════════════════════════════════════════
        private void BtnExportarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                DibujarGrafico(_finalValues, claro: true);
                byte[] pngGrafico = _plotClaroCache;

                string rutaTmp = Path.Combine(Path.GetTempPath(),
                    $"TopProductos_{DateTime.Now:yyyyMMdd_HHmm}.pdf");

                using (var ms = new MemoryStream())
                {
                    var pageSize = iTextSharp.text.PageSize.A4;
                    var doc = new Document(pageSize, 40, 40, 50, 40);
                    var writer = PdfWriter.GetInstance(doc, ms);
                    doc.Open();

                    // ── Fondo blanco ──
                    var cb = writer.DirectContentUnder;
                    cb.SetColorFill(BaseColor.WHITE);
                    cb.Rectangle(0, 0, pageSize.Width, pageSize.Height);
                    cb.Fill();

                    // ── Fuentes ──
                    var colorTitulo = new BaseColor(30, 80, 180);
                    var colorSub = new BaseColor(80, 80, 110);
                    var colorCard = new BaseColor(235, 238, 248);
                    var colorCardVal = new BaseColor(20, 20, 50);

                    var fTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20, colorTitulo);
                    var fSub = FontFactory.GetFont(FontFactory.HELVETICA, 9, colorSub);
                    var fKpiTxt = FontFactory.GetFont(FontFactory.HELVETICA, 7, colorSub);
                    var fKpiVal = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 13, colorCardVal);
                    var fSeccion = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, colorTitulo);

                    // ── Encabezado ──
                    int top = int.Parse(cmbTop.SelectedItem.ToString().Split(' ')[1]);
                    string periodo = rbMensual.Checked
                        ? $"{cmbMes.SelectedItem} {cmbAnio.SelectedItem}"
                        : cmbAnio.SelectedItem.ToString();

                    doc.Add(new Paragraph($"Top {top} Productos Más Vendidos", fTitulo)
                    { Alignment = Element.ALIGN_CENTER, SpacingAfter = 2 });
                    doc.Add(new Paragraph(
                        $"Período: {periodo}  |  Generado: {DateTime.Now:dd/MM/yyyy HH:mm}",
                        fSub)
                    { Alignment = Element.ALIGN_CENTER, SpacingAfter = 16 });

                    // ── KPIs ──
                    var tablaKpi = new PdfPTable(3) { WidthPercentage = 100 };
                    tablaKpi.SpacingAfter = 16;

                    void AgregarKpi(string titulo, string valor)
                    {
                        var cell = new PdfPCell
                        {
                            Border = 0,
                            BackgroundColor = colorCard,
                            Padding = 10,
                            HorizontalAlignment = Element.ALIGN_CENTER
                        };
                        cell.AddElement(new Paragraph(titulo, fKpiTxt)
                        { Alignment = Element.ALIGN_CENTER });
                        cell.AddElement(new Paragraph(valor, fKpiVal)
                        { Alignment = Element.ALIGN_CENTER });
                        tablaKpi.AddCell(cell);
                    }

                    AgregarKpi("TOTAL UNIDADES VENDIDAS", lblTotalVal.Text);
                    AgregarKpi("PROMEDIO POR PRODUCTO", lblPromedioVal.Text);
                    AgregarKpi("PRODUCTO TOP", lblMaximoVal.Text);
                    doc.Add(tablaKpi);

                    // ── Gráfico ──
                    doc.Add(new Paragraph($"Ranking Top {top} — Unidades Vendidas", fSeccion)
                    { SpacingAfter = 6 });
                    var img = iTextSharp.text.Image.GetInstance(pngGrafico);
                    img.ScaleToFit(pageSize.Width - 80, 450);
                    img.Alignment = Element.ALIGN_CENTER;
                    doc.Add(img);

                    doc.Close();
                    File.WriteAllBytes(rutaTmp, ms.ToArray());
                }

                var pdfView = new PDFView(rutaTmp);
                pdfView.MdiParent = this.MdiParent;
                pdfView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar PDF: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}