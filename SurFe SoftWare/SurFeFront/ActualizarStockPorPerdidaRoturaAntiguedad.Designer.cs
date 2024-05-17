namespace SurFeFront
{
    partial class ActualizarStockPorPerdidaRoturaAntiguedad
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
            btnbuscar = new Button();
            dataGridView1 = new DataGridView();
            BarCode = new DataGridViewTextBoxColumn();
            Detalle = new DataGridViewTextBoxColumn();
            CantidadDeBaja = new DataGridViewTextBoxColumn();
            Motivo = new DataGridViewTextBoxColumn();
            btncargar = new Button();
            btnsalir = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnbuscar
            // 
            btnbuscar.Location = new Point(12, 12);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(117, 23);
            btnbuscar.TabIndex = 0;
            btnbuscar.Text = "Buscar Producto";
            btnbuscar.UseVisualStyleBackColor = true;
            btnbuscar.Click += btnbuscar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { BarCode, Detalle, CantidadDeBaja, Motivo });
            dataGridView1.Location = new Point(6, 51);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(782, 359);
            dataGridView1.TabIndex = 1;
            // 
            // BarCode
            // 
            BarCode.HeaderText = "BarCode";
            BarCode.Name = "BarCode";
            BarCode.ReadOnly = true;
            // 
            // Detalle
            // 
            Detalle.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Detalle.HeaderText = "Detalle";
            Detalle.Name = "Detalle";
            Detalle.ReadOnly = true;
            // 
            // CantidadDeBaja
            // 
            CantidadDeBaja.HeaderText = "CantidadDeBaja";
            CantidadDeBaja.Name = "CantidadDeBaja";
            // 
            // Motivo
            // 
            Motivo.HeaderText = "Motivo";
            Motivo.Name = "Motivo";
            Motivo.Width = 200;
            // 
            // btncargar
            // 
            btncargar.Location = new Point(632, 419);
            btncargar.Name = "btncargar";
            btncargar.Size = new Size(75, 23);
            btncargar.TabIndex = 2;
            btncargar.Text = "Cargar";
            btncargar.UseVisualStyleBackColor = true;
            btncargar.Click += btncargar_Click;
            // 
            // btnsalir
            // 
            btnsalir.Location = new Point(713, 419);
            btnsalir.Name = "btnsalir";
            btnsalir.Size = new Size(75, 23);
            btnsalir.TabIndex = 3;
            btnsalir.Text = "Cerrar";
            btnsalir.UseVisualStyleBackColor = true;
            // 
            // ActualizarStockPorPerdidaRoturaAntiguedad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnsalir);
            Controls.Add(btncargar);
            Controls.Add(dataGridView1);
            Controls.Add(btnbuscar);
            Name = "ActualizarStockPorPerdidaRoturaAntiguedad";
            Text = "ActualizarStockPorPerdidaRoturaAntiguedad";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnbuscar;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn BarCode;
        private DataGridViewTextBoxColumn Detalle;
        private DataGridViewTextBoxColumn CantidadDeBaja;
        private DataGridViewTextBoxColumn Motivo;
        private Button btncargar;
        private Button btnsalir;
    }
}