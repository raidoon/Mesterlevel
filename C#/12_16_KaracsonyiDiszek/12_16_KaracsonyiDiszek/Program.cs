using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_16_KaracsonyiDiszek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int diszDb = 0, szam = 0, harang = 0, fenyofa = 0, angyalka = 0;
            bool nemCsinaltDiszt = false, okszam = false;
            List<Adatok> adatok = new List<Adatok>();
            string[] file = File.ReadAllLines("diszek.txt");
            foreach (var i in file) adatok.Add(new Adatok(i));
            Console.WriteLine($"Adatok száma a fájlban: {adatok.Count()}");
            foreach (var i in adatok) diszDb += i.harang + i.angyalka + i.fenyofa;
            Console.WriteLine($"4.feladat: Összesen {diszDb} db dísz készült.");
            foreach(var i in adatok)
            {
                while (!nemCsinaltDiszt)
                {
                    if (i.harang == 0 && i.fenyofa == 0 && i.angyalka == 0)
                    {
                        nemCsinaltDiszt = true;
                        Console.WriteLine($"\n5.feladat: Volt olyan nap, amikor egyetlen dísz sem készült."); break;
                    }
                    break;
                }
            }
            Console.WriteLine("\n6.feladat:");
            while (!okszam)
            {
                Console.Write("Adja meg a keresett napot [1 ... 40]: ");
                try
                {
                    szam = int.Parse(Console.ReadLine());
                    if (szam <= 40 && szam >= 1) okszam = true;
                    else okszam = false;

                }catch(Exception e) { Console.WriteLine(e.Message); }
            }
            foreach (var i in adatok)
            {
                if (i.nap <= szam) 
                {
                    harang += i.harang;
                    harang += i.harangEladas;

                    angyalka += i.angyalka;
                    angyalka += i.angyalkaEladas;
                    
                    fenyofa += i.fenyofa;
                    fenyofa += i.fenyofaEladas;
                }
            }
            Console.WriteLine($"\tA(z) {szam}. nap végén {harang} harang, {angyalka} angyalka és {fenyofa} fenyőfa maradt készleten.");
            harang = 0; angyalka = 0; fenyofa = 0;
            foreach (var item in adatok) { harang -= item.harangEladas; angyalka -= item.angyalkaEladas; fenyofa -= item.fenyofaEladas; }
            if (angyalka > harang && angyalka > fenyofa) Console.WriteLine($"\n7.feladat: Legtöbbet eladott dísz: {angyalka} darab\n\tAngyalka");
            else if (harang > angyalka && harang > fenyofa) Console.WriteLine($"\n7.feladat: Legtöbbet eladott dísz: {harang} darab\n\tHarang");
            else if (fenyofa > angyalka && fenyofa > harang) Console.WriteLine($"\n7.feladat: Legtöbbet eladott dísz: {fenyofa} darab\n\tFenyőfa");
            else if (angyalka > harang && angyalka == fenyofa) Console.WriteLine($"\n7.feladat: Legtöbbet eladott dísz: {angyalka} darab\n\tAngyalka\n\tFenyőfa");
            else if (angyalka == harang && angyalka == fenyofa) Console.WriteLine($"\n7.feladat: Legtöbbet eladott dísz: {harang} darab\n\tHarang\n\tAngyalka\n\tFenyőfa");
            else if (harang == angyalka && harang > fenyofa) Console.WriteLine($"\n7.feladat: Legtöbbet eladott dísz: {harang} darab\n\tHarang\n\tAngyalka");
            else if (harang > angyalka && harang == fenyofa) Console.WriteLine($"\n7.feladat: Legtöbbet eladott dísz: {harang} darab\n\tHarang\n\tFenyőfa");

            Console.ReadKey();
        }
    }
}