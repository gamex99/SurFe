namespace SurFeFront
{
    partial class Productos
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button5 = new Button();
            label1 = new Label();
            tbBuscar = new TextBox();
            dataProductos = new DataGridView();
            cbcategorias = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataProductos).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 362);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Nuevo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(93, 362);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "Consultar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(174, 362);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 2;
            button3.Text = "Eliminar";
            button3.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(602, 362);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 4;
            button5.Text = "Salir";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 43);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 5;
            label1.Text = "Buscar";
            // 
            // tbBuscar
            // 
            tbBuscar.Location = new Point(60, 40);
            tbBuscar.Name = "tbBuscar";
            tbBuscar.Size = new Size(225, 23);
            tbBuscar.TabIndex = 6;
            tbBuscar.TextChanged += tbBuscar_TextChanged;
            // 
            // dataProductos
            // 
            dataProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataProductos.Location = new Point(12, 69);
            dataProductos.Name = "dataProductos";
            dataProductos.RowTemplate.Height = 25;
            dataProductos.Size = new Size(665, 287);
            dataProductos.TabIndex = 8;
            // 
            // cbcategorias
            // 
            cbcategorias.FormattingEnabled = true;
            cbcategorias.Location = new Point(317, 40);
            cbcategorias.Name = "cbcategorias";
            cbcategorias.Size = new Size(151, 23);
            cbcategorias.TabIndex = 7;
            cbcategorias.TextChanged += cbcategorias_TextChanged;
            // 
            // Productos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(689, 397);
            Controls.Add(dataProductos);
            Controls.Add(cbcategorias);
            Controls.Add(tbBuscar);
            Controls.Add(label1);
            Controls.Add(button5);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Productos";
            Text = "Productos";
            ((System.ComponentModel.ISupportInitialize)dataProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button5;
        private Label label1;
        private TextBox tbBuscar;
        private DataGridView dataProductos;
        private ComboBox cbcategorias;
    }
}