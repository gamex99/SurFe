namespace SurFe
{
    partial class PuntoDeVenta
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PuntoDeVenta));
            label1 = new Label();
            label2 = new Label();
            bindingSource1 = new BindingSource(components);
            button1 = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            comboBox1 = new ComboBox();
            dataGridView1 = new DataGridView();
            Codigo = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            Producto = new DataGridViewTextBoxColumn();
            Precio = new DataGridViewTextBoxColumn();
            label6 = new Label();
            label7 = new Label();
            button2 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button3 = new Button();
            button4 = new Button();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(40, 18);
            label1.Name = "label1";
            label1.Size = new Size(231, 37);
            label1.TabIndex = 0;
            label1.Text = "PUNTO DE VENTA";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 74);
            label2.Name = "label2";
            label2.Size = new Size(159, 15);
            label2.TabIndex = 1;
            label2.Text = "Razon Social: Facundo Paron";
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.Location = new Point(205, 66);
            button1.Name = "button1";
            button1.Size = new Size(40, 30);
            button1.TabIndex = 2;
            button1.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(263, 74);
            label3.Name = "label3";
            label3.Size = new Size(114, 15);
            label3.TabIndex = 3;
            label3.Text = "CUIT: 20-41637946-8";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(401, 74);
            label4.Name = "label4";
            label4.Size = new Size(120, 15);
            label4.TabIndex = 4;
            label4.Text = "Direccion: Bolivar 325";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(546, 73);
            label5.Name = "label5";
            label5.Size = new Size(107, 15);
            label5.TabIndex = 5;
            label5.Text = "Localidad: Peyrano";
            // 
            // comboBox1
            // 
            comboBox1.DisplayMember = "Tipo Factura";
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Factura A", "Factura B", "Factura C" });
            comboBox1.Location = new Point(297, 32);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 6;
            comboBox1.Text = "Tipo Factura";
            comboBox1.ValueMember = "Tipo Factura";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Codigo, Cantidad, Producto, Precio });
            dataGridView1.Location = new Point(40, 156);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(702, 322);
            dataGridView1.TabIndex = 7;
            // 
            // Codigo
            // 
            Codigo.HeaderText = "Codigo";
            Codigo.Name = "Codigo";
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.Name = "Cantidad";
            // 
            // Producto
            // 
            Producto.HeaderText = "Producto";
            Producto.Name = "Producto";
            Producto.Width = 350;
            // 
            // Precio
            // 
            Precio.HeaderText = "Precio";
            Precio.Name = "Precio";
            Precio.Width = 125;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(40, 125);
            label6.Name = "label6";
            label6.Size = new Size(46, 15);
            label6.TabIndex = 8;
            label6.Text = "Codigo";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(205, 125);
            label7.Name = "label7";
            label7.Size = new Size(55, 15);
            label7.TabIndex = 9;
            label7.Text = "Cantidad";
            // 
            // button2
            // 
            button2.Location = new Point(391, 121);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 10;
            button2.Text = "Agregar";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(92, 121);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 11;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(266, 122);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(95, 23);
            textBox2.TabIndex = 12;
            // 
            // button3
            // 
            button3.Location = new Point(523, 525);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 13;
            button3.Text = "Aceptar";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(643, 525);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 14;
            button4.Text = "Cancelar";
            button4.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(377, 481);
            label8.Name = "label8";
            label8.Size = new Size(68, 15);
            label8.TabIndex = 15;
            label8.Text = "SubTotal: $";
            label8.Click += label8_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(451, 481);
            label9.Name = "label9";
            label9.Size = new Size(28, 15);
            label9.TabIndex = 16;
            label9.Text = "0.00";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(507, 481);
            label10.Name = "label10";
            label10.Size = new Size(39, 15);
            label10.TabIndex = 17;
            label10.Text = "IVA: $";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(590, 481);
            label11.Name = "label11";
            label11.Size = new Size(47, 15);
            label11.TabIndex = 18;
            label11.Text = "Total: $";
            label11.Click += label11_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(643, 481);
            label12.Name = "label12";
            label12.Size = new Size(28, 15);
            label12.TabIndex = 19;
            label12.Text = "0.00";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(536, 481);
            label13.Name = "label13";
            label13.Size = new Size(28, 15);
            label13.TabIndex = 20;
            label13.Text = "0.00";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(dataGridView1);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Punto de Venta";
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private BindingSource bindingSource1;
        private Button button1;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox comboBox1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Codigo;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Producto;
        private DataGridViewTextBoxColumn Precio;
        private Label label6;
        private Label label7;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button3;
        private Button button4;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
    }
}