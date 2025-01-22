using System;
using System.IO;
using NetworkHelper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Net.Http;
using System.Runtime.InteropServices;

namespace telefonok_01_22
{
    internal class Program
    {
        static List<Telefon> telefonok = new List<Telefon>();
        static List<Telefon> telefonokAdatok = new List<Telefon>();//fájlból
        static void Main(string[] args)
        {
            try
            {
                adatokbetoltese("telefonok-adatok.txt");
                task1();
                task2();
                task3();
                //4.Az osztályon belül hozz létre egy tagfüggvényt regi néven, ami visszatérési értékként visszaadhat két értéket:
                //régebbi — ha 2021ben vagy előtte adták ki, vagy újabb — ha 2021 után adták ki!
                task5();
                task6();
                task7();
                task8();
                task9();
                task10();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }

        private static void task10()
        {
            //Készíts egy statisztikát arról, hogy melyik gyártótól hány telefon található a listában, és írd ki ezt egy fájlba gyarto-statisztika.txt néven!
            var gyartoStatisztika = telefonok
                .GroupBy(x => x.gyarto) 
                .OrderByDescending(x => x.Count())
                .ToList();
            foreach (var gyarto in gyartoStatisztika)
            {
                Console.WriteLine($"{gyarto.Key}: {gyarto.Count()} db modell");
            }
            using (StreamWriter sw = new StreamWriter("gyarto-statisztika.txt", false, Encoding.UTF8))
            {
                foreach (var gyarto in gyartoStatisztika)
                {
                    sw.WriteLine($"{gyarto.Key}: {gyarto.Count()} db modell");
                }
            }
            Console.WriteLine("A gyártók statisztikája sikeresen exportálva lett a 'gyarto-statisztika.txt' fájlba.");
        }

        private static void task9()
        {
            // Határozd meg, melyik gyártó készítette a legtöbb telefont a listában!
            var legtobbTelo = telefonok.GroupBy(x => x.gyarto).OrderByDescending(x => x.Count()).First();
            Console.WriteLine($"A legtöbb telefont a(z) {legtobbTelo.Key} gyártó készítette ({legtobbTelo.Count()} db).");
        }

        private static void task8()
        {
            //Kérj be egy árat a felhasználótól, és listázd ki az összes olyan telefon modelljét, amely olcsóbb ennél az árnál!
            Console.Write("Add meg a maximális árat: ");
            int.TryParse(Console.ReadLine(), out int maxi);
            var olcsobb = telefonok.Where(x=> x.eladasiar <= maxi).ToList();
            if (olcsobb.Count > 0) foreach (var telo in olcsobb) Console.WriteLine($"\t{telo.modell} ({telo.eladasiar} Ft)");
            else Console.WriteLine("Nincs olcsóbb telefon!");
        }

        private static void task7()
        {
            //Számold meg, hány telefon képes az 5G hálózat használatára!
            Console.WriteLine($"Az 5G képes telefonok száma: {telefonok.Where(x=> x.kepes5g=="igen").ToList().Count}");
        }

        private static void task6()
        {
            //Írd ki, hogy melyik telefon a legolcsóbb, és add meg a modell nevét, árát és gyártóját!
            var legolcsobb = telefonok.OrderBy(x => x.eladasiar).ToList().First();
            Console.WriteLine($"A legolcsóbb telefon: {legolcsobb.modell} ({legolcsobb.eladasiar} Ft), Gyártó: {legolcsobb.gyarto}");
        }

        private static void task5()
        {
            //5.Írd ki az apple - export.txt fájlba az összes Apple márkájú telefon modell nevét, mindegyik telefon mellé írd ki
            //az előző feladatban létrehozott regi tagfüggvény visszatérési értékét!
            var appleTelefonok = telefonok.Where(x => x.gyarto.ToLower() == "apple").ToList();
            using (StreamWriter sw = new StreamWriter("apple-export.txt", false, Encoding.UTF8))
            {
                foreach (var telo in appleTelefonok)
                {
                    string regiStatus = telo.regi();
                    sw.WriteLine($"{telo.modell} ({regiStatus})");
                }
            }
            Console.WriteLine("Az Apple telefonok exportálása megtörtént az 'apple-export.txt' fájlba.");
        }

        private static void task3()
        {
            //Kérj be a felhasználótól egy gyártó nevét, majd írd ki, hogy az adott gyártónak van-e olyan telefonja, ami 5g képes!
            Console.Write("Írj be egy telefon márkát: ");
            string marka = Console.ReadLine().ToLower();
            var markaLista = telefonok.Where(x => x.gyarto.ToLower().Contains(marka) && x.kepes5g == "igen").ToList();
            if(markaLista.Count > 0)
                foreach (var telo in markaLista) Console.WriteLine($"\t{telo.modell}");
            else Console.WriteLine("A gyártónak nincs olyan telefonja, ami 5g-re képes!");
        }

        private static void task2()
        {
            //Írd ki annak a telefonnak a gyártóját, nevét és árát, amelyik a legdrágább!
            Console.WriteLine($"A legdrágább telefon: {telefonok.OrderByDescending(x=> x.eladasiar).ToList().First().modell} ({telefonok.OrderByDescending(x => x.eladasiar).ToList().First().eladasiar} Ft)");
        }

        private static void task1()
        {
            //Írd ki, hogy mennyi a telefonok átlagára! (add össze a telefonok árait, majd oszd el modellek darabszámával)
            Console.WriteLine($"A telefonok átlagára: {telefonok.Sum(x=> x.eladasiar)/telefonok.Count} Ft");
        }

        private static void adatokbetoltese(string fajlnev)
        {
            telefonok.Clear();
            telefonokAdatok.Clear();
            string url = "http://localhost:3000/lista";
            telefonok = Backend.GET(url).Send().As<List<Telefon>>();
            if (File.Exists(fajlnev))
            {
                var sorok=File.ReadAllLines(fajlnev,Encoding.UTF8);
                foreach (var sor in sorok.Skip(1))
                {
                    var adatok = sor.Split(';');
                    var ujadat = new Telefon
                    {
                        modell = adatok[0],
                        gyarto = adatok[1],
                        eladasiar = int.Parse(adatok[2]),
                        kiadaseve = int.Parse(adatok[3]),
                        kepes5g = adatok[4]
                    };
                    telefonokAdatok.Add( ujadat );
                }
            }
            else Console.WriteLine($"Nem létezik a(z) {fajlnev} nevű fájl!");
        }
    }
}