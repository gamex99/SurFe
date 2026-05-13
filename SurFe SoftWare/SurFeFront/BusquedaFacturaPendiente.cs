using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SurFeFront
{
    public partial class BusquedaFacturaPendiente : Form
    {
        // ─── Propiedades que devuelve al padre ───────────────────────────
        public int IdFacturaSeleccionada { get; private set; }
        public string NombreProveedor { get; private set; }

        // ─── Estado interno ──────────────────────────────────────────────
        private readonly string _conString = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

        public BusquedaFacturaPendiente()
        {
            InitializeComponent();
            CargarFacturas();
        }

        // ─── CARGA DE DATOS ──────────────────────────────────────────────

        private void CargarFacturas()
        {
            gridFacturas.Rows.Clear();

            // Trae facturas con estado_pago = Pendiente o Pago parcial
            const string sql = @"
                SELECT 
                    f.id_factura,
                    p.razon_social AS proveedor,
                    f.tipo_comprobante + ' - ' + f.nro_factura AS nro_factura,
                    f.fecha_emision,
                    f.monto_total,
                    f.estado_pago
                FROM factura_compra f
                INNER JOIN proveedor p ON f.id_proveedor = p.id
                WHERE f.estado_pago IN ('Pendiente', 'Pago parcial')
                ORDER BY f.fecha_emision DESC";

            using (var con = new SqlConnection(_conString))
            {
                con.Open();
                using (var cmd = new SqlCommand(sql, con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        gridFacturas.Rows.Add(
                            reader["id_factura"],
                            reader["proveedor"],
                            reader["nro_factura"],
                            Convert.ToDateTime(reader["fecha_emision"]).ToShortDateString(),
                            Convert.ToDecimal(reader["monto_total"]).ToString("N2"),
                            reader["estado_pago"]);
                    }
                }
            }

            if (gridFacturas.Rows.Count == 0)
                lblSubtitulo.Text = "No hay facturas pendientes de pago.";
        }

        // ─── SELECCIÓN ───────────────────────────────────────────────────

        private void btnSeleccionar_Click(object sender, EventArgs e) => Seleccionar();

        private void gridFacturas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) Seleccionar();
        }

        private void Seleccionar()
        {
            if (gridFacturas.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione una factura de la lista.",
                    "SurFe",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var fila = gridFacturas.CurrentRow;
            IdFacturaSeleccionada = Convert.ToInt32(fila.Cells["colId"].Value);
            NombreProveedor = fila.Cells["colProveedor"].Value.ToString();

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}