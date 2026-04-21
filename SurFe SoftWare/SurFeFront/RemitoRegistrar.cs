using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SurFeFront
{
    public partial class RemitoRegistrar : Form
    {
        string conString = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
        int idPedidoSel = -1;
        int idProvSel = -1;

        public RemitoRegistrar()
        {
            InitializeComponent();
            ConfigurarGrilla();
        }

        private void ConfigurarGrilla()
        {
            dgvProductos.Columns.Clear();
            dgvProductos.AutoGenerateColumns = false;

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { Name = "id_prod", Visible = false, DataPropertyName = "id" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { Name = "codigo", HeaderText = "Código", ReadOnly = true, Width = 100 });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { Name = "nombre", HeaderText = "Producto", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { Name = "cant_pedida", HeaderText = "Cant. Pedida", ReadOnly = true, Width = 100 });

            // Columna editable para Cantidad Recibida (Criterio de Aceptación)
            DataGridViewTextBoxColumn colRecibida = new DataGridViewTextBoxColumn();
            colRecibida.Name = "cant_recibida";
            colRecibida.HeaderText = "Cant. Recibida";
            colRecibida.Width = 100;
            dgvProductos.Columns.Add(colRecibida);
        }

        private void btnBuscarPedido_Click(object sender, EventArgs e)
        {
            // Usamos el buscador de pedidos (asegurate que devuelva ID e ID de Proveedor)
            using (BusquedaPedidoProveedor buscador = new BusquedaPedidoProveedor())
            {
                if (buscador.ShowDialog() == DialogResult.OK)
                {
                    idPedidoSel = buscador.IdPedido;
                    idProvSel = buscador.IdProveedor;
                    lblPedidoInfo.Text = $"Pedido Nro: {idPedidoSel} - Prov: {buscador.NombreProv}";
                    CargarProductosDelPedido(idPedidoSel);
                }
            }
        }

        private void CargarProductosDelPedido(int idPedido)
        {
            dgvProductos.Rows.Clear();
            using (SqlConnection con = new SqlConnection(conString))
            {
                // Ajustado a tus nombres reales: detalle y barcode
                string sql = @"SELECT p.id, p.barcode, p.detalle, dp.cantidad 
                       FROM pedido_proveedor_detalle dp
                       INNER JOIN producto p ON dp.id_producto = p.id
                       WHERE dp.id_pedido = @idp";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@idp", idPedido);

                try
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        // Asegurate que el orden de las celdas coincida con tu diseño de columnas
                        dgvProductos.Rows.Add(
                            dr["id"],
                            dr["barcode"],
                            dr["detalle"],
                            dr["cantidad"], // Cantidad Pedida
                            dr["cantidad"]  // Cantidad Recibida (por defecto igualamos)
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar productos: " + ex.Message);
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Validaciones (Criterios de Aceptación)
            if (idPedidoSel == -1) { MessageBox.Show("Debe seleccionar un pedido."); return; }
            if (string.IsNullOrWhiteSpace(txtNroRemito.Text)) { MessageBox.Show("Ingrese el Nro. de Remito físico."); return; }

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlTransaction tra = con.BeginTransaction();
                try
                {
                    // 1. Insertar Cabecera Remito
                    string sqlRem = "INSERT INTO remito_entrada (id_proveedor, nro_remito, fecha_entrada, id_pedido) VALUES (@idp, @nro, @fec, @idPed); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdRem = new SqlCommand(sqlRem, con, tra);
                    cmdRem.Parameters.AddWithValue("@idp", idProvSel);
                    cmdRem.Parameters.AddWithValue("@nro", txtNroRemito.Text);
                    cmdRem.Parameters.AddWithValue("@fec", dtpFecha.Value);
                    cmdRem.Parameters.AddWithValue("@idPed", idPedidoSel);
                    int idRemito = Convert.ToInt32(cmdRem.ExecuteScalar());

                    bool tieneCarga = false;
                    bool entregaParcial = false;

                    // 2. Procesar Detalle y Actualizar Stock
                    foreach (DataGridViewRow row in dgvProductos.Rows)
                    {
                        int idProd = Convert.ToInt32(row.Cells["id_prod"].Value);
                        int cantP = Convert.ToInt32(row.Cells["cant_pedida"].Value);
                        int cantR = 0;
                        int.TryParse(row.Cells["cant_recibida"].Value?.ToString(), out cantR);

                        if (cantR > 0)
                        {
                            tieneCarga = true;

                            // CORRECCIÓN AQUÍ: Cambiamos 'cantidad' por 'cantidad_recibida' 
                            // para que coincida con tu tabla remito_entrada_detalle
                            string sqlDet = @"INSERT INTO remito_entrada_detalle (id_remito, id_producto, cantidad_recibida) 
                          VALUES (@idr, @idp, @cant)";

                            SqlCommand cmdDet = new SqlCommand(sqlDet, con, tra);
                            cmdDet.Parameters.AddWithValue("@idr", idRemito);
                            cmdDet.Parameters.AddWithValue("@idp", idProd);
                            cmdDet.Parameters.AddWithValue("@cant", cantR); // Este es el valor que toma de la grilla
                            cmdDet.ExecuteNonQuery();

                            // También corregimos el UPDATE del stock (que en tu tabla es 'stock')
                            SqlCommand cmdStock = new SqlCommand("UPDATE producto SET stock = stock + @cant WHERE id = @idp", con, tra);
                            cmdStock.Parameters.AddWithValue("@cant", cantR);
                            cmdStock.Parameters.AddWithValue("@idp", idProd);
                            cmdStock.ExecuteNonQuery();
                        }

                        if (cantR < cantP) entregaParcial = true;
                    }

                    if (!tieneCarga) throw new Exception("Al menos un producto debe tener cantidad recibida > 0.");

                    // 3. Actualizar Estado del Pedido (Criterio de Aceptación)
                    string estadoFinal = entregaParcial ? "Recibido Parcial" : "Recibido Completo";
                    SqlCommand cmdPed = new SqlCommand("UPDATE pedido_proveedor SET estado = @est WHERE id_pedido = @idp", con, tra);
                    cmdPed.Parameters.AddWithValue("@est", estadoFinal);
                    cmdPed.Parameters.AddWithValue("@idp", idPedidoSel);
                    cmdPed.ExecuteNonQuery();

                    tra.Commit();
                    MessageBox.Show($"Remito registrado con éxito. Pedido actualizado a: {estadoFinal}");
                    this.Close();
                }
                catch (Exception ex)
                {
                    tra.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}