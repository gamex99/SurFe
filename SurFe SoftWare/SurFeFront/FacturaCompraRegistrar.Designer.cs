namespace SurFeFront
{
    partial class FacturaCompraRegistrar
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

            // ── Controles ────────────────────────────────────────────────
            panelHeader = new System.Windows.Forms.Panel();
            lblTitulo = new System.Windows.Forms.Label();
            lblEtiquetaProv = new System.Windows.Forms.Label();
            lblProvSel = new System.Windows.Forms.Label();
            btnBuscarProv = new System.Windows.Forms.Button();

            panelDatos = new System.Windows.Forms.Panel();
            lblTipo = new System.Windows.Forms.Label();
            cmbTipo = new System.Windows.Forms.ComboBox();
            lblNro = new System.Windows.Forms.Label();
            txtNroFactura = new System.Windows.Forms.TextBox();
            lblFechaEmision = new System.Windows.Forms.Label();
            dtpEmision = new System.Windows.Forms.DateTimePicker();
            lblFechaVenc = new System.Windows.Forms.Label();
            dtpVencimiento = new System.Windows.Forms.DateTimePicker();
            lblTotal = new System.Windows.Forms.Label();
            txtTotal = new System.Windows.Forms.TextBox();

            lblOCs = new System.Windows.Forms.Label();
            btnAsociarOC = new System.Windows.Forms.Button();
            gridOCs = new System.Windows.Forms.DataGridView();
            colOCId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colOCFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colOCTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colOCEliminar = new System.Windows.Forms.DataGridViewButtonColumn();

            btnGuardar = new System.Windows.Forms.Button();
            btnGuardarYPagar = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)gridOCs).BeginInit();
            panelHeader.SuspendLayout();
            panelDatos.SuspendLayout();
            SuspendLayout();

            // ── panelHeader ──────────────────────────────────────────────
            panelHeader.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            panelHeader.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblTitulo, lblEtiquetaProv, lblProvSel, btnBuscarProv
            });
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Size = new System.Drawing.Size(620, 88);
            panelHeader.TabIndex = 0;

            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 122, 204);
            lblTitulo.Location = new System.Drawing.Point(12, 9);
            lblTitulo.Text = "Registrar Factura de Compra";

            lblEtiquetaProv.AutoSize = true;
            lblEtiquetaProv.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblEtiquetaProv.Location = new System.Drawing.Point(20, 58);
            lblEtiquetaProv.Text = "Proveedor:";

            lblProvSel.AutoSize = true;
            lblProvSel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            lblProvSel.ForeColor = System.Drawing.Color.DimGray;
            lblProvSel.Location = new System.Drawing.Point(100, 56);
            lblProvSel.Text = "Seleccione un proveedor...";

            btnBuscarProv.BackColor = System.Drawing.Color.White;
            btnBuscarProv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBuscarProv.Location = new System.Drawing.Point(340, 52);
            btnBuscarProv.Size = new System.Drawing.Size(150, 28);
            btnBuscarProv.Text = "🔍 Buscar Proveedor";
            btnBuscarProv.UseVisualStyleBackColor = false;
            btnBuscarProv.Click += btnBuscarProv_Click;

            // ── panelDatos ───────────────────────────────────────────────
            panelDatos.BackColor = System.Drawing.Color.White;
            panelDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelDatos.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblTipo, cmbTipo, lblNro, txtNroFactura,
                lblFechaEmision, dtpEmision, lblFechaVenc, dtpVencimiento,
                lblTotal, txtTotal
            });
            panelDatos.Dock = System.Windows.Forms.DockStyle.Top;
            panelDatos.Location = new System.Drawing.Point(0, 88);
            panelDatos.Size = new System.Drawing.Size(620, 105);
            panelDatos.TabIndex = 1;

            lblTipo.AutoSize = true;
            lblTipo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblTipo.Location = new System.Drawing.Point(16, 12);
            lblTipo.Text = "Tipo:";

            cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbTipo.Location = new System.Drawing.Point(55, 9);
            cmbTipo.Size = new System.Drawing.Size(130, 23);
            cmbTipo.TabIndex = 0;

            lblNro.AutoSize = true;
            lblNro.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblNro.Location = new System.Drawing.Point(200, 12);
            lblNro.Text = "N° Factura:";

            txtNroFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtNroFactura.Location = new System.Drawing.Point(280, 9);
            txtNroFactura.Size = new System.Drawing.Size(160, 23);
            txtNroFactura.TabIndex = 1;

            lblFechaEmision.AutoSize = true;
            lblFechaEmision.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblFechaEmision.Location = new System.Drawing.Point(16, 48);
            lblFechaEmision.Text = "F. Emisión:";

            dtpEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpEmision.Location = new System.Drawing.Point(95, 45);
            dtpEmision.Size = new System.Drawing.Size(120, 23);
            dtpEmision.TabIndex = 2;

            lblFechaVenc.AutoSize = true;
            lblFechaVenc.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblFechaVenc.Location = new System.Drawing.Point(235, 48);
            lblFechaVenc.Text = "F. Vencimiento:";

            dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpVencimiento.Location = new System.Drawing.Point(335, 45);
            dtpVencimiento.Size = new System.Drawing.Size(120, 23);
            dtpVencimiento.TabIndex = 3;

            lblTotal.AutoSize = true;
            lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            lblTotal.Location = new System.Drawing.Point(16, 80);
            lblTotal.Text = "Monto total ($):";

            txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            txtTotal.Location = new System.Drawing.Point(150, 77);
            txtTotal.Size = new System.Drawing.Size(130, 27);
            txtTotal.TabIndex = 4;
            txtTotal.KeyPress += txtTotal_KeyPress;

            // ── Grilla OCs ───────────────────────────────────────────────
            estiloHeader.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            estiloHeader.ForeColor = System.Drawing.Color.White;
            estiloHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);

            lblOCs.AutoSize = true;
            lblOCs.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblOCs.Location = new System.Drawing.Point(20, 205);
            lblOCs.Text = "Órdenes de compra asociadas:";

            btnAsociarOC.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            btnAsociarOC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAsociarOC.ForeColor = System.Drawing.Color.White;
            btnAsociarOC.Enabled = false;
            btnAsociarOC.Location = new System.Drawing.Point(220, 200);
            btnAsociarOC.Size = new System.Drawing.Size(130, 26);
            btnAsociarOC.Text = "＋ Asociar OC";
            btnAsociarOC.UseVisualStyleBackColor = false;
            btnAsociarOC.Click += btnAsociarOC_Click;

            gridOCs.AllowUserToAddRows = false;
            gridOCs.AllowUserToDeleteRows = false;
            gridOCs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            gridOCs.BackgroundColor = System.Drawing.Color.White;
            gridOCs.ColumnHeadersDefaultCellStyle = estiloHeader;
            gridOCs.ColumnHeadersHeight = 30;
            gridOCs.RowHeadersVisible = false;
            gridOCs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            gridOCs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                colOCId, colOCFecha, colOCTotal, colOCEliminar
            });
            gridOCs.Location = new System.Drawing.Point(20, 230);
            gridOCs.Size = new System.Drawing.Size(580, 140);
            gridOCs.TabIndex = 5;
            gridOCs.CellContentClick += gridOCs_CellContentClick;

            colOCId.HeaderText = "N° Pedido";
            colOCId.Name = "colOCId";
            colOCId.ReadOnly = true;
            colOCId.FillWeight = 20;

            colOCFecha.HeaderText = "Fecha";
            colOCFecha.Name = "colOCFecha";
            colOCFecha.ReadOnly = true;
            colOCFecha.FillWeight = 30;

            colOCTotal.HeaderText = "Total estimado";
            colOCTotal.Name = "colOCTotal";
            colOCTotal.ReadOnly = true;
            colOCTotal.FillWeight = 30;

            colOCEliminar.HeaderText = "";
            colOCEliminar.Name = "colOCEliminar";
            colOCEliminar.Text = "✕ Quitar";
            colOCEliminar.UseColumnTextForButtonValue = true;
            colOCEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            colOCEliminar.FillWeight = 20;

            // ── Botones inferiores ───────────────────────────────────────
            btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            btnGuardar.Location = new System.Drawing.Point(220, 388);
            btnGuardar.Size = new System.Drawing.Size(120, 36);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "💾 GUARDAR";
            btnGuardar.Click += btnGuardar_Click;

            btnGuardarYPagar.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            btnGuardarYPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGuardarYPagar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            btnGuardarYPagar.ForeColor = System.Drawing.Color.White;
            btnGuardarYPagar.Location = new System.Drawing.Point(355, 388);
            btnGuardarYPagar.Size = new System.Drawing.Size(150, 36);
            btnGuardarYPagar.TabIndex = 7;
            btnGuardarYPagar.Text = "💳 GUARDAR Y PAGAR";
            btnGuardarYPagar.UseVisualStyleBackColor = false;
            btnGuardarYPagar.Click += btnGuardarYPagar_Click;

            btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancelar.Location = new System.Drawing.Point(520, 388);
            btnCancelar.Size = new System.Drawing.Size(90, 36);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.Click += btnCancelar_Click;

            // ── Form ─────────────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(620, 440);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SurFe - Registrar Factura de Compra";
            Controls.AddRange(new System.Windows.Forms.Control[]
            {
                gridOCs, lblOCs, btnAsociarOC,
                btnGuardar, btnGuardarYPagar, btnCancelar,
                panelDatos, panelHeader
            });

            ((System.ComponentModel.ISupportInitialize)gridOCs).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelDatos.ResumeLayout(false);
            panelDatos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEtiquetaProv;
        private System.Windows.Forms.Label lblProvSel;
        private System.Windows.Forms.Button btnBuscarProv;

        private System.Windows.Forms.Panel panelDatos;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblNro;
        private System.Windows.Forms.TextBox txtNroFactura;
        private System.Windows.Forms.Label lblFechaEmision;
        private System.Windows.Forms.DateTimePicker dtpEmision;
        private System.Windows.Forms.Label lblFechaVenc;
        private System.Windows.Forms.DateTimePicker dtpVencimiento;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;

        private System.Windows.Forms.Label lblOCs;
        private System.Windows.Forms.Button btnAsociarOC;
        private System.Windows.Forms.DataGridView gridOCs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOCId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOCFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOCTotal;
        private System.Windows.Forms.DataGridViewButtonColumn colOCEliminar;

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnGuardarYPagar;
        private System.Windows.Forms.Button btnCancelar;
    }
}