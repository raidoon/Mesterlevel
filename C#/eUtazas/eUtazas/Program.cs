using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace eUtazas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Adatsor> adatok = new List<Adatsor>();
            string[] file = File.ReadAllLines("utasadat.txt", Encoding.UTF8);
            foreach (string sor in file) adatok.Add(new Adatsor(sor));
            Console.WriteLine($"2. feladat\nA buszra {adatok.Count} utas akart felszállni.");
            var noValidTicket = adatok
                                    .Where(x => (x.vanJegye == 0 && x.felszallasDatuma > x.cardFelhasznalhato)
                                             || (x.vanJegye == 1 && x.cardFelhasznalhato == 0))
                                    .ToList();
            Console.WriteLine($"\n3. feladat\nA buszra {noValidTicket.Count()} utas nem szállhatott fel.");
            var legtobb = adatok.GroupBy(x => x.megalloSorszama)
                                .OrderByDescending(x => x.Key)
                                .OrderByDescending (x => x.Count())
                                .ThenBy(x => x.Key)
                                .ToList();
            Console.WriteLine($"\n4. feladat\nA legtöbb utas ({legtobb.First().Count()} fő) a {legtobb.First().Key}. megállóban próbált felszállni.");
            var kedvezmenyes = adatok
                 .Where(x => ((x.vanJegye == 0 && x.felszallasDatuma <= x.cardFelhasznalhato) && (x.cardTipus == "TAB" || x.cardTipus == "NYB"))
                          || ((x.vanJegye == 1 && x.cardFelhasznalhato > 0) && (x.cardTipus == "TAB" || x.cardTipus == "NYB"))
                 ).ToList();
            Console.WriteLine($"\n5.fealdat\nIngyenesen utazók száma: " +
                $"{adatok.Where(x=> x.cardTipus=="NYP"||x.cardTipus=="RVS"||x.cardTipus=="GYK").ToList().Count} fő" +
                $"\nKedvezményesen utazók száma: {kedvezmenyes.Count} fő");
            Console.ReadKey();
        }
    }
}