using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;

namespace SurFeFront
{
    public partial class GraficosAltaClientesMensualesMDI : Form
    {
        public GraficosAltaClientesMensualesMDI()
        {
            InitializeComponent();
            // Crear TabControl
            TabControl tabControl = new TabControl { Dock = DockStyle.Fill };
            this.Controls.Add(tabControl);

            TabPage tabGrafico = new TabPage("Alta Clientes Mensuales");
            tabControl.TabPages.Add(tabGrafico);

            // Crear Chart dentro de la TabPage
            Chart chartClientes = new Chart { Dock = DockStyle.Fill };
            tabGrafico.Controls.Add(chartClientes);

            // Generar gráfico
            GenerarGrafico(chartClientes);
        }
        private void GenerarGrafico(Chart chartClientes)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT fechaRegistro
                FROM cliente
                WHERE fechaRegistro IS NOT NULL
                ORDER BY fechaRegistro";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    var clientesPorMes = new System.Collections.Generic.Dictionary<string, int>();
                    while (reader.Read())
                    {
                        DateTime fecha = Convert.ToDateTime(reader["fechaRegistro"]);
                        string mesAnio = fecha.ToString("MMM yyyy", new CultureInfo("es-ES"));

                        if (clientesPorMes.ContainsKey(mesAnio))
                            clientesPorMes[mesAnio]++;
                        else
                            clientesPorMes[mesAnio] = 1;
                    }
                    reader.Close();

                    // Ordenar cronológicamente
                    var clientesOrdenados = new System.Collections.Generic.SortedDictionary<DateTime, int>();
                    foreach (var kvp in clientesPorMes)
                    {
                        DateTime dt = DateTime.ParseExact(kvp.Key, "MMM yyyy", new CultureInfo("es-ES"));
                        clientesOrdenados[dt] = kvp.Value;
                    }

                    // Limpiar chart
                    chartClientes.Series.Clear();
                    chartClientes.ChartAreas.Clear();
                    chartClientes.Titles.Clear();

                    // Área del chart
                    ChartArea area = new ChartArea("Area1");
                    area.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
                    area.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
                    area.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
                    area.AxisX.LabelStyle.Angle = -45;
                    chartClientes.ChartAreas.Add(area);

                    // Serie
                    Series serie = new Series("Clientes Altas")
                    {
                        ChartType = SeriesChartType.Column,
                        IsValueShownAsLabel = true,
                        LabelForeColor = System.Drawing.Color.White
                    };

                    // Colores degradados para barras
                    var colorBarras = new System.Drawing.Color[]
                    {
                System.Drawing.Color.FromArgb(52, 152, 219), // azul
                System.Drawing.Color.FromArgb(231, 76, 60),  // rojo
                System.Drawing.Color.FromArgb(46, 204, 113), // verde
                System.Drawing.Color.FromArgb(155, 89, 182)  // morado
                    };

                    int colorIndex = 0;
                    foreach (var kvp in clientesOrdenados)
                    {
                        string label = kvp.Key.ToString("MMM yyyy", new CultureInfo("es-ES"));
                        int pointIndex = serie.Points.AddXY(label, kvp.Value);

                        serie.Points[pointIndex].Color = colorBarras[colorIndex % colorBarras.Length];
                        serie.Points[pointIndex].BorderColor = System.Drawing.Color.Black;
                        serie.Points[pointIndex].BorderWidth = 1;
                        serie.Points[pointIndex].ToolTip = $"{label}: {kvp.Value} clientes";

                        colorIndex++;
                    }

                    chartClientes.Series.Add(serie);

                    // Título
                    chartClientes.Titles.Add("Altas de Clientes por Mes");
                    chartClientes.Titles[0].Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
                    chartClientes.Titles[0].ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar gráfico: " + ex.Message);
            }
        }

    }
}
