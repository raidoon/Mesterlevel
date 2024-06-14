using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleTableExt;

namespace ConsoleApp_Csincsilla
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Csincsillaadatok> adatok = new List<Csincsillaadatok>();
            string[] f = File.ReadAllLines("chi.txt", Encoding.UTF8);
            foreach (var a in f) adatok.Add(new Csincsillaadatok(a));
            ConsoleTableBuilder.From(adatok).ExportAndWriteLine();
            Console.WriteLine($"{adatok.Count()} csincsilla adatai szerepelnek az állományban");
            int simidb = adatok.Where(x => x.Simi == "I").Count();
            double Simidbszazalek = (double)simidb / adatok.Count() * 100;
            Console.WriteLine($"{Math.Round(Simidbszazalek, 2)} százaléka szereti, ha simogatják");
            Console.WriteLine("4. feladat:");
            bool van = adatok.Any(x => x.Suly < 360
              && (DateTime.Now - DateTime.Parse(x.Szul)).Days / 365.25 >= 8);
            if (van)
            {
                int index = adatok.FindIndex(x => x.Suly < 360
                && (DateTime.Now - DateTime.Parse(x.Szul)).Days / 365.25 >= 8);
                Console.WriteLine($"{adatok[index].Nev}");
            }
            else Console.WriteLine("Nincs ilyen csincsilla.");
            Console.WriteLine("5 legnagyobb súlyú csincsilla");
            var legnagyobbsulyuak = adatok.OrderByDescending(x => x.Suly)
                .Select(x => new { x.Nev, x.Suly }).Take(5).ToList();
            ConsoleTableBuilder.From(legnagyobbsulyuak).ExportAndWriteLine();
            List<string> kiirtlista = new List<string>();
            adatok.GroupBy(x => DateTime.Parse(x.Szul).Year).OrderBy(x => x.Key).ToList()
                .ForEach(x => kiirtlista.Add($"{x.Key}:{x.Count()}"));
            File.WriteAllLines("evek.txt", kiirtlista);
            var atlagsuly = adatok.Average(x => x.Suly);
            var sovanyak = adatok.Where(x => x.Suly <= atlagsuly).ToList();
            var koverek = adatok.Where(x => x.Suly > atlagsuly).ToList();
            Console.WriteLine("átlagnál kisebb súlyú csincsillák");
            ConsoleTableBuilder.From(sovanyak).ExportAndWriteLine();
            Console.WriteLine("átlagnál nagyobb súlyú csincsillák");
            ConsoleTableBuilder.From(koverek).ExportAndWriteLine();
            File.WriteAllText("sovanyak.txt", "átlagnál kisebb súlyú csincsillák\n");
            foreach (var a in sovanyak) File.AppendAllText("sovanyak.txt", $"{a.Nev};{a.Szul};{a.Suly};{a.Simi}\n");
            Console.ReadKey();
        }
    }
}