namespace SurFeFront
{
    partial class BusquedaOCProveedor
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

            gridOCs = new System.Windows.Forms.DataGridView();
            colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();

            btnSeleccionar = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)gridOCs).BeginInit();
            panelHeader.SuspendLayout();
            SuspendLayout();

            // ── panelHeader ──────────────────────────────────────────────
            panelHeader.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            panelHeader.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblTitulo, lblSubtitulo
            });
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Size = new System.Drawing.Size(560, 70);
            panelHeader.TabIndex = 0;

            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 122, 204);
            lblTitulo.Location = new System.Drawing.Point(12, 10);
            lblTitulo.Text = "Seleccionar Orden de Compra";

            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            lblSubtitulo.ForeColor = System.Drawing.Color.DimGray;
            lblSubtitulo.Location = new System.Drawing.Point(14, 44);
            lblSubtitulo.Text = "Se muestran las órdenes enviadas o pendientes del proveedor seleccionado.";

            // ── gridOCs ──────────────────────────────────────────────────
            estiloHeader.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            estiloHeader.ForeColor = System.Drawing.Color.White;
            estiloHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);

            gridOCs.AllowUserToAddRows = false;
            gridOCs.AllowUserToDeleteRows = false;
            gridOCs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            gridOCs.BackgroundColor = System.Drawing.Color.White;
            gridOCs.ColumnHeadersDefaultCellStyle = estiloHeader;
            gridOCs.ColumnHeadersHeight = 30;
            gridOCs.MultiSelect = false;
            gridOCs.ReadOnly = true;
            gridOCs.RowHeadersVisible = false;
            gridOCs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            gridOCs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                colId, colFecha, colEstado, colTotal
            });
            gridOCs.Location = new System.Drawing.Point(16, 82);
            gridOCs.Size = new System.Drawing.Size(528, 220);
            gridOCs.TabIndex = 1;
            gridOCs.CellDoubleClick += gridOCs_CellDoubleClick;

            colId.HeaderText = "N° Pedido";
            colId.Name = "colId";
            colId.FillWeight = 20;

            colFecha.HeaderText = "Fecha";
            colFecha.Name = "colFecha";
            colFecha.FillWeight = 30;

            colEstado.HeaderText = "Estado";
            colEstado.Name = "colEstado";
            colEstado.FillWeight = 25;

            colTotal.HeaderText = "Total estimado";
            colTotal.Name = "colTotal";
            colTotal.FillWeight = 25;

            // ── Botones ──────────────────────────────────────────────────
            btnSeleccionar.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            btnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSeleccionar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            btnSeleccionar.ForeColor = System.Drawing.Color.White;
            btnSeleccionar.Location = new System.Drawing.Point(310, 316);
            btnSeleccionar.Size = new System.Drawing.Size(110, 34);
            btnSeleccionar.TabIndex = 2;
            btnSeleccionar.Text = "✔ Seleccionar";
            btnSeleccionar.UseVisualStyleBackColor = false;
            btnSeleccionar.Click += btnSeleccionar_Click;

            btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancelar.Location = new System.Drawing.Point(434, 316);
            btnCancelar.Size = new System.Drawing.Size(110, 34);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.Click += btnCancelar_Click;

            // ── Form ─────────────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(560, 365);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "SurFe - Buscar Orden de Compra";
            Controls.AddRange(new System.Windows.Forms.Control[]
            {
                gridOCs, btnSeleccionar, btnCancelar, panelHeader
            });

            ((System.ComponentModel.ISupportInitialize)gridOCs).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.DataGridView gridOCs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Button btnCancelar;
    }
}