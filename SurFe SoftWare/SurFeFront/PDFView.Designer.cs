namespace SurFeFront
{
    partial class PDFView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDFView));
            axAcropdf1 = new AxAcroPDFLib.AxAcroPDF();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            btnsalir = new Button();
            ((System.ComponentModel.ISupportInitialize)axAcropdf1).BeginInit();
            SuspendLayout();
            // 
            // axAcropdf1
            // 
            axAcropdf1.Dock = DockStyle.Fill;
            axAcropdf1.Enabled = true;
            axAcropdf1.Location = new Point(0, 0);
            axAcropdf1.Name = "axAcropdf1";
            axAcropdf1.OcxState = (AxHost.State)resources.GetObject("axAcropdf1.OcxState");
            axAcropdf1.Size = new Size(1104, 353);
            axAcropdf1.TabIndex = 0;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // btnsalir
            // 
            btnsalir.AutoEllipsis = true;
            btnsalir.AutoSize = true;
            btnsalir.Location = new Point(1017, 12);
            btnsalir.Name = "btnsalir";
            btnsalir.Size = new Size(75, 25);
            btnsalir.TabIndex = 1;
            btnsalir.Text = "Salir";
            btnsalir.UseVisualStyleBackColor = true;
            btnsalir.Click += btnsalir_Click;
            // 
            // PDFView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1104, 353);
            Controls.Add(btnsalir);
            Controls.Add(axAcropdf1);
            Name = "PDFView";
            Text = "PDFView";
            FormClosing += PDFView_FormClosing;
            Load += PDFView_Load;
            ((System.ComponentModel.ISupportInitialize)axAcropdf1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF axAcropdf1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private Button btnsalir;
    }
}