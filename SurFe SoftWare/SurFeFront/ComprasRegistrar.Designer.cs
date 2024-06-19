namespace SurFeFront
{
    partial class ComprasRegistrar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(231, 40);
            label1.TabIndex = 0;
            label1.Text = "RegistrarCompra";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(12, 119);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 1;
            label2.Text = "Barcode:";
            label2.Click += label2_Click;
            // 
            // tbcantidad
            // 
            tbcantidad.Location = new Point(452, 115);
            tbcantidad.Name = "tbcantidad";
            tbcantidad.Size = new Size(100, 23);
            tbcantidad.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(391, 119);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 4;
            label3.Text = "Cantidad";
            // 
            // btnagregar
            // 
            btnagregar.Location = new Point(558, 114);
            btnagregar.Name = "btnagregar";
            btnagregar.Size = new Size(75, 23);
            btnagregar.TabIndex = 5;
            btnagregar.Text = "Agregar";
            btnagregar.UseVisualStyleBackColor = true;
            btnagregar.Click += btnagregar_Click;
            // 
            // btnbuscar
            // 
            btnbuscar.Location = new Point(639, 115);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(111, 23);
            btnbuscar.TabIndex = 6;
            btnbuscar.Text = "BuscarProducto";
            btnbuscar.UseVisualStyleBackColor = true;
            btnbuscar.Click += btnbuscar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Barcode, Detalle, Cantidad });
            dataGridView1.Location = new Point(21, 176);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(767, 231);
            dataGridView1.TabIndex = 7;
            // 
            // Barcode
            // 
            Barcode.HeaderText = "Barcode";
            Barcode.Name = "Barcode";
            // 
            // Detalle
            // 
            Detalle.HeaderText = "Detalle";
            Detalle.Name = "Detalle";
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.Name = "Cantidad";
            // 
            // btnguardar
            // 
            btnguardar.Location = new Point(614, 415);
            btnguardar.Name = "btnguardar";
            btnguardar.Size = new Size(75, 23);
            btnguardar.TabIndex = 8;
            btnguardar.Text = "Guardar";
            btnguardar.UseVisualStyleBackColor = true;
            btnguardar.Click += btnguardar_Click;
            // 
            // button1
            // 
            button1.Location = new Point(704, 415);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 9;
            button1.Text = "Cancelar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(12, 62);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 10;
            label4.Text = "Proveedor: ";
            // 
            // lbrazonsocial
            // 
            lbrazonsocial.AutoSize = true;
            lbrazonsocial.BackColor = Color.Transparent;
            lbrazonsocial.Location = new Point(86, 62);
            lbrazonsocial.Name = "lbrazonsocial";
            lbrazonsocial.Size = new Size(27, 15);
            lbrazonsocial.TabIndex = 11;
            lbrazonsocial.Text = "****";
            // 
            // btnbuscarproveedor
            // 
            btnbuscarproveedor.Location = new Point(243, 58);
            btnbuscarproveedor.Name = "btnbuscarproveedor";
            btnbuscarproveedor.Size = new Size(126, 23);
            btnbuscarproveedor.TabIndex = 12;
            btnbuscarproveedor.Text = "Buscar Proveedor";
            btnbuscarproveedor.UseVisualStyleBackColor = true;
            btnbuscarproveedor.Click += btnbuscarproveedor_Click;
            // 
            // lbbarcode
            // 
            lbbarcode.AutoSize = true;
            lbbarcode.BackColor = Color.Transparent;
            lbbarcode.Location = new Point(71, 119);
            lbbarcode.Name = "lbbarcode";
            lbbarcode.Size = new Size(22, 15);
            lbbarcode.TabIndex = 13;
            lbbarcode.Text = "***";
            // 
            // lbdetalle
            // 
            lbdetalle.AutoSize = true;
            lbdetalle.BackColor = Color.Transparent;
            lbdetalle.Location = new Point(182, 119);
            lbdetalle.Name = "lbdetalle";
            lbdetalle.Size = new Size(22, 15);
            lbdetalle.TabIndex = 14;
            lbdetalle.Text = "***";
            // 
            // ComprasRegistrar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.FONDO_REGISTRAR_COMPRA;
            ClientSize = new Size(800, 450);
            Controls.Add(lbdetalle);
            Controls.Add(lbbarcode);
            Controls.Add(btnbuscarproveedor);
            Controls.Add(lbrazonsocial);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(btnguardar);
            Controls.Add(dataGridView1);
            Controls.Add(btnbuscar);
            Controls.Add(btnagregar);
            Controls.Add(label3);
            Controls.Add(tbcantidad);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ComprasRegistrar";
            Text = "ProveedorRegistrarPedido";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
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
    }
}