using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkHelper;
using ConsoleTableExt;
namespace _03_24_Oldtimer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var kategorialista = Backend.GET("http://localhost:3000/kategoriaklista").Send().As<List<Kategoriak>>();
            var autoklista = Backend.GET("http://localhost:3000/autoklista").Send().As<List<Autok>>();
            var berleseklista = Backend.GET("http://localhost:3000/berleseklista").Send().As<List<Berlesek>>();

            feladat1(kategorialista, autoklista);
            feladat2(kategorialista, autoklista);
            //feladat3
            var adatfelvitel = new
            {
                autokrendszam = "OT44-01",
                autokszin = "Fekete-piros",
                autoknev = "GMC Vandura Szupercsapat kiadás",
                autokevjarat = 1983,
                autokkategoriaid = 3
            };
            //string valasz = Backend.POST("http://localhost:3000/autofelvitel").Body(adatfelvitel).Send().As<string>();
            feladat4(autoklista);

            Console.WriteLine($"osszes-bevetel: {berleseklista.Sum(x=> x.berlesekmennyiseg*x.autokar+x.berlesekbiztositas)}");
            Console.WriteLine($"max-biztositas-arany: {Math.Round(berleseklista.Max(x => x.berlesekbiztositas / (x.berlesekmennyiseg * x.autokar + x.berlesekbiztositas)) * 100, 2)}");


            Console.ReadKey();
        }

        private static void feladat4(List<Autok> autoklista)
        {
            Console.WriteLine("a legnépszerűbb 5 típus");
            ConsoleTableBuilder
                .From(autoklista
                .GroupBy(x => x.autoknev)
                .Select(x => new { nev = x.Key, mennyiseg = x.Sum(y=> y.autokid)})
                .OrderByDescending(x=> x.mennyiseg)
                .Take(5)
                .ToList())
                .ExportAndWriteLine();
        }

        private static void feladat2(List<Kategoriak> kategoriak, List<Autok> autok)
        {
            Console.WriteLine("Limuzinok");
            int limuzin_id = kategoriak.Where(x => x.kategoriaknev == "Limuzin").First().kategoriakid;
            ConsoleTableBuilder
                .From(autok.Where(x => x.autokkategoriaid == limuzin_id)
                .Select(x => new { nev = x.autoknev, szín = x.autokszin })
                .OrderBy(x => x.nev)
                .ToList()).ExportAndWriteLine();
        }

        private static void feladat1(List<Kategoriak> kategoriak, List<Autok> autok)
        {
            int sport_id = kategoriak.Where(x=> x.kategoriaknev=="Sport").First().kategoriakid;
            int sportautok_szama = autok.Count(x=> x.autokkategoriaid==sport_id);
            Console.WriteLine($"Sportautók száma: {sportautok_szama}");
        }
    }
}