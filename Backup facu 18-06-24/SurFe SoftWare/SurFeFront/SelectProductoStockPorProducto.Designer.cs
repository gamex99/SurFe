namespace SurFeFront
{
    partial class SelectProductoStockPorProducto
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
            dataGridView3 = new DataGridView();
            txtbuscarproducto = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // dataGridView3
            // 
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowUserToDeleteRows = false;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(18, 41);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.ReadOnly = true;
            dataGridView3.RowTemplate.Height = 25;
            dataGridView3.Size = new Size(770, 258);
            dataGridView3.TabIndex = 0;
            dataGridView3.CellDoubleClick += dataGridView3_CellDoubleClick;
            // 
            // txtbuscarproducto
            // 
            txtbuscarproducto.Location = new Point(18, 12);
            txtbuscarproducto.Name = "txtbuscarproducto";
            txtbuscarproducto.Size = new Size(653, 23);
            txtbuscarproducto.TabIndex = 1;
            txtbuscarproducto.TextChanged += txtbuscarproducto_TextChanged;
            // 
            // SelectProductoStockPorProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 315);
            Controls.Add(txtbuscarproducto);
            Controls.Add(dataGridView3);
            Name = "SelectProductoStockPorProducto";
            Text = "SelectProductoVenta";
            Load += SelectProductoVenta_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView3;
        private TextBox txtbuscarproducto;
    }
}