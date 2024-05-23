namespace SurFeFront
{
    partial class ControlPorInventario
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
            cbcategorias.FormattingEnabled = true;
            cbcategorias.Location = new Point(12, 12);
            cbcategorias.Name = "cbcategorias";
            cbcategorias.Size = new Size(121, 23);
            cbcategorias.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(139, 12);
            button1.Name = "button1";
            button1.Size = new Size(159, 23);
            button1.TabIndex = 1;
            button1.Text = "Buscar Productos";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Detalle, StockActual, StockNuevo });
            dataGridView1.Location = new Point(12, 49);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(776, 365);
            dataGridView1.TabIndex = 2;
            // 
            // Column1
            // 
            Column1.HeaderText = "BarCode";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Detalle
            // 
            Detalle.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Detalle.HeaderText = "Detalle";
            Detalle.Name = "Detalle";
            Detalle.ReadOnly = true;
            // 
            // StockActual
            // 
            StockActual.HeaderText = "StockActual";
            StockActual.Name = "StockActual";
            StockActual.ReadOnly = true;
            // 
            // StockNuevo
            // 
            StockNuevo.HeaderText = "StockNuevo";
            StockNuevo.Name = "StockNuevo";
            // 
            // button2
            // 
            button2.Location = new Point(713, 420);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Salir";
            button2.UseVisualStyleBackColor = true;
            // 
            // Cargar
            // 
            Cargar.Location = new Point(632, 420);
            Cargar.Name = "Cargar";
            Cargar.Size = new Size(75, 23);
            Cargar.TabIndex = 4;
            Cargar.Text = "Cargar";
            Cargar.UseVisualStyleBackColor = true;
            Cargar.Click += Cargar_Click;
            // 
            // Listado
            // 
            Listado.Location = new Point(669, 12);
            Listado.Name = "Listado";
            Listado.Size = new Size(119, 23);
            Listado.TabIndex = 5;
            Listado.Text = "ImprimirListado";
            Listado.UseVisualStyleBackColor = true;
            Listado.Click += Listado_Click;
            // 
            // ControlPorInventario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Listado);
            Controls.Add(Cargar);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(cbcategorias);
            Name = "ControlPorInventario";
            Text = "ControlPorInventario";
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