namespace SurFeFront
{
    partial class RegistrarStock
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
            dataGridView1 = new DataGridView();
            barcode = new DataGridViewTextBoxColumn();
            detalle = new DataGridViewTextBoxColumn();
            stockactual = new DataGridViewTextBoxColumn();
            nuevostock = new DataGridViewTextBoxColumn();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { barcode, detalle, stockactual, nuevostock });
            dataGridView1.Location = new Point(12, 41);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(776, 355);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellValidated += dataGridView1_CellValidated;
            // 
            // barcode
            // 
            barcode.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            barcode.HeaderText = "BarCode";
            barcode.Name = "barcode";
            barcode.ReadOnly = true;
            // 
            // detalle
            // 
            detalle.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            detalle.HeaderText = "Detalle";
            detalle.Name = "detalle";
            detalle.ReadOnly = true;
            // 
            // stockactual
            // 
            stockactual.HeaderText = "Stock Actual";
            stockactual.Name = "stockactual";
            stockactual.ReadOnly = true;
            // 
            // nuevostock
            // 
            nuevostock.HeaderText = "NuevoStock";
            nuevostock.Name = "nuevostock";
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(131, 23);
            button1.TabIndex = 1;
            button1.Text = "Buscar Producto";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // RegistrarStock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "RegistrarStock";
            Text = "RegistrarStock";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private DataGridViewTextBoxColumn barcode;
        private DataGridViewTextBoxColumn detalle;
        private DataGridViewTextBoxColumn stockactual;
        private DataGridViewTextBoxColumn nuevostock;
    }
}