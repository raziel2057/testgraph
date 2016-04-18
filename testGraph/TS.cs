using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace testGraph
{
    public partial class TS : Form
    {
        private Bitmap b;
        private Datos objDatos;

        public TS()
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
            int cont = 0;

            for (double i = 273.15d; i < 623.15d; i++)
            {
                double yPx = this.interpolarT(i,pbxGrafico.Height);
                
                for (int j = 0; j < objDatos.ListadoS.Count; j++)
                {
                    
                    double xPx = this.interpolarV500(objDatos.ListadoS[j]);
                    bool Pintar = false;
                    double x = 0.0d;
                    if ((double)cont <= (double)objDatos.ListadoS.Count / 2d - 1 && xPx < (double)pbxGrafico.Width)
                    {
                        x = (objDatos.ListadoS[j] - objDatos.Sf[cont]) / (objDatos.Sg[cont] - objDatos.Sf[cont]);

                        if (objDatos.Sg[cont] > objDatos.ListadoS[j] && objDatos.Sf[cont] < objDatos.ListadoS[j])
                            Pintar = true;
                    }
                    x = x * 100000000d;
                    //x = x * 500000000d+1000;
                    double color = x / 65535;

                    if (Pintar)
                    {

                        Color c = Color.FromArgb((int)color);
                        b.SetPixel((int)xPx, pbxGrafico.Height - 1 - (int)yPx, Color.FromArgb(c.R, c.G, c.B));
                        
                    }

                    


                }

                cont++;
            }




            for (double i = 623.15d; i < 647.096d; i+=0.001)
            {
                double yPx = this.interpolarT(i, pbxGrafico.Height);

                for (int j = 0; j < objDatos.ListadoS.Count; j++)
                {

                    double xPx = this.interpolarV500(objDatos.ListadoS[j]);
                    bool Pintar = false;
                    double x = 0.0d;
                    if ((double)cont <= (double)objDatos.ListadoS.Count / 2d - 1 && xPx < (double)pbxGrafico.Width)
                    {
                        x = (objDatos.ListadoS[j] - objDatos.Sf[cont]) / (objDatos.Sg[cont] - objDatos.Sf[cont]);

                        if (objDatos.Sg[cont] > objDatos.ListadoS[j] && objDatos.Sf[cont] < objDatos.ListadoS[j])
                            Pintar = true;
                    }
                    x = x * 100000000d;
                    //x = x * 500000000d+1000;
                    double color = x / 65535;

                    if (Pintar)
                    {

                        Color c = Color.FromArgb((int)color);
                        b.SetPixel((int)xPx, pbxGrafico.Height - 1 - (int)yPx, Color.FromArgb(c.R, c.G, c.B));

                    }




                }

                cont++;
            } 


            /*for (double i = 273.15; i < 1073.15; i++)
            {
                double yPx = this.interpolarT(i, pbxGrafico.Height);
                for (int j = 0; j < objDatos.Listado.Count; j++)
                {
                    double xPx = this.interpolarV500(objDatos.Listado[j].s);
                    bool Pintar = false;
                    double x = 0.0d;
                    if (yPx <= (double)objDatos.Listado.Count / 2d - 1 && xPx <= (double)pbxGrafico.Width)
                    {
                        x = (objDatos.Listado[j].s - objDatos.Sf[(int)yPx]) / (objDatos.Sg[(int)yPx] - objDatos.Sf[(int)yPx]);

                        if (objDatos.Sg[(int)yPx] >= objDatos.Listado[j].s && objDatos.Sf[(int)yPx] < objDatos.Listado[j].s)
                            Pintar = true;
                    }
                    x = x * 100000000d;
                    //x = x * 500000000d+1000;
                    double color = x / 65535;

                    if (Pintar)
                    {

                        Color c = Color.FromArgb((int)color);
                        b.SetPixel((int)xPx, pbxGrafico.Height - 1 - (int)yPx, Color.FromArgb(c.R, c.G, c.B));
                    }


                }


            } */
        }

        private double interpolarV(double v, int px)
        {
            return ((double)px / 600d) * ((60d / 21d) * v);
        }

        private double interpolarT(double t, int py)
        {

            return ((double)py / 600d) * (t - 273.15d);
        }

        private double interpolarV500(double v)
        {
            return (500d / (objDatos.SMax - objDatos.SMin)) * (v - objDatos.SMin);
        }

        private double interpolarT600(double t)
        {

            //return (3d / 4d) * (t - 273.15d);
            return (273.15d - 3d*t)/4d;
        }

        private void btnGuardarImagen_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
               int width = Convert.ToInt32(pbxGrafico.Width); 
               int height = Convert.ToInt32(pbxGrafico.Height); 
               Bitmap bmp = new Bitmap(width,height);        
               pbxGrafico.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
               bmp.Save(dialog.FileName, ImageFormat.Bmp);
            }
        }


    }
}
