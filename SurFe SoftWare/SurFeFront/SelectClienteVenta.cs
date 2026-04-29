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
    public partial class SelectClienteVenta : Form
    {
        // Propiedades con getters públicos para que el Punto de Venta las lea
        public string cuitselect { get; private set; }
        public string razonsocialselect { get; private set; }
        public string domicilio { get; private set; }
        public string localidad { get; private set; }
        public string factura_tipo { get; private set; }
        public string id_clienteselect { get; private set; }
        public string condicioniva { get; private set; }

        public SelectClienteVenta()
        {
            InitializeComponent();
        }

        private void SelectClienteVenta_Load(object sender, EventArgs e)
        {
            // Cargamos todos los clientes al iniciar
            CargarDatos("");
        }

        private void textBusquedaVenta_TextChanged(object sender, EventArgs e)
        {
            // Filtramos mientras el usuario escribe
            CargarDatos(textBusquedaVenta.Text);
        }

        private void CargarDatos(string filtro)
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

            // Consulta ajustada a tus nombres reales:
            // cliente.localidad es el ID que une con localidad.id
            // cliente.provincia es el ID que une con provincia.id
            string query = @"
        SELECT 
            C.[id_cliente],
            C.[cuit] AS [CUIT],
            C.[razon_social] AS [RAZÓN SOCIAL],
            C.[domicilio] AS [DIRECCIÓN],
            L.[localidad] AS [LOCALIDAD],
            P.[provincia] AS [PROVINCIA],
            C.[tipo_factura],
            C.[idCondicionIVA]
        FROM [dbo].[cliente] AS C
        LEFT JOIN [dbo].[localidad] AS L ON C.[localidad] = L.[id]
        LEFT JOIN [dbo].[provincia] AS P ON C.[provincia] = P.[id]
        WHERE (C.[razon_social] LIKE @filtro OR C.[cuit] LIKE @filtro)
          AND C.[anulado] = 0"; // Filtramos para no traer clientes anulados

            using (SqlConnection connection = new SqlConnection(conString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();

                    try
                    {
                        connection.Open();
                        adapter.Fill(dt);
                        dataGridView2.DataSource = dt;

                        if (dataGridView2.Columns.Count > 0)
                        {
                            // Ocultamos las columnas técnicas
                            if (dataGridView2.Columns.Contains("id_cliente")) dataGridView2.Columns["id_cliente"].Visible = false;
                            if (dataGridView2.Columns.Contains("tipo_factura")) dataGridView2.Columns["tipo_factura"].Visible = false;
                            if (dataGridView2.Columns.Contains("idCondicionIVA")) dataGridView2.Columns["idCondicionIVA"].Visible = false;

                            // Ajustes de diseño para que se vea bien
                            dataGridView2.Columns["RAZÓN SOCIAL"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar datos de SurFe: " + ex.Message);
                    }
                }
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                id_clienteselect = row.Cells["id_cliente"].Value?.ToString();
                cuitselect = row.Cells["CUIT"].Value?.ToString();
                razonsocialselect = row.Cells["RAZÓN SOCIAL"].Value?.ToString();
                domicilio = row.Cells["DIRECCIÓN"].Value?.ToString();
                localidad = row.Cells["LOCALIDAD"].Value?.ToString();
                factura_tipo = row.Cells["tipo_factura"].Value?.ToString();
                condicioniva = row.Cells["idCondicionIVA"].Value?.ToString();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}