using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SurFeDatos;
using SurFeEntidades;
using SurFeNegocio;
namespace SurFeFront
{
    public partial class FormCliente : Form
    {
        List<FormCliente> clienteList = new List<FormCliente>();
        public FormCliente()
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
            //Obtengo el nombre ingresado por el usuario
            string nombreBuscar = txtBuscar.Text.Trim().ToUpper();

            //declaro el parametro
            Cliente parametro = new Cliente();

            //asigno el nombre ingresado
            if (!String.IsNullOrEmpty(nombreBuscar.Trim()))
                parametro.razon_social = nombreBuscar;

            try
            {
                //Busco la lista de empleados en la capa de negocio, pasandole el parametro ingresado
                clienteList = ClienteNegocio.Get(parametro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Actualizo la grilla
            
            reFreshGrid();
        }
    }

    
}
