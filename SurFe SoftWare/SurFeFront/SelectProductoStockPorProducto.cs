using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurFeFront
{
    public partial class SelectProductoStockPorProducto : Form
    {
        // --- AGREGAMOS EL TIMER ---
        private System.Windows.Forms.Timer searchTimer;

        public string barcode { get; private set; }
        public string detalle { get; private set; }
        public string stock { get; private set; }
        public float precio { get; private set; }

        public SelectProductoStockPorProducto()
        {
            InitializeComponent();

            // --- INICIALIZAMOS EL TIMER ---
            searchTimer = new System.Windows.Forms.Timer();
            searchTimer.Interval = 400; // Espera 400ms después de la última tecla para buscar
            searchTimer.Tick += SearchTimer_Tick;
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop(); // Detenemos el timer
            Buscar();           // Ejecutamos la búsqueda real
        }

        private void CargarDatos()
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            string filtro = "";

            using (SqlConnection connection = new SqlConnection(conString))
            {
                using (SqlCommand command = new SqlCommand("GetProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@filtro", filtro);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();

                    connection.Open();
                    adapter.Fill(dt);
                    connection.Close();

                    dataGridView3.DataSource = dt;
                }
            }
        }

        private void SelectProductoVenta_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void Buscar()
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            string filtro = txtbuscarproducto.Text;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                using (SqlCommand command = new SqlCommand("GetProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@filtro", filtro);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();

                    connection.Open();
                    adapter.Fill(dt);
                    connection.Close();

                    dataGridView3.DataSource = dt;
                }
            }
        }

        // --- MODIFICAMOS EL TEXTCHANGED ---
        private void txtbuscarproducto_TextChanged(object sender, EventArgs e)
        {
            // En lugar de llamar a Buscar() directamente, reiniciamos el timer
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView3.Rows[e.RowIndex];
                object valorCelda = row.Cells["precio"].Value;

                float.TryParse(
                    valorCelda.ToString(),
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out float numeroConComa);

                barcode = row.Cells["barcode"].Value.ToString();
                detalle = row.Cells["detalle"].Value.ToString();
                stock = row.Cells["stock"].Value.ToString();
                precio = numeroConComa;

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}