using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SurFeNegocio;
using SurFeEntidades;
using SurFeDatos;

namespace SurFeFront
{
    public partial class Cliente : Form
    {
        List<ClienteModel> clienteList = new List<ClienteModel>();
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
            RegistrarCliente frm = new RegistrarCliente();

            //paso por parametro "algo"
            frm.modo = EnumModoForm.Alta;

            frm.ShowDialog();

            reFreshGrid(); 
        }


        private void reFreshGrid()
        {
            ClienteNegocio obj = new ClienteNegocio();
            clienteList = obj.Get(txtBuscar.Text.Trim());

            dtgEmpledos.DataSource = clienteList;
            dtgEmpledos.Refresh();
        }



        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            reFreshGrid();
            //mostrame el procedimiento almacenado
        }
    }
}
