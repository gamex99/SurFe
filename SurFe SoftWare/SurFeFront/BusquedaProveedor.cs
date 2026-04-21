using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace SurFeFront
{
    public partial class BusquedaProveedor : Form
    {
        string conString = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

        // ¡ACÁ ESTÁN LAS PROPIEDADES QUE FALTABAN!
        public int IdProveedor { get; set; }
        public string RazonSocial { get; set; }
        public string Cuit { get; set; }
        public int IdSeleccionado => IdProveedor;
        public string NombreSeleccionado => RazonSocial;
        public BusquedaProveedor()
        {
            InitializeComponent();
            ConfigurarGrilla();
            CargarProveedores();
        }

        private void ConfigurarGrilla()
        {
            dgvProveedores.Columns.Clear();
            dgvProveedores.Columns.Add("id", "ID");
            dgvProveedores.Columns["id"].Visible = false; // Ocultamos el ID por estética
            dgvProveedores.Columns.Add("razon_social", "Razón Social");
            dgvProveedores.Columns.Add("cuit", "CUIT");
        }

        private void CargarProveedores()
        {
            dgvProveedores.Rows.Clear();
            using (SqlConnection con = new SqlConnection(conString))
            {
                // Usamos los nombres reales de tu tabla (id, razon_social, cuit)
                string sql = "SELECT id, razon_social, cuit FROM proveedor";
                SqlCommand cmd = new SqlCommand(sql, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dgvProveedores.Rows.Add(dr["id"], dr["razon_social"], dr["cuit"]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar proveedores: " + ex.Message);
                }
            }
        }

        private void dgvProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Cuando el usuario hace doble clic, llenamos las propiedades y cerramos
                this.IdProveedor = Convert.ToInt32(dgvProveedores.CurrentRow.Cells["id"].Value);
                this.RazonSocial = dgvProveedores.CurrentRow.Cells["razon_social"].Value.ToString();

                // Por si el CUIT está vacío en la base de datos, evitamos que explote
                this.Cuit = dgvProveedores.CurrentRow.Cells["cuit"].Value != DBNull.Value
                            ? dgvProveedores.CurrentRow.Cells["cuit"].Value.ToString()
                            : "S/N";

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}