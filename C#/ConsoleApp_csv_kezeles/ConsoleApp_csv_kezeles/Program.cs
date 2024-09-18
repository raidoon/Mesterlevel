using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_csv_kezeles
{
    internal class Program
    {
        public static List<eredmenyek> adatok = new List<eredmenyek>();
        static void Main(string[] args)
        {
            string[] fajl = File.ReadAllLines("lista.csv", Encoding.UTF8);
            foreach (string f in fajl) adatok.Add(new eredmenyek(f));
            foreach (var i in adatok) Console.WriteLine($"{i.nev} ({i.pontszam} pont)");
            var sorbarendezett = adatok.OrderByDescending(x => x.pontszam).ToList();
            Console.WriteLine($"A legjobb versenyző: {sorbarendezett[0].nev} ({sorbarendezett[0].pontszam})");
            Console.WriteLine("1-3. helyezett:");
            for (int i = 0; i < 3; i++) Console.WriteLine($"{i + 1}. adat: {sorbarendezett[i].nev} ({sorbarendezett[i].pontszam} pont)");
            //holtverseny
            var holtverseny = adatok.GroupBy(x => x.pontszam).Where(x => x.Count() > 1).ToList();
            if (holtverseny.Count() > 0)
            {
                Console.WriteLine("Volt holtverseny!");
                foreach (var csoport in holtverseny)
                {
                    Console.WriteLine($"Pontszám: {csoport.Key}-versenyzők nevei:");
                    foreach (var item in csoport) Console.WriteLine($"{item.nev} : {item.pontszam}");
                }
            }
            else Console.WriteLine("Nem volt holtverseny!");
            Console.ReadKey();
        }
    }
}