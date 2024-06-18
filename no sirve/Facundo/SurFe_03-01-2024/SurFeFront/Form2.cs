using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurFe
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void RecalcularSuma()
        {
            decimal SumaSubtotal = 0;
            decimal IVA = 0 ;
            decimal total = 0;

            // Iterar a través de todas las filas en la columna "ColumnaNumerica"
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Verificar si la celda no está vacía
                if (row.Cells["Precio"].Value != null)
                {
                    // Sumar el valor de la celda a la variable suma
                    SumaSubtotal += Convert.ToDecimal(row.Cells["Precio"].Value);

                }
            }
            IVA = SumaSubtotal * (decimal).21;
            total = SumaSubtotal + IVA;
            // Mostrar la suma en algún lugar, como un TextBox
            subtotal.Text = SumaSubtotal.ToString();
            labeliva.Text = IVA.ToString();
            labeltotal.Text = total.ToString();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RecalcularSuma();

        }
    }
}
