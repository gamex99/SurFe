using ScottPlot;
using ScottPlot.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

            ConfigurarFiltrosIniciales();

            // Carga inicial al abrir
            CargarGraficoTopClientes(DateTime.Now.Month, DateTime.Now.Year, true);
        }

        private void ConfigurarFiltrosIniciales()
        {
            // Llenar combo de años
            for (int i = 2020; i <= DateTime.Now.Year; i++) cmbAnio.Items.Add(i);
            cmbAnio.SelectedItem = DateTime.Now.Year;

            // Llenar combo de meses
            cmbMes.DataSource = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames
                .Where(m => !string.IsNullOrEmpty(m)).ToList();
            cmbMes.SelectedIndex = DateTime.Now.Month - 1;

            // Enlazar el evento Click del botón
            btnActualizar.Click += BtnActualizar_Click;

            // Habilitar/Deshabilitar el combo de meses según el radio button
            rbMensual.CheckedChanged += (s, e) => cmbMes.Enabled = rbMensual.Checked;
            rbAnual.CheckedChanged += (s, e) => cmbMes.Enabled = !rbAnual.Checked;
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            int mes = cmbMes.SelectedIndex + 1;
            int anio = Convert.ToInt32(cmbAnio.SelectedItem);
            bool esMensual = rbMensual.Checked;

            CargarGraficoTopClientes(mes, anio, esMensual);
        }

        private void CargarGraficoTopClientes(int mes, int anio, bool filtroMensual)
        {
            List<double> values = new List<double>();
            List<string> labels = new List<string>();

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

            // Consulta optimizada y limpia, aprovechando que 'fecha' ahora es DATETIME en la DB
            string query = @"
                SELECT TOP 10
                    C.[razon_social] AS NombreCliente, 
                    SUM(F.[total]) AS TotalComprado
                FROM [dbo].[factura] AS F
                INNER JOIN [dbo].[cliente] AS C ON F.[id_cliente] = C.[id_cliente]
                WHERE F.[tipo_documento] IN ('1', '2', '3') -- <-- REEMPLAZÁ ESTOS NÚMEROS POR LOS IDs DE TUS FACTURAS
                  AND YEAR(F.[fecha]) = @anio";

            if (filtroMensual)
            {
                query += " AND MONTH(F.[fecha]) = @mes";
            }

            query += @"
                GROUP BY C.[id_cliente], C.[razon_social]
                ORDER BY TotalComprado DESC";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@anio", anio);
                    if (filtroMensual) command.Parameters.AddWithValue("@mes", mes);

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
                MessageBox.Show("Error al cargar datos: " + ex.Message);
                return;
            }

            FormsPlot1.Plot.Clear();

            // Validación si no hay datos
            if (values.Count == 0)
            {
                string msgFiltro = filtroMensual ? $"Mes: {mes}, Año: {anio}" : $"Año: {anio}";
                MessageBox.Show($"La consulta no devolvió resultados para: {msgFiltro}.", "Sin Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var txt = FormsPlot1.Plot.Add.Text("Sin datos en el período", 0, 0);
                txt.Alignment = Alignment.MiddleCenter;
                FormsPlot1.Refresh();
                return;
            }

            // Invertir para que el mayor quede arriba
            values.Reverse();
            labels.Reverse();

            double[] dataValues = values.ToArray();
            string[] dataLabels = labels.ToArray();

            var barPlot = FormsPlot1.Plot.Add.Bars(dataValues);
            barPlot.Horizontal = true;
            barPlot.Color = Colors.DarkGreen;

            Tick[] ticks = new Tick[dataLabels.Length];
            for (int i = 0; i < dataLabels.Length; i++)
            {
                ticks[i] = new Tick(i, dataLabels[i]);
            }
            FormsPlot1.Plot.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);

            FormsPlot1.Plot.Title($"Top 10 Clientes - {(filtroMensual ? "Mensual" : "Anual")}");
            FormsPlot1.Plot.XLabel("Monto Total Comprado ($)");

            double maxX = dataValues.Max();
            FormsPlot1.Plot.Axes.SetLimitsX(0, maxX * 1.25);
            FormsPlot1.Plot.Axes.SetLimitsY(-0.5, dataValues.Length - 0.5);

            for (int i = 0; i < dataValues.Length; i++)
            {
                var txt = FormsPlot1.Plot.Add.Text(dataValues[i].ToString("C0"), dataValues[i], i);
                txt.Alignment = Alignment.MiddleLeft;
                txt.OffsetX = 5;
            }

            FormsPlot1.Refresh();
        }
    }
}