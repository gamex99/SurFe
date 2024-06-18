namespace SurFe
{
    partial class MDIParent1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParent1));
            menuStrip = new MenuStrip();
            fileMenu = new ToolStripMenuItem();
            nuevoProductoToolStripMenuItem = new ToolStripMenuItem();
            actualizarStockToolStripMenuItem = new ToolStripMenuItem();
            actualizarStockPorListaToolStripMenuItem = new ToolStripMenuItem();
            actualizarStockPorUnicoProductoToolStripMenuItem = new ToolStripMenuItem();
            bajaDeStockToolStripMenuItem = new ToolStripMenuItem();
            porRoturaToolStripMenuItem = new ToolStripMenuItem();
            antiguedadToolStripMenuItem = new ToolStripMenuItem();
            perdidaToolStripMenuItem = new ToolStripMenuItem();
            proveedorToolStripMenuItem = new ToolStripMenuItem();
            cargarRemitoDeCompraToolStripMenuItem = new ToolStripMenuItem();
            toolTip = new ToolTip(components);
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileMenu, actualizarStockToolStripMenuItem, proveedorToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(7, 2, 0, 2);
            menuStrip.Size = new Size(737, 24);
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
            // actualizarStockToolStripMenuItem
            // 
            actualizarStockToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { actualizarStockPorListaToolStripMenuItem, actualizarStockPorUnicoProductoToolStripMenuItem, bajaDeStockToolStripMenuItem });
            actualizarStockToolStripMenuItem.Name = "actualizarStockToolStripMenuItem";
            actualizarStockToolStripMenuItem.Size = new Size(103, 20);
            actualizarStockToolStripMenuItem.Text = "Actualizar Stock";
            // 
            // actualizarStockPorListaToolStripMenuItem
            // 
            actualizarStockPorListaToolStripMenuItem.Name = "actualizarStockPorListaToolStripMenuItem";
            actualizarStockPorListaToolStripMenuItem.Size = new Size(263, 22);
            actualizarStockPorListaToolStripMenuItem.Text = "Actualizar stock por lista";
            // 
            // actualizarStockPorUnicoProductoToolStripMenuItem
            // 
            actualizarStockPorUnicoProductoToolStripMenuItem.Name = "actualizarStockPorUnicoProductoToolStripMenuItem";
            actualizarStockPorUnicoProductoToolStripMenuItem.Size = new Size(263, 22);
            actualizarStockPorUnicoProductoToolStripMenuItem.Text = "Actualizar stock por unico producto";
            // 
            // bajaDeStockToolStripMenuItem
            // 
            bajaDeStockToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { porRoturaToolStripMenuItem, antiguedadToolStripMenuItem, perdidaToolStripMenuItem });
            bajaDeStockToolStripMenuItem.Name = "bajaDeStockToolStripMenuItem";
            bajaDeStockToolStripMenuItem.Size = new Size(263, 22);
            bajaDeStockToolStripMenuItem.Text = "Baja de stock";
            // 
            // porRoturaToolStripMenuItem
            // 
            porRoturaToolStripMenuItem.Name = "porRoturaToolStripMenuItem";
            porRoturaToolStripMenuItem.Size = new Size(136, 22);
            porRoturaToolStripMenuItem.Text = "Rotura";
            // 
            // antiguedadToolStripMenuItem
            // 
            antiguedadToolStripMenuItem.Name = "antiguedadToolStripMenuItem";
            antiguedadToolStripMenuItem.Size = new Size(136, 22);
            antiguedadToolStripMenuItem.Text = "Antiguedad";
            // 
            // perdidaToolStripMenuItem
            // 
            perdidaToolStripMenuItem.Name = "perdidaToolStripMenuItem";
            perdidaToolStripMenuItem.Size = new Size(136, 22);
            perdidaToolStripMenuItem.Text = "Perdida";
            // 
            // proveedorToolStripMenuItem
            // 
            proveedorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cargarRemitoDeCompraToolStripMenuItem });
            proveedorToolStripMenuItem.Name = "proveedorToolStripMenuItem";
            proveedorToolStripMenuItem.Size = new Size(73, 20);
            proveedorToolStripMenuItem.Text = "Proveedor";
            // 
            // cargarRemitoDeCompraToolStripMenuItem
            // 
            cargarRemitoDeCompraToolStripMenuItem.Name = "cargarRemitoDeCompraToolStripMenuItem";
            cargarRemitoDeCompraToolStripMenuItem.Size = new Size(207, 22);
            cargarRemitoDeCompraToolStripMenuItem.Text = "Cargar remito de compra";
            // 
            // MDIParent1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            ClientSize = new Size(737, 523);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MDIParent1";
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
        private ToolStripMenuItem actualizarStockToolStripMenuItem;
        private ToolStripMenuItem actualizarStockPorListaToolStripMenuItem;
        private ToolStripMenuItem actualizarStockPorUnicoProductoToolStripMenuItem;
        private ToolStripMenuItem bajaDeStockToolStripMenuItem;
        private ToolStripMenuItem porRoturaToolStripMenuItem;
        private ToolStripMenuItem antiguedadToolStripMenuItem;
        private ToolStripMenuItem perdidaToolStripMenuItem;
        private ToolStripMenuItem proveedorToolStripMenuItem;
        private ToolStripMenuItem cargarRemitoDeCompraToolStripMenuItem;
    }
}



