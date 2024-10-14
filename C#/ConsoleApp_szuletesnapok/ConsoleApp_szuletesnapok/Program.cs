using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkHelper;
using ConsoleTableExt;
using System.Runtime.InteropServices;

namespace ConsoleApp_szuletesnapok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:3000/szuletesnapokLista";
            List<Adatsor> adatok = Backend.GET(url).Send().As<List<Adatsor>>();
            var lista = adatok.Select(x=> 
                new {vezetéknév = x.vnev,keresztnév=x.knev,
                    születésidátum=x.szul.ToString("yyyy.MM.dd"),életkor=Math.Round((DateTime.Now-x.szul).Days/365.25,2)}).ToList();
            //ConsoleTableBuilder.From(lista).ExportAndWriteLine();
            Console.WriteLine($"{adatok.Count()} személy adata került beolvasásra.");
            Console.WriteLine("Akinek a vezetékneve és a keresztneve azonos betűvel kezdődik");
            foreach(var a in adatok) if (a.vnev[0]==a.knev[0]) Console.WriteLine($"{a.vnev} {a.knev}");
            Console.Write("Adj meg egy keresztnevet: ");
            string keresettKeresztnev = Console.ReadLine().ToLower();
            string nev = keresettKeresztnev[0].ToString().ToUpper();
            for (int i = 1; i < keresettKeresztnev.Length; i++) nev += keresettKeresztnev[i];
            int db = 0;
            foreach (var item in adatok) if(item.knev==nev)
            {
                    db++;
                    Console.WriteLine($"{item.vnev} {item.knev}");
            }
            Console.WriteLine($"{db} személy rendelkezik a/az {nev} keresztnévvel.");
            bool ok = false;
            int evszam = 0;
            do
            {
                try
                {
                    Console.Write("Évszám: ");
                    evszam = int.Parse(Console.ReadLine());
                    if (evszam < 1971 || evszam > 1999)
                    {
                        ok = false;
                        Console.WriteLine("Nem 1971-1999 közötti évszámot adtál meg!");
                    }
                    else ok = true;
                }
                catch
                {
                    ok = false;
                    Console.WriteLine("Nem számot adtál meg!");
                }
            }
            while (!ok);
            int szuletesekSzama = SzuletesekSzama(evszam, adatok);
            Console.WriteLine($"{evszam}-ban születettek száma: {szuletesekSzama}");
            //+ feladat
            var szuletesekLista = adatok.GroupBy(x => x.szul.Year).OrderBy(x => x.Key)
                .Select(x => new { évszám = x.Key, darabszám = x.Count() }).ToList();
            ConsoleTableBuilder.From(szuletesekLista).ExportAndWriteLine();
            Console.ReadKey();
        }

        private static int SzuletesekSzama(int evszam, List<Adatsor> adatok)
        {
            int db = 0;
            foreach (var item in adatok) if (item.szul.Year==evszam)db++;
            return db;
        }
    }
}
