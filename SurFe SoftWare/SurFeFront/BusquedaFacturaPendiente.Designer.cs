namespace SurFeFront
{
    partial class BusquedaFacturaPendiente
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

            gridFacturas = new System.Windows.Forms.DataGridView();
            colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colNroFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();

            btnSeleccionar = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)gridFacturas).BeginInit();
            panelHeader.SuspendLayout();
            SuspendLayout();

            // ── panelHeader ──────────────────────────────────────────────
            panelHeader.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            panelHeader.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblTitulo, lblSubtitulo
            });
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Size = new System.Drawing.Size(700, 70);
            panelHeader.TabIndex = 0;

            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 122, 204);
            lblTitulo.Location = new System.Drawing.Point(12, 10);
            lblTitulo.Text = "Seleccionar Factura a Pagar";

            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            lblSubtitulo.ForeColor = System.Drawing.Color.DimGray;
            lblSubtitulo.Location = new System.Drawing.Point(14, 44);
            lblSubtitulo.Text = "Facturas pendientes o con pago parcial.";

            // ── gridFacturas ─────────────────────────────────────────────
            estiloHeader.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            estiloHeader.ForeColor = System.Drawing.Color.White;
            estiloHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);

            gridFacturas.AllowUserToAddRows = false;
            gridFacturas.AllowUserToDeleteRows = false;
            gridFacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            gridFacturas.BackgroundColor = System.Drawing.Color.White;
            gridFacturas.ColumnHeadersDefaultCellStyle = estiloHeader;
            gridFacturas.ColumnHeadersHeight = 30;
            gridFacturas.MultiSelect = false;
            gridFacturas.ReadOnly = true;
            gridFacturas.RowHeadersVisible = false;
            gridFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            gridFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                colId, colProveedor, colNroFactura, colFecha, colMonto, colEstado
            });
            gridFacturas.Location = new System.Drawing.Point(16, 82);
            gridFacturas.Size = new System.Drawing.Size(668, 260);
            gridFacturas.TabIndex = 1;
            gridFacturas.CellDoubleClick += gridFacturas_CellDoubleClick;

            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.FillWeight = 10;

            colProveedor.HeaderText = "Proveedor";
            colProveedor.Name = "colProveedor";
            colProveedor.FillWeight = 30;

            colNroFactura.HeaderText = "N° Factura";
            colNroFactura.Name = "colNroFactura";
            colNroFactura.FillWeight = 20;

            colFecha.HeaderText = "Fecha Emisión";
            colFecha.Name = "colFecha";
            colFecha.FillWeight = 15;

            colMonto.HeaderText = "Monto";
            colMonto.Name = "colMonto";
            colMonto.FillWeight = 15;

            colEstado.HeaderText = "Estado Pago";
            colEstado.Name = "colEstado";
            colEstado.FillWeight = 15;

            // ── Botones ──────────────────────────────────────────────────
            btnSeleccionar.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            btnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSeleccionar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            btnSeleccionar.ForeColor = System.Drawing.Color.White;
            btnSeleccionar.Location = new System.Drawing.Point(450, 356);
            btnSeleccionar.Size = new System.Drawing.Size(110, 34);
            btnSeleccionar.TabIndex = 2;
            btnSeleccionar.Text = "✔ Seleccionar";
            btnSeleccionar.UseVisualStyleBackColor = false;
            btnSeleccionar.Click += btnSeleccionar_Click;

            btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancelar.Location = new System.Drawing.Point(574, 356);
            btnCancelar.Size = new System.Drawing.Size(110, 34);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.Click += btnCancelar_Click;

            // ── Form ─────────────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(700, 405);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "SurFe - Buscar Factura";
            Controls.AddRange(new System.Windows.Forms.Control[]
            {
                gridFacturas, btnSeleccionar, btnCancelar, panelHeader
            });

            ((System.ComponentModel.ISupportInitialize)gridFacturas).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.DataGridView gridFacturas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNroFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Button btnCancelar;
    }
}