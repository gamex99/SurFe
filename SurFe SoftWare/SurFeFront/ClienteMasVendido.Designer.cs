namespace SurFeFront
{
    partial class ClienteMasVendido
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
            panel1 = new System.Windows.Forms.Panel();
            groupBoxFiltros = new System.Windows.Forms.GroupBox();
            btnActualizar = new System.Windows.Forms.Button();
            rbAnual = new System.Windows.Forms.RadioButton();
            rbMensual = new System.Windows.Forms.RadioButton();
            lblAnio = new System.Windows.Forms.Label();
            lblMes = new System.Windows.Forms.Label();
            cmbAnio = new System.Windows.Forms.ComboBox();
            cmbMes = new System.Windows.Forms.ComboBox();
            groupBoxFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.Location = new System.Drawing.Point(12, 85);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(913, 506);
            panel1.TabIndex = 0;
            // 
            // groupBoxFiltros
            // 
            groupBoxFiltros.Controls.Add(btnActualizar);
            groupBoxFiltros.Controls.Add(rbAnual);
            groupBoxFiltros.Controls.Add(rbMensual);
            groupBoxFiltros.Controls.Add(lblAnio);
            groupBoxFiltros.Controls.Add(lblMes);
            groupBoxFiltros.Controls.Add(cmbAnio);
            groupBoxFiltros.Controls.Add(cmbMes);
            groupBoxFiltros.Location = new System.Drawing.Point(12, 12);
            groupBoxFiltros.Name = "groupBoxFiltros";
            groupBoxFiltros.Size = new System.Drawing.Size(913, 67);
            groupBoxFiltros.TabIndex = 1;
            groupBoxFiltros.TabStop = false;
            groupBoxFiltros.Text = "Filtros de Período";
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            btnActualizar.ForeColor = System.Drawing.Color.White;
            btnActualizar.Location = new System.Drawing.Point(670, 22);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new System.Drawing.Size(125, 33);
            btnActualizar.TabIndex = 6;
            btnActualizar.Text = "Actualizar Reporte";
            btnActualizar.UseVisualStyleBackColor = false;
            // 
            // rbAnual
            // 
            rbAnual.AutoSize = true;
            rbAnual.Location = new System.Drawing.Point(111, 29);
            rbAnual.Name = "rbAnual";
            rbAnual.Size = new System.Drawing.Size(56, 19);
            rbAnual.TabIndex = 5;
            rbAnual.Text = "Anual";
            rbAnual.UseVisualStyleBackColor = true;
            // 
            // rbMensual
            // 
            rbMensual.AutoSize = true;
            rbMensual.Checked = true;
            rbMensual.Location = new System.Drawing.Point(21, 29);
            rbMensual.Name = "rbMensual";
            rbMensual.Size = new System.Drawing.Size(70, 19);
            rbMensual.TabIndex = 4;
            rbMensual.TabStop = true;
            rbMensual.Text = "Mensual";
            rbMensual.UseVisualStyleBackColor = true;
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Location = new System.Drawing.Point(460, 31);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new System.Drawing.Size(32, 15);
            lblAnio.TabIndex = 3;
            lblAnio.Text = "Año:";
            // 
            // lblMes
            // 
            lblMes.AutoSize = true;
            lblMes.Location = new System.Drawing.Point(220, 31);
            lblMes.Name = "lblMes";
            lblMes.Size = new System.Drawing.Size(32, 15);
            lblMes.TabIndex = 2;
            lblMes.Text = "Mes:";
            // 
            // cmbAnio
            // 
            cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbAnio.FormattingEnabled = true;
            cmbAnio.Location = new System.Drawing.Point(498, 27);
            cmbAnio.Name = "cmbAnio";
            cmbAnio.Size = new System.Drawing.Size(121, 23);
            cmbAnio.TabIndex = 1;
            // 
            // cmbMes
            // 
            cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbMes.FormattingEnabled = true;
            cmbMes.Location = new System.Drawing.Point(258, 27);
            cmbMes.Name = "cmbMes";
            cmbMes.Size = new System.Drawing.Size(160, 23);
            cmbMes.TabIndex = 0;
            // 
            // ClienteMasVendido
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(937, 603);
            Controls.Add(groupBoxFiltros);
            Controls.Add(panel1);
            Name = "ClienteMasVendido";
            Text = "Ranking Top 10 Clientes";
            groupBoxFiltros.ResumeLayout(false);
            groupBoxFiltros.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBoxFiltros;
        private System.Windows.Forms.RadioButton rbAnual;
        private System.Windows.Forms.RadioButton rbMensual;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.ComboBox cmbAnio;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.Button btnActualizar;
    }
}