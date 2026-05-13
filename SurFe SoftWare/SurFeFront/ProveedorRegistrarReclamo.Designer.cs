namespace SurFeFront
{
    partial class ProveedorRegistrarReclamo
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
            lblEtiquetaRemito = new System.Windows.Forms.Label();
            lblRemito = new System.Windows.Forms.Label();
            btnBuscarRemito = new System.Windows.Forms.Button();
            lblTipo = new System.Windows.Forms.Label();
            cmbTipo = new System.Windows.Forms.ComboBox();

            lblProductos = new System.Windows.Forms.Label();
            btnAgregarProducto = new System.Windows.Forms.Button();
            gridProductos = new System.Windows.Forms.DataGridView();
            colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCantRecibida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCantReclamar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colMotivoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colEliminar = new System.Windows.Forms.DataGridViewButtonColumn();

            lblMotivo = new System.Windows.Forms.Label();
            txtMotivo = new System.Windows.Forms.TextBox();

            btnGuardar = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();

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
            panelHeader.Size = new System.Drawing.Size(780, 85);

            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 122, 204);
            lblTitulo.Location = new System.Drawing.Point(12, 9);
            lblTitulo.Text = "Registrar Reclamo / Devolución";

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
            btnBuscarProveedor.Location = new System.Drawing.Point(380, 50);
            btnBuscarProveedor.Size = new System.Drawing.Size(150, 28);
            btnBuscarProveedor.Text = "🔍 Buscar Proveedor";
            btnBuscarProveedor.UseVisualStyleBackColor = false;
            btnBuscarProveedor.Click += btnBuscarProveedor_Click;

            // ── panelDatos ───────────────────────────────────────────────
            panelDatos.BackColor = System.Drawing.Color.FromArgb(230, 242, 255);
            panelDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelDatos.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblEtiquetaRemito, lblRemito, btnBuscarRemito, lblTipo, cmbTipo
            });
            panelDatos.Dock = System.Windows.Forms.DockStyle.Top;
            panelDatos.Location = new System.Drawing.Point(0, 85);
            panelDatos.Size = new System.Drawing.Size(780, 55);

            lblEtiquetaRemito.AutoSize = true;
            lblEtiquetaRemito.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblEtiquetaRemito.Location = new System.Drawing.Point(16, 10);
            lblEtiquetaRemito.Text = "Remito:";

            lblRemito.AutoSize = true;
            lblRemito.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            lblRemito.ForeColor = System.Drawing.Color.DimGray;
            lblRemito.Location = new System.Drawing.Point(68, 10);
            lblRemito.Text = "Sin remito asociado";

            btnBuscarRemito.BackColor = System.Drawing.Color.White;
            btnBuscarRemito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBuscarRemito.Location = new System.Drawing.Point(270, 5);
            btnBuscarRemito.Size = new System.Drawing.Size(130, 26);
            btnBuscarRemito.Text = "🔍 Buscar Remito";
            btnBuscarRemito.UseVisualStyleBackColor = false;
            btnBuscarRemito.Click += btnBuscarRemito_Click;

            lblTipo.AutoSize = true;
            lblTipo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblTipo.Location = new System.Drawing.Point(16, 32);
            lblTipo.Text = "Tipo:";

            cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbTipo.Location = new System.Drawing.Point(55, 29);
            cmbTipo.Size = new System.Drawing.Size(150, 23);
            cmbTipo.TabIndex = 0;

            // ── Grilla productos ─────────────────────────────────────────
            estiloHeader.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            estiloHeader.ForeColor = System.Drawing.Color.White;
            estiloHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);

            lblProductos.AutoSize = true;
            lblProductos.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblProductos.Location = new System.Drawing.Point(20, 155);
            lblProductos.Text = "Productos a reclamar:";

            btnAgregarProducto.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            btnAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAgregarProducto.ForeColor = System.Drawing.Color.White;
            btnAgregarProducto.Enabled = false;
            btnAgregarProducto.Location = new System.Drawing.Point(185, 150);
            btnAgregarProducto.Size = new System.Drawing.Size(140, 26);
            btnAgregarProducto.Text = "＋ Agregar Producto";
            btnAgregarProducto.UseVisualStyleBackColor = false;
            btnAgregarProducto.Click += btnAgregarProducto_Click;

            gridProductos.AllowUserToAddRows = false;
            gridProductos.AllowUserToDeleteRows = false;
            gridProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            gridProductos.BackgroundColor = System.Drawing.Color.White;
            gridProductos.ColumnHeadersDefaultCellStyle = estiloHeader;
            gridProductos.ColumnHeadersHeight = 30;
            gridProductos.RowHeadersVisible = false;
            gridProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            gridProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                colBarcode, colDetalle, colCantRecibida, colCantReclamar, colMotivoProducto, colEliminar
            });
            gridProductos.Location = new System.Drawing.Point(20, 180);
            gridProductos.Size = new System.Drawing.Size(740, 200);
            gridProductos.TabIndex = 1;
            gridProductos.CellContentClick += gridProductos_CellContentClick;

            colBarcode.HeaderText = "Código";
            colBarcode.Name = "colBarcode";
            colBarcode.ReadOnly = true;
            colBarcode.FillWeight = 10;

            colDetalle.HeaderText = "Producto";
            colDetalle.Name = "colDetalle";
            colDetalle.ReadOnly = true;
            colDetalle.FillWeight = 28;

            colCantRecibida.HeaderText = "Cant. Recibida";
            colCantRecibida.Name = "colCantRecibida";
            colCantRecibida.ReadOnly = true;
            colCantRecibida.FillWeight = 12;

            colCantReclamar.HeaderText = "Cant. Reclamar";
            colCantReclamar.Name = "colCantReclamar";
            colCantReclamar.ReadOnly = false;
            colCantReclamar.FillWeight = 12;

            colMotivoProducto.HeaderText = "Motivo del producto";
            colMotivoProducto.Name = "colMotivoProducto";
            colMotivoProducto.ReadOnly = false;
            colMotivoProducto.FillWeight = 28;

            colEliminar.HeaderText = "";
            colEliminar.Name = "colEliminar";
            colEliminar.Text = "✕ Quitar";
            colEliminar.UseColumnTextForButtonValue = true;
            colEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            colEliminar.FillWeight = 10;

            // ── Motivo general ───────────────────────────────────────────
            lblMotivo.AutoSize = true;
            lblMotivo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblMotivo.Location = new System.Drawing.Point(20, 392);
            lblMotivo.Text = "Motivo general (obligatorio):";

            txtMotivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtMotivo.Location = new System.Drawing.Point(20, 410);
            txtMotivo.Multiline = true;
            txtMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtMotivo.Size = new System.Drawing.Size(740, 70);
            txtMotivo.MaxLength = 500;
            txtMotivo.TabIndex = 2;

            // ── Botones ──────────────────────────────────────────────────
            btnGuardar.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            btnGuardar.ForeColor = System.Drawing.Color.White;
            btnGuardar.Location = new System.Drawing.Point(540, 496);
            btnGuardar.Size = new System.Drawing.Size(110, 35);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "💾 GUARDAR";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

            btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancelar.Location = new System.Drawing.Point(663, 496);
            btnCancelar.Size = new System.Drawing.Size(97, 35);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.Click += btnCancelar_Click;

            // ── Form ─────────────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(780, 548);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SurFe - Registrar Reclamo / Devolución";
            Controls.AddRange(new System.Windows.Forms.Control[]
            {
                gridProductos, lblProductos, btnAgregarProducto,
                lblMotivo, txtMotivo,
                btnGuardar, btnCancelar,
                panelDatos, panelHeader
            });

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
        private System.Windows.Forms.Label lblEtiquetaRemito;
        private System.Windows.Forms.Label lblRemito;
        private System.Windows.Forms.Button btnBuscarRemito;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;

        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.DataGridView gridProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantRecibida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantReclamar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMotivoProducto;
        private System.Windows.Forms.DataGridViewButtonColumn colEliminar;

        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}