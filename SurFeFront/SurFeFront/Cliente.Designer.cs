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
            dtgEmpledos = new DataGridView();
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
            contextMenuStrip1 = new ContextMenuStrip(components);
            opcionesToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            opcionesToolStripMenuItem1 = new ToolStripMenuItem();
            reportesToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dtgEmpledos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clienteBindingSource).BeginInit();
            contextMenuStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
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
            // dtgEmpledos
            // 
            dtgEmpledos.AutoGenerateColumns = false;
            dtgEmpledos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgEmpledos.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, razonsocialDataGridViewTextBoxColumn, condicionivaDataGridViewTextBoxColumn, tipofacturaDataGridViewTextBoxColumn, cuitDataGridViewTextBoxColumn, domicilioDataGridViewTextBoxColumn, localidadDataGridViewTextBoxColumn, provinciaDataGridViewTextBoxColumn, cpDataGridViewTextBoxColumn, telefonoDataGridViewTextBoxColumn, anuladoDataGridViewCheckBoxColumn });
            dtgEmpledos.DataSource = clienteBindingSource;
            dtgEmpledos.Location = new Point(12, 78);
            dtgEmpledos.Name = "dtgEmpledos";
            dtgEmpledos.RowTemplate.Height = 25;
            dtgEmpledos.Size = new Size(776, 316);
            dtgEmpledos.TabIndex = 2;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "id";
            idDataGridViewTextBoxColumn.HeaderText = "id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // razonsocialDataGridViewTextBoxColumn
            // 
            razonsocialDataGridViewTextBoxColumn.DataPropertyName = "razon_social";
            razonsocialDataGridViewTextBoxColumn.HeaderText = "razon_social";
            razonsocialDataGridViewTextBoxColumn.Name = "razonsocialDataGridViewTextBoxColumn";
            // 
            // condicionivaDataGridViewTextBoxColumn
            // 
            condicionivaDataGridViewTextBoxColumn.DataPropertyName = "condicion_iva";
            condicionivaDataGridViewTextBoxColumn.HeaderText = "condicion_iva";
            condicionivaDataGridViewTextBoxColumn.Name = "condicionivaDataGridViewTextBoxColumn";
            // 
            // tipofacturaDataGridViewTextBoxColumn
            // 
            tipofacturaDataGridViewTextBoxColumn.DataPropertyName = "tipo_factura";
            tipofacturaDataGridViewTextBoxColumn.HeaderText = "tipo_factura";
            tipofacturaDataGridViewTextBoxColumn.Name = "tipofacturaDataGridViewTextBoxColumn";
            // 
            // cuitDataGridViewTextBoxColumn
            // 
            cuitDataGridViewTextBoxColumn.DataPropertyName = "cuit";
            cuitDataGridViewTextBoxColumn.HeaderText = "cuit";
            cuitDataGridViewTextBoxColumn.Name = "cuitDataGridViewTextBoxColumn";
            // 
            // domicilioDataGridViewTextBoxColumn
            // 
            domicilioDataGridViewTextBoxColumn.DataPropertyName = "domicilio";
            domicilioDataGridViewTextBoxColumn.HeaderText = "domicilio";
            domicilioDataGridViewTextBoxColumn.Name = "domicilioDataGridViewTextBoxColumn";
            // 
            // localidadDataGridViewTextBoxColumn
            // 
            localidadDataGridViewTextBoxColumn.DataPropertyName = "localidad";
            localidadDataGridViewTextBoxColumn.HeaderText = "localidad";
            localidadDataGridViewTextBoxColumn.Name = "localidadDataGridViewTextBoxColumn";
            // 
            // provinciaDataGridViewTextBoxColumn
            // 
            provinciaDataGridViewTextBoxColumn.DataPropertyName = "provincia";
            provinciaDataGridViewTextBoxColumn.HeaderText = "provincia";
            provinciaDataGridViewTextBoxColumn.Name = "provinciaDataGridViewTextBoxColumn";
            // 
            // cpDataGridViewTextBoxColumn
            // 
            cpDataGridViewTextBoxColumn.DataPropertyName = "cp";
            cpDataGridViewTextBoxColumn.HeaderText = "cp";
            cpDataGridViewTextBoxColumn.Name = "cpDataGridViewTextBoxColumn";
            // 
            // telefonoDataGridViewTextBoxColumn
            // 
            telefonoDataGridViewTextBoxColumn.DataPropertyName = "telefono";
            telefonoDataGridViewTextBoxColumn.HeaderText = "telefono";
            telefonoDataGridViewTextBoxColumn.Name = "telefonoDataGridViewTextBoxColumn";
            // 
            // anuladoDataGridViewCheckBoxColumn
            // 
            anuladoDataGridViewCheckBoxColumn.DataPropertyName = "anulado";
            anuladoDataGridViewCheckBoxColumn.HeaderText = "anulado";
            anuladoDataGridViewCheckBoxColumn.Name = "anuladoDataGridViewCheckBoxColumn";
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
            btModificar.Location = new Point(93, 400);
            btModificar.Name = "btModificar";
            btModificar.Size = new Size(75, 25);
            btModificar.TabIndex = 4;
            btModificar.Text = "Modificar";
            btModificar.UseVisualStyleBackColor = true;
            // 
            // btEliminar
            // 
            btEliminar.Location = new Point(174, 400);
            btEliminar.Name = "btEliminar";
            btEliminar.Size = new Size(75, 25);
            btEliminar.TabIndex = 5;
            btEliminar.Text = "Eliminar";
            btEliminar.UseVisualStyleBackColor = true;
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
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { opcionesToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(125, 26);
            // 
            // opcionesToolStripMenuItem
            // 
            opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            opcionesToolStripMenuItem.Size = new Size(124, 22);
            opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { opcionesToolStripMenuItem1, reportesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem1
            // 
            opcionesToolStripMenuItem1.Name = "opcionesToolStripMenuItem1";
            opcionesToolStripMenuItem1.Size = new Size(69, 20);
            opcionesToolStripMenuItem1.Text = "Opciones";
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(65, 20);
            reportesToolStripMenuItem.Text = "Reportes";
            // 
            // Cliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 432);
            Controls.Add(menuStrip1);
            Controls.Add(btSalir);
            Controls.Add(btEliminar);
            Controls.Add(btModificar);
            Controls.Add(btNuevo);
            Controls.Add(dtgEmpledos);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            MainMenuStrip = menuStrip1;
            Name = "Cliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cliente";
            Load += Cliente_Load;
            ((System.ComponentModel.ISupportInitialize)dtgEmpledos).EndInit();
            ((System.ComponentModel.ISupportInitialize)clienteBindingSource).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBuscar;
        private TextBox txtBuscar;
        private DataGridView dtgEmpledos;
        private Button btNuevo;
        private Button btModificar;
        private Button btEliminar;
        private Button btSalir;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem opcionesToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem opcionesToolStripMenuItem1;
        private ToolStripMenuItem reportesToolStripMenuItem;
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
    }
}