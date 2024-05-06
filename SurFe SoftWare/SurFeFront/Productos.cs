using SurFe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace SurFeFront
{
    public partial class Productos : Form
    {

        public Productos()
        {
            InitializeComponent();
            getCategorias();
            buscarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 NewProd = new Form3();
            //NewProd.modo = EnumModoForm.Alta;               
            NewProd.ShowDialog();
            NewProd.FormClosed += delegate
            {
                buscarDatos();
            };
            

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 ConsProd = new Form1();
            ConsProd.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void getCategorias()
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();

            string sql = "SELECT [id], [categoria] FROM [dbo].[categoria_productos]";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            cbcategorias.Items.Clear();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string categoria = reader.GetString(1);

                // Add category name to the ComboBox

                //cbcategorias.Items.Insert( categoria);
                cbcategorias.Items.Add(categoria);
            }
            reader.Close();
            connection.Close();
        }

        private void buscarDatos()
        {




            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // string filtro = tbBuscar;
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            int selectedindex = 0;
            selectedindex = cbcategorias.SelectedIndex + 1;
            if (cbcategorias.SelectedIndex == null)
            {
                selectedindex = 0;
            }


            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand("GetProductos", connection);
                command.Parameters.AddWithValue("@filtro", tbBuscar.Text.ToString());
                if (selectedindex != 0)
                {
                    command.Parameters.AddWithValue("@categoriaID", selectedindex);
                }
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataProductos.DataSource = dataTable;

                connection.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error executing stored procedure: " + ex.Message);
            }

        }

        private void tbBuscar_TextChanged(object sender, EventArgs e)
        {
            buscarDatos();
        }

        private void cbcategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            buscarDatos();
        }

        private void cbcategorias_SelectedValueChanged(object sender, EventArgs e)
        {
            buscarDatos();

        }

        private void cbcategorias_TextChanged(object sender, EventArgs e)
        {
            buscarDatos();
        }
    }
}
