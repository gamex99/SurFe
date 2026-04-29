namespace SurFeFront
{
    partial class SelectProducto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridView3 = new System.Windows.Forms.DataGridView();
            txtbuscarproducto = new System.Windows.Forms.TextBox();
            labelTitulo = new System.Windows.Forms.Label();
            labelInstruccion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // dataGridView3
            // 
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowUserToDeleteRows = false;
            dataGridView3.AllowUserToResizeRows = false;
            dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.BackgroundColor = System.Drawing.Color.White;
            dataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridView3.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView3.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView3.ColumnHeadersHeight = 35;
            dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(34, 197, 94); // Verde para productos
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridView3.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView3.EnableHeadersVisualStyles = false;
            dataGridView3.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            dataGridView3.Location = new System.Drawing.Point(18, 85);
            dataGridView3.MultiSelect = false;
            dataGridView3.Name = "dataGridView3";
            dataGridView3.ReadOnly = true;
            dataGridView3.RowHeadersVisible = false;
            dataGridView3.RowTemplate.Height = 35;
            dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.Size = new System.Drawing.Size(764, 215);
            dataGridView3.TabIndex = 2;
            dataGridView3.CellDoubleClick += dataGridView3_CellDoubleClick;
            // 
            // txtbuscarproducto
            // 
            txtbuscarproducto.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtbuscarproducto.Location = new System.Drawing.Point(18, 50);
            txtbuscarproducto.Name = "txtbuscarproducto";
            txtbuscarproducto.PlaceholderText = " Ingrese nombre del producto o código de barras...";
            txtbuscarproducto.Size = new System.Drawing.Size(550, 27);
            txtbuscarproducto.TabIndex = 1;
            txtbuscarproducto.TextChanged += txtbuscarproducto_TextChanged;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelTitulo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            labelTitulo.Location = new System.Drawing.Point(18, 20);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new System.Drawing.Size(155, 21);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "Catálogo de Artículos";
            // 
            // labelInstruccion
            // 
            labelInstruccion.AutoSize = true;
            labelInstruccion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            labelInstruccion.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            labelInstruccion.Location = new System.Drawing.Point(580, 58);
            labelInstruccion.Name = "labelInstruccion";
            labelInstruccion.Size = new System.Drawing.Size(202, 13);
            labelInstruccion.TabIndex = 3;
            labelInstruccion.Text = "Doble clic para añadir al carrito de venta";
            // 
            // SelectProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(800, 315);
            Controls.Add(labelInstruccion);
            Controls.Add(labelTitulo);
            Controls.Add(txtbuscarproducto);
            Controls.Add(dataGridView3);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SelectProducto";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "SurFe - Búsqueda de Productos";
            Load += SelectProductoVenta_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView3;
        private TextBox txtbuscarproducto;
        private Label labelTitulo;
        private Label labelInstruccion;
    }
}