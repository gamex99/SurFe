namespace SurFeFront
{
    partial class BusquedaProducto
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
            dgvProductos = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // txtFiltro
            txtFiltro.Location = new Point(12, 32);
            txtFiltro.PlaceholderText = " Buscar por Nombre o Código...";
            txtFiltro.Size = new Size(360, 23);
            txtFiltro.TextChanged += txtFiltro_TextChanged;
            // dgvProductos
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.Location = new Point(12, 70);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(360, 280);
            dgvProductos.CellDoubleClick += dgvProductos_CellDoubleClick;
            // label1
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label1.Location = new Point(12, 12);
            label1.Text = "Seleccione un Producto (Doble Clic):";
            // BusquedaProducto
            ClientSize = new Size(384, 361);
            Controls.Add(label1);
            Controls.Add(dgvProductos);
            Controls.Add(txtFiltro);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            StartPosition = FormStartPosition.CenterParent;
            Text = "SurFe - Buscador de Productos";
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox txtFiltro;
        private DataGridView dgvProductos;
        private Label label1;
    }
}