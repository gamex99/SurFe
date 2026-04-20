namespace SurFeFront
{
    partial class ControlPorInventario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            cbcategorias = new ComboBox();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Detalle = new DataGridViewTextBoxColumn();
            StockActual = new DataGridViewTextBoxColumn();
            StockNuevo = new DataGridViewTextBoxColumn();
            button2 = new Button();
            Cargar = new Button();
            Listado = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // cbcategorias
            // 
            cbcategorias.DropDownStyle = ComboBoxStyle.DropDownList;
            cbcategorias.Font = new Font("Segoe UI", 10F);
            cbcategorias.FormattingEnabled = true;
            cbcategorias.Location = new Point(12, 15);
            cbcategorias.Name = "cbcategorias";
            cbcategorias.Size = new Size(180, 25);
            cbcategorias.TabIndex = 0;
            // 
            // button1 (Buscar)
            // 
            button1.BackColor = Color.FromArgb(240, 240, 240);
            button1.FlatAppearance.BorderColor = Color.Silver;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 9F);
            button1.Location = new Point(198, 14);
            button1.Name = "button1";
            button1.Size = new Size(130, 28);
            button1.TabIndex = 1;
            button1.Text = "🔍 Buscar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 35;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Detalle, StockActual, StockNuevo });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(230, 240, 250);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(235, 235, 235);
            dataGridView1.Location = new Point(12, 55);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.Size = new Size(776, 345);
            dataGridView1.TabIndex = 2;
            // 
            // Column1 (BarCode)
            // 
            Column1.FillWeight = 80F;
            Column1.HeaderText = "BarCode";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Detalle
            // 
            Detalle.FillWeight = 150F;
            Detalle.HeaderText = "Descripción del Producto";
            Detalle.Name = "Detalle";
            Detalle.ReadOnly = true;
            // 
            // StockActual (Sistema)
            // 
            StockActual.FillWeight = 80F;
            StockActual.HeaderText = "Stock Sistema";
            StockActual.Name = "StockActual";
            StockActual.ReadOnly = true;
            // 
            // StockNuevo (Contado)
            // 
            dataGridViewCellStyle3.BackColor = Color.FromArgb(255, 255, 192); // Amarillo suave de edición
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.Navy;
            StockNuevo.DefaultCellStyle = dataGridViewCellStyle3;
            StockNuevo.FillWeight = 80F;
            StockNuevo.HeaderText = "Stock Real (Físico)";
            StockNuevo.Name = "StockNuevo";
            // 
            // Cargar
            // 
            Cargar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Cargar.BackColor = Color.FromArgb(0, 122, 204);
            Cargar.FlatAppearance.BorderSize = 0;
            Cargar.FlatStyle = FlatStyle.Flat;
            Cargar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            Cargar.ForeColor = Color.White;
            Cargar.Location = new Point(570, 410);
            Cargar.Name = "Cargar";
            Cargar.Size = new Size(110, 32);
            Cargar.TabIndex = 4;
            Cargar.Text = "Ajustar Stock";
            Cargar.UseVisualStyleBackColor = false;
            Cargar.Click += Cargar_Click;
            // 
            // button2 (Salir)
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.BackColor = Color.FromArgb(240, 240, 240);
            button2.FlatAppearance.BorderColor = Color.Silver;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9.75F);
            button2.Location = new Point(688, 410);
            button2.Name = "button2";
            button2.Size = new Size(100, 32);
            button2.TabIndex = 3;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = false;
            // 
            // Listado (Imprimir)
            // 
            Listado.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Listado.BackColor = Color.FromArgb(240, 240, 240);
            Listado.FlatAppearance.BorderColor = Color.Silver;
            Listado.FlatStyle = FlatStyle.Flat;
            Listado.Font = new Font("Segoe UI Semibold", 9F);
            Listado.Location = new Point(640, 14);
            Listado.Name = "Listado";
            Listado.Size = new Size(148, 28);
            Listado.TabIndex = 5;
            Listado.Text = "🖨 Imprimir para Conteo";
            Listado.UseVisualStyleBackColor = false;
            Listado.Click += Listado_Click;
            // 
            // ControlPorInventario
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 455);
            Controls.Add(Listado);
            Controls.Add(Cargar);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(cbcategorias);
            Font = new Font("Segoe UI", 9.75F);
            Name = "ControlPorInventario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SurFe - Toma de Inventario General";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cbcategorias;
        private Button button1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Detalle;
        private DataGridViewTextBoxColumn StockActual;
        private DataGridViewTextBoxColumn StockNuevo;
        private Button button2;
        private Button Cargar;
        private Button Listado;
    }
}