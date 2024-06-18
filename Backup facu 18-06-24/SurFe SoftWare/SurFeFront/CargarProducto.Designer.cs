namespace SurFe
{
    partial class CargarProducto
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
            cbCategoria = new ComboBox();
            tbbarcode = new TextBox();
            tbdetalle = new TextBox();
            tbstock = new TextBox();
            tbprecio = new TextBox();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnCargar = new Button();
            btnCancelar = new Button();
            groupBox1 = new GroupBox();
            rbOtroNo = new RadioButton();
            rbOtroSi = new RadioButton();
            label3 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Menu;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(22, 27);
            label1.Name = "label1";
            label1.Size = new Size(116, 15);
            label1.TabIndex = 0;
            label1.Text = "NUEVO PRODUCTO";
            label1.Click += label1_Click;
            // 
            // cbCategoria
            // 
            cbCategoria.DisplayMember = "Categoria";
            cbCategoria.FormattingEnabled = true;
            cbCategoria.Location = new Point(12, 95);
            cbCategoria.Name = "cbCategoria";
            cbCategoria.Size = new Size(121, 23);
            cbCategoria.TabIndex = 1;
            cbCategoria.Text = "Categoria";
            cbCategoria.ValueMember = "Categoria";
            // 
            // tbbarcode
            // 
            tbbarcode.ForeColor = SystemColors.WindowText;
            tbbarcode.Location = new Point(139, 95);
            tbbarcode.Name = "tbbarcode";
            tbbarcode.PlaceholderText = "Barcode";
            tbbarcode.RightToLeft = RightToLeft.No;
            tbbarcode.Size = new Size(121, 23);
            tbbarcode.TabIndex = 2;
            // 
            // tbdetalle
            // 
            tbdetalle.Location = new Point(266, 95);
            tbdetalle.Name = "tbdetalle";
            tbdetalle.PlaceholderText = "Detalle";
            tbdetalle.Size = new Size(121, 23);
            tbdetalle.TabIndex = 4;
            // 
            // tbstock
            // 
            tbstock.Location = new Point(393, 95);
            tbstock.Name = "tbstock";
            tbstock.PlaceholderText = "Stock";
            tbstock.Size = new Size(121, 23);
            tbstock.TabIndex = 5;
            // 
            // tbprecio
            // 
            tbprecio.Location = new Point(520, 95);
            tbprecio.Name = "tbprecio";
            tbprecio.PlaceholderText = "Precio";
            tbprecio.Size = new Size(121, 23);
            tbprecio.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(173, 72);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 7;
            label2.Text = "BarCode";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(302, 72);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 9;
            label4.Text = "Detalle";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(431, 72);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 10;
            label5.Text = "Stock";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(558, 72);
            label6.Name = "label6";
            label6.Size = new Size(40, 15);
            label6.TabIndex = 11;
            label6.Text = "Precio";
            label6.Click += label6_Click;
            // 
            // btnCargar
            // 
            btnCargar.BackColor = SystemColors.Menu;
            btnCargar.Location = new Point(475, 182);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(75, 23);
            btnCargar.TabIndex = 12;
            btnCargar.Text = "Cargar";
            btnCargar.UseVisualStyleBackColor = false;
            btnCargar.Click += button1_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(566, 182);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += button2_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbOtroNo);
            groupBox1.Controls.Add(rbOtroSi);
            groupBox1.Location = new Point(475, 134);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(163, 42);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "CargarOtro?";
            // 
            // rbOtroNo
            // 
            rbOtroNo.AutoSize = true;
            rbOtroNo.Location = new Point(57, 18);
            rbOtroNo.Name = "rbOtroNo";
            rbOtroNo.Size = new Size(41, 19);
            rbOtroNo.TabIndex = 1;
            rbOtroNo.TabStop = true;
            rbOtroNo.Text = "No";
            rbOtroNo.UseVisualStyleBackColor = true;
            // 
            // rbOtroSi
            // 
            rbOtroSi.AutoSize = true;
            rbOtroSi.Location = new Point(11, 18);
            rbOtroSi.Name = "rbOtroSi";
            rbOtroSi.Size = new Size(34, 19);
            rbOtroSi.TabIndex = 0;
            rbOtroSi.TabStop = true;
            rbOtroSi.Text = "Si";
            rbOtroSi.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 72);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 15;
            label3.Text = "Categoria";
            label3.Click += label3_Click;
            // 
            // CargarProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            ClientSize = new Size(655, 213);
            Controls.Add(label3);
            Controls.Add(groupBox1);
            Controls.Add(btnCancelar);
            Controls.Add(btnCargar);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(tbprecio);
            Controls.Add(tbstock);
            Controls.Add(tbdetalle);
            Controls.Add(tbbarcode);
            Controls.Add(cbCategoria);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "CargarProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nuevo Producto";
            Load += CargarProducto_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbCategoria;
        private TextBox tbbarcode;
        private TextBox tbdetalle;
        private TextBox tbstock;
        private TextBox tbprecio;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button btnCargar;
        private Button btnCancelar;
        private GroupBox groupBox1;
        private RadioButton rbOtroNo;
        private RadioButton rbOtroSi;
        private Label label3;
    }
}