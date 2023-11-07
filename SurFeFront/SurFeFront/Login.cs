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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txtCont.PasswordChar = '•';
        }


        private void btAcceso_Click(object sender, EventArgs e)
        {

           

            string usuario = txtUsu.Text; 
            string contraseña = txtCont.Text; 

           
            if (usuario == "admin" && contraseña == "admin")
            {
               
                this.Hide(); 
                             
                SurFe.Form1 f1 = new SurFe.Form1();
                f1.ShowDialog();
            }
            else
            {
                
                MessageBox.Show("Credenciales incorrectas. Por favor, inténtelo de nuevo.");
            }

        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void txtCont_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
