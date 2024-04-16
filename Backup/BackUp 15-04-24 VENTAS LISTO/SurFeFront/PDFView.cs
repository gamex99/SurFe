using SurFe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
