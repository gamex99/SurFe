using iTextSharp.text.pdf;
using iTextSharp.text;
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

namespace SurFeFront
{
    public partial class ControlPorInventario : Form
    {
        public ControlPorInventario()
        {
            InitializeComponent();
            getCategorias();
        }
        private void getCategorias()
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();

            string sql = "SELECT [id], [categoria] FROM [dbo].[categoria_productos]";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            cbcategorias.Items.Clear();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string categoria = reader.GetString(1);

                // Add category name to the ComboBox

                //cbcategorias.Items.Insert( categoria);
                cbcategorias.Items.Add(categoria);
            }
            reader.Close();
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        { if(cbcategorias.SelectedIndex != -1) { 
            cargargrid();
        }else MessageBox.Show("Debe seleccionar una categoría", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

    private void Cargar_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            for (int j = 0; j < dataGridView1.RowCount; j++)
            {
                if (dataGridView1.Rows[j].Cells[3].Value != null && dataGridView1.Rows[j].Cells[3].Value != null)
                {





                    int newStock = 0;
                    int.TryParse(dataGridView1.Rows[j].Cells[3].Value.ToString(), out newStock);

                    MessageBox.Show("STOCK nuev" + newStock, "Stock Actualizado");


                    string updateSql = "UPDATE producto SET stock = @newStock WHERE barcode = @barcode;";
                    SqlCommand updateCommand = new SqlCommand(updateSql, connection);
                    updateCommand.Parameters.AddWithValue("@newStock", newStock);
                    updateCommand.Parameters.AddWithValue("@barcode", int.Parse(dataGridView1.Rows[j].Cells[0].Value.ToString()));
                    updateCommand.ExecuteNonQuery();


                }
            }
            connection.Close();
            MessageBox.Show("Stock Actualizado Correctamente ", "Stock Actualizado");
            this.Close();

        }

        private void Listado_Click(object sender, EventArgs e)
        {
            if (cbcategorias.SelectedIndex != -1)
            {



                cargargrid();


                string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();

                string sql = "SELECT barcode, detalle, stock FROM producto WHERE categoria = @idcategoria";
                SqlCommand comando = new SqlCommand(sql, connection);



                comando.Parameters.AddWithValue("@idcategoria", cbcategorias.SelectedIndex);



                SqlDataReader lector = comando.ExecuteReader();


                //verificamos si esta la carpeta en temp total no tenemos que guardar este informe
                if (!Directory.Exists(ClaseCompartida.carpetaTemp))
                {
                    // La carpeta no existe, crearla
                    Directory.CreateDirectory(ClaseCompartida.carpetaTemp);

                }
                // hasta aca verificamos si esta la carpeta en temp total no tenemos que guardar este informe
                string directorioPrograma = AppDomain.CurrentDomain.BaseDirectory;
                string nombreArchivo = "ListadoPorCategoria";
                string rutaCompletaArchivo = Path.Combine(directorioPrograma, nombreArchivo);
                string rutaArchivoPDF = nombreArchivo;
                string PaginaHTML_Texto = "<!DOCTYPE html>\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n\r\n\r\n    <title>Título del Documento</title>\r\n    <style>\r\n        body {\r\n            font-family: 'Arial', sans-serif;\r\n            margin: 0;\r\n            padding: 0;\r\n            background-color: #f4f4f4;\r\n        }\r\n\r\n        .container {\r\n            width: 80%;\r\n            margin: auto;\r\n            background-color: #fff;\r\n            padding: 20px;\r\n            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\r\n        }\r\n\r\n        .header, .footer {\r\n            text-align: center;\r\n            padding: 10px 0;\r\n            color: #fff;\r\n        }\r\n\r\n        .header {\r\n            position: relative;\r\n            color: #fff;\r\n            background-color: #3498db;\r\n            padding: 10px 0;\r\n        }\r\n\r\n            .header img {\r\n                width: 250px;\r\n                height: auto;\r\n                position: absolute;\r\n            }\r\n\r\n            .header .left-img {\r\n                left: 10px;\r\n            }\r\n\r\n        .footer {\r\n            background-color: #f1c40f;\r\n        }\r\n\r\n        .main {\r\n            margin: 20px 0;\r\n        }\r\n\r\n        table {\r\n            width: 100%;\r\n            border-collapse: collapse;\r\n        }\r\n\r\n        th, td {\r\n            padding: 10px;\r\n            border: 1px solid #ddd;\r\n            text-align: left;\r\n        }\r\n\r\n        th {\r\n            background-color: #3498db;\r\n        }\r\n\r\n        .highlight {\r\n            background-color: #f1c40f;\r\n            color: #fff;\r\n        }\r\n\r\n        .total {\r\n            text-align: right;\r\n            font-weight: bold;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"container\">\r\n        <div class=\"header\">\r\n            <img src=\"./logo pp1 carpeta 2023.png\" class=\"left-img\" />\r\n            <h3>INFORME</h3>\r\n            <p>INFORME @tipoinfo</p>\r\n            \r\n\r\n        </div>\r\n        <div class=\"main\">\r\n            <table>\r\n                <thead>\r\n                    <tr class=\"highlight\">\r\n                        <th>Barcode</th>\r\n                        <th>Descripción</th>\r\n                        <th>StockActual</th>\r\n                        <th>StockFisico</th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n                    @FILAS\r\n                    <tr>\r\n                        \r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n        <div class=\"footer\">\r\n            <p></p>\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>\r\n\r\n";
                string filas = string.Empty;
                decimal total = 0;
                while (lector.Read())
                {
                    string htmlRow = "<tr>";

                    for (int i = 0; i < lector.FieldCount; i++)
                    {
                        htmlRow += "<td>" + lector.GetValue(i).ToString() + "</td>";
                    }
                    htmlRow += "<td></td>";
                    htmlRow += "</tr>";
                    filas += htmlRow;

                }
                lector.Close();
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@tipoinfo", " CONTROL STOCK");
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
                PDFView formPDF = new PDFView(rutaCompletaArchivo);

                // Mostrar el formulario secundario y verificar si se hizo clic en "Aceptar"
                formPDF.ShowDialog();
                //eso es codigo para hacer el html del pdf
                // Cerrar el formulario Form1 después de cerrar el formulario Form2
                //this.Close();

            }else MessageBox.Show("Debe seleccionar una categoría", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void cargargrid()
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                // Obtener el valor del combobox
                int idCategoria = 0;
                if (cbcategorias.SelectedIndex != -1)
                {
                    idCategoria = cbcategorias.SelectedIndex;
                }

                // Preparar la consulta SQL
                string sql = "SELECT barcode, detalle, stock FROM producto WHERE categoria = @idcategoria";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@idcategoria", idCategoria);

                    // Ejecutar la consulta SQL
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Llenar el datagrid
                        while (reader.Read())
                        {
                            int barcode = reader.GetInt32(0);
                            string detalle = reader.GetString(1);
                            int stockActual = reader.GetInt32(2);

                            dataGridView1.Rows.Add(barcode, detalle, stockActual);
                        }
                    }
                }
            }
        }
    }
}
