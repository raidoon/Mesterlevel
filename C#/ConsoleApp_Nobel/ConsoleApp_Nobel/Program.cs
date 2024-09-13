using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace ConsoleApp_Nobel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Nobel> listaNobel = new List<Nobel>();
            string[] fajl = File.ReadAllLines("nobel.csv");
            foreach (string item in fajl.Skip(1)) listaNobel.Add(new Nobel(item));
            foreach (var item in listaNobel) if (item.keresztNev == "Arthur B." && item.vezetekNev == "McDonald") Console.WriteLine($"3.feladat: {item.tipus}"); //Arthur B. McDonald milyen típusú díjat kapott?
            foreach (var item in listaNobel) if (item.ev == 2017 && item.tipus == "irodalmi") Console.WriteLine($"4.feladat: {item.keresztNev + " " + item.vezetekNev}"); //ki kapott 2017-ben irodalmi nobel-díjat
            Console.WriteLine("5.feladat:");
            foreach (var item in listaNobel) if (item.vezetekNev == "" && item.tipus == "béke" && item.ev >= 1990) Console.WriteLine($"\t{item.ev}: {item.keresztNev}");//mely szervezetek kaptak béke nobel-díjat 1990-től napjainkig
            Console.WriteLine("6.feladat:");
            //foreach (var item in listaNobel) Console.WriteLine($"\t{item.ev}: {item.keresztNev}({item.tipus})");//
            Console.WriteLine("7.feladat:");
            //foreach(var item in listaNobel) Console.WriteLine($"\t{item.tipus}\t db)"); //melyik típusú díjból hány darabot osztottak ki a nobel-díj történelme folyamán
            Console.ReadKey();
        }
    }
}