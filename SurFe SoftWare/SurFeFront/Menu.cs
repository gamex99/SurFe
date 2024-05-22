using SurFeFront;

namespace SurFe
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            label1.Text = ClaseCompartida.apellido + " " + ClaseCompartida.nombre + " Departamento: " + ClaseCompartida.departamnto;
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
            PuntoDeVenta frm = new PuntoDeVenta();



            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Deposito frm1 = new Deposito();



            frm1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Informes frm2 = new Informes();



            frm2.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Cliente cl = new Cliente();
            cl.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Productos Prod = new Productos();
            Prod.ShowDialog();
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            Close();

        }

    }
}