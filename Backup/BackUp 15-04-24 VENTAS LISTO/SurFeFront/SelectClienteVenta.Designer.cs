namespace SurFeFront
{
    partial class SelectClienteVenta
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
            dataGridView2 = new DataGridView();
            textBusquedaVenta = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(12, 50);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(808, 233);
            dataGridView2.TabIndex = 0;
            dataGridView2.CellDoubleClick += dataGridView2_CellDoubleClick;
            // 
            // textBusquedaVenta
            // 
            textBusquedaVenta.Location = new Point(12, 21);
            textBusquedaVenta.Name = "textBusquedaVenta";
            textBusquedaVenta.Size = new Size(594, 23);
            textBusquedaVenta.TabIndex = 1;
            textBusquedaVenta.TextChanged += textBusquedaVenta_TextChanged;
            // 
            // SelectClienteVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 295);
            Controls.Add(textBusquedaVenta);
            Controls.Add(dataGridView2);
            Name = "SelectClienteVenta";
            Text = "SelectClienteVenta";
            Load += SelectClienteVenta_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView2;
        private TextBox textBusquedaVenta;
    }
}