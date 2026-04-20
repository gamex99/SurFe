using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SurFeFront
{
    public partial class ProveedorRegistrarReclamo : Form
    {
        string conString = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
        int idProv = -1;
        int idPed = -1;

        public ProveedorRegistrarReclamo()
        {
            InitializeComponent();
            // Limpiamos por las dudas y cargamos los dos tipos que pide el criterio de SCRUM
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("Reclamo");
            cmbTipo.Items.Add("Devolución");

            // Seleccionamos "Reclamo" por defecto
            cmbTipo.SelectedIndex = 0;
        }

        private void btnBuscarPedido_Click(object sender, EventArgs e)
        {
            using (BusquedaPedidoRecibido b = new BusquedaPedidoRecibido())
            {
                if (b.ShowDialog() == DialogResult.OK)
                {
                    idPed = b.IdPedido;
                    idProv = b.IdProveedor;
                    lblProveedor.Text = "Proveedor: " + b.Proveedor;
                    txtComprobante.Text = b.IdPedido.ToString();

                    CargarItemsDelPedido(idPed);
                }
            }
        }

        private void CargarItemsDelPedido(int id)
        {
            dgvProductos.Rows.Clear();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string sql = @"SELECT d.barcode, p.detalle, d.cantidad 
                                   FROM pedido_detalle d 
                                   JOIN producto p ON d.barcode = p.barcode 
                                   WHERE d.id_pedido = @id";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        // Asegurate de que el orden coincida con las columnas que creaste en el DataGridView
                        dgvProductos.Rows.Add(dr["barcode"], dr["detalle"], dr["cantidad"], 0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos del pedido: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idProv == -1) { MessageBox.Show("Seleccione un pedido primero."); return; }
            if (string.IsNullOrWhiteSpace(txtMotivo.Text)) { MessageBox.Show("El motivo es obligatorio."); return; }

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlTransaction tra = con.BeginTransaction();
                try
                {
                    // 1. Insertamos la Cabecera
                    string sqlR = @"INSERT INTO reclamo_devolucion_proveedor (id_proveedor, tipo, motivo, id_comprobante_asociado, estado, fecha_registro) 
                            VALUES (@idp, @tipo, @mot, @idped, 'Abierto', GETDATE()); SELECT SCOPE_IDENTITY();";

                    SqlCommand cmdR = new SqlCommand(sqlR, con, tra);
                    cmdR.Parameters.AddWithValue("@idp", idProv);
                    cmdR.Parameters.AddWithValue("@tipo", cmbTipo.Text);
                    cmdR.Parameters.AddWithValue("@mot", txtMotivo.Text);
                    cmdR.Parameters.AddWithValue("@idped", idPed);
                    int idGenerado = Convert.ToInt32(cmdR.ExecuteScalar());

                    // 2. Procesamos los productos de la grilla
                    foreach (DataGridViewRow row in dgvProductos.Rows)
                    {
                        if (row.Cells["CantDevolver"].Value == null) continue;

                        int cantDev = Convert.ToInt32(row.Cells["CantDevolver"].Value);
                        int cantOrig = Convert.ToInt32(row.Cells["CantOriginal"].Value);

                        if (cantDev > 0)
                        {
                            // Validación de cantidad
                            if (cantDev > cantOrig) throw new Exception($"Error en {row.Cells["Detalle"].Value}: No podés devolver más de lo comprado ({cantOrig}).");

                            string bar = row.Cells["Barcode"].Value.ToString();

                            // --- ESTO ES LO QUE FALTABA: GUARDAR EL DETALLE EN LA DB ---
                            string sqlDet = "INSERT INTO reclamo_devolucion_detalle (id_reclamo, barcode, cantidad) VALUES (@idr, @b, @c)";
                            SqlCommand cmdDet = new SqlCommand(sqlDet, con, tra);
                            cmdDet.Parameters.AddWithValue("@idr", idGenerado);
                            cmdDet.Parameters.AddWithValue("@b", bar);
                            cmdDet.Parameters.AddWithValue("@c", cantDev);
                            cmdDet.ExecuteNonQuery();

                            // Si es devolución, restamos el stock físico
                            if (cmbTipo.Text == "Devolución")
                            {
                                SqlCommand cmdS = new SqlCommand("UPDATE producto SET stock = stock - @c WHERE barcode = @b", con, tra);
                                cmdS.Parameters.AddWithValue("@c", cantDev);
                                cmdS.Parameters.AddWithValue("@b", bar);
                                cmdS.ExecuteNonQuery();
                            }
                        }
                    }

                    tra.Commit();
                    MessageBox.Show($"Registro completado con éxito. Caso Nro: {idGenerado}");

                    // Llamamos al PDF mejorado pasándole el ID
                    GenerarPDFReclamo(idGenerado);
                    this.Close();
                }
                catch (Exception ex)
                {
                    tra.Rollback();
                    MessageBox.Show("Error al guardar: " + ex.Message);
                }
            }
        }

        private void GenerarPDFReclamo(int id)
        {
            // 1. Definir ruta y carpeta temporal
            string carpeta = Path.Combine(Application.StartupPath, "ComprobantesReclamos");
            if (!Directory.Exists(carpeta)) Directory.CreateDirectory(carpeta);
            string rutaArchivo = Path.Combine(carpeta, $"Reclamo_SurFe_{id}.pdf");

            try
            {
                using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create))
                {
                    // Margenes: Izq, Der, Arp, Abj
                    Document doc = new Document(PageSize.A4, 30, 30, 30, 30);
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    // --- FUENTES ---
                    var fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                    var fontSub = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                    var fontCuerpo = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                    var fontBlanca = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, iTextSharp.text.BaseColor.WHITE);

                    // --- 2. ENCABEZADO (Logo y Título) ---
                    PdfPTable headerTable = new PdfPTable(2);
                    headerTable.WidthPercentage = 100;
                    headerTable.SetWidths(new float[] { 1, 2 });

                    // Intentar cargar logo (ajustalo a tu recurso)
                    try
                    {
                        iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(SurFeFront.Properties.Resources.logo_pp1_carpeta_2023, System.Drawing.Imaging.ImageFormat.Png);
                        logo.ScaleToFit(70, 70);
                        PdfPCell logoCell = new PdfPCell(logo) { Border = iTextSharp.text.Rectangle.NO_BORDER };
                        headerTable.AddCell(logoCell);
                    }
                    catch
                    {
                        headerTable.AddCell(new PdfPCell(new Phrase("SURFE", fontTitulo)) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    }

                    PdfPCell tituloCell = new PdfPCell(new Phrase("COMPROBANTE DE RECLAMO / DEVOLUCIÓN", fontTitulo));
                    tituloCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    tituloCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    tituloCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    headerTable.AddCell(tituloCell);

                    doc.Add(headerTable);
                    doc.Add(new Paragraph(new iTextSharp.text.Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.5f, 100, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_CENTER, -2))));

                    // --- 3. DATOS GENERALES DEL COMPROBANTE ---
                    doc.Add(new Paragraph("\n"));
                    PdfPTable infoTable = new PdfPTable(2);
                    infoTable.WidthPercentage = 100;

                    infoTable.AddCell(new PdfPCell(new Phrase($"Caso Nro: #{id}", fontSub)) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    infoTable.AddCell(new PdfPCell(new Phrase($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}", fontCuerpo)) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });

                    infoTable.AddCell(new PdfPCell(new Phrase(lblProveedor.Text, fontCuerpo)) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    infoTable.AddCell(new PdfPCell(new Phrase($"Tipo: {cmbTipo.Text.ToUpper()}", fontSub)) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });

                    doc.Add(infoTable);
                    doc.Add(new Paragraph("\n"));

                    // --- 4. BLOQUE DE MOTIVO (Destacado en gris) ---
                    PdfPTable motivoBox = new PdfPTable(1);
                    motivoBox.WidthPercentage = 100;
                    PdfPCell mCell = new PdfPCell(new Phrase("MOTIVO DEL RECLAMO:\n\n" + txtMotivo.Text, fontCuerpo));
                    mCell.Padding = 12;
                    mCell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240); // Gris claro
                    mCell.BorderColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    motivoBox.AddCell(mCell);
                    doc.Add(motivoBox);
                    doc.Add(new Paragraph("\n"));

                    // --- 5. DETALLE DE PRODUCTOS (Solo si hay cantidades > 0) ---
                    bool tieneProductos = false;
                    foreach (DataGridViewRow r in dgvProductos.Rows)
                    {
                        if (r.Cells["CantDevolver"].Value != null && Convert.ToInt32(r.Cells["CantDevolver"].Value) > 0)
                        {
                            tieneProductos = true; break;
                        }
                    }

                    if (tieneProductos)
                    {
                        doc.Add(new Paragraph("DETALLE DE PRODUCTOS AFECTADOS:", fontSub));
                        doc.Add(new Paragraph("\n"));

                        PdfPTable table = new PdfPTable(3);
                        table.WidthPercentage = 100;
                        table.SetWidths(new float[] { 1.5f, 4, 1 }); // Ancho de columnas

                        // Encabezados con estilo
                        PdfPCell h1 = new PdfPCell(new Phrase("Código", fontBlanca)) { BackgroundColor = iTextSharp.text.BaseColor.DARK_GRAY, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 };
                        PdfPCell h2 = new PdfPCell(new Phrase("Producto / Descripción", fontBlanca)) { BackgroundColor = iTextSharp.text.BaseColor.DARK_GRAY, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 };
                        PdfPCell h3 = new PdfPCell(new Phrase("Cant.", fontBlanca)) { BackgroundColor = iTextSharp.text.BaseColor.DARK_GRAY, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 };

                        table.AddCell(h1); table.AddCell(h2); table.AddCell(h3);

                        foreach (DataGridViewRow r in dgvProductos.Rows)
                        {
                            if (r.Cells["CantDevolver"].Value != null && Convert.ToInt32(r.Cells["CantDevolver"].Value) > 0)
                            {
                                table.AddCell(new PdfPCell(new Phrase(r.Cells["Barcode"].Value.ToString(), fontCuerpo)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 });
                                table.AddCell(new PdfPCell(new Phrase(r.Cells["Detalle"].Value.ToString(), fontCuerpo)) { Padding = 4 });
                                table.AddCell(new PdfPCell(new Phrase(r.Cells["CantDevolver"].Value.ToString(), fontCuerpo)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 });
                            }
                        }
                        doc.Add(table);
                    }

                    // --- 6. FIRMAS ---
                    doc.Add(new Paragraph("\n\n\n\n\n"));
                    PdfPTable firmaTable = new PdfPTable(2);
                    firmaTable.WidthPercentage = 100;

                    PdfPCell f1 = new PdfPCell(new Phrase("__________________________\nFirma Autorizada SurFe", fontCuerpo)) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER };
                    PdfPCell f2 = new PdfPCell(new Phrase("__________________________\nFirma Proveedor / Transporte", fontCuerpo)) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER };

                    firmaTable.AddCell(f1);
                    firmaTable.AddCell(f2);
                    doc.Add(firmaTable);

                    // Cierre del documento
                    doc.Close();
                }

                // 7. ABRIR VISOR
                PDFView visor = new PDFView(rutaArchivo);
                visor.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico al generar el PDF: " + ex.Message, "Error Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}