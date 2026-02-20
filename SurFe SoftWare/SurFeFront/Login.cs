using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurFeFront
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txtCont.PasswordChar = '•';
        }


        private void btAcceso_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = "SELECT u.nombre, u.apellido, u.idDepartamento, d.nombreDepartamento FROM usuarios AS u INNER JOIN departamento AS d ON u.idDepartamento = d.id WHERE u.usuario = @usuario AND u.pass = @password;";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@usuario", txtUsu.Text.Trim());
                    command.Parameters.AddWithValue("@password", txtCont.Text.Trim());

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ClaseCompartida.nombre = reader["nombre"].ToString();
                            ClaseCompartida.apellido = reader["apellido"].ToString();
                            ClaseCompartida.idDepartamento = int.Parse(reader["idDepartamento"].ToString());
                            ClaseCompartida.departamnto = reader["nombreDepartamento"].ToString();

                            // ¡Inicio de sesión exitoso!
                            this.Hide();
                            md f1 = new md();
                            f1.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            // Inicio de sesión fallido
                            MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } // El reader se cierra solo aquí
                } // La conexión se cierra sola aquí
            }
            catch (SqlException ex)
            {
                // Si hay timeout o error de red, entra acá y NO se cierra el programa
                MessageBox.Show("Error de base de datos: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Cualquier otro error general
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


















            /*
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            //string sql = "SELECT nombre, apellido, idDepartamento FROM usuarios WHERE user = @usuario AND pass = @password"; // Consulta SQL
            string sql = "SELECT u.nombre, u.apellido,u.idDepartamento, d.nombreDepartamento FROM usuarios AS u INNER JOIN departamento AS d ON u.idDepartamento = d.id WHERE u.usuario = @usuario AND u.pass = @password;";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@usuario", txtUsu.Text.ToString());
            command.Parameters.AddWithValue("@password", txtCont.Text.ToString());

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                ClaseCompartida.nombre = reader["nombre"].ToString();
                ClaseCompartida.apellido = reader["apellido"].ToString();
                ClaseCompartida.idDepartamento = int.Parse(reader["idDepartamento"].ToString());
                ClaseCompartida.departamnto = reader["nombreDepartamento"].ToString();

                // ¡Inicio de sesión exitoso!
                //SurFe.Menu f1 = new SurFe.Menu();
                this.Hide();
                md f1 = new md();
                f1.ShowDialog();
                this.Close();
            }
            else
            {
                // Inicio de sesión fallido
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




            reader.Close();
            connection.Close();

            */
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void txtCont_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            // Verificamos si la tecla presionada es Enter
            if (e.KeyCode == Keys.Enter)
            {
                // Esto evita el sonido de "error" de Windows
                e.SuppressKeyPress = true;

                // Aquí llamas a tu función (por ejemplo, la de ingresar)

                try
                {
                    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string sql = "SELECT u.nombre, u.apellido, u.idDepartamento, d.nombreDepartamento FROM usuarios AS u INNER JOIN departamento AS d ON u.idDepartamento = d.id WHERE u.usuario = @usuario AND u.pass = @password;";
                        SqlCommand command = new SqlCommand(sql, connection);
                        command.Parameters.AddWithValue("@usuario", txtUsu.Text.Trim());
                        command.Parameters.AddWithValue("@password", txtCont.Text.Trim());

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ClaseCompartida.nombre = reader["nombre"].ToString();
                                ClaseCompartida.apellido = reader["apellido"].ToString();
                                ClaseCompartida.idDepartamento = int.Parse(reader["idDepartamento"].ToString());
                                ClaseCompartida.departamnto = reader["nombreDepartamento"].ToString();

                                // ¡Inicio de sesión exitoso!
                                this.Hide();
                                md f1 = new md();
                                f1.ShowDialog();
                                this.Close();
                            }
                            else
                            {
                                // Inicio de sesión fallido
                                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        } // El reader se cierra solo aquí
                    } // La conexión se cierra sola aquí
                }
                catch (SqlException ex)
                {
                    // Si hay timeout o error de red, entra acá y NO se cierra el programa
                    MessageBox.Show("Error de base de datos: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    // Cualquier otro error general
                    MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }
    }
}
