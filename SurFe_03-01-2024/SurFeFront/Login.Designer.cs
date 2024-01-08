namespace SurFeFront
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel2 = new Panel();
            lblUsu = new Label();
            lblCont = new Label();
            txtUsu = new TextBox();
            txtCont = new TextBox();
            btAcceso = new Button();
            btSalir = new Button();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.Location = new Point(79, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(634, 291);
            panel2.TabIndex = 2;
            // 
            // lblUsu
            // 
            lblUsu.AutoSize = true;
            lblUsu.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblUsu.Location = new Point(229, 315);
            lblUsu.Name = "lblUsu";
            lblUsu.Size = new Size(94, 30);
            lblUsu.TabIndex = 3;
            lblUsu.Text = "Usuario:";
            // 
            // lblCont
            // 
            lblCont.AutoSize = true;
            lblCont.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblCont.Location = new Point(229, 375);
            lblCont.Name = "lblCont";
            lblCont.Size = new Size(129, 30);
            lblCont.TabIndex = 4;
            lblCont.Text = "Contraseña:";
            // 
            // txtUsu
            // 
            txtUsu.Location = new Point(369, 322);
            txtUsu.Name = "txtUsu";
            txtUsu.Size = new Size(136, 23);
            txtUsu.TabIndex = 5;
            txtUsu.Text = "demo";
            // 
            // txtCont
            // 
            txtCont.Location = new Point(369, 382);
            txtCont.Name = "txtCont";
            txtCont.Size = new Size(136, 23);
            txtCont.TabIndex = 6;
            txtCont.Text = "demo";
            txtCont.TextChanged += txtCont_TextChanged;
            // 
            // btAcceso
            // 
            btAcceso.Location = new Point(369, 427);
            btAcceso.Name = "btAcceso";
            btAcceso.Size = new Size(136, 23);
            btAcceso.TabIndex = 7;
            btAcceso.Text = "Acceso ";
            btAcceso.UseVisualStyleBackColor = true;
            btAcceso.Click += btAcceso_Click;
            // 
            // btSalir
            // 
            btSalir.Location = new Point(369, 456);
            btSalir.Name = "btSalir";
            btSalir.Size = new Size(136, 23);
            btSalir.TabIndex = 8;
            btSalir.Text = "Cancelar";
            btSalir.UseVisualStyleBackColor = true;
            btSalir.Click += btSalir_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(861, 488);
            Controls.Add(btSalir);
            Controls.Add(btAcceso);
            Controls.Add(txtCont);
            Controls.Add(txtUsu);
            Controls.Add(lblCont);
            Controls.Add(lblUsu);
            Controls.Add(panel2);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            KeyPress += Login_KeyPress;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel2;
        private Label lblUsu;
        private Label lblCont;
        private TextBox txtUsu;
        private TextBox txtCont;
        private Button btAcceso;
        private Button btSalir;
    }
}