namespace SurFeFront
{
    partial class BusquedaProveedor
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtFiltro = new TextBox();
            dgvProveedores = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).BeginInit();
            SuspendLayout();
            // txtFiltro
            txtFiltro.Location = new Point(12, 32);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.PlaceholderText = " Buscar por Razón Social o CUIT...";
            txtFiltro.Size = new Size(360, 23);
            txtFiltro.TextChanged += txtFiltro_TextChanged;
            // dgvProveedores
            dgvProveedores.AllowUserToAddRows = false;
            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProveedores.BackgroundColor = Color.White;
            dgvProveedores.ColumnHeadersHeight = 30;
            dgvProveedores.Location = new Point(12, 70);
            dgvProveedores.MultiSelect = false;
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.ReadOnly = true;
            dgvProveedores.RowHeadersVisible = false;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.Size = new Size(360, 280);
            dgvProveedores.CellDoubleClick += dgvProveedores_CellDoubleClick;
            // label1
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label1.Location = new Point(12, 12);
            label1.Text = "Seleccione un Proveedor (Doble Clic):";
            // BusquedaProveedor
            ClientSize = new Size(384, 361);
            Controls.Add(label1);
            Controls.Add(dgvProveedores);
            Controls.Add(txtFiltro);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            StartPosition = FormStartPosition.CenterParent;
            Text = "SurFe - Buscador de Proveedores";
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox txtFiltro;
        private DataGridView dgvProveedores;
        private Label label1;
    }
}