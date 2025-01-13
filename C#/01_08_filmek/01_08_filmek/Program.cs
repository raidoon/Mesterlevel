using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_08_filmek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Adatsor> adatok = new List<Adatsor>();
            List<double> szazMillio = new List<double>();
            bool ok = false, vanszazas = false;
            double dollar = 0.9, osszeg = 0;
            int db = 0, min = 0, max = 0;
            string[] f = File.ReadAllLines("movies.txt", Encoding.UTF8);
            foreach (string sor in f) adatok.Add(new Adatsor(sor));
            Console.WriteLine($"Filmek száma: {adatok.Count}");
            Console.WriteLine("Love szó szerepel a film nevében:");
            foreach(var i in adatok) if(i.nev.ToLower().Contains("love")) Console.WriteLine($"\t{i.nev}");
            do
            {
                Console.Write("Alsó határ: ");
                min = int.Parse(Console.ReadLine());
                Console.Write("Felső határ: ");
                max = int.Parse(Console.ReadLine());
                if (min > max)
                {
                    ok = false;
                    Console.WriteLine("Hibás bevitel");
                }
                else
                {
                    ok = true;
                    foreach (var i in adatok)
                    {
                        if (i.bevetel > 100) szazMillio.Add(i.bevetel);
                        //File.AppendAllText("100feletti.txt", $"{i.nev}\n", Encoding.UTF8);   //<-- perper, hogy ne adja hozzá minden alkalommal, amikor tesztelek!
                        vanszazas = true;
                    }
                }
            }
            while (!ok);
            if (!vanszazas) File.AppendAllText("100feletti.txt", "Nem található 100 millió dollár feletti bevételű film.");
            Console.WriteLine($"100 millió dollár feletti bevétel: {szazMillio.Count}");
            double atvaltoFuggveny(double arfolyam, double atvaltani)
            {
                double euro = arfolyam * atvaltani;
                return euro;
            }
            foreach (var i in adatok)
            {
                if (i.ertekeles >= 70)
                {
                    osszeg += atvaltoFuggveny(dollar, i.bevetel);
                    db++;
                }
            }
            Console.WriteLine($"Legalább 70%-ra értékelt filmek átlagos bevétele: {Math.Round(osszeg / db,1)} millió Euró");
            legnagyobBeveteluFilm();
            Console.Write("Adjon meg egy évszámot: ");
            kilistazottFilmek(adatok, int.Parse(Console.ReadLine()));
            atlagosErtekeles(adatok);
            Console.Write("Adja meg az értékelési küszöböt: ");
            ertekelesAlapjan(adatok, int.Parse(Console.ReadLine()));
            Console.Write("Adja meg a minimális bevételt: ");
            min = int.Parse(Console.ReadLine());
            Console.Write("Adja meg a maximális bevételt: ");
            max = int.Parse(Console.ReadLine());
            bevetelekFuggveny(adatok, min, max);
            ujfilm(adatok);
            Console.ReadKey();
        }

        private static void ujfilm(List<Adatsor> adatok)
        {
            
        }
        private static void bevetelekFuggveny(List<Adatsor> adatok, int min, int max)
        {
            Console.WriteLine($"Filmek {min} és {max} millió dollár közötti bevétellel:");
            foreach (var i in adatok)
            {
                if (i.bevetel >= min && i.bevetel <= max) Console.WriteLine($"\t{i.nev} ({i.bevetel} millió dollár)");
            }
        }
        private static void ertekelesAlapjan(List<Adatsor> adatok, int kuszob)
        {
            //for (int i = 0; i < adatok.Count; i++) if (adatok[i].ertekeles >= kuszob) File.AppendAllText("ertekeles_alapjan.txt", $"{adatok[i].nev};{adatok[i].ertekeles}%\n");
            Console.WriteLine("A filmek listája mentve lett az 'ertekeles_alapjan.txt' fájlba.");
        }
        private static void atlagosErtekeles(List<Adatsor> adatok)
        {
            double ertekeles = 0;
            int maxi = 0;
            int mini = adatok[0].ertekeles;
            foreach (var i in adatok)
            {
                ertekeles += i.ertekeles;
                if (i.ertekeles > maxi) maxi = i.ertekeles;
                if (i.ertekeles < mini) mini = i.ertekeles;
            }
            Console.WriteLine($"Átlagos értékelés: {Math.Round(ertekeles / adatok.Count, 2)}%");
            Console.WriteLine($"Legjobb film: {adatok.Where(x=> x.ertekeles==maxi).First().nev} ({adatok.Where(x => x.ertekeles == maxi).First().ertekeles}%)");
            Console.WriteLine($"Legrosszabb film: {adatok.Where(x=> x.ertekeles==mini).First().nev} ({adatok.Where(x => x.ertekeles == mini).First().ertekeles}%)");
        }
        private static void kilistazottFilmek(List<Adatsor> adatok, int evszam)
        {
            Console.WriteLine($"Filmek, amelyek {evszam} után jelentek meg:");
            foreach (var i in adatok) if (i.kiadtak > evszam) Console.WriteLine($"\t{i.nev} ({i.kiadtak})");
        }
        private static void legnagyobBeveteluFilm()
        {
            List<Adatsor> adatok = new List<Adatsor>();
            string[] f = File.ReadAllLines("movies.txt", Encoding.UTF8);
            foreach (string sor in f) adatok.Add(new Adatsor(sor));
            double max = 0;
            foreach (var i in adatok) if (i.bevetel > max) max = i.bevetel;
            var legnagyobbBevetelufilm = adatok.Where(a => a.bevetel == max).ToList();
            Console.WriteLine($"Legnagyobb bevételű film: {legnagyobbBevetelufilm.First().nev} bevétel: {legnagyobbBevetelufilm.First().bevetel}");
        }
    }
}