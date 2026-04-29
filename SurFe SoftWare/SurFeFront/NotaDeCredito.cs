using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using SurFeEntidades;
using SurFeFront;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace SurFe
{
    public partial class NotaDeCredito : Form
    {
        private List<DetallesFactura> detalles = new List<DetallesFactura>();
        string cuit;
        string razonsocial;
        string domicilio;
        string localidad;
        int tipo_factura;
        string id_cliente1;
        string letra_factura;
        string condicionivaa;

        public NotaDeCredito()
        {
            InitializeComponent();
            btnagregar.Visible = false;
            cbxfactura.Visible = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Codigo", "Codigo");
            dataGridView1.Columns.Add("Cantidad", "Cantidad");
            dataGridView1.Columns.Add("Producto", "Producto");
            dataGridView1.Columns.Add("preciouni", "Precio Unitario");
            dataGridView1.Columns.Add("Precio", "Precio");
        }

        private void RecalcularSuma()
        {
            decimal SumaSubtotal = 0;
            decimal IVA = 0;
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Precio"].Value != null)
                {
                    SumaSubtotal += Convert.ToDecimal(row.Cells["Precio"].Value);
                }
            }
            IVA = SumaSubtotal * (decimal).21;
            total = SumaSubtotal + IVA;

            subtotal.Text = SumaSubtotal.ToString("N2");
            labeliva.Text = IVA.ToString("N2");
            labeltotal.Text = total.ToString("N2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectClienteVenta form = new SelectClienteVenta();
            if (form.ShowDialog() == DialogResult.OK)
            {
                id_cliente1 = form.id_clienteselect;
                cuit = form.cuitselect;
                razonsocial = form.razonsocialselect;
                domicilio = form.domicilio;
                localidad = form.localidad;
                condicionivaa = form.condicioniva;
                int.TryParse(form.factura_tipo, out tipo_factura);

                labelrazonsocial.Text = "Razon Social: " + razonsocial;
                labelcuit.Text = "CUIT: " + cuit;
                labeldireccion.Text = "Direccion: " + domicilio;
                labellocalidad.Text = "Localidad: " + localidad;
            }
        }

        private void btnbuscarart_Click(object sender, EventArgs e)
        {
            SelectProducto formproducto = new SelectProducto();
            if (formproducto.ShowDialog() == DialogResult.OK)
            {
                txtcodigo.Text = formproducto.barcode;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtcodigo.Text) && !string.IsNullOrEmpty(txtcantidad.Text))
            {
                string filtro = txtcodigo.Text;
                string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                int cantidad = int.Parse(txtcantidad.Text);

                using (SqlConnection connection = new SqlConnection(conString))
                {
                    using (SqlCommand command = new SqlCommand("SelectProducto", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@filtro", filtro);
                        try
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string barcode = reader["barcode"].ToString();
                                    string detalle = reader["detalle"].ToString();
                                    decimal precio = Convert.ToDecimal(reader["precio"]);
                                    decimal totalart = precio * cantidad;

                                    dataGridView1.Rows.Add(barcode, cantidad, detalle, precio, totalart);
                                    RecalcularSuma();
                                }
                            }
                        }
                        catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
                    }
                }
            }
        }

        // --- MÉTODO PRINCIPAL: GUARDAR Y SUMAR STOCK ---
        private void button3_Click(object sender, EventArgs e)
        {
            if (labelcuit.Text == "CUIT: ")
            {
                MessageBox.Show("Debe seleccionar un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Debe cargar productos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            int numero = 0;
            string nombreArchivo = "NdC_" + GetNombreArchivoFechaHora();
            string rutaCompletaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nombreArchivo);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // 1. Obtener número actual
                string sqlQuery = "SELECT [numero] FROM [dbo].[numero_factura] WHERE [id_numero] = 1;";
                using (SqlCommand cmdNum = new SqlCommand(sqlQuery, connection))
                {
                    numero = Convert.ToInt32(cmdNum.ExecuteScalar());
                }
                string cadena = numero.ToString().PadLeft(5, '0');

                // 2. Insertar Nota de Crédito
                string sqlInsert = "INSERT INTO dbo.notaDeCredito ([id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (@id, @tipo, @fecha, @total, @loc)";
                using (SqlCommand cmdInsert = new SqlCommand(sqlInsert, connection))
                {
                    cmdInsert.Parameters.AddWithValue("@id", id_cliente1);
                    cmdInsert.Parameters.AddWithValue("@tipo", "5"); // Código para Nota de Crédito
                    cmdInsert.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmdInsert.Parameters.AddWithValue("@total", decimal.Parse(labeltotal.Text));
                    cmdInsert.Parameters.AddWithValue("@loc", nombreArchivo);
                    cmdInsert.ExecuteNonQuery();
                }

                // 3. SUMAR STOCK (DEVOLUCIÓN)
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string codProducto = row.Cells["Codigo"].Value.ToString();
                    int cantDevuelta = Convert.ToInt32(row.Cells["Cantidad"].Value);

                    // Importante: stock = stock + @cant (Suma porque es una Nota de Crédito)
                    string sqlStock = "UPDATE producto SET stock = stock + @cant WHERE barcode = @cod";
                    using (SqlCommand cmdStock = new SqlCommand(sqlStock, connection))
                    {
                        cmdStock.Parameters.AddWithValue("@cant", cantDevuelta);
                        cmdStock.Parameters.AddWithValue("@cod", codProducto);
                        cmdStock.ExecuteNonQuery();
                    }
                }
            }

            // 4. Generación de PDF (Diseño Profesional)
            GenerarPDF(rutaCompletaArchivo, nombreArchivo);

            MessageBox.Show("Nota de crédito registrada y stock actualizado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PDFView formPDF = new PDFView(rutaCompletaArchivo);
            formPDF.ShowDialog();
            this.Close();
        }

        private void GenerarPDF(string ruta, string nombre)
        {
            string html = @"<!DOCTYPE html><html><head><style>
                body { font-family: Arial; font-size: 11px; }
                .letra-box { background: #2c3e50; color: white; font-size: 24px; width: 40px; text-align: center; border-radius: 4px; padding: 5px; }
                table { width: 100%; border-collapse: collapse; margin-bottom: 20px; }
                th { background: #2c3e50; color: white; padding: 8px; text-align: left; }
                td { padding: 8px; border-bottom: 1px solid #eee; }
                .total-final { background: #2c3e50; color: white; font-weight: bold; }
                .alerta { background: #fff3cd; color: #856404; padding: 10px; text-align: center; font-weight: bold; border: 1px solid #ffeeba; }
            </style></head><body>
                <table width='100%'><tr>
                    <td><strong>SurFe Software</strong><br/>Bolivar 325, Peyrano</td>
                    <td align='center'><div class='letra-box'>R</div><br/>COD. 03</td>
                    <td align='right'><strong>NOTA DE CRÉDITO</strong><br/>Fecha: " + DateTime.Now.ToString("dd/MM/yyyy") + @"</td>
                </tr></table>
                <div style='background:#f8f9fa; padding:10px;'>
                    Cliente: " + razonsocial + @" | CUIT: " + cuit + @"<br/>
                    Cond. IVA: " + condicionivaa + @"
                </div>
                <table><thead><tr><th>Cod.</th><th>Cant.</th><th>Descripción</th><th>P. Unit</th><th>Importe</th></tr></thead><tbody>";

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                html += $"<tr><td>{row.Cells[0].Value}</td><td>{row.Cells[1].Value}</td><td>{row.Cells[2].Value}</td><td>$ {row.Cells[3].Value}</td><td>$ {row.Cells[4].Value}</td></tr>";
            }

            html += @"</tbody></table>
                <table width='100%'><tr><td width='60%'></td><td width='40%'>
                    Subtotal: $ " + subtotal.Text + @"<br/>IVA 21%: $ " + labeliva.Text + @"<br/>
                    <div class='total-final'>TOTAL: $ " + labeltotal.Text + @"</div>
                </td></tr></table>
                <div class='alerta'>DOCUMENTO NO VÁLIDO COMO FACTURA - USO DIDÁCTICO</div>
            </body></html>";

            using (FileStream stream = new FileStream(ruta, FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                using (StringReader sr = new StringReader(html))
                {
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                }
                pdfDoc.Close();
            }
        }

        private static string GetNombreArchivoFechaHora()
        {
            return DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf";
        }

        private void button4_Click(object sender, EventArgs e) { this.Close(); }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { RecalcularSuma(); }
        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e) { RecalcularSuma(); }

        public class DetallesFactura
        {
            public string Barcode { get; set; }
            public string Detalle { get; set; }
            public int Cantidad { get; set; }
            public decimal PrecioUnitario { get; set; }
            public decimal TotalPorProducto { get; set; }
        }
    }
}