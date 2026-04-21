using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SurFeFront
{
    public partial class ComprasRegistrar : Form
    {
        string conString = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
        int idFacturaSel = -1;
        int idProvSel = -1;

        public ComprasRegistrar()
        {
            InitializeComponent();
            ConfigurarGrillaRemitos();
        }

        private void ConfigurarGrillaRemitos()
        {
            dgvRemitos.Columns.Clear();
            dgvRemitos.AutoGenerateColumns = false;

            // Checkbox para selección múltiple (Criterio: uno o más remitos)
            dgvRemitos.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colCheck", HeaderText = "Asociar", Width = 60 });
            dgvRemitos.Columns.Add(new DataGridViewTextBoxColumn { Name = "id_remito", Visible = false });
            dgvRemitos.Columns.Add(new DataGridViewTextBoxColumn { Name = "nro_remito", HeaderText = "Nro. Remito", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvRemitos.Columns.Add(new DataGridViewTextBoxColumn { Name = "fecha_entrada", HeaderText = "Fecha Ingreso", ReadOnly = true, Width = 120 });
        }

        private void btnSeleccionarFactura_Click(object sender, EventArgs e)
        {
            // Llamamos al buscador de Facturas (SCRUM-14)
            using (BusquedaFacturaCompra f = new BusquedaFacturaCompra(soloNoAsociadas: true))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    idFacturaSel = f.IdFactura;
                    idProvSel = f.IdProveedor;
                    lblFacturaInfo.Text = $"Factura: {f.NroFactura} | Proveedor: {f.NombreProv}";

                    // FILTRO AUTOMÁTICO: Solo remitos del mismo proveedor (Criterio SCRUM)
                    CargarRemitosPendientes(idProvSel);
                }
            }
        }

        private void CargarRemitosPendientes(int idProv)
        {
            dgvRemitos.Rows.Clear();
            using (SqlConnection con = new SqlConnection(conString))
            {
                // Solo remitos que no hayan sido "quemados" en otra compra (Evita duplicación)
                string sql = @"SELECT id_remito, nro_remito, fecha_entrada 
                               FROM remito_entrada 
                               WHERE id_proveedor = @idp 
                               AND id_remito NOT IN (SELECT id_remito FROM compra_remito)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@idp", idProv);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dgvRemitos.Rows.Add(false, dr["id_remito"], dr["nro_remito"], dr["fecha_entrada"]);
                }
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (idFacturaSel == -1) { MessageBox.Show("Debe seleccionar una factura primero."); return; }

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlTransaction tra = con.BeginTransaction();
                try
                {
                    // 1. Crear el registro de Compra (Maestro)
                    string sqlC = @"INSERT INTO compra (id_factura, id_proveedor, nro_orden_compra, fecha_registro) 
                                   VALUES (@idf, @idp, @oc, GETDATE()); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdC = new SqlCommand(sqlC, con, tra);
                    cmdC.Parameters.AddWithValue("@idf", idFacturaSel);
                    cmdC.Parameters.AddWithValue("@idp", idProvSel);
                    cmdC.Parameters.AddWithValue("@oc", txtOrdenCompra.Text);
                    int idCompra = Convert.ToInt32(cmdC.ExecuteScalar());

                    // 2. Vincular Remitos (Detalle / Trazabilidad)
                    int contadorRemitos = 0;
                    foreach (DataGridViewRow row in dgvRemitos.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["colCheck"].Value))
                        {
                            int idR = Convert.ToInt32(row.Cells["id_remito"].Value);
                            SqlCommand cmdR = new SqlCommand("INSERT INTO compra_remito (id_compra, id_remito) VALUES (@idc, @idr)", con, tra);
                            cmdR.Parameters.AddWithValue("@idc", idCompra);
                            cmdR.Parameters.AddWithValue("@idr", idR);
                            cmdR.ExecuteNonQuery();
                            contadorRemitos++;
                        }
                    }

                    if (contadorRemitos == 0) throw new Exception("Debe seleccionar al menos un remito para validar la entrada de mercadería.");

                    // 3. Marcar factura como 'Asociada' para que no vuelva a aparecer
                    SqlCommand cmdF = new SqlCommand("UPDATE factura_compra SET asociada_compra = 1 WHERE id_factura = @idf", con, tra);
                    cmdF.Parameters.AddWithValue("@idf", idFacturaSel);
                    cmdF.ExecuteNonQuery();

                    tra.Commit();
                    MessageBox.Show("Compra registrada con éxito. La trazabilidad entre Factura y Remito ha sido establecida.");
                    GenerarComprobanteCompra(idCompra);
                    this.Close();
                }
                catch (Exception ex)
                {
                    tra.Rollback();
                    MessageBox.Show("Error al registrar: " + ex.Message);
                }
            }
        }
        private void GenerarComprobanteCompra(int idCompra)
        {
            string carpeta = Path.Combine(Application.StartupPath, "ComprobantesCompras");
            if (!Directory.Exists(carpeta)) Directory.CreateDirectory(carpeta);
            string ruta = Path.Combine(carpeta, $"Compra_Vinculada_{idCompra}.pdf");

            try
            {
                Document doc = new Document(PageSize.A4, 30, 30, 30, 30);
                PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
                doc.Open();

                // --- ENCABEZADO ---
                var fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                var fontSub = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                var fontCuerpo = FontFactory.GetFont(FontFactory.HELVETICA, 10);

                doc.Add(new Paragraph("SURFE - REGISTRO DE COMPRA INTEGRAL", fontTitulo));
                doc.Add(new Paragraph($"Operación Nro: #{idCompra} | Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}"));
                doc.Add(new Paragraph("------------------------------------------------------------------"));

                // --- DATOS DE LA OPERACIÓN ---
                doc.Add(new Paragraph("\nDATOS DE LA FACTURA (Contable):", fontSub));
                doc.Add(new Paragraph(lblFacturaInfo.Text, fontCuerpo)); // Usamos el texto que ya tenemos en pantalla
                doc.Add(new Paragraph($"Orden de Compra Interna: {txtOrdenCompra.Text}", fontCuerpo));

                doc.Add(new Paragraph("\nREMITOS ASOCIADOS (Ingreso de Mercadería):", fontSub));
                doc.Add(new Paragraph("La siguiente mercadería ha sido validada contra la factura mencionada:", fontCuerpo));
                doc.Add(new Paragraph("\n"));

                // --- TABLA DE REMITOS ---
                PdfPTable table = new PdfPTable(2);
                table.WidthPercentage = 100;
                table.AddCell(new PdfPCell(new Phrase("Nro. Remito", fontSub)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Fecha de Ingreso", fontSub)) { BackgroundColor = BaseColor.LIGHT_GRAY });

                foreach (DataGridViewRow r in dgvRemitos.Rows)
                {
                    if (Convert.ToBoolean(r.Cells["colCheck"].Value))
                    {
                        table.AddCell(r.Cells["nro_remito"].Value.ToString());
                        table.AddCell(r.Cells["fecha_entrada"].Value.ToString());
                    }
                }
                doc.Add(table);

                // --- CIERRE ---
                doc.Add(new Paragraph("\n\n\n"));
                doc.Add(new Paragraph("__________________________", fontCuerpo));
                doc.Add(new Paragraph("Firma Responsable Compras", fontCuerpo));
                doc.Add(new Paragraph("\n* Este documento certifica que la mercadería recibida coincide con la facturación del proveedor.", fontCuerpo));

                doc.Close();

                // Mostrar en el visor que ya tenemos
                PDFView visor = new PDFView(ruta);
                visor.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar PDF de compra: " + ex.Message);
            }
        }
    }
}