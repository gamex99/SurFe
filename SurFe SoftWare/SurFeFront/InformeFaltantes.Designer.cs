namespace SurFeFront
{
    partial class InformeFaltantes
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
            label1 = new Label();
            textBox1 = new TextBox();
            btnmostrar = new Button();
            dataGridView1 = new DataGridView();
            btncerrar = new Button();
            btnimprimir = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(244, 19);
            label1.TabIndex = 0;
            label1.Text = "Mostrar productos con stock menor a:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10F);
            textBox1.Location = new Point(262, 13);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Ej: 5";
            textBox1.Size = new Size(80, 25);
            textBox1.TabIndex = 1;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // btnmostrar
            // 
            btnmostrar.BackColor = Color.FromArgb(0, 122, 204);
            btnmostrar.FlatAppearance.BorderSize = 0;
            btnmostrar.FlatStyle = FlatStyle.Flat;
            btnmostrar.Font = new Font("Segoe UI Semibold", 9F);
            btnmostrar.ForeColor = Color.White;
            btnmostrar.Location = new Point(348, 12);
            btnmostrar.Name = "btnmostrar";
            btnmostrar.Size = new Size(90, 27);
            btnmostrar.TabIndex = 2;
            btnmostrar.Text = "Filtrar";
            btnmostrar.UseVisualStyleBackColor = false;
            btnmostrar.Click += btnmostrar_Click;
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
            dataGridView1.Location = new Point(12, 50);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(776, 360);
            dataGridView1.TabIndex = 3;
            // 
            // btnimprimir
            // 
            btnimprimir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnimprimir.BackColor = Color.FromArgb(40, 167, 69);
            btnimprimir.FlatAppearance.BorderSize = 0;
            btnimprimir.FlatStyle = FlatStyle.Flat;
            btnimprimir.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnimprimir.ForeColor = Color.White;
            btnimprimir.Location = new Point(585, 416);
            btnimprimir.Name = "btnimprimir";
            btnimprimir.Size = new Size(110, 32);
            btnimprimir.TabIndex = 5;
            btnimprimir.Text = "🖨 Imprimir";
            btnimprimir.UseVisualStyleBackColor = false;
            btnimprimir.Click += btnimprimir_Click;
            // 
            // btncerrar
            // 
            btncerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btncerrar.BackColor = Color.FromArgb(240, 240, 240);
            btncerrar.FlatAppearance.BorderColor = Color.Silver;
            btncerrar.FlatStyle = FlatStyle.Flat;
            btncerrar.Font = new Font("Segoe UI", 9.75F);
            btncerrar.Location = new Point(701, 416);
            btncerrar.Name = "btncerrar";
            btncerrar.Size = new Size(90, 32);
            btncerrar.TabIndex = 4;
            btncerrar.Text = "Cerrar";
            btncerrar.UseVisualStyleBackColor = false;
            btncerrar.Click += button1_Click;
            // 
            // InformeFaltantes
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(803, 460);
            Controls.Add(btnimprimir);
            Controls.Add(btncerrar);
            Controls.Add(dataGridView1);
            Controls.Add(btnmostrar);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 9.75F);
            Name = "InformeFaltantes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SurFe - Informe de Stock Crítico";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button btnmostrar;
        private DataGridView dataGridView1;
        private Button btncerrar;
        private Button btnimprimir;
    }
}