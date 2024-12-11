using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkHelper;
using ConsoleTableExt;
using System.Xml;
namespace Diafilmek
{
    internal class Program
    {
        static List<Kiado> kiadoadatok = new List<Kiado>();
        static List<Film> filmadatok = new List<Film>();
        static List<Adatok> adatok = new List<Adatok>();
        static void Main(string[] args)
        {
            adatokbetoltese();
            feladat3();
            feladat4();
            feladat5();
            feladat6();
            feladat7();
            feladat8();
            feladat9();
            feladat10();
            feladat11();
            feladat12();
            feladat13();
            extrafeladat1();
            Console.ReadKey();
        }

        private static void extrafeladat1()
        {
            /*új film rögzítése
             be: cím, kiadási év, kocka, színes-e, filmiadoid*/
            Console.WriteLine("\nÚj film rögzítése");
            Console.Write("Film cím: ");
            string cim = Console.ReadLine();
            int kiadasiev = 0, kocka = 0, szines = 2, kiadoid = 0;
            bool okev = false, okkocka = false, okszines = false, okfilmkiadoid = false;
            while (!okev)
            {
                Console.Write($"Kiadási év (0-{DateTime.Now.Year}): ");
                kiadasiev = int.Parse(Console.ReadLine());
                if (kiadasiev <= DateTime.Now.Year && kiadasiev > 0) okev = true;
                else okev = false;
            }
            while (!okkocka)
            {
                Console.Write("Kocka: ");
                kocka = int.Parse(Console.ReadLine());
                if (kocka > 0) okkocka = true;
                else okkocka = false;
            }
            while (!okszines)
            {
                Console.Write("Színes-e a film (-1 vagy 0): ");
                szines = int.Parse(Console.ReadLine());
                if (szines == 0 || szines == -1) okszines = true;
                else okszines = false;
            }
            while (!okfilmkiadoid)
            {
                Console.Write("Add meg a film kiadójának id-ját: ");
                kiadoid = int.Parse(Console.ReadLine());
                if (kiadoid >= 1 && kiadoid <= 5) okfilmkiadoid = true;
                else okfilmkiadoid=false;
            }
            Film filmfelvitel = new Film
            {
                cim = cim,
                kiadasiev = kiadasiev,
                kocka = kocka,
                szinese = szines,
                filmkiadoid = kiadoid
            };
            string url = "http://localhost:3000/filmfelvitel";
            string valasz = Backend.POST(url).Body(filmfelvitel).Send().As<string>();
            Console.WriteLine(valasz);
            adatokbetoltese();
        }
        private static void feladat13()
        {
            Console.Write("\nKérek egy kiadónevet: ");
            string keresem = Console.ReadLine().ToLower();
            var lista = adatok.Where(x => x.kiadonev.ToLower().Contains(keresem)).Select(x => new { x.cim, x.kiadasiev }).OrderBy(x => x.cim).ToList();
            if (lista.Count == 0) Console.WriteLine("A keresett kiadó nem található!");
            else
            {
                Console.WriteLine($"A(z) {adatok.Where(x => x.cim == lista[0].cim).First().kiadonev} kiadó összes kiadványa:");
                ConsoleTableBuilder.From(lista).ExportAndWriteLine();
            }
        }
        private static void feladat12()
        {
            Console.WriteLine("\nAz 5 legrégebbi diafilm:");
            ConsoleTableBuilder
                .From(adatok
                .Where(x => x.kiadasiev != 0)
                .Select(x => new { x.cim, x.kiadasiev })
                .OrderBy(x => x.kiadasiev)
                .ThenBy(x => x.cim)
                .Take(5)
                .ToList())
                .ExportAndWriteLine();
        }
        private static void feladat11()
        {
            Console.WriteLine("\nDiafilmek száma kiadónként:");
            ConsoleTableBuilder
                .From(adatok
                .GroupBy(x => x.kiadonev)
                .Select(x => new { Kiado = x.Key, KiadvanyokSzama = x.Count() })
                .OrderByDescending(x => x.KiadvanyokSzama)
                .ToList())
                .ExportAndWriteLine();
        }
        private static void feladat10()
        {
            Console.Write("\nKérek egy évszámot: ");
            int evszam = int.Parse(Console.ReadLine());
            var lista = filmadatok.Where(x => x.kiadasiev == evszam).Select(x => new { x.cim, x.kocka }).OrderByDescending(x => x.kocka).ToList();
            if (lista.Count == 0) Console.WriteLine("A megadott évben nem adtak ki diafilmet.");
            else
            {
                Console.WriteLine($"Diafilmek, amelyeket {evszam}-ban/-ben adtak ki:");
                ConsoleTableBuilder.From(lista).ExportAndWriteLine();
            }

        }
        private static void feladat9()
        {
            Console.WriteLine("\nAz 5 legtöbb kockaszámú diafilm:");
            ConsoleTableBuilder
                .From(filmadatok
                .OrderByDescending(x => x.kocka)
                .Select(x => new { x.cim, x.kocka })
                .Take(5)
                .ToList())
                .ExportAndWriteLine();
        }
        private static void feladat8()
        {
            int db = 47;
            Console.WriteLine($"\nfekete-fehért és színes diafilm változatban is kiadták a következő {db} filmet");
            ConsoleTableBuilder
                .From(adatok
                .Where(x => x.szinese == -1 && filmadatok.Where(y => y.szinese != -1)
                .Select(y => y.cim).ToList().Contains(x.cim))
                .Select(x => x.cim)
                .Distinct()
                .Take(db)
                .ToList())
                .ExportAndWriteLine();
        }
        private static void feladat7()
        {
            Console.WriteLine("\névente kiadott diafilmek száma:");
            ConsoleTableBuilder
                .From(adatok
                .GroupBy(x => x.kiadasiev)
                .Select(x => new { x.Key, kiadásokszáma = x.Count() })
                .OrderByDescending(x => x.kiadásokszáma)
                .ToList())
                .ExportAndWriteLine();
        }
        private static void feladat6()
        {
            Console.WriteLine("\na 3 legtöbb kiadást megélt diafilm címe és a kiadások száma:");
            ConsoleTableBuilder
                .From(adatok
                .GroupBy(x => x.cim)
                .Select(x => new { x.Key, kiadásokszáma = x.Count() })
                .OrderByDescending(x => x.kiadásokszáma)
                .Take(3)
                .ToList())
                .ExportAndWriteLine();
        }
        private static void feladat5()
        {
            Console.WriteLine("\na 'Sicc' címszereplőmacska diafilmejeit mely kiadók adták ki:");
            ConsoleTableBuilder
                .From(adatok
                .Where(x => x.cim.ToLower().Contains("sicc"))
                .GroupBy(x => x.kiadonev)
                .Select(x => new {kiadonev = x.Key })
                .ToList())
                .ExportAndWriteLine();
        }
        private static void feladat4()
        {
            Console.WriteLine("\nFarkas szót tartalmazó diafilmek:");
            ConsoleTableBuilder
                .From(filmadatok
                .Where(x => x.cim.ToLower().Contains("farkas"))
                .Select(x => new { x.cim, x.kocka, x.kiadasiev })
                .ToList())
                .ExportAndWriteLine();
        }
        private static void feladat3()
        {
            Console.WriteLine("2000 után kiadott diafilmek:");
            ConsoleTableBuilder
                .From(filmadatok
                .Where(x => x.kiadasiev >= 2000)
                .Select(x => new { x.cim, x.kiadasiev })
                .ToList())
                .ExportAndWriteLine();
        }
        private static void adatokbetoltese()
        {
            kiadoadatok.Clear();
            filmadatok.Clear();
            adatok.Clear();
            //listák feltöltése adatokkal
            string urlkiado = "http://localhost:3000/kiadolista";
            string urlfilm = "http://localhost:3000/filmlista";
            string urlosszesadat = "http://localhost:3000/adatoklista";

            kiadoadatok = Backend.GET(urlkiado).Send().As<List<Kiado>>();
            filmadatok = Backend.GET(urlfilm).Send().As<List<Film>>();
            adatok = Backend.GET(urlosszesadat).Send().As<List<Adatok>>();
        }
    }
}