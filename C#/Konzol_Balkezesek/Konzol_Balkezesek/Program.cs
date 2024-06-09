using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Konzol_Balkezesek
{
    internal class Program
    {
        public static List<adatsor> adatok = new List<adatsor>();
        static void Main(string[] args)
        {
            string[] f = File.ReadAllLines("balkezesek.csv", Encoding.UTF8);
            foreach (var a in f.Skip(1)) adatok.Add(new adatsor(a));

            Console.WriteLine($"3.feladat: {adatok.Count()}");

            Console.WriteLine("4.feladat:");
            adatok.Where(x => x.utolso.Year.Equals(1999)
            && x.utolso.Month.Equals(10)).ToList()
            .ForEach(x=>Console.WriteLine($"\t{x.nev} {Math.Round(x.magassag * 2.54,1)}"));

            Console.WriteLine($"5.feladat:");
            bool ok = false;
            Console.WriteLine("Kérek egy 1990 és 1999 közötti évszámot!");
            var keresem = Console.ReadLine();
            if (int.Parse(keresem) >= 1990 && int.Parse(keresem) <= 1999) ok = true;
            else ok = false;
            while (!ok)
            {
                Console.WriteLine("Hibás adat, kérek egy 1990 és 1999 közötti évszámot!");
                var evszam = Console.ReadLine();
                keresem = evszam;
                if (int.Parse(evszam) >= 1990 && int.Parse(evszam) <= 1999) ok = true;
            }

            var evszamLista = adatok.Where(x => x.elso.Year <= int.Parse(keresem)
            && x.utolso.Year >= int.Parse(keresem)).ToList();

            Console.WriteLine($"6.feladat: {Math.Round(evszamLista.Average(x => x.suly),2)} font");
            
            Console.ReadKey();
        }
    }
}