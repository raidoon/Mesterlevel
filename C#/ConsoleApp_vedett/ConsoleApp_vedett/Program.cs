using NetworkHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTableExt;
using System.Runtime.InteropServices;

namespace ConsoleApp_vedett
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:3000/vedettallatoklista";
            List<adatsor> adatok = Backend.GET(url).Send().As<List<adatsor>>();
            //ConsoleTableBuilder.From(adatok).ExportAndWriteLine();
            //Határozza meg és a minta szerint írassa ki a képernyőre, hány állat adata került beolvasásra!
            Console.WriteLine($"Állatok száma: {adatok.Count()}");
            //A minta szerint írassa ki a képernyőre a sas állatok a nevét! Akkor tekintünk egy állatot sasnak,
            //ha a neve egy szóközt követő sas szóra végződik. (” sas”).
            Console.WriteLine("Sas madarak:");
            foreach (var item in adatok)
                if (item.faj.Contains(" sas")) Console.WriteLine(item.faj);
            //másik megoldás
            var sasok=adatok.GroupBy(x=>x.faj).Where(x=> x.Key.Contains(" sas"))
                .Select(x => new {sasok=x.Key}).ToList();
            ConsoleTableBuilder.From(sasok).ExportAndWriteLine();
            //Billentyűzetről kérjen be egy tetszőleges rendszertani kategóriát, majd írja ki,
            //hogy mennyi állat tartozik ebbe a kategóriába! A program ne tegyen különbséget a kis-és nagybetűk
            //között, tehát például a Madarak, madarak, MADARAK karaktersorozat mindegyike azonosnak tekintendő!
            //Az eredményt a minta szerinti formában írassa ki a képernyőre!
            Console.Write("Rendszertani kategória: ");
            string keresettKategoria = Console.ReadLine().ToLower();
            //megszámlálás tétele
            int allatokSzama = 0;
            foreach (var item in adatok) if(item.kategoria.ToLower()==keresettKategoria)allatokSzama++;
            Console.WriteLine($"Ebbe a kategóriába tartozó állatok száma: {allatokSzama}");
            Console.WriteLine($"Ebbe a kategóriába tartozó állatok száma: {adatok.Where(x=>x.kategoria.ToLower()==keresettKategoria).Count()}");
            //Adja meg a program kódjában egy arfolyam azonosítójú változóban az Euró árfolyamát!
            int arfolyam = 400;
            //Készíts egy függvényt, amely a paraméterként megkapja az árfolyam értékét és az átváltandó árat Ft-ban,
            //majd visszaadja az átváltandó árat euróban két tizedesjegyre kerekítve. 
            //A függvény használatával számítsa ki az állatok átlagos értékét euróban!
            double atlag = 0;
            foreach (var item in adatok) atlag += atvalt(arfolyam, item.eszmeiErtek);
            Console.WriteLine($"Az állatok átlagos eszmei értéke: {Math.Round(atlag/adatok.Count(),1)} EUR");
            //paraméterként megkapja az árfolyam értékét és a listát
            double atlag2 = atvalt2(arfolyam, adatok);
            Console.WriteLine($"Az állatok átlagos eszmei értéke - másképpen megoldva: {Math.Round(atlag2, 1)} EUR");
            // extra feladat: kategóriánként az állatok száma és átlagos értéke
            var kategoriak = adatok.GroupBy(x => x.kategoria, x => x.eszmeiErtek)
                .OrderBy(x => x.Key)
                .Select(x => new { kategórianév = x.Key, állatok_száma = x.Count(), átlagos_eszmei_érték = x.Average() }).ToList();
            Console.WriteLine("Kategóriánként az állatok száma és átlagos értéke:");
            ConsoleTableBuilder.From(kategoriak).ExportAndWriteLine();
            
            Console.ReadKey();
        }

        private static double atvalt2(int arfolyam, List<adatsor> lista)
        {
            double atlag = 0;
            foreach (var item in lista) atlag += item.eszmeiErtek / arfolyam;
            atlag = atlag / lista.Count();
            return atlag;
        }

        private static double atvalt(int arfolyam, int ar)
        {
            double eszmeiErtekEuroban = ar / arfolyam;
            return eszmeiErtekEuroban;
        }
    }
}