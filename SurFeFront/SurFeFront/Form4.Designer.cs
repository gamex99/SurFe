namespace SurFe
{
    partial class Form4
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
            button1 = new Button();
            label2 = new Label();
            checkBox1 = new CheckBox();
            Emitir = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(38, 23);
            label1.Name = "label1";
            label1.Size = new Size(155, 15);
            label1.TabIndex = 0;
            label1.Text = "INFORME POR PRODUCTO";
            // 
            // button1
            // 
            button1.Location = new Point(38, 62);
            button1.Name = "button1";
            button1.Size = new Size(121, 23);
            button1.TabIndex = 1;
            button1.Text = "Buscar Producto";
            button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 109);
            label2.Name = "label2";
            label2.Size = new Size(384, 15);
            label2.TabIndex = 2;
            label2.Text = "Cod Int: 0001          BarCode: 00456564698153      Producto: Tornillo 6mm";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(38, 154);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(72, 19);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "Imprimir";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // Emitir
            // 
            Emitir.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Emitir.Location = new Point(307, 198);
            Emitir.Name = "Emitir";
            Emitir.Size = new Size(75, 23);
            Emitir.TabIndex = 4;
            Emitir.Text = "Emitir";
            Emitir.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(388, 198);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 5;
            button3.Text = "Cancelar";
            button3.UseVisualStyleBackColor = true;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(486, 235);
            Controls.Add(button3);
            Controls.Add(Emitir);
            Controls.Add(checkBox1);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form4";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form4";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Label label2;
        private CheckBox checkBox1;
        private Button Emitir;
        private Button button3;
    }
}