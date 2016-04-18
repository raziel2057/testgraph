using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testGraph
{
    public class Formulacion
    {
        public double Psat(double T )
        {
            //'Presion de saturacion
       
            const double a1  = -7.85951783;
            const double a2 = 1.84408259;
            const double a3 = -11.7866497;
            const double a4  = 22.6807411;
            const double a5 = -15.9618719;
            const double a6  = 1.80122502;
            const double Tc  = 647.096  ; //'Kelvin
            const double pc  = 22064000 ; //  'kPa
            double Psat_var = (Math.Exp((Tc / T) * ((a1 * Math.Pow(1D - (T / Tc), 1d)) + (a2 * Math.Pow(1D - (T / Tc), 1.5D)) + (a3 * Math.Pow(1D - (T / Tc), 3D)) + (a4 * Math.Pow(1D - (T / Tc), 3.5D)) + (a5 * Math.Pow(1D - (T / Tc), 4D)) + (a6 * Math.Pow(1D - (T / Tc), 7.5D))))) * pc * 0.000001D;
            return Psat_var;
        }

        public double DerPsat(double T)
        {
           // 'derivada de la presion
            const double a1 = -7.85951783;
            const double a2 = 1.84408259;
            const double a3 = -11.7866497;
            const double a4 = 22.6807411;
            const double a5 = -15.9618719;
            const double a6 = 1.80122502;
            double Tc = 647.096 ;  //'Kelvin
            double pc = 22.064  ;  //'MPa
            double Tt = 273.15;
            double DerPsat_var = -(Psat(T) / T) * (Math.Log(Psat(T) / pc) + a1 + 1.5D * a2 * Math.Pow(1D - (T / Tc), 0.5D) + 3D * a3 * Math.Pow(1D - (T / Tc), 2D) + 3.5D * a4 * Math.Pow(1D - (T / Tc), 2.5D) + 4D * a5 * Math.Pow(1D - (T / Tc), 3D) + 7.5D * a6 * Math.Pow(1D - (T / Tc), 6.5D));
            return DerPsat_var;
        }

        public double phy(double T)
        {
            //'funcion de apoyo phy
            const double d1 = -0.0000000565134998;
            const double d2 = 2690.66631;
            const double d3 = 127.2873;
            const double d4 = -135.00344;
            const double d5 = 0.981825814;
            const double Tc = 647.096;
            const double Dphy = 2319.5246;
            const double phy0  = 0.001545365;
            double phy_var = (Dphy + 0.95D * d1 * Math.Pow((T / Tc), -20D) + d2 * Math.Log(T / Tc) + 1.285714286D * d3 * Math.Pow((T / Tc), 3.5D) + 1.25D * d4 * Math.Pow((T / Tc), 4D) + 1.018691589D * d5 * Math.Pow((T / Tc), 53.5D)) * phy0;
            return phy_var;
        }

        public double alpha(double T )
        {
            //'funcion de apoyo alfa
            const double d1 = -0.0000000565134998;
            const double d2 = 2690.66631;
            const double d3 = 127.2873;
            const double d4 = -135.00344;
            const double d5 = 0.981825814;
            const double Tc = 647.096;
            const double Dalpha = -1135.905627715;
            const double alpha0 = 1;
            double alpha_var = (Dalpha + d1 * Math.Pow(T / Tc, -19D) + d2 * Math.Pow(T / Tc, 1D) + d3 * Math.Pow(T / Tc, 4.5D) + d4 * Math.Pow(T / Tc, 5D) + d5 * Math.Pow(T / Tc, 54.5D)) * alpha0;
            return alpha_var;
        }

        public double vol_LSat(double T)
        {
            //'volumen saturacion liquido   v'=vf
            const double b1  = 1.99274064;
            const double b2  = 1.09965342;
            const double b3  = -0.510839303;
            const double b4  = -1.75493479;
            const double b5 = -45.5170352;
            const double b6  = -674694.45;
            const double rhoc  = 322;
            const double Tc  = 647.096  ;// 'Kelvin
           // 'Const pc As Double = 22064   'kPa
           // ' Dim tita As Double = 1 - T / Tc
            double vol_LSat_var = Math.Pow(((1 + b1 * Math.Pow(1 - T / Tc, 0.3333D) + b2 * Math.Pow(1 - T / Tc, 0.6666D) + b3 * Math.Pow(1 - T / Tc, 1.6666D) + b4 * Math.Pow(1 - T / Tc, 5.3333D) + b5 * Math.Pow(1 - T / Tc, 14.3333D) + b6 * Math.Pow(1 - T / Tc, 36.6666D)) * rhoc) , -1d);
            return vol_LSat_var;
        }

        public double vol_GSat(double T )
        {
           // 'volumen saturacion gaseoso   v''=vg

            const double c1 = -2.0315024;
            const double c2 = -2.6830294;
            const double c3 = -5.38626492;
            const double c4 = -17.2991605;
            const double c5 = -44.7586581;
            const double c6 = -63.9201063;
            const double rhoc = 322;
            double Tc = 647.096;   //'Kelvin
            double pc = 22064 ;   //'kPa
            double m ;
            m = (1 - (T / Tc));
            double vol_GSat_var = Math.Pow((rhoc * Math.Exp((c1 * (Math.Pow(m , 0.3333D))) + (c2 * (Math.Pow(m , 0.6666D))) + (c3 * (Math.Pow(m ,1.3333D))) + (c4 * (Math.Pow(m , 3D))) + (c5 * (Math.Pow(m , 6.1666D))) + (c6 * (Math.Pow(m , 11.8333D))))),-1d) ;
            return vol_GSat_var;
        }

        public double h_LSat(double T )
        {
            //'entalpia liquida h'=hf
            const double alpha0 = 1;
            double h_LSat_var = (alpha(T) / alpha0) + 1000 * (T * vol_LSat(T)) * DerPsat(T);
            return h_LSat_var;
        }

        public double h_GSat(double T )
        {
            //'entalpia gaseosa h''=hg

            const double alpha0 = 1;
            double h_GSat_var = (alpha(T) / alpha0) + 1000 * (T * vol_GSat(T)) * DerPsat(T);
            return h_GSat_var;
        }

        public double s_LSat(double T )
        {
            //'entropia liquida s'=sf

            double s_LSat_var = phy(T) + 1000 * (DerPsat(T)) * vol_LSat(T);
            return s_LSat_var;
        }

        public double s_GSat(double T )
        {
           // 'entropia gaseosa s''=sf

            double s_GSat_var = phy(T) + 1000 * (DerPsat(T)) * vol_GSat(T);
            return s_GSat_var;
        }
    }
}
