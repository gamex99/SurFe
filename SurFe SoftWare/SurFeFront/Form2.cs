﻿using iTextSharp.tool.xml;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static iTextSharp.text.pdf.events.IndexEvents;


namespace SurFe
{
    public partial class Form2 : Form
    {
        private List<DetallesFactura> detalles = new List<DetallesFactura>();
        string cuit;
        string razonsocial;
        string domicilio;
        string localidad;
        int tipo_factura;
        string id_cliente1;
        int numero_factura;
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

                id_cliente1 = form.id_clienteselect;
                cuit = form.cuitselect;
                razonsocial = form.razonsocialselect;
                domicilio = form.domicilio;
                localidad = form.localidad;
                //tipo_factura = int.TryParse(form.factura_tipo);
                int.TryParse(form.factura_tipo, out tipo_factura);

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
                cbxfactura.SelectedIndex = tipo_factura;

                //cbxfactura.SelectedIndex = tipo_facutra_cbx;
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
            //aca metemos codigo para traer el numero de factura de la db 

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            int numero = 0;
           
            
               
                
                    connection.Open();

                    string sqlQuery = "SELECT [numero] FROM [dbo].[numero_factura] WHERE [id_numero] = 1 ;";
                    SqlCommand command2 = new SqlCommand(sqlQuery, connection);

                    using (SqlDataReader reader = command2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                             numero = reader.GetInt32(0);

                           
                        }
                    }
               
            
           

            string cadena = numero.ToString();

            if (cadena.Length > 5)
            {
                // Trunca si tiene más de 5 caracteres
                cadena = cadena.Substring(0, 5);
            }
            else if (cadena.Length < 5)
            {
                // Rellena con ceros si tiene menos de 5 caracteres
                cadena = cadena.PadLeft(5, '0');
            }

            //hasta aca el numero de factura


            //METEMOS CODIGO PARA HACER EL PDF backup



            //string PaginaHTML_Texto = "<table border=\"1\"><tr><td>HOLA MUNDO</td></tr></table>";
            string directorioPrograma = AppDomain.CurrentDomain.BaseDirectory;
            string nombreArchivo = GetNombreArchivoFechaHora();
            string rutaCompletaArchivo = Path.Combine(directorioPrograma, nombreArchivo);
            //string rutaArchivoPDF = @"\elarchivo.pdf"; // Reemplace con la ruta y nombre deseados
            string rutaArchivoPDF = nombreArchivo;
            //string PaginaHTML_Texto = SurFeFront.Properties.Resources.Plantilla.ToString();
            string PaginaHTML_Texto = "<!DOCTYPE html>\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <title>Título del Documento</title>\r\n    <style>\r\n        body {\r\n            font-family: 'Arial', sans-serif;\r\n            margin: 0;\r\n            padding: 0;\r\n            background-color: #f4f4f4;\r\n        }\r\n        .container {\r\n            width: 80%;\r\n            margin: auto;\r\n            background-color: #fff;\r\n            padding: 20px;\r\n            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\r\n        }\r\n        .header, .footer {\r\n            text-align: center;\r\n            padding: 10px 0;\r\n            color: #fff;\r\n        }\r\n        .header {\r\n            position: relative; \r\n            color: #fff; \r\n            background-color: #3498db; \r\n            padding: 10px 0; \r\n        }\r\n        .header img {\r\n            width: 250px; \r\n            height: auto; \r\n            position: absolute; \r\n        }\r\n        .header .left-img {\r\n            left: 10px; \r\n        }\r\n        .footer {\r\n            background-color: #f1c40f; \r\n        }\r\n        .main {\r\n            margin: 20px 0;\r\n        }\r\n        table {\r\n            width: 100%;\r\n            border-collapse: collapse;\r\n        }\r\n        th, td {\r\n            padding: 10px;\r\n            border: 1px solid #ddd;\r\n            text-align: left;\r\n        }\r\n        th {\r\n            background-color: #3498db; \r\n        }\r\n        .highlight {\r\n            background-color: #f1c40f; \r\n            color: #fff; \r\n        }\r\n        .total {\r\n            text-align: right;\r\n            font-weight: bold;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"container\">\r\n        <div class=\"header\">\r\n            <img src=\"./logo pp1 carpeta 2023.png\" class=\"left-img\" />\r\n            <h4>CODIGO ESTUDIANTE</h4>\r\n            <p>Dirección: av. las águilas 123</p>\r\n            <p>Teléfono: 567-546-55</p>\r\n            \r\n        </div>\r\n        <div class=\"main\">\r\n            <table>\r\n                <tr>\r\n                    <td>RUC: 3434343434</td>\r\n                    <td class=\"highlight\">Presupuesto</td>\r\n                    <td>Nro: 0002-@NUMERO</td>\r\n                </tr>\r\n            </table>\r\n            <table>\r\n                <tr>\r\n                    <td>Cliente:</td>\r\n                    <td style=\"border-bottom:1px solid black\">@CLIENTE</td>\r\n                </tr>\r\n                <tr>\r\n                    <td>Cuit:</td>\r\n                    <td style=\"border-bottom:1px solid black\">@DOCUMENTO</td>\r\n                    <td>Fecha:</td>\r\n                    <td style=\"border-bottom:1px solid black\">@FECHA</td>\r\n                </tr>\r\n            </table>\r\n            <table>\r\n                <thead>\r\n                    <tr class=\"highlight\">\r\n                        <th>Cant.</th>\r\n                        <th>Descripción</th>\r\n                        <th>P. Unitario</th>\r\n                        <th>Importe</th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n                    @FILAS\r\n                    <tr>\r\n                        <td colspan=\"3\" class=\"total\">Total:</td>\r\n                        <td>@TOTAL</td>\r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n        <div class=\"footer\">\r\n            <p>Gracias por su compra</p>\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>";
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CLIENTE", razonsocial);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DOCUMENTO", cuit);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NUMERO", cadena);

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
            }// aca vamo a mandar a la base de dato antes de abrir el pdf porque sino desp se traba y no anda pa 

            string tipo_documento = tipo_factura.ToString();
           // string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
           // SqlConnection connection = new SqlConnection(connectionString);
            string sql = "INSERT INTO dbo.factura ([id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (@id_cliente, @tipo_documento, @fecha, @total, @location)";
            SqlCommand command = new SqlCommand(sql, connection);

            DateTime fechaActual = DateTime.Now;
            command.Parameters.AddWithValue("@id_cliente", id_cliente1);
            command.Parameters.AddWithValue("@tipo_documento", tipo_documento);
            command.Parameters.AddWithValue("@fecha", fechaActual);
            command.Parameters.AddWithValue("@total", total);
            command.Parameters.AddWithValue("@location", nombreArchivo);
           // connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            //hasta aca guardamos en la db
















            //hasta aca guardamos en la db

            PDFView formPDF = new PDFView(rutaCompletaArchivo);

            // Mostrar el formulario secundario y verificar si se hizo clic en "Aceptar"
            formPDF.ShowDialog();
            //eso es codigo para hacer el html del pdf

        }
        private static string GetNombreArchivoFechaHora()
        {
            // Obtener la fecha y hora actual
            DateTime now = DateTime.Now;

            // Formatear la fecha y hora en un formato de nombre de archivo
            string nombreArchivoFormateado = now.ToString("yyyyMMdd_HHmmss");

            // Combinar el nombre con la extensión
            string nombreArchivo = nombreArchivoFormateado + ".pdf";

            // Devolver el nombre de archivo
            return nombreArchivo;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
