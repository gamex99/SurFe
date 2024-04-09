using iTextSharp.tool.xml;
using SurFeEntidades;
using SurFeFront;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using System.IO;
using Document = iTextSharp.text.Document;
using iTextSharp.text.pdf;
using iTextSharp.tool;
using System.Diagnostics;


namespace SurFe
{
    public partial class Form2 : Form
    {
        private List<DetallesFactura> detalles = new List<DetallesFactura>();
        string cuit;
        string razonsocial;
        string domicilio;
        string localidad;
        string tipo_factura;
        public Form2()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Codigo", "Codigo");
            dataGridView1.Columns.Add("Cantidad", "Cantidad");
            dataGridView1.Columns.Add("Producto", "Producto");
            dataGridView1.Columns.Add("preciouni", "Precio Unitario");
            dataGridView1.Columns.Add("Precio", "Precio");

        }

        private void RecalcularSuma()
        {
            decimal SumaSubtotal = 0;
            decimal IVA = 0;
            decimal total = 0;

            // Iterar a través de todas las filas en la columna "ColumnaNumerica"
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Verificar si la celda no está vacía
                if (row.Cells["Precio"].Value != null)
                {
                    // Sumar el valor de la celda a la variable suma
                    SumaSubtotal += Convert.ToDecimal(row.Cells["Precio"].Value);

                }
            }
            IVA = SumaSubtotal * (decimal).21;
            total = SumaSubtotal + IVA;
            // Mostrar la suma en algún lugar, como un TextBox
            subtotal.Text = SumaSubtotal.ToString();
            labeliva.Text = IVA.ToString();
            labeltotal.Text = total.ToString();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RecalcularSuma();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectClienteVenta form = new SelectClienteVenta();

            // Mostrar el formulario secundario y verificar si se hizo clic en "Aceptar"
            if (form.ShowDialog() == DialogResult.OK)
            {
                // Obtener los datos del formulario secundario
                //string cuit = form.cuitselect;
                //string razonsocial = form.razonsocialselect;
                //string domicilio = form.domicilio;
                //string localidad = form.localidad;
                //string tipo_factura = form.factura_tipo;


                cuit = form.cuitselect;
                razonsocial = form.razonsocialselect;
                domicilio = form.domicilio;
                localidad = form.localidad;
                tipo_factura = form.factura_tipo;


                // Puedes usar los datos como desees, por ejemplo, mostrarlos en un MessageBox
                labelrazonsocial.Text = "Razon Social: " + razonsocial;
                /*
                 *  cuitselect = row.Cells["cuit"].Value.ToString();
                razonsocialselect = row.Cells["razon_social"].Value.ToString();
                domicilio = row.Cells["domicilio"].Value.ToString();
                localidad = row.Cells["localidad_loc"].Value.ToString();
                factura_tipo = row.Cells["tipofactura"].Value.ToString();*/

                labelcuit.Text = "CUIT: " + cuit;
                labeldireccion.Text = "Direccion: " + domicilio;
                labellocalidad.Text = "Localidad: " + localidad;

                int.TryParse(tipo_factura, out int tipo_facutra_cbx);
                cbxfactura.SelectedIndex = tipo_facutra_cbx;
            }
        }

        private void btnbuscarart_Click(object sender, EventArgs e)
        {
            SelectProductoVenta formproducto = new SelectProductoVenta();

            // Mostrar el formulario secundario y verificar si se hizo clic en "Aceptar"
            if (formproducto.ShowDialog() == DialogResult.OK)
            {/* barcode = row.Cells["barcode"].Value.ToString();
                detalle = row.Cells["detalle"].Value.ToString();
                stock = row.Cells["stock"].Value.ToString();
                precio = numeroConComa;*/



                // Obtener los datos del formulario secundario
                string barcode = formproducto.barcode;

                txtcodigo.Text = barcode;




            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filtro = txtcodigo.Text;
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            string barcode = "";
            string detalle = "";
            decimal precio = (decimal)00;
            int stock = 0;
            int cantidad = int.Parse(txtcantidad.Text);


            using (SqlConnection connection = new SqlConnection(conString))
            {
                using (SqlCommand command = new SqlCommand("SelectProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Ajusta el nombre del parámetro y su valor según tus necesidades
                    command.Parameters.AddWithValue("@filtro", filtro);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Asigna los valores a las variables
                                barcode = reader["barcode"].ToString();
                                detalle = reader["detalle"].ToString();
                                precio = Convert.ToDecimal(reader["precio"]);
                                stock = Convert.ToInt32(reader["stock"]);


                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            if (stock > 0)
            {
                decimal totalart = precio * cantidad;
                dataGridView1.Rows.Add(barcode, cantidad, detalle, precio, totalart, stock);
                RecalcularSuma();
            }
            else
            {
                MessageBox.Show("NO HAY EN STOCK: " + detalle, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class DetallesFactura
        {
            public string Barcode { get; set; }
            public string Detalle { get; set; }
            public int Cantidad { get; set; }
            public decimal PrecioUnitario { get; set; }
            public decimal TotalPorProducto { get; set; }
        }

        private void CargarDatosDesdeDataGridView()
        {
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                // Asegurarse de no procesar la última fila vacía si es editable
                if (fila.IsNewRow) continue;

                // Crear un nuevo producto y asignar los valores desde las celdas del DataGridView
                DetallesFactura nuevoProducto = new DetallesFactura
                {
                    Barcode = fila.Cells["barcode"].Value.ToString(),
                    Detalle = fila.Cells["detalle"].Value.ToString(),
                    Cantidad = Convert.ToInt32(fila.Cells["cantidad"].Value),
                    PrecioUnitario = Convert.ToDecimal(fila.Cells["precio"].Value),
                    TotalPorProducto = Convert.ToDecimal(fila.Cells["totalart"].Value)
                };

                // Agregar el producto a la lista
                detalles.Add(nuevoProducto);
            }

            // Ahora, 'productos' contiene la información del DataGridView en una lista de objetos Producto
            // Puedes acceder a los elementos de la lista según tus necesidades.
        }

        private void GuardarDatosEnBaseDeDatos()
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

            string consultaSql = "INSERT INTO TuTabla (Barcode, Detalle, Cantidad, PrecioUnitario, TotalPorProducto) " +
                                 "VALUES (@Barcode, @Detalle, @Cantidad, @PrecioUnitario, @TotalPorProducto); SELECT SCOPE_IDENTITY();";

            using (SqlConnection conexion = new SqlConnection(conString))

                try
                {
                    conexion.Open();

                    foreach (DetallesFactura detalle in detalles)
                    {
                        using (SqlCommand comando = new SqlCommand(consultaSql, conexion))
                        {
                            // Configurar los parámetros del comando
                            comando.Parameters.AddWithValue("@Barcode", detalle.Barcode);
                            comando.Parameters.AddWithValue("@Detalle", detalle.Detalle);
                            comando.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                            comando.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);
                            comando.Parameters.AddWithValue("@TotalPorProducto", detalle.TotalPorProducto);

                            // Ejecutar la consulta de inserción
                            comando.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Datos guardados en la base de datos con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar los datos en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //METEMOS CODIGO PARA HACER EL PDF backup
        


            //string PaginaHTML_Texto = "<table border=\"1\"><tr><td>HOLA MUNDO</td></tr></table>";
            string rutaArchivoPDF = @"C:\PDF\elarchivo.pdf"; // Reemplace con la ruta y nombre deseados
            string PaginaHTML_Texto = SurFeFront.Properties.Resources.Plantilla.ToString();
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CLIENTE", razonsocial);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DOCUMENTO", cuit);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));

            string filas = string.Empty;
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Codigo"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["preciouni"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Precio"].Value.ToString() + "</td>";
                filas += "</tr>";
                total += decimal.Parse(row.Cells["Precio"].Value.ToString());
            }
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@TOTAL", total.ToString());





            using (FileStream stream = new FileStream(rutaArchivoPDF, FileMode.Create))
            {
                //Creamos un nuevo documento y lo definimos como PDF
                Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(new Phrase(""));

                //Agregamos la imagen del banner al documento
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(SurFeFront.Properties.Resources.shop, System.Drawing.Imaging.ImageFormat.Png);
                img.ScaleToFit(60, 60);
                img.Alignment = iTextSharp.text.Image.UNDERLYING;

                //img.SetAbsolutePosition(10,100);
                img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                pdfDoc.Add(img);


                //pdfDoc.Add(new Phrase("Hola Mundo"));
                using (StringReader sr = new StringReader(PaginaHTML_Texto))
                {
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                }

                pdfDoc.Close();
                stream.Close();
            }

            PDFView formPDF = new PDFView();

            // Mostrar el formulario secundario y verificar si se hizo clic en "Aceptar"
            formPDF.ShowDialog();
            //eso es codigo para hacer el html del pdf

        }


    }
}
