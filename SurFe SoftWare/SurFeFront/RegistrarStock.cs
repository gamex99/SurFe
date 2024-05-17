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
    public partial class RegistrarStock : Form
    {
        
        public RegistrarStock()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectProducto formproducto = new SelectProducto();

            // Mostrar el formulario secundario y verificar si se hizo clic en "Aceptar"
            if (formproducto.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Rows.Add();
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    if (dataGridView1.Rows[j].Cells[0].Value == null)
                    {
                        dataGridView1.Rows[j].Cells[0].Value = formproducto.barcode;
                        dataGridView1.Rows[j].Cells[1].Value = formproducto.detalle;
                        dataGridView1.Rows[j].Cells[2].Value = formproducto.stock;


                        

                        break;
                    }
                }



            }







        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void btncargar_Click(object sender, EventArgs e)
        {

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            for (int j = 0; j < dataGridView1.RowCount; j++)
            {
                if (dataGridView1.Rows[j].Cells[3].Value != null)
                {
                    string sql = @"
UPDATE producto
SET stock = @newStock
WHERE barcode = @barcode;
";

                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@barcode", int.Parse(dataGridView1.Rows[j].Cells[0].Value.ToString()));
                    command.Parameters.AddWithValue("@newStock", int.Parse(dataGridView1.Rows[j].Cells[3].Value.ToString()));

                    command.ExecuteNonQuery();






                }
            }
            connection.Close();
            MessageBox.Show("Stock Actualizado Correctamente", "Stock Actualizado");
            this.Close();
        }
    }

}
