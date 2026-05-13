using System;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace SurFeFront
{
    public partial class ProveedorRegistrarPedido : Form
    {
        // ─── Estados posibles del pedido ────────────────────────────────
        private static class EstadoPedido
        {
            public const string Pendiente = "Pendiente";
            public const string Enviado = "Enviado";
            public const string Recibido = "Recibido";
            public const string ConReclamo = "Con reclamo";
            public const string Cerrado = "Cerrado";
            public const string Cancelado = "Cancelado";
        }

        // ─── Estado interno del formulario ──────────────────────────────
        private readonly string _conString = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
        private int _idProveedor = -1;
        private string _barcodeActual = string.Empty;

        public ProveedorRegistrarPedido()
        {
            InitializeComponent();
        }

        // ─── BUSCADORES ─────────────────────────────────────────────────

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            using (var dialogo = new BusquedaProveedor())
            {
                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    _idProveedor = dialogo.IdSeleccionado;
                    lblRazonSocial.Text = dialogo.NombreSeleccionado;
                    lblRazonSocial.ForeColor = Color.Black;
                }
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            using (var dialogo = new BusquedaProducto())
            {
                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    _barcodeActual = dialogo.BarcodeSeleccionado;
                    lblBarcode.Text = dialogo.BarcodeSeleccionado;
                    lblDetalle.Text = dialogo.NombreSeleccionado;
                    tbCantidad.Clear();
                    tbCantidad.Focus();
                }
            }
        }

        // ─── AGREGAR PRODUCTO A LA GRILLA ───────────────────────────────

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_barcodeActual))
            {
                MessageBox.Show("Primero seleccione un producto.", "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(tbCantidad.Text.Trim(), out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida (número mayor a cero).", "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbCantidad.Focus();
                return;
            }

            // Si el producto ya está en la grilla, suma la cantidad
            foreach (DataGridViewRow fila in gridPedido.Rows)
            {
                if (fila.Cells["colBarcode"].Value?.ToString() == _barcodeActual)
                {
                    int cantActual = Convert.ToInt32(fila.Cells["colCantidad"].Value);
                    fila.Cells["colCantidad"].Value = cantActual + cantidad;
                    LimpiarSeleccionProducto();
                    return;
                }
            }

            gridPedido.Rows.Add(_barcodeActual, lblDetalle.Text, cantidad);
            LimpiarSeleccionProducto();
        }

        private void LimpiarSeleccionProducto()
        {
            _barcodeActual = string.Empty;
            lblBarcode.Text = "—";
            lblDetalle.Text = "Seleccione un producto...";
            tbCantidad.Clear();
            btnBuscarProducto.Focus();
        }

        // ─── ELIMINAR FILA DE LA GRILLA ─────────────────────────────────

        private void gridPedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != gridPedido.Columns["colEliminar"].Index)
                return;

            var confirmacion = MessageBox.Show(
                "¿Desea quitar este producto del pedido?",
                "SurFe",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
                gridPedido.Rows.RemoveAt(e.RowIndex);
        }

        // ─── SOLO NÚMEROS EN EL CAMPO CANTIDAD ──────────────────────────

        private void tbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
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
                    int idPedido = InsertarCabecera(con, tra);
                    InsertarDetalles(con, tra, idPedido);
                    tra.Commit();

                    GenerarYMostrarPDF(idPedido, lblRazonSocial.Text);
                    this.Close();
                }
                catch (Exception ex)
                {
                    tra.Rollback();
                    MessageBox.Show(
                        $"Error al guardar el pedido:\n{ex.Message}",
                        "SurFe — Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarFormulario()
        {
            if (_idProveedor == -1)
            {
                MessageBox.Show("Seleccione un proveedor antes de guardar.", "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (gridPedido.Rows.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto al pedido.", "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private int InsertarCabecera(SqlConnection con, SqlTransaction tra)
        {
            const string sql = @"
                INSERT INTO pedido_proveedor (id_proveedor, fecha, estado)
                VALUES (@idProveedor, GETDATE(), @estado);
                SELECT SCOPE_IDENTITY();";

            using (var cmd = new SqlCommand(sql, con, tra))
            {
                cmd.Parameters.AddWithValue("@idProveedor", _idProveedor);
                cmd.Parameters.AddWithValue("@estado", EstadoPedido.Pendiente);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void InsertarDetalles(SqlConnection con, SqlTransaction tra, int idPedido)
        {
            const string sql = @"
                INSERT INTO pedido_proveedor_detalle (id_pedido, id_producto, cantidad)
                VALUES (@idPedido,
                        (SELECT TOP 1 id FROM producto WHERE barcode = @barcode),
                        @cantidad)";

            foreach (DataGridViewRow fila in gridPedido.Rows)
            {
                if (fila.Cells["colBarcode"].Value == null) continue;

                using (var cmd = new SqlCommand(sql, con, tra))
                {
                    cmd.Parameters.AddWithValue("@idPedido", idPedido);
                    cmd.Parameters.AddWithValue("@barcode", fila.Cells["colBarcode"].Value.ToString());
                    cmd.Parameters.AddWithValue("@cantidad", Convert.ToInt32(fila.Cells["colCantidad"].Value));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ─── GENERACIÓN DE PDF ──────────────────────────────────────────

        private void GenerarYMostrarPDF(int nroPedido, string proveedor)
        {
            string ruta = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                $"Pedido_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

            try
            {
                string filasHtml = ConstruirFilasHtml();

                string html = $@"
                <html>
                <body style='font-family: Arial, sans-serif;'>
                    <div style='text-align: center;'>
                        <h1 style='color: #007ACC;'>SurFe — ORDEN DE PEDIDO</h1>
                        <p><b>N° Pedido:</b> {nroPedido} &nbsp;|&nbsp; <b>Fecha:</b> {DateTime.Now:dd/MM/yyyy}</p>
                        <hr/>
                    </div>
                    <p><b>Proveedor:</b> {proveedor}</p>
                    <table style='width:100%; border-collapse: collapse;'>
                        <thead>
                            <tr style='background-color:#007ACC; color:white;'>
                                <th style='padding:10px;'>Código</th>
                                <th style='padding:10px;'>Producto</th>
                                <th style='padding:10px;'>Cant.</th>
                            </tr>
                        </thead>
                        <tbody>{filasHtml}</tbody>
                    </table>
                    <br/><br/>
                    <p>Firma autorizada: _______________________________</p>
                </body>
                </html>";

                using (var stream = new FileStream(ruta, FileMode.Create))
                {
                    var doc = new Document(PageSize.A4, 25, 25, 25, 25);
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

        private string ConstruirFilasHtml()
        {
            var sb = new System.Text.StringBuilder();
            foreach (DataGridViewRow fila in gridPedido.Rows)
            {
                if (fila.Cells["colBarcode"].Value == null) continue;
                sb.Append($@"
                    <tr>
                        <td style='border:1px solid #ddd; padding:8px;'>{fila.Cells["colBarcode"].Value}</td>
                        <td style='border:1px solid #ddd; padding:8px;'>{fila.Cells["colDetalle"].Value}</td>
                        <td style='border:1px solid #ddd; padding:8px; text-align:center;'>{fila.Cells["colCantidad"].Value}</td>
                    </tr>");
            }
            return sb.ToString();
        }

        // ─── CANCELAR ───────────────────────────────────────────────────

        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();
    }
}