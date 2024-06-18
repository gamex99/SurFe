using iTextSharp.text.pdf;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SurFeFront
{
    public partial class ProveedorSelect : Form
    {
        public string razon_social { get; private set; }
        public int id { get; private set; }




        public ProveedorSelect()
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

                SqlCommand command = new SqlCommand("GetProveedor", connection);
                command.Parameters.AddWithValue("@filtro", tbfiltro.Text.ToString());




                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataproveedores.DataSource = dataTable;

                connection.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error executing stored procedure: " + ex.Message);
            }

        }

        private void dataproveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Al hacer doble clic en una celda, se obtienen los datos de esa fila
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataproveedores.Rows[e.RowIndex];
               


                razon_social = row.Cells[0].Value.ToString();
                id = (int)dataproveedores.Rows[e.RowIndex].Cells[6].Value;


                // Establecer el resultado del cuadro de diálogo como OK
                DialogResult = DialogResult.OK;

                // Cerrar el formulario
                Close();
            }
        }
    }
}
