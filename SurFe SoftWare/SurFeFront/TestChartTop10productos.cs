using iTextSharp.tool.xml.css.parser.state;
using Microsoft.VisualBasic.Logging;
using OpenTK.Audio.OpenAL;
using Org.BouncyCastle.Utilities;
using ScottPlot;
using ScottPlot.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient; // Necesario para la conexión a SQL Server
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iTextSharp.text.pdf.events.IndexEvents;


namespace SurFeFront
{
    public partial class TestChartTop10productos : Form
    {
        readonly FormsPlot FormsPlot1 = new FormsPlot() { Dock = DockStyle.Fill };
        public TestChartTop10productos()
        {
            InitializeComponent();
            // Add the FormsPlot to the panel
            panel1.Controls.Add(FormsPlot1);



            // Plot data using the control

            double[] data = ScottPlot.Generate.Sin();

            FormsPlot1.Plot.Add.Signal(data);

            FormsPlot1.Refresh();
            CargarGrafico2();

        }

        private void CargarGrafico()
        {
           
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
      



                
                    // --- 1 y 2. OBTENER DATOS DE SQL ---
                    // (Esta parte esta idéntica y funciona bien)
                    List<double> values = new List<double>();
                    List<string> labels = new List<string>();
                   
                    string query = @"
        SELECT TOP 10 [detalle], [vendidos] 
        FROM [dbo].[producto] 
        WHERE [vendidos] > 0 
        ORDER BY [vendidos] DESC";

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            SqlCommand command = new SqlCommand(query, connection);
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                labels.Add(reader.GetString(0));
                                values.Add(Convert.ToDouble(reader.GetValue(1)));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar datos de la base de datos: " + ex.Message);
                        return;
                    }

                    // --- 3. Configurar el gráfico (Versión Segura) ---
                    FormsPlot1.Plot.Clear();
                    double[] dataValues = values.ToArray();
                    string[] dataLabels = labels.ToArray();

                    // 1. Añadir las barras
                    var barPlot = FormsPlot1.Plot.Add.Bars(dataValues);
                    barPlot.Color = Colors.Navy; // Usamos un color oscuro para que el texto blanco resalte

                    // 2. Asignar etiquetas en ScottPlot 5
                    Tick[] ticks = new Tick[dataLabels.Length];
                    for (int i = 0; i < dataLabels.Length; i++)
                    {
                        ticks[i] = new Tick(i, dataLabels[i]);
                    }
                    FormsPlot1.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);
                    FormsPlot1.Plot.Axes.Bottom.TickLabelStyle.Rotation = 60;

                    // 3. Títulos y Etiquetas
                    FormsPlot1.Plot.Title("Top 10 Productos Más Vendidos");
                    FormsPlot1.Plot.YLabel("Cantidad Vendida");
                    FormsPlot1.Plot.XLabel("Producto");

                    // 4. Límites de Ejes
                    double maxY = dataValues.Length > 0 ? dataValues.Max() : 10;
                    FormsPlot1.Plot.Axes.SetLimitsY(0, maxY * 1.1);
                    FormsPlot1.Plot.Axes.SetLimitsX(-0.5, dataValues.Length - 0.5);


                    // --- 6. (NUEVO) AÑADIR ETIQUETAS DE VALOR (TEXTO) ---
                    for (int i = 0; i < dataValues.Length; i++)
                    {
                        // Convertimos el número (ej. 97) a un string
                        string label = dataValues[i].ToString();

                        // Posición X: Centrado en la barra (posición 'i')
                        double xPos = i;

                        // Posición Y: Justo *debajo* del borde superior de la barra
                        // Ajusta el '- 2' si quieres el texto más arriba o más abajo
                        double yPos = dataValues[i] - 2;

                        // Añadimos el objeto Texto
                        var text = FormsPlot1.Plot.Add.Text(label, xPos, yPos);

                        // --- Estilo del texto ---
                        text.Color = Colors.White; // Texto blanco para que resalte
                          text.Bold = true;
                            text.Size = 10;

                // Alineación: Centrado horizontalmente (TopCenter)
                // Esto significa que la 'yPos' es el borde SUPERIOR del texto
                text.Alignment = Alignment.UpperCenter;
                    }


                    // ¡Refrescar el gráfico!
                    FormsPlot1.Refresh();
                }
        /*
        private void CargarGrafico2()

        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            // --- 1 y 2. OBTENER DATOS DE SQL ---
            // (Esta parte esta idéntica y funciona bien)
            List<double> values = new List<double>();
            List<string> labels = new List<string>();
            
            string query = @"
        SELECT TOP 10 [detalle], [cantidad_venta] 
        FROM [dbo].[producto] 
        WHERE [cantidad_venta] > 0 
        ORDER BY [cantidad_venta] DESC";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        labels.Add(reader.GetString(0));
                        values.Add(Convert.ToDouble(reader.GetValue(1)));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de la base de datos: " + ex.Message);
                return;
            }

            // --- 3. Configurar el gráfico (Versión Horizontal) ---
            FormsPlot1.Plot.Clear();
            double[] dataValues = values.ToArray();
            string[] dataLabels = labels.ToArray();

            // 1. Añadir las barras HORIZONTALES
            // (Este es el cambio principal)
            var barPlot = FormsPlot1.Plot.Add.Bars(dataValues);
            barPlot.Horizontal = true;
            barPlot.Color = Colors.Navy;

            // 2. Asignar etiquetas de eje (AHORA EN EL EJE IZQUIERDO)
            Tick[] ticks = new Tick[dataLabels.Length];
            for (int i = 0; i < dataLabels.Length; i++)
            {
                ticks[i] = new Tick(i, dataLabels[i]);
            }
            // Asignamos los nombres al eje Izquierdo (Y)
            FormsPlot1.Plot.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);
            // Ya no necesitamos rotar las etiquetas del eje X
            // FormsPlot1.Plot.Axes.Bottom.TickLabelStyle.Rotation = 60; 

            // 3. Títulos y Etiquetas (EJES INVERTIDOS)
            FormsPlot1.Plot.Title("Top 10 Productos Más Vendidos");
            FormsPlot1.Plot.XLabel("Cantidad Vendida"); // Eje X es ahora la cantidad
            FormsPlot1.Plot.YLabel("Producto");         // Eje Y es ahora el producto

            // 4. Límites de Ejes (EJES INVERTIDOS)
            double maxX = dataValues.Length > 0 ? dataValues.Max() : 10;
            FormsPlot1.Plot.Axes.SetLimitsX(0, maxX * 1.1); // El límite de valor va en el Eje X
            FormsPlot1.Plot.Axes.SetLimitsY(-0.5, dataValues.Length - 0.5); // El límite de categoría va en el Eje Y


            // --- 6. AÑADIR ETIQUETAS DE TEXTO (LOS NOMBRES) ---
            // (Con lógica adaptada para barras horizontales)
            for (int i = 0; i < dataValues.Length; i++)
            {
                // CAMBIO: La etiqueta es el NOMBRE, no el número
                string label = dataLabels[i];

                // CAMBIO: La posición Y es el centro de la barra ('i')
                double yPos = i;

                // CAMBIO: La posición X la pondremos cerca del inicio de la barra
                double xPos = 1; // Empezar justo a la derecha del eje

                var text = FormsPlot1.Plot.Add.Text(label, xPos, yPos);

                // --- Estilo del texto ---
                text.Color = Colors.White;
                text.Bold = true;
                text.Size = 10;

                // CAMBIO: Alineación (Probamos 'MiddleLeft')
                // Si 'MiddleLeft' da error, prueba 'UpperCenter' o 'LowerCenter'
                text.Alignment = Alignment.MiddleLeft;
            }


            // ¡Refrescar el gráfico!
            FormsPlot1.Refresh();
        }*/
        private void CargarGrafico2()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            // --- 1 y 2. OBTENER DATOS DE SQL ---
            // (Esta parte esta idéntica y funciona bien)
            List<double> values = new List<double>();
            List<string> labels = new List<string>();

            string query = @"
SELECT TOP 10 [detalle], [vendidos] 
FROM [dbo].[producto] 
WHERE [vendidos] > 0 
ORDER BY [vendidos] DESC";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        labels.Add(reader.GetString(0));
                        values.Add(Convert.ToDouble(reader.GetValue(1)));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de la base de datos: " + ex.Message);
                return;
            }

            // --- 3. Configurar el gráfico (Versión Horizontal) ---
            FormsPlot1.Plot.Clear();
            double[] dataValues = values.ToArray();
            string[] dataLabels = labels.ToArray();

            // 1. Añadir las barras HORIZONTALES
            var barPlot = FormsPlot1.Plot.Add.Bars(dataValues);
            barPlot.Horizontal = true;
            barPlot.Color = Colors.Navy;

            // 2. Asignar etiquetas de eje (AHORA EN EL EJE IZQUIERDO)
            Tick[] ticks = new Tick[dataLabels.Length];
            for (int i = 0; i < dataLabels.Length; i++)
            {
                ticks[i] = new Tick(i, dataLabels[i]);
            }
            // Asignamos los nombres al eje Izquierdo (Y)
            FormsPlot1.Plot.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);

            // 3. Títulos y Etiquetas (EJES INVERTIDOS)
            FormsPlot1.Plot.Title("Top 10 Productos Más Vendidos");
            FormsPlot1.Plot.XLabel("Cantidad Vendida"); // Eje X es ahora la cantidad
            FormsPlot1.Plot.YLabel("Producto");       // Eje Y es ahora el producto

            // 4. Límites de Ejes (EJES INVERTIDOS)
            double maxX = dataValues.Length > 0 ? dataValues.Max() : 10;
            // Modificado: Damos un 20% de espacio extra para las etiquetas de valor
            FormsPlot1.Plot.Axes.SetLimitsX(0, maxX * 1.20);
            FormsPlot1.Plot.Axes.SetLimitsY(-0.5, dataValues.Length - 0.5);


            // --- 6. AÑADIR ETIQUETAS DE VALOR (LA CANTIDAD) ---
            // (Modificado para mostrar la cantidad al final de la barra)
            for (int i = 0; i < dataValues.Length; i++)
            {
                // CAMBIO: La etiqueta es el VALOR, no el nombre
                // "N0" es para un número entero (ej: "150")
                string label = dataValues[i].ToString("N0");

                // CAMBIO: La posición Y es el centro de la barra ('i')
                double yPos = i;

                // CAMBIO: La posición X es el FINAL de la barra
                double xPos = dataValues[i];

                var text = FormsPlot1.Plot.Add.Text(label, xPos, yPos);

                // --- Estilo del texto ---
                // CAMBIO: Color a negro para ser visible fuera de la barra
                text.Color = Colors.Black;
                text.Bold = false;
                text.Size = 10;

                // CAMBIO: Alineación (Mantenemos 'MiddleLeft')
                // Esto hace que el texto EMPIECE en xPos
                text.Alignment = Alignment.MiddleLeft;

                // AÑADIDO: Un pequeño padding para que no esté pegado
                text.OffsetX = 5;
            }

            // ¡Refrescar el gráfico!
            FormsPlot1.Refresh();
        }

        private void TestChartTop10productos_Load(object sender, EventArgs e)
        {

        }
    }
}

