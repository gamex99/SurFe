using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace SurFeFront
{
    public partial class RecepcionMercaderia : Form
    {
        // ─── Estado interno ──────────────────────────────────────────────
        private readonly string _conString = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
        private int _idProveedor = -1;
        private List<int> _idsOC = new List<int>();

        public RecepcionMercaderia()
        {
            InitializeComponent();
        }

        // ─── BUSCAR PROVEEDOR ────────────────────────────────────────────

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            using (var dialogo = new BusquedaProveedor())
            {
                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    _idProveedor = dialogo.IdSeleccionado;
                    lblProveedor.Text = dialogo.NombreSeleccionado;
                    lblProveedor.ForeColor = Color.Black;
                    btnAsociarOC.Enabled = true;
                    gridOCs.Rows.Clear();
                    gridProductos.Rows.Clear();
                    _idsOC.Clear();
                    ActualizarResumen();
                }
            }
        }

        // ─── ASOCIAR OC ─────────────────────────────────────────────────

        private void btnAsociarOC_Click(object sender, EventArgs e)
        {
            using (var dialogo = new BusquedaOCProveedor(_idProveedor, false))
            {
                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    if (_idsOC.Contains(dialogo.IdPedidoSeleccionado))
                    {
                        MessageBox.Show("Esa orden de compra ya fue asociada.", "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    _idsOC.Add(dialogo.IdPedidoSeleccionado);
                    gridOCs.Rows.Add(
                        dialogo.IdPedidoSeleccionado,
                        dialogo.FechaPedido.ToShortDateString(),
                        "Enviado");

                    CargarProductosDeOC(dialogo.IdPedidoSeleccionado);
                }
            }
        }

        // ─── CARGAR PRODUCTOS DESDE LA OC ───────────────────────────────

        private void CargarProductosDeOC(int idPedido)
        {
            const string sql = @"
                SELECT p.barcode, p.detalle, d.cantidad
                FROM pedido_proveedor_detalle d
                INNER JOIN producto p ON d.id_producto = p.id
                WHERE d.id_pedido = @idp";

            using (var con = new SqlConnection(_conString))
            {
                con.Open();
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@idp", idPedido);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string barcode = reader["barcode"].ToString();
                            int cant = Convert.ToInt32(reader["cantidad"]);

                            // Si ya existe el producto, suma la cantidad pedida
                            bool encontrado = false;
                            foreach (DataGridViewRow fila in gridProductos.Rows)
                            {
                                if (fila.Cells["colBarcode"].Value?.ToString() == barcode)
                                {
                                    int cantActual = Convert.ToInt32(fila.Cells["colCantPedida"].Value);
                                    fila.Cells["colCantPedida"].Value = cantActual + cant;
                                    RecalcularDiferencia(fila);
                                    encontrado = true;
                                    break;
                                }
                            }

                            if (!encontrado)
                            {
                                int idx = gridProductos.Rows.Add(barcode, reader["detalle"], cant, 0, -cant);
                                ColorizarFila(gridProductos.Rows[idx], -cant);
                            }
                        }
                    }
                }
            }

            ActualizarResumen();
        }

        // ─── QUITAR OC ───────────────────────────────────────────────────

        private void gridOCs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != gridOCs.Columns["colOCEliminar"].Index) return;

            var confirm = MessageBox.Show(
                "¿Desea quitar esta orden de compra? Se quitarán sus productos de la lista.",
                "SurFe", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                int idOC = Convert.ToInt32(gridOCs.Rows[e.RowIndex].Cells["colOCId"].Value);
                _idsOC.Remove(idOC);
                gridOCs.Rows.RemoveAt(e.RowIndex);
                ReconstruirProductos();
            }
        }

        private void ReconstruirProductos()
        {
            gridProductos.Rows.Clear();
            foreach (int idOC in _idsOC)
                CargarProductosDeOC(idOC);
        }

        // ─── DIFERENCIA EN TIEMPO REAL ───────────────────────────────────

        private void gridProductos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != gridProductos.Columns["colCantRecibida"].Index) return;
            RecalcularDiferencia(gridProductos.Rows[e.RowIndex]);
            ActualizarResumen();
        }

        private void gridProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != gridProductos.Columns["colCantRecibida"].Index) return;
            RecalcularDiferencia(gridProductos.Rows[e.RowIndex]);
            ActualizarResumen();
        }

        private void RecalcularDiferencia(DataGridViewRow fila)
        {
            if (!int.TryParse(fila.Cells["colCantPedida"].Value?.ToString(), out int pedida)) return;
            if (!int.TryParse(fila.Cells["colCantRecibida"].Value?.ToString(), out int recibida)) return;

            int diferencia = recibida - pedida;
            fila.Cells["colDiferencia"].Value = diferencia == 0 ? "OK" : diferencia.ToString("+#;-#;0");
            ColorizarFila(fila, diferencia);
        }

        private void ColorizarFila(DataGridViewRow fila, int diferencia)
        {
            fila.DefaultCellStyle.BackColor = diferencia == 0
                ? Color.FromArgb(220, 255, 220)   // verde — OK
                : Color.FromArgb(255, 220, 220);   // rojo  — diferencia
        }

        // ─── RESUMEN ─────────────────────────────────────────────────────

        private void ActualizarResumen()
        {
            int ok = 0;
            int diff = 0;

            foreach (DataGridViewRow fila in gridProductos.Rows)
            {
                string dif = fila.Cells["colDiferencia"].Value?.ToString();
                if (dif == "OK") ok++;
                else diff++;
            }

            if (gridProductos.Rows.Count == 0)
            {
                lblResumen.Text = "";
                return;
            }

            lblResumen.Text = $"Total: {gridProductos.Rows.Count}  |  ✔ Sin diferencia: {ok}  |  ✖ Con diferencia: {diff}";
            lblResumen.ForeColor = diff > 0 ? Color.FromArgb(180, 0, 0) : Color.FromArgb(0, 130, 0);
        }

        // ─── VALIDACIONES ────────────────────────────────────────────────

        private bool ValidarFormulario()
        {
            if (_idProveedor == -1)
            {
                MessageBox.Show("Seleccione un proveedor.", "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNroRemito.Text))
            {
                MessageBox.Show("Ingrese el número de remito.", "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (gridProductos.Rows.Count == 0)
            {
                MessageBox.Show("Asocie al menos una orden de compra.", "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            foreach (DataGridViewRow fila in gridProductos.Rows)
            {
                if (!int.TryParse(fila.Cells["colCantRecibida"].Value?.ToString(), out int cant) || cant < 0)
                {
                    MessageBox.Show(
                        $"Cantidad recibida inválida en '{fila.Cells["colDetalle"].Value}'.",
                        "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        // ─── GUARDAR ────────────────────────────────────────────────────

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            using (var con = new SqlConnection(_conString))
            {
                con.Open();
                var tra = con.BeginTransaction();
                try
                {
                    int idRemito = InsertarRemito(con, tra);
                    InsertarDetalleRemito(con, tra, idRemito);
                    ActualizarEstadoOCs(con, tra);
                    tra.Commit();

                    // Si hay diferencias, ofrece imprimir
                    bool hayDiferencias = HayDiferencias();
                    if (hayDiferencias)
                    {
                        var respuesta = MessageBox.Show(
                            "Se detectaron diferencias en las cantidades.\n¿Desea imprimir el listado de diferencias?",
                            "SurFe", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (respuesta == DialogResult.Yes)
                            GenerarPDFDiferencias(idRemito);
                    }
                    else
                    {
                        MessageBox.Show("Recepción registrada correctamente. Todas las cantidades coinciden.", "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.Close();
                }
                catch (Exception ex)
                {
                    tra.Rollback();
                    MessageBox.Show($"Error al registrar la recepción:\n{ex.Message}", "SurFe — Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool HayDiferencias()
        {
            foreach (DataGridViewRow fila in gridProductos.Rows)
            {
                string dif = fila.Cells["colDiferencia"].Value?.ToString();
                if (dif != "OK" && !string.IsNullOrEmpty(dif)) return true;
            }
            return false;
        }

        private int InsertarRemito(SqlConnection con, SqlTransaction tra)
        {
            const string sql = @"
                INSERT INTO remito_entrada (id_proveedor, nro_remito, fecha_entrada, observaciones, id_pedido, estado)
                VALUES (@idp, @nro, @fecha, @obs, @idoc, 'Pendiente');
                SELECT SCOPE_IDENTITY();";

            using (var cmd = new SqlCommand(sql, con, tra))
            {
                cmd.Parameters.AddWithValue("@idp", _idProveedor);
                cmd.Parameters.AddWithValue("@nro", txtNroRemito.Text.Trim());
                cmd.Parameters.AddWithValue("@fecha", dtpFechaEntrada.Value.Date);
                cmd.Parameters.AddWithValue("@obs", string.IsNullOrWhiteSpace(txtObservaciones.Text)
                                                      ? (object)DBNull.Value
                                                      : txtObservaciones.Text.Trim());
                cmd.Parameters.AddWithValue("@idoc", _idsOC.Count > 0 ? (object)_idsOC[0] : DBNull.Value);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void InsertarDetalleRemito(SqlConnection con, SqlTransaction tra, int idRemito)
        {
            const string sqlDetalle = @"
                INSERT INTO remito_entrada_detalle (id_remito, id_producto, cantidad_recibida)
                VALUES (@idr, (SELECT TOP 1 id FROM producto WHERE barcode = @bar), @cant)";

            const string sqlStock = @"
                UPDATE producto SET stock = stock + @cant WHERE barcode = @bar";

            foreach (DataGridViewRow fila in gridProductos.Rows)
            {
                int cant = Convert.ToInt32(fila.Cells["colCantRecibida"].Value);
                string barcode = fila.Cells["colBarcode"].Value.ToString();

                // Insertar detalle del remito
                using (var cmd = new SqlCommand(sqlDetalle, con, tra))
                {
                    cmd.Parameters.AddWithValue("@idr", idRemito);
                    cmd.Parameters.AddWithValue("@bar", barcode);
                    cmd.Parameters.AddWithValue("@cant", cant);
                    cmd.ExecuteNonQuery();
                }

                // Actualizar stock con la cantidad efectivamente recibida
                using (var cmd = new SqlCommand(sqlStock, con, tra))
                {
                    cmd.Parameters.AddWithValue("@bar", barcode);
                    cmd.Parameters.AddWithValue("@cant", cant);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void ActualizarEstadoOCs(SqlConnection con, SqlTransaction tra)
        {
            const string sql = "UPDATE pedido_proveedor SET estado = 'Recibido' WHERE id_pedido = @idp";
            foreach (int idOC in _idsOC)
            {
                using (var cmd = new SqlCommand(sql, con, tra))
                {
                    cmd.Parameters.AddWithValue("@idp", idOC);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ─── PDF DE DIFERENCIAS ──────────────────────────────────────────

        private void GenerarPDFDiferencias(int idRemito)
        {
            string ruta = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                $"Diferencias_Remito{idRemito}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

            try
            {
                var filas = new StringBuilder();
                foreach (DataGridViewRow fila in gridProductos.Rows)
                {
                    string dif = fila.Cells["colDiferencia"].Value?.ToString();
                    if (dif == "OK") continue;

                    string color = dif.StartsWith("-") ? "#ffd5d5" : "#fff3cd";
                    filas.Append($@"
                        <tr style='background-color:{color};'>
                            <td style='border:1px solid #ddd; padding:8px;'>{fila.Cells["colBarcode"].Value}</td>
                            <td style='border:1px solid #ddd; padding:8px;'>{fila.Cells["colDetalle"].Value}</td>
                            <td style='border:1px solid #ddd; padding:8px; text-align:center;'>{fila.Cells["colCantPedida"].Value}</td>
                            <td style='border:1px solid #ddd; padding:8px; text-align:center;'>{fila.Cells["colCantRecibida"].Value}</td>
                            <td style='border:1px solid #ddd; padding:8px; text-align:center; font-weight:bold;'>{dif}</td>
                        </tr>");
                }

                string html = $@"
                <html>
                <body style='font-family: Arial, sans-serif;'>
                    <div style='text-align:center; border-bottom:2px solid #007ACC; padding-bottom:10px;'>
                        <h1 style='color:#007ACC; margin:0;'>SurFe — DIFERENCIAS DE RECEPCIÓN</h1>
                        <p style='margin:5px 0;'>
                            <b>Remito N°:</b> {txtNroRemito.Text} &nbsp;|&nbsp;
                            <b>Proveedor:</b> {lblProveedor.Text} &nbsp;|&nbsp;
                            <b>Fecha:</b> {dtpFechaEntrada.Value:dd/MM/yyyy}
                        </p>
                    </div>
                    <br/>
                    <table style='width:100%; border-collapse:collapse;'>
                        <thead>
                            <tr style='background-color:#007ACC; color:white;'>
                                <th style='padding:10px;'>Código</th>
                                <th style='padding:10px;'>Producto</th>
                                <th style='padding:10px;'>Cant. Pedida</th>
                                <th style='padding:10px;'>Cant. Recibida</th>
                                <th style='padding:10px;'>Diferencia</th>
                            </tr>
                        </thead>
                        <tbody>{filas}</tbody>
                    </table>
                    <br/>
                    <p style='font-size:11px; color:#666;'>
                        Rojo: faltante &nbsp;|&nbsp; Amarillo: sobrante
                    </p>
                    <p style='margin-top:60px;'>Firma: _______________________________</p>
                </body>
                </html>";

                using (var stream = new FileStream(ruta, FileMode.Create))
                {
                    var doc = new Document(PageSize.A4, 30, 30, 30, 30);
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
                MessageBox.Show($"Error al generar el PDF:\n{ex.Message}", "SurFe — Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();
    }
}