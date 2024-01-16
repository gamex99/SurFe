namespace SurFeFront
{
    partial class Cliente
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
            components = new System.ComponentModel.Container();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            dtgEmpleados = new DataGridView();
            clienteBindingSource = new BindingSource(components);
            btNuevo = new Button();
            btModificar = new Button();
            btEliminar = new Button();
            btSalir = new Button();
            comboBox1 = new ComboBox();
            btnConsultar = new Button();
            razon_social = new DataGridViewTextBoxColumn();
            condicion_iva = new DataGridViewTextBoxColumn();
            cuit = new DataGridViewTextBoxColumn();
            tipo_factura = new DataGridViewTextBoxColumn();
            domicilio = new DataGridViewTextBoxColumn();
            barrio = new DataGridViewTextBoxColumn();
            localidad = new DataGridViewTextBoxColumn();
            cp = new DataGridViewTextBoxColumn();
            provincia = new DataGridViewTextBoxColumn();
            telefono = new DataGridViewTextBoxColumn();
            documento = new DataGridViewTextBoxColumn();
            dni = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dtgEmpleados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clienteBindingSource).BeginInit();
            SuspendLayout();
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(12, 44);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(42, 15);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(74, 41);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(250, 23);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // dtgEmpleados
            // 
            dtgEmpleados.AllowUserToAddRows = false;
            dtgEmpleados.AllowUserToDeleteRows = false;
            dtgEmpleados.AllowUserToOrderColumns = true;
            dtgEmpleados.AutoGenerateColumns = false;
            dtgEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgEmpleados.Columns.AddRange(new DataGridViewColumn[] { razon_social, condicion_iva, cuit, tipo_factura, domicilio, barrio, localidad, cp, provincia, telefono, documento, dni, email });
            dtgEmpleados.DataSource = clienteBindingSource;
            dtgEmpleados.ImeMode = ImeMode.Disable;
            dtgEmpleados.Location = new Point(12, 78);
            dtgEmpleados.Name = "dtgEmpleados";
            dtgEmpleados.ReadOnly = true;
            dtgEmpleados.RowTemplate.Height = 25;
            dtgEmpleados.Size = new Size(776, 316);
            dtgEmpleados.TabIndex = 2;
            dtgEmpleados.CellContentClick += dtgEmpleados_CellContentClick;
            // 
            // clienteBindingSource
            // 
            clienteBindingSource.DataSource = typeof(SurFeEntidades.ClienteModel);
            // 
            // btNuevo
            // 
            btNuevo.Location = new Point(12, 400);
            btNuevo.Name = "btNuevo";
            btNuevo.Size = new Size(75, 25);
            btNuevo.TabIndex = 3;
            btNuevo.Text = "Nuevo";
            btNuevo.UseVisualStyleBackColor = true;
            btNuevo.Click += btNuevo_Click;
            // 
            // btModificar
            // 
            btModificar.Location = new Point(174, 400);
            btModificar.Name = "btModificar";
            btModificar.Size = new Size(75, 25);
            btModificar.TabIndex = 4;
            btModificar.Text = "Modificar";
            btModificar.UseVisualStyleBackColor = true;
            btModificar.Click += btModificar_Click;
            // 
            // btEliminar
            // 
            btEliminar.Location = new Point(255, 400);
            btEliminar.Name = "btEliminar";
            btEliminar.Size = new Size(75, 25);
            btEliminar.TabIndex = 5;
            btEliminar.Text = "Eliminar";
            btEliminar.UseVisualStyleBackColor = true;
            btEliminar.Click += btEliminar_Click;
            // 
            // btSalir
            // 
            btSalir.Location = new Point(713, 400);
            btSalir.Name = "btSalir";
            btSalir.Size = new Size(75, 25);
            btSalir.TabIndex = 6;
            btSalir.Text = "Salir";
            btSalir.UseVisualStyleBackColor = true;
            btSalir.Click += btSalir_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(358, 41);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(165, 23);
            comboBox1.TabIndex = 7;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(93, 400);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(75, 25);
            btnConsultar.TabIndex = 10;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // razon_social
            // 
            razon_social.DataPropertyName = "razon_social";
            razon_social.HeaderText = "Razon Social";
            razon_social.Name = "razon_social";
            razon_social.ReadOnly = true;
            // 
            // condicion_iva
            // 
            condicion_iva.DataPropertyName = "condicion_iva";
            condicion_iva.HeaderText = "Condicion IVA";
            condicion_iva.Name = "condicion_iva";
            condicion_iva.ReadOnly = true;
            // 
            // cuit
            // 
            cuit.DataPropertyName = "cuit";
            cuit.HeaderText = "CUIT";
            cuit.Name = "cuit";
            cuit.ReadOnly = true;
            // 
            // tipo_factura
            // 
            tipo_factura.DataPropertyName = "tipo_factura";
            tipo_factura.HeaderText = "Factura Tipo";
            tipo_factura.Name = "tipo_factura";
            tipo_factura.ReadOnly = true;
            // 
            // domicilio
            // 
            domicilio.DataPropertyName = "domicilio";
            domicilio.HeaderText = "Domicilio";
            domicilio.Name = "domicilio";
            domicilio.ReadOnly = true;
            // 
            // barrio
            // 
            barrio.DataPropertyName = "barrio";
            barrio.HeaderText = "Barrio";
            barrio.Name = "barrio";
            barrio.ReadOnly = true;
            // 
            // localidad
            // 
            localidad.DataPropertyName = "localidad";
            localidad.HeaderText = "Localidad";
            localidad.Name = "localidad";
            localidad.ReadOnly = true;
            // 
            // cp
            // 
            cp.DataPropertyName = "cp";
            cp.HeaderText = "Codigo Postal";
            cp.Name = "cp";
            cp.ReadOnly = true;
            // 
            // provincia
            // 
            provincia.DataPropertyName = "provincia";
            provincia.HeaderText = "Provincia";
            provincia.Name = "provincia";
            provincia.ReadOnly = true;
            // 
            // telefono
            // 
            telefono.DataPropertyName = "telefono";
            telefono.HeaderText = "Telefono";
            telefono.Name = "telefono";
            telefono.ReadOnly = true;
            // 
            // documento
            // 
            documento.DataPropertyName = "documento";
            documento.HeaderText = "Tipo Documento";
            documento.Name = "documento";
            documento.ReadOnly = true;
            // 
            // dni
            // 
            dni.DataPropertyName = "dni";
            dni.HeaderText = "Numero";
            dni.Name = "dni";
            dni.ReadOnly = true;
            // 
            // email
            // 
            email.DataPropertyName = "email";
            email.HeaderText = "E-Mail";
            email.Name = "email";
            email.ReadOnly = true;
            // 
            // Cliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 432);
            Controls.Add(btnConsultar);
            Controls.Add(comboBox1);
            Controls.Add(btSalir);
            Controls.Add(btEliminar);
            Controls.Add(btModificar);
            Controls.Add(btNuevo);
            Controls.Add(dtgEmpleados);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Name = "Cliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cliente";
            Load += Cliente_Load;
            ((System.ComponentModel.ISupportInitialize)dtgEmpleados).EndInit();
            ((System.ComponentModel.ISupportInitialize)clienteBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBuscar;
        private TextBox txtBuscar;
        private DataGridView dtgEmpleados;
        private Button btNuevo;
        private Button btModificar;
        private Button btEliminar;
        private Button btSalir;
        private ComboBox comboBox1;
        private BindingSource clienteBindingSource;
        private Button btnConsultar;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn id_condicion_iva;
        private DataGridViewTextBoxColumn id_tipo_factura;
        private DataGridViewTextBoxColumn id_pronvincia;
        private DataGridViewTextBoxColumn id_localidad;
        private DataGridViewCheckBoxColumn anulado;
        private DataGridViewTextBoxColumn id_tipo_documento;
        private DataGridViewTextBoxColumn id_provincia;
        private DataGridViewTextBoxColumn razon_social;
        private DataGridViewTextBoxColumn condicion_iva;
        private DataGridViewTextBoxColumn cuit;
        private DataGridViewTextBoxColumn tipo_factura;
        private DataGridViewTextBoxColumn domicilio;
        private DataGridViewTextBoxColumn barrio;
        private DataGridViewTextBoxColumn localidad;
        private DataGridViewTextBoxColumn cp;
        private DataGridViewTextBoxColumn provincia;
        private DataGridViewTextBoxColumn telefono;
        private DataGridViewTextBoxColumn documento;
        private DataGridViewTextBoxColumn dni;
        private DataGridViewTextBoxColumn email;
    }
}