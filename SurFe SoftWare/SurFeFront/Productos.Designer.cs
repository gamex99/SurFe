namespace SurFeFront
{
    partial class Productos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            button1 = new Button();
            btnConsulta = new Button();
            btncons = new Button();
            button5 = new Button();
            label1 = new Label();
            tbBuscar = new TextBox();
            dataProductos = new DataGridView();
            cbcategorias = new ComboBox();
            btneliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataProductos).BeginInit();
            SuspendLayout();
            // 
            // label1 (Título/Buscador)
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(116, 19);
            label1.TabIndex = 5;
            label1.Text = "Buscar Producto:";
            // 
            // tbBuscar
            // 
            tbBuscar.Font = new Font("Segoe UI", 10F);
            tbBuscar.Location = new Point(12, 40);
            tbBuscar.Name = "tbBuscar";
            tbBuscar.PlaceholderText = "Ingrese nombre...";
            tbBuscar.Size = new Size(273, 25);
            tbBuscar.TabIndex = 6;
            tbBuscar.TextChanged += tbBuscar_TextChanged;
            // 
            // cbcategorias
            // 
            cbcategorias.DropDownStyle = ComboBoxStyle.DropDownList;
            cbcategorias.Font = new Font("Segoe UI", 10F);
            cbcategorias.FormattingEnabled = true;
            cbcategorias.Location = new Point(291, 40);
            cbcategorias.Name = "cbcategorias";
            cbcategorias.Size = new Size(177, 25);
            cbcategorias.TabIndex = 7;
            cbcategorias.TextChanged += cbcategorias_TextChanged;
            // 
            // dataProductos
            // 
            dataProductos.AllowUserToAddRows = false;
            dataProductos.AllowUserToDeleteRows = false;
            dataProductos.AllowUserToResizeRows = false;
            dataProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataProductos.BackgroundColor = Color.White;
            dataProductos.BorderStyle = BorderStyle.None;
            dataProductos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataProductos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataProductos.ColumnHeadersHeight = 35;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(230, 240, 250);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataProductos.DefaultCellStyle = dataGridViewCellStyle2;
            dataProductos.EnableHeadersVisualStyles = false;
            dataProductos.GridColor = Color.FromArgb(239, 239, 239);
            dataProductos.Location = new Point(12, 80);
            dataProductos.MultiSelect = false;
            dataProductos.Name = "dataProductos";
            dataProductos.ReadOnly = true;
            dataProductos.RowHeadersVisible = false;
            dataProductos.RowTemplate.Height = 30;
            dataProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataProductos.Size = new Size(760, 310);
            dataProductos.TabIndex = 8;
            dataProductos.CellClick += dataProductos_CellClick;
            // 
            // button1 (Nuevo)
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.BackColor = Color.FromArgb(0, 120, 215);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 9F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(12, 405);
            button1.Name = "button1";
            button1.Size = new Size(100, 35);
            button1.TabIndex = 0;
            button1.Text = "Nuevo";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnConsulta (Modificar)
            // 
            btnConsulta.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnConsulta.BackColor = Color.FromArgb(240, 240, 240);
            btnConsulta.FlatAppearance.BorderColor = Color.Silver;
            btnConsulta.FlatStyle = FlatStyle.Flat;
            btnConsulta.Font = new Font("Segoe UI", 9F);
            btnConsulta.Location = new Point(118, 405);
            btnConsulta.Name = "btnConsulta";
            btnConsulta.Size = new Size(100, 35);
            btnConsulta.TabIndex = 1;
            btnConsulta.Text = "Modificar";
            btnConsulta.UseVisualStyleBackColor = false;
            btnConsulta.Click += button2_Click;
            // 
            // btncons (Consulta)
            // 
            btncons.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btncons.BackColor = Color.FromArgb(240, 240, 240);
            btncons.FlatAppearance.BorderColor = Color.Silver;
            btncons.FlatStyle = FlatStyle.Flat;
            btncons.Font = new Font("Segoe UI", 9F);
            btncons.Location = new Point(224, 405);
            btncons.Name = "btncons";
            btncons.Size = new Size(100, 35);
            btncons.TabIndex = 2;
            btncons.Text = "Consulta";
            btncons.UseVisualStyleBackColor = false;
            btncons.Click += btncons_Click;
            // 
            // btneliminar
            // 
            btneliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btneliminar.BackColor = Color.FromArgb(240, 240, 240);
            btneliminar.FlatAppearance.BorderColor = Color.Silver;
            btneliminar.FlatStyle = FlatStyle.Flat;
            btneliminar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btneliminar.ForeColor = Color.Firebrick;
            btneliminar.Location = new Point(330, 405);
            btneliminar.Name = "btneliminar";
            btneliminar.Size = new Size(100, 35);
            btneliminar.TabIndex = 9;
            btneliminar.Text = "Eliminar";
            btneliminar.UseVisualStyleBackColor = false;
            btneliminar.Click += btneliminar_Click;
            // 
            // button5 (Salir)
            // 
            button5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button5.BackColor = Color.FromArgb(240, 240, 240);
            button5.FlatAppearance.BorderColor = Color.Silver;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 9F);
            button5.Location = new Point(672, 405);
            button5.Name = "button5";
            button5.Size = new Size(100, 35);
            button5.TabIndex = 4;
            button5.Text = "Salir";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // Productos
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(784, 452);
            Controls.Add(btneliminar);
            Controls.Add(dataProductos);
            Controls.Add(cbcategorias);
            Controls.Add(tbBuscar);
            Controls.Add(label1);
            Controls.Add(button5);
            Controls.Add(btncons);
            Controls.Add(btnConsulta);
            Controls.Add(button1);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "Productos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Productos - SurFe";
            ((System.ComponentModel.ISupportInitialize)dataProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button btnConsulta;
        private Button btncons;
        private Button button5;
        private Label label1;
        private TextBox tbBuscar;
        private DataGridView dataProductos;
        private ComboBox cbcategorias;
        private Button btneliminar;
    }
}