using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SurFeFront
{
    public partial class BusquedaProducto : Form
    {
        public string BarcodeSeleccionado { get; set; }
        public string NombreSeleccionado { get; set; }
        private string conString = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

        public BusquedaProducto()
        {
            InitializeComponent();
            CargarDatos("");
        }

        private void CargarDatos(string filtro)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    // Cambié 'producto' por 'detalle', que es como se llama en tu tabla
                    string sql = "SELECT barcode as Código, detalle as Descripción, precio as Precio FROM producto WHERE detalle LIKE @f OR barcode LIKE @f";

                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.SelectCommand.Parameters.AddWithValue("@f", "%" + filtro + "%");
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvProductos.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar productos: " + ex.Message, "SurFe");
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e) => CargarDatos(txtFiltro.Text.Trim());

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BarcodeSeleccionado = dgvProductos.CurrentRow.Cells["Código"].Value.ToString();
                NombreSeleccionado = dgvProductos.CurrentRow.Cells["Descripción"].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}