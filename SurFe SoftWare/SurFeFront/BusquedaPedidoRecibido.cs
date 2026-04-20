using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace SurFeFront
{
    public partial class BusquedaPedidoRecibido : Form
    {
        string conString = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
        public int IdPedido { get; set; }
        public string Proveedor { get; set; }
        public int IdProveedor { get; set; }

        public BusquedaPedidoRecibido()
        {
            InitializeComponent();
            CargarPedidos("");
        }

        private void CargarPedidos(string filtro)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    // Saqué el filtro de "estado = 'Recibido'" para que puedas ver y buscar TODO 
                    // hasta que acomodemos bien los estados. Y ahora busca por Nombre o por Nro de Pedido.
                    string sql = @"SELECT p.id_pedido as Nro, p.fecha as Fecha, pr.razon_social as Proveedor, p.id_proveedor 
                                   FROM pedido_proveedor p 
                                   JOIN proveedor pr ON p.id_proveedor = pr.id 
                                   WHERE pr.razon_social LIKE @f OR CAST(p.id_pedido AS VARCHAR) LIKE @f";

                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.SelectCommand.Parameters.AddWithValue("@f", "%" + filtro + "%");
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvPedidos.DataSource = dt;

                    // Ocultamos el ID del proveedor para que no moleste en la vista
                    if (dgvPedidos.Columns["id_proveedor"] != null)
                        dgvPedidos.Columns["id_proveedor"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar pedidos: " + ex.Message);
            }
        }

        // Doble clic en el TextBox de tu diseño para que se genere este evento
        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            CargarPedidos(txtFiltro.Text);
        }

        // Doble clic en la grilla de tu diseño para generar este evento
        private void dgvPedidos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                IdPedido = Convert.ToInt32(dgvPedidos.CurrentRow.Cells["Nro"].Value);
                Proveedor = dgvPedidos.CurrentRow.Cells["Proveedor"].Value.ToString();
                IdProveedor = Convert.ToInt32(dgvPedidos.CurrentRow.Cells["id_proveedor"].Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}