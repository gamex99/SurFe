namespace SurFeFront
{
    partial class RecepcionMercaderia
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
            lblEtiquetaProv = new System.Windows.Forms.Label();
            lblProveedor = new System.Windows.Forms.Label();
            btnBuscarProveedor = new System.Windows.Forms.Button();

            panelDatos = new System.Windows.Forms.Panel();
            lblNroRemito = new System.Windows.Forms.Label();
            txtNroRemito = new System.Windows.Forms.TextBox();
            lblFechaEntrada = new System.Windows.Forms.Label();
            dtpFechaEntrada = new System.Windows.Forms.DateTimePicker();
            lblObservaciones = new System.Windows.Forms.Label();
            txtObservaciones = new System.Windows.Forms.TextBox();

            lblOC = new System.Windows.Forms.Label();
            btnAsociarOC = new System.Windows.Forms.Button();
            gridOCs = new System.Windows.Forms.DataGridView();
            colOCId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colOCFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colOCEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colOCEliminar = new System.Windows.Forms.DataGridViewButtonColumn();

            lblProductos = new System.Windows.Forms.Label();
            gridProductos = new System.Windows.Forms.DataGridView();
            colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCantPedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCantRecibida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDiferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();

            lblResumen = new System.Windows.Forms.Label();
            btnGuardar = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)gridOCs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridProductos).BeginInit();
            panelHeader.SuspendLayout();
            panelDatos.SuspendLayout();
            SuspendLayout();

            // ── panelHeader ──────────────────────────────────────────────
            panelHeader.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            panelHeader.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblTitulo, lblEtiquetaProv, lblProveedor, btnBuscarProveedor
            });
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Size = new System.Drawing.Size(880, 85);

            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 122, 204);
            lblTitulo.Location = new System.Drawing.Point(12, 9);
            lblTitulo.Text = "Recepción de Mercadería";

            lblEtiquetaProv.AutoSize = true;
            lblEtiquetaProv.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblEtiquetaProv.Location = new System.Drawing.Point(20, 55);
            lblEtiquetaProv.Text = "Proveedor:";

            lblProveedor.AutoSize = true;
            lblProveedor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            lblProveedor.ForeColor = System.Drawing.Color.DimGray;
            lblProveedor.Location = new System.Drawing.Point(95, 53);
            lblProveedor.Text = "Seleccione un proveedor...";

            btnBuscarProveedor.BackColor = System.Drawing.Color.White;
            btnBuscarProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBuscarProveedor.Location = new System.Drawing.Point(340, 50);
            btnBuscarProveedor.Size = new System.Drawing.Size(150, 28);
            btnBuscarProveedor.Text = "🔍 Buscar Proveedor";
            btnBuscarProveedor.UseVisualStyleBackColor = false;
            btnBuscarProveedor.Click += btnBuscarProveedor_Click;

            // ── panelDatos ───────────────────────────────────────────────
            panelDatos.BackColor = System.Drawing.Color.White;
            panelDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelDatos.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblNroRemito, txtNroRemito,
                lblFechaEntrada, dtpFechaEntrada,
                lblObservaciones, txtObservaciones
            });
            panelDatos.Dock = System.Windows.Forms.DockStyle.Top;
            panelDatos.Location = new System.Drawing.Point(0, 85);
            panelDatos.Size = new System.Drawing.Size(880, 70);

            lblNroRemito.AutoSize = true;
            lblNroRemito.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblNroRemito.Location = new System.Drawing.Point(16, 12);
            lblNroRemito.Text = "N° Remito:";

            txtNroRemito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtNroRemito.Location = new System.Drawing.Point(90, 9);
            txtNroRemito.Size = new System.Drawing.Size(130, 23);
            txtNroRemito.TabIndex = 0;

            lblFechaEntrada.AutoSize = true;
            lblFechaEntrada.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblFechaEntrada.Location = new System.Drawing.Point(240, 12);
            lblFechaEntrada.Text = "Fecha entrada:";

            dtpFechaEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpFechaEntrada.Location = new System.Drawing.Point(335, 9);
            dtpFechaEntrada.Size = new System.Drawing.Size(120, 23);
            dtpFechaEntrada.TabIndex = 1;

            lblObservaciones.AutoSize = true;
            lblObservaciones.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblObservaciones.Location = new System.Drawing.Point(16, 42);
            lblObservaciones.Text = "Observaciones:";

            txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtObservaciones.Location = new System.Drawing.Point(105, 39);
            txtObservaciones.Size = new System.Drawing.Size(400, 23);
            txtObservaciones.MaxLength = 255;
            txtObservaciones.TabIndex = 2;

            // ── Grilla OCs ───────────────────────────────────────────────
            estiloHeader.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            estiloHeader.ForeColor = System.Drawing.Color.White;
            estiloHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);

            lblOC.AutoSize = true;
            lblOC.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblOC.Location = new System.Drawing.Point(20, 170);
            lblOC.Text = "Órdenes de compra asociadas:";

            btnAsociarOC.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            btnAsociarOC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAsociarOC.ForeColor = System.Drawing.Color.White;
            btnAsociarOC.Enabled = false;
            btnAsociarOC.Location = new System.Drawing.Point(230, 165);
            btnAsociarOC.Size = new System.Drawing.Size(130, 26);
            btnAsociarOC.Text = "＋ Asociar OC";
            btnAsociarOC.UseVisualStyleBackColor = false;
            btnAsociarOC.Click += btnAsociarOC_Click;

            gridOCs.AllowUserToAddRows = false;
            gridOCs.AllowUserToDeleteRows = false;
            gridOCs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            gridOCs.BackgroundColor = System.Drawing.Color.White;
            gridOCs.ColumnHeadersDefaultCellStyle = estiloHeader;
            gridOCs.ColumnHeadersHeight = 28;
            gridOCs.RowHeadersVisible = false;
            gridOCs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            gridOCs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                colOCId, colOCFecha, colOCEstado, colOCEliminar
            });
            gridOCs.Location = new System.Drawing.Point(20, 195);
            gridOCs.Size = new System.Drawing.Size(840, 100);
            gridOCs.CellContentClick += gridOCs_CellContentClick;

            colOCId.HeaderText = "N° Pedido";
            colOCId.Name = "colOCId";
            colOCId.ReadOnly = true;
            colOCId.FillWeight = 15;

            colOCFecha.HeaderText = "Fecha";
            colOCFecha.Name = "colOCFecha";
            colOCFecha.ReadOnly = true;
            colOCFecha.FillWeight = 35;

            colOCEstado.HeaderText = "Estado";
            colOCEstado.Name = "colOCEstado";
            colOCEstado.ReadOnly = true;
            colOCEstado.FillWeight = 35;

            colOCEliminar.HeaderText = "";
            colOCEliminar.Name = "colOCEliminar";
            colOCEliminar.Text = "✕ Quitar";
            colOCEliminar.UseColumnTextForButtonValue = true;
            colOCEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            colOCEliminar.FillWeight = 15;

            // ── Grilla Productos ─────────────────────────────────────────
            lblProductos.AutoSize = true;
            lblProductos.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblProductos.Location = new System.Drawing.Point(20, 308);
            lblProductos.Text = "Productos (ingrese la cantidad recibida):";

            gridProductos.AllowUserToAddRows = false;
            gridProductos.AllowUserToDeleteRows = false;
            gridProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            gridProductos.BackgroundColor = System.Drawing.Color.White;
            gridProductos.ColumnHeadersDefaultCellStyle = estiloHeader;
            gridProductos.ColumnHeadersHeight = 28;
            gridProductos.RowHeadersVisible = false;
            gridProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            gridProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                colBarcode, colDetalle, colCantPedida, colCantRecibida, colDiferencia
            });
            gridProductos.Location = new System.Drawing.Point(20, 328);
            gridProductos.Size = new System.Drawing.Size(840, 200);
            gridProductos.CellValueChanged += gridProductos_CellValueChanged;
            gridProductos.CellEndEdit += gridProductos_CellEndEdit;

            colBarcode.HeaderText = "Código";
            colBarcode.Name = "colBarcode";
            colBarcode.ReadOnly = true;
            colBarcode.FillWeight = 12;

            colDetalle.HeaderText = "Producto";
            colDetalle.Name = "colDetalle";
            colDetalle.ReadOnly = true;
            colDetalle.FillWeight = 40;

            colCantPedida.HeaderText = "Cant. Pedida";
            colCantPedida.Name = "colCantPedida";
            colCantPedida.ReadOnly = true;
            colCantPedida.FillWeight = 14;

            colCantRecibida.HeaderText = "Cant. Recibida";
            colCantRecibida.Name = "colCantRecibida";
            colCantRecibida.ReadOnly = false;
            colCantRecibida.FillWeight = 14;

            colDiferencia.HeaderText = "Diferencia";
            colDiferencia.Name = "colDiferencia";
            colDiferencia.ReadOnly = true;
            colDiferencia.FillWeight = 14;

            // ── Resumen ──────────────────────────────────────────────────
            lblResumen.AutoSize = true;
            lblResumen.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblResumen.Location = new System.Drawing.Point(20, 540);
            lblResumen.Text = "";

            // ── Botones ──────────────────────────────────────────────────
            btnGuardar.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            btnGuardar.ForeColor = System.Drawing.Color.White;
            btnGuardar.Location = new System.Drawing.Point(640, 558);
            btnGuardar.Size = new System.Drawing.Size(110, 35);
            btnGuardar.Text = "💾 GUARDAR";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

            btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancelar.Location = new System.Drawing.Point(762, 558);
            btnCancelar.Size = new System.Drawing.Size(100, 35);
            btnCancelar.Text = "CANCELAR";
            btnCancelar.Click += btnCancelar_Click;

            // ── Form ─────────────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(880, 610);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SurFe - Recepción de Mercadería";
            Controls.AddRange(new System.Windows.Forms.Control[]
            {
                gridProductos, lblProductos,
                gridOCs, lblOC, btnAsociarOC,
                lblResumen, btnGuardar, btnCancelar,
                panelDatos, panelHeader
            });

            ((System.ComponentModel.ISupportInitialize)gridOCs).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridProductos).EndInit();
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
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Button btnBuscarProveedor;
        private System.Windows.Forms.Panel panelDatos;
        private System.Windows.Forms.Label lblNroRemito;
        private System.Windows.Forms.TextBox txtNroRemito;
        private System.Windows.Forms.Label lblFechaEntrada;
        private System.Windows.Forms.DateTimePicker dtpFechaEntrada;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label lblOC;
        private System.Windows.Forms.Button btnAsociarOC;
        private System.Windows.Forms.DataGridView gridOCs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOCId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOCFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOCEstado;
        private System.Windows.Forms.DataGridViewButtonColumn colOCEliminar;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.DataGridView gridProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantPedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantRecibida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiferencia;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}