using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurFeFront
{
    public partial class ControlPorInventario : Form
    {
        private string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

        public ControlPorInventario()
        {
            InitializeComponent();
            getCategorias();
        }

        private void getCategorias()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    connection.Open();
                    string sql = "SELECT [id], [categoria] FROM [dbo].[categoria_productos]";
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    cbcategorias.Items.Clear();
                    cbcategorias.Items.Add("Todas las categorias"); // Índice 0

                    while (reader.Read())
                    {
                        // Agregamos el nombre de la categoría (Índices 1, 2, 3...)
                        cbcategorias.Items.Add(reader.GetString(1));
                    }

                    // Forzamos a que aparezca seleccionado "Todas las categorias" al abrir
                    if (cbcategorias.Items.Count > 0) cbcategorias.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbcategorias.SelectedIndex != -1)
            {
                dataGridView1.Rows.Clear(); // Limpiamos antes de cargar
                cargargrid();
            }
            else MessageBox.Show("Debe seleccionar una categoría", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void Cargar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0) return;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int filasProcesadas = 0;
                        for (int j = 0; j < dataGridView1.RowCount; j++)
                        {
                            var stockNuevoRaw = dataGridView1.Rows[j].Cells[3].Value;
                            if (stockNuevoRaw != null && int.TryParse(stockNuevoRaw.ToString(), out int stockReal))
                            {
                                string barcode = dataGridView1.Rows[j].Cells[0].Value.ToString();
                                int stockSistema = Convert.ToInt32(dataGridView1.Rows[j].Cells[2].Value);
                                int diferencia = stockReal - stockSistema;

                                // 1. Registrar Historial de Inventario (Auditoría)
                                string sqlAudit = @"INSERT INTO historialInventario (barcode, fecha, stock_sistema, stock_real, diferencia, operador) 
                                                  VALUES (@barcode, @fecha, @sistema, @real, @dif, @ope)";
                                using (SqlCommand cmdAudit = new SqlCommand(sqlAudit, connection, transaction))
                                {
                                    cmdAudit.Parameters.AddWithValue("@barcode", barcode);
                                    cmdAudit.Parameters.AddWithValue("@fecha", DateTime.Now);
                                    cmdAudit.Parameters.AddWithValue("@sistema", stockSistema);
                                    cmdAudit.Parameters.AddWithValue("@real", stockReal);
                                    cmdAudit.Parameters.AddWithValue("@dif", diferencia);
                                    cmdAudit.Parameters.AddWithValue("@ope", ClaseCompartida.operador);
                                    cmdAudit.ExecuteNonQuery();
                                }

                                // 2. Actualizar stock al valor REAL contado
                                string sqlUpdate = "UPDATE producto SET stock = @newStock WHERE barcode = @barcode";
                                using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, connection, transaction))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@newStock", stockReal);
                                    cmdUpdate.Parameters.AddWithValue("@barcode", barcode);
                                    cmdUpdate.ExecuteNonQuery();
                                }
                                filasProcesadas++;
                            }
                        }
                        transaction.Commit();
                        MessageBox.Show($"Se procesaron {filasProcesadas} ajustes de stock correctamente.", "SurFe - Éxito");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error al actualizar inventario: " + ex.Message);
                    }
                }
            }
        }

        private void Listado_Click(object sender, EventArgs e)
        {
            if (cbcategorias.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una categoría para generar el listado.", "Atención");
                return;
            }

            try
            {
                // 1. Verificación de Carpeta Temporal
                if (!Directory.Exists(ClaseCompartida.carpetaTemp))
                    Directory.CreateDirectory(ClaseCompartida.carpetaTemp);

                string rutaCompletaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ListadoInventario.pdf");
                string PaginaHTML_Texto = GenerarHTMLPlantilla();

                string filas = "";
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    connection.Open();
                    string sql;

                    // --- LÓGICA DE FILTRADO PARA TODAS (Índice 0) O UNA ESPECÍFICA ---
                    if (cbcategorias.SelectedIndex == 0)
                    {
                        // Si es "Todas", no filtramos por categoría
                        sql = "SELECT barcode, detalle, stock FROM producto";
                    }
                    else
                    {
                        // Si es una específica, usamos el parámetro
                        sql = "SELECT barcode, detalle, stock FROM producto WHERE categoria = @idcategoria";
                    }

                    using (SqlCommand comando = new SqlCommand(sql, connection))
                    {
                        // Solo añadimos el parámetro si no elegimos "Todas"
                        if (cbcategorias.SelectedIndex != 0)
                        {
                            comando.Parameters.AddWithValue("@idcategoria", cbcategorias.SelectedIndex);
                        }

                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                // Agregamos la raya para que el operario escriba el conteo a mano
                                filas += $"<tr><td>{lector[0]}</td><td>{lector[1]}</td><td>{lector[2]}</td><td style='border-bottom: 1px solid black; width: 80px;'></td></tr>";
                            }
                        }
                    }
                }

                // 2. Reemplazo de marcadores en el HTML
                // Si es "Todas", el título dirá "TODAS LAS CATEGORIAS", sino dirá el nombre de la categoría elegida
                string tituloReporte = cbcategorias.SelectedIndex == 0 ? "TODAS LAS CATEGORIAS" : cbcategorias.Text.ToUpper();
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas).Replace("@tipoinfo", tituloReporte);

                // 3. Generación del PDF con iTextSharp
                using (FileStream stream = new FileStream(rutaCompletaArchivo, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    // Logo de SurFe
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(SurFeFront.Properties.Resources.logo_pp1_carpeta_2023, System.Drawing.Imaging.ImageFormat.Png);
                    img.ScaleToFit(60, 60);
                    img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                    pdfDoc.Add(img);

                    using (StringReader sr = new StringReader(PaginaHTML_Texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                    pdfDoc.Close();
                }

                // 4. Abrir el visor de PDF
                new PDFView(rutaCompletaArchivo).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar PDF: " + ex.Message, "Error SurFe");
            }
        }

        private string GenerarHTMLPlantilla()
        {
            return @"<html><head><style>
                body { font-family: 'Arial'; }
                .header { text-align: center; background-color: #3498db; color: white; padding: 10px; }
                table { width: 100%; border-collapse: collapse; }
                th, td { border: 1px solid #ddd; padding: 8px; text-align: left; }
                th { background-color: #f1c40f; color: black; }
                </style></head><body>
                <div class='header'><h3>SURFE - @tipoinfo</h3></div>
                <br/><table><thead><tr><th>Barcode</th><th>Descripción</th><th>Stock Sist.</th><th>Conteo Real</th></tr></thead>
                <tbody>@FILAS</tbody></table></body></html>";
        }

        private void cargargrid()
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                try
                {
                    connection.Open();
                    string sql;

                    // Si es 0, no aplicamos el WHERE
                    if (cbcategorias.SelectedIndex == 0)
                    {
                        sql = "SELECT barcode, detalle, stock FROM producto";
                    }
                    else
                    {
                        // Filtramos por categoría. 
                        // Usamos SelectedIndex porque cargaste las categorías en orden.
                        sql = "SELECT barcode, detalle, stock FROM producto WHERE categoria = @idcategoria";
                    }

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        if (cbcategorias.SelectedIndex != 0)
                        {
                            // IMPORTANTE: Como el índice 0 es "Todas", 
                            // el índice 1 del CB corresponde al ID 1 de la base de datos.
                            command.Parameters.AddWithValue("@idcategoria", cbcategorias.SelectedIndex);
                        }

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Limpiamos antes de cargar
                            dataGridView1.Rows.Clear();

                            while (reader.Read())
                            {
                                dataGridView1.Rows.Add(
                                    reader["barcode"].ToString(),
                                    reader["detalle"].ToString(),
                                    reader["stock"].ToString()
                                );
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar productos: " + ex.Message);
                }
            }
        }
    }
}