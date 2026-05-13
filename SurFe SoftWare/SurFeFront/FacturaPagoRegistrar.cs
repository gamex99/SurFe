using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace SurFeFront
{
    public partial class FacturaPagoRegistrar : Form
    {
        // ─── Estado interno ──────────────────────────────────────────────
        private readonly string _conString;
        private int _idFactura;
        private int _idProveedor;
        private decimal _montoFactura;

        // Constructor con factura preseleccionada (desde "Guardar y Pagar")
        public FacturaPagoRegistrar(int idFactura, string nombreProveedor)
        {
            InitializeComponent();
            _conString = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            _idFactura = idFactura;

            ConfigurarMediosPago();
            btnBuscarFactura.Visible = false; // Ya viene con factura, no necesita buscar
            CargarDatosFactura(nombreProveedor);
        }

        // Constructor sin factura (apertura independiente desde menú)
        public FacturaPagoRegistrar()
        {
            InitializeComponent();
            _conString = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            _idFactura = -1;

            ConfigurarMediosPago();
            DeshabilitarCampos();
        }

        private void ConfigurarMediosPago()
        {
            cmbMedioPago.Items.AddRange(new string[]
            {
                "Transferencia", "Cheque", "Efectivo", "Tarjeta de crédito", "Débito automático"
            });
            cmbMedioPago.SelectedIndex = 0;
        }

        private void DeshabilitarCampos()
        {
            dtpFechaPago.Enabled = false;
            txtMonto.Enabled = false;
            cmbMedioPago.Enabled = false;
            txtObservaciones.Enabled = false;
            btnConfirmar.Enabled = false;
        }

        private void HabilitarCampos()
        {
            dtpFechaPago.Enabled = true;
            txtMonto.Enabled = true;
            cmbMedioPago.Enabled = true;
            txtObservaciones.Enabled = true;
            btnConfirmar.Enabled = true;
        }

        // ─── BÚSQUEDA DE FACTURA ─────────────────────────────────────────

        private void btnBuscarFactura_Click(object sender, EventArgs e)
        {
            using (var dialogo = new BusquedaFacturaPendiente())
            {
                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    _idFactura = dialogo.IdFacturaSeleccionada;
                    CargarDatosFactura(dialogo.NombreProveedor);
                    HabilitarCampos();
                }
            }
        }

        // ─── CARGA DATOS DE LA FACTURA ───────────────────────────────────

        private void CargarDatosFactura(string nombreProveedor)
        {
            const string sql = @"
                SELECT id_proveedor, nro_factura, tipo_comprobante, monto_total
                FROM factura_compra
                WHERE id_factura = @idf";

            using (var con = new SqlConnection(_conString))
            {
                con.Open();
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@idf", _idFactura);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            _idProveedor = Convert.ToInt32(reader["id_proveedor"]);
                            _montoFactura = Convert.ToDecimal(reader["monto_total"]);

                            lblProveedor.Text = nombreProveedor;
                            lblFactura.Text = $"{reader["tipo_comprobante"]} — {reader["nro_factura"]}";
                            lblMonto.Text = $"$ {_montoFactura:N2}";

                            // Precarga el monto a pagar con el total de la factura
                            txtMonto.Text = _montoFactura.ToString("F2");
                        }
                    }
                }
            }
        }

        // ─── SOLO NÚMEROS Y COMA EN MONTO ───────────────────────────────

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        // ─── CONFIRMAR PAGO ──────────────────────────────────────────────

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario(out decimal monto)) return;

            using (var con = new SqlConnection(_conString))
            {
                con.Open();
                var tra = con.BeginTransaction();
                try
                {
                    int idPago = RegistrarPago(con, tra, monto);
                    ActualizarEstadoFactura(con, tra, monto);
                    ActualizarCuentaCorriente(con, tra, monto);
                    tra.Commit();

                    MessageBox.Show(
                        $"Pago de $ {monto:N2} registrado correctamente.",
                        "SurFe",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    GenerarYMostrarRecibo(idPago, monto);
                    this.Close();
                }
                catch (Exception ex)
                {
                    tra.Rollback();
                    MessageBox.Show(
                        $"Error al registrar el pago:\n{ex.Message}",
                        "SurFe — Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        // ─── VALIDACIONES ────────────────────────────────────────────────

        private bool ValidarFormulario(out decimal monto)
        {
            monto = 0;

            if (string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                MessageBox.Show("Ingrese el monto a pagar.", "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtMonto.Text.Replace(",", "."),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out monto) || monto <= 0)
            {
                MessageBox.Show("El monto ingresado no es válido.", "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (monto > _montoFactura)
            {
                var confirmar = MessageBox.Show(
                    $"El monto ingresado ($ {monto:N2}) supera el total de la factura ($ {_montoFactura:N2}).\n¿Desea continuar?",
                    "SurFe — Advertencia",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmar == DialogResult.No) return false;
            }

            if (dtpFechaPago.Value.Date > DateTime.Today)
            {
                MessageBox.Show("La fecha de pago no puede ser futura.", "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // ─── OPERACIONES EN BD ───────────────────────────────────────────

        private int RegistrarPago(SqlConnection con, SqlTransaction tra, decimal monto)
        {
            const string sql = @"
                INSERT INTO pago_proveedor 
                    (id_factura, id_proveedor, fecha_pago, monto_total, medio_pago, observaciones)
                VALUES 
                    (@idf, @idp, @fecha, @monto, @medio, @obs);
                SELECT SCOPE_IDENTITY();";

            using (var cmd = new SqlCommand(sql, con, tra))
            {
                cmd.Parameters.AddWithValue("@idf", _idFactura);
                cmd.Parameters.AddWithValue("@idp", _idProveedor);
                cmd.Parameters.AddWithValue("@fecha", dtpFechaPago.Value.Date);
                cmd.Parameters.AddWithValue("@monto", monto);
                cmd.Parameters.AddWithValue("@medio", cmbMedioPago.Text);
                cmd.Parameters.AddWithValue("@obs", string.IsNullOrWhiteSpace(txtObservaciones.Text)
                                                        ? (object)DBNull.Value
                                                        : txtObservaciones.Text.Trim());
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void ActualizarEstadoFactura(SqlConnection con, SqlTransaction tra, decimal monto)
        {
            // Si el pago cubre el total, marca la factura como Pagada; si es parcial, En proceso
            string nuevoEstado = monto >= _montoFactura ? "Pagada" : "Pago parcial";

            const string sql = @"
                UPDATE factura_compra 
                SET estado_pago = @estado
                WHERE id_factura = @idf";

            using (var cmd = new SqlCommand(sql, con, tra))
            {
                cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                cmd.Parameters.AddWithValue("@idf", _idFactura);
                cmd.ExecuteNonQuery();
            }
        }

        private void ActualizarCuentaCorriente(SqlConnection con, SqlTransaction tra, decimal monto)
        {
            const string sql = @"
                INSERT INTO cuenta_corriente_proveedor (id_proveedor, id_factura, haber)
                VALUES (@idp, @idf, @monto)";

            using (var cmd = new SqlCommand(sql, con, tra))
            {
                cmd.Parameters.AddWithValue("@idp", _idProveedor);
                cmd.Parameters.AddWithValue("@idf", _idFactura);
                cmd.Parameters.AddWithValue("@monto", monto);
                cmd.ExecuteNonQuery();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();

        // ─── GENERACIÓN DE RECIBO PDF ────────────────────────────────────

        private void GenerarYMostrarRecibo(int idPago, decimal monto)
        {
            string ruta = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                $"Recibo_{idPago}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

            try
            {
                string observ = string.IsNullOrWhiteSpace(txtObservaciones.Text)
                    ? "—"
                    : txtObservaciones.Text.Trim();

                string html = $@"
                <html>
                <body style='font-family: Arial, sans-serif;'>
                    <div style='text-align: center; border-bottom: 2px solid #007ACC; padding-bottom: 10px;'>
                        <h1 style='color: #007ACC; margin: 0;'>SurFe — RECIBO DE PAGO</h1>
                        <p style='margin: 5px 0;'><b>Recibo N°:</b> {idPago} &nbsp;|&nbsp; <b>Fecha:</b> {dtpFechaPago.Value:dd/MM/yyyy}</p>
                    </div>
                    <div style='margin: 30px 0;'>
                        <table style='width: 100%; border-collapse: collapse;'>
                            <tr>
                                <td style='padding: 8px; width: 40%; font-weight: bold;'>Proveedor:</td>
                                <td style='padding: 8px;'>{lblProveedor.Text}</td>
                            </tr>
                            <tr style='background-color: #f5f5f5;'>
                                <td style='padding: 8px; font-weight: bold;'>Factura:</td>
                                <td style='padding: 8px;'>{lblFactura.Text}</td>
                            </tr>
                            <tr>
                                <td style='padding: 8px; font-weight: bold;'>Medio de pago:</td>
                                <td style='padding: 8px;'>{cmbMedioPago.Text}</td>
                            </tr>
                            <tr style='background-color: #f5f5f5;'>
                                <td style='padding: 8px; font-weight: bold;'>Observaciones:</td>
                                <td style='padding: 8px;'>{observ}</td>
                            </tr>
                        </table>
                    </div>
                    <div style='margin: 40px 0; padding: 20px; background-color: #e6f2ff; border: 2px solid #007ACC; text-align: center;'>
                        <p style='margin: 0; font-size: 14px;'>MONTO TOTAL PAGADO</p>
                        <p style='margin: 10px 0 0 0; font-size: 28px; font-weight: bold; color: #007ACC;'>$ {monto:N2}</p>
                    </div>
                    <div style='margin-top: 60px; border-top: 1px solid #ddd; padding-top: 20px;'>
                        <p style='font-size: 11px; color: #666;'>
                            Este comprobante certifica el pago realizado en la fecha indicada.<br/>
                            Para cualquier consulta, conserve este recibo como constancia.
                        </p>
                    </div>
                    <div style='margin-top: 80px;'>
                        <p>Firma autorizada: _______________________________</p>
                    </div>
                </body>
                </html>";

                using (var stream = new FileStream(ruta, FileMode.Create))
                {
                    var doc = new Document(PageSize.A4, 40, 40, 40, 40);
                    var writer = PdfWriter.GetInstance(doc, stream);
                    doc.Open();
                    using (var sr = new StringReader(html))
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, sr);
                    doc.Close();
                }

                new PDFView(ruta).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al generar el recibo:\n{ex.Message}",
                    "SurFe — Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}