namespace SurFeFront
{
    partial class ProveedorRegistrarPedido
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
            label1 = new Label();
            tbcantidad = new TextBox();
            label3 = new Label();
            btnagregar = new Button();
            btnbuscar = new Button();
            dataGridView1 = new DataGridView();
            Barcode = new DataGridViewTextBoxColumn();
            Detalle = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            btnguardar = new Button();
            button1 = new Button();
            label4 = new Label();
            lbrazonsocial = new Label();
            btnbuscarproveedor = new Button();
            lbbarcode = new Label();
            lbdetalle = new Label();
            panelHeader = new Panel();
            panelBusquedaProd = new Panel();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelHeader.SuspendLayout();
            panelBusquedaProd.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader (Datos del Proveedor)
            // 
            panelHeader.BackColor = Color.FromArgb(240, 240, 240);
            panelHeader.Controls.Add(label1);
            panelHeader.Controls.Add(label4);
            panelHeader.Controls.Add(lbrazonsocial);
            panelHeader.Controls.Add(btnbuscarproveedor);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(800, 85);
            panelHeader.TabIndex = 15;
            // 
            // label1 (Título)
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(0, 122, 204);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(196, 32);
            label1.Text = "Registrar Pedido";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label4.Location = new Point(20, 55);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.Text = "Proveedor:";
            // 
            // lbrazonsocial
            // 
            lbrazonsocial.AutoSize = true;
            lbrazonsocial.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lbrazonsocial.Location = new Point(90, 53);
            lbrazonsocial.Name = "lbrazonsocial";
            lbrazonsocial.Size = new Size(160, 19);
            lbrazonsocial.Text = "Seleccione un proveedor...";
            // 
            // btnbuscarproveedor
            // 
            btnbuscarproveedor.BackColor = Color.White;
            btnbuscarproveedor.FlatStyle = FlatStyle.Flat;
            btnbuscarproveedor.Location = new Point(280, 50);
            btnbuscarproveedor.Name = "btnbuscarproveedor";
            btnbuscarproveedor.Size = new Size(140, 26);
            btnbuscarproveedor.Text = "🔍 Buscar Proveedor";
            btnbuscarproveedor.UseVisualStyleBackColor = false;
            btnbuscarproveedor.Click += btnbuscarproveedor_Click;
            // 
            // panelBusquedaProd (Datos del Producto)
            // 
            panelBusquedaProd.BackColor = Color.White;
            panelBusquedaProd.Controls.Add(label2);
            panelBusquedaProd.Controls.Add(lbbarcode);
            panelBusquedaProd.Controls.Add(lbdetalle);
            panelBusquedaProd.Controls.Add(label3);
            panelBusquedaProd.Controls.Add(tbcantidad);
            panelBusquedaProd.Controls.Add(btnbuscar);
            panelBusquedaProd.Controls.Add(btnagregar);
            panelBusquedaProd.Dock = DockStyle.Top;
            panelBusquedaProd.Location = new Point(0, 85);
            panelBusquedaProd.Name = "panelBusquedaProd";
            panelBusquedaProd.Size = new Size(800, 65);
            panelBusquedaProd.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label2.Location = new Point(20, 10);
            label2.Text = "Producto:";
            // 
            // lbbarcode
            // 
            lbbarcode.AutoSize = true;
            lbbarcode.ForeColor = Color.DimGray;
            lbbarcode.Location = new Point(20, 32);
            lbbarcode.Text = "Código";
            // 
            // lbdetalle
            // 
            lbdetalle.AutoSize = true;
            lbdetalle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lbdetalle.Location = new Point(130, 32);
            lbdetalle.Text = "Detalle del producto seleccionado";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(430, 10);
            label3.Text = "Cantidad:";
            // 
            // tbcantidad
            // 
            tbcantidad.BorderStyle = BorderStyle.FixedSingle;
            tbcantidad.Location = new Point(430, 30);
            tbcantidad.Name = "tbcantidad";
            tbcantidad.Size = new Size(80, 23);
            // 
            // btnbuscar
            // 
            btnbuscar.Location = new Point(530, 28);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(120, 26);
            btnbuscar.Text = "🔍 Buscar Producto";
            btnbuscar.Click += btnbuscar_Click;
            // 
            // btnagregar
            // 
            btnagregar.BackColor = Color.FromArgb(40, 167, 69);
            btnagregar.FlatStyle = FlatStyle.Flat;
            btnagregar.ForeColor = Color.White;
            btnagregar.Location = new Point(660, 28);
            btnagregar.Name = "btnagregar";
            btnagregar.Size = new Size(100, 26);
            btnagregar.Text = "✚ Agregar";
            btnagregar.UseVisualStyleBackColor = false;
            btnagregar.Click += btnagregar_Click;
            // 
            // dataGridView1 (Grilla de Pedido)
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 30;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Barcode, Detalle, Cantidad });
            dataGridView1.Location = new Point(20, 160);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(760, 240);
            dataGridView1.TabIndex = 7;
            // 
            // Barcode
            // 
            Barcode.HeaderText = "Código / Barcode";
            Barcode.Name = "Barcode";
            // 
            // Detalle
            // 
            Detalle.HeaderText = "Descripción del Producto";
            Detalle.Name = "Detalle";
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cant. Pedida";
            Cantidad.Name = "Cantidad";
            // 
            // btnguardar
            // 
            btnguardar.BackColor = Color.FromArgb(0, 122, 204);
            btnguardar.FlatStyle = FlatStyle.Flat;
            btnguardar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnguardar.ForeColor = Color.White;
            btnguardar.Location = new Point(560, 410);
            btnguardar.Name = "btnguardar";
            btnguardar.Size = new Size(100, 35);
            btnguardar.Text = "GUARDAR";
            btnguardar.Click += btnguardar_Click;
            // 
            // button1 (Cancelar)
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(680, 410);
            button1.Name = "button1";
            button1.Size = new Size(100, 35);
            button1.Text = "CANCELAR";
            button1.Click += button1_Click;
            // 
            // ProveedorRegistrarPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 460);
            Controls.Add(dataGridView1);
            Controls.Add(btnguardar);
            Controls.Add(button1);
            Controls.Add(panelBusquedaProd);
            Controls.Add(panelHeader);
            Name = "ProveedorRegistrarPedido";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SurFe - Registro de Pedido a Proveedor";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelBusquedaProd.ResumeLayout(false);
            panelBusquedaProd.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox tbcantidad;
        private Label label3;
        private Button btnagregar;
        private Button btnbuscar;
        private DataGridView dataGridView1;
        private Button btnguardar;
        private Button button1;
        private Label label4;
        private Label lbrazonsocial;
        private Button btnbuscarproveedor;
        private DataGridViewTextBoxColumn Barcode;
        private DataGridViewTextBoxColumn Detalle;
        private DataGridViewTextBoxColumn Cantidad;
        private Label lbbarcode;
        private Label lbdetalle;
        private Panel panelHeader;
        private Panel panelBusquedaProd;
        private Label label2;
    }
}