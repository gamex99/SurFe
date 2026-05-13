namespace SurFeFront
{
    partial class FacturaPagoRegistrar
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
            panelHeader = new System.Windows.Forms.Panel();
            lblTitulo = new System.Windows.Forms.Label();
            lblSubtitulo = new System.Windows.Forms.Label();

            panelDatos = new System.Windows.Forms.Panel();
            lblEtiquetaProv = new System.Windows.Forms.Label();
            lblProveedor = new System.Windows.Forms.Label();
            lblEtiquetaFactura = new System.Windows.Forms.Label();
            lblFactura = new System.Windows.Forms.Label();
            lblEtiquetaMonto = new System.Windows.Forms.Label();
            lblMonto = new System.Windows.Forms.Label();
            btnBuscarFactura = new System.Windows.Forms.Button();

            panelPago = new System.Windows.Forms.Panel();
            lblFechaPago = new System.Windows.Forms.Label();
            dtpFechaPago = new System.Windows.Forms.DateTimePicker();
            lblMontoPago = new System.Windows.Forms.Label();
            txtMonto = new System.Windows.Forms.TextBox();
            lblMedioPago = new System.Windows.Forms.Label();
            cmbMedioPago = new System.Windows.Forms.ComboBox();
            lblObservaciones = new System.Windows.Forms.Label();
            txtObservaciones = new System.Windows.Forms.TextBox();

            btnConfirmar = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();

            panelHeader.SuspendLayout();
            panelDatos.SuspendLayout();
            panelPago.SuspendLayout();
            SuspendLayout();

            // ── panelHeader ──────────────────────────────────────────────
            panelHeader.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            panelHeader.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblTitulo, lblSubtitulo
            });
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Size = new System.Drawing.Size(480, 72);
            panelHeader.TabIndex = 0;

            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 122, 204);
            lblTitulo.Location = new System.Drawing.Point(12, 10);
            lblTitulo.Text = "Registrar Pago";

            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            lblSubtitulo.ForeColor = System.Drawing.Color.DimGray;
            lblSubtitulo.Location = new System.Drawing.Point(14, 46);
            lblSubtitulo.Text = "Complete los datos del pago para esta factura.";

            // ── panelDatos (info de la factura, solo lectura) ────────────
            panelDatos.BackColor = System.Drawing.Color.FromArgb(230, 242, 255);
            panelDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelDatos.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblEtiquetaProv, lblProveedor,
                lblEtiquetaFactura, lblFactura,
                lblEtiquetaMonto, lblMonto,
                btnBuscarFactura
            });
            panelDatos.Dock = System.Windows.Forms.DockStyle.Top;
            panelDatos.Location = new System.Drawing.Point(0, 72);
            panelDatos.Size = new System.Drawing.Size(480, 90);
            panelDatos.TabIndex = 1;

            lblEtiquetaProv.AutoSize = true;
            lblEtiquetaProv.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblEtiquetaProv.Location = new System.Drawing.Point(16, 14);
            lblEtiquetaProv.Text = "Proveedor:";

            lblProveedor.AutoSize = true;
            lblProveedor.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblProveedor.Location = new System.Drawing.Point(100, 14);
            lblProveedor.Text = "—";

            lblEtiquetaFactura.AutoSize = true;
            lblEtiquetaFactura.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblEtiquetaFactura.Location = new System.Drawing.Point(16, 38);
            lblEtiquetaFactura.Text = "N° Factura:";

            lblFactura.AutoSize = true;
            lblFactura.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblFactura.Location = new System.Drawing.Point(100, 38);
            lblFactura.Text = "—";

            lblEtiquetaMonto.AutoSize = true;
            lblEtiquetaMonto.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblEtiquetaMonto.Location = new System.Drawing.Point(16, 62);
            lblEtiquetaMonto.Text = "Monto factura:";

            lblMonto.AutoSize = true;
            lblMonto.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            lblMonto.ForeColor = System.Drawing.Color.FromArgb(0, 122, 204);
            lblMonto.Location = new System.Drawing.Point(110, 60);
            lblMonto.Text = "$ 0,00";

            btnBuscarFactura.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            btnBuscarFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBuscarFactura.ForeColor = System.Drawing.Color.White;
            btnBuscarFactura.Location = new System.Drawing.Point(300, 14);
            btnBuscarFactura.Size = new System.Drawing.Size(150, 28);
            btnBuscarFactura.Text = "🔍 Buscar Factura";
            btnBuscarFactura.UseVisualStyleBackColor = false;
            btnBuscarFactura.Click += btnBuscarFactura_Click;

            // ── panelPago ────────────────────────────────────────────────
            panelPago.BackColor = System.Drawing.Color.White;
            panelPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelPago.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblFechaPago, dtpFechaPago,
                lblMontoPago, txtMonto,
                lblMedioPago, cmbMedioPago,
                lblObservaciones, txtObservaciones
            });
            panelPago.Dock = System.Windows.Forms.DockStyle.Top;
            panelPago.Location = new System.Drawing.Point(0, 162);
            panelPago.Size = new System.Drawing.Size(480, 175);
            panelPago.TabIndex = 2;

            lblFechaPago.AutoSize = true;
            lblFechaPago.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblFechaPago.Location = new System.Drawing.Point(16, 16);
            lblFechaPago.Text = "Fecha de pago:";

            dtpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpFechaPago.Location = new System.Drawing.Point(130, 13);
            dtpFechaPago.Size = new System.Drawing.Size(130, 23);
            dtpFechaPago.TabIndex = 0;

            lblMontoPago.AutoSize = true;
            lblMontoPago.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblMontoPago.Location = new System.Drawing.Point(16, 52);
            lblMontoPago.Text = "Monto a pagar ($):";

            txtMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtMonto.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            txtMonto.Location = new System.Drawing.Point(150, 49);
            txtMonto.Size = new System.Drawing.Size(130, 27);
            txtMonto.TabIndex = 1;
            txtMonto.KeyPress += txtMonto_KeyPress;

            lblMedioPago.AutoSize = true;
            lblMedioPago.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblMedioPago.Location = new System.Drawing.Point(16, 92);
            lblMedioPago.Text = "Medio de pago:";

            cmbMedioPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbMedioPago.Location = new System.Drawing.Point(130, 89);
            cmbMedioPago.Size = new System.Drawing.Size(160, 23);
            cmbMedioPago.TabIndex = 2;

            lblObservaciones.AutoSize = true;
            lblObservaciones.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblObservaciones.Location = new System.Drawing.Point(16, 128);
            lblObservaciones.Text = "Observaciones:";

            txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtObservaciones.Location = new System.Drawing.Point(130, 125);
            txtObservaciones.Size = new System.Drawing.Size(320, 23);
            txtObservaciones.TabIndex = 3;
            txtObservaciones.MaxLength = 255;

            // ── Botones ──────────────────────────────────────────────────
            btnConfirmar.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnConfirmar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            btnConfirmar.ForeColor = System.Drawing.Color.White;
            btnConfirmar.Location = new System.Drawing.Point(240, 352);
            btnConfirmar.Size = new System.Drawing.Size(120, 36);
            btnConfirmar.TabIndex = 3;
            btnConfirmar.Text = "💳 CONFIRMAR";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;

            btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancelar.Location = new System.Drawing.Point(375, 352);
            btnCancelar.Size = new System.Drawing.Size(90, 36);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.Click += btnCancelar_Click;

            // ── Form ─────────────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(480, 405);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "SurFe - Registrar Pago";
            Controls.AddRange(new System.Windows.Forms.Control[]
            {
                btnConfirmar, btnCancelar, panelPago, panelDatos, panelHeader
            });

            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelDatos.ResumeLayout(false);
            panelDatos.PerformLayout();
            panelPago.ResumeLayout(false);
            panelPago.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;

        private System.Windows.Forms.Panel panelDatos;
        private System.Windows.Forms.Label lblEtiquetaProv;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label lblEtiquetaFactura;
        private System.Windows.Forms.Label lblFactura;
        private System.Windows.Forms.Label lblEtiquetaMonto;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Button btnBuscarFactura;

        private System.Windows.Forms.Panel panelPago;
        private System.Windows.Forms.Label lblFechaPago;
        private System.Windows.Forms.DateTimePicker dtpFechaPago;
        private System.Windows.Forms.Label lblMontoPago;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label lblMedioPago;
        private System.Windows.Forms.ComboBox cmbMedioPago;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;

        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
    }
}