using ScottPlot;
using ScottPlot.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot.Palettes;


namespace SurFeFront
{
    
    public partial class GraficosAltaClientesMensualesMDI : Form
    {
        readonly FormsPlot FormsPlot1 = new FormsPlot() { Dock = DockStyle.Fill };
        public GraficosAltaClientesMensualesMDI()
        {
            InitializeComponent();
            panel1.Controls.Add(FormsPlot1);
            FormsPlot1.Refresh();
            AltaClientesMensuales();

        }
        private void AltaClientesMensuales()
        {
            // --- 1. OBTENER DATOS DE SQL ---
            List<double> values = new List<double>();
            List<string> labels = new List<string>();

            // Asegúrate de tener tu connection string correcto aquí
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

            // Consulta: Cuenta clientes agrupados por Año y Mes de los últimos 12 meses
            string query = @"
        SELECT 
            YEAR(fechaRegistro) AS Anio,
            MONTH(fechaRegistro) AS Mes,
            COUNT(id_cliente) AS Total
        FROM 
            [dbo].[cliente]
        WHERE 
            fechaRegistro >= DATEADD(MONTH, -12, GETDATE())
        GROUP BY 
            YEAR(fechaRegistro), MONTH(fechaRegistro)
        ORDER BY 
            YEAR(fechaRegistro), MONTH(fechaRegistro);
    ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int anio = reader.GetInt32(0);
                        int mes = reader.GetInt32(1);
                        int total = reader.GetInt32(2);

                        // Crear fecha para formatear el nombre (ej: "sep.-25")
                        DateTime fecha = new DateTime(anio, mes, 1);
                        labels.Add(fecha.ToString("MMM-yy"));
                        values.Add((double)total);
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
                MessageBox.Show("No hay clientes registrados en los últimos 12 meses.");
                return;
            }

            // --- 2. Configurar el gráfico de Barras (ScottPlot 5) ---
            FormsPlot1.Plot.Clear();

            // Añadir las barras
            var barPlot = FormsPlot1.Plot.Add.Bars(values.ToArray());

            // Color opcional (Azul Cornflower es agradable)
            barPlot.Color = ScottPlot.Colors.CornflowerBlue;

            // Poner el valor numérico encima de cada barra
            foreach (var bar in barPlot.Bars)
            {
                bar.Label = bar.Value.ToString();
            }

            // --- 3. Configurar las etiquetas del Eje X (Meses) ---
            // Usamos NumericManual para mapear la posición 0, 1, 2 a texto "Ene", "Feb", etc.
            ScottPlot.TickGenerators.NumericManual tickGen = new ScottPlot.TickGenerators.NumericManual();

            for (int i = 0; i < labels.Count; i++)
            {
                tickGen.AddMajor(i, labels[i]);
            }

            FormsPlot1.Plot.Axes.Bottom.TickGenerator = tickGen;

            // --- 4. Estética Final ---
            FormsPlot1.Plot.Title("Alta de Clientes (Último Año)");
            FormsPlot1.Plot.Axes.Left.Label.Text = "Cantidad";

            // Ajustes de espacio para que se lean las fechas
            FormsPlot1.Plot.Axes.Bottom.TickLabelStyle.Rotation = 45;
            FormsPlot1.Plot.Axes.Bottom.MinimumSize = 60;

            

            FormsPlot1.Refresh();
        }

    }
}