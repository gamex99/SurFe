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
            RegistrarCliente rg = new RegistrarCliente();
            rg.modo = EnumModoForm.Alta;   ///esto es una referencia de enum

            rg.ShowDialog();
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

        private void btnConsultar_Click(object sender, EventArgs e)
        
            
            {
                if (clienteBindingSource.Current == null)
                    return; //aca hay un error y no me abre el form
                RegistrarCliente frm = new RegistrarCliente();
                frm.modo = EnumModoForm.Consulta;
                frm._clienteModel = (ClienteModel)clienteBindingSource.Current;
                frm.ShowDialog();
                reFreshGrid();
            }
        
    }
}
