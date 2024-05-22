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


    public partial class CargarProducto : Form
    {
        public EnumModoForm modo = EnumModoForm.Alta;
 
        public CargarProducto()
        {
            InitializeComponent();
            getCategorias();
           

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

                    if (rbOtroSi.Checked)
                    {
                        LimpiarControles();
                    }
                    else if (rbOtroNo.Checked)
                    {
                        this.Close();
                    }
                    else if (!rbOtroNo.Checked & !rbOtroSi.Checked)
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

        private void getCategorias()
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();

            string sql = "SELECT [id], [categoria] FROM [dbo].[categoria_productos]";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            cbCategoria.Items.Clear();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string categoria = reader.GetString(1);

                // Add category name to the ComboBox

                //cbcategorias.Items.Insert( categoria);
                cbCategoria.Items.Add(categoria);
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
                tbbarcode.Enabled = false;
                CargarDatos();
                tbstock.Enabled = false;
                groupBox1.Visible = false;
                rbOtroNo.Visible = false;
                rbOtroSi.Visible = false;
                btnCargar.Text = "Modificar";
            }
            if (modo == EnumModoForm.Consulta)
            {
                HabilitarControles(false);
                CargarDatos();
                btnCargar.Enabled = false;
                groupBox1.Visible = false;
                rbOtroNo.Visible = false;
                rbOtroSi.Visible = false;
                btnCargar.Visible = false;
            }
        }
        private void LimpiarControles()

        {
            cbCategoria.SelectedIndex = -1;
            tbbarcode.Text = "";
            tbdetalle.Text = "";
            tbprecio.Text = "";
            tbstock.Text = "";
        }

        private void HabilitarControles(bool habilitar)
        {
            cbCategoria.Enabled = habilitar;
            tbbarcode.Enabled = habilitar;
            tbdetalle.Enabled = habilitar;
            tbprecio.Enabled = habilitar;
            tbstock.Enabled = habilitar;

        }

       /* guardar sin comprobacion del lado del sql
        * private void Guardar()
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                string query = "INSERT INTO producto (categoria, barcode, detalle, stock, precio) VALUES (@categoria, @barcode, @detalle, @stock, @precio)";
                if (modo == EnumModoForm.Modificacion)
                {
                    query = "UPDATE producto SET categoria = @categoria, detalle = @detalle, stock = @stock, precio = @precio WHERE barcode = @barcode;";

                }



                

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@categoria", cbCategoria.SelectedIndex + 1);
                command.Parameters.AddWithValue("@barcode", int.Parse(tbbarcode.Text)); // Allow null for barcode
                command.Parameters.AddWithValue("@detalle", tbdetalle.Text);
                command.Parameters.AddWithValue("@stock", int.Parse(tbstock.Text));
                command.Parameters.AddWithValue("@precio", decimal.Parse(tbprecio.Text));

                command.ExecuteNonQuery();
            }
        } */

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
                        query = "UPDATE producto SET categoria = @categoria, detalle = @detalle, stock = @stock, precio = @precio WHERE barcode = @barcode;";
                    }
                    else
                    {
                        query = "INSERT INTO producto (categoria, barcode, detalle, stock, precio) VALUES (@categoria, @barcode, @detalle, @stock, @precio)";
                    }

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@categoria", cbCategoria.SelectedIndex + 1);
                    command.Parameters.AddWithValue("@barcode", int.Parse(tbbarcode.Text)); // Allow null for barcode (consider validation)
                    command.Parameters.AddWithValue("@detalle", tbdetalle.Text);
                    command.Parameters.AddWithValue("@stock", int.Parse(tbstock.Text));
                    command.Parameters.AddWithValue("@precio", decimal.Parse(tbprecio.Text));

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Success message (optional)
                        MessageBox.Show("¡Operación realizada con éxito!", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Handle potential errors here:
                        // - Check for specific exception types (e.g., SqlException)
                        // - Log the error for debugging
                        // - Provide a more informative error message to the user
                        MessageBox.Show("Ha ocurrido un error al guardar los datos. Por favor, intente nuevamente o contacte al soporte técnico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // Catch any unexpected exceptions
                MessageBox.Show("Se ha producido un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Log the exception for further investigation
            }
        }

        private void CargarDatos()
        {
            cbCategoria.SelectedIndex = ClaseCompartida.categoria - 1;
            tbbarcode.Text = ClaseCompartida.barcode.ToString();
            tbdetalle.Text = ClaseCompartida.detalle.ToString();
            tbprecio.Text = ClaseCompartida.precio.ToString();
            tbstock.Text = ClaseCompartida.stock.ToString();

        }
        private bool validarcontroles()
        {
            if(cbCategoria.SelectedIndex > -1)
            {
                if(tbbarcode.Text.Length > 0 && int.TryParse(tbbarcode.Text, out int barcode))
                {
                    if (tbdetalle.Text.Length > 0)
                    {
                        if(tbstock.Text.Length > 0)
                        {
                            if(tbprecio.Text.Length > 0 && (decimal.TryParse(tbprecio.Text, out decimal precio) || int.TryParse(tbprecio.Text, out int precioo)))
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
            }
        }

    }
    }

