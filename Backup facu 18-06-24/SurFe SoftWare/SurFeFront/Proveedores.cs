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
    public partial class Proveedores : Form
    {


        public Proveedores()
        {
            InitializeComponent();
            
            buscarDatos();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistrarProveedor NewProd = new RegistrarProveedor();
            NewProd.modo = EnumModoForm.Alta;
            NewProd.ShowDialog();
            NewProd.FormClosed += delegate
            {
                buscarDatos();
            };



        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistrarProveedor ConsProd = new RegistrarProveedor();
            ConsProd.modo = EnumModoForm.Modificacion;
            ConsProd.ShowDialog();

            
           
               
                   
                    buscarDatos();
                
                
               
                
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
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
                command.Parameters.AddWithValue("@filtro", tbBuscar.Text.ToString());
               
                
                   
                 
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

        private void EnviarDatos()
        {


        }

        private void dataProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClaseCompartida.razon_rosial = (string)dataProductos.Rows[e.RowIndex].Cells[0].Value;
            ClaseCompartida.cuit = (long)dataProductos.Rows[e.RowIndex].Cells[1].Value;
            ClaseCompartida.direccion = (string)dataProductos.Rows[e.RowIndex].Cells[2].Value;
            ClaseCompartida.tel = (long)dataProductos.Rows[e.RowIndex].Cells[3].Value;
            ClaseCompartida.correo = (string)dataProductos.Rows[e.RowIndex].Cells[4].Value;
            ClaseCompartida.idlocalidad = (int)dataProductos.Rows[e.RowIndex].Cells[5].Value;
        }

        private void btncons_Click(object sender, EventArgs e)
        {
            RegistrarProveedor ConsProd = new RegistrarProveedor();
            ConsProd.modo = EnumModoForm.Consulta;
            ConsProd.ShowDialog();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            long ideliminar = (long)dataProductos.SelectedCells[1].Value;
            DialogResult result = MessageBox.Show("¿Desea eliminar el Proveedor" + (string)dataProductos.SelectedCells[2].Value + "?", "Mensaje de confirmación",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            switch (result)
            {
                case DialogResult.Yes:
                    borrarproducto(ideliminar);
                    buscarDatos();

                    break;
                case DialogResult.No:
                    
                    break;

            }
        }
        private void borrarproducto(long idEliminar)
        {
            string errorMessage = null;
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("DELETE FROM proveedor WHERE cuit = @cuitel", connection))
                    {
                        command.Parameters.AddWithValue("@cuitel", idEliminar);

                        int rowsAffected = command.ExecuteNonQuery();
                        
                    }
                }
            }
            catch (SqlException ex)
            {
                errorMessage = ex.Message;
            }

            if (errorMessage != null)
            {
                MessageBox.Show("Error al cargar producto", "" + errorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                MessageBox.Show("Producto borrado correctamente", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
