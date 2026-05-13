namespace SurFeFront
{
    partial class BusquedaRemitoRecibido
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle estiloHeader = new System.Windows.Forms.DataGridViewCellStyle();

            panelHeader = new System.Windows.Forms.Panel();
            lblTitulo = new System.Windows.Forms.Label();
            lblSubtitulo = new System.Windows.Forms.Label();

            panelFiltros = new System.Windows.Forms.Panel();
            lblBuscar = new System.Windows.Forms.Label();
            txtBuscar = new System.Windows.Forms.TextBox();
            chkSoloDiferencias = new System.Windows.Forms.CheckBox();

            gridRemitos = new System.Windows.Forms.DataGridView();
            colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colNroRemito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDiferencias = new System.Windows.Forms.DataGridViewTextBoxColumn();

            btnSeleccionar = new System.Windows.Forms.Button();
            btnProductoManual = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)gridRemitos).BeginInit();
            panelHeader.SuspendLayout();
            panelFiltros.SuspendLayout();
            SuspendLayout();

            // ── panelHeader ──────────────────────────────────────────────
            panelHeader.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            panelHeader.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblTitulo, lblSubtitulo
            });
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Size = new System.Drawing.Size(700, 70);

            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 122, 204);
            lblTitulo.Location = new System.Drawing.Point(12, 10);
            lblTitulo.Text = "Seleccionar Remito";

            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            lblSubtitulo.ForeColor = System.Drawing.Color.DimGray;
            lblSubtitulo.Location = new System.Drawing.Point(14, 44);
            lblSubtitulo.Text = "Seleccione el remito sobre el cual desea registrar el reclamo.";

            // ── panelFiltros ─────────────────────────────────────────────
            panelFiltros.BackColor = System.Drawing.Color.White;
            panelFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelFiltros.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblBuscar, txtBuscar, chkSoloDiferencias
            });
            panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            panelFiltros.Location = new System.Drawing.Point(0, 70);
            panelFiltros.Size = new System.Drawing.Size(700, 45);

            lblBuscar.AutoSize = true;
            lblBuscar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblBuscar.Location = new System.Drawing.Point(16, 14);
            lblBuscar.Text = "Buscar:";

            txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtBuscar.Location = new System.Drawing.Point(65, 11);
            txtBuscar.Size = new System.Drawing.Size(250, 23);
            txtBuscar.TabIndex = 0;
            txtBuscar.TextChanged += txtBuscar_TextChanged;

            chkSoloDiferencias.AutoSize = true;
            chkSoloDiferencias.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            chkSoloDiferencias.Location = new System.Drawing.Point(340, 13);
            chkSoloDiferencias.Text = "Solo remitos con diferencias";
            chkSoloDiferencias.TabIndex = 1;
            chkSoloDiferencias.CheckedChanged += chkSoloDiferencias_CheckedChanged;

            // ── gridRemitos ──────────────────────────────────────────────
            estiloHeader.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            estiloHeader.ForeColor = System.Drawing.Color.White;
            estiloHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);

            gridRemitos.AllowUserToAddRows = false;
            gridRemitos.AllowUserToDeleteRows = false;
            gridRemitos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            gridRemitos.BackgroundColor = System.Drawing.Color.White;
            gridRemitos.ColumnHeadersDefaultCellStyle = estiloHeader;
            gridRemitos.ColumnHeadersHeight = 30;
            gridRemitos.MultiSelect = false;
            gridRemitos.ReadOnly = true;
            gridRemitos.RowHeadersVisible = false;
            gridRemitos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            gridRemitos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                colId, colProveedor, colNroRemito, colFecha, colEstado, colDiferencias
            });
            gridRemitos.Location = new System.Drawing.Point(16, 128);
            gridRemitos.Size = new System.Drawing.Size(668, 240);
            gridRemitos.TabIndex = 2;
            gridRemitos.CellDoubleClick += gridRemitos_CellDoubleClick;

            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.FillWeight = 8;

            colProveedor.HeaderText = "Proveedor";
            colProveedor.Name = "colProveedor";
            colProveedor.FillWeight = 30;

            colNroRemito.HeaderText = "N° Remito";
            colNroRemito.Name = "colNroRemito";
            colNroRemito.FillWeight = 18;

            colFecha.HeaderText = "Fecha";
            colFecha.Name = "colFecha";
            colFecha.FillWeight = 16;

            colEstado.HeaderText = "Estado";
            colEstado.Name = "colEstado";
            colEstado.FillWeight = 14;

            colDiferencias.HeaderText = "Diferencias";
            colDiferencias.Name = "colDiferencias";
            colDiferencias.FillWeight = 14;

            // ── Botones ──────────────────────────────────────────────────
            btnSeleccionar.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            btnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSeleccionar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            btnSeleccionar.ForeColor = System.Drawing.Color.White;
            btnSeleccionar.Location = new System.Drawing.Point(340, 382);
            btnSeleccionar.Size = new System.Drawing.Size(110, 34);
            btnSeleccionar.TabIndex = 3;
            btnSeleccionar.Text = "✔ Seleccionar";
            btnSeleccionar.UseVisualStyleBackColor = false;
            btnSeleccionar.Click += btnSeleccionar_Click;

            btnProductoManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnProductoManual.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            btnProductoManual.Location = new System.Drawing.Point(16, 382);
            btnProductoManual.Size = new System.Drawing.Size(160, 34);
            btnProductoManual.TabIndex = 4;
            btnProductoManual.Text = "＋ Producto manual";
            btnProductoManual.Click += btnProductoManual_Click;

            btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancelar.Location = new System.Drawing.Point(464, 382);
            btnCancelar.Size = new System.Drawing.Size(110, 34);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.Click += btnCancelar_Click;

            // ── Form ─────────────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(700, 432);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "SurFe - Buscar Remito";
            Controls.AddRange(new System.Windows.Forms.Control[]
            {
                gridRemitos, btnSeleccionar, btnProductoManual, btnCancelar,
                panelFiltros, panelHeader
            });

            ((System.ComponentModel.ISupportInitialize)gridRemitos).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.CheckBox chkSoloDiferencias;
        private System.Windows.Forms.DataGridView gridRemitos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNroRemito;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiferencias;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Button btnProductoManual;
        private System.Windows.Forms.Button btnCancelar;
    }
}