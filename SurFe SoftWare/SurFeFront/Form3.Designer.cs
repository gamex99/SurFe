namespace SurFe
{
    partial class Form3
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
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            button1 = new Button();
            button2 = new Button();
            groupBox1 = new GroupBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            label3 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Menu;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(22, 27);
            label1.Name = "label1";
            label1.Size = new Size(116, 15);
            label1.TabIndex = 0;
            label1.Text = "NUEVO PRODUCTO";
            label1.Click += label1_Click;
            // 
            // comboBox1
            // 
            comboBox1.DisplayMember = "Categoria";
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 95);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 1;
            comboBox1.Text = "Categoria";
            comboBox1.ValueMember = "Categoria";
            // 
            // textBox1
            // 
            textBox1.ForeColor = SystemColors.WindowText;
            textBox1.Location = new Point(139, 95);
            textBox1.Name = "textBox1";
            textBox1.RightToLeft = RightToLeft.No;
            textBox1.Size = new Size(121, 23);
            textBox1.TabIndex = 2;
            textBox1.Text = "BarCode";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(266, 95);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(121, 23);
            textBox3.TabIndex = 4;
            textBox3.Text = "Detalle";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(393, 95);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(121, 23);
            textBox4.TabIndex = 5;
            textBox4.Text = "Stock";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(520, 95);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(121, 23);
            textBox5.TabIndex = 6;
            textBox5.Text = "Precio";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(173, 72);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 7;
            label2.Text = "BarCode";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(302, 72);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 9;
            label4.Text = "Detalle";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(431, 72);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 10;
            label5.Text = "Stock";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(558, 72);
            label6.Name = "label6";
            label6.Size = new Size(40, 15);
            label6.TabIndex = 11;
            label6.Text = "Precio";
            label6.Click += label6_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Menu;
            button1.Location = new Point(475, 182);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 12;
            button1.Text = "Cargar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(566, 182);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 13;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(475, 134);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(163, 42);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "CargarOtro?";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(57, 18);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(41, 19);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "No";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(11, 18);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(34, 19);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Si";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 72);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 15;
            label3.Text = "Categoria";
            label3.Click += label3_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            ClientSize = new Size(655, 213);
            Controls.Add(label3);
            Controls.Add(groupBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nuevo Producto";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button button1;
        private Button button2;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label3;
    }
}