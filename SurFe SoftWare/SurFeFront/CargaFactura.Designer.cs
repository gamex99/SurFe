namespace SurFeFront
{
    partial class CargaFactura
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tbfac = new TextBox();
            tbfactura = new TextBox();
            btncarga = new Button();
            salir = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(30, 27);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 0;
            label1.Text = "Compra n°";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(122, 27);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 1;
            label2.Text = "****";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(30, 85);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 2;
            label3.Text = "FACTURA N°";
            // 
            // tbfac
            // 
            tbfac.Location = new Point(115, 81);
            tbfac.Name = "tbfac";
            tbfac.Size = new Size(179, 23);
            tbfac.TabIndex = 3;
            // 
            // tbfactura
            // 
            tbfactura.Location = new Point(300, 81);
            tbfactura.Name = "tbfactura";
            tbfactura.Size = new Size(179, 23);
            tbfactura.TabIndex = 4;
            // 
            // btncarga
            // 
            btncarga.Location = new Point(468, 139);
            btncarga.Name = "btncarga";
            btncarga.Size = new Size(75, 23);
            btncarga.TabIndex = 5;
            btncarga.Text = "Cargar";
            btncarga.UseVisualStyleBackColor = true;
            btncarga.Click += btncarga_Click;
            // 
            // salir
            // 
            salir.Location = new Point(549, 139);
            salir.Name = "salir";
            salir.Size = new Size(75, 23);
            salir.TabIndex = 6;
            salir.Text = "Salir";
            salir.UseVisualStyleBackColor = true;
            // 
            // CargaFactura
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondo_carga_factura1;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(643, 174);
            Controls.Add(salir);
            Controls.Add(btncarga);
            Controls.Add(tbfactura);
            Controls.Add(tbfac);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CargaFactura";
            RightToLeft = RightToLeft.No;
            Text = "CargaFactura";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbfac;
        private TextBox tbfactura;
        private Button btncarga;
        private Button salir;
    }
}