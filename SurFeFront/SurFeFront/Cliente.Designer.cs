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
            dataGridView1 = new DataGridView();
            btNuevo = new Button();
            btModificar = new Button();
            btEliminar = new Button();
            btSalir = new Button();
            comboBox1 = new ComboBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            opcionesToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            opcionesToolStripMenuItem1 = new ToolStripMenuItem();
            reportesToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 78);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(776, 316);
            dataGridView1.TabIndex = 2;
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
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(358, 41);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(165, 23);
            comboBox1.TabIndex = 7;
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
            Controls.Add(comboBox1);
            Controls.Add(btSalir);
            Controls.Add(btEliminar);
            Controls.Add(btModificar);
            Controls.Add(btNuevo);
            Controls.Add(dataGridView1);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            MainMenuStrip = menuStrip1;
            Name = "Cliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cliente";
            Load += Cliente_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBuscar;
        private TextBox txtBuscar;
        private DataGridView dataGridView1;
        private Button btNuevo;
        private Button btModificar;
        private Button btEliminar;
        private Button btSalir;
        private ComboBox comboBox1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem opcionesToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem opcionesToolStripMenuItem1;
        private ToolStripMenuItem reportesToolStripMenuItem;
    }
}