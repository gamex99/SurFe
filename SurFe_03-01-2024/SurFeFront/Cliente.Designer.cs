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
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            razonsocialDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            condicionivaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tipofacturaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cuitDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            domicilioDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            localidadDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            provinciaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cpDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            telefonoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            anuladoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            clienteBindingSource = new BindingSource(components);
            btNuevo = new Button();
            btModificar = new Button();
            btEliminar = new Button();
            btSalir = new Button();
            comboBox1 = new ComboBox();
            btnConsultar = new Button();
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
            dtgEmpleados.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, razonsocialDataGridViewTextBoxColumn, condicionivaDataGridViewTextBoxColumn, tipofacturaDataGridViewTextBoxColumn, cuitDataGridViewTextBoxColumn, domicilioDataGridViewTextBoxColumn, localidadDataGridViewTextBoxColumn, provinciaDataGridViewTextBoxColumn, cpDataGridViewTextBoxColumn, telefonoDataGridViewTextBoxColumn, anuladoDataGridViewCheckBoxColumn });
            dtgEmpleados.DataSource = clienteBindingSource;
            dtgEmpleados.ImeMode = ImeMode.Disable;
            dtgEmpleados.Location = new Point(12, 78);
            dtgEmpleados.Name = "dtgEmpleados";
            dtgEmpleados.ReadOnly = true;
            dtgEmpleados.RowTemplate.Height = 25;
            dtgEmpleados.Size = new Size(776, 316);
            dtgEmpleados.TabIndex = 2;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "id";
            idDataGridViewTextBoxColumn.HeaderText = "id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // razonsocialDataGridViewTextBoxColumn
            // 
            razonsocialDataGridViewTextBoxColumn.DataPropertyName = "razon_social";
            razonsocialDataGridViewTextBoxColumn.HeaderText = "razon_social";
            razonsocialDataGridViewTextBoxColumn.Name = "razonsocialDataGridViewTextBoxColumn";
            razonsocialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // condicionivaDataGridViewTextBoxColumn
            // 
            condicionivaDataGridViewTextBoxColumn.DataPropertyName = "condicion_iva";
            condicionivaDataGridViewTextBoxColumn.HeaderText = "condicion_iva";
            condicionivaDataGridViewTextBoxColumn.Name = "condicionivaDataGridViewTextBoxColumn";
            condicionivaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipofacturaDataGridViewTextBoxColumn
            // 
            tipofacturaDataGridViewTextBoxColumn.DataPropertyName = "tipo_factura";
            tipofacturaDataGridViewTextBoxColumn.HeaderText = "tipo_factura";
            tipofacturaDataGridViewTextBoxColumn.Name = "tipofacturaDataGridViewTextBoxColumn";
            tipofacturaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cuitDataGridViewTextBoxColumn
            // 
            cuitDataGridViewTextBoxColumn.DataPropertyName = "cuit";
            cuitDataGridViewTextBoxColumn.HeaderText = "cuit";
            cuitDataGridViewTextBoxColumn.Name = "cuitDataGridViewTextBoxColumn";
            cuitDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // domicilioDataGridViewTextBoxColumn
            // 
            domicilioDataGridViewTextBoxColumn.DataPropertyName = "domicilio";
            domicilioDataGridViewTextBoxColumn.HeaderText = "domicilio";
            domicilioDataGridViewTextBoxColumn.Name = "domicilioDataGridViewTextBoxColumn";
            domicilioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // localidadDataGridViewTextBoxColumn
            // 
            localidadDataGridViewTextBoxColumn.DataPropertyName = "localidad";
            localidadDataGridViewTextBoxColumn.HeaderText = "localidad";
            localidadDataGridViewTextBoxColumn.Name = "localidadDataGridViewTextBoxColumn";
            localidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // provinciaDataGridViewTextBoxColumn
            // 
            provinciaDataGridViewTextBoxColumn.DataPropertyName = "provincia";
            provinciaDataGridViewTextBoxColumn.HeaderText = "provincia";
            provinciaDataGridViewTextBoxColumn.Name = "provinciaDataGridViewTextBoxColumn";
            provinciaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cpDataGridViewTextBoxColumn
            // 
            cpDataGridViewTextBoxColumn.DataPropertyName = "cp";
            cpDataGridViewTextBoxColumn.HeaderText = "cp";
            cpDataGridViewTextBoxColumn.Name = "cpDataGridViewTextBoxColumn";
            cpDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telefonoDataGridViewTextBoxColumn
            // 
            telefonoDataGridViewTextBoxColumn.DataPropertyName = "telefono";
            telefonoDataGridViewTextBoxColumn.HeaderText = "telefono";
            telefonoDataGridViewTextBoxColumn.Name = "telefonoDataGridViewTextBoxColumn";
            telefonoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // anuladoDataGridViewCheckBoxColumn
            // 
            anuladoDataGridViewCheckBoxColumn.DataPropertyName = "anulado";
            anuladoDataGridViewCheckBoxColumn.HeaderText = "anulado";
            anuladoDataGridViewCheckBoxColumn.Name = "anuladoDataGridViewCheckBoxColumn";
            anuladoDataGridViewCheckBoxColumn.ReadOnly = true;
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
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn razonsocialDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn condicionivaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tipofacturaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cuitDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn domicilioDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn localidadDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn provinciaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cpDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn anuladoDataGridViewCheckBoxColumn;
        private BindingSource clienteBindingSource;
        private Button btnConsultar;
    }
}