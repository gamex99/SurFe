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
            axAcropdf1.src = "C:\\Users\\ParraX\\Desktop\\TestPDF\\elarchivo.pdf";
        }
    }
}
