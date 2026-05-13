namespace SurFeFront
{
    partial class GestionUsuarios
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            dgvUsuarios = new DataGridView();
            lblTitulo = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblPass = new Label();
            txtPass = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblDni = new Label();
            txtDni = new TextBox();
            lblDepto = new Label();
            cmbDepartamento = new ComboBox();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnDarDeBaja = new Button();
            btnLimpiar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.BackgroundColor = Color.White;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(12, 50);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.Size = new Size(760, 250);
            dgvUsuarios.TabIndex = 0;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(256, 25);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Gestión de Usuarios y Roles";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(12, 320);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(50, 15);
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(100, 317);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(150, 23);
            txtUsuario.TabIndex = 3;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Location = new Point(12, 350);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(70, 15);
            lblPass.TabIndex = 4;
            lblPass.Text = "Contraseña:";
            // 
            // txtPass
            // 
            txtPass.Location = new Point(100, 347);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(150, 23);
            txtPass.TabIndex = 5;
            txtPass.UseSystemPasswordChar = true;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(280, 320);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 6;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(360, 317);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(150, 23);
            txtNombre.TabIndex = 7;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(280, 350);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(54, 15);
            lblApellido.TabIndex = 8;
            lblApellido.Text = "Apellido:";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(360, 347);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(150, 23);
            txtApellido.TabIndex = 9;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(530, 320);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(30, 15);
            lblDni.TabIndex = 10;
            lblDni.Text = "DNI:";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(600, 317);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(150, 23);
            txtDni.TabIndex = 11;
            // 
            // lblDepto
            // 
            lblDepto.AutoSize = true;
            lblDepto.Location = new Point(12, 385);
            lblDepto.Name = "lblDepto";
            lblDepto.Size = new Size(86, 15);
            lblDepto.TabIndex = 12;
            lblDepto.Text = "Departamento:";
            // 
            // cmbDepartamento
            // 
            cmbDepartamento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartamento.FormattingEnabled = true;
            cmbDepartamento.Location = new Point(100, 382);
            cmbDepartamento.Name = "cmbDepartamento";
            cmbDepartamento.Size = new Size(200, 23);
            cmbDepartamento.TabIndex = 13;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.MidnightBlue;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(12, 425);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(120, 35);
            btnAgregar.TabIndex = 15;
            btnAgregar.Text = "AGREGAR";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.DarkGreen;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnModificar.ForeColor = Color.White;
            btnModificar.Location = new Point(145, 425);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(120, 35);
            btnModificar.TabIndex = 16;
            btnModificar.Text = "MODIFICAR";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnDarDeBaja
            // 
            btnDarDeBaja.BackColor = Color.DarkRed;
            btnDarDeBaja.FlatStyle = FlatStyle.Flat;
            btnDarDeBaja.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnDarDeBaja.ForeColor = Color.White;
            btnDarDeBaja.Location = new Point(280, 425);
            btnDarDeBaja.Name = "btnDarDeBaja";
            btnDarDeBaja.Size = new Size(120, 35);
            btnDarDeBaja.TabIndex = 17;
            btnDarDeBaja.Text = "DAR DE BAJA";
            btnDarDeBaja.UseVisualStyleBackColor = false;
            btnDarDeBaja.Click += btnDarDeBaja_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.Gray;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(620, 425);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(150, 35);
            btnLimpiar.TabIndex = 18;
            btnLimpiar.Text = "LIMPIAR CAMPOS";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // GestionUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(784, 481);
            Controls.Add(btnLimpiar);
            Controls.Add(btnDarDeBaja);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(cmbDepartamento);
            Controls.Add(lblDepto);
            Controls.Add(txtDni);
            Controls.Add(lblDni);
            Controls.Add(txtApellido);
            Controls.Add(lblApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(txtPass);
            Controls.Add(lblPass);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(lblTitulo);
            Controls.Add(dgvUsuarios);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "GestionUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SurFe - Gestión de Usuarios";
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblDepto;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnDarDeBaja;
        private System.Windows.Forms.Button btnLimpiar;
    }
}