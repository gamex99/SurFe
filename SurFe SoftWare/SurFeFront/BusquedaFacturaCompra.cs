using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace SurFeFront
{
    public partial class BusquedaFacturaCompra : Form
    {
        string conString = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

        // Propiedades para retornar al form de ComprasRegistrar
        public int IdFactura { get; set; }
        public int IdProveedor { get; set; }
        public string NroFactura { get; set; }
        public string NombreProv { get; set; }

        public BusquedaFacturaCompra(bool soloNoAsociadas = true)
        {
            InitializeComponent();
            // Aseguramos que las columnas de la grilla existan antes de cargar
            ConfigurarGrilla();
            CargarFacturas(soloNoAsociadas);
        }

        private void ConfigurarGrilla()
        {
            dgvBusqueda.Columns.Clear();
            dgvBusqueda.Columns.Add("id", "ID");
            dgvBusqueda.Columns["id"].Visible = false;
            dgvBusqueda.Columns.Add("nro", "Nro Factura");
            dgvBusqueda.Columns.Add("prov", "Proveedor");
            dgvBusqueda.Columns.Add("monto", "Monto Total");
            dgvBusqueda.Columns.Add("idp", "ID Prov");
            dgvBusqueda.Columns["idp"].Visible = false;
        }

        private void CargarFacturas(bool soloNoAsociadas)
        {
            dgvBusqueda.Rows.Clear();
            using (SqlConnection con = new SqlConnection(conString))
            {
                // CORRECCIÓN: Usamos monto_total y estado_pago según la nueva estructura
                string sql = @"SELECT f.id_factura, f.nro_factura, p.razon_social, f.monto_total, f.id_proveedor
                               FROM factura_compra f
                               INNER JOIN proveedor p ON f.id_proveedor = p.id
                               WHERE 1=1 ";

                // Si buscamos solo las que no están asociadas/pagadas aún
                if (soloNoAsociadas)
                {
                    sql += " AND f.estado_pago = 'Pendiente de Pago'";
                }

                SqlCommand cmd = new SqlCommand(sql, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dgvBusqueda.Rows.Add(
                            dr["id_factura"],
                            dr["nro_factura"],
                            dr["razon_social"],
                            dr["monto_total"],
                            dr["id_proveedor"]
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar facturas: " + ex.Message);
                }
            }
        }

        private void dgvBusqueda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Usamos los nombres de las columnas configuradas arriba para mayor seguridad
                this.IdFactura = Convert.ToInt32(dgvBusqueda.CurrentRow.Cells["id"].Value);
                this.NroFactura = dgvBusqueda.CurrentRow.Cells["nro"].Value.ToString();
                this.NombreProv = dgvBusqueda.CurrentRow.Cells["prov"].Value.ToString();
                this.IdProveedor = Convert.ToInt32(dgvBusqueda.CurrentRow.Cells["idp"].Value);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}