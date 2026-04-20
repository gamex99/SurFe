using SurFeFront;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SurFe
{
    public partial class RegistrarProveedor : Form
    {
        private string conString = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
        public EnumModoForm modo { get; set; }

        public RegistrarProveedor()
        {
            InitializeComponent();
            // Cargamos las provincias apenas se crea la ventana
            CargarComboProvincias();
        }

        private void RegistrarProveedor_Load(object sender, EventArgs e)
        {
            if (modo == EnumModoForm.Modificacion) btnCargar.Text = "ACTUALIZAR";
        }

        public void CargarDatos(string razon, long cuit, string dir, string tel, string correo, int idLoc)
        {
            tbrazonsocial.Text = razon;
            tbcuit.Text = cuit.ToString();
            tbdireccion.Text = dir;
            tbtel.Text = tel;
            tbcorreo.Text = correo;

            // En edición, buscamos a qué provincia pertenece la localidad para setear el primer combo
            int idProv = ObtenerProvinciaDeLocalidad(idLoc);
            if (idProv != -1)
            {
                cbProvincia.SelectedValue = idProv;
                CargarComboLocalidades(idProv); // Cargamos las localidades de esa provincia
                cblocalidad.SelectedValue = idLoc; // Seleccionamos la localidad específica
            }

            if (modo == EnumModoForm.Consulta)
            {
                foreach (Control c in this.Controls) if (c is TextBox || c is ComboBox) c.Enabled = false;
                btnCargar.Visible = false;
            }
            if (modo == EnumModoForm.Modificacion) tbcuit.Enabled = false; // El CUIT no se edita
        }

        // --- MANEJO DE COMBOBOXES ---

        private void CargarComboProvincias()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT id, provincia FROM provincia ORDER BY provincia", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cbProvincia.DataSource = dt;
                    cbProvincia.DisplayMember = "provincia";
                    cbProvincia.ValueMember = "id";
                    cbProvincia.SelectedIndex = -1; // Lo dejamos en blanco al principio
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar provincias: " + ex.Message); }
        }

        private void CargarComboLocalidades(int idProvincia)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    // Filtramos por id_provincia usando la tabla que me mostraste
                    string query = "SELECT id, localidad FROM localidad WHERE id_provincia = @idProv ORDER BY localidad";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@idProv", idProvincia);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cblocalidad.DataSource = dt;
                    cblocalidad.DisplayMember = "localidad";
                    cblocalidad.ValueMember = "id";
                    cblocalidad.SelectedIndex = -1;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar localidades: " + ex.Message); }
        }

        // Evento: Cuando el usuario elige una provincia, cargamos sus localidades
        private void cbProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbProvincia.SelectedValue != null && int.TryParse(cbProvincia.SelectedValue.ToString(), out int idProv))
            {
                CargarComboLocalidades(idProv);
            }
        }

        // Método auxiliar para el modo Modificar/Consultar
        private int ObtenerProvinciaDeLocalidad(int idLoc)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT id_provincia FROM localidad WHERE id = @id", con);
                    cmd.Parameters.AddWithValue("@id", idLoc);
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value) return Convert.ToInt32(result);
                }
            }
            catch { }
            return -1;
        }

        // --- VALIDACIÓN Y GUARDADO ---

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;
            Guardar();
        }

        private bool Validar()
        {
            // Verificamos que NINGÚN campo esté vacío
            if (string.IsNullOrWhiteSpace(tbrazonsocial.Text)) { MessageBox.Show("Razón Social es obligatoria."); tbrazonsocial.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(tbdireccion.Text)) { MessageBox.Show("Dirección es obligatoria."); tbdireccion.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(tbtel.Text)) { MessageBox.Show("Teléfono es obligatorio."); tbtel.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(tbcorreo.Text)) { MessageBox.Show("Correo es obligatorio."); tbcorreo.Focus(); return false; }
            if (cbProvincia.SelectedIndex == -1) { MessageBox.Show("Seleccione una provincia."); cbProvincia.Focus(); return false; }
            if (cblocalidad.SelectedIndex == -1) { MessageBox.Show("Seleccione una localidad."); cblocalidad.Focus(); return false; }

            long cuitVal;
            if (tbcuit.Text.Trim().Length != 11 || !long.TryParse(tbcuit.Text, out cuitVal))
            {
                MessageBox.Show("CUIT inválido. Debe tener exactamente 11 dígitos numéricos.");
                tbcuit.Focus();
                return false;
            }

            if (modo == EnumModoForm.Alta && ExisteCuit(cuitVal))
            {
                MessageBox.Show("El CUIT ingresado ya se encuentra registrado.");
                return false;
            }

            return true;
        }

        private bool ExisteCuit(long cuit)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM proveedor WHERE cuit = @c", con);
                cmd.Parameters.AddWithValue("@c", cuit);
                con.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private void Guardar()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    string query = modo == EnumModoForm.Alta
                        ? "INSERT INTO proveedor (razon_social, cuit, direccion, tel, correo, idLocalidad) VALUES (@r, @c, @d, @t, @m, @l)"
                        : "UPDATE proveedor SET razon_social=@r, direccion=@d, tel=@t, correo=@m, idLocalidad=@l WHERE cuit=@c";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@r", tbrazonsocial.Text.Trim());
                    cmd.Parameters.AddWithValue("@c", Convert.ToInt64(tbcuit.Text.Trim()));
                    cmd.Parameters.AddWithValue("@d", tbdireccion.Text.Trim());
                    cmd.Parameters.AddWithValue("@t", tbtel.Text.Trim());
                    cmd.Parameters.AddWithValue("@m", tbcorreo.Text.Trim());
                    cmd.Parameters.AddWithValue("@l", cblocalidad.SelectedValue);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Proveedor guardado exitosamente.", "SurFe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al guardar en la base de datos: " + ex.Message); }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();
    }
}