using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using SurFeFront; // Ajustá si tus otras pantallas están en otros namespaces
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace SurFe
{
    public partial class PuntoDeVenta : Form
    {
        private List<DetallesFactura> detalles = new List<DetallesFactura>();
        string cuit;
        string razonsocial;
        string domicilio;
        string localidad;
        int tipo_factura;
        string id_cliente1;
        int numero_factura;
        string letra_factura;
        string condicionivaa;

        public PuntoDeVenta()
        {
            InitializeComponent();
            button3.Enabled = false;
            btnmod.Enabled = false;
            btnagregar.Visible = false;
            cbxfactura.Enabled = false;
            this.KeyPreview = true;
            //this.KeyDown += new KeyEventHandler(PuntoDeVenta_KeyDown);
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

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Precio"].Value != null)
                {
                    SumaSubtotal += Convert.ToDecimal(row.Cells["Precio"].Value);
                }
            }

            IVA = SumaSubtotal * (decimal).21;
            total = SumaSubtotal;
            decimal subtotalfloat = SumaSubtotal - IVA;

            subtotal.Text = subtotalfloat.ToString("N2");
            labeliva.Text = IVA.ToString("N2");
            labeltotal.Text = total.ToString("N2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectClienteVenta form = new SelectClienteVenta();

            if (form.ShowDialog() == DialogResult.OK)
            {
                id_cliente1 = form.id_clienteselect;
                cuit = form.cuitselect;
                razonsocial = form.razonsocialselect;
                domicilio = form.domicilio;
                localidad = form.localidad;
                condicionivaa = form.condicioniva;
                int.TryParse(form.factura_tipo, out tipo_factura);

                labelrazonsocial.Text = "Razon Social: " + razonsocial;
                labelcuit.Text = "CUIT: " + cuit;
                labeldireccion.Text = "Direccion: " + domicilio;
                labellocalidad.Text = "Localidad: " + localidad;

                if (tipo_factura >= 0 && tipo_factura < cbxfactura.Items.Count)
                {
                    cbxfactura.SelectedIndex = tipo_factura;
                }
            }
        }

        private void btnbuscarart_Click(object sender, EventArgs e)
        {
            SelectProducto formproducto = new SelectProducto();

            if (formproducto.ShowDialog() == DialogResult.OK)
            {
                string barcode = formproducto.barcode;
                txtcodigo.Text = barcode;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtcodigo.Text) && !string.IsNullOrEmpty(txtcantidad.Text))
            {
                string filtro = txtcodigo.Text;
                string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

                string barcode = "";
                string detalle = "";
                decimal precio = (decimal)00;
                int stock = 0;
                int cantidad = int.Parse(txtcantidad.Text);

                string queryArticulo = "SELECT barcode, detalle, precio, stock FROM producto WHERE barcode = @filtro";

                using (SqlConnection connection = new SqlConnection(conString))
                {
                    using (SqlCommand command = new SqlCommand(queryArticulo, connection))
                    {
                        command.Parameters.AddWithValue("@filtro", filtro);

                        try
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    barcode = reader["barcode"].ToString();
                                    detalle = reader["detalle"].ToString();
                                    precio = Convert.ToDecimal(reader["precio"]);
                                    stock = Convert.ToInt32(reader["stock"]);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al buscar artículo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                if (stock >= cantidad)
                {
                    decimal totalart = precio * cantidad;
                    dataGridView1.Rows.Add(barcode, cantidad, detalle, precio, totalart, stock);
                    RecalcularSuma();
                }
                else
                {
                    MessageBox.Show(string.IsNullOrEmpty(detalle) ? "Producto no encontrado." : "Stock insuficiente. Hay " + stock + " unidades disponibles de: " + detalle, "Error de Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debe introducir codigo de producto y cantidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // --- MÉTODO FACTURAR ---
        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            int numero = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT [numero] FROM [dbo].[numero_factura] WHERE [id_numero] = 1;";
                using (SqlCommand command2 = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            numero = reader.GetInt32(0);
                        }
                    }
                }
            }

            string cadena = numero.ToString();
            if (cadena.Length > 5)
            {
                cadena = cadena.Substring(0, 5);
            }
            else if (cadena.Length < 5)
            {
                cadena = cadena.PadLeft(5, '0');
            }

            Random random = new Random();
            long randomNumber = (long)(random.NextDouble() * (1e14 - 1e13) + 1e13);
            string randomString = randomNumber.ToString("D14");

            switch (cbxfactura.SelectedIndex)
            {
                case 1: letra_factura = "A"; break;
                case 2: letra_factura = "B"; break;
                case 3: letra_factura = "C"; break;
                case 4: letra_factura = "Presupuesto X"; break;
            }

            string directorioPrograma = AppDomain.CurrentDomain.BaseDirectory;
            string nombreArchivo = letra_factura + "_" + GetNombreArchivoFechaHora();
            string rutaCompletaArchivo = Path.Combine(directorioPrograma, nombreArchivo);
            string rutaArchivoPDF = nombreArchivo;

            string PaginaHTML_Texto = @"<!DOCTYPE html>
<html xmlns='http://www.w3.org/1999/xhtml'>
<head>
    <title>Factura</title>
    <style>
        body { font-family: 'Helvetica', 'Arial', sans-serif; font-size: 12px; color: #333; line-height: 1.4; margin: 0; padding: 0; }
        .container { width: 100%; margin: 0 auto; }
        table.header-table { width: 100%; border-bottom: 2px solid #2c3e50; padding-bottom: 10px; margin-bottom: 20px; border-collapse: collapse; }
        .col-logo { width: 120px; vertical-align: top; padding-right: 15px; }
        .col-empresa { vertical-align: top; padding-top: 5px; }
        .col-letra { width: 60px; vertical-align: top; text-align: center; }
        .col-datos { width: 35%; vertical-align: top; text-align: right; }
        .img-logo { width: 100px; height: auto; display: block; }
        .company-title { font-size: 16px; font-weight: bold; margin: 0 0 5px 0; color: #2c3e50; text-transform: uppercase; }
        .company-info { font-size: 10px; color: #555; margin: 2px 0; display: block; }
        .letra-box { background-color: #2c3e50; color: white; font-size: 24px; font-weight: bold; width: 40px; height: 40px; line-height: 40px; margin: 0 auto; border-radius: 4px; display: block; text-align: center; }
        .cod-comp { font-size: 8px; font-weight: bold; margin-top: 2px; display: block; }
        .doc-title { font-size: 22px; font-weight: bold; color: #2c3e50; margin-bottom: 5px; }
        .box-cliente { background-color: #f8f9fa; border: 1px solid #e9ecef; padding: 10px; margin-bottom: 20px; border-radius: 4px; }
        table.cliente-table { width: 100%; }
        .label { font-weight: bold; color: #2c3e50; width: 80px; font-size: 11px; }
        .value { color: #000; font-size: 11px; }
        table.products-table { width: 100%; border-collapse: collapse; margin-bottom: 20px; }
        table.products-table th { background-color: #2c3e50; color: white; padding: 8px; text-align: left; font-size: 11px; text-transform: uppercase; }
        table.products-table td { border-bottom: 1px solid #ddd; padding: 8px; font-size: 11px; vertical-align: middle; }
        .text-right { text-align: right; }
        .text-center { text-align: center; }
        table.footer-layout { width: 100%; margin-top: 10px; }
        table.totals-table { width: 100%; border-collapse: collapse; }
        table.totals-table td { padding: 5px; border-bottom: 1px solid #eee; }
        .total-label { font-weight: bold; text-align: right; padding-right: 10px; white-space: nowrap; }
        .total-value { text-align: right; font-weight: bold; font-size: 13px; white-space: nowrap; }
        .final-total { background-color: #2c3e50; color: white; }
        .disclaimer { margin-top: 30px; text-align: center; font-size: 10px; font-weight: bold; color: #856404; background-color: #fff3cd; border: 1px solid #ffeeba; padding: 10px; border-radius: 4px; text-transform: uppercase; }
        .cae-container { margin-top: 15px; font-size: 10px; color: #444; border: 1px dashed #ccc; padding: 8px; background: #fafafa; }
    </style>
</head>
<body>
    <div class='container'>
        <table class='header-table'>
            <tr>
                <td class='col-logo'>
                    <img src='SurFeFront.Properties.Resources.logo_pp1_carpeta_2023' class='img-logo' />
                </td>
                <td class='col-empresa'>
                    <p class='company-title'>SurFe Software</p>
                    <span class='company-info'>Bolivar 325, Peyrano, Santa Fe</span>
                    <span class='company-info'>Tel: 3416082000</span>
                    <span class='company-info'>Email: contacto@surfe.com.ar</span>
                    <span class='company-info'>IVA Responsable Inscripto</span>
                </td>
                <td class='col-letra'>
                    <div class='letra-box'>@LETRA_FACTURA</div>
                    <span class='cod-comp'>COD. 01</span>
                </td>
                <td class='col-datos'>
                    <div class='doc-title'>FACTURA</div>
                    <span class='company-info'><strong>N°:</strong> 0001-@NUMERO</span>
                    <span class='company-info'><strong>Fecha:</strong> @FECHAHOY</span>
                    <br/>
                    <span class='company-info'><strong>CUIT:</strong> 20-21950728-4</span>
                    <span class='company-info'><strong>Ing. Brutos:</strong> 102-009216-1</span>
                </td>
            </tr>
        </table>
        
        <div class='box-cliente'>
            <table class='cliente-table'>
                <tr>
                    <td class='label'>Cliente:</td> <td class='value'>@CLIENTE</td>
                    <td class='label'>CUIT:</td> <td class='value'>@CUITCLIENTE</td>
                </tr>
                <tr>
                    <td class='label'>Domicilio:</td> <td class='value'>@DOMICILIO</td>
                    <td class='label'>Cond. IVA:</td> <td class='value'>@IVA</td>
                </tr>
            </table>
        </div>

        <table class='products-table'>
            <thead>
                <tr>
                    <th style='width: 10%;'>Cod.</th>
                    <th style='width: 45%;'>Descripción</th>
                    <th style='width: 10%;' class='text-center'>Cant.</th>
                    <th style='width: 15%;' class='text-right'>P. Unitario</th>
                    <th style='width: 20%;' class='text-right'>Importe</th>
                </tr>
            </thead>
            <tbody>
                @FILAS
            </tbody>
        </table>

        <table class='footer-layout'>
            <tr>
                <td style='width: 60%; vertical-align: top; padding-right: 20px;'>
                    <div class='cae-container'>
                        <strong>CAE N°:</strong> @CAE <br/>
                        <strong>Vto. CAE:</strong> @FECHAHOY <br/><br/>
                        <em>Comprobante Autorizado</em>
                    </div>
                </td>
                <td style='width: 40%; vertical-align: top;'>
                    <table class='totals-table'>
                        <tr><td class='total-label'>Subtotal:</td><td class='total-value'>$ @NETO</td></tr>
                        <tr><td class='total-label'>IVA (21%):</td><td class='total-value'>$ @ALGOIVA</td></tr>
                        <tr style='background-color: #2c3e50; color: white;'>
                            <td class='total-label' style='color: white;'>TOTAL:</td>
                            <td class='total-value' style='color: white;'>$ @TOTAL</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

        <div class='disclaimer'>
            ESTE DOCUMENTO NO ES VÁLIDO COMO FACTURA FISCAL - SOLAMENTE PARA USO DIDÁCTICO
        </div>
    </div>
</body>
</html>";

            string iva_factura = labeliva.Text.ToString();
            string total_factura = labeltotal.Text.ToString();
            string subtotal_factura = subtotal.Text.ToString();

            if (letra_factura == "C")
            {
                iva_factura = "0";
                total_factura = subtotal.Text.ToString();
            }
            if (letra_factura == "B")
            {
                iva_factura = "0";
                subtotal_factura = labeltotal.Text.ToString();
            }

            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CLIENTE", razonsocial);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CUITCLIENTE", cuit);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHAHOY", DateTime.Now.ToString("dd/MM/yyyy"));
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NUMERO", cadena);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@LETRA_FACTURA", letra_factura);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CAE", randomString);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@IVA", condicionivaa);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NETO", subtotal_factura);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ALGOIVA", iva_factura);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DOMICILIO", labeldireccion.Text.ToString());

            string filas = string.Empty;
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Codigo"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td class='text-center'>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td class='text-right'>$ " + row.Cells["preciouni"].Value.ToString() + "</td>";
                filas += "<td class='text-right'>$ " + row.Cells["Precio"].Value.ToString() + "</td>";
                filas += "</tr>";
                total += decimal.Parse(row.Cells["Precio"].Value.ToString());
            }
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@TOTAL", total_factura);

            using (FileStream stream = new FileStream(rutaArchivoPDF, FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(new Phrase(""));

                try
                {
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(SurFeFront.Properties.Resources.logo_pp1_carpeta_2023, System.Drawing.Imaging.ImageFormat.Png);
                    img.ScaleToFit(60, 60);
                    img.Alignment = iTextSharp.text.Image.UNDERLYING;
                    img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                    pdfDoc.Add(img);
                }
                catch { }

                using (StringReader sr = new StringReader(PaginaHTML_Texto))
                {
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                }

                pdfDoc.Close();
                stream.Close();
            }

            // --- INSERCIÓN A BASE DE DATOS Y MODIFICACIÓN DE STOCK ---
            string tipo_documento_str = tipo_factura.ToString();
            string sql = "";
            bool esFactura = false;

            if (cbxfactura.SelectedIndex == 4) // Presupuesto
            {
                sql = "INSERT INTO dbo.presupuesto ([id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (@id_cliente, @tipo_documento, @fecha, @total, @location)";
            }
            else if (cbxfactura.SelectedIndex >= 1 && cbxfactura.SelectedIndex <= 3) // Factura A, B, o C
            {
                sql = "INSERT INTO dbo.factura ([id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (@id_cliente, @tipo_documento, @fecha, @total, @location)";
                esFactura = true; // Marcamos que es factura para descontar stock
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un tipo de documento válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    DateTime fechaActual = DateTime.Now;
                    command.Parameters.AddWithValue("@id_cliente", id_cliente1);
                    command.Parameters.AddWithValue("@tipo_documento", tipo_documento_str);
                    command.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fechaActual;
                    command.Parameters.AddWithValue("@total", total);
                    command.Parameters.AddWithValue("@location", nombreArchivo);

                    connection.Open();
                    command.ExecuteNonQuery();

                    // --- DESCUENTO DE STOCK LÓGICO ---
                    if (esFactura)
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            string codProducto = row.Cells["Codigo"].Value.ToString();
                            int cantVendida = Convert.ToInt32(row.Cells["Cantidad"].Value);

                            string sqlStock = "UPDATE producto SET stock = stock - @cantVendida WHERE barcode = @codProducto";

                            using (SqlCommand cmdStock = new SqlCommand(sqlStock, connection))
                            {
                                cmdStock.Parameters.AddWithValue("@cantVendida", cantVendida);
                                cmdStock.Parameters.AddWithValue("@codProducto", codProducto);
                                cmdStock.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }

            PDFView formPDF = new PDFView(rutaCompletaArchivo);
            formPDF.ShowDialog();
            this.Close();
        }

        private static string GetNombreArchivoFechaHora()
        {
            DateTime now = DateTime.Now;
            string nombreArchivoFormateado = now.ToString("yyyyMMdd_HHmmss");
            return nombreArchivoFormateado + ".pdf";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RecalcularSuma();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RecalcularSuma();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            RecalcularSuma();
        }

        // --- MÉTODO PRESUPUESTO INDEPENDIENTE ---
        private void btnpresu_Click(object sender, EventArgs e)
        {
            if (labelcuit.Text != "CUIT: ")
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    button2.Enabled = false;
                    btnbuscarart.Enabled = false;
                    btnpresu.Enabled = false;
                    btnmod.Enabled = true;
                    button3.Enabled = true;
                    dataGridView1.ReadOnly = true;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;

                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        col.ReadOnly = true;
                    }

                    Random random = new Random();
                    long randomNumber = (long)(random.NextDouble() * (1e14 - 1e13) + 1e13);
                    string randomString = randomNumber.ToString("D14");

                    letra_factura = "Presupuesto";

                    string directorioPrograma = AppDomain.CurrentDomain.BaseDirectory;
                    string nombreArchivo = "Pres" + GetNombreArchivoFechaHora();
                    string rutaCompletaArchivo = Path.Combine(directorioPrograma, nombreArchivo);
                    string rutaArchivoPDF = nombreArchivo;

                    string PaginaHTML_Texto = @"<!DOCTYPE html>
<html xmlns='http://www.w3.org/1999/xhtml'>
<head>
    <title>Presupuesto</title>
    <style>
        body { font-family: 'Helvetica', 'Arial', sans-serif; font-size: 12px; color: #333; line-height: 1.4; margin: 0; padding: 0; }
        .container { width: 100%; margin: 0 auto; }
        table.header-table { width: 100%; border-bottom: 2px solid #2c3e50; padding-bottom: 10px; margin-bottom: 20px; border-collapse: collapse; }
        .col-logo { width: 120px; vertical-align: top; padding-right: 15px; }
        .col-empresa { vertical-align: top; padding-top: 5px; }
        .col-letra { width: 60px; vertical-align: top; text-align: center; }
        .col-datos { width: 35%; vertical-align: top; text-align: right; }
        .img-logo { width: 100px; height: auto; display: block; }
        .company-title { font-size: 16px; font-weight: bold; margin: 0 0 5px 0; color: #2c3e50; text-transform: uppercase; }
        .company-info { font-size: 10px; color: #555; margin: 2px 0; display: block; }
        .letra-box { background-color: #2c3e50; color: white; font-size: 24px; font-weight: bold; width: 40px; height: 40px; line-height: 40px; margin: 0 auto; border-radius: 4px; display: block; text-align: center; }
        .cod-comp { font-size: 8px; font-weight: bold; margin-top: 2px; display: block; }
        .doc-title { font-size: 22px; font-weight: bold; color: #2c3e50; margin-bottom: 5px; }
        .box-cliente { background-color: #f8f9fa; border: 1px solid #e9ecef; padding: 10px; margin-bottom: 20px; border-radius: 4px; }
        table.cliente-table { width: 100%; }
        .label { font-weight: bold; color: #2c3e50; width: 80px; font-size: 11px; }
        .value { color: #000; font-size: 11px; }
        table.products-table { width: 100%; border-collapse: collapse; margin-bottom: 20px; }
        table.products-table th { background-color: #2c3e50; color: white; padding: 8px; text-align: left; font-size: 11px; text-transform: uppercase; }
        table.products-table td { border-bottom: 1px solid #ddd; padding: 8px; font-size: 11px; vertical-align: middle; }
        .text-right { text-align: right; }
        .text-center { text-align: center; }
        table.footer-layout { width: 100%; margin-top: 10px; }
        table.totals-table { width: 100%; border-collapse: collapse; }
        table.totals-table td { padding: 5px; border-bottom: 1px solid #eee; }
        .total-label { font-weight: bold; text-align: right; padding-right: 10px; white-space: nowrap; }
        .total-value { text-align: right; font-weight: bold; font-size: 13px; white-space: nowrap; }
        .final-total { background-color: #2c3e50; color: white; }
        .disclaimer { margin-top: 30px; text-align: center; font-size: 10px; font-weight: bold; color: #856404; background-color: #fff3cd; border: 1px solid #ffeeba; padding: 10px; border-radius: 4px; text-transform: uppercase; }
    </style>
</head>
<body>
    <div class='container'>
        <table class='header-table'>
            <tr>
                <td class='col-logo'>
                    <img src='SurFeFront.Properties.Resources.logo_pp1_carpeta_2023' class='img-logo' />
                </td>
                <td class='col-empresa'>
                    <p class='company-title'>SurFe Software</p>
                    <span class='company-info'>Bolivar 325, Peyrano, Santa Fe</span>
                    <span class='company-info'>Tel: 3416082000</span>
                    <span class='company-info'>Email: contacto@surfe.com.ar</span>
                </td>
                <td class='col-letra'>
                    <div class='letra-box'>X</div>
                    <span class='cod-comp'>PRE</span>
                </td>
                <td class='col-datos'>
                    <div class='doc-title'>PRESUPUESTO</div>
                    <span class='company-info'><strong>N°:</strong> 0001-@NUMERO</span>
                    <span class='company-info'><strong>Fecha:</strong> @FECHAHOY</span>
                    <br/>
                    <span class='company-info'><strong>CUIT:</strong> 20-21950728-4</span>
                    <span class='company-info'><strong>Ing. Brutos:</strong> 102-009216-1</span>
                </td>
            </tr>
        </table>
        <div class='box-cliente'>
            <table class='cliente-table'>
                <tr>
                    <td class='label'>Cliente:</td> <td class='value'>@CLIENTE</td>
                    <td class='label'>CUIT:</td> <td class='value'>@CUITCLIENTE</td>
                </tr>
                <tr>
                    <td class='label'>Domicilio:</td> <td class='value'>@DOMICILIO</td>
                    <td class='label'>Cond. IVA:</td> <td class='value'>@IVA</td>
                </tr>
            </table>
        </div>
        <table class='products-table'>
            <thead>
                <tr>
                    <th style='width: 10%;'>Cod.</th>
                    <th style='width: 45%;'>Descripción</th>
                    <th style='width: 10%;' class='text-center'>Cant.</th>
                    <th style='width: 15%;' class='text-right'>P. Unitario</th>
                    <th style='width: 20%;' class='text-right'>Importe</th>
                </tr>
            </thead>
            <tbody>
                @FILAS
            </tbody>
        </table>
        <table class='footer-layout'>
            <tr>
                <td style='width: 60%; vertical-align: top; padding-right: 20px;'>
                    <div style='font-size: 10px; color: #666; padding: 10px; border: 1px dashed #ccc; background: #fafafa;'>
                        <strong>Observaciones:</strong><br/>
                        Presupuesto válido por 15 días. <br/>
                        Sujeto a disponibilidad de stock.
                    </div>
                </td>
                <td style='width: 40%; vertical-align: top;'>
                    <table class='totals-table'>
                        <tr><td class='total-label'>Subtotal:</td><td class='total-value'>$ @NETO</td></tr>
                        <tr><td class='total-label'>IVA (21%):</td><td class='total-value'>$ @ALGOIVA</td></tr>
                        <tr style='background-color: #2c3e50; color: white;'>
                            <td class='total-label' style='color: white;'>TOTAL:</td>
                            <td class='total-value' style='color: white;'>$ @TOTAL</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div class='disclaimer'>
            ESTE DOCUMENTO NO ES VÁLIDO COMO FACTURA FISCAL - SOLAMENTE PARA USO DIDÁCTICO
        </div>
    </div>
</body>
</html>";

                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CLIENTE", razonsocial);
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CUITCLIENTE", cuit);
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHAHOY", DateTime.Now.ToString("dd/MM/yyyy"));
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NUMERO", "0");
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@LETRA_FACTURA", letra_factura);
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CAE", randomString);
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@IVA", condicionivaa);
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NETO", subtotal.Text.ToString());
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ALGOIVA", labeliva.Text.ToString());
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DOMICILIO", labeldireccion.Text.ToString());

                    string filas = string.Empty;
                    decimal total = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        filas += "<tr>";
                        filas += "<td>" + row.Cells["Codigo"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                        filas += "<td class='text-center'>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                        filas += "<td class='text-right'>$ " + row.Cells["preciouni"].Value.ToString() + "</td>";
                        filas += "<td class='text-right'>$ " + row.Cells["Precio"].Value.ToString() + "</td>";
                        filas += "</tr>";
                        total += decimal.Parse(row.Cells["Precio"].Value.ToString());
                    }

                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace("@TOTAL", labeltotal.Text.ToString());

                    using (FileStream stream = new FileStream(rutaArchivoPDF, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(new Phrase(""));

                        try
                        {
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(SurFeFront.Properties.Resources.logo_pp1_carpeta_2023, System.Drawing.Imaging.ImageFormat.Png);
                            img.ScaleToFit(60, 60);
                            img.Alignment = iTextSharp.text.Image.UNDERLYING;
                            img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                            pdfDoc.Add(img);
                        }
                        catch { }

                        using (StringReader sr = new StringReader(PaginaHTML_Texto))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        }

                        pdfDoc.Close();
                        stream.Close();
                    }

                    // --- INSERCIÓN A BASE DE DATOS PRESUPUESTO (NO DESCUENTA STOCK) ---
                    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                    string tipo_documento_str = tipo_factura.ToString();
                    string sql = "INSERT INTO dbo.presupuesto ([id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (@id_cliente, @tipo_documento, @fecha, @total, @location)";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            DateTime fechaActual = DateTime.Now;
                            command.Parameters.AddWithValue("@id_cliente", id_cliente1);
                            command.Parameters.AddWithValue("@tipo_documento", tipo_documento_str);
                            command.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fechaActual;
                            command.Parameters.AddWithValue("@total", total);
                            command.Parameters.AddWithValue("@location", nombreArchivo);

                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }

                    PDFView formPDF = new PDFView(rutaCompletaArchivo);
                    formPDF.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Debe cargar productos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnmod_Click(object sender, EventArgs e)
        {
            btnmod.Enabled = false;
            btnpresu.Enabled = true;
            button2.Enabled = true;
            btnbuscarart.Enabled = true;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = true;

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.ReadOnly = false;
            }
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void label11_Click(object sender, EventArgs e) { }

        private void PuntoDeVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                e.Handled = true; // Evita pitidos del sistema
                EjecutarBusquedaProducto();
            }
        }
        private void EjecutarBusquedaProducto()
        {
            SelectProducto formproducto = new SelectProducto();
            if (formproducto.ShowDialog() == DialogResult.OK)
            {
                txtcodigo.Text = formproducto.barcode;
                txtcantidad.Focus(); // Pasa el foco a cantidad para agilizar
            }
        }
    }
}