namespace SurFeFront
{
    partial class ClienteMasVendido
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelTop = new System.Windows.Forms.Panel();
            panelFiltros = new System.Windows.Forms.Panel();
            panelKpis = new System.Windows.Forms.Panel();
            panelGrafico = new System.Windows.Forms.Panel();

            lblTitulo = new System.Windows.Forms.Label();
            lblSubtitulo = new System.Windows.Forms.Label();
            lblMes = new System.Windows.Forms.Label();
            lblAnio = new System.Windows.Forms.Label();
            lblTop = new System.Windows.Forms.Label();
            lblPeriodo = new System.Windows.Forms.Label();

            cmbMes = new System.Windows.Forms.ComboBox();
            cmbAnio = new System.Windows.Forms.ComboBox();
            cmbTop = new System.Windows.Forms.ComboBox();

            rbMensual = new System.Windows.Forms.RadioButton();
            rbAnual = new System.Windows.Forms.RadioButton();

            btnActualizar = new System.Windows.Forms.Button();
            btnExportarPDF = new System.Windows.Forms.Button();

            cardTotal = new System.Windows.Forms.Panel();
            cardPromedio = new System.Windows.Forms.Panel();
            cardMaximo = new System.Windows.Forms.Panel();

            lblTotalTxt = new System.Windows.Forms.Label();
            lblTotalVal = new System.Windows.Forms.Label();
            lblPromedioTxt = new System.Windows.Forms.Label();
            lblPromedioVal = new System.Windows.Forms.Label();
            lblMaximoTxt = new System.Windows.Forms.Label();
            lblMaximoVal = new System.Windows.Forms.Label();

            SuspendLayout();

            // ════ FORM ════
            this.ClientSize = new System.Drawing.Size(1160, 800);
            this.Text = "Ranking Top Clientes";
            this.MinimumSize = new System.Drawing.Size(900, 650);

            // ════ PANEL TOP ════
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Height = 75;

            lblTitulo.Text = "Ranking de Clientes";
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblTitulo.Location = new System.Drawing.Point(20, 10);
            lblTitulo.AutoSize = true;

            lblSubtitulo.Text = "Top clientes por monto facturado en el período";
            lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblSubtitulo.Location = new System.Drawing.Point(22, 44);
            lblSubtitulo.AutoSize = true;

            panelTop.Controls.AddRange(new System.Windows.Forms.Control[]
                { lblTitulo, lblSubtitulo });

            // ════ PANEL FILTROS ════
            panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            panelFiltros.Height = 55;

            lblPeriodo.Text = "Período:";
            lblPeriodo.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblPeriodo.Location = new System.Drawing.Point(20, 18);
            lblPeriodo.AutoSize = true;

            rbMensual.Text = "Mensual";
            rbMensual.Checked = true;
            rbMensual.Font = new System.Drawing.Font("Segoe UI", 9F);
            rbMensual.Location = new System.Drawing.Point(80, 16);
            rbMensual.AutoSize = true;

            rbAnual.Text = "Anual";
            rbAnual.Font = new System.Drawing.Font("Segoe UI", 9F);
            rbAnual.Location = new System.Drawing.Point(160, 16);
            rbAnual.AutoSize = true;

            lblMes.Text = "Mes:";
            lblMes.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblMes.Location = new System.Drawing.Point(230, 18);
            lblMes.AutoSize = true;

            cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbMes.Font = new System.Drawing.Font("Segoe UI", 9F);
            cmbMes.Location = new System.Drawing.Point(265, 14);
            cmbMes.Width = 140;

            lblAnio.Text = "Año:";
            lblAnio.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblAnio.Location = new System.Drawing.Point(420, 18);
            lblAnio.AutoSize = true;

            cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbAnio.Font = new System.Drawing.Font("Segoe UI", 9F);
            cmbAnio.Location = new System.Drawing.Point(455, 14);
            cmbAnio.Width = 90;

            lblTop.Text = "Mostrar:";
            lblTop.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblTop.Location = new System.Drawing.Point(565, 18);
            lblTop.AutoSize = true;

            cmbTop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbTop.Font = new System.Drawing.Font("Segoe UI", 9F);
            cmbTop.Location = new System.Drawing.Point(625, 14);
            cmbTop.Width = 90;

            btnActualizar.Text = "↻ Actualizar";
            btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnActualizar.Location = new System.Drawing.Point(735, 12);
            btnActualizar.Size = new System.Drawing.Size(110, 30);

            btnExportarPDF.Text = "⬇ PDF";
            btnExportarPDF.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnExportarPDF.Location = new System.Drawing.Point(858, 12);
            btnExportarPDF.Size = new System.Drawing.Size(90, 30);

            panelFiltros.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblPeriodo, rbMensual, rbAnual,
                lblMes, cmbMes, lblAnio, cmbAnio,
                lblTop, cmbTop, btnActualizar, btnExportarPDF
            });

            // ════ PANEL KPIs ════
            panelKpis.Dock = System.Windows.Forms.DockStyle.Top;
            panelKpis.Height = 85;

            void ConfigurarCard(System.Windows.Forms.Panel card,
                                 System.Windows.Forms.Label txtLbl,
                                 System.Windows.Forms.Label valLbl,
                                 string titulo, int x)
            {
                card.Size = new System.Drawing.Size(210, 65);
                card.Location = new System.Drawing.Point(x, 10);

                txtLbl.Text = titulo;
                txtLbl.Font = new System.Drawing.Font("Segoe UI", 7.5F);
                txtLbl.Location = new System.Drawing.Point(10, 8);
                txtLbl.AutoSize = true;

                valLbl.Text = "—";
                valLbl.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
                valLbl.Location = new System.Drawing.Point(10, 26);
                valLbl.AutoSize = true;

                card.Controls.Add(txtLbl);
                card.Controls.Add(valLbl);
                panelKpis.Controls.Add(card);
            }

            ConfigurarCard(cardTotal, lblTotalTxt, lblTotalVal, "TOTAL FACTURADO", 20);
            ConfigurarCard(cardPromedio, lblPromedioTxt, lblPromedioVal, "PROMEDIO CLIENTE", 250);
            ConfigurarCard(cardMaximo, lblMaximoTxt, lblMaximoVal, "CLIENTE TOP", 480);

            // ════ PANEL GRÁFICO ════
            panelGrafico.Dock = System.Windows.Forms.DockStyle.Fill;

            this.Controls.Add(panelGrafico);
            this.Controls.Add(panelKpis);
            this.Controls.Add(panelFiltros);
            this.Controls.Add(panelTop);

            ResumeLayout(false);
        }

        // Controles
        private System.Windows.Forms.Panel panelTop, panelFiltros, panelKpis, panelGrafico;
        private System.Windows.Forms.Label lblTitulo, lblSubtitulo, lblMes, lblAnio, lblTop, lblPeriodo;
        private System.Windows.Forms.ComboBox cmbMes, cmbAnio, cmbTop;
        private System.Windows.Forms.RadioButton rbMensual, rbAnual;
        private System.Windows.Forms.Button btnActualizar, btnExportarPDF;
        private System.Windows.Forms.Panel cardTotal, cardPromedio, cardMaximo;
        private System.Windows.Forms.Label lblTotalTxt, lblTotalVal;
        private System.Windows.Forms.Label lblPromedioTxt, lblPromedioVal;
        private System.Windows.Forms.Label lblMaximoTxt, lblMaximoVal;
    }
}