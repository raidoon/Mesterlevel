using System;
using System.Collections.Generic;
using ConsoleTableExt;
using NetworkHelper;

namespace ConsoleApp_berek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:3000/dolgozok_lekerdez";
            List<Adatsor> adatok = Backend.GET(url).Send().As<List<Adatsor>>();
            ConsoleTableBuilder.From(adatok).ExportAndWriteLine();


            Console.ReadKey();
        }
    }
}