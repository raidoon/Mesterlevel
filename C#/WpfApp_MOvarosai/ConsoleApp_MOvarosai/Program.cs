using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTableExt;
using NetworkHelper;

namespace ConsoleApp_MOvarosai
{
    public class Program
    {
        static void Main(string[] args)
        {
            string urlmegye = "http://localhost:3000/megyeLista";
            List<Megye> megyeAdatok = new List<Megye>();
            megyeAdatok = Backend.GET(urlmegye).Send().As<List<Megye>>();
            ConsoleTableBuilder.From(megyeAdatok).ExportAndWriteLine();
            string urlvaros = "http://localhost:3000/varosLista";
            List<Varos> varosAdatok = new List<Varos>();
            varosAdatok = Backend.GET(urlvaros).Send().As<List<Varos>>();
            ConsoleTableBuilder.From(varosAdatok).ExportAndWriteLine();
            string urlvarostipus = "http://localhost:3000/varostipusLista";
            List<Varostipus> varostipusAdatok = new List<Varostipus>();
            varostipusAdatok = Backend.GET(urlvarostipus).Send().As<List<Varostipus>>();
            ConsoleTableBuilder.From(varostipusAdatok).ExportAndWriteLine();

            //---------------------------------- main program

            foreach(var i in megyeAdatok) Console.WriteLine($"{i.megye_id} {i.mnev}");
            Console.WriteLine($"Vár szót tartalmazó városok népessége, területe");
            var varLista = varosAdatok.Where(x => x.vnev.ToLower().Contains("vár")).Select(x => new { x.vnev, x.nepesseg, x.terulet }).ToList();
            ConsoleTableBuilder.From(varLista).ExportAndWriteLine();
            Console.WriteLine("Hajdú-Bihar megyében található városok neve, népessége:");
            var hajduLista=varosAdatok.Where(x=>x.mnev=="Hajdú-Bihar").Select(x=> new {x.vnev,x.nepesseg}).ToList();
            ConsoleTableBuilder.From(hajduLista).ExportAndWriteLine();
            Console.WriteLine("várostípusonként az átlagos népesség:");
            var atlagok = varosAdatok.GroupBy(x => x.vtip, x => x.nepesseg)
                .Select(x => new { várostípus = x.Key, átlagnépesség = Math.Round(x.Average(), 2) }).ToList();
            ConsoleTableBuilder.From(atlagok).ExportAndWriteLine() ;
            //+feladat városok kiírása fájlba
            List<string> kiirtlista = new List<string>();
            varosAdatok.ToList().ForEach(x => 
                            kiirtlista.Add($"{x.varos_id};{x.vnev};{x.vtip};{x.mnev};{x.jaras};{x.kisterseg};{x.nepesseg},{x.terulet}"));
            File.WriteAllLines("varosok.txt", kiirtlista);
            Console.ReadKey();
        }
    }
}