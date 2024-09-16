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
            //Arthur B. McDonald milyen típusú díjat kapott?
            foreach (var item in listaNobel) if (item.keresztNev == "Arthur B." && item.vezetekNev == "McDonald") Console.WriteLine($"3.feladat: {item.tipus}");
            //ki kapott 2017-ben irodalmi nobel-díjat
            foreach (var item in listaNobel) if (item.ev == 2017 && item.tipus == "irodalmi") Console.WriteLine($"4.feladat: {item.keresztNev + " " + item.vezetekNev}"); 
            //mely szervezetek kaptak béke nobel-díjat 1990-től napjainkig
            Console.WriteLine("5.feladat:");
            foreach (var item in listaNobel) if (item.vezetekNev == "" && item.tipus == "béke" && item.ev >= 1990) Console.WriteLine($"\t{item.ev}: {item.keresztNev}");
            //a curie család több tagja is kapott díjat. Határozza meg és írja ki a képernyőre minta szerint, hogy melyik évben a család melyik tagja milyen díjat kapott
            Console.WriteLine("6.feladat:");
            foreach (var item in listaNobel) if(item.vezetekNev.Contains("Curie")) Console.WriteLine($"\t{item.ev}: {item.keresztNev} {item.vezetekNev}({item.tipus})");
            //melyik típusú díjból hány darabot osztottak ki a nobel-díj történelme folyamán
            Console.WriteLine("7.feladat:");
            List<string> tipusok = new List<string>();
            
            foreach(var item in listaNobel)
            {
                if (tipusok.Contains(item.tipus)) { }
                else
                {
                     tipusok.Add(item.tipus);
                }
            }
            foreach (var item in tipusok) Console.WriteLine($"\t{item}");

            //orvosi.txt néven egy utf-8 kódolású fájl --> tartalmazza az összes kiosztott orvosi nobel-díj adatait
            Console.ReadKey();
        }
    }
}