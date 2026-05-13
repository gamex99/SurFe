using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SurFeFront
{
    public partial class BusquedaOCProveedor : Form
    {
        // ─── Propiedades que devuelve al padre ───────────────────────────
        public int IdPedidoSeleccionado { get; private set; }
        public DateTime FechaPedido { get; private set; }
        public decimal TotalEstimado { get; private set; }

        // ─── Estado interno ──────────────────────────────────────────────
        private readonly string _conString = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
        private readonly int _idProveedor;
        private readonly bool _soloSinFactura;

        // Para FacturaCompraRegistrar — excluye OCs que ya tienen factura
        public BusquedaOCProveedor(int idProveedor) : this(idProveedor, true) { }

        // Para RecepcionMercaderia — muestra todas las OCs del proveedor
        public BusquedaOCProveedor(int idProveedor, bool soloSinFactura)
        {
            InitializeComponent();
            _idProveedor = idProveedor;
            _soloSinFactura = soloSinFactura;
            CargarOCs();
        }

        // ─── CARGA DE DATOS ──────────────────────────────────────────────

        private void CargarOCs()
        {
            gridOCs.Rows.Clear();

            string sql = @"
                SELECT p.id_pedido, p.fecha, p.estado, p.total_estimado
                FROM pedido_proveedor p
                WHERE p.id_proveedor = @idp
                  AND p.estado IN ('Pendiente', 'Enviado')";

            if (_soloSinFactura)
                sql += @" AND NOT EXISTS (
                      SELECT 1 FROM factura_pedido_asociacion fpa
                      WHERE fpa.id_pedido = p.id_pedido
                  )";

            sql += " ORDER BY p.fecha DESC";

            using (var con = new SqlConnection(_conString))
            {
                con.Open();
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@idp", _idProveedor);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            gridOCs.Rows.Add(
                                reader["id_pedido"],
                                Convert.ToDateTime(reader["fecha"]).ToShortDateString(),
                                reader["estado"],
                                reader["total_estimado"] == DBNull.Value
                                    ? "—"
                                    : Convert.ToDecimal(reader["total_estimado"]).ToString("N2"));
                        }
                    }
                }
            }

            if (gridOCs.Rows.Count == 0)
                lblSubtitulo.Text = "Este proveedor no tiene órdenes de compra disponibles para asociar.";
        }

        // ─── SELECCIÓN ───────────────────────────────────────────────────

        private void btnSeleccionar_Click(object sender, EventArgs e) => Seleccionar();

        private void gridOCs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) Seleccionar();
        }

        private void Seleccionar()
        {
            if (gridOCs.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione una orden de compra de la lista.",
                    "SurFe",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var fila = gridOCs.CurrentRow;
            IdPedidoSeleccionado = Convert.ToInt32(fila.Cells["colId"].Value);
            FechaPedido = Convert.ToDateTime(fila.Cells["colFecha"].Value);

            string totalStr = fila.Cells["colTotal"].Value?.ToString();
            TotalEstimado = (totalStr == "—" || string.IsNullOrEmpty(totalStr))
                ? 0
                : Convert.ToDecimal(totalStr.Replace(".", "").Replace(",", "."),
                    System.Globalization.CultureInfo.InvariantCulture);

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
