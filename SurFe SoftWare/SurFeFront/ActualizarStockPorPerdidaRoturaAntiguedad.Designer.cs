namespace SurFeFront
{
    partial class ActualizarStockPorPerdidaRoturaAntiguedad
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            btnbuscar.BackColor = Color.FromArgb(240, 240, 240);
            btnbuscar.FlatAppearance.BorderColor = Color.Silver;
            btnbuscar.FlatStyle = FlatStyle.Flat;
            btnbuscar.Font = new Font("Segoe UI Semibold", 9F);
            btnbuscar.Location = new Point(12, 12);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(150, 32);
            btnbuscar.TabIndex = 0;
            btnbuscar.Text = "🔍 Buscar Producto";
            btnbuscar.UseVisualStyleBackColor = false;
            btnbuscar.Click += btnbuscar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { BarCode, Detalle, CantidadDeBaja, Motivo });
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
            dataGridView1.TabIndex = 1;
            // 
            // BarCode
            // 
            BarCode.FillWeight = 80F;
            BarCode.HeaderText = "BarCode";
            BarCode.Name = "BarCode";
            BarCode.ReadOnly = true;
            // 
            // Detalle
            // 
            Detalle.FillWeight = 150F;
            Detalle.HeaderText = "Descripción del Producto";
            Detalle.Name = "Detalle";
            Detalle.ReadOnly = true;
            // 
            // CantidadDeBaja
            // 
            dataGridViewCellStyle3.BackColor = Color.FromArgb(255, 245, 230); // Color crema suave para edición
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(192, 64, 0);
            CantidadDeBaja.DefaultCellStyle = dataGridViewCellStyle3;
            CantidadDeBaja.FillWeight = 70F;
            CantidadDeBaja.HeaderText = "Cantidad a Bajar";
            CantidadDeBaja.Name = "CantidadDeBaja";
            // 
            // Motivo
            // 
            dataGridViewCellStyle4.BackColor = Color.FromArgb(255, 245, 230);
            dataGridViewCellStyle4.Font = new Font("Segoe UI Italic", 9.75F);
            Motivo.DefaultCellStyle = dataGridViewCellStyle4;
            Motivo.FillWeight = 120F;
            Motivo.HeaderText = "Motivo de la Baja";
            Motivo.Name = "Motivo";
            // 
            // btncargar
            // 
            btncargar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btncargar.BackColor = Color.FromArgb(217, 83, 79); // Rojo/Naranja de advertencia
            btncargar.FlatAppearance.BorderSize = 0;
            btncargar.FlatStyle = FlatStyle.Flat;
            btncargar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btncargar.ForeColor = Color.White;
            btncargar.Location = new Point(570, 410);
            btncargar.Name = "btncargar";
            btncargar.Size = new Size(110, 32);
            btncargar.TabIndex = 2;
            btncargar.Text = "Procesar Baja";
            btncargar.UseVisualStyleBackColor = false;
            btncargar.Click += btncargar_Click;
            // 
            // btnsalir
            // 
            btnsalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnsalir.BackColor = Color.FromArgb(240, 240, 240);
            btnsalir.FlatAppearance.BorderColor = Color.Silver;
            btnsalir.FlatStyle = FlatStyle.Flat;
            btnsalir.Font = new Font("Segoe UI", 9.75F);
            btnsalir.Location = new Point(688, 410);
            btnsalir.Name = "btnsalir";
            btnsalir.Size = new Size(100, 32);
            btnsalir.TabIndex = 3;
            btnsalir.Text = "Cerrar";
            btnsalir.UseVisualStyleBackColor = false;
            // 
            // ActualizarStockPorPerdidaRoturaAntiguedad
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 455);
            Controls.Add(btnsalir);
            Controls.Add(btncargar);
            Controls.Add(dataGridView1);
            Controls.Add(btnbuscar);
            Font = new Font("Segoe UI", 9.75F);
            Name = "ActualizarStockPorPerdidaRoturaAntiguedad";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SurFe - Gestión de Bajas (Rotura / Pérdida / Antigüedad)";
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