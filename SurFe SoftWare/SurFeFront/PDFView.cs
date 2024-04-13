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
        public PDFView()
        {
            InitializeComponent();
        }

        private void PDFView_Load(object sender, EventArgs e)
        {
            axAcropdf1.src = "C:\\PDF\\elarchivo.pdf";
            //tengo que agregar un valor que me traiga desde el form2 para vizualizar el ultimo archivo
        }
    }
}
