using System;
using System.IO;
using NetworkHelper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AB_Filmek
{
    internal class Program
    {
        static List<Adatsor> filmek = new List<Adatsor>();
        static List<Adatsor> filmekadatok = new List<Adatsor>();
        static void Main(string[] args)
        {
            adatokbetoltese();
            adatokbetolteseFajlbol("movies.csv");
            //Console.WriteLine($"{filmekadatok[0].Nev}");
            //Console.WriteLine($"{ABfilmek[0].Nev}");
            int db = filmek.Count;
            if(db>0) Console.WriteLine($"Filmek száma: {db}");
            else Console.WriteLine("Nincs adat");
            LoveFilmek(filmek);
            beviteliTartomanySzures(filmek);
            atlagosErtekeles(filmek);
            legnagyobbBeveteluFilm(filmek);
            megadottKiadasiEvUtaniFilmek(filmek);
            ertekelesStatisztika(filmek);
            ertekelesKuszob(filmek);
            beviteliTartomany(filmek);
            ujfilmekHozzaadasa(filmekadatok);
            Console.ReadKey();
        }

        private static void ujfilmekHozzaadasa(List<Adatsor> adatok)
        {
            while (true)
            {
                Console.Write("Adja meg a film nevét (vagy 'stop' a kilépéshez): ");
                string nev = Console.ReadLine();
                if (nev.ToLower() == "stop") break;
                int kiadaseve = szambe("Adja meg a kiadás évét: ");
                double bevetel = szambe2("Adja meg a bevételt (millió dollár): ");
                int ertekeles = szambe("Adja meg az értékelést (%): ");
                File.AppendAllText("movies.csv", $"{adatok.Max(x => x.Id + 1)};{nev};{kiadaseve};{bevetel};{ertekeles}\n");
                Console.WriteLine("új film adatai rögzítve a movies.csv-be");
                Adatsor filmfelvitel = new Adatsor
                {
                    Nev = nev,
                    Kiadaseve = kiadaseve,
                    Bevetel = bevetel,
                    Ertekeles = ertekeles,
                };
                string url = "http://localhost:3000/ujfilmfelvitel";
                string valasz = Backend.POST(url).Body(filmfelvitel).Send().As<string>();
                Console.WriteLine(valasz);
            }
        }
        private static void beviteliTartomany(List<Adatsor> adatok)
        {
            int db = 0;
            int min = szambe("Adja meg a minimális bevételt: ");
            int max = szambe("Adja meg a maximális bevételt: ");
            if (min > max) Console.WriteLine("Hibás adatok");
            else
            {
                Console.WriteLine($"Filmek {min} és {max} millió dollár közötti bevétellel:");
                foreach (Adatsor i in adatok)
                {
                    if (i.Bevetel >= min && i.Bevetel <= max) Console.WriteLine($"\t{i.Nev} ({i.Bevetel} millió dollár)");
                    db++;
                }
                if(db==0) Console.WriteLine($"Nincs {min} és {max} millió dollár közötti bevételű film.");
            }
        }
        private static void ertekelesKuszob(List<Adatsor> adatok)
        {
            int kuszob = szambe("Adja meg az értékelési küszöböt: ");
            List<string> kiirtLista = new List<string>();
            foreach (Adatsor i in adatok) if (i.Ertekeles > kuszob) kiirtLista.Add($"{i.Nev};{i.Ertekeles}%");

            if (kiirtLista.Count > 0) File.WriteAllLines("ertekeles_alapjan.txt", kiirtLista);
            else Console.WriteLine($"Nincs {kuszob}-nél jobb értékelésű film.");
        }
        private static void ertekelesStatisztika(List<Adatsor> adatok)
        {
            double atlagosErtekeles = adatok.Average(x => x.Ertekeles);
            var legjobbFilm = adatok.OrderByDescending(x => x.Ertekeles).First();
            var legrosszabbFilm = adatok.OrderBy(x => x.Ertekeles).First();
            Console.WriteLine($"Átlagos értékelés: {Math.Round(atlagosErtekeles, 2)}%" +
                $"\nLegjobb film: {legjobbFilm.Nev} ({legjobbFilm.Ertekeles}%)" +
                $"\nLegrosszabb film: {legrosszabbFilm.Nev} ({legrosszabbFilm.Ertekeles}%)");
        }
        private static void megadottKiadasiEvUtaniFilmek(List<Adatsor> adatok)
        {
            int ev = szambe("Adjon meg egy évszámot: ");
            var szurtFilmek = adatok.Where(x => x.Kiadaseve > ev).ToList();
            if (szurtFilmek.Any())
            {
                Console.WriteLine($"Filmek, amelyek {ev} után jelentek meg: ");
                foreach (var i in szurtFilmek) Console.WriteLine($"\t{i.Nev} ({i.Kiadaseve})" );
            }else Console.WriteLine($"Nincs {ev} utáni film!");
        }
        private static void legnagyobbBeveteluFilm(List<Adatsor> adatok)
        {
            var maxFilm = adatok.OrderByDescending(x => x.Bevetel).First();
            Console.WriteLine($"Legnagyobb bevételű film: {maxFilm.Nev}, bevétel: {maxFilm.Bevetel} millió dollár");
        }
        private static void atlagosErtekeles(List<Adatsor> adatok)
        {
            double arfolyam = 0.9;
            double osszBevetel = adatok.Where(x => x.Ertekeles > 70).Sum(x => x.Bevetel);
            Console.WriteLine($"Legalább 70%-ra értékelt filmek átlagos bevétele: " +
                $"{Math.Round(DollarToEuro(arfolyam, osszBevetel) / adatok.Where(x => x.Ertekeles > 70).Count(), 1)} millió Euró");
        }
        private static double DollarToEuro(double arfolyam, double osszBevetel) { return Math.Round(arfolyam * osszBevetel, 2); }
        private static void beviteliTartomanySzures(List<Adatsor> adatok)
        {
            int alsoHatar = szambe("Alsó határ: ");
            int felsoHatar = szambe("Felső határ: ");
            if (felsoHatar > alsoHatar)
            {
                var nagyBeveteluFilmek = adatok.Where(x => x.Bevetel > 100 & x.Kiadaseve >= alsoHatar && x.Kiadaseve <= felsoHatar).ToList();
                List<string> kiirtLista = new List<string>();
                if (nagyBeveteluFilmek.Any()) foreach (var i in nagyBeveteluFilmek) kiirtLista.Add(i.Nev);
                else kiirtLista.Add($"Nem található 100 millió dollár feletti bevételű film ({alsoHatar} - {felsoHatar}) között.");
                File.WriteAllLines("100feletti2.txt", kiirtLista);
                Console.WriteLine($"100 millió dollár feletti bevétel: {nagyBeveteluFilmek.Count}");
            }
            else Console.WriteLine("Az alsó határ nem lehet nagyobb, mint a felső!");
        }
        private static int szambe(string szoveg)
        {
            int szam = 0;
            bool ok = false;
            do
            {
                Console.Write(szoveg);
                ok = int.TryParse(Console.ReadLine(), out szam) && szam > 0;
            }
            while (!ok);
            return szam;
        }
        private static double szambe2(string szoveg)
        {
            double szam = 0;
            bool ok = false;
            do
            {
                Console.Write(szoveg);
                ok = double.TryParse(Console.ReadLine(), out szam) && szam > 0;
            }
            while (!ok);
            return szam;
        }
        private static void LoveFilmek(List<Adatsor> filmek)
        {
            Console.WriteLine("Love szó szerepel a film nevében:");
            foreach (Adatsor i in filmek) if (i.Nev.ToLower().Contains("love")) Console.WriteLine($"\t{i.Nev}");
        }
        private static void adatokbetolteseFajlbol(string fajlnev)
        {
            if (!File.Exists(fajlnev))
            {
                Console.WriteLine($"{fajlnev} nem létezik");
                return;
            }
            try
            {
                var sorok = File.ReadAllLines("movies.csv", Encoding.UTF8);
                foreach (var sor in sorok.Skip(1))
                {
                    var adatok = sor.Split(';');
                    if (adatok.Length == 5)
                    {
                        var film = new Adatsor
                        {
                            Id = int.Parse(adatok[0]),
                            Nev = adatok[1],
                            Kiadaseve = int.Parse(adatok[2]),
                            Bevetel = double.Parse(adatok[3].Replace('.', ',')),
                            Ertekeles = int.Parse(adatok[4]),
                        };
                        filmekadatok.Add(film);
                    }
                }
                Console.WriteLine("Sikeres fájlbeolvasás");
            }
            catch (Exception ex) {Console.WriteLine(ex.Message );}
        }
        private static void adatokbetoltese()
        {
            string url = "http://localhost:3000/filmeklista";
            filmek = Backend.GET(url).Send().As<List<Adatsor>>();
        }
    }
}