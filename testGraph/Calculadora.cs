using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Math;

namespace testGraph
{
    public class Calculadora
    {
        private static Calculadora instance;

        //listas constantes
        private List<double> ci;
        private List<double> di;
        private List<double> ti;
        private List<double> nir;
        private double[,] matriz1;
        private double[,] matriz2;
        private double[,] matriz2Extras;
       
        
        // listas calculadas
        private List<double> fr;
        private List<double> frd;
        private List<double> frdd;
        private List<double> frt;
        private List<double> frtt;
        private List<double> frdt;


        //constantes
        private static double R = 0.46151805d;

        

        private double Tc = 647.10d;
        private double Pc = 22.06d;
        private double rc = 322.00d;

        // variables de entrada
        private double t;
        private double v;

        //variables calculadas
        private double tao;
        private double delta;

        //parte residual
        private double frCalc;
        private double frdCalc;
        private double frddCalc;
        private double frtCalc;
        private double frttCalc;
        private double frdtCalc;

        //parte ideal
        private double f0;
        private double f0d;
        private double f0dd;
        private double f0t;
        private double f0tt;
        private double f0dt;

        public double FrdtCalc
        {
            get { return frdtCalc; }
            set { frdtCalc = value; }
        }

        public double FrttCalc
        {
            get { return frttCalc; }
            set { frttCalc = value; }
        }

        public double FrtCalc
        {
            get { return frtCalc; }
            set { frtCalc = value; }
        }

        public double FrddCalc
        {
            get { return frddCalc; }
            set { frddCalc = value; }
        }

        public double FrdCalc
        {
            get { return frdCalc; }
            set { frdCalc = value; }
        }

        public double FrCalc
        {
            get { return frCalc; }
            set { frCalc = value; }
        }


        

        public double Tao
        {
            get { return tao; }
            set { tao = value; }
        }

        public double Delta
        {
            get { return delta; }
            set { delta = value; }
        }

        public double V
        {
            get { return v; }
            set { v = value; }
        }

        public double T
        {
            get { return t; }
            set { t = value; }
        }

        public List<double> Fr
        {
          get { return fr; }
          set { fr = value; }
        }

        public List<double> Nir
        {
            get { return nir; }
            set { nir = value; }
        }

        public List<double> Ti
        {
            get { return ti; }
            set { ti = value; }
        }

        public List<double> Di
        {
            get { return di; }
            set { di = value; }
        }

        public List<double> Ci
        {
            get { return ci; }
            set { ci = value; }
        }

        private Calculadora()
        {
            this.ci = new List<double>();
            this.cargarCi();

            this.di = new List<double>();
            this.cargarDi();

            this.ti = new List<double>();
            this.cargarTi();

            this.nir = new List<double>();
            this.cargarNir();

            this.cargarMatriz1();
            this.cargarMatriz2();
        }

        public static Calculadora Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Calculadora();
                }
                return instance;
            }
        }

        public void calculosGenerales()
        { 
            this.calcularTao();
            this.calcularDelta();

            this.calcularFr();
            double acum = 0;
            for (int i = 0; i < this.fr.Count; i++)
            {
                acum += this.fr[i];
            }           
            this.frCalc = acum;

            this.calcularFrd();
            acum = 0;
            for (int i = 0; i < this.frd.Count; i++)
            {
                acum += this.frd[i];
            }
            this.frdCalc = acum;

            this.calcularFrdd();
            acum = 0;
            for (int i = 0; i < this.frd.Count; i++)
            {
                acum += this.frdd[i];
            }
            this.frddCalc = acum;

            this.calcularFrt();
            acum = 0;
            for (int i = 0; i < this.frt.Count; i++)
            {
                acum += this.frt[i];
            }
            this.frtCalc = acum;

            this.calcularFrtt();
            acum = 0;
            for (int i = 0; i < this.frtt.Count; i++)
            {
                acum += this.frtt[i];
            }
            this.frttCalc = acum;

            this.calcularFrdt();
            acum = 0;
            for (int i = 0; i < this.frdt.Count; i++)
            {
                acum += this.frdt[i];
            }
            this.frdtCalc = acum;


            
        }

        private void calcularFrdt()
        {
            this.frdt = new List<double>();

            for (int i = 0; i < 7; i++)
            {
                double auxE = this.nir[i];
                double auxC = this.di[i];
                double auxD = this.ti[i];
                double auxB = this.ci[i];

                double calc = auxE * auxC * auxD * Math.Pow(this.delta, auxC - 1d) * Math.Pow(this.tao, auxD - 1d);
                this.frdt.Add(calc);
            }

            for (int i = 7; i < 51; i++)
            {
                double auxE = this.nir[i];
                double auxC = this.di[i];
                double auxD = this.ti[i];
                double auxB = this.ci[i];

                double calc = auxE * auxD * Math.Pow(this.delta, auxC - 1d) * Math.Pow(this.tao, auxD - 1d) * (auxC - auxB * Math.Pow(this.delta, auxB)) * Math.Exp(-Math.Pow(this.delta, auxB));
                this.frdt.Add(calc);
            }

            for (int i = 0; i < 3; i++)
            {
                double auxB = this.matriz1[i, 0];
                double auxC = this.matriz1[i, 1];
                double auxD = this.matriz1[i, 2];
                double auxE = this.matriz1[i, 3];
                double auxF = this.matriz1[i, 4];
                double auxG = this.matriz1[i, 5];
                double auxH = this.matriz1[i, 6];
                double auxI = this.matriz1[i, 7];

                double calc = auxE * Math.Pow(this.delta, auxC) * Math.Pow(this.tao, auxD) * Math.Exp(-auxF * Math.Pow(this.delta - auxI, 2d) - auxG * Math.Pow(this.tao - auxH, 2d)) * ((auxC / this.delta) - 2d * auxF * (this.delta - auxI)) * ((auxD / this.tao) - 2d * auxG * (this.tao - auxH));
                this.frdt.Add(calc);
            }

            this.calcularMatriz2Extras();

            for (int i = 0; i < 2; i++)
            {
                double auxB = this.matriz2[i, 0];
                double auxC = this.matriz2[i, 1];
                double auxD = this.matriz2[i, 2];
                double auxE = this.matriz2[i, 3];
                double auxF = this.matriz2[i, 4];
                double auxG = this.matriz2[i, 5];
                double auxH = this.matriz2[i, 6];
                double auxI = this.matriz2[i, 7];

                double auxJ = this.matriz2Extras[i, 0];
                double auxK = this.matriz2Extras[i, 1];
                double auxL = this.matriz2Extras[i, 2];
                double auxM = this.matriz2Extras[i, 3];
                double auxN = this.matriz2Extras[i, 4];
                double auxO = this.matriz2Extras[i, 5];
                double auxP = this.matriz2Extras[i, 6];
                double auxQ = this.matriz2Extras[i, 7];
                double auxR = this.matriz2Extras[i, 8];
                double auxS = this.matriz2Extras[i, 9];
                double auxT = this.matriz2Extras[i, 10];
                double auxU = this.matriz2Extras[i, 11];
                double auxV = this.matriz2Extras[i, 12];
                double auxW = this.matriz2Extras[i, 13];
                double auxX = this.matriz2Extras[i, 14];

                double calc = auxE * (Math.Pow(auxK, auxC) * (auxV + this.delta * auxX) + this.delta * auxO * auxV + auxQ * (auxL + this.delta * auxT) + auxS * this.delta * auxL);
                this.frdt.Add(calc);
            }

        }

        private void calcularFrtt()
        {
            this.frtt = new List<double>();

            for (int i = 0; i < 7; i++)
            {
                double auxE = this.nir[i];
                double auxC = this.di[i];
                double auxD = this.ti[i];
                double auxB = this.ci[i];

                double calc = auxE * auxD * (auxD - 1d) * Math.Pow(this.delta, auxC) * Math.Pow(this.tao, auxD - 2d);
                this.frtt.Add(calc);
            }

            for (int i = 7; i < 51; i++)
            {
                double auxE = this.nir[i];
                double auxC = this.di[i];
                double auxD = this.ti[i];
                double auxB = this.ci[i];

                double calc = auxE * auxD * (auxD - 1d) * Math.Pow(this.delta, auxC) * Math.Pow(this.tao, auxD - 2d) * Math.Exp(-Math.Pow(this.delta, auxB));
                this.frtt.Add(calc);
            }

            for (int i = 0; i < 3; i++)
            {
                double auxB = this.matriz1[i, 0];
                double auxC = this.matriz1[i, 1];
                double auxD = this.matriz1[i, 2];
                double auxE = this.matriz1[i, 3];
                double auxF = this.matriz1[i, 4];
                double auxG = this.matriz1[i, 5];
                double auxH = this.matriz1[i, 6];
                double auxI = this.matriz1[i, 7];

                double calc = auxE*Math.Pow(this.delta,auxC)*Math.Pow(this.tao,auxD)*Math.Exp(-auxF*Math.Pow(this.delta-auxI,2d)-auxG*Math.Pow(this.tao-auxH,2d))*(Math.Pow((auxD/this.tao)-2d*auxG*(this.tao-auxH),2d)-(auxD/Math.Pow(this.tao,2d))-2d*auxG);
                this.frtt.Add(calc);
            }

            this.calcularMatriz2Extras();

            for (int i = 0; i < 2; i++)
            {
                double auxB = this.matriz2[i, 0];
                double auxC = this.matriz2[i, 1];
                double auxD = this.matriz2[i, 2];
                double auxE = this.matriz2[i, 3];
                double auxF = this.matriz2[i, 4];
                double auxG = this.matriz2[i, 5];
                double auxH = this.matriz2[i, 6];
                double auxI = this.matriz2[i, 7];

                double auxJ = this.matriz2Extras[i, 0];
                double auxK = this.matriz2Extras[i, 1];
                double auxL = this.matriz2Extras[i, 2];
                double auxM = this.matriz2Extras[i, 3];
                double auxN = this.matriz2Extras[i, 4];
                double auxO = this.matriz2Extras[i, 5];
                double auxP = this.matriz2Extras[i, 6];
                double auxQ = this.matriz2Extras[i, 7];
                double auxR = this.matriz2Extras[i, 8];
                double auxS = this.matriz2Extras[i, 9];
                double auxT = this.matriz2Extras[i, 10];
                double auxU = this.matriz2Extras[i, 11];
                double auxV = this.matriz2Extras[i, 12];
                double auxW = this.matriz2Extras[i, 13];
                double auxX = this.matriz2Extras[i, 14];

                double calc = auxE * this.delta * (auxR * auxL + 2d * auxQ * auxV + Math.Pow(auxK, auxC) * auxW);
                this.frtt.Add(calc);
            }

        }

        private void calcularFrt()
        {
            this.frt = new List<double>();

            for (int i = 0; i < 7; i++)
            {
                double auxE = this.nir[i];
                double auxC = this.di[i];
                double auxD = this.ti[i];
                double auxB = this.ci[i];

                double calc = auxE * auxD * Math.Pow(this.delta, auxC) * Math.Pow(this.tao, auxD - 1d);
                this.frt.Add(calc);
            }

            for (int i = 7; i < 51; i++)
            {
                double auxE = this.nir[i];
                double auxC = this.di[i];
                double auxD = this.ti[i];
                double auxB = this.ci[i];

                double calc = auxE * auxD * Math.Pow(this.delta, auxC) * Math.Pow(this.tao, auxD - 1d) * Math.Exp(-Math.Pow(this.delta, auxB));
                this.frt.Add(calc);
            }

            for (int i = 0; i < 3; i++)
            {
                double auxB = this.matriz1[i, 0];
                double auxC = this.matriz1[i, 1];
                double auxD = this.matriz1[i, 2];
                double auxE = this.matriz1[i, 3];
                double auxF = this.matriz1[i, 4];
                double auxG = this.matriz1[i, 5];
                double auxH = this.matriz1[i, 6];
                double auxI = this.matriz1[i, 7];

                double calc = auxE * Math.Pow(this.delta, auxC) * Math.Pow(this.tao, auxD) * Math.Exp(-auxF * Math.Pow(this.delta - auxI, 2d) - auxG * Math.Pow(this.tao - auxH, 2d)) * ((auxD / this.tao) - 2d * auxG * (this.tao - auxH));
                this.frt.Add(calc);
            }

            this.calcularMatriz2Extras();

            for (int i = 0; i < 2; i++)
            {
                double auxB = this.matriz2[i, 0];
                double auxC = this.matriz2[i, 1];
                double auxD = this.matriz2[i, 2];
                double auxE = this.matriz2[i, 3];
                double auxF = this.matriz2[i, 4];
                double auxG = this.matriz2[i, 5];
                double auxH = this.matriz2[i, 6];
                double auxI = this.matriz2[i, 7];

                double auxJ = this.matriz2Extras[i, 0];
                double auxK = this.matriz2Extras[i, 1];
                double auxL = this.matriz2Extras[i, 2];
                double auxM = this.matriz2Extras[i, 3];
                double auxN = this.matriz2Extras[i, 4];
                double auxO = this.matriz2Extras[i, 5];
                double auxP = this.matriz2Extras[i, 6];
                double auxQ = this.matriz2Extras[i, 7];
                double auxR = this.matriz2Extras[i, 8];
                double auxS = this.matriz2Extras[i, 9];
                double auxT = this.matriz2Extras[i, 10];
                double auxU = this.matriz2Extras[i, 11];
                double auxV = this.matriz2Extras[i, 12];
                double auxW = this.matriz2Extras[i, 13];
                double auxX = this.matriz2Extras[i, 14];

                double calc = auxE * this.delta * (auxQ * auxL + Math.Pow(auxK, auxC) * auxV);
                this.frt.Add(calc);
            }

        }

        private void calcularFrdd()
        {
            this.frdd = new List<double>();

            for (int i = 0; i < 7; i++)
            {
                double auxE = this.nir[i];
                double auxC = this.di[i];
                double auxD = this.ti[i];
                double auxB = this.ci[i];

                double calc = auxE * auxC * (auxC - 1d) * Math.Pow(this.delta, auxC - 2d) * Math.Pow(this.tao, auxD);
                this.frdd.Add(calc);
            }

            for (int i = 7; i < 51; i++)
            {
                double auxE = this.nir[i];
                double auxC = this.di[i];
                double auxD = this.ti[i];
                double auxB = this.ci[i];

                double calc = auxE * Math.Exp(-Math.Pow(this.delta, auxB)) * (Math.Pow(this.delta, auxC - 2d) * Math.Pow(this.tao, auxD) * ((auxC - auxB * Math.Pow(this.delta, auxB)) * (auxC - 1d - auxB * Math.Pow(this.delta, auxB)) - Math.Pow(auxB, 2d) * Math.Pow(this.delta, auxB)));
                this.frdd.Add(calc);
            }

            for (int i = 0; i < 3; i++)
            {
                double auxB = this.matriz1[i, 0];
                double auxC = this.matriz1[i, 1];
                double auxD = this.matriz1[i, 2];
                double auxE = this.matriz1[i, 3];
                double auxF = this.matriz1[i, 4];
                double auxG = this.matriz1[i, 5];
                double auxH = this.matriz1[i, 6];
                double auxI = this.matriz1[i, 7];

                double calc = auxE * Math.Pow(this.tao, auxD) * Math.Exp(-auxF * Math.Pow(this.delta - auxI, 2d) - auxG * Math.Pow(this.tao - auxH, 2d)) * (-2d * auxF * Math.Pow(this.delta, auxC) + 4d * Math.Pow(auxF, 2d) * Math.Pow(this.delta - auxI, 2d) - 4d * auxC * auxF * Math.Pow(this.delta, auxC - 1d) * (this.delta - auxI) + auxC * (auxC - 1d) * Math.Pow(this.delta, auxC - 2d));
                this.frdd.Add(calc);
            }

            this.calcularMatriz2Extras();

            for (int i = 0; i < 2; i++)
            {
                double auxB = this.matriz2[i, 0];
                double auxC = this.matriz2[i, 1];
                double auxD = this.matriz2[i, 2];
                double auxE = this.matriz2[i, 3];
                double auxF = this.matriz2[i, 4];
                double auxG = this.matriz2[i, 5];
                double auxH = this.matriz2[i, 6];
                double auxI = this.matriz2[i, 7];

                double auxJ = this.matriz2Extras[i, 0];
                double auxK = this.matriz2Extras[i, 1];
                double auxL = this.matriz2Extras[i, 2];
                double auxM = this.matriz2Extras[i, 3];
                double auxN = this.matriz2Extras[i, 4];
                double auxO = this.matriz2Extras[i, 5];
                double auxP = this.matriz2Extras[i, 6];
                double auxQ = this.matriz2Extras[i, 7];
                double auxR = this.matriz2Extras[i, 8];
                double auxS = this.matriz2Extras[i, 9];
                double auxT = this.matriz2Extras[i, 10];
                double auxU = this.matriz2Extras[i, 11];
                double auxV = this.matriz2Extras[i, 12];
                double auxW = this.matriz2Extras[i, 13];
                double auxX = this.matriz2Extras[i, 14];

                double calc = auxE * (Math.Pow(auxK, auxC) * (2d * auxT + this.delta * auxU) + 2d * auxO * (auxL + this.delta * auxT) + auxN * this.delta * auxL);
                this.frdd.Add(calc);
            }

        }

        private void calcularFrd()
        {
            this.frd = new List<double>();

            for (int i = 0; i < 7; i++)
            {
                double auxE = this.nir[i];
                double auxC = this.di[i];
                double auxD = this.ti[i];
                double auxB = this.ci[i];

                double calc = auxE * auxC * Math.Pow(this.delta, auxC - 1d) * Math.Pow(this.tao, auxD);
                this.frd.Add(calc);
            }

            for (int i = 7; i < 51; i++)
            {
                double auxE = this.nir[i];
                double auxC = this.di[i];
                double auxD = this.ti[i];
                double auxB = this.ci[i];

                double calc = auxE * Math.Exp(-Math.Pow(this.delta, auxB)) * (Math.Pow(this.delta, auxC - 1d) * Math.Pow(this.tao, auxD) * (auxC - auxB * Math.Pow(this.delta, auxB)));
                this.frd.Add(calc);
            }

            for (int i = 0; i < 3; i++)
            {
                double auxB = this.matriz1[i, 0];
                double auxC = this.matriz1[i, 1];
                double auxD = this.matriz1[i, 2];
                double auxE = this.matriz1[i, 3];
                double auxF = this.matriz1[i, 4];
                double auxG = this.matriz1[i, 5];
                double auxH = this.matriz1[i, 6];
                double auxI = this.matriz1[i, 7];

                double calc = auxE * Math.Pow(this.delta, auxC) * Math.Pow(this.tao, auxD) * Math.Exp(-auxF * Math.Pow(this.delta - auxI, 2d) - auxG * Math.Pow(this.tao - auxH, 2d)) * ((auxC / this.delta) - 2d * auxF * (this.delta - auxI));
                this.frd.Add(calc);
            }

            this.calcularMatriz2Extras();

            for (int i = 0; i < 2; i++)
            {
                double auxB = this.matriz2[i, 0];
                double auxC = this.matriz2[i, 1];
                double auxD = this.matriz2[i, 2];
                double auxE = this.matriz2[i, 3];
                double auxF = this.matriz2[i, 4];
                double auxG = this.matriz2[i, 5];
                double auxH = this.matriz2[i, 6];
                double auxI = this.matriz2[i, 7];

                double auxJ = this.matriz2Extras[i, 0];
                double auxK = this.matriz2Extras[i, 1];
                double auxL = this.matriz2Extras[i, 2];
                double auxM = this.matriz2Extras[i, 3];
                double auxN = this.matriz2Extras[i, 4];
                double auxO = this.matriz2Extras[i, 5];
                double auxP = this.matriz2Extras[i, 6];
                double auxQ = this.matriz2Extras[i, 7];
                double auxR = this.matriz2Extras[i, 8];
                double auxS = this.matriz2Extras[i, 9];
                double auxT = this.matriz2Extras[i, 10];
                double auxU = this.matriz2Extras[i, 11];
                double auxV = this.matriz2Extras[i, 12];
                double auxW = this.matriz2Extras[i, 13];
                double auxX = this.matriz2Extras[i, 14];

                double calc = auxE * (Math.Pow(auxK, auxC) * (auxL + this.delta * auxT) + auxO * this.delta * auxL);
                this.frd.Add(calc);
            }

        }

        private void calcularFr()
        {
            this.fr = new List<double>();
            for (int i = 0; i < 7; i++)
            {
                double auxE = this.nir[i];
                double auxC = this.di[i];
                double auxD = this.ti[i];
                double auxB = this.ci[i];

                double calc = auxE * Math.Pow(this.delta, auxC) * Math.Pow(this.tao, auxD);
                this.fr.Add(calc);
            }

            for (int i = 7; i < 51; i++)
            {
                double auxE = this.nir[i];
                double auxC = this.di[i];
                double auxD = this.ti[i];
                double auxB = this.ci[i];
                
                double calc = auxE * Math.Pow(this.delta, auxC) * Math.Pow(this.tao, auxD)*Math.Exp(-Math.Pow(this.delta,auxB));
                this.fr.Add(calc);
            }

            for (int i = 0; i < 3; i++)
            {
                double auxB = this.matriz1[i, 0];
                double auxC = this.matriz1[i, 1];
                double auxD = this.matriz1[i, 2];
                double auxE = this.matriz1[i, 3];
                double auxF = this.matriz1[i, 4];
                double auxG = this.matriz1[i, 5];
                double auxH = this.matriz1[i, 6];
                double auxI = this.matriz1[i, 7];

                double calc = auxE * Math.Pow(this.delta, auxC) * Math.Pow(this.tao, auxD) * Math.Exp(-auxF*Math.Pow(this.delta-auxI,2d)-auxG*Math.Pow(this.tao-auxH,2d));
                this.fr.Add(calc);
            }

            this.calcularMatriz2Extras();

            for (int i = 0; i < 2; i++)
            {
                double auxB = this.matriz2[i, 0];
                double auxC = this.matriz2[i, 1];
                double auxD = this.matriz2[i, 2];
                double auxE = this.matriz2[i, 3];
                double auxF = this.matriz2[i, 4];
                double auxG = this.matriz2[i, 5];
                double auxH = this.matriz2[i, 6];
                double auxI = this.matriz2[i, 7];

                double auxJ = this.matriz2Extras[i, 0];
                double auxK = this.matriz2Extras[i, 1];
                double auxL = this.matriz2Extras[i, 2];
                double auxM = this.matriz2Extras[i, 3];
                double auxN = this.matriz2Extras[i, 4];
                double auxO = this.matriz2Extras[i, 5];
                double auxP = this.matriz2Extras[i, 6];
                double auxQ = this.matriz2Extras[i, 7];
                double auxR = this.matriz2Extras[i, 8];
                double auxS = this.matriz2Extras[i, 9];
                double auxT = this.matriz2Extras[i, 10];
                double auxU = this.matriz2Extras[i, 11];
                double auxV = this.matriz2Extras[i, 12];
                double auxW = this.matriz2Extras[i, 13];
                double auxX = this.matriz2Extras[i, 14];

                double calc = auxE * Math.Pow(auxK, auxC) * this.delta * auxL;
                this.fr.Add(calc);
            }

            
        }

        private void calcularTao()
        {
            this.tao = this.Tc / this.t;
        }

        private void calcularDelta()
        {
            this.delta =1d/( this.rc * this.v);
        }

        private void calcularMatriz2Extras()
        { 
            this.matriz2Extras = new double[2,15];

            for (int i = 0; i < 2; i++)
            {
                double auxB = this.matriz2[i, 0];
                double auxC = this.matriz2[i, 1];
                double auxD = this.matriz2[i, 2];
                double auxE = this.matriz2[i, 3];
                double auxF = this.matriz2[i, 4];
                double auxG = this.matriz2[i, 5];
                double auxH = this.matriz2[i, 6];
                double auxI = this.matriz2[i, 7];

                double auxJ = (1 - this.tao) + auxH * Math.Pow(Math.Pow(this.delta - 1d, 2d), (1d / (2d * auxI)));
                double auxK = Math.Pow(auxJ, 2d) + auxD * Math.Pow(Math.Pow(this.delta-1d,2d),auxB);
                double auxL = Math.Exp(-auxF*Math.Pow(this.delta-1d,2d)-auxG*Math.Pow(this.tao-1d,2d));
                double auxM = (this.delta - 1d) * (auxH * auxJ * (2d / auxI) * Math.Pow(Math.Pow(this.delta - 1d, 2d), (1d / (2d * auxI)) - 1d) + 2d * auxD * auxB * Math.Pow(Math.Pow(this.delta - 1d, 2d), auxB - 1d));
                double auxN = (1d / (this.delta - 1d)) * auxM + Math.Pow(this.delta - 1d, 2d) * (4d * auxD * auxB * (auxB - 1d) * Math.Pow(Math.Pow(this.delta - 1d, 2d), auxB - 2d) + 2d * Math.Pow(auxH, 2d) * Math.Pow(1d / auxI, 2d) * Math.Pow(Math.Pow(Math.Pow(this.delta - 1d, 2d), (1d / (2d * auxI)) - 1d), 2d) + auxH * auxJ * (4d / auxI) * ((1d / (2d * auxI)) - 1d) * Math.Pow(Math.Pow(this.delta - 1d, 2d), (1d / (2d * auxI)) - 2d));
                double auxO = auxC * Math.Pow(auxK,auxC-1d)*auxM;
                double auxP = auxC * (Math.Pow(auxK, auxC - 1d) * auxN + (auxC - 1d) * Math.Pow(auxK, auxC - 2d) * Math.Pow(auxM, 2d));
                double auxQ = -2d * auxJ * auxC * Math.Pow(auxK, auxC - 1d);
                double auxR = 2d * auxC * Math.Pow(auxK, auxC - 1d) + 4d * Math.Pow(auxJ, 2d) * auxC * (auxC - 1d) * Math.Pow(auxK, auxC - 2d);
                double auxS = -auxH * auxC * (2d / auxI) * Math.Pow(auxK, auxC - 1d) * (this.delta - 1d) * Math.Pow(Math.Pow(this.delta - 1d, 2d), (1d / (2d * auxI)) - 1d) - 2d * auxJ * auxC * (auxC - 1d) * Math.Pow(auxK, auxC - 2d) * auxM;
                double auxT = -2d * auxF * (this.delta - 1d) * auxL;
                double auxU = (2d * auxF * Math.Pow(this.delta - 1d, 2d) - 1d) * 2d * auxF * auxL;
                double auxV = -2d * auxG * (this.tao - 1d) * auxL;
                double auxW = (2d * auxG * Math.Pow(this.tao - 1d, 2d) - 1d) * 2d * auxG * auxL;
                double auxX = 4d * auxF * auxG * (this.delta - 1d) * (this.tao - 1d) * auxL;


                this.matriz2Extras[i, 0] = auxJ;
                this.matriz2Extras[i, 1] = auxK;
                this.matriz2Extras[i, 2] = auxL;
                this.matriz2Extras[i, 3] = auxM;
                this.matriz2Extras[i, 4] = auxN;
                this.matriz2Extras[i, 5] = auxO;
                this.matriz2Extras[i, 6] = auxP;
                this.matriz2Extras[i, 7] = auxQ;
                this.matriz2Extras[i, 8] = auxR;
                this.matriz2Extras[i, 9] = auxS;
                this.matriz2Extras[i, 10] = auxT;
                this.matriz2Extras[i, 11] = auxU;
                this.matriz2Extras[i, 12] = auxV;
                this.matriz2Extras[i, 13] = auxW;
                this.matriz2Extras[i, 14] = auxX;

            }
        }

        private void cargarMatriz1()
        { 
            this.matriz1 = new double[3,8];

            this.matriz1[0, 0] = 0.00d; this.matriz1[0, 1] = 3.00d; this.matriz1[0, 2] = 0.00d; this.matriz1[0, 3] = -31.306260323435d;
            this.matriz1[0, 4] = 20.00d; this.matriz1[0, 5] = 150.00d; this.matriz1[0, 6] = 1.21d; this.matriz1[0, 7] = 1.00d;

            this.matriz1[1, 0] = 0.00d; this.matriz1[1, 1] = 3.00d; this.matriz1[1, 2] = 1.00d; this.matriz1[1, 3] = 31.546140237781d;
            this.matriz1[1, 4] = 20.00d; this.matriz1[1, 5] = 150.00d; this.matriz1[1, 6] = 1.21d; this.matriz1[1, 7] = 1.00d;

            this.matriz1[2, 0] = 0.00d; this.matriz1[2, 1] = 3.00d; this.matriz1[2, 2] = 4.00d; this.matriz1[2, 3] = -2521.3154341695d;
            this.matriz1[2, 4] = 20.00d; this.matriz1[2, 5] = 250.00d; this.matriz1[2, 6] = 1.25d; this.matriz1[2, 7] = 1.00d;
        }

        private void cargarMatriz2()
        { 
            this.matriz2 = new double[2,8];

            this.matriz2[0, 0] = 3.50d; this.matriz2[0, 1] = 0.85d; this.matriz2[0, 2] = 0.20d; this.matriz2[0, 3] = -0.14874640856724d;
            this.matriz2[0, 4] = 28.00d; this.matriz2[0, 5] = 700.00d; this.matriz2[0, 6] = 0.32d; this.matriz2[0, 7] = 0.30d;

            this.matriz2[1, 0] = 3.50d; this.matriz2[1, 1] = 0.95d; this.matriz2[1, 2] = 0.20d; this.matriz2[1, 3] = 0.31806110878444d;
            this.matriz2[1, 4] = 32.00d; this.matriz2[1, 5] = 800.00d; this.matriz2[1, 6] = 0.32d; this.matriz2[1, 7] = 0.30d;
        }
        

        private void cargarNir()
        {           
            this.Nir.Add(0.012533547935523d);
            this.Nir.Add(7.895763472282800d);
            this.Nir.Add(-8.780320330356100d);
            this.Nir.Add(0.318025093454180d);
            this.Nir.Add(-0.261455338593580d);
            this.Nir.Add(-0.007819975168798d);
            this.Nir.Add(0.008808949310213d);

            this.Nir.Add(-0.668565723079650d);
            this.Nir.Add(0.204338109509650d);
            this.Nir.Add(-0.000066212605040d);
            this.Nir.Add(-0.192327211560020d);
            this.Nir.Add(-0.257090430034380d);
            this.Nir.Add(0.160748684862510d);
            this.Nir.Add(-0.040092828925807d);
            this.Nir.Add(0.000000393434226d);
            this.Nir.Add(-0.000007594137709d);
            this.Nir.Add(0.000562509793519d);
            this.Nir.Add(-0.000015608652257d);
            this.Nir.Add(0.000000001153800d);
            this.Nir.Add(0.000000365821651d);
            this.Nir.Add(-0.000000000001325d);
            this.Nir.Add(-0.000000000626396d);
            this.Nir.Add(-0.107936009089320d);
            this.Nir.Add(0.017611491008752d);
            this.Nir.Add(0.221322951675460d);
            this.Nir.Add(-0.402476697635280d);
            this.Nir.Add(0.580833999857590d);
            this.Nir.Add(0.004996914699081d);
            this.Nir.Add(-0.031358700712549d);
            this.Nir.Add(-0.743159297103410d);
            this.Nir.Add(0.478073299154800d);
            this.Nir.Add(0.020527940895948d);
            this.Nir.Add(-0.136364351103430d);
            this.Nir.Add(0.014180634400617d);
            this.Nir.Add(0.008332650488071d);
            this.Nir.Add(-0.029052336009585d);
            this.Nir.Add(0.038615085574206d);
            this.Nir.Add(-0.020393486513704d);
            this.Nir.Add(-0.001655405006373d);
            this.Nir.Add(0.001995557197954d);
            this.Nir.Add(0.000158703083242d);
            this.Nir.Add(-0.000016388568343d);
            this.Nir.Add(0.043613615723811d);
            this.Nir.Add(0.034994005463765d);
            this.Nir.Add(-0.076788197844621d);
            this.Nir.Add(0.022446277332006d);
            this.Nir.Add(-0.000062689710415d);
            this.Nir.Add(-0.000000000557111d);
            this.Nir.Add(-0.199057183544080d);
            this.Nir.Add(0.317774973307380d);
            this.Nir.Add(-0.118411824259810d);

            /*this.Nir.Add(-31.306260323435d);
            this.Nir.Add(31.546140237781d);
            this.Nir.Add(-2521.3154341695d);

            this.Nir.Add(-0.14874640856724d);
            this.Nir.Add(0.31806110878444d);*/

        }

        private void cargarTi()
        {
            this.Ti.Add(-0.500d);
            this.Ti.Add(0.875d);
            this.Ti.Add(1.000d);
            this.Ti.Add(0.500d);
            this.Ti.Add(0.750d);
            this.Ti.Add(0.375d);
            this.Ti.Add(1.000d);

            this.Ti.Add(4.000d);
            this.Ti.Add(6.000d);
            this.Ti.Add(12.000d);
            this.Ti.Add(1.000d);
            this.Ti.Add(5.000d);
            this.Ti.Add(4.000d);
            this.Ti.Add(2.000d);
            this.Ti.Add(13.000d);
            this.Ti.Add(9.000d);
            this.Ti.Add(3.000d);
            this.Ti.Add(4.000d);
            this.Ti.Add(11.000d);
            this.Ti.Add(4.000d);
            this.Ti.Add(13.000d);
            this.Ti.Add(1.000d);
            this.Ti.Add(7.000d);
            this.Ti.Add(1.000d);
            this.Ti.Add(9.000d);
            this.Ti.Add(10.000d);
            this.Ti.Add(10.000d);
            this.Ti.Add(3.000d);
            this.Ti.Add(7.000d);
            this.Ti.Add(10.000d);
            this.Ti.Add(10.000d);
            this.Ti.Add(6.000d);
            this.Ti.Add(10.000d);
            this.Ti.Add(10.000d);
            this.Ti.Add(1.000d);
            this.Ti.Add(2.000d);
            this.Ti.Add(3.000d);
            this.Ti.Add(4.000d);
            this.Ti.Add(8.000d);
            this.Ti.Add(6.000d);
            this.Ti.Add(9.000d);
            this.Ti.Add(8.000d);
            this.Ti.Add(16.000d);
            this.Ti.Add(22.000d);
            this.Ti.Add(23.000d);
            this.Ti.Add(23.000d);
            this.Ti.Add(10.000d);
            this.Ti.Add(50.000d);
            this.Ti.Add(44.000d);
            this.Ti.Add(46.000d);
            this.Ti.Add(50.000d);

            /*this.Ti.Add(0.000d);
            this.Ti.Add(1.000d);
            this.Ti.Add(4.000d);

            this.Ti.Add(0.200d);
            this.Ti.Add(0.200d);*/
            
        }

        private void cargarDi()
        {
            this.Di.Add(1d);
            this.Di.Add(1d);
            this.Di.Add(1d);
            this.Di.Add(2d);
            this.Di.Add(2d);
            this.Di.Add(3d);
            this.Di.Add(4d);

            this.Di.Add(1d);
            this.Di.Add(1d);
            this.Di.Add(1d);
            this.Di.Add(2d);
            this.Di.Add(2d);
            this.Di.Add(3d);
            this.Di.Add(4d);
            this.Di.Add(4d);
            this.Di.Add(5d);
            this.Di.Add(7d);
            this.Di.Add(9d);
            this.Di.Add(10d);
            this.Di.Add(11d);
            this.Di.Add(13d);
            this.Di.Add(15d);
            this.Di.Add(1d);
            this.Di.Add(2d);
            this.Di.Add(2d);
            this.Di.Add(2d);
            this.Di.Add(3d);
            this.Di.Add(4d);
            this.Di.Add(4d);
            this.Di.Add(4d);
            this.Di.Add(5d);
            this.Di.Add(6d);
            this.Di.Add(6d);
            this.Di.Add(7d);
            this.Di.Add(9d);
            this.Di.Add(9d);
            this.Di.Add(9d);
            this.Di.Add(9d);
            this.Di.Add(9d);
            this.Di.Add(10d);
            this.Di.Add(10d);
            this.Di.Add(12d);
            this.Di.Add(3d);
            this.Di.Add(4d);
            this.Di.Add(4d);
            this.Di.Add(5d);
            this.Di.Add(14d);
            this.Di.Add(3d);
            this.Di.Add(6d);
            this.Di.Add(6d);
            this.Di.Add(6d);

            /*this.Di.Add(3d);
            this.Di.Add(3d);
            this.Di.Add(3d);

            this.Di.Add(0.85d);
            this.Di.Add(0.95d);*/



        }

        private void cargarCi()
        {
            this.Ci.Add(0d);
            this.Ci.Add(0d);
            this.Ci.Add(0d);
            this.Ci.Add(0d);
            this.Ci.Add(0d);
            this.Ci.Add(0d);

            this.Ci.Add(1d);
            this.Ci.Add(1d);
            this.Ci.Add(1d);
            this.Ci.Add(1d);
            this.Ci.Add(1d);
            this.Ci.Add(1d);
            this.Ci.Add(1d);
            this.Ci.Add(1d);
            this.Ci.Add(1d);
            this.Ci.Add(1d);
            this.Ci.Add(1d);
            this.Ci.Add(1d);
            this.Ci.Add(1d);
            this.Ci.Add(1d);
            this.Ci.Add(1d);
            this.Ci.Add(1d);

            this.Ci.Add(2d);
            this.Ci.Add(2d);
            this.Ci.Add(2d);
            this.Ci.Add(2d);
            this.Ci.Add(2d);
            this.Ci.Add(2d);
            this.Ci.Add(2d);
            this.Ci.Add(2d);
            this.Ci.Add(2d);
            this.Ci.Add(2d);
            this.Ci.Add(2d);
            this.Ci.Add(2d);
            this.Ci.Add(2d);
            this.Ci.Add(2d);
            this.Ci.Add(2d);
            this.Ci.Add(2d);
            this.Ci.Add(2d);
            this.Ci.Add(2d);
            this.Ci.Add(2d);
            this.Ci.Add(2d);

            this.Ci.Add(3d);
            this.Ci.Add(3d);
            this.Ci.Add(3d);
            this.Ci.Add(3d);

            this.Ci.Add(4d);

            this.Ci.Add(6d);
            this.Ci.Add(6d);
            this.Ci.Add(6d);
            this.Ci.Add(6d);

            /*this.Ci.Add(0d);
            this.Ci.Add(0d);
            this.Ci.Add(0d);

            this.Ci.Add(3.5d);
            this.Ci.Add(3.5d);*/

        }
    }
}
