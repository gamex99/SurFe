using iTextSharp.text.pdf;
using iTextSharp.text.pdf.qrcode;
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
    public partial class RegistrarFactura : Form
    {
        public RegistrarFactura()
        {
            InitializeComponent();
            buscarDatos();
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

                SqlCommand command = new SqlCommand("GetCompra", connection);





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

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell celdaSeleccionada = dataGridView1.SelectedCells[0];

            ClaseCompartida.id_factura = celdaSeleccionada.Value.ToString();


            CargaFactura newMDIChild = new CargaFactura();
            // Set the parent form of the child window.  

            // Display the new form.  
            newMDIChild.FormClosed += newMDIChild_FormClosed;
            newMDIChild.Show();

            buscarDatos();
        }
        private void newMDIChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Ejecutar BuscarDatos() cuando la ventana secundaria se cierre
            buscarDatos();
        }
    }
}
