namespace SurFeFront
{
    partial class InformeFaltantes
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
            textBox1 = new TextBox();
            btnmostrar = new Button();
            dataGridView1 = new DataGridView();
            btncerrar = new Button();
            btnimprimir = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(209, 15);
            label1.TabIndex = 0;
            label1.Text = "Mostrar productos con stock menor a:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(227, 11);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            // 
            // btnmostrar
            // 
            btnmostrar.Location = new Point(333, 11);
            btnmostrar.Name = "btnmostrar";
            btnmostrar.Size = new Size(75, 23);
            btnmostrar.TabIndex = 2;
            btnmostrar.Text = "Mostrar";
            btnmostrar.UseVisualStyleBackColor = true;
            btnmostrar.Click += btnmostrar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 40);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(776, 376);
            dataGridView1.TabIndex = 3;
            // 
            // btncerrar
            // 
            btncerrar.Location = new Point(713, 422);
            btncerrar.Name = "btncerrar";
            btncerrar.Size = new Size(75, 23);
            btncerrar.TabIndex = 4;
            btncerrar.Text = "Cerrar";
            btncerrar.UseVisualStyleBackColor = true;
            btncerrar.Click += button1_Click;
            // 
            // btnimprimir
            // 
            btnimprimir.Location = new Point(632, 422);
            btnimprimir.Name = "btnimprimir";
            btnimprimir.Size = new Size(75, 23);
            btnimprimir.TabIndex = 5;
            btnimprimir.Text = "Imprimir";
            btnimprimir.UseVisualStyleBackColor = true;
            btnimprimir.Click += btnimprimir_Click;
            // 
            // InformeFaltantes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnimprimir);
            Controls.Add(btncerrar);
            Controls.Add(dataGridView1);
            Controls.Add(btnmostrar);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "InformeFaltantes";
            Text = "InformeFaltantes";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button btnmostrar;
        private DataGridView dataGridView1;
        private Button btncerrar;
        private Button btnimprimir;
    }
}