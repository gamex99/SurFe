namespace SurFeFront
{
    partial class BusquedaFacturaCompra
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
            this.dgvBusqueda = new System.Windows.Forms.DataGridView();
            this.id_factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nro_factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razon_social = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblInstruccion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBusqueda
            // 
            this.dgvBusqueda.AllowUserToAddRows = false;
            this.dgvBusqueda.AllowUserToDeleteRows = false;
            this.dgvBusqueda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBusqueda.BackgroundColor = System.Drawing.Color.White;
            this.dgvBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBusqueda.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBusqueda.ColumnHeadersHeight = 30;
            this.dgvBusqueda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_factura,
            this.nro_factura,
            this.razon_social,
            this.total,
            this.id_proveedor});
            this.dgvBusqueda.EnableHeadersVisualStyles = false;
            this.dgvBusqueda.Location = new System.Drawing.Point(12, 45);
            this.dgvBusqueda.MultiSelect = false;
            this.dgvBusqueda.Name = "dgvBusqueda";
            this.dgvBusqueda.ReadOnly = true;
            this.dgvBusqueda.RowHeadersVisible = false;
            this.dgvBusqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBusqueda.Size = new System.Drawing.Size(560, 304);
            this.dgvBusqueda.TabIndex = 0;
            this.dgvBusqueda.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBusqueda_CellDoubleClick);
            // 
            // id_factura
            // 
            this.id_factura.HeaderText = "ID";
            this.id_factura.Name = "id_factura";
            this.id_factura.ReadOnly = true;
            this.id_factura.Visible = false;
            // 
            // nro_factura
            // 
            this.nro_factura.HeaderText = "Nro. Factura";
            this.nro_factura.Name = "nro_factura";
            this.nro_factura.ReadOnly = true;
            // 
            // razon_social
            // 
            this.razon_social.HeaderText = "Proveedor";
            this.razon_social.Name = "razon_social";
            this.razon_social.ReadOnly = true;
            // 
            // total
            // 
            this.total.HeaderText = "Total ($)";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // id_proveedor
            // 
            this.id_proveedor.HeaderText = "ID Prov";
            this.id_proveedor.Name = "id_proveedor";
            this.id_proveedor.ReadOnly = true;
            this.id_proveedor.Visible = false;
            // 
            // lblInstruccion
            // 
            this.lblInstruccion.AutoSize = true;
            this.lblInstruccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblInstruccion.Location = new System.Drawing.Point(12, 18);
            this.lblInstruccion.Name = "lblInstruccion";
            this.lblInstruccion.Size = new System.Drawing.Size(262, 15);
            this.lblInstruccion.TabIndex = 1;
            this.lblInstruccion.Text = "Doble clic sobre la factura para seleccionarla...";
            // 
            // BusquedaFacturaCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.lblInstruccion);
            this.Controls.Add(this.dgvBusqueda);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BusquedaFacturaCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SurFe - Buscar Facturas de Compra Disponibles";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqueda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBusqueda;
        private System.Windows.Forms.Label lblInstruccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn nro_factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn razon_social;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_proveedor;
    }
}