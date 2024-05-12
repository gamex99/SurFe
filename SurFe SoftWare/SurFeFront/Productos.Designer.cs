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
            // btnConsulta
            // 
            btnConsulta.Location = new Point(93, 362);
            btnConsulta.Name = "btnConsulta";
            btnConsulta.Size = new Size(75, 23);
            btnConsulta.TabIndex = 1;
            btnConsulta.Text = "Modificacion";
            btnConsulta.UseVisualStyleBackColor = true;
            btnConsulta.Click += button2_Click;
            // 
            // btncons
            // 
            btncons.Location = new Point(174, 362);
            btncons.Name = "btncons";
            btncons.Size = new Size(75, 23);
            btncons.TabIndex = 2;
            btncons.Text = "Consulta";
            btncons.UseVisualStyleBackColor = true;
            btncons.Click += btncons_Click;
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
            dataProductos.CellClick += dataProductos_CellClick;
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
            // btneliminar
            // 
            btneliminar.Location = new Point(255, 362);
            btneliminar.Name = "btneliminar";
            btneliminar.Size = new Size(75, 23);
            btneliminar.TabIndex = 9;
            btneliminar.Text = "Eliminar";
            btneliminar.UseVisualStyleBackColor = true;
            btneliminar.Click += btneliminar_Click;
            // 
            // Productos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(689, 397);
            Controls.Add(btneliminar);
            Controls.Add(dataProductos);
            Controls.Add(cbcategorias);
            Controls.Add(tbBuscar);
            Controls.Add(label1);
            Controls.Add(button5);
            Controls.Add(btncons);
            Controls.Add(btnConsulta);
            Controls.Add(button1);
            Name = "Productos";
            Text = "Productos";
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