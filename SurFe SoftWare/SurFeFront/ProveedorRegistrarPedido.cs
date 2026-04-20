using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
// Usamos solo los namespaces básicos de iText
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace SurFeFront
{
    public partial class ProveedorRegistrarPedido : Form
    {
        private string conString = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
        private int idProveedorSeleccionado = -1;

        public ProveedorRegistrarPedido()
        {
            InitializeComponent();
        }

        // --- BUSCADORES ---
        private void btnbuscarproveedor_Click(object sender, EventArgs e)
        {
            using (BusquedaProveedor b = new BusquedaProveedor())
            {
                if (b.ShowDialog() == DialogResult.OK)
                {
                    idProveedorSeleccionado = b.IdSeleccionado;
                    lbrazonsocial.Text = b.NombreSeleccionado;
                }
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            using (BusquedaProducto b = new BusquedaProducto())
            {
                if (b.ShowDialog() == DialogResult.OK)
                {
                    lbbarcode.Text = b.BarcodeSeleccionado;
                    lbdetalle.Text = b.NombreSeleccionado;
                    tbcantidad.Focus();
                }
            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (lbbarcode.Text == "Código" || lbbarcode.Text == "***") return;
            if (!int.TryParse(tbcantidad.Text, out int cant) || cant <= 0) return;

            dataGridView1.Rows.Add(lbbarcode.Text, lbdetalle.Text, cant);
            tbcantidad.Clear();
            lbbarcode.Text = "Código";
            lbdetalle.Text = "Seleccione otro producto...";
        }

        // --- GUARDADO ---
        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (idProveedorSeleccionado == -1 || dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Faltan datos para completar el pedido.", "SurFe");
                return;
            }

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlTransaction tra = con.BeginTransaction();
                try
                {
                    // 1. Cabecera
                    string sqlCab = @"INSERT INTO pedido_proveedor (id_proveedor, fecha, estado) 
                                      VALUES (@idp, GETDATE(), 'Pendiente');
                                      SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdCab = new SqlCommand(sqlCab, con, tra);
                    cmdCab.Parameters.AddWithValue("@idp", idProveedorSeleccionado);
                    int idGenerado = Convert.ToInt32(cmdCab.ExecuteScalar());

                    // 2. Detalles
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["Barcode"].Value != null)
                        {
                            string sqlDet = "INSERT INTO pedido_detalle (id_pedido, barcode, cantidad) VALUES (@idp, @bar, @cant)";
                            SqlCommand cmdDet = new SqlCommand(sqlDet, con, tra);
                            cmdDet.Parameters.AddWithValue("@idp", idGenerado);
                            cmdDet.Parameters.AddWithValue("@bar", row.Cells["Barcode"].Value.ToString());
                            cmdDet.Parameters.AddWithValue("@cant", Convert.ToInt32(row.Cells["Cantidad"].Value));
                            cmdDet.ExecuteNonQuery();
                        }
                    }

                    tra.Commit();

                    // 3. Generar PDF (Sin estilos conflictivos)
                    GenerarYMostrarPDF(idGenerado, lbrazonsocial.Text);
                    this.Close();
                }
                catch (Exception ex)
                {
                    tra.Rollback();
                    MessageBox.Show("Error al guardar: " + ex.Message);
                }
            }
        }

        // --- GENERACIÓN DE PDF LIMPIA ---
        private void GenerarYMostrarPDF(int nro, string prov)
        {
            // 1. Definir rutas (Igual que en tu código de Nota de Crédito)
            string directorioPrograma = AppDomain.CurrentDomain.BaseDirectory;
            string nombreArchivo = "Pedido_" + GetNombreArchivoFechaHora();
            string rutaCompletaArchivo = Path.Combine(directorioPrograma, nombreArchivo);

            try
            {
                // 2. Crear el HTML (Más fácil de manejar que los objetos Paragraph rebeldes)
                string filasHtml = "";
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Barcode"].Value != null)
                    {
                        filasHtml += $@"
                    <tr>
                        <td style='border: 1px solid #ddd; padding: 8px;'>{row.Cells["Barcode"].Value}</td>
                        <td style='border: 1px solid #ddd; padding: 8px;'>{row.Cells["Detalle"].Value}</td>
                        <td style='border: 1px solid #ddd; padding: 8px; text-align: center;'>{row.Cells["Cantidad"].Value}</td>
                    </tr>";
                    }
                }

                string PaginaHTML_Texto = $@"
            <html>
            <body style='font-family: Arial, sans-serif;'>
                <div style='text-align: center;'>
                    <h1 style='color: #2c3e50;'>SurFe - ORDEN DE PEDIDO</h1>
                    <p><b>Número de Pedido:</b> {nro} | <b>Fecha:</b> {DateTime.Now:dd/MM/yyyy}</p>
                    <hr/>
                </div>
                <div style='margin: 20px 0;'>
                    <p><b>Proveedor:</b> {prov}</p>
                </div>
                <table style='width: 100%; border-collapse: collapse;'>
                    <thead>
                        <tr style='background-color: #2c3e50; color: white;'>
                            <th style='padding: 10px;'>Código</th>
                            <th style='padding: 10px;'>Producto</th>
                            <th style='padding: 10px;'>Cant.</th>
                        </tr>
                    </thead>
                    <tbody>
                        {filasHtml}
                    </tbody>
                </table>
                <p style='margin-top: 50px;'>Firma Autorizada: _________________________</p>
            </body>
            </html>";

                // 3. Generar el PDF usando iTextSharp (Tu método de confianza)
                using (FileStream stream = new FileStream(rutaCompletaArchivo, FileMode.Create))
                {
                    iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25);
                    iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, stream);

                    pdfDoc.Open();

                    using (StringReader sr = new StringReader(PaginaHTML_Texto))
                    {
                        iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();
                }

                // 4. Abrir en tu PDFView (que ya sabemos que funciona)
                PDFView formPDF = new PDFView(rutaCompletaArchivo);
                formPDF.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar PDF: " + ex.Message, "SurFe Error");
            }
        }

        // No te olvides de copiar este método también si no lo tenés en este form
        private static string GetNombreArchivoFechaHora()
        {
            return DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf";
        }

        private void button1_Click(object sender, EventArgs e) => this.Close();
    }
}