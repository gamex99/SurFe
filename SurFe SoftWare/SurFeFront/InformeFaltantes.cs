using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;

namespace SurFeFront
{
    public partial class InformeFaltantes : Form
    {
        public InformeFaltantes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnmostrar_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);

            string sql = "select barcode, detalle , stock from producto where stock < @stockfaltante";
            SqlCommand command = new SqlCommand(sql, connection);


            SqlDataAdapter adapter = new SqlDataAdapter(command);
            System.Data.DataSet dataSet = new System.Data.DataSet();
            connection.Open();
            command.Parameters.AddWithValue("@stockfaltante", int.Parse(textBox1.Text));
            adapter.Fill(dataSet, "productosfaltantes");
            connection.Close();
            dataGridView1.DataSource = dataSet.Tables["productosfaltantes"];
        }

        private void btnimprimir_Click(object sender, EventArgs e)
        {   //verificamos si esta la carpeta en temp total no tenemos que guardar este informe
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
            //string PaginaHTML_Texto = SurFeFront.Properties.Resources.Plantilla.ToString();
            //string PaginaHTML_Texto = "<!DOCTYPE html>\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <title>Título del Documento</title>\r\n    <style>\r\n        body {\r\n            font-family: 'Arial', sans-serif;\r\n            margin: 0;\r\n            padding: 0;\r\n            background-color: #f4f4f4;\r\n        }\r\n        .container {\r\n            width: 80%;\r\n            margin: auto;\r\n            background-color: #fff;\r\n            padding: 20px;\r\n            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\r\n        }\r\n        .header, .footer {\r\n            text-align: center;\r\n            padding: 10px 0;\r\n            color: #fff;\r\n        }\r\n        .header {\r\n            background-color: #3498db;\r\n            color: #fff;\r\n            display: flex;\r\n            justify-content: space-between;\r\n            align-items: center;\r\n        }\r\n        .header .info {\r\n            flex: 2;\r\n            text-align: center;\r\n        }\r\n        .header .mas-info {\r\n            flex: 3;\r\n            text-align: left;\r\n            height: 150px;\r\n        }\r\n        .header .logo {\r\n            width: auto;\r\n            margin-top: 0px;\r\n            flex: 1;\r\n            text-align: center;\r\n        }\r\n        img {\r\n            width: 200px;\r\n            height:200px;\r\n        }\r\n        .footer {\r\n            margin-top: 10px;\r\n            color: black;\r\n            display: flex;\r\n            justify-content: space-between;\r\n            align-items: center;\r\n        }\r\n        .main {\r\n            margin: 10px 0;\r\n        }\r\n        table {\r\n            width: 100%;\r\n            border-collapse: collapse;\r\n        }\r\n        th, td {\r\n            padding: 10px;\r\n            border: 1px solid #ddd;\r\n            text-align: left;\r\n        }\r\n        th {\r\n            background-color: #3498db;\r\n            color: white;\r\n        }\r\n        .highlight {\r\n            background-color: #f1c40f;\r\n            color: #fff;\r\n        }\r\n        .total {\r\n            text-align: right;\r\n            font-weight: bold;\r\n        }\r\n        .cliente {\r\n            margin-top: 10px;\r\n        }\r\n        .productos {\r\n\r\n        }\r\n        #con {\r\n            width: 200px;\r\n        }\r\n        .logo-footer {\r\n            text-align: left;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"container\">\r\n        <div class=\"header\">\r\n            <div class=\"logo\">\r\n                <img src=\"https://via.placeholder.com/200\" />\r\n            </div>\r\n            <div class=\"info\">\r\n                <h1>@LETRA_FACTURA</h1>\r\n                <p>Dirección: Bolivar 325,Peyrano, Santa Fe</p>\r\n                <p>Teléfono: 3416082000</p>\r\n            </div>\r\n            <div class=\"mas-info\">\r\n                <p>Fecha de emision: @FECHAHOY</p>\r\n                <p>Cuit: 20-21950728-4</p>\r\n                <p>Ingresos Brutos: 102-009216-1</p>\r\n                <p>Inicio de actividades: 20/05/2005</p>\r\n            </div>\r\n        </div>\r\n        \r\n        <div class=\"main\">       \r\n            <table class=\"cliente\">\r\n                <tr>\r\n                    <td id=\"con\">Cliente:</td>\r\n                    <td style=\"border-bottom:1px solid black\">@CLIENTE</td>\r\n                </tr>\r\n                <tr>\r\n                    <td id=\"con\">Domicilio:</td>\r\n                    <td style=\"border-bottom:1px solid black\">@DOMICILIO</td>\r\n                </tr>\r\n                <tr>\r\n                    <td id=\"con\">Cond iva:</td>\r\n                    <td style=\"border-bottom:1px solid black\">@IVA</td>\r\n                </tr>\r\n                <tr>\r\n                    <td id=\"con\">CUIT:</td>\r\n                    <td style=\"border-bottom:1px solid black\">@CUITCLIENTE</td>\r\n                </tr>\r\n                \r\n            </table>\r\n        </div>\r\n        <div class=\"productos\">    \r\n            <table>\r\n                <thead>\r\n                    <tr class=\"highlight\">\r\n                        <th>Cod.</th>\r\n                        <th>Descripción</th>\r\n                        <th>Cant.</th>\r\n                        <th>U.Medida</th>\r\n                        <th>P.Unitario</th>\r\n                        <th>Alic iva</th>\r\n                        <th>Importe</th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n                    @FILAS \r\n                    <tr>\r\n                        <td colspan=\"3\" class=\"total\">Total:</td>\r\n                        <td>@NETO</td>\r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n        <div class=\"footer\">\r\n            <div class=\"footer-uno\">\r\n                <table>\r\n                    <tr>\r\n                        <td id=\"con\">Importe neto </td>\r\n                        <td style=\"border-bottom:1px solid black\">@NETO</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td id=\"con\">IVA 21% </td>\r\n                        <td style=\"border-bottom:1px solid black\">@NETOIVA</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td id=\"con\">IVA 10,5%</td>\r\n                        <td style=\"border-bottom:1px solid black\">0.00</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td id=\"con\">Importe otros tributos:</td>\r\n                        <td style=\"border-bottom:1px solid black\">0.00</td>\r\n                    </tr>            \r\n                    <tr>\r\n                        <td id=\"con\">TOTAL</td>\r\n                        <td style=\"border-bottom:1px solid black\">@TOTAL</td>\r\n                    </tr>\r\n                </table>\r\n            </div>\r\n            <div class=\"logo-footer\">\r\n                <p>CAE N : @CAE</p>\r\n                <img src=\"https://via.placeholder.com/200\" />\r\n                <p> Muchas gracias por su compra, vuelva pronto</p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>";
            string PaginaHTML_Texto = "<!DOCTYPE html>\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <title>Título del Documento</title>\r\n    <style>\r\n        body {\r\n            font-family: 'Arial', sans-serif;\r\n            margin: 0;\r\n            padding: 0;\r\n            background-color: #f4f4f4;\r\n        }\r\n        .container {\r\n            width: 80%;\r\n            margin: auto;\r\n            background-color: #fff;\r\n            padding: 20px;\r\n            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\r\n        }\r\n        .header, .footer {\r\n            text-align: center;\r\n            padding: 10px 0;\r\n            color: #fff;\r\n        }\r\n        .header {\r\n            background-color: #3498db;\r\n            color: #fff;\r\n            display: flex;\r\n            justify-content: space-between;\r\n            align-items: center;\r\n        }\r\n        .header .info {\r\n            flex: 2;\r\n            text-align: center;\r\n        }\r\n        .header .mas-info {\r\n            flex: 3;\r\n            text-align: left;\r\n            height: 150px;\r\n        }\r\n        .header .logo {\r\n            width: auto;\r\n            margin-top: 0px;\r\n            flex: 1;\r\n            text-align: center;\r\n        }\r\n        img {\r\n            width: 200px;\r\n            height:200px;\r\n        }\r\n        .footer {\r\n            margin-top: 10px;\r\n            color: black;\r\n            display: flex;\r\n            justify-content: space-between;\r\n            align-items: center;\r\n        }\r\n        .main {\r\n            margin: 10px 0;\r\n        }\r\n        table {\r\n            width: 100%;\r\n            border-collapse: collapse;\r\n        }\r\n        th, td {\r\n            padding: 10px;\r\n            border: 1px solid #ddd;\r\n            text-align: left;\r\n        }\r\n        th {\r\n            background-color: #3498db;\r\n            color: white;\r\n        }\r\n        .highlight {\r\n            background-color: #f1c40f;\r\n            color: #fff;\r\n        }\r\n        .total {\r\n            text-align: right;\r\n            font-weight: bold;\r\n        }\r\n        .cliente {\r\n            margin-top: 10px;\r\n        }\r\n        .productos {\r\n\r\n        }\r\n        #con {\r\n            width: 200px;\r\n        }\r\n        .logo-footer {\r\n            text-align: left;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"container\">\r\n        <div class=\"header\">\r\n            <div class=\"logo\">\r\n                <img src=\"https://via.placeholder.com/200\" />\r\n            </div>\r\n            <div class=\"info\">\r\n                <h1>@LETRA_FACTURA</h1>\r\n                <p>Dirección: Bolivar 325,Peyrano, Santa Fe</p>\r\n                <p>Teléfono: 3416082000</p>\r\n            </div>\r\n            <div class=\"mas-info\">\r\n                <p>Fecha de emision: @FECHAHOY</p>\r\n                <p>Cuit: 20-21950728-4</p>\r\n                <p>Ingresos Brutos: 102-009216-1</p>\r\n                <p>Inicio de actividades: 20/05/2005</p>\r\n            </div>\r\n        </div>\r\n        \r\n        <div class=\"main\">       \r\n            <table class=\"cliente\">\r\n                <tr>\r\n                    <td id=\"con\">Cliente:</td>\r\n                    <td style=\"border-bottom:1px solid black\">@CLIENTE</td>\r\n                </tr>\r\n                <tr>\r\n                    <td id=\"con\">Domicilio:</td>\r\n                    <td style=\"border-bottom:1px solid black\">@DOMICILIO</td>\r\n                </tr>\r\n                <tr>\r\n                    <td id=\"con\">Cond iva:</td>\r\n                    <td style=\"border-bottom:1px solid black\">@IVA</td>\r\n                </tr>\r\n                <tr>\r\n                    <td id=\"con\">CUIT:</td>\r\n                    <td style=\"border-bottom:1px solid black\">@CUITCLIENTE</td>\r\n                </tr>\r\n                \r\n            </table>\r\n        </div>\r\n        <div class=\"productos\">    \r\n            <table>\r\n                <thead>\r\n                    <tr class=\"highlight\">\r\n                        <th>Cod.</th>\r\n                        \r\n                        <th>Cant.</th>\r\n                        <th>Descripción</th>\r\n                        \r\n                        <th>P.Unitario</th>\r\n                       \r\n                        <th>Importe</th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n                    @FILAS \r\n                    <tr>\r\n                        <td colspan=\"3\" class=\"total\">Total:</td>\r\n                        <td>@NETO</td>\r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n        <div class=\"footer\">\r\n            <div class=\"footer-uno\">\r\n                <table>\r\n                    <tr>\r\n                        <td id=\"con\">Importe neto </td>\r\n                        <td style=\"border-bottom:1px solid black\">@NETO</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td id=\"con\">IVA 21% </td>\r\n                        <td style=\"border-bottom:1px solid black\">@ALGOIVA</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td id=\"con\">IVA 10,5%</td>\r\n                        <td style=\"border-bottom:1px solid black\">0.00</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td id=\"con\">Importe otros tributos:</td>\r\n                        <td style=\"border-bottom:1px solid black\">0.00</td>\r\n                    </tr>            \r\n                    <tr>\r\n                        <td id=\"con\">TOTAL</td>\r\n                        <td style=\"border-bottom:1px solid black\">@TOTAL</td>\r\n                    </tr>\r\n                </table>\r\n            </div>\r\n            <div class=\"logo-footer\">\r\n                <p>CAE N : @CAE</p>\r\n                <img src=\"https://via.placeholder.com/200\" />\r\n                <p> Muchas gracias por su compra, vuelva pronto</p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>";
            //string PaginaHTML_Texto = "<!DOCTYPE html>\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <title>Título del Documento</title>\r\n    <style>\r\n        body {\r\n            font-family: 'Arial', sans-serif;\r\n            margin: 0;\r\n            padding: 0;\r\n            background-color: #f4f4f4;\r\n        }\r\n        .container {\r\n            width: 80%;\r\n            margin: auto;\r\n            background-color: #fff;\r\n            padding: 20px;\r\n            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\r\n        }\r\n        .header, .footer {\r\n            text-align: center;\r\n            padding: 10px 0;\r\n            color: #fff;\r\n        }\r\n        .header {\r\n            background-color: #3498db;\r\n            color: #fff;\r\n            display: flex;\r\n            justify-content: space-between;\r\n            align-items: center;\r\n        }\r\n        .header .info {\r\n            flex: 2;\r\n            text-align: center;\r\n        }\r\n        .header .mas-info {\r\n            flex: 3;\r\n            text-align: left;\r\n            height: 150px;\r\n        }\r\n        .header .logo {\r\n            width: auto;\r\n            margin-top: 0px;\r\n            flex: 1;\r\n            text-align: center;\r\n        }\r\n        img {\r\n            width: 200px;\r\n            height:200px;\r\n        }\r\n        .footer {\r\n            margin-top: 10px;\r\n            color: black;\r\n            display: flex;\r\n            justify-content: space-between;\r\n            align-items: center;\r\n        }\r\n        .main {\r\n            margin: 10px 0;\r\n        }\r\n        table {\r\n            width: 100%;\r\n            border-collapse: collapse;\r\n        }\r\n        th, td {\r\n            padding: 10px;\r\n            border: 1px solid #ddd;\r\n            text-align: left;\r\n        }\r\n        th {\r\n            background-color: #3498db;\r\n            color: white;\r\n        }\r\n        .highlight {\r\n            background-color: #f1c40f;\r\n            color: #fff;\r\n        }\r\n        .total {\r\n            text-align: right;\r\n            font-weight: bold;\r\n        }\r\n        .cliente {\r\n            margin-top: 10px;\r\n        }\r\n        .productos {\r\n\r\n        }\r\n        #con {\r\n            width: 200px;\r\n        }\r\n        .logo-footer {\r\n            text-align: left;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"container\">\r\n        <div class=\"header\">\r\n            <div class=\"logo\">\r\n                <img src=\"https://via.placeholder.com/200\" />\r\n            </div>\r\n            <div class=\"info\">\r\n                <h1>@LETRA_FACTURA</h1>\r\n                <p>Dirección: Bolivar 325,Peyrano, Santa Fe</p>\r\n                <p>Teléfono: 3416082000</p>\r\n            </div>\r\n            <div class=\"mas-info\">\r\n                <p>Fecha de emision: @FECHAHOY</p>\r\n                <p>Cuit: 20-21950728-4</p>\r\n                <p>Ingresos Brutos: 102-009216-1</p>\r\n                <p>Inicio de actividades: 20/05/2005</p>\r\n            </div>\r\n        </div>\r\n        \r\n        <div class=\"main\">       \r\n            <table class=\"cliente\">\r\n                <tr>\r\n                    <td id=\"con\">Cliente:</td>\r\n                    <td style=\"border-bottom:1px solid black\">@CLIENTE</td>\r\n                </tr>\r\n                <tr>\r\n                    <td id=\"con\">Domicilio:</td>\r\n                    <td style=\"border-bottom:1px solid black\">@DOMICILIO</td>\r\n                </tr>\r\n                <tr>\r\n                    <td id=\"con\">Cond iva:</td>\r\n                    <td style=\"border-bottom:1px solid black\">@IVA</td>\r\n                </tr>\r\n                <tr>\r\n                    <td id=\"con\">CUIT:</td>\r\n                    <td style=\"border-bottom:1px solid black\">@CUITCLIENTE</td>\r\n                </tr>\r\n                \r\n            </table>\r\n        </div>\r\n        <div class=\"productos\">    \r\n            <table>\r\n                <thead>\r\n                    <tr class=\"highlight\">\r\n                        <th>Cod.</th>\r\n                        \r\n                        <th>Cant.</th>\r\n                        <th>Descripción</th>\r\n                        \r\n                        <th>P.Unitario</th>\r\n                       \r\n                        <th>Importe</th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n                    @FILAS \r\n                    <tr>\r\n                        <td colspan=\"3\" class=\"total\">Total:</td>\r\n                        <td>@NETO</td>\r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n        <div class=\"footer\">\r\n            <div class=\"footer-uno\">\r\n                <table>\r\n                    <tr>\r\n                        <td id=\"con\">Importe neto </td>\r\n                        <td style=\"border-bottom:1px solid black\">@NETO</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td id=\"con\">IVA 21% </td>\r\n                        <td style=\"border-bottom:1px solid black\">@NETOIVA</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td id=\"con\">IVA 10,5%</td>\r\n                        <td style=\"border-bottom:1px solid black\">0.00</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td id=\"con\">Importe otros tributos:</td>\r\n                        <td style=\"border-bottom:1px solid black\">0.00</td>\r\n                    </tr>            \r\n                    <tr>\r\n                        <td id=\"con\">TOTAL</td>\r\n                        <td style=\"border-bottom:1px solid black\">@TOTAL</td>\r\n                    </tr>\r\n                </table>\r\n            </div>\r\n            <div class=\"logo-footer\">\r\n                <p>CAE N : @CAE</p>\r\n                <img src=\"https://via.placeholder.com/200\" />\r\n                <p> Muchas gracias por su compra, vuelva pronto</p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>";
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CLIENTE", "Faltante");


            string filas = string.Empty;
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["barcode"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells[1].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells[2].Value.ToString() + "</td>";  
                filas += "</tr>";
                
            }
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
            string nombreArchivo = nombreArchivoFormateado + "InformeFaltantes" + ".pdf";

            // Devolver el nombre de archivo
            return nombreArchivo;
        }
    }
}
