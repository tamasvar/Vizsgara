using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDatagrid
{
    public class Futo
    {
        public int FutoId { get; set; }
        public string FutoNev { get; set; }
        public string Egyesulet { get; set; }

        public Futo() //adat feltöltés
        {

        }
        
        public Futo(string sor)
        {
            string[] darabok = sor.Split(';');
            
            FutoId = int.Parse(darabok[0]);
            FutoNev = darabok[1];
            Egyesulet = darabok[2];
        }
    }
}
