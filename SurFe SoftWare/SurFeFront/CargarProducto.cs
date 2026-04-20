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
                }
                else if (modo == EnumModoForm.Modificacion)
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
            // 1. Validar Categoría
            // Si usaste el ID 0 para "Seleccione...", verificamos que sea mayor a 0
            if (cbCategoria.SelectedIndex <= -1)
            {
                MessageBox.Show("Debe seleccionar una categoría válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbCategoria.Focus();
                return false;
            }

            // 2. Validar Código de Barras (Barcode)
            // Verificamos que no esté vacío y que sea un número positivo
            if (string.IsNullOrWhiteSpace(tbbarcode.Text) || !long.TryParse(tbbarcode.Text, out long barcode) || barcode <= 0)
            {
                MessageBox.Show("El código de barras debe ser un número positivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbbarcode.Focus();
                return false;
            }

            // 3. Validar Detalle
            // Verificamos que tenga una descripción mínima para no cargar productos "fantasma"
            if (string.IsNullOrWhiteSpace(tbdetalle.Text) || tbdetalle.Text.Length < 3)
            {
                MessageBox.Show("El detalle debe tener al menos 3 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbdetalle.Focus();
                return false;
            }

            // 4. Validar Stock
            // No permitimos stock negativo (pueden ser 0, pero no -5)
            if (!int.TryParse(tbstock.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("El stock no puede ser un valor negativo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbstock.Focus();
                return false;
            }

            // 5. Validar Precio
            // El precio debe ser un número decimal mayor a 0
            if (!decimal.TryParse(tbprecio.Text.Replace(".", ","), out decimal precio) || precio <= 0)
            {
                MessageBox.Show("El precio debe ser un valor numérico mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbprecio.Focus();
                return false;
            }

            // Si pasó todas las pruebas
            return true;
        } 

    }
}

