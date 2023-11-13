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
            txtNomAp = new TextBox();
            lblTipo = new Label();
            cbxDoc = new ComboBox();
            label1 = new Label();
            txtNumDoc = new TextBox();
            label2 = new Label();
            lblDom = new Label();
            txtDom = new TextBox();
            lblTel = new Label();
            txtTel = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblProv = new Label();
            cbcProv = new ComboBox();
            lblLoc = new Label();
            cbxLoc = new ComboBox();
            lblBarrio = new Label();
            txtBarrio = new TextBox();
            lblCp = new Label();
            txtCp = new TextBox();
            label3 = new Label();
            lblFechaN = new Label();
            dtpFn = new DateTimePicker();
            label4 = new Label();
            lblCuit = new Label();
            txtCuit = new TextBox();
            label5 = new Label();
            cbxIva = new ComboBox();
            lblTfac = new Label();
            cbxTfac = new ComboBox();
            btGuardar = new Button();
            btCancelar = new Button();
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
            // txtNomAp
            // 
            txtNomAp.Location = new Point(149, 48);
            txtNomAp.Name = "txtNomAp";
            txtNomAp.Size = new Size(200, 23);
            txtNomAp.TabIndex = 2;
            txtNomAp.Text = "Ingrese nombre completo";
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
            // cbxDoc
            // 
            cbxDoc.FormattingEnabled = true;
            cbxDoc.Location = new Point(149, 90);
            cbxDoc.Name = "cbxDoc";
            cbxDoc.Size = new Size(121, 23);
            cbxDoc.TabIndex = 4;
            cbxDoc.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
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
            // txtNumDoc
            // 
            txtNumDoc.Location = new Point(150, 133);
            txtNumDoc.Name = "txtNumDoc";
            txtNumDoc.Size = new Size(200, 23);
            txtNumDoc.TabIndex = 6;
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
            // cbcProv
            // 
            cbcProv.FormattingEnabled = true;
            cbcProv.Location = new Point(101, 325);
            cbcProv.Name = "cbcProv";
            cbcProv.Size = new Size(121, 23);
            cbcProv.TabIndex = 15;
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(12, 474);
            label3.Name = "label3";
            label3.Size = new Size(97, 21);
            label3.TabIndex = 22;
            label3.Text = "Otros datos";
            // 
            // lblFechaN
            // 
            lblFechaN.AutoSize = true;
            lblFechaN.Location = new Point(15, 513);
            lblFechaN.Name = "lblFechaN";
            lblFechaN.Size = new Size(117, 15);
            lblFechaN.TabIndex = 23;
            lblFechaN.Text = "Fecha de nacimiento";
            // 
            // dtpFn
            // 
            dtpFn.Format = DateTimePickerFormat.Short;
            dtpFn.Location = new Point(150, 507);
            dtpFn.Name = "dtpFn";
            dtpFn.Size = new Size(100, 23);
            dtpFn.TabIndex = 24;
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
            // txtCuit
            // 
            txtCuit.Location = new Point(516, 48);
            txtCuit.Name = "txtCuit";
            txtCuit.Size = new Size(200, 23);
            txtCuit.TabIndex = 27;
            txtCuit.Text = "Ingrese cuit";
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
            // cbxIva
            // 
            cbxIva.FormattingEnabled = true;
            cbxIva.Location = new Point(563, 90);
            cbxIva.Name = "cbxIva";
            cbxIva.Size = new Size(121, 23);
            cbxIva.TabIndex = 29;
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
            // cbxTfac
            // 
            cbxTfac.FormattingEnabled = true;
            cbxTfac.Location = new Point(563, 133);
            cbxTfac.Name = "cbxTfac";
            cbxTfac.Size = new Size(121, 23);
            cbxTfac.TabIndex = 31;
            // 
            // btGuardar
            // 
            btGuardar.Location = new Point(563, 540);
            btGuardar.Name = "btGuardar";
            btGuardar.Size = new Size(75, 30);
            btGuardar.TabIndex = 33;
            btGuardar.Text = "Guardar";
            btGuardar.UseVisualStyleBackColor = true;
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
            // RegistrarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(753, 575);
            Controls.Add(btCancelar);
            Controls.Add(btGuardar);
            Controls.Add(cbxTfac);
            Controls.Add(lblTfac);
            Controls.Add(cbxIva);
            Controls.Add(label5);
            Controls.Add(txtCuit);
            Controls.Add(lblCuit);
            Controls.Add(label4);
            Controls.Add(dtpFn);
            Controls.Add(lblFechaN);
            Controls.Add(label3);
            Controls.Add(txtCp);
            Controls.Add(lblCp);
            Controls.Add(txtBarrio);
            Controls.Add(lblBarrio);
            Controls.Add(cbxLoc);
            Controls.Add(lblLoc);
            Controls.Add(cbcProv);
            Controls.Add(lblProv);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtTel);
            Controls.Add(lblTel);
            Controls.Add(txtDom);
            Controls.Add(lblDom);
            Controls.Add(label2);
            Controls.Add(txtNumDoc);
            Controls.Add(label1);
            Controls.Add(cbxDoc);
            Controls.Add(lblTipo);
            Controls.Add(txtNomAp);
            Controls.Add(lblNomAp);
            Controls.Add(lblPersona);
            Name = "RegistrarCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegistrarCliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPersona;
        private Label lblNomAp;
        private TextBox txtNomAp;
        private Label lblTipo;
        private ComboBox cbxDoc;
        private Label label1;
        private TextBox txtNumDoc;
        private Label label2;
        private Label lblDom;
        private TextBox txtDom;
        private Label lblTel;
        private TextBox txtTel;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblProv;
        private ComboBox cbcProv;
        private Label lblLoc;
        private ComboBox cbxLoc;
        private Label lblBarrio;
        private TextBox txtBarrio;
        private Label lblCp;
        private TextBox txtCp;
        private Label label3;
        private Label lblFechaN;
        private DateTimePicker dtpFn;
        private Label label4;
        private Label lblCuit;
        private TextBox txtCuit;
        private Label label5;
        private ComboBox cbxIva;
        private Label lblTfac;
        private ComboBox cbxTfac;
        private Button btGuardar;
        private Button btCancelar;
    }
}