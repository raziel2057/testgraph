using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testGraph
{
    public partial class TV : Form
    {
        private Bitmap b;
        private Datos objDatos;
        public TV()
        {
            InitializeComponent();
            objDatos = Datos.Instance;
            b = new Bitmap(pbxGrafico.Width, pbxGrafico.Height);
            pbxGrafico.DrawToBitmap(b, pbxGrafico.Bounds);
        }

        private void pbxGrafico_Paint(object sender, PaintEventArgs e)
        {
            if (b != null)
                pbxGrafico.Image = (Image)b.Clone();
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            
            for (double i = 273.15; i < 1073.15; i++)
            {
                double yPx = this.interpolarT(i, pbxGrafico.Height);
                for (int j = 0; j < objDatos.Listado.Count; j++)
                {
                    double xPx = this.interpolarV(objDatos.Listado[j].v,pbxGrafico.Width);
                    bool Pintar = false;
                    double x = 0.0d;
                    if (yPx <= (double)objDatos.Listado.Count/2d - 1 && xPx <= (double)pbxGrafico.Width)
                    {
                        x = (objDatos.Listado[j].v - objDatos.Vf[(int)yPx]) / (objDatos.Vg[(int)yPx] - objDatos.Vf[(int)yPx]);

                        if (objDatos.Vg[(int)yPx] >= objDatos.Listado[j].v && objDatos.Vf[(int)yPx] < objDatos.Listado[j].v)
                            Pintar = true;
                    }
                    x = x * 10000000000d;
                    double color = x / 65535;

                    if (Pintar)
                    {
                        
                        Color c = Color.FromArgb((int)color);
                        b.SetPixel((int)xPx, pbxGrafico.Height - 1 - (int)yPx, Color.FromArgb(c.R,c.G,c.B));
                    }


                }


            } 
        }

        private double interpolarV(double v, int px)
        {
            return Math.Abs(((double)px / 600d) * ((60d / 21d) * Math.Log(v)));
        }

        private double interpolarT(double t, int py)
        {

            return ((double)py / 800d) * (t - 273.15d);
        }

        private double interpolarV500(double v)
        {
            return (500d / (objDatos.VMax - objDatos.VMin)) * (v - objDatos.VMin);
        }

        private double interpolarT600(double t)
        {

            return (3d / 4d) * (t - 273.15d);
        }

        private void TV_Load(object sender, EventArgs e)
        {

        }


    }
}
