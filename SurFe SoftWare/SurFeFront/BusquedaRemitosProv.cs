using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace SurFeFront
{
    public partial class BusquedaRemitosProv : Form
    {
        string conString = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
        int idProv;

        // Propiedades para que la pantalla de Factura las pueda leer
        public int IdRemito { get; set; }
        public string NroRemito { get; set; }
        public DateTime Fecha { get; set; }

        // El constructor ahora pide el ID del proveedor seleccionado
        public BusquedaRemitosProv(int idProveedor)
        {
            InitializeComponent();
            idProv = idProveedor;
            ConfigurarGrilla();
            CargarRemitos();
        }

        private void ConfigurarGrilla()
        {
            dgvRemitos.Columns.Clear();
            dgvRemitos.Columns.Add("id_remito", "ID");
            dgvRemitos.Columns["id_remito"].Visible = false;
            dgvRemitos.Columns.Add("nro_remito", "Nro. Remito");
            dgvRemitos.Columns.Add("fecha_entrada", "Fecha de Ingreso");
        }

        private void CargarRemitos()
        {
            dgvRemitos.Rows.Clear();
            using (SqlConnection con = new SqlConnection(conString))
            {
                // Solo traemos los remitos del proveedor seleccionado
                string sql = @"SELECT id_remito, nro_remito, fecha_entrada 
                               FROM remito_entrada 
                               WHERE id_proveedor = @idp";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@idp", idProv);

                try
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dgvRemitos.Rows.Add(
                            dr["id_remito"],
                            dr["nro_remito"],
                            Convert.ToDateTime(dr["fecha_entrada"]).ToShortDateString()
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar remitos: " + ex.Message);
                }
            }
        }

        private void dgvRemitos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Llenamos las propiedades y cerramos
                this.IdRemito = Convert.ToInt32(dgvRemitos.CurrentRow.Cells["id_remito"].Value);
                this.NroRemito = dgvRemitos.CurrentRow.Cells["nro_remito"].Value.ToString();
                this.Fecha = Convert.ToDateTime(dgvRemitos.CurrentRow.Cells["fecha_entrada"].Value);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}