namespace SurFeFront
{
    partial class RegistrarStock
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
            dataGridView1 = new DataGridView();
            barcode = new DataGridViewTextBoxColumn();
            detalle = new DataGridViewTextBoxColumn();
            stockactual = new DataGridViewTextBoxColumn();
            nuevostock = new DataGridViewTextBoxColumn();
            button1 = new Button();
            btncerrar = new Button();
            btncargar = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { barcode, detalle, stockactual, nuevostock });
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
            dataGridView1.Size = new Size(776, 340);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellValidated += dataGridView1_CellValidated;
            // 
            // barcode
            // 
            barcode.FillWeight = 80F;
            barcode.HeaderText = "BarCode";
            barcode.Name = "barcode";
            barcode.ReadOnly = true;
            // 
            // detalle
            // 
            detalle.FillWeight = 150F;
            detalle.HeaderText = "Descripción del Producto";
            detalle.Name = "detalle";
            detalle.ReadOnly = true;
            // 
            // stockactual
            // 
            stockactual.FillWeight = 80F;
            stockactual.HeaderText = "Stock Actual";
            stockactual.Name = "stockactual";
            stockactual.ReadOnly = true;
            // 
            // nuevostock
            // 
            dataGridViewCellStyle3.BackColor = Color.FromArgb(255, 255, 192); // Fondo amarillento para indicar edición
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(0, 0, 192);
            nuevostock.DefaultCellStyle = dataGridViewCellStyle3;
            nuevostock.FillWeight = 80F;
            nuevostock.HeaderText = "Nuevo Stock";
            nuevostock.Name = "nuevostock";
            // 
            // button1 (Buscar)
            // 
            button1.BackColor = Color.FromArgb(240, 240, 240);
            button1.FlatAppearance.BorderColor = Color.Silver;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 9F);
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(150, 30);
            button1.TabIndex = 1;
            button1.Text = "🔍 Buscar Producto";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btncargar
            // 
            btncargar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btncargar.BackColor = Color.FromArgb(0, 122, 204);
            btncargar.FlatAppearance.BorderSize = 0;
            btncargar.FlatStyle = FlatStyle.Flat;
            btncargar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btncargar.ForeColor = Color.White;
            btncargar.Location = new Point(570, 405);
            btncargar.Name = "btncargar";
            btncargar.Size = new Size(100, 35);
            btncargar.TabIndex = 3;
            btncargar.Text = "Actualizar";
            btncargar.UseVisualStyleBackColor = false;
            btncargar.Click += btncargar_Click;
            // 
            // btncerrar
            // 
            btncerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btncerrar.BackColor = Color.FromArgb(240, 240, 240);
            btncerrar.FlatAppearance.BorderColor = Color.Silver;
            btncerrar.FlatStyle = FlatStyle.Flat;
            btncerrar.Font = new Font("Segoe UI", 9.75F);
            btncerrar.Location = new Point(688, 405);
            btncerrar.Name = "btncerrar";
            btncerrar.Size = new Size(100, 35);
            btncerrar.TabIndex = 2;
            btncerrar.Text = "Cancelar";
            btncerrar.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Italic", 8.25F);
            label1.ForeColor = Color.FromArgb(192, 0, 0);
            label1.Location = new Point(12, 415);
            label1.Name = "label1";
            label1.Size = new Size(393, 13);
            label1.TabIndex = 4;
            label1.Text = "⚠ Importante: El valor ingresado reemplazará el stock actual. No es suma/resta automática.";
            // 
            // RegistrarStock
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btncargar);
            Controls.Add(btncerrar);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Font = new Font("Segoe UI", 9.75F);
            Name = "RegistrarStock";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SurFe - Ajuste Manual de Stock";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private DataGridViewTextBoxColumn barcode;
        private DataGridViewTextBoxColumn detalle;
        private DataGridViewTextBoxColumn stockactual;
        private DataGridViewTextBoxColumn nuevostock;
        private Button btncerrar;
        private Button btncargar;
        private Label label1;
    }
}