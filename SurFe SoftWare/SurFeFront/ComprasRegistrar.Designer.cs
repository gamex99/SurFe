namespace SurFeFront
{
    partial class ComprasRegistrar
    
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
                this.panelTop = new System.Windows.Forms.Panel();
                this.btnSeleccionarFactura = new System.Windows.Forms.Button();
                this.lblFacturaInfo = new System.Windows.Forms.Label();
                this.txtOrdenCompra = new System.Windows.Forms.TextBox();
                this.lblOC = new System.Windows.Forms.Label();
                this.dgvRemitos = new System.Windows.Forms.DataGridView();
                this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
                this.id_remito = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.nro_remito = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.fecha_entrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.lblTituloRemitos = new System.Windows.Forms.Label();
                this.panelBottom = new System.Windows.Forms.Panel();
                this.btnRegistrar = new System.Windows.Forms.Button();
                this.lblAyuda = new System.Windows.Forms.Label();
                this.panelTop.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.dgvRemitos)).BeginInit();
                this.panelBottom.SuspendLayout();
                this.SuspendLayout();
                // 
                // panelTop
                // 
                this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
                this.panelTop.Controls.Add(this.btnSeleccionarFactura);
                this.panelTop.Controls.Add(this.lblFacturaInfo);
                this.panelTop.Controls.Add(this.txtOrdenCompra);
                this.panelTop.Controls.Add(this.lblOC);
                this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
                this.panelTop.Location = new System.Drawing.Point(0, 0);
                this.panelTop.Name = "panelTop";
                this.panelTop.Size = new System.Drawing.Size(784, 100);
                this.panelTop.TabIndex = 0;
                // 
                // btnSeleccionarFactura
                // 
                this.btnSeleccionarFactura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
                this.btnSeleccionarFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnSeleccionarFactura.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
                this.btnSeleccionarFactura.ForeColor = System.Drawing.Color.White;
                this.btnSeleccionarFactura.Location = new System.Drawing.Point(20, 20);
                this.btnSeleccionarFactura.Name = "btnSeleccionarFactura";
                this.btnSeleccionarFactura.Size = new System.Drawing.Size(160, 35);
                this.btnSeleccionarFactura.TabIndex = 0;
                this.btnSeleccionarFactura.Text = "📄 Buscar Factura";
                this.btnSeleccionarFactura.UseVisualStyleBackColor = false;
                this.btnSeleccionarFactura.Click += new System.EventHandler(this.btnSeleccionarFactura_Click);
                // 
                // lblFacturaInfo
                // 
                this.lblFacturaInfo.AutoSize = true;
                this.lblFacturaInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
                this.lblFacturaInfo.Location = new System.Drawing.Point(195, 28);
                this.lblFacturaInfo.Name = "lblFacturaInfo";
                this.lblFacturaInfo.Size = new System.Drawing.Size(258, 19);
                this.lblFacturaInfo.TabIndex = 1;
                this.lblFacturaInfo.Text = "Factura: No seleccionada (SCRUM-14)...";
                // 
                // txtOrdenCompra
                // 
                this.txtOrdenCompra.Location = new System.Drawing.Point(150, 65);
                this.txtOrdenCompra.Name = "txtOrdenCompra";
                this.txtOrdenCompra.Size = new System.Drawing.Size(200, 23);
                this.txtOrdenCompra.TabIndex = 2;
                // 
                // lblOC
                // 
                this.lblOC.AutoSize = true;
                this.lblOC.Location = new System.Drawing.Point(20, 68);
                this.lblOC.Name = "lblOC";
                this.lblOC.Size = new System.Drawing.Size(124, 15);
                this.lblOC.TabIndex = 3;
                this.lblOC.Text = "Orden de Compra Int.:";
                // 
                // dgvRemitos
                // 
                this.dgvRemitos.AllowUserToAddRows = false;
                this.dgvRemitos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                this.dgvRemitos.BackgroundColor = System.Drawing.Color.White;
                dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
                dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
                dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
                dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
                dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                this.dgvRemitos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
                this.dgvRemitos.ColumnHeadersHeight = 30;
                this.dgvRemitos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.id_remito,
            this.nro_remito,
            this.fecha_entrada});
                this.dgvRemitos.EnableHeadersVisualStyles = false;
                this.dgvRemitos.Location = new System.Drawing.Point(20, 140);
                this.dgvRemitos.Name = "dgvRemitos";
                this.dgvRemitos.RowHeadersVisible = false;
                this.dgvRemitos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
                this.dgvRemitos.Size = new System.Drawing.Size(740, 280);
                this.dgvRemitos.TabIndex = 1;
                // 
                // colCheck
                // 
                this.colCheck.FillWeight = 50F;
                this.colCheck.HeaderText = "Asociar";
                this.colCheck.Name = "colCheck";
                // 
                // id_remito
                // 
                this.id_remito.HeaderText = "ID";
                this.id_remito.Name = "id_remito";
                this.id_remito.Visible = false;
                // 
                // nro_remito
                // 
                this.nro_remito.HeaderText = "Nro. Remito (SCRUM-16)";
                this.nro_remito.Name = "nro_remito";
                // 
                // fecha_entrada
                // 
                this.fecha_entrada.HeaderText = "Fecha de Ingreso";
                this.fecha_entrada.Name = "fecha_entrada";
                // 
                // lblTituloRemitos
                // 
                this.lblTituloRemitos.AutoSize = true;
                this.lblTituloRemitos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
                this.lblTituloRemitos.Location = new System.Drawing.Point(20, 115);
                this.lblTituloRemitos.Name = "lblTituloRemitos";
                this.lblTituloRemitos.Size = new System.Drawing.Size(326, 19);
                this.lblTituloRemitos.TabIndex = 2;
                this.lblTituloRemitos.Text = "Remitos Pendientes de Asociación (Mismo Prov):";
                // 
                // panelBottom
                // 
                this.panelBottom.Controls.Add(this.btnRegistrar);
                this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
                this.panelBottom.Location = new System.Drawing.Point(0, 441);
                this.panelBottom.Name = "panelBottom";
                this.panelBottom.Size = new System.Drawing.Size(784, 70);
                this.panelBottom.TabIndex = 3;
                // 
                // btnRegistrar
                // 
                this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
                this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnRegistrar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
                this.btnRegistrar.ForeColor = System.Drawing.Color.White;
                this.btnRegistrar.Location = new System.Drawing.Point(560, 10);
                this.btnRegistrar.Name = "btnRegistrar";
                this.btnRegistrar.Size = new System.Drawing.Size(200, 45);
                this.btnRegistrar.TabIndex = 0;
                this.btnRegistrar.Text = "REGISTRAR COMPRA";
                this.btnRegistrar.UseVisualStyleBackColor = false;
                this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
                // 
                // lblAyuda
                // 
                this.lblAyuda.AutoSize = true;
                this.lblAyuda.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
                this.lblAyuda.ForeColor = System.Drawing.Color.Gray;
                this.lblAyuda.Location = new System.Drawing.Point(20, 423);
                this.lblAyuda.Name = "lblAyuda";
                this.lblAyuda.Size = new System.Drawing.Size(433, 13);
                this.lblAyuda.TabIndex = 4;
                this.lblAyuda.Text = "* Al registrar, se vinculan permanentemente los documentos para el Informe de Com" +
        "pras.";
                // 
                // RegistrarCompra
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.BackColor = System.Drawing.Color.White;
                this.ClientSize = new System.Drawing.Size(784, 511);
                this.Controls.Add(this.lblAyuda);
                this.Controls.Add(this.panelBottom);
                this.Controls.Add(this.lblTituloRemitos);
                this.Controls.Add(this.dgvRemitos);
                this.Controls.Add(this.panelTop);
                this.Font = new System.Drawing.Font("Segoe UI", 9F);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                this.Name = "RegistrarCompra";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "SurFe - Registrar Operación de Compra Completa";
                this.panelTop.ResumeLayout(false);
                this.panelTop.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(this.dgvRemitos)).EndInit();
                this.panelBottom.ResumeLayout(false);
                this.ResumeLayout(false);
                this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.Panel panelTop;
            private System.Windows.Forms.Button btnSeleccionarFactura;
            private System.Windows.Forms.Label lblFacturaInfo;
            private System.Windows.Forms.TextBox txtOrdenCompra;
            private System.Windows.Forms.Label lblOC;
            private System.Windows.Forms.DataGridView dgvRemitos;
            private System.Windows.Forms.Label lblTituloRemitos;
            private System.Windows.Forms.Panel panelBottom;
            private System.Windows.Forms.Button btnRegistrar;
            private System.Windows.Forms.Label lblAyuda;
            private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
            private System.Windows.Forms.DataGridViewTextBoxColumn id_remito;
            private System.Windows.Forms.DataGridViewTextBoxColumn nro_remito;
            private System.Windows.Forms.DataGridViewTextBoxColumn fecha_entrada;
        }
    }