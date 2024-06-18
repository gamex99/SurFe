namespace SurFeFront
{
    partial class ListadoPorCategoria
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
            cbcategorias = new ComboBox();
            btnMostrar = new Button();
            btncancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(143, 15);
            label1.TabIndex = 0;
            label1.Text = "LISTADO POR CATEGORIA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 43);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 1;
            label2.Text = "Categoria";
            // 
            // cbcategorias
            // 
            cbcategorias.FormattingEnabled = true;
            cbcategorias.Location = new Point(76, 40);
            cbcategorias.Name = "cbcategorias";
            cbcategorias.Size = new Size(121, 23);
            cbcategorias.TabIndex = 2;
            // 
            // btnMostrar
            // 
            btnMostrar.Location = new Point(203, 39);
            btnMostrar.Name = "btnMostrar";
            btnMostrar.Size = new Size(95, 23);
            btnMostrar.TabIndex = 3;
            btnMostrar.Text = "MostrarLista";
            btnMostrar.UseVisualStyleBackColor = true;
            btnMostrar.Click += btnMostrar_Click;
            // 
            // btncancelar
            // 
            btncancelar.Location = new Point(304, 39);
            btncancelar.Name = "btncancelar";
            btncancelar.Size = new Size(75, 23);
            btncancelar.TabIndex = 4;
            btncancelar.Text = "Cancelar";
            btncancelar.UseVisualStyleBackColor = true;
            // 
            // ListadoPorCategoria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 88);
            Controls.Add(btncancelar);
            Controls.Add(btnMostrar);
            Controls.Add(cbcategorias);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ListadoPorCategoria";
            Text = "ListadoPorCategoria";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cbcategorias;
        private Button btnMostrar;
        private Button btncancelar;
    }
}