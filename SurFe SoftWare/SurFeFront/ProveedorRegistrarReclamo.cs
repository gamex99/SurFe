using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace SurFeFront
{
    public partial class ProveedorRegistrarReclamo : Form
    {
        // ─── Estado interno ──────────────────────────────────────────────
        private readonly string _conString = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
        private int _idRemito = -1;
        private int _idProveedor = -1;
        private string _nroRemito = "Sin remito";

        public ProveedorRegistrarReclamo()
        {
            InitializeComponent();
            cmbTipo.Items.AddRange(new string[] { "Reclamo", "Devolución" });
            cmbTipo.SelectedIndex = 0;
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
                    lblProveedor.ForeColor = System.Drawing.Color.Black;
                    btnAgregarProducto.Enabled = true;
                    gridProductos.Rows.Clear();

                    // Si cambia el proveedor, limpia el remito
                    _idRemito = -1;
                    _nroRemito = "Sin remito";
                    lblRemito.Text = "Sin remito asociado";
                    lblRemito.ForeColor = System.Drawing.Color.DimGray;
                }
            }
        }

        // ─── BUSCAR REMITO ───────────────────────────────────────────────

        private void btnBuscarRemito_Click(object sender, EventArgs e)
        {
            using (var dialogo = new BusquedaRemitoRecibido())
            {
                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    _idRemito = dialogo.IdRemitoSeleccionado;
                    _idProveedor = dialogo.IdProveedor;
                    _nroRemito = dialogo.NroRemito;
                    lblProveedor.Text = dialogo.NombreProveedor;
                    lblProveedor.ForeColor = System.Drawing.Color.Black;
                    lblRemito.Text = dialogo.NroRemito;
                    lblRemito.ForeColor = System.Drawing.Color.Black;
                    btnAgregarProducto.Enabled = false  ;
                    CargarProductosDelRemito(_idRemito);
                    
                }
            }
        }

        // ─── AGREGAR PRODUCTO MANUAL ─────────────────────────────────────

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (_idProveedor == -1)
            {
                MessageBox.Show("Seleccione un proveedor primero.", "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var dialogo = new BusquedaProducto())
            {
                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    // Si ya está en la grilla no lo duplica
                    foreach (DataGridViewRow fila in gridProductos.Rows)
                    {
                        if (fila.Cells["colBarcode"].Value?.ToString() == dialogo.BarcodeSeleccionado)
                        {
                            MessageBox.Show("Ese producto ya está en la lista.", "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    gridProductos.Rows.Add(
                        dialogo.BarcodeSeleccionado,
                        dialogo.NombreSeleccionado,
                        0,   // Cant. recibida = 0 en modo manual
                        0,   // Cant. reclamar
                        ""); // Motivo del producto
                }
            }
        }

        // ─── CARGAR PRODUCTOS DEL REMITO ─────────────────────────────────

        private void CargarProductosDelRemito(int idRemito)
        {
            gridProductos.Rows.Clear();

            const string sql = @"
                SELECT p.barcode, p.detalle, d.cantidad_recibida
                FROM remito_entrada_detalle d
                INNER JOIN producto p ON d.id_producto = p.id
                WHERE d.id_remito = @idr
                ORDER BY p.detalle";

            using (var con = new SqlConnection(_conString))
            {
                con.Open();
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@idr", idRemito);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            gridProductos.Rows.Add(
                                reader["barcode"],
                                reader["detalle"],
                                Convert.ToInt32(reader["cantidad_recibida"]),
                                0,
                                "");
                        }
                    }
                }
            }
        }

        // ─── QUITAR PRODUCTO DE LA GRILLA ────────────────────────────────

        private void gridProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != gridProductos.Columns["colEliminar"].Index) return;

            var confirm = MessageBox.Show(
                "¿Desea quitar este producto del reclamo?",
                "SurFe", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
                gridProductos.Rows.RemoveAt(e.RowIndex);
        }

        // ─── VALIDACIONES ────────────────────────────────────────────────

        private bool ValidarFormulario()
        {
            if (_idProveedor == -1)
            {
                MessageBox.Show("Seleccione un proveedor.", "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("El motivo general es obligatorio.", "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (gridProductos.Rows.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto.", "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            bool hayAlgo = false;
            foreach (DataGridViewRow fila in gridProductos.Rows)
            {
                string val = fila.Cells["colCantReclamar"].Value?.ToString();
                if (!int.TryParse(val, out int cant) || cant < 0)
                {
                    MessageBox.Show(
                        $"Cantidad inválida en '{fila.Cells["colDetalle"].Value}'.",
                        "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Solo valida max contra recibida si hay remito
                if (_idRemito != -1)
                {
                    int cantRecibida = Convert.ToInt32(fila.Cells["colCantRecibida"].Value);
                    if (cant > cantRecibida)
                    {
                        MessageBox.Show(
                            $"No podés reclamar más de lo recibido en '{fila.Cells["colDetalle"].Value}' (recibido: {cantRecibida}).",
                            "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                if (cant > 0) hayAlgo = true;
            }

            if (!hayAlgo)
            {
                MessageBox.Show("Ingrese al menos una cantidad a reclamar.", "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
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
                    int idReclamo = InsertarCabecera(con, tra);
                    InsertarDetalle(con, tra, idReclamo);

                    if (cmbTipo.Text == "Devolución")
                        DescontarStock(con, tra);

                    tra.Commit();

                    MessageBox.Show(
                        $"Reclamo N° {idReclamo} registrado correctamente.",
                        "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GenerarPDF(idReclamo);
                    this.Close();
                }
                catch (Exception ex)
                {
                    tra.Rollback();
                    MessageBox.Show(
                        $"Error al guardar el reclamo:\n{ex.Message}",
                        "SurFe — Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int InsertarCabecera(SqlConnection con, SqlTransaction tra)
        {
            const string sql = @"
                INSERT INTO reclamo_proveedor 
                    (id_remito, id_proveedor, tipo, motivo, estado, fecha_registro)
                VALUES 
                    (@idr, @idp, @tipo, @motivo, 'Abierto', GETDATE());
                SELECT SCOPE_IDENTITY();";

            using (var cmd = new SqlCommand(sql, con, tra))
            {
                cmd.Parameters.AddWithValue("@idr", _idRemito == -1 ? (object)DBNull.Value : _idRemito);
                cmd.Parameters.AddWithValue("@idp", _idProveedor);
                cmd.Parameters.AddWithValue("@tipo", cmbTipo.Text);
                cmd.Parameters.AddWithValue("@motivo", txtMotivo.Text.Trim());
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void InsertarDetalle(SqlConnection con, SqlTransaction tra, int idReclamo)
        {
            const string sql = @"
                INSERT INTO reclamo_proveedor_detalle 
                    (id_reclamo, id_producto, cantidad_reclamada)
                VALUES 
                    (@idr, (SELECT TOP 1 id FROM producto WHERE barcode = @bar), @cant)";

            foreach (DataGridViewRow fila in gridProductos.Rows)
            {
                int cant = Convert.ToInt32(fila.Cells["colCantReclamar"].Value);
                if (cant <= 0) continue;

                using (var cmd = new SqlCommand(sql, con, tra))
                {
                    cmd.Parameters.AddWithValue("@idr", idReclamo);
                    cmd.Parameters.AddWithValue("@bar", fila.Cells["colBarcode"].Value.ToString());
                    cmd.Parameters.AddWithValue("@cant", cant);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void DescontarStock(SqlConnection con, SqlTransaction tra)
        {
            const string sql = "UPDATE producto SET stock = stock - @cant WHERE barcode = @bar";

            foreach (DataGridViewRow fila in gridProductos.Rows)
            {
                int cant = Convert.ToInt32(fila.Cells["colCantReclamar"].Value);
                if (cant <= 0) continue;

                using (var cmd = new SqlCommand(sql, con, tra))
                {
                    cmd.Parameters.AddWithValue("@cant", cant);
                    cmd.Parameters.AddWithValue("@bar", fila.Cells["colBarcode"].Value.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ─── GENERACIÓN DE PDF ──────────────────────────────────────────

        private void GenerarPDF(int idReclamo)
        {
            string ruta = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                $"Reclamo_{idReclamo}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

            try
            {
                var filas = new StringBuilder();
                foreach (DataGridViewRow fila in gridProductos.Rows)
                {
                    int cant = Convert.ToInt32(fila.Cells["colCantReclamar"].Value);
                    if (cant <= 0) continue;

                    string motivoProd = fila.Cells["colMotivoProducto"].Value?.ToString();
                    motivoProd = string.IsNullOrWhiteSpace(motivoProd) ? "—" : motivoProd;

                    filas.Append($@"
                        <tr>
                            <td style='border:1px solid #ddd; padding:8px;'>{fila.Cells["colBarcode"].Value}</td>
                            <td style='border:1px solid #ddd; padding:8px;'>{fila.Cells["colDetalle"].Value}</td>
                            <td style='border:1px solid #ddd; padding:8px; text-align:center;'>{fila.Cells["colCantRecibida"].Value}</td>
                            <td style='border:1px solid #ddd; padding:8px; text-align:center; font-weight:bold;'>{cant}</td>
                            <td style='border:1px solid #ddd; padding:8px;'>{motivoProd}</td>
                        </tr>");
                }

                string html = $@"
                <html>
                <body style='font-family: Arial, sans-serif;'>
                    <div style='text-align:center; border-bottom:2px solid #007ACC; padding-bottom:10px;'>
                        <h1 style='color:#007ACC; margin:0;'>SurFe — {cmbTipo.Text.ToUpper()} N° {idReclamo}</h1>
                        <p style='margin:5px 0;'>
                            <b>Fecha:</b> {DateTime.Now:dd/MM/yyyy HH:mm} &nbsp;|&nbsp;
                            <b>Proveedor:</b> {lblProveedor.Text} &nbsp;|&nbsp;
                            <b>Remito:</b> {_nroRemito}
                        </p>
                    </div>
                    <br/>
                    <div style='background-color:#f5f5f5; border:1px solid #ddd; padding:12px; margin-bottom:20px;'>
                        <b>MOTIVO GENERAL:</b><br/>{txtMotivo.Text.Trim()}
                    </div>
                    <table style='width:100%; border-collapse:collapse;'>
                        <thead>
                            <tr style='background-color:#007ACC; color:white;'>
                                <th style='padding:10px;'>Código</th>
                                <th style='padding:10px;'>Producto</th>
                                <th style='padding:10px;'>Cant. Recibida</th>
                                <th style='padding:10px;'>Cant. Reclamada</th>
                                <th style='padding:10px;'>Motivo</th>
                            </tr>
                        </thead>
                        <tbody>{filas}</tbody>
                    </table>
                    <br/><br/><br/>
                    <table style='width:100%;'>
                        <tr>
                            <td style='text-align:center;'>__________________________<br/>Firma Autorizada SurFe</td>
                            <td style='text-align:center;'>__________________________<br/>Firma Proveedor / Transporte</td>
                        </tr>
                    </table>
                </body>
                </html>";

                using (var stream = new FileStream(ruta, FileMode.Create))
                {
                    var doc = new Document(PageSize.A4, 35, 35, 35, 35);
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