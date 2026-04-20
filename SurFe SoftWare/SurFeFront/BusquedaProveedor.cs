using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SurFeFront
{
    public partial class BusquedaProveedor : Form
    {
        public int IdSeleccionado { get; set; }
        public string NombreSeleccionado { get; set; }
        private string conString = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

        public BusquedaProveedor()
        {
            InitializeComponent();
            CargarDatos("");
        }

        private void CargarDatos(string filtro)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                string sql = "SELECT id, razon_social as [Razón Social], cuit as CUIT FROM proveedor WHERE razon_social LIKE @f OR cuit LIKE @f";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.SelectCommand.Parameters.AddWithValue("@f", "%" + filtro + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProveedores.DataSource = dt;
                if (dgvProveedores.Columns["id"] != null) dgvProveedores.Columns["id"].Visible = false;
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e) => CargarDatos(txtFiltro.Text.Trim());

        private void dgvProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                IdSeleccionado = Convert.ToInt32(dgvProveedores.CurrentRow.Cells["id"].Value);
                NombreSeleccionado = dgvProveedores.CurrentRow.Cells["Razón Social"].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}