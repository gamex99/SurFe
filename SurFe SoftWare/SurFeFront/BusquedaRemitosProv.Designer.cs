namespace SurFeFront
{
    partial class BusquedaRemitosProv
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.dgvRemitos = new System.Windows.Forms.DataGridView();
            this.lblInstruccion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemitos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRemitos
            // 
            this.dgvRemitos.AllowUserToAddRows = false;
            this.dgvRemitos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRemitos.BackgroundColor = System.Drawing.Color.White;
            this.dgvRemitos.ColumnHeadersHeight = 30;
            this.dgvRemitos.Location = new System.Drawing.Point(12, 40);
            this.dgvRemitos.Name = "dgvRemitos";
            this.dgvRemitos.ReadOnly = true;
            this.dgvRemitos.RowHeadersVisible = false;
            this.dgvRemitos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRemitos.Size = new System.Drawing.Size(460, 260);
            this.dgvRemitos.TabIndex = 0;
            this.dgvRemitos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRemitos_CellDoubleClick);
            // 
            // lblInstruccion
            // 
            this.lblInstruccion.AutoSize = true;
            this.lblInstruccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblInstruccion.Location = new System.Drawing.Point(12, 15);
            this.lblInstruccion.Name = "lblInstruccion";
            this.lblInstruccion.Size = new System.Drawing.Size(262, 15);
            this.lblInstruccion.TabIndex = 1;
            this.lblInstruccion.Text = "Doble clic para seleccionar el remito a asociar...";
            // 
            // BusquedaRemitosProv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.lblInstruccion);
            this.Controls.Add(this.dgvRemitos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BusquedaRemitosProv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SurFe - Buscar Remitos de Entrada";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemitos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.DataGridView dgvRemitos;
        private System.Windows.Forms.Label lblInstruccion;
    }
}