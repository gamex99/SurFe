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
            Guardar();
            if (modo == EnumModoForm.Alta)
            {

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
                            LimpiarControles(); // Call your function to clear controls
                            break;
                        case DialogResult.No:
                            this.Close();
                            break;

                    }
                }
            }
            else { this.Close(); }
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
            }
            if (modo == EnumModoForm.Consulta)
            {
                HabilitarControles(false);
                CargarDatos();
                btnCargar.Enabled = false;
                groupBox1.Visible = false;
                rbOtroNo.Visible = false;
                rbOtroSi.Visible = false;
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

        private void Guardar()
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
        }

        private void CargarDatos()
        {
            cbCategoria.SelectedIndex = ClaseCompartida.categoria - 1;
            tbbarcode.Text = ClaseCompartida.barcode.ToString();
            tbdetalle.Text = ClaseCompartida.detalle.ToString();
            tbprecio.Text = ClaseCompartida.precio.ToString();
            tbstock.Text = ClaseCompartida.stock.ToString();

        }

    }
    }

