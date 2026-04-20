namespace SurFeFront
{
    partial class Login
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblUsu = new Label();
            lblCont = new Label();
            txtUsu = new TextBox();
            txtCont = new TextBox();
            btAcceso = new Button();
            btSalir = new Button();
            SuspendLayout();
            // 
            // lblUsu
            // 
            lblUsu.AutoSize = true;
            lblUsu.BackColor = Color.Transparent;
            lblUsu.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblUsu.ForeColor = Color.White; // Asumiendo fondo oscuro
            lblUsu.Location = new Point(275, 200);
            lblUsu.Name = "lblUsu";
            lblUsu.Size = new Size(66, 20);
            lblUsu.TabIndex = 3;
            lblUsu.Text = "Usuario:";
            // 
            // lblCont
            // 
            lblCont.AutoSize = true;
            lblCont.BackColor = Color.Transparent;
            lblCont.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblCont.ForeColor = Color.White;
            lblCont.Location = new Point(275, 265);
            lblCont.Name = "lblCont";
            lblCont.Size = new Size(90, 20);
            lblCont.TabIndex = 4;
            lblCont.Text = "Contraseña:";
            // 
            // txtUsu
            // 
            txtUsu.BackColor = Color.White;
            txtUsu.BorderStyle = BorderStyle.FixedSingle;
            txtUsu.Font = new Font("Segoe UI", 11F);
            txtUsu.Location = new Point(275, 225);
            txtUsu.Name = "txtUsu";
            txtUsu.Size = new Size(180, 27);
            txtUsu.TabIndex = 0;
            // 
            // txtCont
            // 
            txtCont.BackColor = Color.White;
            txtCont.BorderStyle = BorderStyle.FixedSingle;
            txtCont.Font = new Font("Segoe UI", 11F);
            txtCont.Location = new Point(275, 290);
            txtCont.Name = "txtCont";
            txtCont.PasswordChar = '●'; // Caracter de seguridad moderno
            txtCont.Size = new Size(180, 27);
            txtCont.TabIndex = 1;
            txtCont.TextChanged += txtCont_TextChanged;
            // 
            // btAcceso
            // 
            btAcceso.BackColor = Color.FromArgb(0, 120, 215); // Azul moderno
            btAcceso.Cursor = Cursors.Hand;
            btAcceso.FlatAppearance.BorderSize = 0;
            btAcceso.FlatStyle = FlatStyle.Flat;
            btAcceso.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btAcceso.ForeColor = Color.White;
            btAcceso.Location = new Point(275, 335);
            btAcceso.Name = "btAcceso";
            btAcceso.Size = new Size(180, 35);
            btAcceso.TabIndex = 2;
            btAcceso.Text = "INGRESAR";
            btAcceso.UseVisualStyleBackColor = false;
            btAcceso.Click += btAcceso_Click;
            // 
            // btSalir
            // 
            btSalir.BackColor = Color.FromArgb(64, 64, 64); // Gris oscuro
            btSalir.Cursor = Cursors.Hand;
            btSalir.FlatAppearance.BorderSize = 0;
            btSalir.FlatStyle = FlatStyle.Flat;
            btSalir.Font = new Font("Segoe UI", 9F);
            btSalir.ForeColor = Color.Silver;
            btSalir.Location = new Point(275, 380);
            btSalir.Name = "btSalir";
            btSalir.Size = new Size(180, 30);
            btSalir.TabIndex = 8;
            btSalir.Text = "Cancelar";
            btSalir.UseVisualStyleBackColor = false;
            btSalir.Click += btSalir_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30); // Fondo oscuro base
            BackgroundImage = Properties.Resources.fondo_login2;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(720, 480);
            Controls.Add(btSalir);
            Controls.Add(btAcceso);
            Controls.Add(txtCont);
            Controls.Add(txtUsu);
            Controls.Add(lblCont);
            Controls.Add(lblUsu);
            DoubleBuffered = true; // Evita el parpadeo al cargar imagen
            FormBorderStyle = FormBorderStyle.None; // Login sin bordes de ventana feos
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - SurFe";
            Load += Login_Load;
            KeyDown += Login_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblUsu;
        private Label lblCont;
        private TextBox txtUsu;
        private TextBox txtCont;
        private Button btAcceso;
        private Button btSalir;
    }
}