namespace SurFeFront
{
    partial class GraficosAltaClientesMensualesMDI
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
            panelKpis = new System.Windows.Forms.Panel();
            panelGraficos = new System.Windows.Forms.Panel();   // contenedor de ambos gráficos
            panelGrafico = new System.Windows.Forms.Panel();
            panelTorta = new System.Windows.Forms.Panel();
            panelBottom = new System.Windows.Forms.Panel();

            lblTitulo = new System.Windows.Forms.Label();
            lblSubtitulo = new System.Windows.Forms.Label();
            lblRango = new System.Windows.Forms.Label();
            cboRango = new System.Windows.Forms.ComboBox();
            btnExportar = new System.Windows.Forms.Button();
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
            this.ClientSize = new System.Drawing.Size(1300, 820);
            this.Text = "Alta de Clientes — Análisis Mensual";
            this.MinimumSize = new System.Drawing.Size(1000, 700);

            // ════ PANEL TOP ════
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Height = 80;

            lblTitulo.Text = "Alta de Clientes";
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblTitulo.Location = new System.Drawing.Point(20, 12);
            lblTitulo.AutoSize = true;

            lblSubtitulo.Text = "Evolución mensual de nuevos registros";
            lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblSubtitulo.Location = new System.Drawing.Point(22, 46);
            lblSubtitulo.AutoSize = true;

            lblRango.Text = "Período:";
            lblRango.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblRango.Location = new System.Drawing.Point(620, 30);
            lblRango.AutoSize = true;

            cboRango.Items.AddRange(new object[] { "3 meses", "6 meses", "12 meses", "24 meses" });
            cboRango.SelectedIndex = 2;
            cboRango.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboRango.Font = new System.Drawing.Font("Segoe UI", 9F);
            cboRango.Location = new System.Drawing.Point(680, 27);
            cboRango.Width = 110;
            cboRango.SelectedIndexChanged += new System.EventHandler(cboRango_SelectedIndexChanged);

            btnExportar.Text = "⬇ PNG";
            btnExportar.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnExportar.Location = new System.Drawing.Point(810, 24);
            btnExportar.Size = new System.Drawing.Size(100, 32);
            btnExportar.Click += new System.EventHandler(btnExportar_Click);

            btnExportarPDF.Text = "⬇ PDF";
            btnExportarPDF.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnExportarPDF.Location = new System.Drawing.Point(920, 24);
            btnExportarPDF.Size = new System.Drawing.Size(100, 32);
            btnExportarPDF.Click += new System.EventHandler(btnExportarPDF_Click);

            panelTop.Controls.AddRange(new System.Windows.Forms.Control[]
                { lblTitulo, lblSubtitulo, lblRango, cboRango, btnExportar, btnExportarPDF });

            // ════ PANEL KPIs ════
            panelKpis.Dock = System.Windows.Forms.DockStyle.Top;
            panelKpis.Height = 90;

            void ConfigurarCard(System.Windows.Forms.Panel card, System.Windows.Forms.Label txtLbl,
                                 System.Windows.Forms.Label valLbl, string titulo, int x)
            {
                card.Size = new System.Drawing.Size(200, 68);
                card.Location = new System.Drawing.Point(x, 11);

                txtLbl.Text = titulo;
                txtLbl.Font = new System.Drawing.Font("Segoe UI", 8F);
                txtLbl.Location = new System.Drawing.Point(12, 8);
                txtLbl.AutoSize = true;

                valLbl.Text = "—";
                valLbl.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
                valLbl.Location = new System.Drawing.Point(12, 26);
                valLbl.AutoSize = true;

                card.Controls.Add(txtLbl);
                card.Controls.Add(valLbl);
                panelKpis.Controls.Add(card);
            }

            ConfigurarCard(cardTotal, lblTotalTxt, lblTotalVal, "TOTAL CLIENTES", 20);
            ConfigurarCard(cardPromedio, lblPromedioTxt, lblPromedioVal, "PROMEDIO MENSUAL", 240);
            ConfigurarCard(cardMaximo, lblMaximoTxt, lblMaximoVal, "MÁXIMO EN UN MES", 460);

            // ════ PANEL GRÁFICOS (Split izq/der) ════
            panelGraficos.Dock = System.Windows.Forms.DockStyle.Fill;

            panelGrafico.Dock = System.Windows.Forms.DockStyle.Left;
            panelGrafico.Width = 650;    // mitad izquierda — barras

            panelTorta.Dock = System.Windows.Forms.DockStyle.Fill;  // mitad derecha — torta

            panelGraficos.Controls.Add(panelTorta);
            panelGraficos.Controls.Add(panelGrafico);

            // ════ PANEL BOTTOM ════
            panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Height = 10;

            this.Controls.Add(panelGraficos);
            this.Controls.Add(panelBottom);
            this.Controls.Add(panelKpis);
            this.Controls.Add(panelTop);

            ResumeLayout(false);
        }

        // Controles
        private System.Windows.Forms.Panel panelTop, panelKpis, panelGraficos, panelGrafico, panelTorta, panelBottom;
        private System.Windows.Forms.Label lblTitulo, lblSubtitulo, lblRango;
        private System.Windows.Forms.ComboBox cboRango;
        private System.Windows.Forms.Button btnExportar, btnExportarPDF;
        private System.Windows.Forms.Panel cardTotal, cardPromedio, cardMaximo;
        private System.Windows.Forms.Label lblTotalTxt, lblTotalVal;
        private System.Windows.Forms.Label lblPromedioTxt, lblPromedioVal;
        private System.Windows.Forms.Label lblMaximoTxt, lblMaximoVal;
    }
}