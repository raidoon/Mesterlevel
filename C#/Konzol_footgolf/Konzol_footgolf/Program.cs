using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using footgolf;

namespace Konzol_footgolf
{
    internal class Program
    {
        public static List<adatsor> Versenyzoadatok = new List<adatsor>();
        static void Main(string[] args)
        {
            string[] f = File.ReadAllLines("fob2016.txt",Encoding.UTF8);
            foreach (var a in f) Versenyzoadatok.Add(new adatsor(a));
            Console.WriteLine($"3.feladat: Versenyzők száma: {Versenyzoadatok.Count()}");
            double noiversenyzokszama = Versenyzoadatok.Where(x=> x.Kategoria == "Noi").Count();
            Console.WriteLine($"4.feladat: A női versenyzők aránya: " +
                $"{Math.Round(noiversenyzokszama/Versenyzoadatok.Count()*100,2)}%");
            Console.WriteLine($"6.feladat: A bajnok női versenyző");
            var noibajnok = Versenyzoadatok.Where(x => x.Kategoria == "Noi")
                .OrderByDescending(x => x.osszpontszamfuggveny).First();
            Console.WriteLine($"\tNév: {noibajnok.Nev}" +
                              $"\n\tEgyesület: {noibajnok.Egyesulet}" +
                              $"\n\tÖsszpont: {noibajnok.osszpontszamfuggveny}");

            //osszpontFF.txt
            List<string> kiirtsor = new List<string>();
            foreach (var a in Versenyzoadatok)
            {
                if (a.Kategoria == "Felnott ferfi")
                {
                    kiirtsor.Add($"{a.Nev};{a.osszpontszamfuggveny}");
                }
            }
            File.WriteAllLines("osszpontFF.txt", kiirtsor);
            Console.WriteLine("7.feladat lefutott");
            //7.feladat másképp
            Versenyzoadatok.Where(x=>x.Kategoria == "Felnott ferfi")
                .OrderByDescending(x=>x.osszpontszamfuggveny)
                .ToList().ForEach(x => File.AppendAllText("osszpontFF2.txt",$"{x.Nev};{x.osszpontszamfuggveny}\n"));
            
            Console.WriteLine("8.feladat: Egyesület statisztika");
            Versenyzoadatok.GroupBy(x => x.Egyesulet).Where(x=>x.Key !="n.a." && x.Count()>2).ToList()
                .ForEach(x=> Console.WriteLine($"\t{x.Key} - {x.Count()} fő"));

            //Így igazi statisztika:

            Dictionary<string, int> egyesuletdb = new Dictionary<string, int>();
            foreach (var x in Versenyzoadatok)
            {
                if (egyesuletdb.ContainsKey(x.Egyesulet)) egyesuletdb[x.Egyesulet]++;
                else egyesuletdb.Add(x.Egyesulet, 1); //aktuális egyesületet 1es értékkel adjuk hozzá
            }
            foreach (var item in egyesuletdb)
            {
                if (item.Key != "n.a." && item.Value > 2) 
                    Console.WriteLine($"{item.Key} - {item.Value} fő");
            }
            Console.ReadKey();
        }
    }
}