using ScottPlot;
using ScottPlot.WinForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Color = System.Drawing.Color;
using Label = System.Windows.Forms.Label;
using Panel = System.Windows.Forms.Panel;

namespace SurFeFront
{
    public partial class GraficosAltaClientesMensualesMDI : Form
    {
        readonly FormsPlot FormsPlot1 = new FormsPlot() { Dock = DockStyle.Fill };
        readonly FormsPlot FormsPlotTorta = new FormsPlot() { Dock = DockStyle.Fill };

        private System.Windows.Forms.Timer _animTimer;
        private double _animProgress = 0;
        private double[] _finalValues;
        private List<string> _labels;
        private ScottPlot.Bar[] _bars;

        public GraficosAltaClientesMensualesMDI()
        {
            InitializeComponent();
            AplicarTemaOscuroFormulario();
            panelGrafico.Controls.Add(FormsPlot1);
            panelTorta.Controls.Add(FormsPlotTorta);
            FormsPlot1.Refresh();
            FormsPlotTorta.Refresh();
            CargarDatos();
        }

        private void AplicarTemaOscuroFormulario()
        {
            this.BackColor = Color.FromArgb(18, 18, 30);
            panelTop.BackColor = Color.FromArgb(28, 28, 45);
            panelKpis.BackColor = Color.FromArgb(28, 28, 45);
            panelBottom.BackColor = Color.FromArgb(18, 18, 30);
            panelGrafico.BackColor = Color.FromArgb(18, 18, 30);
            panelTorta.BackColor = Color.FromArgb(18, 18, 30);

            lblTitulo.ForeColor = Color.FromArgb(120, 180, 255);
            lblSubtitulo.ForeColor = Color.FromArgb(160, 160, 200);

            foreach (Panel card in new[] { cardTotal, cardPromedio, cardMaximo })
                card.BackColor = Color.FromArgb(38, 38, 58);

            foreach (Label lbl in new[] { lblTotalVal, lblPromedioVal, lblMaximoVal,
                                          lblTotalTxt, lblPromedioTxt, lblMaximoTxt })
                lbl.ForeColor = Color.White;

            cboRango.BackColor = Color.FromArgb(38, 38, 58);
            cboRango.ForeColor = Color.White;
            lblRango.ForeColor = Color.FromArgb(160, 160, 200);

            btnExportar.BackColor = Color.FromArgb(60, 100, 200);
            btnExportar.ForeColor = Color.White;
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.FlatAppearance.BorderColor = Color.FromArgb(80, 120, 220);

            btnExportarPDF.BackColor = Color.FromArgb(180, 60, 60);
            btnExportarPDF.ForeColor = Color.White;
            btnExportarPDF.FlatStyle = FlatStyle.Flat;
            btnExportarPDF.FlatAppearance.BorderColor = Color.FromArgb(200, 80, 80);
        }

        // ════════════════════════════════════════════
        //  CARGA DE DATOS
        // ════════════════════════════════════════════
        private void CargarDatos()
        {
            int meses = int.Parse(cboRango.SelectedItem?.ToString()?.Split(' ')[0] ?? "12");

            var values = new List<double>();
            var labels = new List<string>();

            string connectionString = System.Configuration.ConfigurationManager
                .ConnectionStrings["conexionDB"].ConnectionString;

            string query = $@"
                SELECT 
                    YEAR(fechaRegistro)  AS Anio,
                    MONTH(fechaRegistro) AS Mes,
                    COUNT(id_cliente)    AS Total
                FROM [dbo].[cliente]
                WHERE fechaRegistro >= DATEADD(MONTH, -{meses}, GETDATE())
                GROUP BY YEAR(fechaRegistro), MONTH(fechaRegistro)
                ORDER BY YEAR(fechaRegistro), MONTH(fechaRegistro);";

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                        {
                            int anio = reader.GetInt32(0);
                            int mes = reader.GetInt32(1);
                            int total = reader.GetInt32(2);
                            labels.Add(new DateTime(anio, mes, 1).ToString("MMM-yy"));
                            values.Add(total);
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
                MessageBox.Show($"No hay clientes registrados en los últimos {meses} meses.");
                return;
            }

            _finalValues = values.ToArray();
            _labels = labels;

            ActualizarKpis(_finalValues);
            DibujarTorta();
            IniciarAnimacion();
        }

        // ════════════════════════════════════════════
        //  KPIs
        // ════════════════════════════════════════════
        private void ActualizarKpis(double[] vals)
        {
            lblTotalVal.Text = vals.Sum().ToString("N0");
            lblPromedioVal.Text = vals.Average().ToString("N1");
            lblMaximoVal.Text = vals.Max().ToString("N0");
        }

        // ════════════════════════════════════════════
        //  ANIMACIÓN
        // ════════════════════════════════════════════
        private void IniciarAnimacion()
        {
            _animProgress = 0;
            _animTimer = new System.Windows.Forms.Timer { Interval = 16 };
            _animTimer.Tick += AnimTimer_Tick;
            _animTimer.Start();
        }

        private void AnimTimer_Tick(object sender, EventArgs e)
        {
            _animProgress += 0.045;
            if (_animProgress >= 1.0)
            {
                _animProgress = 1.0;
                _animTimer.Stop();
            }
            double t = 1 - Math.Pow(1 - _animProgress, 3);
            DibujarGrafico(_finalValues.Select(v => v * t).ToArray());
        }

        // ════════════════════════════════════════════
        //  GRÁFICO DE BARRAS
        // ════════════════════════════════════════════
        private void DibujarGrafico(double[] values)
        {
            var plot = FormsPlot1.Plot;
            plot.Clear();

            plot.FigureBackground.Color = ScottPlot.Color.FromHex("#12121E");
            plot.DataBackground.Color = ScottPlot.Color.FromHex("#1C1C2D");
            plot.Axes.Color(ScottPlot.Color.FromHex("#A0A0C8"));
            plot.Grid.MajorLineColor = ScottPlot.Color.FromHex("#2A2A42");

            double max = _finalValues.Max();
            var barItems = new ScottPlot.Bar[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                double ratio = max > 0 ? values[i] / max : 0;
                int r = (int)(58 + ratio * (155 - 58));
                int g = (int)(111 + ratio * (93 - 111));
                int b = (int)(216 + ratio * (229 - 216));
                barItems[i] = new ScottPlot.Bar
                {
                    Position = i,
                    Value = values[i],
                    FillColor = ScottPlot.Color.FromHex($"#{r:X2}{g:X2}{b:X2}"),
                    Label = _animProgress >= 1.0 ? ((int)_finalValues[i]).ToString() : string.Empty
                };
            }
            plot.Add.Bars(barItems);

            if (_animProgress >= 1.0 && values.Length > 1)
            {
                double n = values.Length;
                double sumX = 0, sumY = 0, sumXY = 0, sumX2 = 0;
                for (int i = 0; i < values.Length; i++)
                {
                    sumX += i; sumY += values[i];
                    sumXY += i * values[i]; sumX2 += i * i;
                }
                double slope = (n * sumXY - sumX * sumY) / (n * sumX2 - sumX * sumX);
                double intercept = (sumY - slope * sumX) / n;

                double[] xTrend = { 0, values.Length - 1 };
                double[] yTrend = { intercept, intercept + slope * (values.Length - 1) };

                var line = plot.Add.ScatterLine(xTrend, yTrend);
                line.Color = ScottPlot.Color.FromHex("#FF6B6B");
                line.LineWidth = 2;
                line.LinePattern = ScottPlot.LinePattern.Dashed;
            }

            var tickGen = new ScottPlot.TickGenerators.NumericManual();
            for (int i = 0; i < _labels.Count; i++)
                tickGen.AddMajor(i, _labels[i]);
            plot.Axes.Bottom.TickGenerator = tickGen;

            plot.Axes.Bottom.TickLabelStyle.Rotation = 45;
            plot.Axes.Bottom.TickLabelStyle.ForeColor = ScottPlot.Color.FromHex("#A0A0C8");
            plot.Axes.Bottom.MinimumSize = 60;
            plot.Axes.Left.Label.Text = "Clientes";
            plot.Axes.Left.Label.ForeColor = ScottPlot.Color.FromHex("#A0A0C8");

            FormsPlot1.Refresh();
        }

        // ════════════════════════════════════════════
        //  GRÁFICO DE TORTA
        // ════════════════════════════════════════════
        private void DibujarTorta()
        {
            var plot = FormsPlotTorta.Plot;
            plot.Clear();

            plot.FigureBackground.Color = ScottPlot.Color.FromHex("#12121E");
            plot.DataBackground.Color = ScottPlot.Color.FromHex("#1C1C2D");

            // Paleta de colores para los sectores
            string[] paleta = new[]
            {
                "#3A6FD8","#9B5DE5","#F15BB5","#FEE440",
                "#00BBF9","#00F5D4","#FF6B6B","#FFB347",
                "#7FFF00","#FF69B4","#40E0D0","#FF4500"
            };

            double total = _finalValues.Sum();
            var slices = new List<PieSlice>();

            for (int i = 0; i < _finalValues.Length; i++)
            {
                string hex = paleta[i % paleta.Length];
                slices.Add(new PieSlice
                {
                    Value = _finalValues[i],
                    FillColor = ScottPlot.Color.FromHex(hex),
                    Label = $"{_labels[i]}\n{_finalValues[i]:N0} ({(_finalValues[i] / total * 100):N1}%)"
                });
            }

            var pie = plot.Add.Pie(slices);
            pie.ExplodeFraction = 0.05;   // separa un poco los sectores
            pie.SliceLabelDistance = 1.4;    // etiquetas hacia afuera

            plot.ShowLegend();
            plot.Legend.FontColor = ScottPlot.Color.FromHex("#A0A0C8");
            plot.Legend.BackgroundColor = ScottPlot.Color.FromHex("#1C1C2D");
            plot.Legend.OutlineColor = ScottPlot.Color.FromHex("#2A2A42");

            plot.Axes.Frameless();
            plot.HideGrid();

            FormsPlotTorta.Refresh();
        }

        // ════════════════════════════════════════════
        //  EXPORTAR PDF
        // ════════════════════════════════════════════
        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Ruta temporal con nombre único
                string rutaTmp = System.IO.Path.Combine(
                    System.IO.Path.GetTempPath(),
                    $"AltaClientes_{DateTime.Now:yyyyMMdd_HHmm}.pdf");

                // 2. Renderizar ambos gráficos en memoria
                byte[] pngBarras = RenderizarGraficoClaro(FormsPlot1.Plot, _finalValues, esTorta: false);
                byte[] pngTorta = RenderizarGraficoClaro(FormsPlotTorta.Plot, _finalValues, esTorta: true);

                // 3. Armar el PDF con iTextSharp
                using (var ms = new System.IO.MemoryStream())
                {
                    var pageSize = iTextSharp.text.PageSize.A4;
                    var doc = new iTextSharp.text.Document(pageSize, 40, 40, 50, 40);
                    var writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, ms);
                    doc.Open();

                    // ── Colores y fuentes ──
                    // ── Colores claros para PDF (ahorro de tinta) ──
                    var colorFondo = iTextSharp.text.BaseColor.WHITE;
                    var colorTitulo = new iTextSharp.text.BaseColor(30, 80, 180);   // azul oscuro
                    var colorSubtitle = new iTextSharp.text.BaseColor(80, 80, 110);   // gris azulado
                    var colorCard = new iTextSharp.text.BaseColor(235, 238, 248); // gris muy claro
                    var colorCardTxt = new iTextSharp.text.BaseColor(80, 80, 110);
                    var colorCardVal = new iTextSharp.text.BaseColor(20, 20, 50);    // casi negro

                    var fuenteTitulo = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 20, colorTitulo);
                    var fuenteSubtitle = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 9, colorSubtitle);
                    var fuenteKpiTxt = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 7, colorCardTxt);
                    var fuenteKpiVal = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 16, colorCardVal);
                    var fuenteSeccion = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 11, colorTitulo);

                    // ── Fondo blanco ──
                    var cb = writer.DirectContentUnder;
                    cb.SetColorFill(iTextSharp.text.BaseColor.WHITE);
                    cb.Rectangle(0, 0, pageSize.Width, pageSize.Height);
                    cb.Fill();

                    // ── Título ──
                    doc.Add(new iTextSharp.text.Paragraph("Alta de Clientes", fuenteTitulo)
                    { Alignment = iTextSharp.text.Element.ALIGN_CENTER, SpacingAfter = 2 });
                    doc.Add(new iTextSharp.text.Paragraph(
                        $"Evolución mensual  |  Período: {cboRango.SelectedItem}  |  {DateTime.Now:dd/MM/yyyy HH:mm}",
                        fuenteSubtitle)
                    { Alignment = iTextSharp.text.Element.ALIGN_CENTER, SpacingAfter = 14 });

                    // ── Tabla KPIs ──
                    var tablaKpi = new iTextSharp.text.pdf.PdfPTable(3) { WidthPercentage = 100 };
                    tablaKpi.SpacingAfter = 14;

                    void AgregarKpi(string titulo, string valor)
                    {
                        var cell = new iTextSharp.text.pdf.PdfPCell
                        {
                            Border = 0,
                            BackgroundColor = colorCard,
                            Padding = 10,
                            HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                        };
                        cell.AddElement(new iTextSharp.text.Paragraph(titulo, fuenteKpiTxt)
                        { Alignment = iTextSharp.text.Element.ALIGN_CENTER });
                        cell.AddElement(new iTextSharp.text.Paragraph(valor, fuenteKpiVal)
                        { Alignment = iTextSharp.text.Element.ALIGN_CENTER });
                        tablaKpi.AddCell(cell);
                    }

                    AgregarKpi("TOTAL CLIENTES", lblTotalVal.Text);
                    AgregarKpi("PROMEDIO MENSUAL", lblPromedioVal.Text);
                    AgregarKpi("MÁXIMO EN UN MES", lblMaximoVal.Text);
                    doc.Add(tablaKpi);

                    // ── Gráfico de Barras ──
                    doc.Add(new iTextSharp.text.Paragraph("Evolución Mensual — Barras", fuenteSeccion)
                    { SpacingAfter = 6 });
                    var imgBarras = iTextSharp.text.Image.GetInstance(pngBarras);
                    imgBarras.ScaleToFit(pageSize.Width - 80, 300);
                    imgBarras.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    doc.Add(imgBarras);

                    doc.Add(new iTextSharp.text.Paragraph(" ") { SpacingAfter = 10 });

                    // ── Gráfico de Torta ──
                    doc.Add(new iTextSharp.text.Paragraph("Distribución Mensual — Torta", fuenteSeccion)
                    { SpacingAfter = 6 });
                    var imgTorta = iTextSharp.text.Image.GetInstance(pngTorta);
                    imgTorta.ScaleToFit(pageSize.Width - 80, 300);
                    imgTorta.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    doc.Add(imgTorta);

                    doc.Close();

                    // 4. Escribir en disco
                    System.IO.File.WriteAllBytes(rutaTmp, ms.ToArray());
                }

                // 5. Abrir en el PDFView de la aplicación
                var pdfView = new PDFView(rutaTmp);
                pdfView.MdiParent = this.MdiParent;
                pdfView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private byte[] RenderizarGraficoClaro(ScottPlot.Plot plotOriginal, double[] values, bool esTorta)
        {
            // Creamos un Plot nuevo solo para el PDF
            var plotClaro = new ScottPlot.Plot();

            plotClaro.FigureBackground.Color = ScottPlot.Color.FromHex("#FFFFFF");
            plotClaro.DataBackground.Color = ScottPlot.Color.FromHex("#F5F7FF");
            plotClaro.Axes.Color(ScottPlot.Color.FromHex("#333355"));
            plotClaro.Grid.MajorLineColor = ScottPlot.Color.FromHex("#DDDDEE");

            if (esTorta)
            {
                double total = _finalValues.Sum();
                string[] paleta = new[]
                {
            "#3A6FD8","#9B5DE5","#F15BB5","#E09B00",
            "#0099CC","#00B89C","#CC4444","#CC7700",
            "#558800","#BB3377","#229988","#BB3300"
        };
                var slices = new List<PieSlice>();
                for (int i = 0; i < _finalValues.Length; i++)
                {
                    slices.Add(new PieSlice
                    {
                        Value = _finalValues[i],
                        FillColor = ScottPlot.Color.FromHex(paleta[i % paleta.Length]),
                        Label = $"{_labels[i]}\n{_finalValues[i]:N0} ({(_finalValues[i] / total * 100):N1}%)"
                    });
                }
                var pie = plotClaro.Add.Pie(slices);
                pie.ExplodeFraction = 0.05;
                pie.SliceLabelDistance = 1.4;
                plotClaro.ShowLegend();
                plotClaro.Legend.FontColor = ScottPlot.Color.FromHex("#333355");
                plotClaro.Legend.BackgroundColor = ScottPlot.Color.FromHex("#F5F7FF");
                plotClaro.Legend.OutlineColor = ScottPlot.Color.FromHex("#CCCCDD");
                plotClaro.Axes.Frameless();
                plotClaro.HideGrid();
            }
            else
            {
                double max = _finalValues.Max();
                var barItems = new ScottPlot.Bar[_finalValues.Length];
                for (int i = 0; i < _finalValues.Length; i++)
                {
                    double ratio = max > 0 ? _finalValues[i] / max : 0;
                    int r = (int)(58 + ratio * (155 - 58));
                    int g = (int)(111 + ratio * (93 - 111));
                    int b = (int)(216 + ratio * (229 - 216));
                    barItems[i] = new ScottPlot.Bar
                    {
                        Position = i,
                        Value = _finalValues[i],
                        FillColor = ScottPlot.Color.FromHex($"#{r:X2}{g:X2}{b:X2}"),
                        Label = ((int)_finalValues[i]).ToString()
                    };
                }
                plotClaro.Add.Bars(barItems);

                // Línea de tendencia en el PDF también
                if (_finalValues.Length > 1)
                {
                    double n = _finalValues.Length;
                    double sumX = 0, sumY = 0, sumXY = 0, sumX2 = 0;
                    for (int i = 0; i < _finalValues.Length; i++)
                    {
                        sumX += i; sumY += _finalValues[i];
                        sumXY += i * _finalValues[i]; sumX2 += i * i;
                    }
                    double slope = (n * sumXY - sumX * sumY) / (n * sumX2 - sumX * sumX);
                    double intercept = (sumY - slope * sumX) / n;
                    double[] xT = { 0, _finalValues.Length - 1 };
                    double[] yT = { intercept, intercept + slope * (_finalValues.Length - 1) };
                    var line = plotClaro.Add.ScatterLine(xT, yT);
                    line.Color = ScottPlot.Color.FromHex("#CC3333");
                    line.LineWidth = 2;
                    line.LinePattern = ScottPlot.LinePattern.Dashed;
                }

                var tickGen = new ScottPlot.TickGenerators.NumericManual();
                for (int i = 0; i < _labels.Count; i++)
                    tickGen.AddMajor(i, _labels[i]);
                plotClaro.Axes.Bottom.TickGenerator = tickGen;
                plotClaro.Axes.Bottom.TickLabelStyle.Rotation = 45;
                plotClaro.Axes.Bottom.TickLabelStyle.ForeColor = ScottPlot.Color.FromHex("#333355");
                plotClaro.Axes.Bottom.MinimumSize = 60;
                plotClaro.Axes.Left.Label.Text = "Clientes";
                plotClaro.Axes.Left.Label.ForeColor = ScottPlot.Color.FromHex("#333355");
            }

            return plotClaro.GetImageBytes(900, 420);
        }
        // ════════════════════════════════════════════
        //  EVENTOS UI
        // ════════════════════════════════════════════
        private void cboRango_SelectedIndexChanged(object sender, EventArgs e) => CargarDatos();

        private void btnExportar_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG Image|*.png";
                sfd.FileName = $"AltaClientes_{DateTime.Now:yyyyMMdd_HHmm}";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    FormsPlot1.Plot.SavePng(sfd.FileName, 1200, 700);
                    MessageBox.Show("Gráfico exportado correctamente.", "Exportar",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}