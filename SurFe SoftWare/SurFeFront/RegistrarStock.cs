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
            // --- 0. VALIDACIÓN DE GRILLA VACÍA ---
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("No hay productos cargados en la lista para actualizar.",
                                "Lista Vacía", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // --- 1. VALIDACIÓN PREVIA DE TODA LA GRILLA ---
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                var cellValue = dataGridView1.Rows[i].Cells[3].Value;
                string detalleProd = dataGridView1.Rows[i].Cells[1].Value?.ToString() ?? "Desconocido";

                if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()))
                {
                    MessageBox.Show($"La columna 'Nuevo Stock' está vacía en la fila {i + 1} ({detalleProd}).",
                                    "Dato Faltante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(cellValue.ToString(), out int nuevoStock))
                {
                    MessageBox.Show($"El valor '{cellValue}' en la fila {i + 1} no es un número válido.",
                                    "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (nuevoStock < 0)
                {
                    MessageBox.Show($"El stock no puede ser negativo (Fila {i + 1}: {detalleProd}).",
                                    "Valor Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // --- 2. PROCESO DE ACTUALIZACIÓN ---
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            for (int j = 0; j < dataGridView1.RowCount; j++)
                            {
                                string sql = "UPDATE producto SET stock = @newStock WHERE barcode = @barcode;";
                                using (SqlCommand command = new SqlCommand(sql, connection, transaction))
                                {
                                    command.Parameters.AddWithValue("@newStock", Convert.ToInt32(dataGridView1.Rows[j].Cells[3].Value));
                                    command.Parameters.AddWithValue("@barcode", dataGridView1.Rows[j].Cells[0].Value.ToString());
                                    command.ExecuteNonQuery();
                                }
                            }
                            transaction.Commit();
                            MessageBox.Show("¡Todo el stock se actualizó correctamente!", "SurFe - Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error al escribir en la base de datos: " + ex.Message, "Error Crítico");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar con la base de datos: " + ex.Message, "Error de Conexión");
            }
        }
    }

}
