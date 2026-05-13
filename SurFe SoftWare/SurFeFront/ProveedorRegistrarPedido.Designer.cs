namespace SurFeFront
{
    partial class ProveedorRegistrarPedido
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            lblTitulo = new Label();
            lblEtiquetaProveedor = new Label();
            lblRazonSocial = new Label();
            btnBuscarProveedor = new Button();
            panelProducto = new Panel();
            lblEtiquetaProducto = new Label();
            lblBarcode = new Label();
            lblDetalle = new Label();
            lblEtiquetaCantidad = new Label();
            tbCantidad = new TextBox();
            btnBuscarProducto = new Button();
            btnAgregar = new Button();
            gridPedido = new DataGridView();
            colBarcode = new DataGridViewTextBoxColumn();
            colDetalle = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            colEliminar = new DataGridViewButtonColumn();
            btnGuardar = new Button();
            btnCancelar = new Button();
            panelHeader.SuspendLayout();
            panelProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridPedido).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(240, 240, 240);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Controls.Add(lblEtiquetaProveedor);
            panelHeader.Controls.Add(lblRazonSocial);
            panelHeader.Controls.Add(btnBuscarProveedor);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(820, 85);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = Color.FromArgb(0, 122, 204);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(192, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registrar Pedido";
            // 
            // lblEtiquetaProveedor
            // 
            lblEtiquetaProveedor.AutoSize = true;
            lblEtiquetaProveedor.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblEtiquetaProveedor.Location = new Point(20, 55);
            lblEtiquetaProveedor.Name = "lblEtiquetaProveedor";
            lblEtiquetaProveedor.Size = new Size(64, 15);
            lblEtiquetaProveedor.TabIndex = 1;
            lblEtiquetaProveedor.Text = "Proveedor:";
            // 
            // lblRazonSocial
            // 
            lblRazonSocial.AutoSize = true;
            lblRazonSocial.Font = new Font("Segoe UI", 10F, FontStyle.Italic, GraphicsUnit.Point);
            lblRazonSocial.ForeColor = Color.DimGray;
            lblRazonSocial.Location = new Point(95, 53);
            lblRazonSocial.Name = "lblRazonSocial";
            lblRazonSocial.Size = new Size(169, 19);
            lblRazonSocial.TabIndex = 2;
            lblRazonSocial.Text = "Seleccione un proveedor...";
            // 
            // btnBuscarProveedor
            // 
            btnBuscarProveedor.BackColor = Color.White;
            btnBuscarProveedor.FlatStyle = FlatStyle.Flat;
            btnBuscarProveedor.Location = new Point(290, 49);
            btnBuscarProveedor.Name = "btnBuscarProveedor";
            btnBuscarProveedor.Size = new Size(150, 28);
            btnBuscarProveedor.TabIndex = 3;
            btnBuscarProveedor.Text = "🔍 Buscar Proveedor";
            btnBuscarProveedor.UseVisualStyleBackColor = false;
            btnBuscarProveedor.Click += btnBuscarProveedor_Click;
            // 
            // panelProducto
            // 
            panelProducto.BackColor = Color.White;
            panelProducto.BorderStyle = BorderStyle.FixedSingle;
            panelProducto.Controls.Add(lblEtiquetaProducto);
            panelProducto.Controls.Add(lblBarcode);
            panelProducto.Controls.Add(lblDetalle);
            panelProducto.Controls.Add(lblEtiquetaCantidad);
            panelProducto.Controls.Add(tbCantidad);
            panelProducto.Controls.Add(btnBuscarProducto);
            panelProducto.Controls.Add(btnAgregar);
            panelProducto.Dock = DockStyle.Top;
            panelProducto.Location = new Point(0, 85);
            panelProducto.Name = "panelProducto";
            panelProducto.Size = new Size(820, 70);
            panelProducto.TabIndex = 1;
            // 
            // lblEtiquetaProducto
            // 
            lblEtiquetaProducto.AutoSize = true;
            lblEtiquetaProducto.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblEtiquetaProducto.Location = new Point(20, 10);
            lblEtiquetaProducto.Name = "lblEtiquetaProducto";
            lblEtiquetaProducto.Size = new Size(59, 15);
            lblEtiquetaProducto.TabIndex = 0;
            lblEtiquetaProducto.Text = "Producto:";
            // 
            // lblBarcode
            // 
            lblBarcode.AutoSize = true;
            lblBarcode.ForeColor = Color.DimGray;
            lblBarcode.Location = new Point(20, 35);
            lblBarcode.Name = "lblBarcode";
            lblBarcode.Size = new Size(19, 15);
            lblBarcode.TabIndex = 1;
            lblBarcode.Text = "—";
            // 
            // lblDetalle
            // 
            lblDetalle.AutoSize = true;
            lblDetalle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblDetalle.Location = new Point(130, 35);
            lblDetalle.Name = "lblDetalle";
            lblDetalle.Size = new Size(142, 15);
            lblDetalle.TabIndex = 2;
            lblDetalle.Text = "Seleccione un producto...";
            // 
            // lblEtiquetaCantidad
            // 
            lblEtiquetaCantidad.AutoSize = true;
            lblEtiquetaCantidad.Location = new Point(450, 10);
            lblEtiquetaCantidad.Name = "lblEtiquetaCantidad";
            lblEtiquetaCantidad.Size = new Size(58, 15);
            lblEtiquetaCantidad.TabIndex = 3;
            lblEtiquetaCantidad.Text = "Cantidad:";
            // 
            // tbCantidad
            // 
            tbCantidad.BorderStyle = BorderStyle.FixedSingle;
            tbCantidad.Location = new Point(450, 32);
            tbCantidad.Name = "tbCantidad";
            tbCantidad.Size = new Size(70, 23);
            tbCantidad.TabIndex = 0;
            tbCantidad.KeyPress += tbCantidad_KeyPress;
            // 
            // btnBuscarProducto
            // 
            btnBuscarProducto.FlatStyle = FlatStyle.Flat;
            btnBuscarProducto.Location = new Point(535, 30);
            btnBuscarProducto.Name = "btnBuscarProducto";
            btnBuscarProducto.Size = new Size(130, 27);
            btnBuscarProducto.TabIndex = 1;
            btnBuscarProducto.Text = "🔍 Buscar Producto";
            btnBuscarProducto.Click += btnBuscarProducto_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(40, 167, 69);
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(680, 30);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(110, 27);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "✚ Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // gridPedido
            // 
            gridPedido.AllowUserToAddRows = false;
            gridPedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridPedido.BackgroundColor = Color.White;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            gridPedido.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridPedido.ColumnHeadersHeight = 32;
            gridPedido.Columns.AddRange(new DataGridViewColumn[] { colBarcode, colDetalle, colCantidad, colEliminar });
            gridPedido.Location = new Point(20, 170);
            gridPedido.Name = "gridPedido";
            gridPedido.RowHeadersVisible = false;
            gridPedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridPedido.Size = new Size(780, 260);
            gridPedido.TabIndex = 3;
            gridPedido.CellClick += gridPedido_CellClick;
            // 
            // colBarcode
            // 
            colBarcode.FillWeight = 15F;
            colBarcode.HeaderText = "Código";
            colBarcode.Name = "colBarcode";
            colBarcode.ReadOnly = true;
            // 
            // colDetalle
            // 
            colDetalle.FillWeight = 55F;
            colDetalle.HeaderText = "Descripción";
            colDetalle.Name = "colDetalle";
            colDetalle.ReadOnly = true;
            // 
            // colCantidad
            // 
            colCantidad.FillWeight = 15F;
            colCantidad.HeaderText = "Cant.";
            colCantidad.Name = "colCantidad";
            colCantidad.ReadOnly = true;
            // 
            // colEliminar
            // 
            colEliminar.FillWeight = 15F;
            colEliminar.FlatStyle = FlatStyle.Flat;
            colEliminar.HeaderText = "";
            colEliminar.Name = "colEliminar";
            colEliminar.Text = "✕ Quitar";
            colEliminar.UseColumnTextForButtonValue = true;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(0, 122, 204);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(570, 445);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(110, 35);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "💾 GUARDAR";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(695, 445);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(110, 35);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.Click += btnCancelar_Click;
            // 
            // ProveedorRegistrarPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(820, 500);
            Controls.Add(gridPedido);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Controls.Add(panelProducto);
            Controls.Add(panelHeader);
            Name = "ProveedorRegistrarPedido";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SurFe - Registrar Pedido a Proveedor";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelProducto.ResumeLayout(false);
            panelProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridPedido).EndInit();
            ResumeLayout(false);
        }

        #endregion

        // Controles
        private Panel panelHeader;
        private Label lblTitulo;
        private Label lblEtiquetaProveedor;
        private Label lblRazonSocial;
        private Button btnBuscarProveedor;

        private Panel panelProducto;
        private Label lblEtiquetaProducto;
        private Label lblBarcode;
        private Label lblDetalle;
        private Label lblEtiquetaCantidad;
        private TextBox tbCantidad;
        private Button btnBuscarProducto;
        private Button btnAgregar;

        private DataGridView gridPedido;
        private DataGridViewTextBoxColumn colBarcode;
        private DataGridViewTextBoxColumn colDetalle;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewButtonColumn colEliminar;

        private Button btnGuardar;
        private Button btnCancelar;
    }
}