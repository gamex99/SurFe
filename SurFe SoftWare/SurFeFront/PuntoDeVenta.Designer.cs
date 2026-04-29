namespace SurFe
{
    partial class PuntoDeVenta
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PuntoDeVenta));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
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
            btnagregar = new Button();
            btnbuscarart = new Button();
            btnpresu = new Button();
            btnmod = new Button();
            panelHeader = new Panel();
            panelTotales = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelHeader.SuspendLayout();
            panelTotales.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(30, 41, 59);
            label1.Location = new Point(20, 15);
            label1.Name = "label1";
            label1.Size = new Size(208, 32);
            label1.TabIndex = 0;
            label1.Text = "PUNTO DE VENTA";
            // 
            // labelrazonsocial
            // 
            labelrazonsocial.AutoSize = true;
            labelrazonsocial.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelrazonsocial.Location = new Point(25, 65);
            labelrazonsocial.Name = "labelrazonsocial";
            labelrazonsocial.Size = new Size(89, 17);
            labelrazonsocial.TabIndex = 1;
            labelrazonsocial.Text = "Razón Social:";
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(240, 58);
            button1.Name = "button1";
            button1.Size = new Size(35, 30);
            button1.TabIndex = 2;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // labelcuit
            // 
            labelcuit.AutoSize = true;
            labelcuit.Location = new Point(290, 67);
            labelcuit.Name = "labelcuit";
            labelcuit.Size = new Size(39, 15);
            labelcuit.TabIndex = 3;
            labelcuit.Text = "CUIT: ";
            // 
            // labeldireccion
            // 
            labeldireccion.AutoSize = true;
            labeldireccion.Location = new Point(450, 67);
            labeldireccion.Name = "labeldireccion";
            labeldireccion.Size = new Size(63, 15);
            labeldireccion.TabIndex = 4;
            labeldireccion.Text = "Dirección: ";
            // 
            // labellocalidad
            // 
            labellocalidad.AutoSize = true;
            labellocalidad.Location = new Point(650, 67);
            labellocalidad.Name = "labellocalidad";
            labellocalidad.Size = new Size(64, 15);
            labellocalidad.TabIndex = 5;
            labellocalidad.Text = "Localidad: ";
            // 
            // cbxfactura
            // 
            cbxfactura.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxfactura.FormattingEnabled = true;
            cbxfactura.Items.AddRange(new object[] { "Seleccionar...", "Factura A", "Factura B", "Factura C", "Presupuesto" });
            cbxfactura.Location = new Point(720, 24);
            cbxfactura.Name = "cbxfactura";
            cbxfactura.Size = new Size(140, 23);
            cbxfactura.TabIndex = 6;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(59, 130, 246);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Location = new Point(20, 160);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(840, 280);
            dataGridView1.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(25, 120);
            label6.Name = "label6";
            label6.Size = new Size(45, 15);
            label6.TabIndex = 8;
            label6.Text = "Código";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(195, 120);
            label7.Name = "label7";
            label7.Size = new Size(54, 15);
            label7.TabIndex = 9;
            label7.Text = "Cantidad";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(34, 197, 94);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Location = new Point(370, 116);
            button2.Name = "button2";
            button2.Size = new Size(110, 25);
            button2.TabIndex = 10;
            button2.Text = "+ Agregar";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // txtcodigo
            // 
            txtcodigo.Location = new Point(75, 117);
            txtcodigo.Name = "txtcodigo";
            txtcodigo.Size = new Size(100, 23);
            txtcodigo.TabIndex = 11;
            // 
            // txtcantidad
            // 
            txtcantidad.Location = new Point(255, 117);
            txtcantidad.Name = "txtcantidad";
            txtcantidad.Size = new Size(70, 23);
            txtcantidad.TabIndex = 12;
            txtcantidad.Text = "1";
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(59, 130, 246);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = Color.White;
            button3.Location = new Point(720, 505);
            button3.Name = "button3";
            button3.Size = new Size(140, 40);
            button3.TabIndex = 13;
            button3.Text = "CONFIRMAR VENTA";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(239, 68, 68);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = Color.White;
            button4.Location = new Point(20, 510);
            button4.Name = "button4";
            button4.Size = new Size(100, 30);
            button4.TabIndex = 14;
            button4.Text = "Cancelar";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(15, 10);
            label8.Name = "label8";
            label8.Size = new Size(90, 20);
            label8.TabIndex = 15;
            label8.Text = "Subtotal:   $";
            // 
            // subtotal
            // 
            subtotal.AutoSize = true;
            subtotal.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            subtotal.Location = new Point(110, 10);
            subtotal.Name = "subtotal";
            subtotal.Size = new Size(37, 20);
            subtotal.TabIndex = 16;
            subtotal.Text = "0.00";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(200, 10);
            label10.Name = "label10";
            label10.Size = new Size(56, 20);
            label10.TabIndex = 17;
            label10.Text = "IVA:   $";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = Color.FromArgb(30, 41, 59);
            label11.Location = new Point(400, 10);
            label11.Name = "label11";
            label11.Size = new Size(106, 30);
            label11.TabIndex = 18;
            label11.Text = "TOTAL:  $";
            // 
            // labeltotal
            // 
            labeltotal.AutoSize = true;
            labeltotal.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            labeltotal.ForeColor = Color.FromArgb(30, 41, 59);
            labeltotal.Location = new Point(510, 10);
            labeltotal.Name = "labeltotal";
            labeltotal.Size = new Size(55, 30);
            labeltotal.TabIndex = 19;
            labeltotal.Text = "0.00";
            // 
            // labeliva
            // 
            labeliva.AutoSize = true;
            labeliva.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labeliva.Location = new Point(260, 10);
            labeliva.Name = "labeliva";
            labeliva.Size = new Size(37, 20);
            labeliva.TabIndex = 20;
            labeliva.Text = "0.00";
            // 
            // btnagregar
            // 
            btnagregar.Location = new Point(0, 0);
            btnagregar.Name = "btnagregar";
            btnagregar.Size = new Size(75, 23);
            btnagregar.TabIndex = 0;
            // 
            // btnbuscarart
            // 
            btnbuscarart.BackColor = Color.FromArgb(226, 232, 240);
            btnbuscarart.FlatStyle = FlatStyle.Flat;
            btnbuscarart.Location = new Point(490, 116);
            btnbuscarart.Name = "btnbuscarart";
            btnbuscarart.Size = new Size(105, 25);
            btnbuscarart.TabIndex = 22;
            btnbuscarart.Text = "🔍 Buscar F2";
            btnbuscarart.UseVisualStyleBackColor = false;
            btnbuscarart.Click += btnbuscarart_Click;
            // 
            // btnpresu
            // 
            btnpresu.BackColor = Color.FromArgb(71, 85, 105);
            btnpresu.FlatAppearance.BorderSize = 0;
            btnpresu.FlatStyle = FlatStyle.Flat;
            btnpresu.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnpresu.ForeColor = Color.White;
            btnpresu.Location = new Point(420, 510);
            btnpresu.Name = "btnpresu";
            btnpresu.Size = new Size(140, 30);
            btnpresu.TabIndex = 23;
            btnpresu.Text = "Solo Presupuesto";
            btnpresu.UseVisualStyleBackColor = false;
            btnpresu.Click += btnpresu_Click;
            // 
            // btnmod
            // 
            btnmod.Location = new Point(570, 510);
            btnmod.Name = "btnmod";
            btnmod.Size = new Size(100, 30);
            btnmod.TabIndex = 24;
            btnmod.Text = "Editar Grilla";
            btnmod.UseVisualStyleBackColor = true;
            btnmod.Click += btnmod_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(248, 250, 252);
            panelHeader.Controls.Add(label1);
            panelHeader.Controls.Add(cbxfactura);
            panelHeader.Controls.Add(labelrazonsocial);
            panelHeader.Controls.Add(button1);
            panelHeader.Controls.Add(labelcuit);
            panelHeader.Controls.Add(labeldireccion);
            panelHeader.Controls.Add(labellocalidad);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(881, 100);
            panelHeader.TabIndex = 25;
            // 
            // panelTotales
            // 
            panelTotales.BackColor = Color.FromArgb(241, 245, 249);
            panelTotales.Controls.Add(label8);
            panelTotales.Controls.Add(subtotal);
            panelTotales.Controls.Add(label10);
            panelTotales.Controls.Add(labeliva);
            panelTotales.Controls.Add(label11);
            panelTotales.Controls.Add(labeltotal);
            panelTotales.Location = new Point(20, 445);
            panelTotales.Name = "panelTotales";
            panelTotales.Size = new Size(840, 50);
            panelTotales.TabIndex = 26;
            // 
            // PuntoDeVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(881, 561);
            Controls.Add(panelTotales);
            Controls.Add(panelHeader);
            Controls.Add(btnmod);
            Controls.Add(btnpresu);
            Controls.Add(btnbuscarart);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(txtcantidad);
            Controls.Add(txtcodigo);
            Controls.Add(button2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PuntoDeVenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SurFe - Gestión de Ventas";
            Load += Form2_Load;
            KeyDown += PuntoDeVenta_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelTotales.ResumeLayout(false);
            panelTotales.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelrazonsocial;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelcuit;
        private System.Windows.Forms.Label labeldireccion;
        private System.Windows.Forms.Label labellocalidad;
        private System.Windows.Forms.ComboBox cbxfactura;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.TextBox txtcantidad;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label subtotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labeltotal;
        private System.Windows.Forms.Label labeliva;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.Button btnbuscarart;
        private System.Windows.Forms.Button btnpresu;
        private System.Windows.Forms.Button btnmod;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelTotales;
    }
}