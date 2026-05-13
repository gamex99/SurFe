using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SurFeFront
{
    public partial class FacturaCompraRegistrar : Form
    {
        // ─── Estado interno ──────────────────────────────────────────────
        private readonly string _conString = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
        private int _idProveedor = -1;
        private List<int> _idsOC = new List<int>();

        public FacturaCompraRegistrar()
        {
            InitializeComponent();
            cmbTipo.Items.AddRange(new string[] { "Factura A", "Factura B", "Factura C" });
            cmbTipo.SelectedIndex = 0;
        }

        // ─── BUSCAR PROVEEDOR ────────────────────────────────────────────

        private void btnBuscarProv_Click(object sender, EventArgs e)
        {
            using (var dialogo = new BusquedaProveedor())
            {
                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    _idProveedor = dialogo.IdSeleccionado;
                    lblProvSel.Text = dialogo.NombreSeleccionado;
                    lblProvSel.ForeColor = System.Drawing.Color.Black;
                    btnAsociarOC.Enabled = true;
                    gridOCs.Rows.Clear();
                    _idsOC.Clear();
                }
            }
        }

        // ─── ASOCIAR OC ─────────────────────────────────────────────────

        private void btnAsociarOC_Click(object sender, EventArgs e)
        {
            using (var dialogo = new BusquedaOCProveedor(_idProveedor))
            {
                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    if (_idsOC.Contains(dialogo.IdPedidoSeleccionado))
                    {
                        MessageBox.Show(
                            "Esa orden de compra ya fue asociada.",
                            "SurFe",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    _idsOC.Add(dialogo.IdPedidoSeleccionado);
                    gridOCs.Rows.Add(
                        dialogo.IdPedidoSeleccionado,
                        dialogo.FechaPedido.ToShortDateString(),
                        dialogo.TotalEstimado.ToString("N2"));
                }
            }
        }

        // ─── QUITAR OC DE LA GRILLA ──────────────────────────────────────

        private void gridOCs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != gridOCs.Columns["colOCEliminar"].Index)
                return;

            var confirmacion = MessageBox.Show(
                "¿Desea quitar esta orden de compra de la factura?",
                "SurFe",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                int idOC = Convert.ToInt32(gridOCs.Rows[e.RowIndex].Cells["colOCId"].Value);
                _idsOC.Remove(idOC);
                gridOCs.Rows.RemoveAt(e.RowIndex);
            }
        }

        // ─── SOLO NÚMEROS Y COMA EN MONTO ───────────────────────────────

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        // ─── GUARDAR ────────────────────────────────────────────────────

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int idFactura = GuardarFactura();
            if (idFactura == -1) return;

            MessageBox.Show(
                "Factura registrada correctamente.",
                "SurFe",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            this.Close();
        }

        private void btnGuardarYPagar_Click(object sender, EventArgs e)
        {
            int idFactura = GuardarFactura();
            if (idFactura == -1) return;

            // Abre directamente la ventana de pago pasando el id de factura
            var ventanaPago = new FacturaPagoRegistrar(idFactura, lblProvSel.Text);
            ventanaPago.ShowDialog();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();

        // ─── LÓGICA CENTRAL DE GUARDADO ──────────────────────────────────

        private int GuardarFactura()
        {
            if (!ValidarFormulario()) return -1;

            if (!decimal.TryParse(txtTotal.Text.Replace(",", "."), System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out decimal total))
            {
                MessageBox.Show("El monto ingresado no es válido.", "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }

            using (var con = new SqlConnection(_conString))
            {
                con.Open();

                if (FacturaDuplicada(con))
                {
                    MessageBox.Show(
                        "Ya existe una factura con ese número para este proveedor.",
                        "SurFe",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return -1;
                }

                var tra = con.BeginTransaction();
                try
                {
                    int idFactura = InsertarFactura(con, tra, total);
                    AsociarOCs(con, tra, idFactura);
                    InsertarEnCuentaCorriente(con, tra, idFactura, total);
                    tra.Commit();
                    return idFactura;
                }
                catch (Exception ex)
                {
                    tra.Rollback();
                    MessageBox.Show(
                        $"Error al registrar la factura:\n{ex.Message}",
                        "SurFe — Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return -1;
                }
            }
        }

        private bool ValidarFormulario()
        {
            if (_idProveedor == -1)
            {
                MessageBox.Show("Seleccione un proveedor.", "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNroFactura.Text))
            {
                MessageBox.Show("Ingrese el número de factura.", "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTotal.Text))
            {
                MessageBox.Show("Ingrese el monto total.", "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dtpVencimiento.Value < dtpEmision.Value)
            {
                MessageBox.Show("La fecha de vencimiento no puede ser anterior a la de emisión.", "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool FacturaDuplicada(SqlConnection con)
        {
            const string sql = @"SELECT COUNT(*) FROM factura_compra 
                                 WHERE nro_factura = @nro AND id_proveedor = @idp";
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@nro", txtNroFactura.Text.Trim());
                cmd.Parameters.AddWithValue("@idp", _idProveedor);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private int InsertarFactura(SqlConnection con, SqlTransaction tra, decimal total)
        {
            const string sql = @"
                INSERT INTO factura_compra 
                    (id_proveedor, tipo_comprobante, nro_factura, fecha_emision, fecha_vencimiento, monto_total, estado_pago)
                VALUES 
                    (@idp, @tipo, @nro, @fecE, @fecV, @total, 'Pendiente');
                SELECT SCOPE_IDENTITY();";

            using (var cmd = new SqlCommand(sql, con, tra))
            {
                cmd.Parameters.AddWithValue("@idp", _idProveedor);
                cmd.Parameters.AddWithValue("@tipo", cmbTipo.Text);
                cmd.Parameters.AddWithValue("@nro", txtNroFactura.Text.Trim());
                cmd.Parameters.AddWithValue("@fecE", dtpEmision.Value.Date);
                cmd.Parameters.AddWithValue("@fecV", dtpVencimiento.Value.Date);
                cmd.Parameters.AddWithValue("@total", total);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void AsociarOCs(SqlConnection con, SqlTransaction tra, int idFactura)
        {
            const string sql = @"
                INSERT INTO factura_pedido_asociacion (id_factura, id_pedido)
                VALUES (@idf, @idp);
                UPDATE pedido_proveedor SET estado = 'Enviado' WHERE id_pedido = @idp;";

            foreach (int idOC in _idsOC)
            {
                using (var cmd = new SqlCommand(sql, con, tra))
                {
                    cmd.Parameters.AddWithValue("@idf", idFactura);
                    cmd.Parameters.AddWithValue("@idp", idOC);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void InsertarEnCuentaCorriente(SqlConnection con, SqlTransaction tra, int idFactura, decimal total)
        {
            const string sql = @"
                INSERT INTO cuenta_corriente_proveedor (id_proveedor, id_factura, debe)
                VALUES (@idp, @idf, @total)";

            using (var cmd = new SqlCommand(sql, con, tra))
            {
                cmd.Parameters.AddWithValue("@idp", _idProveedor);
                cmd.Parameters.AddWithValue("@idf", idFactura);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.ExecuteNonQuery();
            }
        }
    }
}