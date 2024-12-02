using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkHelper;
using ConsoleTableExt;
using System.Xml;

namespace Dolgozo_Nyilvantarto_ConsoleApp_WPF
{
    public class Program
    {
        static List<Reszleg> reszlegadatok = new List<Reszleg>();
        static List<Dolgozo> dolgozoadatok = new List<Dolgozo>();
        static List<Adatok> adatok = new List<Adatok>();
        static void Main(string[] args)
        {
            adatokbetoltese();
            //ReszlegenkentiStatisztika();
            //ReszlegenkentiStatisztika2();
            //ReszlegenkentiStatisztika3();
            //top10LegnagyobbFizetesuDolgozo();
            //dolgozokBelepesiEvSzerint();
            //ReszlegenkentLegmagasabbFizetes();
            //DolgozokSzamaNemenkent();
            //LegfiatalabbDolgozo();
            //DolgozokFizetesiTartomanyban();
            //DolgozokAtlagfizeteseNemenkent();
            JubileumiJutalomraJogosultak();
            Console.ReadKey();
        }

        private static void JubileumiJutalomraJogosultak()
        {
            int AktualisEv = DateTime.Now.Year;
            var lista = dolgozoadatok
                .Where(x => (AktualisEv - x.belepes) == 25 || (AktualisEv - x.belepes) == 30 || (AktualisEv - x.belepes) == 40)
                .Select(x => new
                {
                    x.nev, x.neme, x.belepes, x.ber,
                    Munkaviszony = (AktualisEv - x.belepes),
                    Jutalom = (AktualisEv - x.belepes) == 25 ? x.ber * 2 : (AktualisEv - x.belepes) == 30 ? x.ber * 3 : x.ber * 5
                })
                .ToList();
            ConsoleTableBuilder.From(lista).ExportAndWriteLine();
        }

        private static void DolgozokAtlagfizeteseNemenkent()
        {
            var lista = dolgozoadatok.GroupBy(d=>d.neme,d=>d.ber)
                .Select(x=> new
                {
                    neme=x.Key,
                    átlagfizetés=Math.Round(x.Average(),2)
                })
                .ToList();
            ConsoleTableBuilder.From(lista).ExportAndWriteLine();
        }

        private static void DolgozokFizetesiTartomanyban()
        {
            //Bekér egy minimum és egy maximum fizetési értéket, majd kilistázza az ebbe a tartományba eső dolgozókat.
            Console.Write("Kérem a minimumfizetést: ");
            int minfizu = 0, maxfizu = 0;
            while(!int.TryParse(Console.ReadLine(),out minfizu))
            {
                Console.WriteLine("Érvénytelen fizetés!");
                Console.Write("Kérem a minimumfizetést: ");
            }
            do
            {
                Console.Write("Kérem a maximumfizetést: ");
                while (!int.TryParse(Console.ReadLine(), out maxfizu))
                {
                    Console.WriteLine("Érvénytelen fizetés!");
                    Console.Write("Kérem a maximumfizetést: ");
                }
            } while (maxfizu < minfizu);
            var lista = dolgozoadatok
                .Where(x => x.ber >= minfizu && x.ber <= maxfizu)
                .ToList();
            Console.WriteLine($"A dolgozók {minfizu} - {maxfizu} tartományban:");
            ConsoleTableBuilder.From(lista).ExportAndWriteLine();
        }

        private static void LegfiatalabbDolgozo()
        {
            int belepeslegkesobb = dolgozoadatok.Max(x => x.belepes);
            var lista = dolgozoadatok.Where(x=> x.belepes==belepeslegkesobb)
                .ToList();
            ConsoleTableBuilder.From(lista).ExportAndWriteLine();
            //másik megoldás
            //var lista2 = dolgozoadatok.OrderByDescending(x => x.belepes).FirstOrDefault();
            //if(lista2!=null) Console.WriteLine($"{lista2.nev,-25}{lista2.belepes,-5}{lista2.neme,-10}{lista2.ber}");
        }

        private static void DolgozokSzamaNemenkent()
        {
            ConsoleTableBuilder.From(dolgozoadatok
                .GroupBy(x => x.neme)
                .Select(y => new
                {
                    neme = y.Key,
                    dolgozókszáma = y.Count()
                })
                .ToList())
                .ExportAndWriteLine();
        }

        private static void ReszlegenkentLegmagasabbFizetes()
        {
            var lista = reszlegadatok
                .Select(x => new
                {
                    részleg = x.reszleg,
                    LegmagasabbFizetés = dolgozoadatok
                                        .Where(d => d.dolgozoreszlegid == x.reszlegid)
                                        .OrderByDescending(d => d.ber)
                                        .FirstOrDefault()
                })
                .Where(y => y.LegmagasabbFizetés != null)
                .ToList();
            foreach (var i in lista)
            {
                Console.WriteLine($"{i.részleg,-25}{i.LegmagasabbFizetés.nev,-25}{i.LegmagasabbFizetés.ber}");
            }
        }

        private static void dolgozokBelepesiEvSzerint()
        {
            //Bekér egy évszámot és megjeleníti azokat a dolgozókat, akik abban az évben léptek be
            Console.Write("Kérem az évszámot: ");
            int evszam;
            while(!int.TryParse(Console.ReadLine(),out evszam))
            {
                Console.WriteLine("Érvénytelen évszám!");
                Console.Write("Kérem az évszámot: ");
            }
            var lista = dolgozoadatok
                .Where(x => x.belepes == evszam)
                .ToList();
            if(lista.Count > 0) ConsoleTableBuilder.From(lista).ExportAndWriteLine();
            else Console.WriteLine("Egy dolgozó sem csatlakozott a megadott évben.");
        }

        private static void top10LegnagyobbFizetesuDolgozo()
        {
            //Készíts listát a 10 legnagyobb fizetésű dolgozóról
            ConsoleTableBuilder.From(dolgozoadatok
                .OrderByDescending(x=> x.ber)
                .Take(10)
                .ToList())
                .ExportAndWriteLine();
        }

        private static void ReszlegenkentiStatisztika3()
        {
            //táblák összekapcsolása
            ConsoleTableBuilder
                .From(reszlegadatok
                .Select(x => new
                {
                    Részleg = x.reszleg,
                    dolgozókszáma = dolgozoadatok.Count(d => d.dolgozoreszlegid == x.reszlegid),
                    átlagfizetés = Math.Round(dolgozoadatok
                                                .Where(d => d.dolgozoreszlegid == x.reszlegid)
                                                .Select(d => d.ber)
                                                .DefaultIfEmpty(0)
                                                .Average(), 2)
                })
                .ToList())
                .ExportAndWriteLine();
        }

        private static void ReszlegenkentiStatisztika2()
        {
            Dictionary<string, (int dolgozókszáma, int összfizetés)> statisztika = new Dictionary<string, (int, int)>();
            foreach (var aktualis in adatok)
            {
                if (!statisztika.ContainsKey(aktualis.reszleg)) statisztika[aktualis.reszleg] = (0, 0);
                var jelenlegi = statisztika[aktualis.reszleg];
                statisztika[aktualis.reszleg] = (jelenlegi.dolgozókszáma + 1, jelenlegi.összfizetés + aktualis.ber);
            }
            foreach (var s in statisztika)
            {
                string reszleg = s.Key;
                int dolgozokSzama = s.Value.dolgozókszáma;
                int osszFizetes = s.Value.összfizetés;
                double atlagFizetes = dolgozokSzama > 0 ? (double)osszFizetes / dolgozokSzama : 0;
                Console.WriteLine($"{reszleg,-25}{dolgozokSzama,-5}{atlagFizetes:F2}");
            }
        }

        private static void ReszlegenkentiStatisztika()
        {
            //Készíts listát, ami részlegenként kiírja a dolgozók számát, átlagfizetését
            ConsoleTableBuilder
                .From(adatok
                .GroupBy(x => x.reszleg)
                .Select(g => new
                {
                    részleg = g.Key,
                    dolgozókszáma = g.Count(),
                    átlagbér = Math.Round(g.Average(a => a.ber), 2)
                })
                .ToList())
                .ExportAndWriteLine();

        }

        private static void adatokbetoltese()
        {
            string urlreszleg = "http://localhost:3000/reszleglista";
            reszlegadatok=Backend.GET(urlreszleg).Send().As<List<Reszleg>>();
            string urldolgozo = "http://localhost:3000/dolgozolista";
            dolgozoadatok = Backend.GET(urldolgozo).Send().As<List<Dolgozo>>();
            string urladatok = "http://localhost:3000/adatoklista";
            adatok = Backend.GET(urladatok).Send().As<List<Adatok>>();
        }
    }
}