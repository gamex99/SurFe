namespace SurFe
{
    partial class Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            panel1 = new Panel();
            button5 = new Button();
            btSalir = new Button();
            button1 = new Button();
            label3 = new Label();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            panel2 = new Panel();
            bindingSource1 = new BindingSource(components);
            label1 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Blue;
            panel1.Controls.Add(button5);
            panel1.Controls.Add(btSalir);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(178, 453);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // button5
            // 
            button5.BackColor = Color.DodgerBlue;
            button5.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            button5.Location = new Point(12, 258);
            button5.Name = "button5";
            button5.Size = new Size(151, 43);
            button5.TabIndex = 6;
            button5.Text = "PRODUCTOS";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // btSalir
            // 
            btSalir.BackColor = Color.DodgerBlue;
            btSalir.FlatAppearance.BorderColor = Color.White;
            btSalir.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btSalir.Location = new Point(12, 396);
            btSalir.Name = "btSalir";
            btSalir.Size = new Size(151, 43);
            btSalir.TabIndex = 5;
            btSalir.Text = "SALIR";
            btSalir.UseVisualStyleBackColor = false;
            btSalir.Click += btSalir_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.DodgerBlue;
            button1.FlatAppearance.BorderColor = Color.White;
            button1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(12, 209);
            button1.Name = "button1";
            button1.Size = new Size(151, 43);
            button1.TabIndex = 4;
            button1.Text = "CLIENTES";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.ImageAlign = ContentAlignment.TopCenter;
            label3.Location = new Point(59, 25);
            label3.Name = "label3";
            label3.Size = new Size(55, 21);
            label3.TabIndex = 0;
            label3.Text = "MENU";
            label3.UseMnemonic = false;
            // 
            // button4
            // 
            button4.BackColor = Color.DodgerBlue;
            button4.FlatAppearance.BorderColor = Color.White;
            button4.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Location = new Point(12, 160);
            button4.Name = "button4";
            button4.Size = new Size(151, 43);
            button4.TabIndex = 3;
            button4.Text = "INFORMES";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.DodgerBlue;
            button3.FlatAppearance.BorderColor = Color.White;
            button3.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(12, 111);
            button3.Name = "button3";
            button3.Size = new Size(151, 43);
            button3.TabIndex = 2;
            button3.Text = "DEPOSITO";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.DodgerBlue;
            button2.FlatAppearance.BorderColor = Color.White;
            button2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(12, 62);
            button2.Name = "button2";
            button2.Size = new Size(151, 43);
            button2.TabIndex = 1;
            button2.Text = "VENTA";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.Location = new Point(184, 70);
            panel2.Name = "panel2";
            panel2.Size = new Size(619, 283);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(184, 426);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 2;
            label1.Text = "Usuario: FPARON";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(741, 426);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 3;
            label2.Text = "SurFe®";
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Menu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu Principal";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button button4;
        private Button button3;
        private Button button2;
        private BindingSource bindingSource1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button btSalir;
        private Button button5;
    }
}