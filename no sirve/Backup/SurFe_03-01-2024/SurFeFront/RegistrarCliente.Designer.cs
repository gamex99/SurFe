namespace SurFeFront
{
    partial class RegistrarCliente
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
            lblPersona = new Label();
            lblNomAp = new Label();
            txtrazonsocial = new TextBox();
            lblTipo = new Label();
            label1 = new Label();
            txtdni = new TextBox();
            label2 = new Label();
            lblDom = new Label();
            txtDom = new TextBox();
            lblTel = new Label();
            txtTel = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblProv = new Label();
            cbxprov = new ComboBox();
            lblLoc = new Label();
            cbxLoc = new ComboBox();
            lblBarrio = new Label();
            txtBarrio = new TextBox();
            lblCp = new Label();
            txtCp = new TextBox();
            label4 = new Label();
            lblCuit = new Label();
            txtcuit = new TextBox();
            label5 = new Label();
            cbxiva = new ComboBox();
            lblTfac = new Label();
            cbxtfac = new ComboBox();
            btGuardar = new Button();
            btCancelar = new Button();
            cbxDoc = new ComboBox();
            txtid = new TextBox();
            SuspendLayout();
            // 
            // lblPersona
            // 
            lblPersona.AutoSize = true;
            lblPersona.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblPersona.Location = new Point(12, 9);
            lblPersona.Name = "lblPersona";
            lblPersona.Size = new Size(115, 21);
            lblPersona.TabIndex = 0;
            lblPersona.Text = "Persona fisica";
            // 
            // lblNomAp
            // 
            lblNomAp.AutoSize = true;
            lblNomAp.Location = new Point(12, 51);
            lblNomAp.Name = "lblNomAp";
            lblNomAp.Size = new Size(107, 15);
            lblNomAp.TabIndex = 1;
            lblNomAp.Text = "Apellido y Nombre";
            // 
            // txtrazonsocial
            // 
            txtrazonsocial.Location = new Point(149, 48);
            txtrazonsocial.Name = "txtrazonsocial";
            txtrazonsocial.Size = new Size(200, 23);
            txtrazonsocial.TabIndex = 2;
            txtrazonsocial.Text = "Ingrese nombre completo";
            txtrazonsocial.TextChanged += txtNomAp_TextChanged;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(12, 93);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(111, 15);
            lblTipo.TabIndex = 3;
            lblTipo.Text = "Tipo de documento";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 136);
            label1.Name = "label1";
            label1.Size = new Size(132, 15);
            label1.TabIndex = 5;
            label1.Text = "Numero de documento";
            // 
            // txtdni
            // 
            txtdni.Location = new Point(150, 133);
            txtdni.Name = "txtdni";
            txtdni.Size = new Size(200, 23);
            txtdni.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 181);
            label2.Name = "label2";
            label2.Size = new Size(148, 21);
            label2.TabIndex = 7;
            label2.Text = "Datos de contacto";
            // 
            // lblDom
            // 
            lblDom.AutoSize = true;
            lblDom.Location = new Point(12, 215);
            lblDom.Name = "lblDom";
            lblDom.Size = new Size(58, 15);
            lblDom.TabIndex = 8;
            lblDom.Text = "Domicilio";
            // 
            // txtDom
            // 
            txtDom.ForeColor = Color.Black;
            txtDom.Location = new Point(101, 212);
            txtDom.Name = "txtDom";
            txtDom.Size = new Size(200, 23);
            txtDom.TabIndex = 9;
            txtDom.Text = "Ingrese domicilio";
            // 
            // lblTel
            // 
            lblTel.AutoSize = true;
            lblTel.Location = new Point(12, 254);
            lblTel.Name = "lblTel";
            lblTel.Size = new Size(52, 15);
            lblTel.TabIndex = 10;
            lblTel.Text = "Telefono";
            // 
            // txtTel
            // 
            txtTel.ForeColor = Color.Black;
            txtTel.Location = new Point(101, 251);
            txtTel.Name = "txtTel";
            txtTel.Size = new Size(200, 23);
            txtTel.TabIndex = 11;
            txtTel.Text = "Ingrese telefono";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(12, 291);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(41, 15);
            lblEmail.TabIndex = 12;
            lblEmail.Text = "E-mail";
            // 
            // txtEmail
            // 
            txtEmail.ForeColor = Color.Black;
            txtEmail.Location = new Point(101, 288);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 13;
            txtEmail.Text = "Ingrese correo electronico";
            // 
            // lblProv
            // 
            lblProv.AutoSize = true;
            lblProv.Location = new Point(12, 328);
            lblProv.Name = "lblProv";
            lblProv.Size = new Size(56, 15);
            lblProv.TabIndex = 14;
            lblProv.Text = "Provincia";
            // 
            // cbxprov
            // 
            cbxprov.FormattingEnabled = true;
            cbxprov.Items.AddRange(new object[] { "", "Santa Fe" });
            cbxprov.Location = new Point(101, 325);
            cbxprov.Name = "cbxprov";
            cbxprov.Size = new Size(121, 23);
            cbxprov.TabIndex = 15;
            // 
            // lblLoc
            // 
            lblLoc.AutoSize = true;
            lblLoc.Location = new Point(14, 360);
            lblLoc.Name = "lblLoc";
            lblLoc.Size = new Size(58, 15);
            lblLoc.TabIndex = 16;
            lblLoc.Text = "Localidad";
            // 
            // cbxLoc
            // 
            cbxLoc.FormattingEnabled = true;
            cbxLoc.Items.AddRange(new object[] { "", "Peyrano", "Santa Teresa", "Rosario" });
            cbxLoc.Location = new Point(101, 357);
            cbxLoc.Name = "cbxLoc";
            cbxLoc.Size = new Size(121, 23);
            cbxLoc.TabIndex = 17;
            // 
            // lblBarrio
            // 
            lblBarrio.AutoSize = true;
            lblBarrio.Location = new Point(12, 393);
            lblBarrio.Name = "lblBarrio";
            lblBarrio.Size = new Size(38, 15);
            lblBarrio.TabIndex = 18;
            lblBarrio.Text = "Barrio";
            // 
            // txtBarrio
            // 
            txtBarrio.ForeColor = Color.Black;
            txtBarrio.Location = new Point(101, 390);
            txtBarrio.Name = "txtBarrio";
            txtBarrio.Size = new Size(200, 23);
            txtBarrio.TabIndex = 19;
            txtBarrio.Text = "Ingrese barrio";
            // 
            // lblCp
            // 
            lblCp.AutoSize = true;
            lblCp.Location = new Point(15, 426);
            lblCp.Name = "lblCp";
            lblCp.Size = new Size(22, 15);
            lblCp.TabIndex = 20;
            lblCp.Text = "CP";
            // 
            // txtCp
            // 
            txtCp.ForeColor = Color.Black;
            txtCp.Location = new Point(101, 423);
            txtCp.Name = "txtCp";
            txtCp.Size = new Size(200, 23);
            txtCp.TabIndex = 21;
            txtCp.Text = "Ingrese codigo postal";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(462, 9);
            label4.Name = "label4";
            label4.Size = new Size(183, 21);
            label4.TabIndex = 25;
            label4.Text = "Datos para facturacion";
            // 
            // lblCuit
            // 
            lblCuit.AutoSize = true;
            lblCuit.Location = new Point(462, 51);
            lblCuit.Name = "lblCuit";
            lblCuit.Size = new Size(32, 15);
            lblCuit.TabIndex = 26;
            lblCuit.Text = "CUIT";
            // 
            // txtcuit
            // 
            txtcuit.Location = new Point(516, 48);
            txtcuit.Name = "txtcuit";
            txtcuit.Size = new Size(200, 23);
            txtcuit.TabIndex = 27;
            txtcuit.Text = "Ingrese cuit";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(462, 98);
            label5.Name = "label5";
            label5.Size = new Size(76, 15);
            label5.TabIndex = 28;
            label5.Text = "Situacion IVA";
            // 
            // cbxiva
            // 
            cbxiva.FormattingEnabled = true;
            cbxiva.Items.AddRange(new object[] { "", "Responsable Inscripto", "Consumidor Final", "Excento" });
            cbxiva.Location = new Point(563, 90);
            cbxiva.Name = "cbxiva";
            cbxiva.Size = new Size(121, 23);
            cbxiva.TabIndex = 29;
            // 
            // lblTfac
            // 
            lblTfac.AutoSize = true;
            lblTfac.Location = new Point(462, 136);
            lblTfac.Name = "lblTfac";
            lblTfac.Size = new Size(86, 15);
            lblTfac.TabIndex = 30;
            lblTfac.Text = "Tipo de factura";
            // 
            // cbxtfac
            // 
            cbxtfac.FormattingEnabled = true;
            cbxtfac.Items.AddRange(new object[] { "", "A", "B", "C" });
            cbxtfac.Location = new Point(563, 133);
            cbxtfac.Name = "cbxtfac";
            cbxtfac.Size = new Size(121, 23);
            cbxtfac.TabIndex = 31;
            // 
            // btGuardar
            // 
            btGuardar.Location = new Point(563, 540);
            btGuardar.Name = "btGuardar";
            btGuardar.Size = new Size(75, 30);
            btGuardar.TabIndex = 33;
            btGuardar.Text = "Guardar";
            btGuardar.UseVisualStyleBackColor = true;
            btGuardar.Click += btGuardar_Click;
            // 
            // btCancelar
            // 
            btCancelar.Location = new Point(666, 540);
            btCancelar.Name = "btCancelar";
            btCancelar.Size = new Size(75, 30);
            btCancelar.TabIndex = 34;
            btCancelar.Text = "Cancelar";
            btCancelar.UseVisualStyleBackColor = true;
            btCancelar.Click += btCancelar_Click;
            // 
            // cbxDoc
            // 
            cbxDoc.FormattingEnabled = true;
            cbxDoc.Items.AddRange(new object[] { "", "DNI", "LC" });
            cbxDoc.Location = new Point(149, 90);
            cbxDoc.Name = "cbxDoc";
            cbxDoc.Size = new Size(121, 23);
            cbxDoc.TabIndex = 4;
            cbxDoc.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // txtid
            // 
            txtid.Enabled = false;
            txtid.ForeColor = Color.Black;
            txtid.Location = new Point(101, 540);
            txtid.Name = "txtid";
            txtid.Size = new Size(200, 23);
            txtid.TabIndex = 35;
            txtid.Text = "2";
            // 
            // RegistrarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(753, 575);
            Controls.Add(txtid);
            Controls.Add(btCancelar);
            Controls.Add(btGuardar);
            Controls.Add(cbxtfac);
            Controls.Add(lblTfac);
            Controls.Add(cbxiva);
            Controls.Add(label5);
            Controls.Add(txtcuit);
            Controls.Add(lblCuit);
            Controls.Add(label4);
            Controls.Add(txtCp);
            Controls.Add(lblCp);
            Controls.Add(txtBarrio);
            Controls.Add(lblBarrio);
            Controls.Add(cbxLoc);
            Controls.Add(lblLoc);
            Controls.Add(cbxprov);
            Controls.Add(lblProv);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtTel);
            Controls.Add(lblTel);
            Controls.Add(txtDom);
            Controls.Add(lblDom);
            Controls.Add(label2);
            Controls.Add(txtdni);
            Controls.Add(label1);
            Controls.Add(cbxDoc);
            Controls.Add(lblTipo);
            Controls.Add(txtrazonsocial);
            Controls.Add(lblNomAp);
            Controls.Add(lblPersona);
            Name = "RegistrarCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Client";
            Load += RegistrarCliente_Load;
            KeyPress += RegistrarCliente_KeyPress;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPersona;
        private Label lblNomAp;
        private TextBox txtrazonsocial;
        private Label lblTipo;
        private Label label1;
        private TextBox txtdni;
        private Label label2;
        private Label lblDom;
        private TextBox txtDom;
        private Label lblTel;
        private TextBox txtTel;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblProv;
        private ComboBox cbxprov;
        private Label lblLoc;
        private ComboBox cbxLoc;
        private Label lblBarrio;
        private TextBox txtBarrio;
        private Label lblCp;
        private TextBox txtCp;
        private Label label4;
        private Label lblCuit;
        private TextBox txtcuit;
        private Label label5;
        private ComboBox cbxiva;
        private Label lblTfac;
        private ComboBox cbxtfac;
        private Button btGuardar;
        private Button btCancelar;
        private ComboBox cbxDoc;
        private TextBox txtid;
    }
}