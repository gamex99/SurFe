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
            tbcuit = new TextBox();
            tbdireccion = new TextBox();
            tbtel = new TextBox();
            tbcorreo = new TextBox();
            btnCargar = new Button();
            btnCancelar = new Button();
            tbrazonsocial = new TextBox();
            cblocalidad = new ComboBox();
            SuspendLayout();
            // 
            // tbcuit
            // 
            tbcuit.ForeColor = SystemColors.WindowText;
            tbcuit.Location = new Point(129, 42);
            tbcuit.Name = "tbcuit";
            tbcuit.PlaceholderText = "CUIT";
            tbcuit.RightToLeft = RightToLeft.No;
            tbcuit.Size = new Size(121, 23);
            tbcuit.TabIndex = 2;
            // 
            // tbdireccion
            // 
            tbdireccion.Location = new Point(256, 42);
            tbdireccion.Name = "tbdireccion";
            tbdireccion.PlaceholderText = "Direccion";
            tbdireccion.Size = new Size(121, 23);
            tbdireccion.TabIndex = 4;
            // 
            // tbtel
            // 
            tbtel.Location = new Point(383, 42);
            tbtel.Name = "tbtel";
            tbtel.PlaceholderText = "Telefono";
            tbtel.Size = new Size(121, 23);
            tbtel.TabIndex = 5;
            // 
            // tbcorreo
            // 
            tbcorreo.Location = new Point(510, 42);
            tbcorreo.Name = "tbcorreo";
            tbcorreo.PlaceholderText = "Correo";
            tbcorreo.Size = new Size(121, 23);
            tbcorreo.TabIndex = 6;
            // 
            // btnCargar
            // 
            btnCargar.BackColor = SystemColors.Menu;
            btnCargar.Location = new Point(609, 91);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(75, 23);
            btnCargar.TabIndex = 12;
            btnCargar.Text = "Cargar";
            btnCargar.UseVisualStyleBackColor = false;
            btnCargar.Click += button1_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(708, 91);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += button2_Click;
            // 
            // tbrazonsocial
            // 
            tbrazonsocial.Location = new Point(23, 42);
            tbrazonsocial.Name = "tbrazonsocial";
            tbrazonsocial.PlaceholderText = "Razon Social";
            tbrazonsocial.Size = new Size(100, 23);
            tbrazonsocial.TabIndex = 16;
            // 
            // cblocalidad
            // 
            cblocalidad.FormattingEnabled = true;
            cblocalidad.Location = new Point(637, 42);
            cblocalidad.Name = "cblocalidad";
            cblocalidad.Size = new Size(121, 23);
            cblocalidad.TabIndex = 17;
            cblocalidad.Text = "Localidad";
            // 
            // RegistrarProveedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            ClientSize = new Size(795, 132);
            Controls.Add(cblocalidad);
            Controls.Add(tbrazonsocial);
            Controls.Add(btnCancelar);
            Controls.Add(btnCargar);
            Controls.Add(tbcorreo);
            Controls.Add(tbtel);
            Controls.Add(tbdireccion);
            Controls.Add(tbcuit);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "RegistrarProveedor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Proveedor";
            Load += CargarProducto_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox tbcuit;
        private TextBox tbdireccion;
        private TextBox tbtel;
        private TextBox tbcorreo;
        private Button btnCargar;
        private Button btnCancelar;
        private TextBox tbrazonsocial;
        private ComboBox cblocalidad;
    }
}