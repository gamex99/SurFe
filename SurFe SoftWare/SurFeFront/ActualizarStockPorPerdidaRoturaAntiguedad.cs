using iTextSharp.text.pdf;
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
    public partial class ActualizarStockPorPerdidaRoturaAntiguedad : Form
    {
        public ActualizarStockPorPerdidaRoturaAntiguedad()
        {
            InitializeComponent();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
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





                        break;
                    }
                }



            }
        }

        private void btncargar_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            for (int j = 0; j < dataGridView1.RowCount; j++)
            {
                if (dataGridView1.Rows[j].Cells[2].Value != null && dataGridView1.Rows[j].Cells[3].Value != null)
                {
                    string sql = "SELECT stock FROM producto WHERE barcode = @barcode;";

                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@barcode", int.Parse(dataGridView1.Rows[j].Cells[0].Value.ToString()));
                    int stock = (int)command.ExecuteScalar();
                   
                    
                    string sql1 = "INSERT INTO motivoBajaStock (barcodebaja, cantidadbaja, motivo, operador) " +
             "VALUES (@barcodebaja, @cantidadbaja, @motivo, @operador);";
                    SqlCommand commandd = new SqlCommand(sql1, connection);

                    commandd.Parameters.AddWithValue("@barcodebaja", int.Parse(dataGridView1.Rows[j].Cells[0].Value.ToString()));
                    commandd.Parameters.AddWithValue("@cantidadbaja", int.Parse(dataGridView1.Rows[j].Cells[2].Value.ToString()));
                    commandd.Parameters.AddWithValue("@motivo", dataGridView1.Rows[j].Cells[3].Value.ToString());
                    commandd.Parameters.AddWithValue("@operador", ClaseCompartida.operador);
                    commandd.ExecuteNonQuery();

                    int newStock = 0;
                    int stockbaja = 0;
                    int.TryParse(dataGridView1.Rows[j].Cells[2].Value.ToString(), out stockbaja);
                    newStock = stock - stockbaja;
                    //MessageBox.Show("STOCK " + stock +"STOCKBJA: " + stockbaja + "NEWSTOCK: " + newStock , "Stock Actualizado");


                    string updateSql = "UPDATE producto SET stock = @newStock WHERE barcode = @barcode;";
                    SqlCommand updateCommand = new SqlCommand(updateSql, connection);
                    updateCommand.Parameters.AddWithValue("@newStock", newStock);
                    updateCommand.Parameters.AddWithValue("@barcode", int.Parse(dataGridView1.Rows[j].Cells[0].Value.ToString()));
                    updateCommand.ExecuteNonQuery();
                    

                }
            }
            connection.Close();
            MessageBox.Show("Stock Actualizado Correctamente ", "Stock Actualizado");
            this.Close();
        }
    }
}
