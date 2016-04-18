namespace testGraph
{
    partial class MenuPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gráficasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gráficasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(764, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gráficasToolStripMenuItem
            // 
            this.gráficasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tVToolStripMenuItem,
            this.tSToolStripMenuItem});
            this.gráficasToolStripMenuItem.Name = "gráficasToolStripMenuItem";
            this.gráficasToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.gráficasToolStripMenuItem.Text = "Gráficas";
            // 
            // tVToolStripMenuItem
            // 
            this.tVToolStripMenuItem.Name = "tVToolStripMenuItem";
            this.tVToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tVToolStripMenuItem.Text = "TV";
            this.tVToolStripMenuItem.Click += new System.EventHandler(this.tVToolStripMenuItem_Click);
            // 
            // tSToolStripMenuItem
            // 
            this.tSToolStripMenuItem.Name = "tSToolStripMenuItem";
            this.tSToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tSToolStripMenuItem.Text = "TS";
            this.tSToolStripMenuItem.Click += new System.EventHandler(this.tSToolStripMenuItem_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 295);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MenuPrincipal";
            this.Text = "Menu Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gráficasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tSToolStripMenuItem;
    }
}