namespace SurFeFront
{
    partial class Proveedores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            btnNuevo = new Button();
            btnModificar = new Button();
            btnConsultar = new Button();
            btnSalir = new Button();
            lblBuscar = new Label();
            tbBuscar = new TextBox();
            dgvProveedores = new DataGridView();
            btnEliminar = new Button();
            panelHeader = new Panel();
            panelFooter = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).BeginInit();
            panelHeader.SuspendLayout();
            panelFooter.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(240, 240, 240);
            panelHeader.Controls.Add(lblBuscar);
            panelHeader.Controls.Add(tbBuscar);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(800, 60);
            panelHeader.TabIndex = 10;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblBuscar.ForeColor = Color.FromArgb(64, 64, 64);
            lblBuscar.Location = new Point(20, 22);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(51, 17);
            lblBuscar.TabIndex = 5;
            lblBuscar.Text = "Buscar:";
            // 
            // tbBuscar
            // 
            tbBuscar.BackColor = Color.White;
            tbBuscar.BorderStyle = BorderStyle.FixedSingle;
            tbBuscar.Font = new Font("Segoe UI", 10F);
            tbBuscar.Location = new Point(77, 18);
            tbBuscar.Name = "tbBuscar";
            tbBuscar.PlaceholderText = " Ingrese razón social o CUIT...";
            tbBuscar.Size = new Size(350, 25);
            tbBuscar.TabIndex = 6;
            tbBuscar.TextChanged += tbBuscar_TextChanged;
            // 
            // dgvProveedores
            // 
            dgvProveedores.AllowUserToAddRows = false;
            dgvProveedores.AllowUserToDeleteRows = false;
            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProveedores.BackgroundColor = Color.White;
            dgvProveedores.BorderStyle = BorderStyle.None;
            dgvProveedores.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProveedores.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProveedores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProveedores.ColumnHeadersHeight = 35;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(230, 242, 250);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvProveedores.DefaultCellStyle = dataGridViewCellStyle2;
            dgvProveedores.Dock = DockStyle.Fill;
            dgvProveedores.EnableHeadersVisualStyles = false;
            dgvProveedores.GridColor = Color.FromArgb(224, 224, 224);
            dgvProveedores.Location = new Point(0, 60);
            dgvProveedores.MultiSelect = false;
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.ReadOnly = true;
            dgvProveedores.RowHeadersVisible = false;
            dgvProveedores.RowTemplate.Height = 30;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.Size = new Size(800, 360);
            dgvProveedores.TabIndex = 8;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.FromArgb(245, 245, 245);
            panelFooter.Controls.Add(btnNuevo);
            panelFooter.Controls.Add(btnModificar);
            panelFooter.Controls.Add(btnConsultar);
            panelFooter.Controls.Add(btnEliminar);
            panelFooter.Controls.Add(btnSalir);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 420);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(800, 80);
            panelFooter.TabIndex = 11;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(0, 122, 204);
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(20, 20);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(110, 40);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "NUEVO";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += button1_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.FromArgb(224, 224, 224);
            btnModificar.FlatAppearance.BorderSize = 0;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnModificar.ForeColor = Color.Black;
            btnModificar.Location = new Point(140, 20);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(110, 40);
            btnModificar.TabIndex = 1;
            btnModificar.Text = "MODIFICAR";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += button2_Click;
            // 
            // btnConsultar
            // 
            btnConsultar.BackColor = Color.FromArgb(224, 224, 224);
            btnConsultar.FlatAppearance.BorderSize = 0;
            btnConsultar.FlatStyle = FlatStyle.Flat;
            btnConsultar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnConsultar.ForeColor = Color.Black;
            btnConsultar.Location = new Point(260, 20);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(110, 40);
            btnConsultar.TabIndex = 2;
            btnConsultar.Text = "CONSULTA";
            btnConsultar.UseVisualStyleBackColor = false;
            btnConsultar.Click += btncons_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(255, 192, 192);
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.FromArgb(192, 0, 0);
            btnEliminar.Location = new Point(380, 20);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(110, 40);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btneliminar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSalir.BackColor = Color.FromArgb(224, 224, 224);
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnSalir.ForeColor = Color.Black;
            btnSalir.Location = new Point(670, 20);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(110, 40);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += button5_Click;
            // 
            // Proveedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 500);
            Controls.Add(dgvProveedores);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);
            Name = "Proveedores";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SurFe - Gestión de Proveedores";
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnNuevo;
        private Button btnModificar;
        private Button btnConsultar;
        private Button btnSalir;
        private Label lblBuscar;
        private TextBox tbBuscar;
        private DataGridView dgvProveedores;
        private Button btnEliminar;
        private Panel panelHeader;
        private Panel panelFooter;
    }
}