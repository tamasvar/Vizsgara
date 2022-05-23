using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI_Unitest
{
    public class Teglalap
    {
        public double A { get; set; }

        public double B { get; set; }

        public static double Terulet(double x, double y)
        {
            return Math.Round(x * y);
        }

        public static double Kerulet(double x, double y)
        {
            return 2 * (x + y);
        }

        public Teglalap(string sor)
        {
            string[] teglalapOldalak = sor.Split('\t');

            A = double.Parse(teglalapOldalak[0]);
            B = double.Parse(teglalapOldalak[1]);
        }
    }
}
