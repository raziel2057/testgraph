using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToExcel;

namespace testGraph
{
    public class Datos
    {
        private static Datos instance;
        private List<Fijos> listado;

        private double vMax;
        private double vMin;
        private List<double> vf;
        private List<double> vg;

        private double sMax;
        private double sMin;
        private List<double> listadoS;

        public List<double> ListadoS
        {
            get { return listadoS; }
            set { listadoS = value; }
        }
        private List<double> sf;
        private List<double> sg;

        public double SMax
        {
            get { return sMax; }
            set { sMax = value; }
        }
        

        public double SMin
        {
            get { return sMin; }
            set { sMin = value; }
        }
        

        public List<double> Sf
        {
            get { return sf; }
            set { sf = value; }
        }
        

        public List<double> Sg
        {
            get { return sg; }
            set { sg = value; }
        }


        public List<double> Vf
        {
            get { return vf; }
            set { vf = value; }
        }

        public List<double> Vg
        {
            get { return vg; }
            set { vg = value; }
        }

        internal List<Fijos> Listado
        {
            get { return listado; }
            set { listado = value; }
        }
        

        public double VMax
        {
            get { return vMax; }
            set { vMax = value; }
        }
        

        public double VMin
        {
            get { return vMin; }
            set { vMin = value; }
        }


        private Datos()
        {
            this.listado = new List<Fijos>();
            Formulacion f = new Formulacion();
            this.listadoS = new List<double>();
            this.sf = new List<double>();
            this.sg = new List<double>();
          

            for (double i = 273.15d; i < 623.15d; i += 1)
            {
                double sL = f.s_LSat(i);
                double sG = f.s_GSat(i);
                if(!double.IsNaN(sL))
                    this.sf.Add(sL);
                if (!double.IsNaN(sG))
                    this.sg.Add(sG);
                
            }
            for (double i = 623.15d; i <= 647.096d; i += 0.001)
            {
                double sL = f.s_LSat(i);
                double sG = f.s_GSat(i);
                if (!double.IsNaN(sL))
                    this.sf.Add(sL);
                if (!double.IsNaN(sG))
                    this.sg.Add(sG);

            }

            List<double> sfAux = new List<double>();
            sfAux.AddRange(this.sf);
            List<double> sgAux = new List<double>();
            sgAux.AddRange(this.sg);
            sgAux.Reverse();
            this.listadoS.AddRange(sfAux);
            this.listadoS.AddRange(sgAux);
            sMax = listadoS[listadoS.Count - 1];
            sMin = listadoS[0];


            Console.Out.WriteLine("dsdad");
            /*string startupPath = System.IO.Directory.GetCurrentDirectory();
            this.listado = this.obtenerDatosFijos(startupPath+@"\PropSaturacion.xlsx");

            vf = new List<double>();
            vg = new List<double>();

            for (int i = 0; i < listado.Count / 2; i++)
            {
                vf.Add(listado[i].v);
            }
            for (int i = listado.Count / 2; i < listado.Count; i++)
            {
                vg.Add(listado[i].v);
            }

            vg.Reverse();
            vMax = listado[listado.Count - 1].v;
            vMin = listado[0].v;

            // datos S

            sf = new List<double>();
            sg = new List<double>();

            for (int i = 0; i < listado.Count / 2; i++)
            {
                sf.Add(listado[i].s);
            }
            for (int i = listado.Count / 2; i < listado.Count; i++)
            {
                sg.Add(listado[i].s);
            }

            sg.Reverse();
            sMax = listado[listado.Count - 1].s;
            sMin = listado[0].s;*/


            
        
        }

        public static Datos Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Datos();
                }
                return instance;
            }
        }

        private List<Fijos> obtenerDatosFijos(string pathDelFicheroExcel)
        {


            var book = new ExcelQueryFactory(pathDelFicheroExcel);
            var resultado = (from row in book.Worksheet("propsat")
                             let item = new Fijos
                             {
                                 v = row["v"].Cast<double>(),
                                 s = row["s"].Cast<double>(),
                                 h = row["h"].Cast<double>()
                             }
                             select item).ToList();

            book.Dispose();
            return resultado;
        }


    }
}
