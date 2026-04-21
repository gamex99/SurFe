namespace SurFeFront
{
    partial class FacturaCompraRegistrar
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnBuscarProv = new System.Windows.Forms.Button();
            this.lblProvSel = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblNro = new System.Windows.Forms.Label();
            this.txtNroFactura = new System.Windows.Forms.TextBox();
            this.lblFecE = new System.Windows.Forms.Label();
            this.dtpEmision = new System.Windows.Forms.DateTimePicker();
            this.lblFecV = new System.Windows.Forms.Label();
            this.dtpVencimiento = new System.Windows.Forms.DateTimePicker();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgvRemitosAsoc = new System.Windows.Forms.DataGridView();
            this.btnAsociarRemito = new System.Windows.Forms.Button();
            this.lblRemitos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemitosAsoc)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(262, 25);
            this.lblTitulo.Text = "Registrar Factura de Compra";
            // 
            // btnBuscarProv
            // 
            this.btnBuscarProv.Location = new System.Drawing.Point(16, 50);
            this.btnBuscarProv.Name = "btnBuscarProv";
            this.btnBuscarProv.Size = new System.Drawing.Size(150, 30);
            this.btnBuscarProv.TabIndex = 1;
            this.btnBuscarProv.Text = "🔍 Buscar Proveedor";
            this.btnBuscarProv.UseVisualStyleBackColor = true;
            this.btnBuscarProv.Click += new System.EventHandler(this.btnBuscarProv_Click);
            // 
            // lblProvSel
            // 
            this.lblProvSel.AutoSize = true;
            this.lblProvSel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblProvSel.Location = new System.Drawing.Point(180, 58);
            this.lblProvSel.Name = "lblProvSel";
            this.lblProvSel.Size = new System.Drawing.Size(161, 15);
            this.lblProvSel.Text = "Proveedor no seleccionado...";
            // 
            // lblTipo
            // 
            this.lblTipo.Location = new System.Drawing.Point(16, 100);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(110, 23);
            this.lblTipo.Text = "Tipo Comp:";
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Location = new System.Drawing.Point(120, 97);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(120, 23);
            // 
            // lblNro
            // 
            this.lblNro.Location = new System.Drawing.Point(260, 100);
            this.lblNro.Name = "lblNro";
            this.lblNro.Size = new System.Drawing.Size(80, 23);
            this.lblNro.Text = "Nro Factura:";
            // 
            // txtNroFactura
            // 
            this.txtNroFactura.Location = new System.Drawing.Point(340, 97);
            this.txtNroFactura.Name = "txtNroFactura";
            this.txtNroFactura.Size = new System.Drawing.Size(150, 23);
            // 
            // lblFecE
            // 
            this.lblFecE.Location = new System.Drawing.Point(16, 140);
            this.lblFecE.Name = "lblFecE";
            this.lblFecE.Size = new System.Drawing.Size(100, 23);
            this.lblFecE.Text = "F. Emisión:";
            // 
            // dtpEmision
            // 
            this.dtpEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEmision.Location = new System.Drawing.Point(120, 137);
            this.dtpEmision.Name = "dtpEmision";
            this.dtpEmision.Size = new System.Drawing.Size(120, 23);
            // 
            // lblFecV
            // 
            this.lblFecV.Location = new System.Drawing.Point(260, 140);
            this.lblFecV.Name = "lblFecV";
            this.lblFecV.Size = new System.Drawing.Size(80, 23);
            this.lblFecV.Text = "F. Venc:";
            // 
            // dtpVencimiento
            // 
            this.dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVencimiento.Location = new System.Drawing.Point(340, 137);
            this.dtpVencimiento.Name = "dtpVencimiento";
            this.dtpVencimiento.Size = new System.Drawing.Size(120, 23);
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(16, 185);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(140, 23);
            this.lblTotal.Text = "MONTO TOTAL ($):";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtTotal.Location = new System.Drawing.Point(160, 182);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(120, 27);
            // 
            // lblRemitos
            // 
            this.lblRemitos.AutoSize = true;
            this.lblRemitos.Location = new System.Drawing.Point(16, 230);
            this.lblRemitos.Name = "lblRemitos";
            this.lblRemitos.Size = new System.Drawing.Size(167, 15);
            this.lblRemitos.Text = "Asociar Remitos (Justificación):";
            // 
            // btnAsociarRemito
            // 
            this.btnAsociarRemito.Enabled = false;
            this.btnAsociarRemito.Location = new System.Drawing.Point(16, 250);
            this.btnAsociarRemito.Name = "btnAsociarRemito";
            this.btnAsociarRemito.Size = new System.Drawing.Size(120, 25);
            this.btnAsociarRemito.Text = "+ Añadir Remito";
            this.btnAsociarRemito.UseVisualStyleBackColor = true;
            this.btnAsociarRemito.Click += new System.EventHandler(this.btnAsociarRemito_Click);
            // 
            // dgvRemitosAsoc
            // 
            this.dgvRemitosAsoc.AllowUserToAddRows = false;
            this.dgvRemitosAsoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRemitosAsoc.BackgroundColor = System.Drawing.Color.White;
            this.dgvRemitosAsoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRemitosAsoc.Location = new System.Drawing.Point(16, 280);
            this.dgvRemitosAsoc.Name = "dgvRemitosAsoc";
            this.dgvRemitosAsoc.RowHeadersVisible = false;
            this.dgvRemitosAsoc.Size = new System.Drawing.Size(550, 110);
            this.dgvRemitosAsoc.TabIndex = 10;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(366, 400);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(200, 40);
            this.btnGuardar.Text = "REGISTRAR FACTURA";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FacturaCompraRegistrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 451);
            this.Controls.Add(this.dgvRemitosAsoc);
            this.Controls.Add(this.btnAsociarRemito);
            this.Controls.Add(this.lblRemitos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dtpVencimiento);
            this.Controls.Add(this.lblFecV);
            this.Controls.Add(this.dtpEmision);
            this.Controls.Add(this.lblFecE);
            this.Controls.Add(this.txtNroFactura);
            this.Controls.Add(this.lblNro);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblProvSel);
            this.Controls.Add(this.btnBuscarProv);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FacturaCompraRegistrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SurFe - Gestión de Facturas de Compra";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemitosAsoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnBuscarProv;
        private System.Windows.Forms.Label lblProvSel;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblNro;
        private System.Windows.Forms.TextBox txtNroFactura;
        private System.Windows.Forms.Label lblFecE;
        private System.Windows.Forms.DateTimePicker dtpEmision;
        private System.Windows.Forms.Label lblFecV;
        private System.Windows.Forms.DateTimePicker dtpVencimiento;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvRemitosAsoc;
        private System.Windows.Forms.Button btnAsociarRemito;
        private System.Windows.Forms.Label lblRemitos;
    }
}