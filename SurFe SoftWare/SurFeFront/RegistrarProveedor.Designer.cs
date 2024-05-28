namespace SurFe
{
    partial class RegistrarProveedor
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
            tbcuit = new TextBox();
            tbdireccion = new TextBox();
            tbtel = new TextBox();
            tbcorreo = new TextBox();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnCargar = new Button();
            btnCancelar = new Button();
            label3 = new Label();
            tbrazonsocial = new TextBox();
            cblocalidad = new ComboBox();
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
            // tbcuit
            // 
            tbcuit.ForeColor = SystemColors.WindowText;
            tbcuit.Location = new Point(139, 95);
            tbcuit.Name = "tbcuit";
            tbcuit.PlaceholderText = "cuit";
            tbcuit.RightToLeft = RightToLeft.No;
            tbcuit.Size = new Size(121, 23);
            tbcuit.TabIndex = 2;
            // 
            // tbdireccion
            // 
            tbdireccion.Location = new Point(266, 95);
            tbdireccion.Name = "tbdireccion";
            tbdireccion.PlaceholderText = "direccion";
            tbdireccion.Size = new Size(121, 23);
            tbdireccion.TabIndex = 4;
            // 
            // tbtel
            // 
            tbtel.Location = new Point(393, 95);
            tbtel.Name = "tbtel";
            tbtel.PlaceholderText = "tel";
            tbtel.Size = new Size(121, 23);
            tbtel.TabIndex = 5;
            // 
            // tbcorreo
            // 
            tbcorreo.Location = new Point(520, 95);
            tbcorreo.Name = "tbcorreo";
            tbcorreo.PlaceholderText = "Correo";
            tbcorreo.Size = new Size(121, 23);
            tbcorreo.TabIndex = 6;
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 134);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 15;
            label3.Text = "localidad";
            label3.Click += label3_Click;
            // 
            // tbrazonsocial
            // 
            tbrazonsocial.Location = new Point(22, 95);
            tbrazonsocial.Name = "tbrazonsocial";
            tbrazonsocial.PlaceholderText = "Razonsocial";
            tbrazonsocial.Size = new Size(100, 23);
            tbrazonsocial.TabIndex = 16;
            // 
            // cblocalidad
            // 
            cblocalidad.FormattingEnabled = true;
            cblocalidad.Location = new Point(17, 153);
            cblocalidad.Name = "cblocalidad";
            cblocalidad.Size = new Size(121, 23);
            cblocalidad.TabIndex = 17;
            // 
            // RegistrarProveedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            ClientSize = new Size(655, 213);
            Controls.Add(cblocalidad);
            Controls.Add(tbrazonsocial);
            Controls.Add(label3);
            Controls.Add(btnCancelar);
            Controls.Add(btnCargar);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(tbcorreo);
            Controls.Add(tbtel);
            Controls.Add(tbdireccion);
            Controls.Add(tbcuit);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "RegistrarProveedor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nuevo Producto";
            Load += CargarProducto_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbcuit;
        private TextBox tbdireccion;
        private TextBox tbtel;
        private TextBox tbcorreo;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button btnCargar;
        private Button btnCancelar;
        private Label label3;
        private TextBox tbrazonsocial;
        private ComboBox cblocalidad;
    }
}