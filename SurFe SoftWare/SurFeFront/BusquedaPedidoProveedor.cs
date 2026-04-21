using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace SurFeFront
{
    public partial class BusquedaPedidoProveedor : Form
    {
        string conString = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

        public int IdPedido { get; set; }
        public int IdProveedor { get; set; }
        public string NombreProv { get; set; }

        public BusquedaPedidoProveedor()
        {
            InitializeComponent();
            ConfigurarColumnas(); // <--- Esto asegura que no explote
            CargarPedidosPendientes();
        }

        private void ConfigurarColumnas()
        {
            dgvPedidos.Columns.Clear();
            dgvPedidos.Columns.Add("colId", "Nro Pedido");
            dgvPedidos.Columns.Add("colProv", "Proveedor");
            dgvPedidos.Columns.Add("colFecha", "Fecha");
            dgvPedidos.Columns.Add("colEstado", "Estado");
            dgvPedidos.Columns.Add("colIdProv", "ID Prov");
            dgvPedidos.Columns["colIdProv"].Visible = false;
        }

        private void CargarPedidosPendientes()
        {
            dgvPedidos.Rows.Clear();
            using (SqlConnection con = new SqlConnection(conString))
            {
                // Ajusté los nombres de las columnas a lo más común (id_pedido, fecha, etc.)
                string sql = @"SELECT p.id_pedido, p.id_proveedor, prov.razon_social, p.fecha, p.estado
                               FROM pedido_proveedor p
                               INNER JOIN proveedor prov ON p.id_proveedor = prov.id
                               WHERE p.estado != 'Recibido Completo'";

                SqlCommand cmd = new SqlCommand(sql, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dgvPedidos.Rows.Add(
                            dr["id_pedido"],
                            dr["razon_social"],
                            Convert.ToDateTime(dr["fecha"]).ToShortDateString(),
                            dr["estado"],
                            dr["id_proveedor"]
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en DB: " + ex.Message);
                }
            }
        }

        private void dgvPedidos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.IdPedido = Convert.ToInt32(dgvPedidos.CurrentRow.Cells["colId"].Value);
                this.NombreProv = dgvPedidos.CurrentRow.Cells["colProv"].Value.ToString();
                this.IdProveedor = Convert.ToInt32(dgvPedidos.CurrentRow.Cells["colIdProv"].Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}