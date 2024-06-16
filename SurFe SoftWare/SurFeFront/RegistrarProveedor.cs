using iTextSharp.text.pdf;
using SurFeEntidades;
using SurFeFront;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurFe
{


    public partial class RegistrarProveedor : Form
    {
        public EnumModoForm modo = EnumModoForm.Alta;
 
        public RegistrarProveedor()
        {
            InitializeComponent();
            getLocalidades();
           

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validarcontroles() == true)
            {

                
                if (modo == EnumModoForm.Alta)
                { 
                    Guardar();

                   
                    {
                        DialogResult result = MessageBox.Show("¿Desea cargar otro producto?", "Mensaje de confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        switch (result)
                        {
                            case DialogResult.Yes:
                                LimpiarControles(); 
                                break;
                            case DialogResult.No:
                                this.Close();
                                break;

                        }
                    }
                } else if (modo == EnumModoForm.Modificacion)
                {
                    DialogResult result = MessageBox.Show("¿Esta seguro que desea guardar las modificaciones?", "Mensaje de confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    switch (result)
                    {
                        case DialogResult.Yes:
                            Guardar();
                            this.Close();
                            break;
                        case DialogResult.No:
                            
                            break;

                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void getLocalidades()
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();

            string sql = "SELECT [id], [localidad] FROM [dbo].[localidad]";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            cblocalidad.Items.Clear();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string categoria = reader.GetString(1);

                // Add category name to the ComboBox

                //cbcategorias.Items.Insert( categoria);
                cblocalidad.Items.Add(categoria);
            }
            reader.Close();
            connection.Close();
        }

        private void CargarProducto_Load(object sender, EventArgs e)
        {
            if (modo == EnumModoForm.Alta)
            {
                LimpiarControles();
                HabilitarControles(true);
                
            }
            if (modo == EnumModoForm.Modificacion)
            {
                HabilitarControles(true);
                tbcuit.Enabled = false;
                CargarDatos();
                tbtel.Enabled = false;
                
                btnCargar.Text = "Modificar";
            }
            if (modo == EnumModoForm.Consulta)
            {
                HabilitarControles(false);
                CargarDatos();
                btnCargar.Enabled = false;
                
                btnCargar.Visible = false;
            }
        }
        private void LimpiarControles()

        {
            cblocalidad.SelectedIndex = -1;
            tbcuit.Text = "";
            tbdireccion.Text = "";
            tbcorreo.Text = "";
            tbtel.Text = "";
        }

        private void HabilitarControles(bool habilitar)
        {
            cblocalidad.Enabled = habilitar;
            tbcuit.Enabled = habilitar;
            tbdireccion.Enabled = habilitar;
            tbcorreo.Enabled = habilitar;
            tbtel.Enabled = habilitar;

        }

     

        private void Guardar()
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    connection.Open();

                    string query;
                    if (modo == EnumModoForm.Modificacion)
                    {
                        query = "UPDATE proveedor SET razon_social = @razon_social,   cuit = @cuit,    direccion = @direccion,   idLocalidad = @idLocalidad,   tel = @tel,   correo = @correo WHERE CUIT = @cuit;";
                    }
                    else
                    {
                        query = "INSERT INTO proveedor (razon_social, cuit, direccion, idLocalidad, tel, correo ) VALUES (@razon_social, @cuit, @direccion, @idLocalidad, @tel, @correo)";
                    }

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@razon_social", tbrazonsocial.Text);
                    command.Parameters.AddWithValue("@idlocalidad", cblocalidad.SelectedIndex + 1);
                    command.Parameters.AddWithValue("@cuit", long.Parse(tbcuit.Text)); // Allow null for barcode (consider validation)
                    command.Parameters.AddWithValue("@direccion", tbdireccion.Text);
                    command.Parameters.AddWithValue("@tel", long.Parse(tbtel.Text));
                    command.Parameters.AddWithValue("@correo", tbcorreo.Text);


                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        
                        MessageBox.Show("¡Operación realizada con éxito!", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                       
                        MessageBox.Show("Ha ocurrido un error al guardar los datos. Por favor, intente nuevamente o contacte al soporte técnico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
            }
        }

        private void CargarDatos()
        {
            
            cblocalidad.SelectedIndex = ClaseCompartida.idlocalidad - 1;
            tbrazonsocial.Text = ClaseCompartida.razon_rosial;
            tbcuit.Text = ClaseCompartida.cuit.ToString();
            tbdireccion.Text = ClaseCompartida.direccion.ToString();
            tbcorreo.Text = ClaseCompartida.correo.ToString();
            tbtel.Text = ClaseCompartida.tel.ToString();
            tbcorreo.Text = ClaseCompartida.correo.ToString();

        }
        private bool validarcontroles()
        {
            /* if(cblocalidad.SelectedIndex > -1)
             {
                 if(tbcuit.Text.Length > 0 && int.TryParse(tbcuit.Text, out int barcode))
                 {
                     if (tbdireccion.Text.Length > 0)
                     {
                         if(tbtel.Text.Length > 0)
                         {
                             if(tbcorreo.Text.Length > 0 )
                             {
                                 return true;
                             }
                             else
                             {
                                 MessageBox.Show("Falta cargar precio o no es decimal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                 return false;
                             }

                         }
                         else
                         {
                             MessageBox.Show("Falta cargar stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                             return false;
                         }

                     }
                     else
                     {
                         MessageBox.Show("Falta cargar detalle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         return false;
                     }
                 }
                 else { 
                     MessageBox.Show("Falta cargar barcode o no es un numero entero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return false;
                 }
             } else
             {
                 MessageBox.Show("Cargar Categoria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return false;
             }*/
            return true;

        }

    }
    }

