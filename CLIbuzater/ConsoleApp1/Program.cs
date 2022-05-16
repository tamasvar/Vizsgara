using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1

{
    public class Rekord
    {
        public string Datum { get; set; }
        public double Kendioxid { get; set; }
        public double Nitrogenoxidok {get;set;}
        public double Szenmonoxid { get; set; }
        public double Ozon { get; set; }
        public double Szallopor { get; set; }

        public Rekord(string sor)
        {
            string[] darabok = sor.Split('\t');

            Datum = darabok[0];
            Kendioxid = double.Parse(darabok[1]);
            Nitrogenoxidok = double.Parse(darabok[2]);
            Szenmonoxid = double.Parse(darabok[3]);
            Ozon = double.Parse(darabok[4]);
            Szallopor = double.Parse(darabok[5]);
        }
    }
    public  class Program
    {
        
        static void Main(string[] args)
        {
            List<Rekord> list = new List<Rekord>();
            string[] sorok= File.ReadLines("buzater.txt",Encoding.UTF8).Skip(1).ToArray();
            foreach (string s in sorok)
            {
                list.Add(new Rekord(s));
            }
            
            double KDO_hatarertek = 20;

            Console.WriteLine("Rekord kén-dioxid értéke a 20-as határérték fölött:");
            foreach (Rekord r in list)
            {
                if (r.Kendioxid > KDO_hatarertek)
                {
                    Console.WriteLine($"\tdátum:{r.Datum}\t ken-dioxid:{r.Kendioxid}");
                }
            }
            double atlag=list.Average(r=>r.Kendioxid);
            Console.WriteLine($"Kendioxid átlaga:{Math.Round(atlag,2)}");

            double min = list.Min(r => r.Kendioxid);
            Console.WriteLine($"Kendioxid min:{min}");

            double max = list.Max(r => r.Kendioxid);
            Console.WriteLine($"Kendioxid max:{max}");
            Console.ReadKey();
        }

         public static bool Hatarertek(double hatarertek,double ertek)
        {
            if (ertek>hatarertek)
            {
                return true;
            }
            else
            {
              return false;
            }
            
        }

    }
}
