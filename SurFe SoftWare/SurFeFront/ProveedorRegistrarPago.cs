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
    public partial class ProveedorRegistrarPago : Form
    {
        // Cadena de conexión desde App.config
        string conString = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
        int idProv = -1;

        // --- CONSTRUCTOR COMPLETO ---
        public ProveedorRegistrarPago()
        {
            InitializeComponent();

            // 1. Configurar Grilla por código para evitar errores de diseño
            ConfigurarGridFacturas();

            // 2. Cargar Medios de Pago (Criterio SCRUM)
            cmbMedioPago.Items.Clear();
            cmbMedioPago.Items.Add("Efectivo");
            cmbMedioPago.Items.Add("Transferencia Bancaria");
            cmbMedioPago.Items.Add("Cheque");
            cmbMedioPago.Items.Add("Mercado Pago");
            cmbMedioPago.SelectedIndex = 0;

            // 3. Fecha por defecto y labels
            dtpFechaPago.Value = DateTime.Now;
            lblProveedor.Text = "Proveedor: Seleccione uno...";
        }

        private void ConfigurarGridFacturas()
        {
            dgvFacturas.Columns.Clear();
            dgvFacturas.AutoGenerateColumns = false;

            // Columna Checkbox
            DataGridViewCheckBoxColumn colCheck = new DataGridViewCheckBoxColumn();
            colCheck.Name = "Seleccionar";
            colCheck.HeaderText = "Pagar";
            colCheck.Width = 50;
            dgvFacturas.Columns.Add(colCheck);

            // Columnas de Datos
            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdFactura", Visible = false });
            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn { Name = "NroFactura", HeaderText = "Nro. Factura", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn { Name = "FechaEmision", HeaderText = "Emisión", ReadOnly = true, Width = 90 });
            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn { Name = "FechaVencimiento", HeaderText = "Vencimiento", ReadOnly = true, Width = 90 });

            DataGridViewTextBoxColumn colMonto = new DataGridViewTextBoxColumn();
            colMonto.Name = "MontoPendiente";
            colMonto.HeaderText = "Pendiente ($)";
            colMonto.ReadOnly = true;
            colMonto.Width = 110;
            colMonto.DefaultCellStyle.Format = "N2";
            colMonto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvFacturas.Columns.Add(colMonto);

            dgvFacturas.RowHeadersVisible = false;
            dgvFacturas.AllowUserToAddRows = false;
            dgvFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // --- BUSQUEDA DE PROVEEDOR ---
        private void btnBuscarProv_Click(object sender, EventArgs e)
        {
            using (BusquedaProveedor b = new BusquedaProveedor())
            {
                if (b.ShowDialog() == DialogResult.OK)
                {
                    idProv = b.IdSeleccionado;
                    lblProveedor.Text = "Proveedor: " + b.NombreSeleccionado;
                    CargarFacturasPendientes(idProv);
                }
            }
        }

        private void CargarFacturasPendientes(int id)
        {
            dgvFacturas.Rows.Clear();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    // Buscamos facturas que no estén pagadas (SCRUM-14)
                    string sql = @"SELECT id_factura, nro_factura, fecha_emision, fecha_vencimiento, total 
                                   FROM factura_compra 
                                   WHERE id_proveedor = @id AND estado != 'Pagada'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dgvFacturas.Rows.Add(false, dr["id_factura"], dr["nro_factura"],
                                           Convert.ToDateTime(dr["fecha_emision"]).ToShortDateString(),
                                           Convert.ToDateTime(dr["fecha_vencimiento"]).ToShortDateString(),
                                           dr["total"]);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar facturas: " + ex.Message); }
        }

        // --- REGISTRO DEL PAGO ---
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (idProv == -1) { MessageBox.Show("Seleccione un proveedor."); return; }
            if (!decimal.TryParse(txtMontoAPagar.Text, out decimal montoPagado) || montoPagado <= 0)
            {
                MessageBox.Show("Monto de pago inválido."); return;
            }

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlTransaction tra = con.BeginTransaction();
                try
                {
                    // 1. Validar Monto vs Selección (Criterio SCRUM)
                    decimal totalSeleccionado = 0;
                    foreach (DataGridViewRow r in dgvFacturas.Rows)
                    {
                        if (Convert.ToBoolean(r.Cells["Seleccionar"].Value))
                            totalSeleccionado += Convert.ToDecimal(r.Cells["MontoPendiente"].Value);
                    }

                    if (montoPagado > totalSeleccionado)
                        throw new Exception($"El monto a pagar no puede superar el total de facturas seleccionadas (${totalSeleccionado}).");

                    // 2. Insertar Pago Maestro
                    string sqlPago = @"INSERT INTO pago_proveedor (id_proveedor, fecha_pago, monto_total, medio_pago) 
                                      VALUES (@idp, @fec, @mon, @med); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdP = new SqlCommand(sqlPago, con, tra);
                    cmdP.Parameters.AddWithValue("@idp", idProv);
                    cmdP.Parameters.AddWithValue("@fec", dtpFechaPago.Value);
                    cmdP.Parameters.AddWithValue("@mon", montoPagado);
                    cmdP.Parameters.AddWithValue("@med", cmbMedioPago.Text);
                    int idPago = Convert.ToInt32(cmdP.ExecuteScalar());

                    // 3. Aplicar detalle y actualizar facturas
                    foreach (DataGridViewRow row in dgvFacturas.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                        {
                            int idFactura = Convert.ToInt32(row.Cells["IdFactura"].Value);
                            decimal importe = Convert.ToDecimal(row.Cells["MontoPendiente"].Value);

                            // Registrar Detalle del pago
                            SqlCommand cmdD = new SqlCommand("INSERT INTO pago_proveedor_detalle (id_pago, id_factura_compra, monto_aplicado) VALUES (@idp, @idf, @mon)", con, tra);
                            cmdD.Parameters.AddWithValue("@idp", idPago);
                            cmdD.Parameters.AddWithValue("@idf", idFactura);
                            cmdD.Parameters.AddWithValue("@mon", importe);
                            cmdD.ExecuteNonQuery();

                            // Actualizar Factura (SCRUM criterio)
                            SqlCommand cmdF = new SqlCommand("UPDATE factura_compra SET estado = 'Pagada' WHERE id_factura = @idf", con, tra);
                            cmdF.Parameters.AddWithValue("@idf", idFactura);
                            cmdF.ExecuteNonQuery();
                        }
                    }

                    tra.Commit();
                    MessageBox.Show("Pago registrado correctamente.");
                    GenerarReciboPDF(idPago, montoPagado);
                    this.Close();
                }
                catch (Exception ex)
                {
                    tra.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // --- GENERACIÓN DEL RECIBO PDF ---
        private void GenerarReciboPDF(int id, decimal monto)
        {
            string carpeta = Path.Combine(Application.StartupPath, "Recibos");
            if (!Directory.Exists(carpeta)) Directory.CreateDirectory(carpeta);
            string ruta = Path.Combine(carpeta, $"Recibo_SurFe_{id}.pdf");

            try
            {
                Document doc = new Document(PageSize.A4, 30, 30, 30, 30);
                PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
                doc.Open();

                // Encabezado
                doc.Add(new Paragraph("SURFE SOFTWARE - RECIBO DE PAGO", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18)));
                doc.Add(new Paragraph($"Número de Pago: #PAG-{id}"));
                doc.Add(new Paragraph($"Fecha de Operación: {dtpFechaPago.Value:dd/MM/yyyy}"));
                doc.Add(new Paragraph($"Proveedor: {lblProveedor.Text}"));
                doc.Add(new Paragraph("-----------------------------------------------------------------------"));

                doc.Add(new Paragraph($"\nMONTO TOTAL ABONADO: $ {monto:N2}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14)));
                doc.Add(new Paragraph($"MEDIO DE PAGO: {cmbMedioPago.Text}\n\n"));

                // Tabla de facturas saldadas
                PdfPTable table = new PdfPTable(3);
                table.WidthPercentage = 100;
                table.AddCell(new PdfPCell(new Phrase("Nro Factura", FontFactory.GetFont(FontFactory.HELVETICA_BOLD))) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Fecha Emisión", FontFactory.GetFont(FontFactory.HELVETICA_BOLD))) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Monto Cancelado", FontFactory.GetFont(FontFactory.HELVETICA_BOLD))) { BackgroundColor = BaseColor.LIGHT_GRAY });

                foreach (DataGridViewRow r in dgvFacturas.Rows)
                {
                    if (Convert.ToBoolean(r.Cells["Seleccionar"].Value))
                    {
                        table.AddCell(r.Cells["NroFactura"].Value.ToString());
                        table.AddCell(r.Cells["FechaEmision"].Value.ToString());
                        table.AddCell("$ " + r.Cells["MontoPendiente"].Value.ToString());
                    }
                }
                doc.Add(table);

                doc.Add(new Paragraph("\n\n\n\n__________________________\nFirma y Sello Administración"));
                doc.Close();

                // Mostrar en tu visor
                new PDFView(ruta).ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show("Error PDF: " + ex.Message); }
        }
        // Este método recorre la grilla y suma lo que esté tildado
        private void CalcularTotalSeleccionado()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvFacturas.Rows)
            {
                // Verificamos si la celda de selección es true
                bool isSelected = row.Cells["Seleccionar"].Value != null && (bool)row.Cells["Seleccionar"].Value;

                if (isSelected)
                {
                    total += Convert.ToDecimal(row.Cells["MontoPendiente"].Value);
                }
            }

            // Lo mostramos en el TextBox del monto a pagar
            txtMontoAPagar.Text = total.ToString("N2");
        }

        // Este evento es clave para que el cambio sea "en vivo"
        private void dgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Si el usuario hizo clic en la columna del CheckBox
            if (e.ColumnIndex == dgvFacturas.Columns["Seleccionar"].Index && e.RowIndex >= 0)
            {
                // Forzamos el fin de la edición para que el valor cambie YA
                dgvFacturas.EndEdit();
                CalcularTotalSeleccionado();
            }
        }
    }
}