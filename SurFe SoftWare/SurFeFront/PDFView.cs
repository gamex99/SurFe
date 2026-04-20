using SurFe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace SurFeFront
{
    public partial class PDFView : Form
    {
        string rutaCompletaArchivo;
        public PDFView(string recibido)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.rutaCompletaArchivo = recibido;

        }

        private async void PDFView_Load(object sender, EventArgs e)
        {
            btnsalir.BringToFront();
            //axAcropdf1.src = rutaCompletaArchivo;
            //axAcropdf1.setView("Fit");
            // 1. Inicializar el motor del navegador
            // 1. Inicializamos el motor
            await webView21.EnsureCoreWebView2Async(null);

            // 2. Usamos la variable que recibiste
            string rutaParaCargar = this.rutaCompletaArchivo;

            if (!string.IsNullOrEmpty(rutaParaCargar))
            {
                // Verificamos si el archivo existe físicamente en el disco
                if (System.IO.File.Exists(rutaParaCargar))
                {
                    // LA CLAVE: Convertimos la ruta de Windows a formato URI
                    // Esto transforma C:\SurFe\... en file:///C:/SurFe/...
                    var uri = new Uri(rutaParaCargar).AbsoluteUri;
                    webView21.CoreWebView2.Navigate(uri);
                }
                else
                {
                    MessageBox.Show("El archivo no existe en la ubicación especificada:\n" + rutaParaCargar,
                                    "Error de ruta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void PDFView_FormClosing(object sender, FormClosingEventArgs e)
        {// 1. Verificamos que el control no sea nulo
            if (webView21 != null)
            {
                // 2. Liberamos el control y cerramos los procesos de Edge asociados
                webView21.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //printDocument1 = new System.Drawing.Printing.PrintDocument();
            //PrinterSettings ps = new PrinterSettings();
            //printDocument1.PrinterSettings = ps;
            //printDocument1.PrintPage += Imprimir;
            //printDocument1.Print();
        }
        private void Imprimir(object sender, PrintPageEventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }
    }
}