using SurFeEntidades;
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
                int idEmp = ClienteModel.Insert(cli);
                txtId.Text = idEmp.ToString();
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
            if (String.IsNullOrEmpty(e.Dni.Trim()))
            {
                mensaje += "\nError en DNI";
            }
            if (String.IsNullOrEmpty(e.Nombre.Trim()))
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
            txtId.Text = "";
            txtSalario.Value = 0;
            txtDireccion.Text = "";
            txtDni.Text = "";
            txtIngreso.Value = DateTime.Now;
            txtNombre.Text = "";
        }

        private void txtNomAp_TextChanged(object sender, EventArgs e)
        {

        }
        // todavia no  private void FrmEditEmpleados_Load(object sender, EventArgs e)
        //{
        //   LimpiarControles();
        //}
        private int cbxiva_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si hay algo seleccionado en el ComboBox
            if (cbxiva.SelectedItem != null)
            {
                // Obtén el texto del elemento seleccionado
                string seleccion = cbxiva.SelectedItem.ToString();

                // Utiliza una estructura condicional para asignar valores según la selección
                int valor;
                if (seleccion == "Responsable Inscripto")
                {
                    valor = 1;
                }
                else if (seleccion == "Consumidor Final")
                {
                    valor = 2;
                }
                else if (seleccion == "Exento")
                {
                    valor = 3;
                }
                else
                {
                    // Asigna un valor por defecto o maneja el caso no previsto
                    valor = 0;

                }

                // Utiliza el valor según sea necesario
                
            }

        }
}