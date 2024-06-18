using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurFeFront
{
    public partial class SelectProductoStockPorProducto : Form
    {
        public string barcode { get; private set; }
        public string detalle { get; private set; }
        public string stock { get; private set; }
        public float precio { get; private set; }  
        public SelectProductoStockPorProducto()
        {
            InitializeComponent();
        }
        private void CargarDatos()
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

            // Definir la variable de filtro (por ejemplo, asumiendo que tienes una variable llamada "filtro")
            string filtro = "";

            // Crear una conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(conString))
            {
                // Crear un objeto SqlCommand y especificar que es un procedimiento almacenado
                using (SqlCommand command = new SqlCommand("GetProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetro al procedimiento almacenado
                    command.Parameters.AddWithValue("@filtro", filtro);

                    // Crear un adaptador de datos y un conjunto de datos
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    System.Data.DataSet dataSet = new System.Data.DataSet();

                    // Abrir la conexión y llenar el conjunto de datos con los resultados del procedimiento almacenado
                    connection.Open();
                    adapter.Fill(dataSet, "cliente");
                    connection.Close();

                    // Asignar el conjunto de datos como origen de datos para el DataGridView
                    dataGridView3.DataSource = dataSet.Tables["cliente"];
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

            // Definir la variable de filtro (por ejemplo, asumiendo que tienes una variable llamada "filtro")
            string filtro = txtbuscarproducto.Text;

            // Crear una conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(conString))
            {
                // Crear un objeto SqlCommand y especificar que es un procedimiento almacenado
                using (SqlCommand command = new SqlCommand("GetProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetro al procedimiento almacenado
                    command.Parameters.AddWithValue("@filtro", filtro);

                    // Crear un adaptador de datos y un conjunto de datos
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    System.Data.DataSet dataSet = new System.Data.DataSet();

                    // Abrir la conexión y llenar el conjunto de datos con los resultados del procedimiento almacenado
                    connection.Open();
                    adapter.Fill(dataSet, "cliente");
                    connection.Close();

                    // Asignar el conjunto de datos como origen de datos para el DataGridView
                    dataGridView3.DataSource = dataSet.Tables["cliente"];
                }
            }
        }

        private void txtbuscarproducto_TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Al hacer doble clic en una celda, se obtienen los datos de esa fila
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

                // Establecer el resultado del cuadro de diálogo como OK
                DialogResult = DialogResult.OK;

                // Cerrar el formulario
                Close();
            }
        }
    }
}
