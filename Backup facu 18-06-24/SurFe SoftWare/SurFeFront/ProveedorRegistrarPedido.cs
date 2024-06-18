using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SurFeFront
{
    public partial class ProveedorRegistrarPedido : Form
    {
        public int id;
        public string razon_social;


        public ProveedorRegistrarPedido()
        {
            InitializeComponent();
            lbdetalle.Text = "";
            lbrazonsocial.Text = "";
            lbbarcode.Text = "";

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            SelectProducto formproducto = new SelectProducto();

            // Mostrar el formulario secundario y verificar si se hizo clic en "Aceptar"
            if (formproducto.ShowDialog() == DialogResult.OK)
            {/* barcode = row.Cells["barcode"].Value.ToString();
                detalle = row.Cells["detalle"].Value.ToString();
                stock = row.Cells["stock"].Value.ToString();
                precio = numeroConComa;*/



                // Obtener los datos del formulario secundario
                string barcode = formproducto.barcode;

                lbbarcode.Text = barcode;
                lbdetalle.Text = formproducto.detalle;





            }
        }

        private void btnbuscarproveedor_Click(object sender, EventArgs e)
        {
            ProveedorSelect form = new ProveedorSelect();

            // Mostrar el formulario secundario y verificar si se hizo clic en "Aceptar"
            if (form.ShowDialog() == DialogResult.OK)
            {


                id = form.id;

                razon_social = form.razon_social;



                lbrazonsocial.Text = razon_social;
            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(lbbarcode.Text, lbdetalle.Text, tbcantidad.Text);
            lbbarcode.Text = "";
            lbdetalle.Text = "";
            tbcantidad.Text = "";
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            //verificamos si esta la carpeta en temp total no tenemos que guardar este informe
            if (!Directory.Exists(ClaseCompartida.carpetaTemp))
            {
                // La carpeta no existe, crearla
                Directory.CreateDirectory(ClaseCompartida.carpetaTemp);

            }
            // hasta aca verificamos si esta la carpeta en temp total no tenemos que guardar este informe
            string directorioPrograma = AppDomain.CurrentDomain.BaseDirectory;
            string nombreArchivo = GetNombreArchivoFechaHora();
            string rutaCompletaArchivo = Path.Combine(directorioPrograma, nombreArchivo);
            //string rutaArchivoPDF = @"\elarchivo.pdf"; // Reemplace con la ruta y nombre deseados
            string rutaArchivoPDF = nombreArchivo;

            string PaginaHTML_Texto = "<!DOCTYPE html>\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n\r\n\r\n    <title>Título del Documento</title>\r\n    <style>\r\n        body {\r\n            font-family: 'Arial', sans-serif;\r\n            margin: 0;\r\n            padding: 0;\r\n            background-color: #f4f4f4;\r\n        }\r\n\r\n        .container {\r\n            width: 80%;\r\n            margin: auto;\r\n            background-color: #fff;\r\n            padding: 20px;\r\n            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\r\n        }\r\n\r\n        .header, .footer {\r\n            text-align: center;\r\n            padding: 10px 0;\r\n            color: #fff;\r\n        }\r\n\r\n        .header {\r\n            position: relative;\r\n            color: #fff;\r\n            background-color: #3498db;\r\n            padding: 10px 0;\r\n        }\r\n\r\n            .header img {\r\n                width: 250px;\r\n                height: auto;\r\n                position: absolute;\r\n            }\r\n\r\n            .header .left-img {\r\n                left: 10px;\r\n            }\r\n\r\n        .footer {\r\n            background-color: #f1c40f;\r\n        }\r\n\r\n        .main {\r\n            margin: 20px 0;\r\n        }\r\n\r\n        table {\r\n            width: 100%;\r\n            border-collapse: collapse;\r\n        }\r\n\r\n        th, td {\r\n            padding: 10px;\r\n            border: 1px solid #ddd;\r\n            text-align: left;\r\n        }\r\n\r\n        th {\r\n            background-color: #3498db;\r\n        }\r\n\r\n        .highlight {\r\n            background-color: #f1c40f;\r\n            color: #fff;\r\n        }\r\n\r\n        .total {\r\n            text-align: right;\r\n            font-weight: bold;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"container\">\r\n        <div class=\"header\">\r\n            <img src=\"./logo pp1 carpeta 2023.png\" class=\"left-img\" />\r\n            <h3>ORDEN DE COMPRA</h3>\r\n            <p> @Proveedor</p>\r\n            \r\n\r\n        </div>\r\n        <div class=\"main\">\r\n            <table>\r\n                <thead>\r\n                    <tr class=\"highlight\">\r\n                        <th>Barcode</th>\r\n                        <th>Descripción</th>\r\n                        <th>Stock</th>\r\n                        <th></th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n                    @FILAS\r\n                    <tr>\r\n                        \r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n        <div class=\"footer\">\r\n            <p></p>\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>\r\n\r\n";
            string filas = string.Empty;
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                filas += "<tr>";

                filas += "<td>" + row.Cells[0].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells[1].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells[2].Value.ToString() + "</td>";
                filas += "</tr>";

            }
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@Proveedor", DateTime.Now + "   " + lbrazonsocial.Text);
            using (FileStream stream = new FileStream(rutaArchivoPDF, FileMode.Create))
            {
                //Creamos un nuevo documento y lo definimos como PDF
                Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(new Phrase(""));

                //Agregamos la imagen del banner al documento
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(SurFeFront.Properties.Resources.logo_pp1_carpeta_2023, System.Drawing.Imaging.ImageFormat.Png);
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


            //aca guardamos en la db la orden de compra
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string sql = "INSERT INTO dbo.ordendecompra ([fecha], [id_proveedor], [location]) VALUES (@fecha, @id_proveedor, @location)";
            SqlCommand command = new SqlCommand(sql, connection);

            DateTime fechaActual = DateTime.Now;

            command.Parameters.AddWithValue("@fecha", fechaActual);
            command.Parameters.AddWithValue("@id_proveedor", id);
            command.Parameters.AddWithValue("@location", nombreArchivo);
            // connection.Open();
            command.ExecuteNonQuery();
            connection.Close();





            //hasta aca 









            PDFView formPDF = new PDFView(rutaCompletaArchivo);

            // Mostrar el formulario secundario y verificar si se hizo clic en "Aceptar"
            formPDF.ShowDialog();
            //eso es codigo para hacer el html del pdf
            // Cerrar el formulario Form1 después de cerrar el formulario Form2
            this.Close();
















        }
        private static string GetNombreArchivoFechaHora()
        {
            // Obtener la fecha y hora actual
            DateTime now = DateTime.Now;

            // Formatear la fecha y hora en un formato de nombre de archivo
            string nombreArchivoFormateado = now.ToString("yyyyMMdd_HHmmss");

            // Combinar el nombre con la extensión
            string nombreArchivo = nombreArchivoFormateado + "NotaDePedido" + ".pdf";

            // Devolver el nombre de archivo
            return nombreArchivo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
