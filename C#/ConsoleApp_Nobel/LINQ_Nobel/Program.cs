using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp_Nobel;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace LINQ_Nobel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Nobel> listaNobel = new List<Nobel>();
            string[] fajl = File.ReadAllLines("nobel.csv");
            foreach (string item in fajl.Skip(1)) listaNobel.Add(new Nobel(item));
            //Arthur B. McDonald milyen típusú díjat kapott?
            Console.WriteLine($"3.feladat: {listaNobel.Find(x => x.keresztNev == "Arthur B." && x.vezetekNev=="McDonald").tipus}");

            // vagy: 

            var megoldas = listaNobel.Where(x=> x.keresztNev=="Arthur B."&&x.vezetekNev=="McDonald").Select(x=> x.tipus).First();

            //ki kapott 2017-ben irodalmi nobel-díjat
            Console.WriteLine($"4.feladat: {listaNobel.Find(x => x.ev == 2017 && x.tipus == "irodalmi").keresztNev} " +
                $"{listaNobel.Find(x => x.ev == 2017 && x.tipus == "irodalmi").vezetekNev}");

            //vagy

            var megoldas2 = listaNobel.Where(x => x.tipus == "irodalmi" && x.ev == 2017);
            //foreach (var i in megoldas2) Console.WriteLine($"{i.keresztNev} {i.vezetekNev}");

            //mely szervezetek kaptak béke nobel-díjat 1990-től napjainkig
            Console.WriteLine("5.feladat:");
            listaNobel
                .Where(x=> x.ev>=1990  && x.tipus=="béke" && x.vezetekNev == "")
                .ToList()
                .ForEach(x => Console.WriteLine($"\t{x.ev}: {x.keresztNev}"));

            //a curie család több tagja is kapott díjat. Határozza meg és írja ki a képernyőre minta szerint,
                //hogy melyik évben a család melyik tagja milyen díjat kapott
            Console.WriteLine("6.feladat:");
            listaNobel.Where(x => x.vezetekNev.Contains("Curie"))
                .ToList()
                .ForEach(x => Console.WriteLine($"\t{x.ev}: {x.keresztNev} {x.vezetekNev}({x.tipus})"));
            
            //melyik típusú díjból hány darabot osztottak ki a nobel-díj történelme folyamán
            Console.WriteLine("7.feladat:");
            listaNobel.GroupBy(x => x.tipus).ToList().ForEach(x => Console.WriteLine($"\t{x.Key.PadRight(20)} {x.Count()} db"));

            Console.WriteLine("8. feladat: orvosi.txt");
            using (StreamWriter sw = new StreamWriter("orvosi.txt", false, Encoding.UTF8))
                listaNobel.Where(x => x.tipus == "orvosi")
                    .OrderBy(x=> x.ev)
                    .ToList()
                    .ForEach(x => sw.WriteLine($"{x.ev}:{x.keresztNev} {x.vezetekNev}"));
            Console.ReadKey();
        }
    }
}