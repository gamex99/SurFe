using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using SurFe;

namespace SurFeFront
{
    public partial class Proveedores : Form
    {
        private string conString = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

        public Proveedores()
        {
            InitializeComponent();
            this.Load += (s, e) => buscarDatos();
        }

        private void buscarDatos()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    // Hacemos un JOIN con localidad para mostrar el nombre en la grilla
                    string query = @"SELECT p.id, p.razon_social, p.cuit, p.direccion, p.tel, p.correo, 
                                   l.localidad as LocalidadNombre, p.idLocalidad
                            FROM proveedor p
                            LEFT JOIN localidad l ON p.idLocalidad = l.id
                            WHERE p.razon_social LIKE @filtro 
                            OR CAST(p.cuit AS VARCHAR) LIKE @filtro";

                    SqlCommand command = new SqlCommand(query, connection);
                    // El '%' permite que busque coincidencias parciales
                    command.Parameters.AddWithValue("@filtro", "%" + tbBuscar.Text.Trim() + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    connection.Open();
                    adapter.Fill(dataTable);

                    dgvProveedores.DataSource = dataTable;

                    // Limpieza de columnas para que no se vea feo
                    if (dgvProveedores.Columns["id"] != null) dgvProveedores.Columns["id"].Visible = false;
                    if (dgvProveedores.Columns["idLocalidad"] != null) dgvProveedores.Columns["idLocalidad"].Visible = false;

                    // Renombrar encabezado para el usuario
                    if (dgvProveedores.Columns["LocalidadNombre"] != null)
                        dgvProveedores.Columns["LocalidadNombre"].HeaderText = "Localidad";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message, "SurFe Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbBuscar_TextChanged(object sender, EventArgs e) => buscarDatos();

        private void button1_Click(object sender, EventArgs e) // NUEVO
        {
            RegistrarProveedor frm = new RegistrarProveedor();
            frm.modo = EnumModoForm.Alta;
            if (frm.ShowDialog() == DialogResult.OK) buscarDatos();
        }

        private void button2_Click(object sender, EventArgs e) // MODIFICAR
        {
            if (dgvProveedores.CurrentRow == null) return;
            RegistrarProveedor frm = new RegistrarProveedor();
            frm.modo = EnumModoForm.Modificacion;

            var r = dgvProveedores.CurrentRow;
            frm.CargarDatos(
                r.Cells["razon_social"].Value.ToString(),
                Convert.ToInt64(r.Cells["cuit"].Value),
                r.Cells["direccion"].Value.ToString(),
                r.Cells["tel"].Value.ToString(),
                r.Cells["correo"].Value.ToString(),
                Convert.ToInt32(r.Cells["idLocalidad"].Value)
            );

            if (frm.ShowDialog() == DialogResult.OK) buscarDatos();
        }

        private void btncons_Click(object sender, EventArgs e) // CONSULTA
        {
            if (dgvProveedores.CurrentRow == null) return;
            RegistrarProveedor frm = new RegistrarProveedor();
            frm.modo = EnumModoForm.Consulta;

            var r = dgvProveedores.CurrentRow;
            frm.CargarDatos(
                r.Cells["razon_social"].Value.ToString(),
                Convert.ToInt64(r.Cells["cuit"].Value),
                r.Cells["direccion"].Value.ToString(),
                r.Cells["tel"].Value.ToString(),
                r.Cells["correo"].Value.ToString(),
                Convert.ToInt32(r.Cells["idLocalidad"].Value)
            );
            frm.ShowDialog();
        }

        private void btneliminar_Click(object sender, EventArgs e) // ELIMINAR
        {
            if (dgvProveedores.CurrentRow == null) return;
            long cuit = Convert.ToInt64(dgvProveedores.CurrentRow.Cells["cuit"].Value);
            string nombre = dgvProveedores.CurrentRow.Cells["razon_social"].Value.ToString();

            if (MessageBox.Show($"¿Eliminar a {nombre}?", "SurFe", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM proveedor WHERE cuit = @c", con);
                        cmd.Parameters.AddWithValue("@c", cuit);
                        cmd.ExecuteNonQuery();
                    }
                    buscarDatos();
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        private void button5_Click(object sender, EventArgs e) => this.Close(); // SALIR
    }
}