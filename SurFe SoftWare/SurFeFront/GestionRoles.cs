using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SurFeFront
{
    public partial class GestionUsuarios : Form
    {
        string conString = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
        int idUsuarioSeleccionado = -1;

        public GestionUsuarios()
        {
            InitializeComponent();
            ConfigurarGrilla();
            CargarDepartamentos();
            CargarUsuarios();
        }

        private void ConfigurarGrilla()
        {
            dgvUsuarios.Columns.Clear();
            dgvUsuarios.AutoGenerateColumns = false;

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "id", Visible = false });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Usuario", HeaderText = "Usuario", Width = 100 });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Nombre", Width = 120 });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Apellido", HeaderText = "Apellido", Width = 120 });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Dni", HeaderText = "DNI", Width = 90 });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Departamento", HeaderText = "Departamento", Width = 130 });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "EsAdmin", HeaderText = "Rol de Sistema", Width = 100 });

            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void CargarDepartamentos()
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                string sql = "SELECT id, nombreDepartamento FROM departamento";
                SqlCommand cmd = new SqlCommand(sql, con);
                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbDepartamento.DataSource = dt;
                    cmbDepartamento.DisplayMember = "nombreDepartamento";
                    cmbDepartamento.ValueMember = "id";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar departamentos: " + ex.Message);
                }
            }
        }

        private void CargarUsuarios()
        {
            dgvUsuarios.Rows.Clear();
            using (SqlConnection con = new SqlConnection(conString))
            {
                string sql = @"SELECT u.id, u.usuario, u.nombre, u.apellido, u.dni, d.nombreDepartamento, u.idDepartamento
                               FROM usuarios u
                               LEFT JOIN departamento d ON u.idDepartamento = d.id";
                SqlCommand cmd = new SqlCommand(sql, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        // Si el idDepartamento es 1 es Administrador, de lo contrario Empleado
                        bool esDeptoAdmin = dr["idDepartamento"] != DBNull.Value && Convert.ToInt32(dr["idDepartamento"]) == 1;

                        string rolStr = esDeptoAdmin ? "Administrador" : "Empleado";

                        dgvUsuarios.Rows.Add(
                            dr["id"],
                            dr["usuario"],
                            dr["nombre"],
                            dr["apellido"],
                            dr["dni"],
                            dr["nombreDepartamento"] != DBNull.Value ? dr["nombreDepartamento"] : "Sin asignar",
                            rolStr
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar usuarios: " + ex.Message);
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Usuario y contrasena son obligatorios.");
                return;
            }

            using (SqlConnection con = new SqlConnection(conString))
            {
                int deptoSeleccionado = Convert.ToInt32(cmbDepartamento.SelectedValue);

                string sql = @"INSERT INTO usuarios (usuario, pass, nombre, apellido, dni, idDepartamento) 
                               VALUES (@user, @pass, @nom, @ape, @dni, @idd)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@user", txtUsuario.Text);
                cmd.Parameters.AddWithValue("@pass", txtPass.Text);
                cmd.Parameters.AddWithValue("@nom", txtNombre.Text);
                cmd.Parameters.AddWithValue("@ape", txtApellido.Text);
                cmd.Parameters.AddWithValue("@dni", txtDni.Text);
                cmd.Parameters.AddWithValue("@idd", deptoSeleccionado);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuario agregado correctamente.");
                    LimpiarCampos();
                    CargarUsuarios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar: " + ex.Message);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un usuario de la lista para modificar.");
                return;
            }

            using (SqlConnection con = new SqlConnection(conString))
            {
                int deptoSeleccionado = Convert.ToInt32(cmbDepartamento.SelectedValue);

                string sql = @"UPDATE usuarios 
                               SET usuario = @user, nombre = @nom, apellido = @ape, dni = @dni, 
                                   idDepartamento = @idd";

                if (!string.IsNullOrWhiteSpace(txtPass.Text))
                {
                    sql += ", pass = @pass";
                }
                sql += " WHERE id = @id";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@user", txtUsuario.Text);
                if (!string.IsNullOrWhiteSpace(txtPass.Text))
                {
                    cmd.Parameters.AddWithValue("@pass", txtPass.Text);
                }
                cmd.Parameters.AddWithValue("@nom", txtNombre.Text);
                cmd.Parameters.AddWithValue("@ape", txtApellido.Text);
                cmd.Parameters.AddWithValue("@dni", txtDni.Text);
                cmd.Parameters.AddWithValue("@idd", deptoSeleccionado);
                cmd.Parameters.AddWithValue("@id", idUsuarioSeleccionado);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuario actualizado correctamente.");
                    LimpiarCampos();
                    CargarUsuarios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar: " + ex.Message);
                }
            }
        }

        private void btnDarDeBaja_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un usuario para dar de baja.");
                return;
            }

            DialogResult result = MessageBox.Show("Esta seguro que desea eliminar el usuario seleccionado?", "SurFe - Confirmacion", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string sql = "DELETE FROM usuarios WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", idUsuarioSeleccionado);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Usuario eliminado correctamente.");
                        LimpiarCampos();
                        CargarUsuarios();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message);
                    }
                }
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsuarios.CurrentRow;
                idUsuarioSeleccionado = Convert.ToInt32(row.Cells["Id"].Value);

                txtUsuario.Text = row.Cells["Usuario"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtApellido.Text = row.Cells["Apellido"].Value.ToString();
                txtDni.Text = row.Cells["Dni"].Value.ToString();

                string depto = row.Cells["Departamento"].Value.ToString();
                if (depto != "Sin asignar")
                {
                    cmbDepartamento.Text = depto;
                }

                txtPass.Clear(); // Por seguridad limpiamos el campo de texto
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            idUsuarioSeleccionado = -1;
            txtUsuario.Clear();
            txtPass.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            if (cmbDepartamento.Items.Count > 0) cmbDepartamento.SelectedIndex = 0;
        }
    }
}