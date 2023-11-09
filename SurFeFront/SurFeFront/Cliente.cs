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
    public partial class Cliente : Form
    {
        List<Cliente> clienteList = new List<Cliente>();
        public Cliente()
        {
            InitializeComponent();
            reFreshGrid();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {

        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            RegistrarCliente rg = new RegistrarCliente();
            rg.ShowDialog();
        }


        private void reFreshGrid()
        {
            dataGridView1.DataSource = clienteList;
            dataGridView1.Refresh();
        }

        private void buscarEmpleados()
        {

            clienteList = SurFeNegocio.Get(new Cliente());
            reFreshGrid();
        }
    }

    
}
