namespace SurFe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
    }
}