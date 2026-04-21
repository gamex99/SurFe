using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SurFeFront
{
    public partial class FacturaCompraRegistrar : Form
    {
        string conString = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
        int idProvSel = -1;
        List<int> remitosSeleccionados = new List<int>();

        public FacturaCompraRegistrar()
        {
            InitializeComponent();
            ConfigurarGrillaRemitos();
            cmbTipo.Items.AddRange(new string[] { "Factura A", "Factura B", "Factura C" });
            cmbTipo.SelectedIndex = 0;
        }

        private void ConfigurarGrillaRemitos()
        {
            dgvRemitosAsoc.Columns.Clear();
            dgvRemitosAsoc.Columns.Add("id", "ID");
            dgvRemitosAsoc.Columns.Add("nro", "Nro Remito");
            dgvRemitosAsoc.Columns.Add("fecha", "Fecha");
        }

        private void btnBuscarProv_Click(object sender, EventArgs e)
        {
            using (BusquedaProveedor buscador = new BusquedaProveedor())
            {
                if (buscador.ShowDialog() == DialogResult.OK)
                {
                    idProvSel = buscador.IdProveedor;
                    lblProvSel.Text = $"Prov: {buscador.RazonSocial}";
                    btnAsociarRemito.Enabled = true; // Habilitamos asociar remitos
                }
            }
        }

        private void btnAsociarRemito_Click(object sender, EventArgs e)
        {
            // Este buscador debe filtrar remitos del idProvSel que no estén en otra factura
            using (BusquedaRemitosProv buscador = new BusquedaRemitosProv(idProvSel))
            {
                if (buscador.ShowDialog() == DialogResult.OK)
                {
                    if (!remitosSeleccionados.Contains(buscador.IdRemito))
                    {
                        remitosSeleccionados.Add(buscador.IdRemito);
                        dgvRemitosAsoc.Rows.Add(buscador.IdRemito, buscador.NroRemito, buscador.Fecha.ToShortDateString());
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idProvSel == -1) { MessageBox.Show("Seleccione un proveedor."); return; }
            if (string.IsNullOrWhiteSpace(txtNroFactura.Text)) { MessageBox.Show("Nro Factura obligatorio."); return; }
            if (!decimal.TryParse(txtTotal.Text, out decimal total)) { MessageBox.Show("Monto inválido."); return; }

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                // Validar duplicado
                SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM factura_compra WHERE nro_factura = @nro AND id_proveedor = @idp", con);
                cmdCheck.Parameters.AddWithValue("@nro", txtNroFactura.Text);
                cmdCheck.Parameters.AddWithValue("@idp", idProvSel);
                if ((int)cmdCheck.ExecuteScalar() > 0)
                {
                    MessageBox.Show("Esta factura ya existe para este proveedor."); return;
                }

                SqlTransaction tra = con.BeginTransaction();
                try
                {
                    // 1. Insertar Factura
                    string sqlF = @"INSERT INTO factura_compra (id_proveedor, tipo_comprobante, nro_factura, fecha_emision, fecha_vencimiento, monto_total) 
                                    VALUES (@idp, @tipo, @nro, @fecE, @fecV, @total); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdF = new SqlCommand(sqlF, con, tra);
                    cmdF.Parameters.AddWithValue("@idp", idProvSel);
                    cmdF.Parameters.AddWithValue("@tipo", cmbTipo.Text);
                    cmdF.Parameters.AddWithValue("@nro", txtNroFactura.Text);
                    cmdF.Parameters.AddWithValue("@fecE", dtpEmision.Value);
                    cmdF.Parameters.AddWithValue("@fecV", dtpVencimiento.Value);
                    cmdF.Parameters.AddWithValue("@total", total);
                    int idFactura = Convert.ToInt32(cmdF.ExecuteScalar());

                    // 2. Asociar Remitos
                    foreach (int idRem in remitosSeleccionados)
                    {
                        SqlCommand cmdAsoc = new SqlCommand("INSERT INTO factura_remito_asociacion (id_factura, id_remito) VALUES (@idf, @idr)", con, tra);
                        cmdAsoc.Parameters.AddWithValue("@idf", idFactura);
                        cmdAsoc.Parameters.AddWithValue("@idr", idRem);
                        cmdAsoc.ExecuteNonQuery();
                    }

                    // 3. Cuenta Corriente
                    SqlCommand cmdCC = new SqlCommand("INSERT INTO cuenta_corriente_proveedor (id_proveedor, id_factura, debe) VALUES (@idp, @idf, @total)", con, tra);
                    cmdCC.Parameters.AddWithValue("@idp", idProvSel);
                    cmdCC.Parameters.AddWithValue("@idf", idFactura);
                    cmdCC.Parameters.AddWithValue("@total", total);
                    cmdCC.ExecuteNonQuery();

                    tra.Commit();
                    MessageBox.Show("Factura registrada y asentada en CC.");
                    this.Close();
                }
                catch (Exception ex) { tra.Rollback(); MessageBox.Show(ex.Message); }
            }
        }
    }
}