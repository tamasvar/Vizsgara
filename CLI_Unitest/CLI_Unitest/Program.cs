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

            /*
            //Legnagyobb területű téglalap adatainak kiíratása - 2.0
            Dictionary<Teglalap, double> teglalapTeruletek = new Dictionary<Teglalap, double>();
            for(int i = 0; i < teglalapLista.Count(); i++)
            {
                teglalapTeruletek.Add(teglalapLista[i], Teglalap.Terulet(teglalapLista[i].A, teglalapLista[i].B));
            }


            foreach (var item in teglalapTeruletek)
            {
                Console.WriteLine(item.Key.A + " " + item.Key.B + " " + item.Value);
                //kb mint a for ciklusban feljebb
            }

            Console.WriteLine(teglalapTeruletek.Max(x => x.Value));
            */

            Console.ReadKey();
        }
    }
}
