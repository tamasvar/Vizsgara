using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Datagrid2
{
    public class Teglalap
    {
        public double A { get; set; }

        public double B { get; set; }

        public Teglalap(string sor)
        {
            string[] teglalapOldalak = sor.Split("\t");

            A = double.Parse(teglalapOldalak[0]);
            B = double.Parse(teglalapOldalak[1]);
        }

        public Teglalap(double a, double b)
        {
            A = a;
            B = b;
        }
    }
}
