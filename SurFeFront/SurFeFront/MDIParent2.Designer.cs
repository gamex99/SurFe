namespace SurFe
{
    partial class MDIParent2
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
            menuStrip = new MenuStrip();
            porProductoToolStripMenuItem = new ToolStripMenuItem();
            porFaltanteToolStripMenuItem = new ToolStripMenuItem();
            stockActualToolStripMenuItem = new ToolStripMenuItem();
            toolTip = new ToolTip(components);
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { porProductoToolStripMenuItem, porFaltanteToolStripMenuItem, stockActualToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(7, 2, 0, 2);
            menuStrip.Size = new Size(737, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "MenuStrip";
            // 
            // porProductoToolStripMenuItem
            // 
            porProductoToolStripMenuItem.Name = "porProductoToolStripMenuItem";
            porProductoToolStripMenuItem.Size = new Size(89, 20);
            porProductoToolStripMenuItem.Text = "Por Producto";
            porProductoToolStripMenuItem.Click += porProductoToolStripMenuItem_Click;
            // 
            // porFaltanteToolStripMenuItem
            // 
            porFaltanteToolStripMenuItem.Name = "porFaltanteToolStripMenuItem";
            porFaltanteToolStripMenuItem.Size = new Size(82, 20);
            porFaltanteToolStripMenuItem.Text = "Por Faltante";
            // 
            // stockActualToolStripMenuItem
            // 
            stockActualToolStripMenuItem.Name = "stockActualToolStripMenuItem";
            stockActualToolStripMenuItem.Size = new Size(85, 20);
            stockActualToolStripMenuItem.Text = "Stock Actual";
            // 
            // MDIParent2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(737, 523);
            Controls.Add(menuStrip);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MDIParent2";
            Text = "MDIParent2";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion


        private MenuStrip menuStrip;
        private ToolTip toolTip;
        private ToolStripMenuItem porProductoToolStripMenuItem;
        private ToolStripMenuItem porFaltanteToolStripMenuItem;
        private ToolStripMenuItem stockActualToolStripMenuItem;
    }
}



