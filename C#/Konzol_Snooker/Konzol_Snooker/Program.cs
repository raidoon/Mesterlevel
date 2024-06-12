using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Konzol_Snooker
{
    internal class Program
    {
        public static List<adatsor> adatok = new List<adatsor>();
        static void Main(string[] args)
        {
            string[] f = File.ReadAllLines("snooker.txt", Encoding.UTF8);
            foreach (var a in f.Skip(1)) adatok.Add(new adatsor(a));
            Console.WriteLine($"3.feladat: A világranglistán {adatok.Count()} versenyző szerepel");
            
            Console.WriteLine($"4.feladat: A versenyzők átlagosan {adatok.Average(x=>x.nyeremeny):### ###.##} fontot kerestek");

            Console.WriteLine($"5.feladat: A legjobban kereső Kínai versenyző:");
            var legjobbankereso = adatok.Where(x => x.orszag == "Kína").OrderByDescending(x => x.nyeremeny).First();

            Console.WriteLine($"\tHelyezés: {legjobbankereso.helyezes}" +
                $"\n\tNév: {legjobbankereso.nev}" +
                $"\n\tOrszág: {legjobbankereso.orszag}" +
                $"\n\tNyeremény összege: {legjobbankereso.nyeremeny * 380:### ### ###} Ft");

            bool vanNorvegVersenyzo = adatok.Any(x => x.orszag == "Norvégia");
            if(vanNorvegVersenyzo)
            {
                int norvegVersenyzoIndexe = adatok.FindIndex(x => x.orszag == "Norvégia") + 1;
                Console.WriteLine($"6.feladat: Van norvég versenyző a listában. Az első norvég versenyző az " +
                    $"adatok között a(z) {norvegVersenyzoIndexe}. sorban található.");
            }
            else Console.WriteLine("6.feladat: Nincs norvég versenyző a listában.");

            Console.WriteLine("7.feladat: Statisztika");
            adatok.GroupBy(x => x.orszag).Where(x=>x.Count()>4).ToList()
                .ForEach(x=>Console.WriteLine($"\t{x.Key} - {x.Count()} fő"));
            Console.ReadKey();
        }
    }
}