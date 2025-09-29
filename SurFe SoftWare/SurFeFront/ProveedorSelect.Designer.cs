namespace SurFeFront
{
    partial class ProveedorSelect
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
            tbfiltro = new TextBox();
            dataproveedores = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataproveedores).BeginInit();
            SuspendLayout();
            // 
            // tbfiltro
            // 
            tbfiltro.Location = new Point(15, 15);
            tbfiltro.Name = "tbfiltro";
            tbfiltro.Size = new Size(773, 23);
            tbfiltro.TabIndex = 0;
            // 
            // dataproveedores
            // 
            dataproveedores.AllowUserToAddRows = false;
            dataproveedores.AllowUserToDeleteRows = false;
            dataproveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataproveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataproveedores.Location = new Point(10, 56);
            dataproveedores.Name = "dataproveedores";
            dataproveedores.ReadOnly = true;
            dataproveedores.RowTemplate.Height = 25;
            dataproveedores.Size = new Size(778, 382);
            dataproveedores.TabIndex = 1;
            dataproveedores.CellDoubleClick += dataproveedores_CellDoubleClick;
            // 
            // ProveedorSelect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataproveedores);
            Controls.Add(tbfiltro);
            Name = "ProveedorSelect";
            Text = "ProveedorSelect";
            ((System.ComponentModel.ISupportInitialize)dataproveedores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbfiltro;
        private DataGridView dataproveedores;
    }
}