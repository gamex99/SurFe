using SurFeFront;

namespace SurFe
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();



            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MDIParent1 frm1 = new MDIParent1();



            frm1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MDIParent2 frm2 = new MDIParent2();



            frm2.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Cliente cl = new Cliente();
            cl.ShowDialog();
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}