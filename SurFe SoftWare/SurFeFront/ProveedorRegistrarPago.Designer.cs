namespace SurFeFront
{
    partial class ProveedorRegistrarPago
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            lbrazonsocial = new Label();
            label4 = new Label();
            tbfactura = new TextBox();
            label3 = new Label();
            tbmonto = new TextBox();
            label5 = new Label();
            dateTimePicker1 = new DateTimePicker();
            dataGridView1 = new DataGridView();
            cargarfactura = new Button();
            buscarproveedor = new Button();
            btnsalir = new Button();
            tbBuscar = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 24);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 0;
            label1.Text = "ProveedoresPago";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 69);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 1;
            label2.Text = "Proveedor:";
            // 
            // lbrazonsocial
            // 
            lbrazonsocial.AutoSize = true;
            lbrazonsocial.Location = new Point(97, 69);
            lbrazonsocial.Name = "lbrazonsocial";
            lbrazonsocial.Size = new Size(52, 15);
            lbrazonsocial.TabIndex = 2;
            lbrazonsocial.Text = "*********";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 94);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 3;
            label4.Text = "Factura:";
            // 
            // tbfactura
            // 
            tbfactura.Location = new Point(97, 87);
            tbfactura.Name = "tbfactura";
            tbfactura.Size = new Size(100, 23);
            tbfactura.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 120);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 5;
            label3.Text = "Monto";
            // 
            // tbmonto
            // 
            tbmonto.Location = new Point(97, 117);
            tbmonto.Name = "tbmonto";
            tbmonto.Size = new Size(100, 23);
            tbmonto.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(458, 67);
            label5.Name = "label5";
            label5.Size = new Size(71, 15);
            label5.TabIndex = 7;
            label5.Text = "Dia De Pago";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(535, 61);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 8;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 186);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(776, 233);
            dataGridView1.TabIndex = 9;
            // 
            // cargarfactura
            // 
            cargarfactura.Location = new Point(713, 121);
            cargarfactura.Name = "cargarfactura";
            cargarfactura.Size = new Size(75, 23);
            cargarfactura.TabIndex = 10;
            cargarfactura.Text = "CargarFatura";
            cargarfactura.UseVisualStyleBackColor = true;
            cargarfactura.Click += cargarfactura_Click;
            // 
            // buscarproveedor
            // 
            buscarproveedor.Location = new Point(360, 62);
            buscarproveedor.Name = "buscarproveedor";
            buscarproveedor.Size = new Size(92, 23);
            buscarproveedor.TabIndex = 13;
            buscarproveedor.Text = "Buscar Proveedor";
            buscarproveedor.UseVisualStyleBackColor = true;
            buscarproveedor.Click += buscarproveedor_Click;
            // 
            // btnsalir
            // 
            btnsalir.Location = new Point(713, 425);
            btnsalir.Name = "btnsalir";
            btnsalir.Size = new Size(75, 23);
            btnsalir.TabIndex = 14;
            btnsalir.Text = "Salir";
            btnsalir.UseVisualStyleBackColor = true;
            // 
            // tbBuscar
            // 
            tbBuscar.Location = new Point(12, 157);
            tbBuscar.Name = "tbBuscar";
            tbBuscar.Size = new Size(776, 23);
            tbBuscar.TabIndex = 15;
            // 
            // ProveedorRegistrarPago
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbBuscar);
            Controls.Add(btnsalir);
            Controls.Add(buscarproveedor);
            Controls.Add(cargarfactura);
            Controls.Add(dataGridView1);
            Controls.Add(dateTimePicker1);
            Controls.Add(label5);
            Controls.Add(tbmonto);
            Controls.Add(label3);
            Controls.Add(tbfactura);
            Controls.Add(label4);
            Controls.Add(lbrazonsocial);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ProveedorRegistrarPago";
            Text = "ProveedorRegistrarPago";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label lbrazonsocial;
        private Label label4;
        private TextBox tbfactura;
        private Label label3;
        private TextBox tbmonto;
        private Label label5;
        private DateTimePicker dateTimePicker1;
        private DataGridView dataGridView1;
        private Button cargarfactura;
        private Button buscarproveedor;
        private Button btnsalir;
        private TextBox tbBuscar;
    }
}