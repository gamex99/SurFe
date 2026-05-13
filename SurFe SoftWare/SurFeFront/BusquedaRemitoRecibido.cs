using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SurFeFront
{
    public partial class BusquedaRemitoRecibido : Form
    {
        // ─── Propiedades que devuelve al padre ───────────────────────────
        public int IdRemitoSeleccionado { get; private set; } = -1;
        public int IdProveedor { get; private set; }
        public string NroRemito { get; private set; }
        public string NombreProveedor { get; private set; }

        // Cuando el usuario elige "Producto manual" sin remito
        public bool EsProductoManual { get; private set; } = false;

        // ─── Estado interno ──────────────────────────────────────────────
        private readonly string _conString = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

        // Todas las filas cargadas — para filtrar sin ir a la BD
        private List<object[]> _todosLosRemitos = new List<object[]>();

        public BusquedaRemitoRecibido()
        {
            InitializeComponent();
            CargarRemitos();
        }

        // ─── CARGA DE DATOS ──────────────────────────────────────────────

        private void CargarRemitos()
        {
            _todosLosRemitos.Clear();
            gridRemitos.Rows.Clear();

            // Trae remitos con cantidad de productos con diferencia
            const string sql = @"
                SELECT 
                    r.id_remito,
                    r.id_proveedor,
                    p.razon_social          AS proveedor,
                    r.nro_remito,
                    r.fecha_entrada,
                    r.estado,
                    (
                        SELECT COUNT(*)
                        FROM remito_entrada_detalle d
                        INNER JOIN pedido_proveedor_detalle od 
                            ON od.id_producto = d.id_producto
                            AND od.id_pedido  = r.id_pedido
                        WHERE d.id_remito = r.id_remito
                          AND d.cantidad_recibida <> od.cantidad
                    ) AS cant_diferencias
                FROM remito_entrada r
                INNER JOIN proveedor p ON r.id_proveedor = p.id
                ORDER BY r.fecha_entrada DESC";

            using (var con = new SqlConnection(_conString))
            {
                con.Open();
                using (var cmd = new SqlCommand(sql, con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idRemito = Convert.ToInt32(reader["id_remito"]);
                        int idProv = Convert.ToInt32(reader["id_proveedor"]);
                        string proveedor = reader["proveedor"].ToString();
                        string nroRemito = reader["nro_remito"].ToString();
                        string fecha = Convert.ToDateTime(reader["fecha_entrada"]).ToShortDateString();
                        string estado = reader["estado"].ToString();
                        int diferencias = Convert.ToInt32(reader["cant_diferencias"]);
                        string difTexto = diferencias > 0 ? $"⚠ {diferencias}" : "OK";

                        _todosLosRemitos.Add(new object[]
                        {
                            idRemito, idProv, proveedor, nroRemito, fecha, estado, diferencias, difTexto
                        });
                    }
                }
            }

            AplicarFiltros();
        }

        // ─── FILTROS ─────────────────────────────────────────────────────

        private void AplicarFiltros()
        {
            gridRemitos.Rows.Clear();

            string busqueda = txtBuscar.Text.Trim().ToLower();
            bool soloDiff = chkSoloDiferencias.Checked;

            foreach (var fila in _todosLosRemitos)
            {
                string proveedor = fila[2].ToString().ToLower();
                string nroRemito = fila[3].ToString().ToLower();
                int diferencias = Convert.ToInt32(fila[6]);

                // Filtro texto
                if (!string.IsNullOrEmpty(busqueda) &&
                    !proveedor.Contains(busqueda) &&
                    !nroRemito.Contains(busqueda))
                    continue;

                // Filtro solo diferencias
                if (soloDiff && diferencias == 0)
                    continue;

                int idx = gridRemitos.Rows.Add(
                    fila[0],   // id_remito
                    fila[2],   // proveedor
                    fila[3],   // nro_remito
                    fila[4],   // fecha
                    fila[5],   // estado
                    fila[7]);  // difTexto

                // Colorear filas con diferencias
                if (diferencias > 0)
                    gridRemitos.Rows[idx].DefaultCellStyle.BackColor = Color.FromArgb(255, 240, 200);
            }

            if (gridRemitos.Rows.Count == 0)
                lblSubtitulo.Text = "No se encontraron remitos con los filtros aplicados.";
            else
                lblSubtitulo.Text = "Seleccione el remito sobre el cual desea registrar el reclamo.";
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e) => AplicarFiltros();

        private void chkSoloDiferencias_CheckedChanged(object sender, EventArgs e) => AplicarFiltros();

        // ─── SELECCIÓN ───────────────────────────────────────────────────

        private void btnSeleccionar_Click(object sender, EventArgs e) => Seleccionar();

        private void gridRemitos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) Seleccionar();
        }

        private void Seleccionar()
        {
            if (gridRemitos.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione un remito de la lista.",
                    "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fila = gridRemitos.CurrentRow;
            IdRemitoSeleccionado = Convert.ToInt32(fila.Cells["colId"].Value);
            NroRemito = fila.Cells["colNroRemito"].Value.ToString();
            NombreProveedor = fila.Cells["colProveedor"].Value.ToString();

            // Obtener id_proveedor desde la BD
            using (var con = new SqlConnection(_conString))
            {
                con.Open();
                using (var cmd = new SqlCommand("SELECT id_proveedor FROM remito_entrada WHERE id_remito = @idr", con))
                {
                    cmd.Parameters.AddWithValue("@idr", IdRemitoSeleccionado);
                    IdProveedor = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            EsProductoManual = false;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        // ─── PRODUCTO MANUAL ─────────────────────────────────────────────

        private void btnProductoManual_Click(object sender, EventArgs e)
        {
            EsProductoManual = true;
            IdRemitoSeleccionado = -1;
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