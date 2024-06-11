using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzol_Kosar
{
    internal class Program
    {
        public static List<kosarAdatok> adatok = new List<kosarAdatok>();
        static void Main(string[] args)
        {
            string[] f = File.ReadAllLines("eredmenyek.csv", Encoding.UTF8);
            foreach (var a in f.Skip(1)) adatok.Add(new kosarAdatok(a));
            Console.WriteLine($"3.feladat: Real Madrid: Hazai: {adatok.Where(x=>x.Hazai=="Real Madrid").Count()}, " +
                $" Idegen: {adatok.Where(x => x.Idegen == "Real Madrid").Count()}");
            string dontetlen = "";
            foreach (var a in adatok)
            {
                if(a.HazaiPont == a.IdegenPont) dontetlen = "igen";
                else dontetlen = "nem";
            }
            Console.WriteLine($"4.feladat: Volt döntetlen? {dontetlen}");
            var barcelona = adatok.Where(x => x.Hazai.ToLower().Contains("barcelona")).First();
            Console.WriteLine($"5.feladat: barcelonai csapat neve: {barcelona.Hazai}");
            Console.WriteLine("6.feladat:");
            DateTime KeresettIdopont = Convert.ToDateTime("2004.11.21");
            adatok.Where(x => x.Idopont.Equals(KeresettIdopont)).ToList()
                .ForEach(x => Console.WriteLine($"\t{x.Hazai} - {x.Idegen} ({x.HazaiPont}:{x.IdegenPont})"));
            Console.WriteLine($"7.feladat:");
            adatok.GroupBy(x => x.Helyszin).Where(x => x.Count() > 20).ToList()
                .ForEach(x => Console.WriteLine($"\t{x.Key}: {x.Count()}"));
            Console.ReadKey();
        }
    }
}