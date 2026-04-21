namespace SurFeFront
{
    partial class RemitoRegistrar
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnBuscarPedido = new System.Windows.Forms.Button();
            this.lblPedidoInfo = new System.Windows.Forms.Label();
            this.lblNroRemito = new System.Windows.Forms.Label();
            this.txtNroRemito = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.btnConfirmar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(432, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registrar Remito de Entrada (Carga de Stock)";
            // 
            // btnBuscarPedido
            // 
            this.btnBuscarPedido.Location = new System.Drawing.Point(16, 50);
            this.btnBuscarPedido.Name = "btnBuscarPedido";
            this.btnBuscarPedido.Size = new System.Drawing.Size(150, 30);
            this.btnBuscarPedido.TabIndex = 1;
            this.btnBuscarPedido.Text = "🔍 Buscar Pedido";
            this.btnBuscarPedido.UseVisualStyleBackColor = true;
            this.btnBuscarPedido.Click += new System.EventHandler(this.btnBuscarPedido_Click);
            // 
            // lblPedidoInfo
            // 
            this.lblPedidoInfo.AutoSize = true;
            this.lblPedidoInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPedidoInfo.Location = new System.Drawing.Point(180, 58);
            this.lblPedidoInfo.Name = "lblPedidoInfo";
            this.lblPedidoInfo.Size = new System.Drawing.Size(147, 15);
            this.lblPedidoInfo.TabIndex = 2;
            this.lblPedidoInfo.Text = "Pedido no seleccionado...";
            // 
            // lblNroRemito
            // 
            this.lblNroRemito.AutoSize = true;
            this.lblNroRemito.Location = new System.Drawing.Point(16, 100);
            this.lblNroRemito.Name = "lblNroRemito";
            this.lblNroRemito.Size = new System.Drawing.Size(107, 15);
            this.lblNroRemito.TabIndex = 3;
            this.lblNroRemito.Text = "Nro Remito Físico:";
            // 
            // txtNroRemito
            // 
            this.txtNroRemito.Location = new System.Drawing.Point(130, 97);
            this.txtNroRemito.Name = "txtNroRemito";
            this.txtNroRemito.Size = new System.Drawing.Size(150, 23);
            this.txtNroRemito.TabIndex = 4;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(300, 100);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(101, 15);
            this.lblFecha.TabIndex = 5;
            this.lblFecha.Text = "Fecha Recepción:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(410, 97);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(110, 23);
            this.dtpFecha.TabIndex = 6;
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductos.ColumnHeadersHeight = 30;
            this.dgvProductos.EnableHeadersVisualStyles = false;
            this.dgvProductos.Location = new System.Drawing.Point(16, 140);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.Size = new System.Drawing.Size(750, 300);
            this.dgvProductos.TabIndex = 7;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.DarkGreen;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(566, 450);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(200, 40);
            this.btnConfirmar.TabIndex = 8;
            this.btnConfirmar.Text = "CONFIRMAR CARGA";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // RemitoRegistrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.txtNroRemito);
            this.Controls.Add(this.lblNroRemito);
            this.Controls.Add(this.lblPedidoInfo);
            this.Controls.Add(this.btnBuscarPedido);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "RemitoRegistrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SurFe - Registro de Remitos de Entrada";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnBuscarPedido;
        private System.Windows.Forms.Label lblPedidoInfo;
        private System.Windows.Forms.Label lblNroRemito;
        private System.Windows.Forms.TextBox txtNroRemito;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btnConfirmar;
    }
}