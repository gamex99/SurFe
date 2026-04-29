namespace SurFe
{
    partial class NotaDeCredito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotaDeCredito));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            label1 = new System.Windows.Forms.Label();
            labelrazonsocial = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            labelcuit = new System.Windows.Forms.Label();
            labeldireccion = new System.Windows.Forms.Label();
            labellocalidad = new System.Windows.Forms.Label();
            cbxfactura = new System.Windows.Forms.ComboBox();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            button2 = new System.Windows.Forms.Button();
            txtcodigo = new System.Windows.Forms.TextBox();
            txtcantidad = new System.Windows.Forms.TextBox();
            button3 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            label8 = new System.Windows.Forms.Label();
            subtotal = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            labeltotal = new System.Windows.Forms.Label();
            labeliva = new System.Windows.Forms.Label();
            btnbuscarart = new System.Windows.Forms.Button();
            btnagregar = new System.Windows.Forms.Button();
            panelHeader = new System.Windows.Forms.Panel();
            panelTotales = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelHeader.SuspendLayout();
            panelTotales.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.Color.FromArgb(153, 27, 27); // Rojo para diferenciar de factura
            label1.Location = new System.Drawing.Point(20, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(225, 32);
            label1.TabIndex = 0;
            label1.Text = "NOTA DE CRÉDITO";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.FromArgb(254, 242, 242); // Fondo rojizo tenue
            panelHeader.Controls.Add(label1);
            panelHeader.Controls.Add(cbxfactura);
            panelHeader.Controls.Add(labelrazonsocial);
            panelHeader.Controls.Add(button1);
            panelHeader.Controls.Add(labelcuit);
            panelHeader.Controls.Add(labeldireccion);
            panelHeader.Controls.Add(labellocalidad);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(881, 100);
            panelHeader.TabIndex = 25;
            // 
            // labelrazonsocial
            // 
            labelrazonsocial.AutoSize = true;
            labelrazonsocial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            labelrazonsocial.Location = new System.Drawing.Point(25, 65);
            labelrazonsocial.Name = "labelrazonsocial";
            labelrazonsocial.Size = new System.Drawing.Size(90, 17);
            labelrazonsocial.TabIndex = 1;
            labelrazonsocial.Text = "Razón Social:";
            // 
            // button1
            // 
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Image = (System.Drawing.Image)resources.GetObject("button1.BackgroundImage");
            button1.Location = new System.Drawing.Point(240, 58);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(35, 30);
            button1.TabIndex = 2;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // labelcuit
            // 
            labelcuit.AutoSize = true;
            labelcuit.Location = new System.Drawing.Point(290, 67);
            labelcuit.Name = "labelcuit";
            labelcuit.Size = new System.Drawing.Size(41, 15);
            labelcuit.TabIndex = 3;
            labelcuit.Text = "CUIT: ";
            // 
            // labeldireccion
            // 
            labeldireccion.AutoSize = true;
            labeldireccion.Location = new System.Drawing.Point(450, 67);
            labeldireccion.Name = "labeldireccion";
            labeldireccion.Size = new System.Drawing.Size(63, 15);
            labeldireccion.TabIndex = 4;
            labeldireccion.Text = "Dirección: ";
            // 
            // labellocalidad
            // 
            labellocalidad.AutoSize = true;
            labellocalidad.Location = new System.Drawing.Point(650, 67);
            labellocalidad.Name = "labellocalidad";
            labellocalidad.Size = new System.Drawing.Size(64, 15);
            labellocalidad.TabIndex = 5;
            labellocalidad.Text = "Localidad: ";
            // 
            // cbxfactura
            // 
            cbxfactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbxfactura.FormattingEnabled = true;
            cbxfactura.Items.AddRange(new object[] { "NC Relacionada...", "Nota de Crédito A", "Nota de Crédito B", "Nota de Crédito C" });
            cbxfactura.Location = new System.Drawing.Point(680, 24);
            cbxfactura.Name = "cbxfactura";
            cbxfactura.Size = new System.Drawing.Size(180, 23);
            cbxfactura.TabIndex = 6;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(153, 27, 27);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Location = new System.Drawing.Point(20, 160);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new System.Drawing.Size(840, 280);
            dataGridView1.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            label6.Location = new System.Drawing.Point(25, 120);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(45, 15);
            label6.TabIndex = 8;
            label6.Text = "Código";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            label7.Location = new System.Drawing.Point(195, 120);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(54, 15);
            label7.TabIndex = 9;
            label7.Text = "Cantidad";
            // 
            // button2
            // 
            button2.BackColor = System.Drawing.Color.FromArgb(220, 38, 38);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            button2.ForeColor = System.Drawing.Color.White;
            button2.Location = new System.Drawing.Point(370, 116);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(120, 25);
            button2.TabIndex = 10;
            button2.Text = "Añadir Devolución";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // txtcodigo
            // 
            txtcodigo.Location = new System.Drawing.Point(75, 117);
            txtcodigo.Name = "txtcodigo";
            txtcodigo.Size = new System.Drawing.Size(100, 23);
            txtcodigo.TabIndex = 11;
            // 
            // txtcantidad
            // 
            txtcantidad.Location = new System.Drawing.Point(255, 117);
            txtcantidad.Name = "txtcantidad";
            txtcantidad.Size = new System.Drawing.Size(70, 23);
            txtcantidad.TabIndex = 12;
            txtcantidad.Text = "1";
            // 
            // btnbuscarart
            // 
            btnbuscarart.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            btnbuscarart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnbuscarart.Location = new System.Drawing.Point(505, 116);
            btnbuscarart.Name = "btnbuscarart";
            btnbuscarart.Size = new System.Drawing.Size(105, 25);
            btnbuscarart.TabIndex = 22;
            btnbuscarart.Text = "🔍 Buscar F2";
            btnbuscarart.UseVisualStyleBackColor = false;
            btnbuscarart.Click += btnbuscarart_Click;
            // 
            // panelTotales
            // 
            panelTotales.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            panelTotales.Controls.Add(label8);
            panelTotales.Controls.Add(subtotal);
            panelTotales.Controls.Add(label10);
            panelTotales.Controls.Add(labeliva);
            panelTotales.Controls.Add(label11);
            panelTotales.Controls.Add(labeltotal);
            panelTotales.Location = new System.Drawing.Point(20, 445);
            panelTotales.Name = "panelTotales";
            panelTotales.Size = new System.Drawing.Size(840, 50);
            panelTotales.TabIndex = 26;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            label8.Location = new System.Drawing.Point(15, 10);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(89, 20);
            label8.TabIndex = 15;
            label8.Text = "Subtotal:   $";
            // 
            // subtotal
            // 
            subtotal.AutoSize = true;
            subtotal.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            subtotal.Location = new System.Drawing.Point(110, 10);
            subtotal.Name = "subtotal";
            subtotal.Size = new System.Drawing.Size(37, 20);
            subtotal.TabIndex = 16;
            subtotal.Text = "0.00";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            label10.Location = new System.Drawing.Point(200, 10);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(56, 20);
            label10.TabIndex = 17;
            label10.Text = "IVA:   $";
            // 
            // labeliva
            // 
            labeliva.AutoSize = true;
            labeliva.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            labeliva.Location = new System.Drawing.Point(260, 10);
            labeliva.Name = "labeliva";
            labeliva.Size = new System.Drawing.Size(37, 20);
            labeliva.TabIndex = 20;
            labeliva.Text = "0.00";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            label11.ForeColor = System.Drawing.Color.FromArgb(153, 27, 27);
            label11.Location = new System.Drawing.Point(400, 10);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(107, 30);
            label11.TabIndex = 18;
            label11.Text = "TOTAL:  $";
            // 
            // labeltotal
            // 
            labeltotal.AutoSize = true;
            labeltotal.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            labeltotal.Location = new System.Drawing.Point(510, 10);
            labeltotal.Name = "labeltotal";
            labeltotal.Size = new System.Drawing.Size(55, 30);
            labeltotal.TabIndex = 19;
            labeltotal.Text = "0.00";
            // 
            // button3
            // 
            button3.BackColor = System.Drawing.Color.FromArgb(153, 27, 27);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            button3.ForeColor = System.Drawing.Color.White;
            button3.Location = new System.Drawing.Point(680, 505);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(180, 40);
            button3.TabIndex = 13;
            button3.Text = "EMITIR NOTA CRÉDITO";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = System.Drawing.Color.FromArgb(71, 85, 105);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            button4.ForeColor = System.Drawing.Color.White;
            button4.Location = new System.Drawing.Point(20, 510);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(100, 30);
            button4.TabIndex = 14;
            button4.Text = "Cancelar";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // NotaDeCredito
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(881, 561);
            Controls.Add(panelTotales);
            Controls.Add(panelHeader);
            Controls.Add(btnbuscarart);
            Controls.Add(btnagregar);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(txtcantidad);
            Controls.Add(txtcodigo);
            Controls.Add(button2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(dataGridView1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "NotaDeCredito";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SurFe - Notas de Crédito";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelTotales.ResumeLayout(false);
            panelTotales.PerformLayout();
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
        private Button btnbuscarart;
        private Button btnagregar;
        private Panel panelHeader;
        private Panel panelTotales;
    }
}