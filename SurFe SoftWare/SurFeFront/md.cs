using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using SurFe;
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
    public partial class md : Form
    {
        private int childFormNumber = 0;

        public md()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void vENTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void dEPOSITOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registrarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {


            CargarProducto newMDIChild = new CargarProducto();
            newMDIChild.modo = EnumModoForm.Alta;
            newMDIChild.MdiParent = this;

            newMDIChild.Show();
        }

        private void registrarStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarStock nMDI = new RegistrarStock();
            nMDI.MdiParent = this;
            nMDI.Show();
        }

        private void consultarStockPorProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectProductoStockPorProducto nMDI = new SelectProductoStockPorProducto();
            nMDI.MdiParent = this;
            nMDI.Show();
        }

        private void actualizarStockPorPerdidaRoturaOAntiguedadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActualizarStockPorPerdidaRoturaAntiguedad nMDI = new ActualizarStockPorPerdidaRoturaAntiguedad();
            nMDI.MdiParent = this;
            nMDI.Show();
        }

        private void controlPorInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlPorInventario nMDI = new ControlPorInventario();
            nMDI.MdiParent = this;
            nMDI.Show();
        }

        private void porFaltanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InformeFaltantes newMDIChild = new InformeFaltantes();
            // Set the parent form of the child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void stockActualToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productosDeBajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();

            // string sql = "SELECT \r\n    [barcodebaja] as BarCode,\r\n    [cantidadbaja] as CantidadBaja,\r\n    [motivo] as Baja,\r\n   \r\n    u.nombre as Nombre,\r\n    u.apellido as Apellido\r\nFROM [dbo].[motivoBajaStock] AS mb\r\nINNER JOIN [dbo].[usuarios] AS u ON mb.operador = u.id";
            string sql = "SELECT \r\n    mb.barcodebaja AS BarCode,\r\n    p.detalle AS Detalle,\r\n    mb.cantidadbaja AS CantidadBaja,\r\n    mb.motivo AS Baja,\r\n    CONCAT(u.nombre, ' ', u.apellido) AS Operador\r\nFROM [dbo].[motivoBajaStock] AS mb\r\nINNER JOIN [dbo].[usuarios] AS u ON mb.operador = u.id\r\nINNER JOIN [dbo].[producto] AS p ON mb.barcodebaja = p.barcode";
            SqlCommand comando = new SqlCommand(sql, connection);







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
            string PaginaHTML_Texto = "<!DOCTYPE html>\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n\r\n\r\n    <title>Título del Documento</title>\r\n    <style>\r\n        body {\r\n            font-family: 'Arial', sans-serif;\r\n            margin: 0;\r\n            padding: 0;\r\n            background-color: #f4f4f4;\r\n        }\r\n\r\n        .container {\r\n            width: 80%;\r\n            margin: auto;\r\n            background-color: #fff;\r\n            padding: 20px;\r\n            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\r\n        }\r\n\r\n        .header, .footer {\r\n            text-align: center;\r\n            padding: 10px 0;\r\n            color: #fff;\r\n        }\r\n\r\n        .header {\r\n            position: relative;\r\n            color: #fff;\r\n            background-color: #3498db;\r\n            padding: 10px 0;\r\n        }\r\n\r\n            .header img {\r\n                width: 250px;\r\n                height: auto;\r\n                position: absolute;\r\n            }\r\n\r\n            .header .left-img {\r\n                left: 10px;\r\n            }\r\n\r\n        .footer {\r\n            background-color: #f1c40f;\r\n        }\r\n\r\n        .main {\r\n            margin: 20px 0;\r\n        }\r\n\r\n        table {\r\n            width: 100%;\r\n            border-collapse: collapse;\r\n        }\r\n\r\n        th, td {\r\n            padding: 10px;\r\n            border: 1px solid #ddd;\r\n            text-align: left;\r\n        }\r\n\r\n        th {\r\n            background-color: #3498db;\r\n        }\r\n\r\n        .highlight {\r\n            background-color: #f1c40f;\r\n            color: #fff;\r\n        }\r\n\r\n        .total {\r\n            text-align: right;\r\n            font-weight: bold;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"container\">\r\n        <div class=\"header\">\r\n            <img src=\"./logo pp1 carpeta 2023.png\" class=\"left-img\" />\r\n            <h3>INFORME</h3>\r\n            <p>INFORME @tipoinfo</p>\r\n            \r\n\r\n        </div>\r\n        <div class=\"main\">\r\n            <table>\r\n                <thead>\r\n                    <tr class=\"highlight\">\r\n                        <th>Barcode</th>\r\n       <th>Detalle</th>                   <th>Cantidad</th>\r\n                        <th>Motivo</th>                      <th>Operador</th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n                    @FILAS\r\n                    <tr>\r\n                        \r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n        <div class=\"footer\">\r\n            <p></p>\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>\r\n\r\n";
            string filas = string.Empty;
            decimal total = 0;
            while (lector.Read())
            {
                string htmlRow = "<tr>";

                for (int i = 0; i < lector.FieldCount; i++)
                {
                    htmlRow += "<td>" + lector.GetValue(i).ToString() + "</td>";
                }
                htmlRow += "</tr>";
                filas += htmlRow;

            }
            lector.Close();
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@tipoinfo", " PRODUCTOS DE BAJA");
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




        }

        private void cLIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Cliente newMDIChild = new Cliente();
            // Set the parent form of the child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();

        }

        private void pRODUCTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productos newMDIChild = new Productos();
            // Set the parent form of the child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void pROVEEDORESToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void proveedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Proveedores newMDIChild = new Proveedores();
            // Set the parent form of the child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void registrarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProveedorRegistrarPedido newMDIChild = new ProveedorRegistrarPedido();
            // Set the parent form of the child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();

        }

        private void registrarReclamoODevolucionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProveedorRegistrarReclamo newMDIChild = new ProveedorRegistrarReclamo();
            // Set the parent form of the child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void pagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProveedorRegistrarPago newMDIChild = new ProveedorRegistrarPago();
            // Set the parent form of the child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void registrarCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComprasRegistrar newMDIChild = new ComprasRegistrar();
            // Set the parent form of the child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();

        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarFactura newMDIChild = new RegistrarFactura();
            // Set the parent form of the child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void comprasRealizadasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();

            // string sql = "SELECT \r\n    [barcodebaja] as BarCode,\r\n    [cantidadbaja] as CantidadBaja,\r\n    [motivo] as Baja,\r\n   \r\n    u.nombre as Nombre,\r\n    u.apellido as Apellido\r\nFROM [dbo].[motivoBajaStock] AS mb\r\nINNER JOIN [dbo].[usuarios] AS u ON mb.operador = u.id";
            string sql = "SELECT TOP (1000)\r\n    c.[id],\r\n    c.[fecha],\r\n    p.[razon_social],\r\n    \r\n    c.[factura]\r\n    \r\nFROM [SurFeFinal].[dbo].[compra] AS c\r\nJOIN [SurFeFinal].[dbo].[proveedor] AS p\r\n    ON c.id_proveedor = p.id;";
            SqlCommand comando = new SqlCommand(sql, connection);







            SqlDataReader lector = comando.ExecuteReader();


            //verificamos si esta la carpeta en temp total no tenemos que guardar este informe
            if (!Directory.Exists(ClaseCompartida.carpetaTemp))
            {
                // La carpeta no existe, crearla
                Directory.CreateDirectory(ClaseCompartida.carpetaTemp);

            }
            // hasta aca verificamos si esta la carpeta en temp total no tenemos que guardar este informe
            string directorioPrograma = AppDomain.CurrentDomain.BaseDirectory;
            string nombreArchivo = "ComprasRealizadas";
            string rutaCompletaArchivo = Path.Combine(directorioPrograma, nombreArchivo);
            string rutaArchivoPDF = nombreArchivo;
            string PaginaHTML_Texto = "<!DOCTYPE html>\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n\r\n\r\n    <title>Título del Documento</title>\r\n    <style>\r\n        body {\r\n            font-family: 'Arial', sans-serif;\r\n            margin: 0;\r\n            padding: 0;\r\n            background-color: #f4f4f4;\r\n        }\r\n\r\n        .container {\r\n            width: 80%;\r\n            margin: auto;\r\n            background-color: #fff;\r\n            padding: 20px;\r\n            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\r\n        }\r\n\r\n        .header, .footer {\r\n            text-align: center;\r\n            padding: 10px 0;\r\n            color: #fff;\r\n        }\r\n\r\n        .header {\r\n            position: relative;\r\n            color: #fff;\r\n            background-color: #3498db;\r\n            padding: 10px 0;\r\n        }\r\n\r\n            .header img {\r\n                width: 250px;\r\n                height: auto;\r\n                position: absolute;\r\n            }\r\n\r\n            .header .left-img {\r\n                left: 10px;\r\n            }\r\n\r\n        .footer {\r\n            background-color: #f1c40f;\r\n        }\r\n\r\n        .main {\r\n            margin: 20px 0;\r\n        }\r\n\r\n        table {\r\n            width: 100%;\r\n            border-collapse: collapse;\r\n        }\r\n\r\n        th, td {\r\n            padding: 10px;\r\n            border: 1px solid #ddd;\r\n            text-align: left;\r\n        }\r\n\r\n        th {\r\n            background-color: #3498db;\r\n        }\r\n\r\n        .highlight {\r\n            background-color: #f1c40f;\r\n            color: #fff;\r\n        }\r\n\r\n        .total {\r\n            text-align: right;\r\n            font-weight: bold;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"container\">\r\n        <div class=\"header\">\r\n            <img src=\"./logo pp1 carpeta 2023.png\" class=\"left-img\" />\r\n            <h3>INFORME</h3>\r\n            <p>INFORME @tipoinfo</p>\r\n            \r\n\r\n        </div>\r\n        <div class=\"main\">\r\n            <table>\r\n                <thead>\r\n                    <tr class=\"highlight\">\r\n                        <th>Factura N°</th>\r\n       <th>Fec</th>                   <th>Proveedor</th>\r\n                        <th>Factura n°</th>                      \r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n                    @FILAS\r\n                    <tr>\r\n                        \r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n        <div class=\"footer\">\r\n            <p></p>\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>\r\n\r\n";
            string filas = string.Empty;
            decimal total = 0;
            while (lector.Read())
            {
                string htmlRow = "<tr>";

                for (int i = 0; i < lector.FieldCount; i++)
                {
                    htmlRow += "<td>" + lector.GetValue(i).ToString() + "</td>";
                }
                htmlRow += "</tr>";
                filas += htmlRow;

            }
            lector.Close();
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@tipoinfo", " COMPRAS REALIZADAS");
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











        }

        private void otroMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu newMDIChild = new Menu();
            // Set the parent form of the child window.  

            // Display the new form.  
            newMDIChild.Show();
        }

        private void ventasRealizadasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void altaClienteMensualesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GraficosAltaClientesMensualesMDI graficoForm = new GraficosAltaClientesMensualesMDI();
            graficoForm.MdiParent = this; // Establece el MDI parent
            graficoForm.Show();
        }

        private void puntoDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {


            PuntoDeVenta newMDIChild = new PuntoDeVenta();


            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void notaDeCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            NotaDeCredito newMDIChild = new NotaDeCredito();


            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void porProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ventasRealizadasToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();

            // string sql = "SELECT \r\n    [barcodebaja] as BarCode,\r\n    [cantidadbaja] as CantidadBaja,\r\n    [motivo] as Baja,\r\n   \r\n    u.nombre as Nombre,\r\n    u.apellido as Apellido\r\nFROM [dbo].[motivoBajaStock] AS mb\r\nINNER JOIN [dbo].[usuarios] AS u ON mb.operador = u.id";
            string sql = "SELECT TOP (1000)\r\n    f.[id_factura] ,\r\n    \r\n    c.[razon_social],\r\n    \r\n    td.[descripcion],\r\n    f.[fecha],\r\n    f.[total]\r\n   \r\nFROM [SurFeFinal].[dbo].[factura] AS f\r\nJOIN [SurFeFinal].[dbo].[cliente] AS c\r\n    ON f.id_cliente = c.id_cliente\r\nJOIN [SurFeFinal].[dbo].[tipo_factura] AS td\r\n    ON f.tipo_documento = td.id;";
            SqlCommand comando = new SqlCommand(sql, connection);







            SqlDataReader lector = comando.ExecuteReader();


            //verificamos si esta la carpeta en temp total no tenemos que guardar este informe
            if (!Directory.Exists(ClaseCompartida.carpetaTemp))
            {
                // La carpeta no existe, crearla
                Directory.CreateDirectory(ClaseCompartida.carpetaTemp);

            }
            // hasta aca verificamos si esta la carpeta en temp total no tenemos que guardar este informe
            string directorioPrograma = AppDomain.CurrentDomain.BaseDirectory;
            string nombreArchivo = "VentasRealizadas";
            string rutaCompletaArchivo = Path.Combine(directorioPrograma, nombreArchivo);
            string rutaArchivoPDF = nombreArchivo;
            string PaginaHTML_Texto = "<!DOCTYPE html>\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n\r\n\r\n    <title>Título del Documento</title>\r\n    <style>\r\n        body {\r\n            font-family: 'Arial', sans-serif;\r\n            margin: 0;\r\n            padding: 0;\r\n            background-color: #f4f4f4;\r\n        }\r\n\r\n        .container {\r\n            width: 80%;\r\n            margin: auto;\r\n            background-color: #fff;\r\n            padding: 20px;\r\n            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\r\n        }\r\n\r\n        .header, .footer {\r\n            text-align: center;\r\n            padding: 10px 0;\r\n            color: #fff;\r\n        }\r\n\r\n        .header {\r\n            position: relative;\r\n            color: #fff;\r\n            background-color: #3498db;\r\n            padding: 10px 0;\r\n        }\r\n\r\n            .header img {\r\n                width: 250px;\r\n                height: auto;\r\n                position: absolute;\r\n            }\r\n\r\n            .header .left-img {\r\n                left: 10px;\r\n            }\r\n\r\n        .footer {\r\n            background-color: #f1c40f;\r\n        }\r\n\r\n        .main {\r\n            margin: 20px 0;\r\n        }\r\n\r\n        table {\r\n            width: 100%;\r\n            border-collapse: collapse;\r\n        }\r\n\r\n        th, td {\r\n            padding: 10px;\r\n            border: 1px solid #ddd;\r\n            text-align: left;\r\n        }\r\n\r\n        th {\r\n            background-color: #3498db;\r\n        }\r\n\r\n        .highlight {\r\n            background-color: #f1c40f;\r\n            color: #fff;\r\n        }\r\n\r\n        .total {\r\n            text-align: right;\r\n            font-weight: bold;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"container\">\r\n        <div class=\"header\">\r\n            <img src=\"./logo pp1 carpeta 2023.png\" class=\"left-img\" />\r\n            <h3>INFORME</h3>\r\n            <p>INFORME @tipoinfo</p>\r\n            \r\n\r\n        </div>\r\n        <div class=\"main\">\r\n            <table>\r\n                <thead>\r\n                    <tr class=\"highlight\">\r\n                        <th>Factura N°</th>\r\n       <th>Cliente</th>                   <th>Factura</th>\r\n                        <th>Fecha</th>    <th>Monto</th>                  \r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n                    @FILAS\r\n                    <tr>\r\n                        \r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n        <div class=\"footer\">\r\n            <p></p>\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>\r\n\r\n";
            string filas = string.Empty;
            decimal total = 0;
            while (lector.Read())
            {
                string htmlRow = "<tr>";

                for (int i = 0; i < lector.FieldCount; i++)
                {
                    htmlRow += "<td>" + lector.GetValue(i).ToString() + "</td>";
                }
                htmlRow += "</tr>";
                filas += htmlRow;

            }
            lector.Close();
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@tipoinfo", " COMPRAS REALIZADAS");
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












        }

        private void consultarVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarVenta newMDIChild = new ConsultarVenta();


            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void pDFSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArchivosSistema newMDIChild = new ArchivosSistema();


            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }
    }
}
