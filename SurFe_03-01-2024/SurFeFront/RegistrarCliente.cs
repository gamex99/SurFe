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
                //cargo los datos ingresados en un objeto empleado
                ClienteModel cli = new ClienteModel();
                cli.razon_social = txtrazonsocial.Text.Trim();
                cli.cuit = txtdni.Text.Trim();
                cli.cuit = txtcuit.Text.Trim();

                ///////////////
                string seleccion = cbxiva.SelectedIndex.ToString();


                // Utiliza una estructura condicional para asignar valores según la selección
                string valor = "0";
                if (seleccion == "Responsable Inscripto")
                {
                    valor = "1";
                }
                else if (seleccion == "Consumidor Final")
                {
                    valor = "2";
                }
                else if (seleccion == "Exento")
                {
                    valor = "3";
                }

                /////////////
                cli.condicion_iva = valor;
                cli.tipo_factura = cbxtfac.SelectedIndex.ToString();
                cli.domicilio = txtDom.Text.Trim();
                cli.provincia = cbxprov.SelectedIndex.ToString();
                cli.localidad = cbxLoc.SelectedIndex.ToString();
                cli.cp = txtCp.Text.Trim();
                cli.telefono = txtTel.Text.Trim();
                string mensajeErrores = "";
                //realizo validaciones. El mensaje va por referencia
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
                //////////////////////////////////////////////hasta aca llegue 
                int idEmp = ClienteNegocio.Insert(cli);

                MessageBox.Show("Se generó el empleado nro " +
               idEmp.ToString(), "Empleado creado", MessageBoxButtons.OK, MessageBoxIcon.Information);


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
            txtcuit.Text = "";
            txtdni.Text = "";
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
                //HabilitarControles(true);
            }
            if (modo == EnumModoForm.Modificacion)
            {
                //HabilitarControles(true);
                //CargarDatos();
            }
            if (modo == EnumModoForm.Consulta)
            {
                //HabilitarControles(false);
                //CargarDatos();
                btGuardar.Enabled = false;
            }
        }
        

    }




}