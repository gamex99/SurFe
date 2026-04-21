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
        string conString = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
        int idProv = -1;

        public ProveedorRegistrarPago()
        {
            InitializeComponent();
            ConfigurarGridFacturas();

            cmbMedioPago.Items.Clear();
            cmbMedioPago.Items.Add("Efectivo");
            cmbMedioPago.Items.Add("Transferencia Bancaria");
            cmbMedioPago.Items.Add("Cheque");
            cmbMedioPago.Items.Add("Mercado Pago");
            cmbMedioPago.SelectedIndex = 0;

            dtpFechaPago.Value = DateTime.Now;
            lblProveedor.Text = "Proveedor: Seleccione uno...";
        }

        private void ConfigurarGridFacturas()
        {
            dgvFacturas.Columns.Clear();
            dgvFacturas.AutoGenerateColumns = false;

            DataGridViewCheckBoxColumn colCheck = new DataGridViewCheckBoxColumn();
            colCheck.Name = "Seleccionar";
            colCheck.HeaderText = "Pagar";
            colCheck.Width = 50;
            dgvFacturas.Columns.Add(colCheck);

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
                    // CORRECCIÓN: Usamos monto_total y estado_pago (nombres reales en tu DB)
                    string sql = @"SELECT id_factura, nro_factura, fecha_emision, fecha_vencimiento, monto_total 
                                   FROM factura_compra 
                                   WHERE id_proveedor = @id AND estado_pago != 'Pagada'";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dgvFacturas.Rows.Add(false, dr["id_factura"], dr["nro_factura"],
                                           Convert.ToDateTime(dr["fecha_emision"]).ToShortDateString(),
                                           Convert.ToDateTime(dr["fecha_vencimiento"]).ToShortDateString(),
                                           dr["monto_total"]);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar facturas: " + ex.Message); }
        }

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
                    // 1. Insertar Pago Maestro (Opcional, para tener historial de pagos)
                    // Si no tienes la tabla pago_proveedor creada, este bloque fallará. 
                    // Pero lo más importante es el UPDATE y la CC.

                    // 2. Procesar facturas seleccionadas
                    foreach (DataGridViewRow row in dgvFacturas.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                        {
                            int idFactura = Convert.ToInt32(row.Cells["IdFactura"].Value);
                            decimal importe = Convert.ToDecimal(row.Cells["MontoPendiente"].Value);

                            // Actualizar Factura a PAGADA
                            SqlCommand cmdF = new SqlCommand("UPDATE factura_compra SET estado_pago = 'Pagada' WHERE id_factura = @idf", con, tra);
                            cmdF.Parameters.AddWithValue("@idf", idFactura);
                            cmdF.ExecuteNonQuery();

                            // ASENTAR EN CUENTA CORRIENTE (HABER) para bajar la deuda
                            string sqlCC = @"INSERT INTO cuenta_corriente_proveedor (id_proveedor, id_factura, debe, haber, fecha_mov) 
                                             VALUES (@idp, @idf, 0, @monto, GETDATE())";
                            SqlCommand cmdCC = new SqlCommand(sqlCC, con, tra);
                            cmdCC.Parameters.AddWithValue("@idp", idProv);
                            cmdCC.Parameters.AddWithValue("@idf", idFactura);
                            cmdCC.Parameters.AddWithValue("@monto", importe);
                            cmdCC.ExecuteNonQuery();
                        }
                    }

                    tra.Commit();
                    MessageBox.Show("Pago registrado correctamente. La cuenta corriente ha sido actualizada.");

                    // Opcional: Generar Recibo PDF
                    // GenerarReciboPDF(0, montoPagado); 

                    this.Close();
                }
                catch (Exception ex)
                {
                    tra.Rollback();
                    MessageBox.Show("Error al procesar el pago: " + ex.Message);
                }
            }
        }

        private void CalcularTotalSeleccionado()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvFacturas.Rows)
            {
                bool isSelected = row.Cells["Seleccionar"].Value != null && (bool)row.Cells["Seleccionar"].Value;
                if (isSelected)
                {
                    total += Convert.ToDecimal(row.Cells["MontoPendiente"].Value);
                }
            }
            txtMontoAPagar.Text = total.ToString("N2");
        }

        private void dgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvFacturas.Columns["Seleccionar"].Index && e.RowIndex >= 0)
            {
                dgvFacturas.EndEdit();
                CalcularTotalSeleccionado();
            }
        }
    }
}