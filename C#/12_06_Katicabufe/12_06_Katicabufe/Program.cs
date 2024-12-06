using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ConsoleTableExt;
using NetworkHelper;
namespace _12_06_Katicabufe
{
    internal class Program
    {
        static List<Kategoria> kategoriaadatok = new List<Kategoria>();
        static List<Forgalom> forgalomadatok = new List<Forgalom>();
        static List<Adatok> adatok = new List<Adatok>();
        static void Main(string[] args)
        {
            adatokbetoltese();
            //KategoriaBovites();
            //ForgalomBovites();
            //GyrostalModositas();
            
            Console.WriteLine("\nKiadásra váró rendelések:");
            ConsoleTableBuilder.From(forgalomadatok
                .Where(x=> x.kiadva==0)
                .Select(x=> new {x.termek,x.vevo})
                .OrderBy(x=> x.vevo)
                .ThenBy(x=> x.termek)
                .ToList())
                .ExportAndWriteLine();

            Console.WriteLine("\nKategóriánkénti bevételek");
            ConsoleTableBuilder.From(adatok
                .GroupBy(x => x.kategorianev)
                .Select(y => new
                {
                    Kategórianév = y.Key,
                    Nettóbevétel = y.Sum(x => x.nettoar * x.mennyiseg),
                    Forgalmiadó = Math.Round(y.Sum(x => (x.nettoar * x.mennyiseg) * 0.27), 1),
                })
                .OrderBy(x => x.Kategórianév)
                .ToList())
                .ExportAndWriteLine();

            Console.WriteLine("\nLegnépszerűbb termékek:");
            ConsoleTableBuilder.From(forgalomadatok
                .GroupBy(x => x.termek)
                .Select(y => new
                {
                    Termék = y.Key,
                    Rendelésszám = y.Count(),
                    Összesdarab = y.Sum(x => x.mennyiseg)
                })
                .OrderByDescending(y => y.Rendelésszám)
                .ToList())
                .ExportAndWriteLine();

            //8.feladat
            Console.WriteLine("\nVevők által leadott rendelések száma:");
            ConsoleTableBuilder.From(forgalomadatok
                .GroupBy(x=> x.vevo)
                .Select(y=> new
                {
                    Vevő = y.Key,
                    RendelésekSzáma = y.Count(),
                })
                .OrderByDescending(y=> y.RendelésekSzáma)
                .ToList())
                .ExportAndWriteLine();

            //9.feladat
            Console.WriteLine("\nKiadott és kiadásra váró rendelések:");
            ConsoleTableBuilder.From(forgalomadatok
                .GroupBy(x => x.kiadva == 1 ? "Kiadott" : "Kiadatlan")
                .Select(y => new
                {
                    Állapot = y.Key,
                    Rendelésszám = y.Count(),
                    ÖsszesNettóÉrték = y.Sum(x => x.nettoar)
                })
                .ToList())
              .ExportAndWriteLine();

            //10.feladat
            Console.WriteLine("\nTermékek átlagos nettó ára kategóriánként:");
            ConsoleTableBuilder.From(adatok
                .GroupBy(x=> x.kategorianev)
                .Select(y=> new
                {
                    Kategória = y.Key,
                    ÁtlagosÁr = y.Average(x=> x.nettoar)
                })
                .ToList())
                .ExportAndWriteLine();

            //11.feladat
            Console.WriteLine("\nTermékek teljes mennyisége kategóriánként:");
            ConsoleTableBuilder.From(adatok
                .GroupBy (x=> x.kategorianev)
                .Select(y=> new
                {
                    Kategória = y.Key,
                    TeljesMennyiség = y.Sum(x=> x.mennyiseg)
                })
                .ToList())
                .ExportAndWriteLine();

            //12.feladat
            Console.WriteLine("\nKategóriánként a legdrágább termék és annak nettó ára");
            var lista = adatok.Select(x => new
            {
                Kategórianév = x.kategorianev,
                LegdrágábbTermék = forgalomadatok.Where(y => y.forgalomkategoriaid == x.kategoriaid)
                .OrderByDescending(y => y.nettoar).FirstOrDefault()
            })
                .Where(z => z.LegdrágábbTermék != null)
                .ToList();
            foreach (var item in lista) Console.WriteLine($"{item.Kategórianév,-15}{item.LegdrágábbTermék.termek,-15}{item.LegdrágábbTermék.nettoar}");


            //13.feladat
            Console.WriteLine("\nVevők által leadott összes rendelt termék nettó értéke:");
            ConsoleTableBuilder.From(forgalomadatok
                .GroupBy(x => x.vevo)
                .Select(y => new
                {
                    Vevő = y.Key,
                    RendelésekSzáma = y.Count(),
                    TeljesRendelésiÉrték = y.Sum(x => x.nettoar * x.mennyiseg)
                })
                .OrderByDescending(y => y.TeljesRendelésiÉrték)
                .ToList())
                .ExportAndWriteLine();

            //14.feladat
            Console.WriteLine("\nVevőnként és termékenként rendelt termékek összes mennyiség:");
            ConsoleTableBuilder.From(forgalomadatok
                .GroupBy(x => new { x.vevo, x.termek })
                .Select(y => new
                {
                    Vevő = y.Key.vevo,
                    Termék = y.Key.termek,
                    ÖsszesMennyiség = y.Sum(x => x.mennyiseg)
                })
                .OrderBy(y=>y.Vevő)
                .ThenBy(y=>y.Termék)
                .ToList())
                .ExportAndWriteLine();

            //+ feladat: tetsszőleges lista --> kérjen be a felhasználótól egy keresett terméket, és írjuk ki, hogy az adott termék benne van-e az adatbázisban
            //+ ha igen, akkor írjuk ki, hogy az adott rendelést már megkapta-e a vevő, vagy sem
            //+ attól függetlenül, hogy igen vagy nem, írjuk ki az adott rendelést is

            Console.Write("\nAdd meg a keresett termék nevét! (Pl.: Limonádé) ");
            string keresem = Console.ReadLine();
            var keresettLista = forgalomadatok.Where(x => x.termek.ToLower() == keresem.ToLower()).ToList();
            while(keresettLista.Count() == 0)
            {
                Console.WriteLine("Ez a termék nem található az adatbázisban!");
                Console.Write("Add meg újra a keresett termék nevét: ");
                keresem = Console.ReadLine();
                keresettLista = forgalomadatok.Where(x => x.termek.ToLower() == keresem.ToLower()).ToList();
            }
            foreach (var item in keresettLista)
            {
                if (item.kiadva == 0) Console.WriteLine($"\n\t{item.vevo} még mindig várja a terméket! - Rendelése: {item.mennyiseg} {item.egyseg} {item.termek}.");
                else Console.WriteLine($"\n\t{item.vevo} már megkapta a terméket! - Rendelése: {item.mennyiseg} {item.egyseg} {item.termek}.");
            }
            Console.ReadKey();
        }
        private static void ForgalomBovites()
        {
            Forgalom forgalomfelvitel = new Forgalom
            {
                termek = "Mintás tányér",
                vevo = "Hanna",
                forgalomkategoriaid = kategoriaadatok.Where(x => x.kategorianev == "Ajándéktárgyak").First().kategoriaid,
                egyseg = "db",
                nettoar = 1000,
                mennyiseg = 1,
                kiadva = 1
            };
            string url = "http://localhost:3000/forgalomfelvitel";
            string valasz = Backend.POST(url).Body(forgalomfelvitel).Send().As<string>();
            Console.WriteLine(valasz);
            adatokbetoltese();
        }
        private static void GyrostalModositas()
        {
            string url = "http://localhost:3000/gyrosmodositas";
            string valasz = Backend.PUT(url).Send().As<string>();
            Console.WriteLine(valasz);
            adatokbetoltese();
        }
        private static void KategoriaBovites()
        {
            Kategoria kategoriafelvitel = new Kategoria
            {
                kategorianev = "Ajéndéktárgyak"
            };
            string url = "http://localhost:3000/kategoriafelvitel";
            string valasz = Backend.POST(url).Body(kategoriafelvitel).Send().As<string>();
            Console.WriteLine(valasz);
            adatokbetoltese();
        }
        private static void adatokbetoltese()
        {
            kategoriaadatok.Clear();
            forgalomadatok.Clear();
            adatok.Clear();

            string urlkategoria = "http://localhost:3000/kategorialista";
            string urlforgalom = "http://localhost:3000/forgalomlista";
            string urladatok = "http://localhost:3000/adatoklista";

            kategoriaadatok = Backend.GET(urlkategoria).Send().As<List<Kategoria>>();
            forgalomadatok = Backend.GET(urlforgalom).Send().As<List<Forgalom>>();
            adatok = Backend.GET(urladatok).Send().As<List<Adatok>>();
        }
    }
}