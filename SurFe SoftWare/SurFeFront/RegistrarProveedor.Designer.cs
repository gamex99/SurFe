namespace SurFe
{
    partial class RegistrarProveedor
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
            tbcuit = new TextBox();
            tbdireccion = new TextBox();
            tbtel = new TextBox();
            tbcorreo = new TextBox();
            btnCargar = new Button();
            btnCancelar = new Button();
            tbrazonsocial = new TextBox();
            cblocalidad = new ComboBox();
            cbProvincia = new ComboBox();
            lblRazon = new Label();
            lblCuit = new Label();
            lblDireccion = new Label();
            lblTel = new Label();
            lblCorreo = new Label();
            lblLocalidad = new Label();
            lblProvincia = new Label();
            SuspendLayout();
            // 
            // lblRazon
            // 
            lblRazon.AutoSize = true;
            lblRazon.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblRazon.Location = new Point(25, 20);
            lblRazon.Name = "lblRazon";
            lblRazon.Size = new Size(84, 15);
            lblRazon.TabIndex = 0;
            lblRazon.Text = "Razón Social *";
            // 
            // tbrazonsocial
            // 
            tbrazonsocial.BorderStyle = BorderStyle.FixedSingle;
            tbrazonsocial.Location = new Point(25, 40);
            tbrazonsocial.Name = "tbrazonsocial";
            tbrazonsocial.Size = new Size(250, 23);
            tbrazonsocial.TabIndex = 1;
            // 
            // lblCuit
            // 
            lblCuit.AutoSize = true;
            lblCuit.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblCuit.Location = new Point(25, 75);
            lblCuit.Name = "lblCuit";
            lblCuit.Size = new Size(103, 15);
            lblCuit.TabIndex = 0;
            lblCuit.Text = "CUIT (11 dígitos) *";
            // 
            // tbcuit
            // 
            tbcuit.BorderStyle = BorderStyle.FixedSingle;
            tbcuit.Location = new Point(25, 95);
            tbcuit.MaxLength = 11;
            tbcuit.Name = "tbcuit";
            tbcuit.Size = new Size(250, 23);
            tbcuit.TabIndex = 2;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblDireccion.Location = new Point(25, 130);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(68, 15);
            lblDireccion.TabIndex = 0;
            lblDireccion.Text = "Dirección *";
            // 
            // tbdireccion
            // 
            tbdireccion.BorderStyle = BorderStyle.FixedSingle;
            tbdireccion.Location = new Point(25, 150);
            tbdireccion.Name = "tbdireccion";
            tbdireccion.Size = new Size(250, 23);
            tbdireccion.TabIndex = 3;
            // 
            // lblTel
            // 
            lblTel.AutoSize = true;
            lblTel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblTel.Location = new Point(25, 185);
            lblTel.Name = "lblTel";
            lblTel.Size = new Size(63, 15);
            lblTel.TabIndex = 0;
            lblTel.Text = "Teléfono *";
            // 
            // tbtel
            // 
            tbtel.BorderStyle = BorderStyle.FixedSingle;
            tbtel.Location = new Point(25, 205);
            tbtel.Name = "tbtel";
            tbtel.Size = new Size(250, 23);
            tbtel.TabIndex = 4;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblCorreo.Location = new Point(25, 240);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(116, 15);
            lblCorreo.TabIndex = 0;
            lblCorreo.Text = "Correo Electrónico *";
            // 
            // tbcorreo
            // 
            tbcorreo.BorderStyle = BorderStyle.FixedSingle;
            tbcorreo.Location = new Point(25, 260);
            tbcorreo.Name = "tbcorreo";
            tbcorreo.Size = new Size(250, 23);
            tbcorreo.TabIndex = 5;
            // 
            // lblProvincia
            // 
            lblProvincia.AutoSize = true;
            lblProvincia.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblProvincia.Location = new Point(25, 295);
            lblProvincia.Name = "lblProvincia";
            lblProvincia.Size = new Size(67, 15);
            lblProvincia.TabIndex = 0;
            lblProvincia.Text = "Provincia *";
            // 
            // cbProvincia
            // 
            cbProvincia.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProvincia.Location = new Point(25, 315);
            cbProvincia.Name = "cbProvincia";
            cbProvincia.Size = new Size(250, 23);
            cbProvincia.TabIndex = 6;
            cbProvincia.SelectionChangeCommitted +=     cbProvincia_SelectionChangeCommitted;
            // 
            // lblLocalidad
            // 
            lblLocalidad.AutoSize = true;
            lblLocalidad.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblLocalidad.Location = new Point(25, 350);
            lblLocalidad.Name = "lblLocalidad";
            lblLocalidad.Size = new Size(68, 15);
            lblLocalidad.TabIndex = 0;
            lblLocalidad.Text = "Localidad *";
            // 
            // cblocalidad
            // 
            cblocalidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cblocalidad.Location = new Point(25, 370);
            cblocalidad.Name = "cblocalidad";
            cblocalidad.Size = new Size(250, 23);
            cblocalidad.TabIndex = 7;
            // 
            // btnCargar
            // 
            btnCargar.BackColor = Color.FromArgb(0, 122, 204);
            btnCargar.FlatStyle = FlatStyle.Flat;
            btnCargar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnCargar.ForeColor = Color.White;
            btnCargar.Location = new Point(25, 420);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(110, 40);
            btnCargar.TabIndex = 8;
            btnCargar.Text = "GUARDAR";
            btnCargar.UseVisualStyleBackColor = false;
            btnCargar.Click += btnCargar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(240, 240, 240);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(165, 420);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(110, 40);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // RegistrarProveedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(310, 490);
            Controls.Add(lblLocalidad);
            Controls.Add(cblocalidad);
            Controls.Add(lblProvincia);
            Controls.Add(cbProvincia);
            Controls.Add(lblRazon);
            Controls.Add(tbrazonsocial);
            Controls.Add(btnCancelar);
            Controls.Add(btnCargar);
            Controls.Add(lblCorreo);
            Controls.Add(tbcorreo);
            Controls.Add(lblTel);
            Controls.Add(tbtel);
            Controls.Add(lblDireccion);
            Controls.Add(tbdireccion);
            Controls.Add(lblCuit);
            Controls.Add(tbcuit);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RegistrarProveedor";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SurFe - Registro de Proveedor";
            Load += RegistrarProveedor_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbrazonsocial;
        private TextBox tbcuit;
        private TextBox tbdireccion;
        private TextBox tbtel;
        private TextBox tbcorreo;
        private ComboBox cblocalidad;
        private ComboBox cbProvincia;
        private Button btnCargar;
        private Button btnCancelar;
        private Label lblRazon;
        private Label lblCuit;
        private Label lblDireccion;
        private Label lblTel;
        private Label lblCorreo;
        private Label lblLocalidad;
        private Label lblProvincia;
    }
}