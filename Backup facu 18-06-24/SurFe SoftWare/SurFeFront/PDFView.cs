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

        private void PDFView_Load(object sender, EventArgs e)
        {
            //axAcropdf1.src = "C:\\PDF\\elarchivo.pdf";
            axAcropdf1.src = rutaCompletaArchivo;
            //tengo que agregar un valor que me traiga desde el form2 para vizualizar el ultimo archivo
        }

        private void PDFView_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printDocument1.PrinterSettings = ps;
            printDocument1.PrintPage += Imprimir;
            printDocument1.Print();
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
    }
}
