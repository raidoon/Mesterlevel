using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Konzol_Elnok
{
    internal class Program
    {
        public static List<adatsor> adatok = new List<adatsor>();
        static void Main(string[] args)
        {
            //elnokok.txt
            string[] f = File.ReadAllLines("elnokok.txt", Encoding.UTF8);
            foreach (var i in f) adatok.Add(new adatsor(i));
            //Elnokikor(adatok[0].szuletes, adatok[0].kezdet);
            Console.WriteLine("2.feladat");
            Console.WriteLine($"\tAz Amerikai Egyesült Államok {adatok.Count()} elnöke");

            Console.WriteLine("4.feladat");

            int legfiatalabbelnokikor = adatok.Min(x => Elnokikor(x.szuletes, x.kezdet));

            var legfiatalabb = adatok.Where(x=> x.kezdet-x.szuletes == legfiatalabbelnokikor).First();

            Console.WriteLine($"\tA legfiatalabb elnök neve: {legfiatalabb.nev}" +
                            $"\n\tA legfiatalabb elnök született: {legfiatalabb.szuletes}" +
                            $"\n\tA legfiatalabb elnököt beiktatták: {legfiatalabb.kezdet}");

            //Vege(adatok[0].halala, adatok[0].veg);
            Console.WriteLine("6.feladat");
            Console.WriteLine($"\t{adatok.Where(x=> Vege(x.halala,x.veg)).Count()} elnök hunyt el");

            Console.WriteLine("7.feladat");
            adatok.Where(x => x.part == "Demokrata" && x.veg - x.kezdet == 12).ToList().ForEach(x => Console.WriteLine($"\t3 ciklust töltött ki: {x.nev}"));

            List<string> republikanus = new List<string>();
            var republikanus2 = adatok.Where(x => x.part == "Republikánus").ToList();
            //Abraham Lincoln|1861|1865|Republikánus|1809|1865
            foreach (var i in republikanus2) republikanus.Add($"{i.nev}|{i.szuletes}|{i.halala}|{i.part}|{i.kezdet}|{i.veg}");

            File.WriteAllLines("republikanus.txt", republikanus);
            Console.ReadKey();
        }

        private static bool Vege(int halala, int mandatumvege)
        {
            if (halala == mandatumvege) return true;
            else return false;
        }

        private static int Elnokikor(int szuletes, int beiktatas)
        {
            int kor = beiktatas - szuletes;
            return kor;
        }
    }
}
