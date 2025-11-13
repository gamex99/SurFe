namespace SurFe
{
    partial class NotaDeCredito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotaDeCredito));
            label1 = new Label();
            labelrazonsocial = new Label();
            button1 = new Button();
            labelcuit = new Label();
            labeldireccion = new Label();
            labellocalidad = new Label();
            cbxfactura = new ComboBox();
            dataGridView1 = new DataGridView();
            label6 = new Label();
            label7 = new Label();
            button2 = new Button();
            txtcodigo = new TextBox();
            txtcantidad = new TextBox();
            button3 = new Button();
            button4 = new Button();
            label8 = new Label();
            subtotal = new Label();
            label10 = new Label();
            label11 = new Label();
            labeltotal = new Label();
            labeliva = new Label();
            btnbuscarart = new Button();
            btnagregar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe MDL2 Assets", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(40, 18);
            label1.Name = "label1";
            label1.Size = new Size(214, 27);
            label1.TabIndex = 0;
            label1.Text = "NOTA DE CREDITO";
            label1.Click += label1_Click;
            // 
            // labelrazonsocial
            // 
            labelrazonsocial.AutoSize = true;
            labelrazonsocial.BackColor = Color.Transparent;
            labelrazonsocial.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelrazonsocial.Location = new Point(40, 74);
            labelrazonsocial.Name = "labelrazonsocial";
            labelrazonsocial.Size = new Size(79, 15);
            labelrazonsocial.TabIndex = 1;
            labelrazonsocial.Text = "Razon Social:";
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.Location = new Point(205, 66);
            button1.Name = "button1";
            button1.Size = new Size(40, 30);
            button1.TabIndex = 2;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // labelcuit
            // 
            labelcuit.AutoSize = true;
            labelcuit.BackColor = Color.Transparent;
            labelcuit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelcuit.Location = new Point(263, 74);
            labelcuit.Name = "labelcuit";
            labelcuit.Size = new Size(40, 15);
            labelcuit.TabIndex = 3;
            labelcuit.Text = "CUIT: ";
            // 
            // labeldireccion
            // 
            labeldireccion.AutoSize = true;
            labeldireccion.BackColor = Color.Transparent;
            labeldireccion.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labeldireccion.Location = new Point(401, 74);
            labeldireccion.Name = "labeldireccion";
            labeldireccion.Size = new Size(66, 15);
            labeldireccion.TabIndex = 4;
            labeldireccion.Text = "Direccion: ";
            // 
            // labellocalidad
            // 
            labellocalidad.AutoSize = true;
            labellocalidad.BackColor = Color.Transparent;
            labellocalidad.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labellocalidad.Location = new Point(546, 73);
            labellocalidad.Name = "labellocalidad";
            labellocalidad.Size = new Size(64, 15);
            labellocalidad.TabIndex = 5;
            labellocalidad.Text = "Localidad: ";
            // 
            // cbxfactura
            // 
            cbxfactura.DisplayMember = "Tipo Factura";
            cbxfactura.FormattingEnabled = true;
            cbxfactura.Items.AddRange(new object[] { "", "Factura A", "Factura B", "Factura C", "Presupuesto" });
            cbxfactura.Location = new Point(297, 25);
            cbxfactura.Name = "cbxfactura";
            cbxfactura.Size = new Size(121, 23);
            cbxfactura.TabIndex = 6;
            cbxfactura.Text = "Tipo Factura";
            cbxfactura.ValueMember = "Tipo Factura";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(40, 156);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(808, 322);
            dataGridView1.TabIndex = 7;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.RowsAdded += dataGridView1_RowsAdded;
            dataGridView1.RowsRemoved += dataGridView1_RowsRemoved;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(40, 125);
            label6.Name = "label6";
            label6.Size = new Size(45, 15);
            label6.TabIndex = 8;
            label6.Text = "Codigo";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(205, 125);
            label7.Name = "label7";
            label7.Size = new Size(55, 15);
            label7.TabIndex = 9;
            label7.Text = "Cantidad";
            // 
            // button2
            // 
            button2.Location = new Point(377, 122);
            button2.Name = "button2";
            button2.Size = new Size(102, 23);
            button2.TabIndex = 10;
            button2.Text = "Sumar Articulo";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // txtcodigo
            // 
            txtcodigo.Location = new Point(92, 121);
            txtcodigo.Name = "txtcodigo";
            txtcodigo.Size = new Size(100, 23);
            txtcodigo.TabIndex = 11;
            // 
            // txtcantidad
            // 
            txtcantidad.Location = new Point(266, 122);
            txtcantidad.Name = "txtcantidad";
            txtcantidad.Size = new Size(95, 23);
            txtcantidad.TabIndex = 12;
            // 
            // button3
            // 
            button3.Location = new Point(692, 525);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 13;
            button3.Text = "Aceptar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(773, 525);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 14;
            button4.Text = "Cancelar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(266, 481);
            label8.Name = "label8";
            label8.Size = new Size(68, 15);
            label8.TabIndex = 15;
            label8.Text = "SubTotal: $";
            label8.Click += label8_Click;
            // 
            // subtotal
            // 
            subtotal.AutoSize = true;
            subtotal.Location = new Point(340, 481);
            subtotal.Name = "subtotal";
            subtotal.Size = new Size(28, 15);
            subtotal.TabIndex = 16;
            subtotal.Text = "0.00";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(476, 481);
            label10.Name = "label10";
            label10.Size = new Size(39, 15);
            label10.TabIndex = 17;
            label10.Text = "IVA: $";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(661, 481);
            label11.Name = "label11";
            label11.Size = new Size(47, 15);
            label11.TabIndex = 18;
            label11.Text = "Total: $";
            label11.Click += label11_Click;
            // 
            // labeltotal
            // 
            labeltotal.AutoSize = true;
            labeltotal.Location = new Point(714, 481);
            labeltotal.Name = "labeltotal";
            labeltotal.Size = new Size(28, 15);
            labeltotal.TabIndex = 19;
            labeltotal.Text = "0.00";
            // 
            // labeliva
            // 
            labeliva.AutoSize = true;
            labeliva.Location = new Point(523, 481);
            labeliva.Name = "labeliva";
            labeliva.Size = new Size(28, 15);
            labeliva.TabIndex = 20;
            labeliva.Text = "0.00";
            // 
            // btnbuscarart
            // 
            btnbuscarart.Location = new Point(505, 122);
            btnbuscarart.Name = "btnbuscarart";
            btnbuscarart.Size = new Size(105, 23);
            btnbuscarart.TabIndex = 22;
            btnbuscarart.Text = "Buscar Articulo";
            btnbuscarart.UseVisualStyleBackColor = true;
            btnbuscarart.Click += btnbuscarart_Click;
            // 
            // btnagregar
            // 
            btnagregar.Location = new Point(645, 125);
            btnagregar.Name = "btnagregar";
            btnagregar.Size = new Size(111, 23);
            btnagregar.TabIndex = 21;
            btnagregar.Text = "Agregar Articulo";
            btnagregar.UseVisualStyleBackColor = true;
            btnagregar.Visible = false;
            btnagregar.Click += btnagregar_Click;
            // 
            // NotaDeCredito
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(881, 561);
            Controls.Add(btnbuscarart);
            Controls.Add(btnagregar);
            Controls.Add(labeliva);
            Controls.Add(labeltotal);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(subtotal);
            Controls.Add(label8);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(txtcantidad);
            Controls.Add(txtcodigo);
            Controls.Add(button2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(dataGridView1);
            Controls.Add(cbxfactura);
            Controls.Add(labellocalidad);
            Controls.Add(labeldireccion);
            Controls.Add(labelcuit);
            Controls.Add(button1);
            Controls.Add(labelrazonsocial);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "NotaDeCredito";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nota de Credito";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label labelrazonsocial;
        private Button button1;
        private Label labelcuit;
        private Label labeldireccion;
        private Label labellocalidad;
        private ComboBox cbxfactura;
        private DataGridView dataGridView1;
        private Label label6;
        private Label label7;
        private Button button2;
        private TextBox txtcodigo;
        private TextBox txtcantidad;
        private Button button3;
        private Button button4;
        private Label label8;
        private Label subtotal;
        private Label label10;
        private Label label11;
        private Label labeltotal;
        private Label labeliva;
        private Button btnagregar;
        private Button btnbuscarart;
    }
}