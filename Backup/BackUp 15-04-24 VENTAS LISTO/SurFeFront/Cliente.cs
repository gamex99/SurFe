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
            BuscarCliente();
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
            rg.FormClosed += delegate
            {
                reFreshGrid();
            };
        }


        private void BuscarCliente()
        {
            reFreshGrid();
            ClienteNegocio obj = new ClienteNegocio();
            clienteList = obj.Get(txtBuscar.Text.Trim());

            dtgEmpleados.DataSource = clienteList;

            dtgEmpleados.Refresh();

        }
        private void reFreshGrid()
        {

            dtgEmpleados.DataSource = clienteList;

            clienteBindingSource.DataSource = clienteList;
            dtgEmpleados.DataSource = clienteBindingSource;
            dtgEmpleados.Refresh();


        }



        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarCliente();

        }

        private void btnConsultar_Click(object sender, EventArgs e)


        {
            dtgEmpleados.DataSource = clienteList;

            clienteBindingSource.DataSource = clienteList;
            dtgEmpleados.DataSource = clienteBindingSource;
            dtgEmpleados.Refresh();


            if (clienteBindingSource.Current == null)
                return;
            RegistrarCliente frm = new RegistrarCliente();
            frm.modo = EnumModoForm.Consulta;
            frm._clienteModel = (ClienteModel)clienteBindingSource.Current;
            frm.ShowDialog();
            reFreshGrid();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            dtgEmpleados.DataSource = clienteList;

            clienteBindingSource.DataSource = clienteList;
            dtgEmpleados.DataSource = clienteBindingSource;
            dtgEmpleados.Refresh();

            if (clienteBindingSource.Current == null)
                return;
            RegistrarCliente frm = new RegistrarCliente();

            frm.modo = EnumModoForm.Modificacion;
            frm._clienteModel = (ClienteModel)clienteBindingSource.Current;

            frm.ShowDialog();
            BuscarCliente();
            frm.FormClosed += delegate
            {
                reFreshGrid();
            };
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            dtgEmpleados.DataSource = clienteList;

            clienteBindingSource.DataSource = clienteList;
            dtgEmpleados.DataSource = clienteBindingSource;
            dtgEmpleados.Refresh();

            if (clienteBindingSource.Current == null)
                return;

            ClienteModel cli = (ClienteModel)clienteBindingSource.Current;

            //pregunto si quiere guardar los datos
            DialogResult res = MessageBox.Show("¿Confirma anular el cliente " + cli.razon_social + " ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return;
            }

            cli.anulado = true;

            try
            {
                ClienteNegocio.Update(cli);
                MessageBox.Show("El empleado " + cli.razon_social + " se anuló correctamente", "Anulación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            BuscarCliente();

        }

        private void dtgEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
} 

