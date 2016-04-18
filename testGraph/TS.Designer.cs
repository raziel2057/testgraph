namespace testGraph
{
    partial class TS
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
            this.btnGraficar = new System.Windows.Forms.Button();
            this.pbxGrafico = new System.Windows.Forms.PictureBox();
            this.btnGuardarImagen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGrafico)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGraficar
            // 
            this.btnGraficar.Location = new System.Drawing.Point(546, 17);
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(75, 67);
            this.btnGraficar.TabIndex = 11;
            this.btnGraficar.Text = "Graficar";
            this.btnGraficar.UseVisualStyleBackColor = true;
            this.btnGraficar.Click += new System.EventHandler(this.btnGraficar_Click);
            // 
            // pbxGrafico
            // 
            this.pbxGrafico.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pbxGrafico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxGrafico.Location = new System.Drawing.Point(17, 17);
            this.pbxGrafico.Name = "pbxGrafico";
            this.pbxGrafico.Size = new System.Drawing.Size(500, 600);
            this.pbxGrafico.TabIndex = 10;
            this.pbxGrafico.TabStop = false;
            this.pbxGrafico.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxGrafico_Paint);
            // 
            // btnGuardarImagen
            // 
            this.btnGuardarImagen.Location = new System.Drawing.Point(546, 99);
            this.btnGuardarImagen.Name = "btnGuardarImagen";
            this.btnGuardarImagen.Size = new System.Drawing.Size(75, 67);
            this.btnGuardarImagen.TabIndex = 12;
            this.btnGuardarImagen.Text = "Guardar";
            this.btnGuardarImagen.UseVisualStyleBackColor = true;
            this.btnGuardarImagen.Click += new System.EventHandler(this.btnGuardarImagen_Click);
            // 
            // TS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 635);
            this.Controls.Add(this.btnGuardarImagen);
            this.Controls.Add(this.btnGraficar);
            this.Controls.Add(this.pbxGrafico);
            this.Name = "TS";
            this.Text = "TS";
            ((System.ComponentModel.ISupportInitialize)(this.pbxGrafico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGraficar;
        private System.Windows.Forms.PictureBox pbxGrafico;
        private System.Windows.Forms.Button btnGuardarImagen;
    }
}