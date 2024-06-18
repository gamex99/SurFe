using SurFeDatos;
using SurFeEntidades;
using SurFeNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace SurFeFront
{
    public partial class RegistrarCliente : Form
    {
        public EnumModoForm modo = EnumModoForm.Alta; // aca tamb enum
        public ClienteModel _clienteModel = new ClienteModel();
        public RegistrarCliente()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        private void Guardar()
        {
            


            try
            {
   
                ClienteModel cli = new ClienteModel();
                cli.razon_social = txtrazonsocial.Text.Trim();
                cli.cuit = txtcuit.Text.Trim();
                cli.id_tipo_documento = cbxDoc.SelectedIndex;
                cli.dni = Int32.Parse(txtdni.Text);
                cli.id_tipo_factura = cbxtfac.SelectedIndex;
                cli.id_condicion_iva = cbxiva.SelectedIndex;                
                cli.tipo_factura = cbxtfac.SelectedIndex.ToString();          
                cli.domicilio = txtDom.Text.Trim();
                cli.id_provincia = cbxprov.SelectedIndex;
                cli.id_localidad = cbxLoc.SelectedIndex;
                cli.cp = txtCp.Text.Trim();
                cli.telefono = txtTel.Text.Trim();
                cli.email = txtTel.Text.Trim();
                cli.barrio = txtBarrio.Text.Trim();
                
                string mensajeErrores = "";
                //aca decia algo de realizar validaciones
                if (!ValidarEmpleado(ref mensajeErrores, cli))
                {
                    //si falla alguna validacion muestro el mensaje y no hago nada mas
                    MessageBox.Show("Atención: Se encontraron los siguientes errores \n" + mensajeErrores, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //las validaciones estan bien
                //pregunto si quiere guardar los datos
                DialogResult res = MessageBox.Show("¿Confirma guardar ? ", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                {
                    return;
                }
                //Guardo los datos
                if (modo == EnumModoForm.Alta)
                {
                    int idcli = ClienteDatos.Insert(cli);
                    
                    MessageBox.Show("Se generó el cliente nro " + idcli.ToString(), "Cliente creado",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (modo == EnumModoForm.Modificacion)
                {
                    cli.cuit = Convert.ToString(txtcuit.Text);
                    ClienteDatos.Update(cli);
                    MessageBox.Show("Se actualizaron los datos correctamente", "Cliente actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        

    }
        private bool ValidarEmpleado(ref string mensaje, ClienteModel e)
        {
            mensaje = "";
            if (String.IsNullOrEmpty(e.cuit.Trim()))
            {
                mensaje += "\nError en DNI";
            }
            if (String.IsNullOrEmpty(e.razon_social.Trim()))
            {
                mensaje += "\nError en Nombre";
            }
            if (!String.IsNullOrEmpty(mensaje))
            {
                return false;

            }

            return true;
        }

        private void LimpiarControles()
        {
            txtrazonsocial.Text = "";
            cbxDoc.SelectedIndex = 0;
            txtdni.Text = "";
            txtcuit.Text = "";
            cbxiva.SelectedIndex = 0;
            cbxtfac.SelectedIndex = 0;
            txtDom.Text = "";
            txtTel.Text = "";
            txtEmail.Text = "";
            cbxprov.SelectedIndex = 0;
            cbxLoc.SelectedIndex = 0;
            txtBarrio.Text = "";
            txtCp.Text = "";
        }
        private void HabilitarControles(bool habilitar)
        {

            txtrazonsocial.Enabled = habilitar;
            cbxDoc.Enabled = habilitar;
            txtdni.Enabled = habilitar;
            txtcuit.Enabled = habilitar;
            cbxiva.Enabled = habilitar;
            cbxtfac.Enabled = habilitar;
            txtDom.Enabled = habilitar;
            txtTel.Enabled = habilitar;
            txtEmail.Enabled = habilitar;
            cbxprov.Enabled = habilitar;
            cbxLoc.Enabled = habilitar;
            txtBarrio.Enabled = habilitar;
            txtCp.Enabled = habilitar;
        }


        private void CargarDatos()
        {
            txtrazonsocial.Text = _clienteModel.razon_social.ToString();
            cbxDoc.SelectedIndex = _clienteModel.id_tipo_documento; 
            txtdni.Text = _clienteModel.dni.ToString(); ;
            txtcuit.Text = _clienteModel.cuit.ToString();
            cbxiva.SelectedIndex = _clienteModel.id_condicion_iva;
            cbxtfac.SelectedIndex = _clienteModel.id_tipo_factura;
            txtDom.Text = _clienteModel.domicilio.ToString();
            txtTel.Text = _clienteModel.telefono.ToString();
            txtEmail.Text = _clienteModel.email.ToString(); 
            cbxprov.SelectedIndex = _clienteModel.id_provincia;
            cbxLoc.SelectedIndex = _clienteModel.id_localidad;
            txtBarrio.Text = _clienteModel.barrio.ToString();
            txtCp.Text = _clienteModel.cp.ToString();
        }

        private void txtNomAp_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegistrarCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Guardar();
            }
        }

        private void RegistrarCliente_Load(object sender, EventArgs e)
        {
            if (modo == EnumModoForm.Alta)
            {
                LimpiarControles();
                HabilitarControles(true);
            }
            if (modo == EnumModoForm.Modificacion)
            {
                HabilitarControles(true);
                txtcuit.Enabled = false;
                CargarDatos();
            }
            if (modo == EnumModoForm.Consulta)
            {
                HabilitarControles(false);
                CargarDatos();
                btGuardar.Enabled = false;
            }
        }
        

    }




}