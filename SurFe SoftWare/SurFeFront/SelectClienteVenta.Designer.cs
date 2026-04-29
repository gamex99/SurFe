namespace SurFeFront
{
    partial class SelectClienteVenta
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
            dataGridView2 = new System.Windows.Forms.DataGridView();
            textBusquedaVenta = new System.Windows.Forms.TextBox();
            labelTitulo = new System.Windows.Forms.Label();
            labelInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToOrderColumns = true;
            // IMPORTANTE: Cambiamos a AllCells para que las columnas se estiren segun el texto
            dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.BackgroundColor = System.Drawing.Color.White;
            dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;

            // Estilo de Cabecera (Más grande y con color fuerte)
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView2.ColumnHeadersHeight = 40;
            dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Estilo de Celdas (Más espacio entre filas)
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5); // Margen interno para que no esten pegados
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridView2.DefaultCellStyle = dataGridViewCellStyle2;

            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            dataGridView2.Location = new System.Drawing.Point(12, 100);
            dataGridView2.MultiSelect = false;
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.RowTemplate.Height = 45; // Fila mas alta para mejor lectura
            dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new System.Drawing.Size(808, 250);
            dataGridView2.TabIndex = 0;
            dataGridView2.CellDoubleClick += dataGridView2_CellDoubleClick;
            // 
            // textBusquedaVenta
            // 
            textBusquedaVenta.Font = new System.Drawing.Font("Segoe UI", 12F);
            textBusquedaVenta.Location = new System.Drawing.Point(12, 55);
            textBusquedaVenta.Name = "textBusquedaVenta";
            textBusquedaVenta.Size = new System.Drawing.Size(500, 29);
            textBusquedaVenta.TabIndex = 1;
            textBusquedaVenta.TextChanged += textBusquedaVenta_TextChanged;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            labelTitulo.Location = new System.Drawing.Point(12, 15);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new System.Drawing.Size(179, 25);
            labelTitulo.TabIndex = 2;
            labelTitulo.Text = "Seleccionar Cliente";
            // 
            // labelInfo
            // 
            labelInfo.AutoSize = true;
            labelInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            labelInfo.ForeColor = System.Drawing.Color.Navy;
            labelInfo.Location = new System.Drawing.Point(530, 63);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new System.Drawing.Size(211, 15);
            labelInfo.TabIndex = 3;
            labelInfo.Text = "Doble clic en la fila para seleccionar";
            // 
            // SelectClienteVenta
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            ClientSize = new System.Drawing.Size(832, 365);
            Controls.Add(labelInfo);
            Controls.Add(labelTitulo);
            Controls.Add(textBusquedaVenta);
            Controls.Add(dataGridView2);
            Name = "SelectClienteVenta";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "SurFe - Búsqueda de Clientes";
            Load += SelectClienteVenta_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox textBusquedaVenta;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelInfo;
    }
}