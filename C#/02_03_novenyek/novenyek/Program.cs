using System;
using NetworkHelper;
using ConsoleTableExt;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace novenyek
{
    internal class Program
    {
        static List<Adatsor> adatok = new List<Adatsor>();
        static void Main(string[] args)
        {
            string url = "http://localhost:3000/lista";
            adatok = Backend.GET(url).Send().As<List<Adatsor>>();
            ConsoleTableBuilder.From(adatok).ExportAndWriteLine();
            Console.WriteLine($"növények száma: {adatok.Count}");
            Console.WriteLine($"Átlagár: {adatok.Average(x=> x.ar)} Ft");
            var legdragabb = adatok.OrderByDescending(x=> x.ar).ToList();
            Console.WriteLine($"Legdrágább neve: {legdragabb.First().nev}, ára: {legdragabb.First().ar} Ft");
            Console.WriteLine($"Legolcsóbb neve: {legdragabb.Last().nev}, ára: {legdragabb.Last().ar} Ft");
            Console.WriteLine($"{adatok.Where(x => x.ar > 5000).Count()} db 5000-nél drágább van.");
            Console.WriteLine($"{adatok.Where(x => x.ar < 4000).Count()} db fa van, ami olcsóbb, mint 4000Ft.");
            //6.	Az átlagárak tipusonként! (GroupBy, Select, Average, OrderByDescending, ToList)
            var atlagarak = adatok.GroupBy(x => x.tipus)
                .Select(x => new { tipus = x.Key, atlagár = x.Average(y => y.ar) })
                .OrderByDescending(x => x.atlagár)
                .ToList();
            ConsoleTableBuilder.From(atlagarak).ExportAndWriteLine();
            var viragok = adatok.Where(x=> x.tipus=="Virág").OrderByDescending(x=>x.ar).ToList();
            Console.WriteLine($"A virágok közül a {viragok.First().nev} ({viragok.First().ar} Ft), amely a legdrágább.");
           var olcsoVirag = adatok.Where(x => x.tipus == "Virág" && x.ar < 1000).ToList();
            if (olcsoVirag.Count != 0)
            {
                Console.WriteLine($"Van-e olyan növény, amelynek ára 1000 Ft alatti és típusa virág: igen ({olcsoVirag.First().nev} ára: {olcsoVirag.First().ar})");
            }
            else Console.WriteLine("Van-e olyan növény, amelynek ára 1000 Ft alatti és típusa virág: nem");

            var idk = adatok.Any(x => x.vizigeny == "alacsony" && x.tipus == "Dísznövény");
            if (idk) Console.WriteLine("Van-e olyan dísznövény, amely vízigénye alacsony: igen");
            else Console.WriteLine("Van-e olyan dísznövény, amely vízigénye alacsony: nem");
            var eredmeny = adatok.GroupBy(x => x.tipus)
                .OrderByDescending(x => x.Count())
                .Select(x => new { tipus = x.Key, darab = x.Count() })
                .ToList();
            ConsoleTableBuilder.From(eredmeny).ExportAndWriteLine();



            Console.ReadKey();
        }
    }
}