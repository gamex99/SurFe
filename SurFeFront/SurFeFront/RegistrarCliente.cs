using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using SurFeEntidades;
using SurFeNegocio;
namespace SurFeFront
{
    public partial class RegistrarCliente : Form
    {
        public EnumModoForm modo = EnumModoForm.Alta;

        public Cliente _cliente = new Cliente();
        public RegistrarCliente()
        {
            InitializeComponent();
        }
        private void FrmEditEmpleados_Load(object sender, EventArgs e)
        {


            if (modo == EnumModoForm.Alta)
            {
                LimpiarControles();
                HabilitarControles(true);
            }
            // if (modo == EnumModoForm.Modificacion)
            //{
            //  HabilitarControles(true);
            //CargarDatos();
            //}

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

        }

        private void LimpiarControles()
        {
            //hay que hacerlo todavia, todos lo txt van a vacio.
        }
        private void HabilitarControles(bool habilitar)
        {

            //txtSalario.Enabled = habilitar;
            //txtDireccion.Enabled = habilitar;
            //hay que hacerlo tamb
        }

        private void Guardar() //////////////////////////////////////////////////////sigo aca perri dale
        {
            try
            {
                //cargo los datos ingresados en un objeto empleado
                ClienteModel cli = new ClienteModel();
                //emp.razon_social = txtSalario.Value;
                cli.razon_social = txtRazonSocial.Text.Trim();
                cli.cuit = txtCuit.Text.Trim();
                cli.condicion_iva = (string)cbxIva.SelectedValue;
                cli.tipo_factura = (string)cbxTfac.SelectedValue;
                cli.domicilio = txtDom.Text.Trim();
                cli.telefono = txtTel.Text.Trim();
                cli.localidad = txtLocalidad.Text.Trim();
                cli.cp = txtCodigoPostal.Text.Trim();



                
                string mensajeErrores = "";
              

                //las validaciones estan bien
                //pregunto si quiere guardar los datos
                DialogResult res = MessageBox.Show("¿Confirma guardar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                {
                    return;
                }

                //Guardo los datos

                if (modo == EnumModoForm.Alta)
                {
                    int idEmp = EmpleadosNegocio.Insert(emp);
                    txtId.Text = idEmp.ToString();
                    MessageBox.Show("Se generó el empleado nro " + idEmp.ToString(), "Empleado creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (modo == EnumModoForm.Modificacion)
                {
                    emp.id = Convert.ToInt32(txtId.Text);
                    EmpleadosNegocio.Update(emp);
                    MessageBox.Show("Se actualizaron los datos correctamente", "Empleado actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }


                LimpiarControles();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumDoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegistrarCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
