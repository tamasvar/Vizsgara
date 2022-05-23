-----------------Program.cs-----------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI_Unitest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1. lista létrehozása, adatok beolvasása
            List<Teglalap> teglalapLista = new List<Teglalap>();

            StreamReader sr = new StreamReader("teglalap.txt");

            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                teglalapLista.Add(new Teglalap(sr.ReadLine()));
            }
            #endregion

            #region 2. teszt kiíratása
            //Teszt kiíratás
            foreach (var item in teglalapLista)
            {
                Console.WriteLine(item.A + " " + item.B + " Terület: " + Teglalap.Terulet(item.A, item.B) + " Kerület: " + Teglalap.Kerulet(item.A, item.B));
            }
            #endregion

            #region 3. Max
            //Legnagyobb területű téglalap adatainak kiíratása
            double maxTerulet = 0;
            int index = 0;
            for(int i = 0; i < teglalapLista.Count(); i++) //Miért nem <=
            {
                if (Teglalap.Terulet(teglalapLista[i].A, teglalapLista[i].B) > maxTerulet)
                {
                    maxTerulet = Teglalap.Terulet(teglalapLista[i].A, teglalapLista[i].B);
                    index = i;
                }
            }

            Console.WriteLine("A legnagyobb területű téglalap oldalainak az adatai: A oldal: " + teglalapLista[index].A + " B oldal: " + teglalapLista[index].B);
            #endregion

            #region 4. Min
            //Legkisebb területű téglalap adatainak kiíratása
            double minTerulet = Teglalap.Terulet(teglalapLista[0].A, teglalapLista[0].B);
            int indexMin = 0;

            for (int i = 0; i < teglalapLista.Count(); i++)
            {
                if (Teglalap.Terulet(teglalapLista[i].A, teglalapLista[i].B) < minTerulet)
                {
                    minTerulet = Teglalap.Terulet(teglalapLista[i].A, teglalapLista[i].B);
                    indexMin = i;
                }
            }

            Console.WriteLine("A legkisebb területű téglalap oldalainak az adatai: A oldal: " + teglalapLista[indexMin].A + " B oldal: " + teglalapLista[indexMin].B);
            #endregion

          
            Console.ReadKey();
        }
    }
}
----------------Teglalap.cs --------------------

 using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
 using System.Threading.Tasks;

namespace CLI_Unitest{ 

public class Teglalap { 

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
------------------Test.cs------------

   using Microsoft.VisualStudio.TestTools.UnitTesting;
 using CLI_Unitest; 
using System; 
using System.Collections.Generic; 
using System.Linq;
 using System.Text;
 using System.Threading.Tasks;


namespace CLI_Unitest.Tests { 
[TestClass()] 
public class TeglalapTests { 
[TestMethod()] 
public void TeruletTest() 
{ 
double elvart = 2 * 2; 
Assert.AreEqual(elvart, Teglalap.Terulet(2.1, 2.3), 1); 
}

 [TestMethod()]
    public void KeruletTest()
    {
        double elvart = 2* (2 + 2);
        Assert.AreEqual(elvart, Teglalap.Kerulet(2.1, 2.3), 1.5);
    }
}
}