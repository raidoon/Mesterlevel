using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConsoleApp_VarmegyeSzekhelyJatek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Adatsor> adatok = new List<Adatsor>();
            string[] f = File.ReadAllLines("varmegyeszekhelyek2023.txt", Encoding.UTF8);
            foreach(string line in f.Skip(1)) adatok.Add(new Adatsor(line));
            foreach(var i in adatok) Console.WriteLine($"{i.Szekhely,-20}{i.Megye}");
            Console.WriteLine("3.feladat: Játékszabályok");
            Console.WriteLine($"A játékban {adatok.Count()} vármegyéből választhatunk ki N darabot" +
                $"\nÖnnek a vármegyék vármegyeszékhelyeit kell kitalálnia!");
            Console.WriteLine("4.feladat:");
            int n = szambe(2, 19);
            //5.feladat
            int[] indexek=new int[n];
            int j = 0, szam = 0;
            Random r = new Random();
            indexek[0] = r.Next(19); //0..18 első szám
            bool van = false;
            while (j < n) 
            {
                van = false;
                szam = r.Next(19); // második szám
                for (int i = 0; i < j; i++) if (indexek[i] == szam) van = true;
                if (!van)
                {
                    indexek[j] = szam;
                    j++;
                }
            }
            //for (int i = 0; i < n; i++) Console.Write($"{indexek[i]}, ");
            int leghosszabb = adatok[indexek[0]].Szekhely.Length;
            int legrovidebb = adatok[indexek[0]].Szekhely.Length;
            for(int i = 0; i < n; i++)
            {
                if (adatok[indexek[i]].Szekhely.Length > leghosszabb) leghosszabb = adatok[indexek[i]].Szekhely.Length;
                if (adatok[indexek[i]].Szekhely.Length < legrovidebb) legrovidebb = adatok[indexek[i]].Szekhely.Length;
            }
            Console.WriteLine("6.feladat: Segítség");
            Console.WriteLine($"A válaszok közül a legrövidebb vármegyeszékhely neve {legrovidebb} karakteres");
            Console.WriteLine($"A válaszok közül a leghosszabb vármegyeszékhely neve {leghosszabb} karakteres");
            Console.WriteLine("7.feladat:");
            double jotipp = 0;
            string tipp = "";
            for(int i = 0; i < n; i++)
            {
                Console.Write($"{adatok[indexek[i]].Megye} ----> {adatok[indexek[i]].Szekhely[0]}");
                tipp=Console.ReadLine();
                if(adatok[indexek[i]].Szekhely[0]+tipp== adatok[indexek[i]].Szekhely)jotipp++;
            }
            Console.WriteLine("8.feladat: Értékelés");
            Console.WriteLine($"Ön {jotipp} vármegyeszékhely nevét találta el!");
            Console.WriteLine($"Teljesítménye {Math.Round(jotipp/n*100,2)}%-os");
            Console.ReadKey();
        }

        private static int szambe(int alsoHatar, int felsoHatar)
        {
            int szam = 0;
            bool ok = false;
            while (!ok)
            {
                ok = true;
                try
                {
                    Console.Write($"Kérem a kitalálandó vármegyeszékhelyek számát [{alsoHatar}-{felsoHatar}] N=");
                    szam=int.Parse(Console.ReadLine());
                    if (szam >= alsoHatar && szam <= felsoHatar) ok = true;
                    else
                    {
                        ok=false;
                        Console.WriteLine($"{alsoHatar} és {felsoHatar} közötti számot adj meg!");
                    }
                }
                catch
                {
                    ok = false;
                    Console.WriteLine("Nem számot adtál meg!");
                }
            }
            return szam;
        }
    }
}