namespace SurFe
{
    partial class CargarProducto
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
            // label1 (Título Principal)
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(45, 45, 48);
            label1.Location = new Point(20, 15);
            label1.Name = "label1";
            label1.Size = new Size(181, 25);
            label1.TabIndex = 0;
            label1.Text = "NUEVO PRODUCTO";
            // 
            // label3 (Label Categoría)
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label3.Location = new Point(12, 65);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 15;
            label3.Text = "Categoría";
            // 
            // cbCategoria
            // 
            cbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategoria.Font = new Font("Segoe UI", 10F);
            cbCategoria.FormattingEnabled = true;
            cbCategoria.Location = new Point(12, 85);
            cbCategoria.Name = "cbCategoria";
            cbCategoria.Size = new Size(135, 25);
            cbCategoria.TabIndex = 1;
            // 
            // label2 (Label Barcode)
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label2.Location = new Point(155, 65);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 7;
            label2.Text = "BarCode";
            // 
            // tbbarcode
            // 
            tbbarcode.Font = new Font("Segoe UI", 10F);
            tbbarcode.Location = new Point(155, 85);
            tbbarcode.Name = "tbbarcode";
            tbbarcode.PlaceholderText = "00000000";
            tbbarcode.Size = new Size(120, 25);
            tbbarcode.TabIndex = 2;
            // 
            // label4 (Label Detalle)
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label4.Location = new Point(283, 65);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 9;
            label4.Text = "Detalle";
            // 
            // tbdetalle
            // 
            tbdetalle.Font = new Font("Segoe UI", 10F);
            tbdetalle.Location = new Point(283, 85);
            tbdetalle.Name = "tbdetalle";
            tbdetalle.PlaceholderText = "Descripción...";
            tbdetalle.Size = new Size(140, 25);
            tbdetalle.TabIndex = 4;
            // 
            // label5 (Label Stock)
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label5.Location = new Point(431, 65);
            label5.Name = "label5";
            label5.Size = new Size(37, 15);
            label5.TabIndex = 10;
            label5.Text = "Stock";
            // 
            // tbstock
            // 
            tbstock.Font = new Font("Segoe UI", 10F);
            tbstock.Location = new Point(431, 85);
            tbstock.Name = "tbstock";
            tbstock.PlaceholderText = "0";
            tbstock.Size = new Size(80, 25);
            tbstock.TabIndex = 5;
            // 
            // label6 (Label Precio)
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label6.Location = new Point(520, 65);
            label6.Name = "label6";
            label6.Size = new Size(41, 15);
            label6.TabIndex = 11;
            label6.Text = "Precio";
            // 
            // tbprecio
            // 
            tbprecio.Font = new Font("Segoe UI", 10F);
            tbprecio.Location = new Point(520, 85);
            tbprecio.Name = "tbprecio";
            tbprecio.PlaceholderText = "$ 0.00";
            tbprecio.Size = new Size(110, 25);
            tbprecio.TabIndex = 6;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(rbOtroNo);
            groupBox1.Controls.Add(rbOtroSi);
            groupBox1.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 134);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(135, 52);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "¿Cargar otro?";
            // 
            // rbOtroNo
            // 
            rbOtroNo.AutoSize = true;
            rbOtroNo.Location = new Point(65, 22);
            rbOtroNo.Name = "rbOtroNo";
            rbOtroNo.Size = new Size(40, 17);
            rbOtroNo.TabIndex = 1;
            rbOtroNo.TabStop = true;
            rbOtroNo.Text = "No";
            rbOtroNo.UseVisualStyleBackColor = true;
            // 
            // rbOtroSi
            // 
            rbOtroSi.AutoSize = true;
            rbOtroSi.Location = new Point(15, 22);
            rbOtroSi.Name = "rbOtroSi";
            rbOtroSi.Size = new Size(34, 17);
            rbOtroSi.TabIndex = 0;
            rbOtroSi.TabStop = true;
            rbOtroSi.Text = "Si";
            rbOtroSi.UseVisualStyleBackColor = true;
            // 
            // btnCargar
            // 
            btnCargar.BackColor = Color.FromArgb(0, 122, 204);
            btnCargar.FlatAppearance.BorderSize = 0;
            btnCargar.FlatStyle = FlatStyle.Flat;
            btnCargar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnCargar.ForeColor = Color.White;
            btnCargar.Location = new Point(415, 145);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(105, 38);
            btnCargar.TabIndex = 12;
            btnCargar.Text = "Cargar";
            btnCargar.UseVisualStyleBackColor = false;
            btnCargar.Click += button1_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(230, 230, 230);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 9.75F);
            btnCancelar.Location = new Point(526, 145);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 38);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += button2_Click;
            // 
            // CargarProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = SurFeFront.Properties.Resources.fondo_nvo_Produc;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(645, 205);
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
            Font = new Font("Segoe UI", 9.75F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "CargarProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SurFe - Nuevo Producto";
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