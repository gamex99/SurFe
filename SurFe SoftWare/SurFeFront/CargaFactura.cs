using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurFeFront
{
    public partial class CargaFactura : Form
    {
        public CargaFactura()
        {
            InitializeComponent();
            label2.Text = ClaseCompartida.id_factura; ;
        }

        private void btncarga_Click(object sender, EventArgs e)
        {
            string factura = tbfac.Text + "-" + tbfactura.Text;

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string sql = "UPDATE dbo.compra SET[factura] = @factura WHERE id = @id_compra; ";
            SqlCommand command = new SqlCommand(sql, connection);

            DateTime fechaActual = DateTime.Now;
            command.Parameters.AddWithValue("@id_compra", label2.Text);
            command.Parameters.AddWithValue("@factura", factura);

            // connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            this.Close();
        }
    }
}
