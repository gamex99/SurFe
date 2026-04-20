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
            this.Close();
        }

        private void btnmostrar_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox1.Text))
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
            else
            {
                MessageBox.Show("Por favor, ingrese la cantidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnimprimir_Click(object sender, EventArgs e)
        {
            // --- COMPROBACIÓN 1: GRILLA VACÍA ---
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos disponibles para generar el informe.", "SurFe - Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Verificamos si esta la carpeta en temp
                if (!Directory.Exists(ClaseCompartida.carpetaTemp))
                {
                    Directory.CreateDirectory(ClaseCompartida.carpetaTemp);
                }

                string directorioPrograma = AppDomain.CurrentDomain.BaseDirectory;
                string nombreArchivo = GetNombreArchivoFechaHora();
                string rutaCompletaArchivo = Path.Combine(directorioPrograma, nombreArchivo);
                string rutaArchivoPDF = nombreArchivo;

                // El HTML que definiste (lo mantenemos igual por ahora)
                string PaginaHTML_Texto = @"
<!DOCTYPE html>
<html>
<head>
    <title>Informe de Faltantes - SurFe</title>
    <style>
        body {
            font-family: 'Segoe UI', Arial, sans-serif;
            margin: 0;
            padding: 0;
            color: #333;
        }
        .container {
            width: 90%;
            margin: 20px auto;
            background-color: #fff;
        }
        .header {
            background-color: #2D2D30;
            color: #FFFFFF;
            padding: 20px;
            text-align: center;
            border-bottom: 4px solid #0078D7;
        }
        .header h3 {
            margin: 0;
            font-size: 22px;
            letter-spacing: 2px;
        }
        .header p {
            margin: 5px 0 0 0;
            font-size: 14px;
            color: #CCCCCC;
        }
        .main {
            margin: 20px 0;
        }
        table {
            width: 100%;
            border-collapse: collapse;
        }
        th {
            background-color: #0078D7;
            color: white;
            padding: 12px 10px;
            text-align: left;
            font-size: 13px;
            text-transform: uppercase;
        }
        td {
            padding: 10px;
            border-bottom: 1px solid #EEEEEE;
            font-size: 12px;
        }
        tr:nth-child(even) {
            background-color: #F9F9F9;
        }
        .stock-zero {
            color: #D32F2F;
            font-weight: bold;
        }
        .footer {
            margin-top: 30px;
            text-align: center;
            font-size: 11px;
            color: #777;
            border-top: 1px solid #DDD;
            padding-top: 10px;
        }
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h3>SURFE - GESTIÓN DE STOCK</h3>
            <p>INFORME: @tipoinfo</p>
        </div>
        <div class='main'>
            <table>
                <thead>
                    <tr>
                        <th style='width: 25%;'>Barcode</th>
                        <th style='width: 55%;'>Descripción / Producto</th>
                        <th style='width: 20%;'>Stock</th>
                    </tr>
                </thead>
                <tbody>
                    @FILAS
                </tbody>
            </table>
        </div>
        <div class='footer'>
            Este es un documento interno generado por el sistema SurFe.
        </div>
    </div>
</body>
</html>";
                string filas = string.Empty;
                decimal total = 0;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    // --- COMPROBACIÓN 2: VALORES NULOS EN CELDAS ---
                    // Usamos el operador ?. y ?? para evitar el "Object reference not set to an instance of an object"
                    string valBarcode = row.Cells["barcode"].Value?.ToString() ?? "";
                    string valDetalle = row.Cells[1].Value?.ToString() ?? "";
                    string valStock = row.Cells[2].Value?.ToString() ?? "0";

                    filas += "<tr>";
                    filas += "<td>" + valBarcode + "</td>";
                    filas += "<td>" + valDetalle + "</td>";
                    filas += "<td>" + valStock + "</td>";
                    filas += "</tr>";
                }

                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@tipoinfo", " FALTA DE STOCK");

                // --- COMPROBACIÓN 3: ESCRITURA DE ARCHIVO ---
                using (FileStream stream = new FileStream(rutaArchivoPDF, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    // Imagen del logo
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(SurFeFront.Properties.Resources.logo_pp1_carpeta_2023, System.Drawing.Imaging.ImageFormat.Png);
                    img.ScaleToFit(60, 60);
                    img.Alignment = iTextSharp.text.Image.UNDERLYING;
                    img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                    pdfDoc.Add(img);

                    using (StringReader sr = new StringReader(PaginaHTML_Texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();
                }

                PDFView formPDF = new PDFView(rutaCompletaArchivo);
                formPDF.ShowDialog();

                this.Close();
            }
            catch (IOException ioEx)
            {
                MessageBox.Show("El archivo PDF está siendo usado por otro programa o no se puede escribir en el disco.\n" + ioEx.Message, "Error de Archivo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado al generar el PDF:\n" + ex.Message, "Error Crítico");
            }
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
