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
            CargarProducto NewProd = new CargarProducto();
            NewProd.modo = EnumModoForm.Alta;
            NewProd.ShowDialog();
            NewProd.FormClosed += delegate
            {
                buscarDatos();
            };



        }

        private void button2_Click(object sender, EventArgs e)
        {
            CargarProducto ConsProd = new CargarProducto();
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
            ClaseCompartida.categoria = (int)dataProductos.Rows[e.RowIndex].Cells[6].Value;
            ClaseCompartida.barcode = (int)dataProductos.Rows[e.RowIndex].Cells[1].Value;
            ClaseCompartida.detalle = (string)dataProductos.Rows[e.RowIndex].Cells[2].Value;
            ClaseCompartida.stock = (int)dataProductos.Rows[e.RowIndex].Cells[3].Value;
            ClaseCompartida.precio = (decimal)dataProductos.Rows[e.RowIndex].Cells[4].Value;
        }

        private void btncons_Click(object sender, EventArgs e)
        {
            CargarProducto ConsProd = new CargarProducto();
            ConsProd.modo = EnumModoForm.Consulta;
            ConsProd.ShowDialog();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            int ideliminar = (int)dataProductos.SelectedCells[0].Value;
            DialogResult result = MessageBox.Show("¿Desea eliminar el producto" + (string)dataProductos.SelectedCells[2].Value + "?", "Mensaje de confirmación",
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
        private void borrarproducto(int idEliminar)
        {
            string errorMessage = null;
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("DELETE FROM producto WHERE id = @ideliminar", connection))
                    {
                        command.Parameters.AddWithValue("@ideliminar", idEliminar);

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
