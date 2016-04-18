namespace testGraph
{
    partial class TV
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
            this.pbxGrafico = new System.Windows.Forms.PictureBox();
            this.btnGraficar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGrafico)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxGrafico
            // 
            this.pbxGrafico.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pbxGrafico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxGrafico.Location = new System.Drawing.Point(28, 12);
            this.pbxGrafico.Name = "pbxGrafico";
            this.pbxGrafico.Size = new System.Drawing.Size(500, 600);
            this.pbxGrafico.TabIndex = 8;
            this.pbxGrafico.TabStop = false;
            this.pbxGrafico.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxGrafico_Paint);
            // 
            // btnGraficar
            // 
            this.btnGraficar.Location = new System.Drawing.Point(557, 12);
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(75, 67);
            this.btnGraficar.TabIndex = 9;
            this.btnGraficar.Text = "Graficar";
            this.btnGraficar.UseVisualStyleBackColor = true;
            this.btnGraficar.Click += new System.EventHandler(this.btnGraficar_Click);
            // 
            // TV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 635);
            this.Controls.Add(this.btnGraficar);
            this.Controls.Add(this.pbxGrafico);
            this.Name = "TV";
            this.Text = "TV";
            this.Load += new System.EventHandler(this.TV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxGrafico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxGrafico;
        private System.Windows.Forms.Button btnGraficar;
    }
}