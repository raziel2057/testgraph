using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinqToExcel;


namespace testGraph
{
    public partial class Form1 : Form
    {
        Bitmap b;
        List<Fijos> listado;
        double vMax;
        double vMin;
        public Form1()
        {
            InitializeComponent();
            /*string startupPath = System.IO.Directory.GetCurrentDirectory();

            string startupPath2 = Environment.CurrentDirectory;
            MessageBox.Show(startupPath);
            MessageBox.Show(startupPath2);*/

            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(b, pictureBox1.Bounds);
        }

        public void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            var fichero = @"C:\Users\RAUL\Documents\Visual Studio 2013\Projects\testGraph\testGraph\PropSaturacion.xlsx";
            listado = this.ToEntidadHojaExcelList(fichero);
            foreach (Fijos d in listado)
            {
                
                listBox1.Items.Add(d.v);
                listBox2.Items.Add(d.s);
                listBox3.Items.Add(d.h);
            }

            listBox1.Refresh();
            listBox2.Refresh();
            listBox3.Refresh();
            vMax = listado[listado.Count - 1].v;
            vMin = listado[0].v;
        }

        private List<Fijos> ToEntidadHojaExcelList(string pathDelFicheroExcel)
        {
            
            
            var book = new ExcelQueryFactory(pathDelFicheroExcel);
            var resultado = (from row in book.Worksheet("propsat")
                             let item = new Fijos
                             {
                                 v = row["s"].Cast<double>(),
                                 s = row["s"].Cast<double>(),
                                 h = row["h"].Cast<double>()
                             }
                             select item).ToList();

            book.Dispose();
            return resultado;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (b != null)
                pictureBox1.Image = (Image)b.Clone();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
           // Random r = new Random(System.Environment.TickCount);

            List<double> vf = new List<double>();
            List<double> vg = new List<double>();

            for (int i = 0; i < listado.Count / 2; i++)
            {
                vf.Add(listado[i].v);
            }
            for (int i=listado.Count / 2; i < listado.Count; i++)
            {
                vg.Add(listado[i].v);
            }

            vg.Reverse();

                /*b.Dispose();
                b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.DrawToBitmap(b, pictureBox1.Bounds);
                Graphics g = Graphics.FromImage(b);/*
            
            

                /*g.FillRectangle(Brushes.Black,
                                new Rectangle(r.Next(0, pictureBox1.Width),
                                              r.Next(0, pictureBox1.Height),
                                              r.Next(0, pictureBox1.Width),
                                              r.Next(0, pictureBox1.Height)));

                g.DrawLine(Pens.Blue, new Point(r.Next(0, pictureBox1.Width), r.Next(0, pictureBox1.Height)),
                                                  new Point(r.Next(0, pictureBox1.Width), r.Next(0, pictureBox1.Height)));*/

                for (double i = 273.15; i < 1073.15; i++)
                {
                    double yPx = this.interpolarT600(i);
                    for (int j = 0; j < listado.Count; j++)
                    {
                        double xPx = this.interpolarV500(listado[j].v);
                        bool Pintar = false;
                        if (yPx <= 374.0d && xPx<=499.0d)
                        {
                            
                            if (vg[(int)yPx] >= listado[j].v && vf[(int)yPx] < listado[j].v)
                                Pintar = true;
                        }

                        if (Pintar)
                            b.SetPixel((int)xPx, (int)yPx, Color.Fuchsia);


                    }




                    //b.SetPixel(r.Next(0, pictureBox1.Width),
                    //r.Next(0, pictureBox1.Height), Color.FromArgb(r.Next(0, 255),
                    // r.Next(0, 255),
                    //   r.Next(0, 255)
                    //  )
                    // );
                    /*double yPx = this.interpolarT(i, pictureBox1.Height);
                    for (int j = 0; j < listado.Count; j++)
                    {

                        double xPx = this.interpolarV(listado[j].v, pictureBox1.Width);
                        double x=0.0d;
                        bool Pintar = false;
                        if (yPx <= 374.0d)
                        {
                            x = (listado[j].v - vf[(int)yPx]) / (vg[(int)yPx] - vf[(int)yPx]);
                            if (vg[(int)yPx] >= listado[j].v && vf[(int)yPx] < listado[j].v)
                                Pintar = true;
                        }

                        double color = x / 65535;

                        if(Pintar)
                            b.SetPixel((int)xPx,(int)yPx,Color.Fuchsia);
                       // pictureBox1.Refresh();
                    


                    }*/


                }  
            
        }

        private double interpolarV(double v, int px)
        {
            return ((double)px / 600d) * ((60d / 21d) * v);
        }

        private double interpolarT(double t, int py)
        {

            return ((double)py / 800d) * (t - 273.15d);
        }

        private double interpolarV500(double v)
        {
            return (500d / (vMax - vMin)) * (v - vMin);
        }

        private double interpolarT600(double t)
        {

            return (3d / 4d) * (t - 273.15d);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Calculadora c = Calculadora.Instance;
            c.T = 647.00d;
            c.V = 0.002793296d;
            c.calculosGenerales();
        }

        


    }
}
