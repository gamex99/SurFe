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
            // 0. Validar si la grilla está vacía
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("No hay productos cargados en la lista.", "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // --- 1. PRIMERA PASADA: VALIDACIÓN DE DATOS ---
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        var cantValue = dataGridView1.Rows[i].Cells[2].Value; // CantidadDeBaja
                        var motivoValue = dataGridView1.Rows[i].Cells[3].Value; // Motivo
                        string detalle = dataGridView1.Rows[i].Cells[1].Value?.ToString() ?? "Producto";

                        // Validar que la cantidad sea un número positivo
                        if (cantValue == null || !int.TryParse(cantValue.ToString(), out int cantBaja) || cantBaja <= 0)
                        {
                            MessageBox.Show($"Ingrese una cantidad de baja válida y mayor a cero en la fila {i + 1} ({detalle}).", "Error de Entrada");
                            return;
                        }

                        // Validar que el motivo no esté vacío
                        if (motivoValue == null || string.IsNullOrWhiteSpace(motivoValue.ToString()))
                        {
                            MessageBox.Show($"Debe indicar un motivo para la baja en la fila {i + 1} ({detalle}).", "Dato Faltante");
                            return;
                        }

                        // Validar stock disponible en DB antes de procesar
                        string sqlCheck = "SELECT stock FROM producto WHERE barcode = @barcode;";
                        using (SqlCommand cmdCheck = new SqlCommand(sqlCheck, connection))
                        {
                            cmdCheck.Parameters.AddWithValue("@barcode", dataGridView1.Rows[i].Cells[0].Value.ToString());
                            int stockActual = Convert.ToInt32(cmdCheck.ExecuteScalar());

                            if (cantBaja > stockActual)
                            {
                                MessageBox.Show($"No puede dar de baja {cantBaja} unidades de '{detalle}' porque solo hay {stockActual} en stock.", "Stock Insuficiente");
                                return;
                            }
                        }
                    }

                    // --- 2. SEGUNDA PASADA: PROCESO CON TRANSACCIÓN ---
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            for (int j = 0; j < dataGridView1.RowCount; j++)
                            {
                                string barcode = dataGridView1.Rows[j].Cells[0].Value.ToString();
                                int cantBaja = int.Parse(dataGridView1.Rows[j].Cells[2].Value.ToString());
                                string motivo = dataGridView1.Rows[j].Cells[3].Value.ToString();

                                // A. Insertar en tabla de motivos (Auditoría)
                                // string sqlInsert = @"INSERT INTO motivoBajaStock (barcodebaja, cantidadbaja, motivo, operador) 
                                //          VALUES (@barcodebaja, @cantidadbaja, @motivo, @operador);";
                                string sqlInsert = @"INSERT INTO motivoBajaStock (barcodebaja, cantidadbaja, motivo, operador, fecha) 
                     VALUES (@barcodebaja, @cantidadbaja, @motivo, @operador, @fecha);";

                                using (SqlCommand cmdInsert = new SqlCommand(sqlInsert, connection, transaction))
                                {
                                    cmdInsert.Parameters.AddWithValue("@barcodebaja", barcode);
                                    cmdInsert.Parameters.AddWithValue("@cantidadbaja", cantBaja);
                                    cmdInsert.Parameters.AddWithValue("@motivo", motivo);
                                    cmdInsert.Parameters.AddWithValue("@operador", ClaseCompartida.operador);
                                    cmdInsert.Parameters.AddWithValue("@fecha", DateTime.Now);
                                    cmdInsert.ExecuteNonQuery();
                                }

                                // B. Actualizar stock restando la cantidad
                                string sqlUpdate = "UPDATE producto SET stock = stock - @cantidad WHERE barcode = @barcode;";
                                using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, connection, transaction))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@cantidad", cantBaja);
                                    cmdUpdate.Parameters.AddWithValue("@barcode", barcode);
                                    cmdUpdate.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                            MessageBox.Show("Bajas de stock procesadas correctamente.", "SurFe - Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error durante la actualización: " + ex.Message, "Error Crítico");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message, "Error");
            }
        }
    }
}
