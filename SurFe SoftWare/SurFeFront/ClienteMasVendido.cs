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

namespace SurFeFront
{
    public partial class ClienteMasVendido : Form
    {

        readonly FormsPlot FormsPlot1 = new FormsPlot() { Dock = DockStyle.Fill };
        public ClienteMasVendido()
        {
            InitializeComponent();
            panel1.Controls.Add(FormsPlot1);



            // Plot data using the control

            double[] data = ScottPlot.Generate.Sin();

            FormsPlot1.Plot.Add.Signal(data);

            FormsPlot1.Refresh();
            CargarGraficoTopClientes();
        }

        /*
        private void CargarGraficoTopClientes()
        {
            // --- 1 y 2. OBTENER DATOS DE SQL (YA COMPLETADO) ---
            List<double> values = new List<double>();
            List<string> labels = new List<string>();

            // ¡Asegúrate de que esta sea tu cadena de conexión!
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

            // Consulta SQL con los nombres de tus tablas y columnas
            string query = @"
        SELECT TOP 10
            C.[razon_social] AS NombreCliente, 
            SUM(F.[total]) AS TotalComprado
        FROM 
            [dbo].[factura] AS F
        INNER JOIN 
            [dbo].[cliente] AS C ON F.[id_cliente] = C.[id_cliente]
        GROUP BY
            C.[id_cliente], C.[razon_social]
        ORDER BY
            TotalComprado DESC";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        labels.Add(reader.GetString(0));       // Col 0: NombreCliente (razon_social)
                        values.Add(Convert.ToDouble(reader.GetValue(1))); // Col 1: TotalComprado (SUM(total))
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de la base de datos: " + ex.Message);
                return;
            }

            // --- 3. Configurar el gráfico (Horizontal) ---
            FormsPlot1.Plot.Clear(); // Limpiamos el gráfico anterior

            double[] dataValues = values.ToArray();
            string[] dataLabels = labels.ToArray();

            if (dataValues.Length == 0)
            {
                MessageBox.Show("No se encontraron facturas para generar el Top 10.");
                return;
            }

            // Usamos el código que sabemos que funciona en tu versión
            var barPlot = FormsPlot1.Plot.Add.Bars(dataValues);
            barPlot.Horizontal = true;
            barPlot.Color = Colors.DarkGreen; // Verde para "ganancias" / "ventas"

            // 3. Asignar etiquetas de eje (al eje Izquierdo)
            Tick[] ticks = new Tick[dataLabels.Length];
            for (int i = 0; i < dataLabels.Length; i++)
            {
                ticks[i] = new Tick(i, dataLabels[i]);
            }
            FormsPlot1.Plot.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);

            // 4. Títulos y Etiquetas
            FormsPlot1.Plot.Title("Top 10 Clientes con Más Compras");
            FormsPlot1.Plot.XLabel("Monto Total Comprado ($)");
            FormsPlot1.Plot.YLabel("Cliente");

            // 5. Límites de Ejes
            double maxX = dataValues.Length > 0 ? dataValues.Max() : 1000;
            FormsPlot1.Plot.Axes.SetLimitsX(0, maxX * 1.1);
            FormsPlot1.Plot.Axes.SetLimitsY(-0.5, dataValues.Length - 0.5);

            // --- 6. AÑADIR ETIQUETAS DE TEXTO (LOS NOMBRES) ---
            // (Mantenemos tu petición de poner el NOMBRE dentro)
            for (int i = 0; i < dataValues.Length; i++)
            {
                // Pondremos el nombre del cliente
                string label = dataLabels[i];
                double yPos = i;
                double xPos = 1; // Posición X cerca del borde izquierdo

                var text = FormsPlot1.Plot.Add.Text(label, xPos, yPos);

                text.Color = Colors.White;
                text.Bold = true;
                text.Size = 10;
                text.Alignment = Alignment.MiddleLeft; // Si da error, usa 'UpperCenter'
            }

            // ¡Refrescar el gráfico!
            FormsPlot1.Refresh();
        }*/
        private void CargarGraficoTopClientes()
        {
            // --- 1 y 2. OBTENER DATOS DE SQL (YA COMPLETADO) ---
            List<double> values = new List<double>();
            List<string> labels = new List<string>();

            // ¡Asegúrate de que esta sea tu cadena de conexión!
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

            // Consulta SQL con los nombres de tus tablas y columnas
            string query = @"
    SELECT TOP 10
        C.[razon_social] AS NombreCliente, 
        SUM(F.[total]) AS TotalComprado
    FROM 
        [dbo].[factura] AS F
    INNER JOIN 
        [dbo].[cliente] AS C ON F.[id_cliente] = C.[id_cliente]
    GROUP BY
        C.[id_cliente], C.[razon_social]
    ORDER BY
        TotalComprado DESC";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        labels.Add(reader.GetString(0));       // Col 0: NombreCliente (razon_social)
                        values.Add(Convert.ToDouble(reader.GetValue(1))); // Col 1: TotalComprado (SUM(total))
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de la base de datos: " + ex.Message);
                return;
            }

            // --- 3. Configurar el gráfico (Horizontal) ---
            FormsPlot1.Plot.Clear(); // Limpiamos el gráfico anterior

            double[] dataValues = values.ToArray();
            string[] dataLabels = labels.ToArray();

            if (dataValues.Length == 0)
            {
                MessageBox.Show("No se encontraron facturas para generar el Top 10.");
                return;
            }

            // Usamos el código que sabemos que funciona en tu versión
            var barPlot = FormsPlot1.Plot.Add.Bars(dataValues);
            barPlot.Horizontal = true;
            barPlot.Color = Colors.DarkGreen; // Verde para "ganancias" / "ventas"

            // 3. Asignar etiquetas de eje (al eje Izquierdo)
            Tick[] ticks = new Tick[dataLabels.Length];
            for (int i = 0; i < dataLabels.Length; i++)
            {
                ticks[i] = new Tick(i, dataLabels[i]);
            }
            FormsPlot1.Plot.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);

            // 4. Títulos y Etiquetas
            FormsPlot1.Plot.Title("Top 10 Clientes con Más Compras");
            FormsPlot1.Plot.XLabel("Monto Total Comprado ($)");
            FormsPlot1.Plot.YLabel("Cliente");

            // 5. Límites de Ejes
            double maxX = dataValues.Length > 0 ? dataValues.Max() : 1000;
            FormsPlot1.Plot.Axes.SetLimitsX(0, maxX * 1.15); // Aumentamos a 1.15 para dar espacio a la etiqueta
            FormsPlot1.Plot.Axes.SetLimitsY(-0.5, dataValues.Length - 0.5);

            // --- 6. AÑADIR ETIQUETAS DE VALOR (LA CANTIDAD) ---
            // (Este bloque está modificado para mostrar la cantidad al final)
            for (int i = 0; i < dataValues.Length; i++)
            {
                // Pondremos el valor (cantidad)
                // "C0" formatea como Moneda sin decimales (ej: $1,234)
                // "N2" formatea como Número con 2 decimales (ej: 1,234.56)
                string label = dataValues[i].ToString("C0");

                double yPos = i;
                double xPos = dataValues[i]; // Posición X al final de la barra

                var text = FormsPlot1.Plot.Add.Text(label, xPos, yPos);

                text.Color = Colors.Black; // Color de texto legible
                text.Bold = false;
                text.Size = 10;

                // Alinear el texto para que EMPIECE donde termina la barra
                text.Alignment = Alignment.MiddleLeft;

                // Añadimos un pequeño espacio (padding) para que no esté pegado
                text.OffsetX = 5;
            }

            // ¡Refrescar el gráfico!
            FormsPlot1.Refresh();
        }
    }
}