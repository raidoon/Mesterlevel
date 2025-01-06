using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using NetworkHelper;
namespace karacsonyCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool volt = false, ok = false;
            int i = 0, nap = 0, harang = 0, fenyofa = 0, angyalka = 0;
            List<Adatsor> adatok = new List<Adatsor>();
            string url = "http://localhost:3000/diszeklista";
            adatok = Backend.GET(url).Send().As<List<Adatsor>>();
            /*int napi_bevitel = adatok[1].NapiBevetel();
            Console.WriteLine(napi_bevitel);*/
            Console.WriteLine($"Adatok száma a fájlban:{adatok.Count()}");
            Console.WriteLine($"4.feladat: Összesen {adatok.Sum(a=> a.keszharang)+ adatok.Sum(a => a.keszfenyo) + adatok.Sum(a => a.keszangyal)} karácsonyi díszt készített a hölgy.");
            do
            {
                if (adatok[i].keszharang == 0 && adatok[i].keszangyal == 0 && adatok[i].keszfenyo == 0) volt = true;
                i++;
            }
            while (!volt && i < adatok.Count);

            if(volt) Console.WriteLine($"\n5.feladat: Volt olyan nap, amikor egyetlen dísz sem készült.");
            else Console.WriteLine($"\n5.feladat: Nem volt olyan nap, amikor egyetlen dísz sem készült.");

            Console.WriteLine("\n6.feladat:");
            do
            {
                Console.Write("Adja meg a keresett napot [1 ... 40]: ");
                ok = int.TryParse(Console.ReadLine(), out nap);
                if (nap <= 40 && nap >= 1) ok = true;
                else ok = false;
            }
            while (!ok);

            for(int j = 0; j < nap; j++)
            {
                harang += adatok[j].keszharang + adatok[j].eladottharang;
                angyalka += adatok[j].keszangyal + adatok[j].eladottangyal;
                fenyofa += adatok[j].keszfenyo + adatok[j].eladottfenyo;
            }
            Console.WriteLine($"\tA(z) {nap}. nap végén {harang} harang, {angyalka} angyalka és {fenyofa} fenyőfa maradt készleten.");

            Dictionary<string,int> eladottDiszek = new Dictionary<string,int>();
            eladottDiszek.Add("Harang", 0);
            eladottDiszek.Add("Angyalka", 0);
            eladottDiszek.Add("Fenyőfa", 0);
            foreach (var a in adatok)
            {
                eladottDiszek["Harang"] -= a.eladottharang;
                eladottDiszek["Angyalka"] -= a.eladottangyal;
                eladottDiszek["Fenyőfa"] -= a.eladottfenyo;
            }
            int max=eladottDiszek.Values.Max();
            Console.WriteLine($"\n7.feladat: Legtöbbet eladott dísz: {max} darab");
            foreach (var a in eladottDiszek) if(max==a.Value) Console.WriteLine($"\t{a.Key}");

            Console.ReadKey();
        }
    }
}