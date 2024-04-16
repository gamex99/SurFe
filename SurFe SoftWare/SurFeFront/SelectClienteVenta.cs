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
        public string cuitselect { get; private set; }
        public string razonsocialselect { get; private set; }
        public string domicilio { get; private set; }
        public string localidad { get; private set; }
        public string factura_tipo {  get; private set; }  
        public string id_clienteselect { get; private set; }
        public string condicioniva { get; private set; }
        public SelectClienteVenta()
        {
            InitializeComponent();
        }

        private void SelectClienteVenta_Load(object sender, EventArgs e)
        {
            CargarDatos();
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
                using (SqlCommand command = new SqlCommand("GetSurFeFinal", connection))
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
                    dataGridView2.DataSource = dataSet.Tables["cliente"];
                }
            }
        }

        private void Buscar()
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

            // Definir la variable de filtro (por ejemplo, asumiendo que tienes una variable llamada "filtro")
            string filtro = textBusquedaVenta.Text;

            // Crear una conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(conString))
            {
                // Crear un objeto SqlCommand y especificar que es un procedimiento almacenado
                using (SqlCommand command = new SqlCommand("GetSurFeFinal", connection))
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
                    dataGridView2.DataSource = dataSet.Tables["cliente"];
                }
            }
        }

        private void textBusquedaVenta_TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Al hacer doble clic en una celda, se obtienen los datos de esa fila
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                id_clienteselect = row.Cells["id_cliente"].Value.ToString();
                cuitselect = row.Cells["cuit"].Value.ToString();
                razonsocialselect = row.Cells["razon_social"].Value.ToString();
                domicilio = row.Cells["domicilio"].Value.ToString();
                localidad = row.Cells["localidad_loc"].Value.ToString();
                factura_tipo = row.Cells["tipo_factura"].Value.ToString();
                condicioniva = row.Cells["CondicionIva"].Value.ToString();
                // Establecer el resultado del cuadro de diálogo como OK
                DialogResult = DialogResult.OK;

                // Cerrar el formulario
                Close();
            }
        }
    }
}

