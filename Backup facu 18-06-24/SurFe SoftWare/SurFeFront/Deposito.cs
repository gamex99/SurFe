using SurFeFront;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurFe
{
    public partial class Deposito : Form
    {
        private int childFormNumber = 0;

        public Deposito()
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

        private void editMenu_Click(object sender, EventArgs e)
        {

        }

        private void fileMenu_Click(object sender, EventArgs e)
        {

        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void bajaStockPorRoturaPerdidaToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
