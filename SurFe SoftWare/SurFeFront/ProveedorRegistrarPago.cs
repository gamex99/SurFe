using Org.BouncyCastle.Asn1.Mozilla;
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
    public partial class ProveedorRegistrarPago : Form
    {
        public int id;
        public string razon_social;

        public ProveedorRegistrarPago()
        {
            InitializeComponent();
            buscarDatos();
        }

        private void buscarproveedor_Click(object sender, EventArgs e)
        {
            ProveedorSelect form = new ProveedorSelect();

            // Mostrar el formulario secundario y verificar si se hizo clic en "Aceptar"
            if (form.ShowDialog() == DialogResult.OK)
            {


                id = form.id;

                razon_social = form.razon_social;



                lbrazonsocial.Text = razon_social;
            }
        }

        private void buscarDatos()
        {




            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // string filtro = tbBuscar;
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);




            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand("GetProveedorPagos", connection);





                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;

                connection.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error executing stored procedure: " + ex.Message);
            }

        }

        private void cargarfactura_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string sql = "INSERT INTO dbo.proveedorpago ( [id_proveedor], [fecha], [numero_factura], [monto]) VALUES ( @id_proveedor, @fecha, @numero_factura, @monto)";
            SqlCommand command = new SqlCommand(sql, connection);

            DateTime fechaActual = DateTime.Now;

            command.Parameters.AddWithValue("@fecha", fechaActual);
            command.Parameters.AddWithValue("@id_proveedor", id);
            command.Parameters.AddWithValue("@numero_factura", tbfactura.Text);
            command.Parameters.AddWithValue("@monto", tbmonto.Text);
            // connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
