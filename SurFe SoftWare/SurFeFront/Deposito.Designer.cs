namespace SurFe
{
    partial class Deposito
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Deposito));
            menuStrip = new MenuStrip();
            fileMenu = new ToolStripMenuItem();
            nuevoProductoToolStripMenuItem = new ToolStripMenuItem();
            registrarStockToolStripMenuItem = new ToolStripMenuItem();
            consultarStockPorProductoToolStripMenuItem = new ToolStripMenuItem();
            bajaStockPorRoturaPerdidaToolStripMenuItem = new ToolStripMenuItem();
            toolTip = new ToolTip(components);
            controlPorInventarioToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileMenu, registrarStockToolStripMenuItem, consultarStockPorProductoToolStripMenuItem, bajaStockPorRoturaPerdidaToolStripMenuItem, controlPorInventarioToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(7, 2, 0, 2);
            menuStrip.Size = new Size(863, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { nuevoProductoToolStripMenuItem });
            fileMenu.ImageTransparentColor = SystemColors.ActiveBorder;
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(117, 20);
            fileMenu.Text = "Registrar Producto";
            fileMenu.Click += fileMenu_Click;
            // 
            // nuevoProductoToolStripMenuItem
            // 
            nuevoProductoToolStripMenuItem.Name = "nuevoProductoToolStripMenuItem";
            nuevoProductoToolStripMenuItem.Size = new Size(161, 22);
            nuevoProductoToolStripMenuItem.Text = "Nuevo Producto";
            nuevoProductoToolStripMenuItem.Click += nuevoProductoToolStripMenuItem_Click;
            // 
            // registrarStockToolStripMenuItem
            // 
            registrarStockToolStripMenuItem.Name = "registrarStockToolStripMenuItem";
            registrarStockToolStripMenuItem.Size = new Size(97, 20);
            registrarStockToolStripMenuItem.Text = "Registrar Stock";
            registrarStockToolStripMenuItem.Click += registrarStockToolStripMenuItem_Click;
            // 
            // consultarStockPorProductoToolStripMenuItem
            // 
            consultarStockPorProductoToolStripMenuItem.Name = "consultarStockPorProductoToolStripMenuItem";
            consultarStockPorProductoToolStripMenuItem.Size = new Size(175, 20);
            consultarStockPorProductoToolStripMenuItem.Text = "Consultar Stock Por Producto";
            consultarStockPorProductoToolStripMenuItem.Click += consultarStockPorProductoToolStripMenuItem_Click;
            // 
            // bajaStockPorRoturaPerdidaToolStripMenuItem
            // 
            bajaStockPorRoturaPerdidaToolStripMenuItem.Name = "bajaStockPorRoturaPerdidaToolStripMenuItem";
            bajaStockPorRoturaPerdidaToolStripMenuItem.Size = new Size(283, 20);
            bajaStockPorRoturaPerdidaToolStripMenuItem.Text = "Actualizar Stock Por Perdida, Rotura o Antiguedad";
            bajaStockPorRoturaPerdidaToolStripMenuItem.Click += bajaStockPorRoturaPerdidaToolStripMenuItem_Click;
            // 
            // controlPorInventarioToolStripMenuItem
            // 
            controlPorInventarioToolStripMenuItem.Name = "controlPorInventarioToolStripMenuItem";
            controlPorInventarioToolStripMenuItem.Size = new Size(136, 20);
            controlPorInventarioToolStripMenuItem.Text = "Control Por Inventario";
            controlPorInventarioToolStripMenuItem.Click += controlPorInventarioToolStripMenuItem_Click;
            // 
            // Deposito
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            ClientSize = new Size(863, 523);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Deposito";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Deposito";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion


        private MenuStrip menuStrip;
        private ToolStripMenuItem fileMenu;
        private ToolTip toolTip;
        private ToolStripMenuItem nuevoProductoToolStripMenuItem;
        private ToolStripMenuItem registrarStockToolStripMenuItem;
        private ToolStripMenuItem consultarStockPorProductoToolStripMenuItem;
        private ToolStripMenuItem bajaStockPorRoturaPerdidaToolStripMenuItem;
        private ToolStripMenuItem controlPorInventarioToolStripMenuItem;
    }
}



