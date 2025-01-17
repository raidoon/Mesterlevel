using System;
using System.IO;
using NetworkHelper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statisztika
{
    internal class Program
    {
        static List<Adatsor>stat=new List<Adatsor>();//AB-ból
        static List<Adatsor>statadatok=new List<Adatsor>();//fájlból
        static void Main(string[] args)
        {
            try
            {
                adatokbetoltese();//AB-ból-->stat listába
                adatokbetolteseFajlbol("stat.txt");//fájlból-->statadatok listába
                if(stat.Count > 0)
                {
                    //Console.WriteLine($"Első azonosító:{stat[0].Azonosito}");//teszt
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            double fiuk = stat.Where(x => x.Azonosito.EndsWith("F")).Count();
            double lanyok = stat.Where(x => x.Azonosito.EndsWith("N")).Count();
            double mindenki = stat.Count();
            double osszHianyzas = stat.Sum(x => x.Hianyzas);

            Console.WriteLine($"Tanulók száma: {mindenki}");

            Console.WriteLine($"Fiúk száma: {fiuk}");

            //Console.WriteLine($"Lányok száma: {stat.Where(x=> x.Azonosito.EndsWith("N")).Count()}");
            var tavolsaglista = stat.OrderByDescending(x => x.Tavolsag).ToList();
            Console.WriteLine($"Legtávoblabb lakó tanuló: {tavolsaglista.First().Azonosito} ({tavolsaglista.First().Tavolsag} km)");

            Console.WriteLine("Kollégiumra jogosult tanulók:");
            foreach (var i in stat) if (i.Ellenorzes()) Console.WriteLine($"\t{i.Azonosito}");

            Console.WriteLine($"Legjobb átlaggal rendelkező tanuló azonosítója: {stat.OrderByDescending(x=> x.Atlag).ToList().First().Azonosito}");

            Console.WriteLine($"Összes hiányzás: {stat.Sum(x=> x.Hianyzas)}, Áltagos hiányzás: {Math.Round(osszHianyzas/mindenki,2)}");
            
            Console.WriteLine($"Fiúk aránya: {Math.Round(fiuk/mindenki*100,2)}% Lányok aránya: {Math.Round(lanyok/mindenki*100,2)}%");

            Console.WriteLine("Add meg a küszöbértéket az átlaghoz:");
            int kuszob = int.Parse(Console.ReadLine());
            Console.WriteLine($"{atlagAlatt(stat,kuszob)} tanuló átlaga van {kuszob} alatt.");

            Console.WriteLine("Legtávolabb lakó tanuló összes adata:");

            Console.WriteLine($"Azonosító: {tavolsaglista.First().Azonosito}, " +
                $"Nem: {(tavolsaglista.First().Azonosito[4] == 'N' ? "Nő" : "Férfi")}, " +
                $"Átlag: {tavolsaglista.First().Atlag}, " +
                $"Hiányzás: {tavolsaglista.First().Hianyzas}, " +
                $"Távolság: {tavolsaglista.First().Tavolsag}");

            bool nemekOK = false, felkialtojelOK = false, azonositoOK = false;
            string azonosito = "";
            int atlag = 0, hianyzas = 0, tavolsag = 0, felkialtojelDB = 0;
            do
            {
                Console.WriteLine("Adj meg egy új tanuló adatait pontosvesszővel elválasztva (azonosító;átlag;hiányzás;távolság):");
                string sor = Console.ReadLine();
                felkialtojelDB = sor.Where(x=> x==';').Count();
                if (felkialtojelDB == 3)
                {
                    string[] s = sor.Split(';');
                    if(s.Length == 4 && AzonositoEllenorzes(s[0]))
                    {
                        azonosito = s[0];
                        atlag = int.Parse(s[1]);
                        hianyzas = int.Parse(s[2]);
                        tavolsag = int.Parse(s[3]);
                        if (azonosito[4] == 'F' || azonosito[4] == 'N')
                        {
                            nemekOK = true;
                            int vaneIlyenAzonosito = stat.Where(x => x.Azonosito == azonosito).Count();
                            if (vaneIlyenAzonosito == 0)
                            {
                                azonositoOK = true;
                                Console.WriteLine("Új tanuló sikeresen hozzáadva.");
                            }
                            else
                            {
                                Console.WriteLine("Az azonosító már volt korábban!");
                                azonositoOK = false;
                            }
                        }
                        else nemekOK = false;
                    }
                }
                else felkialtojelOK = false;  
            }
            while(!nemekOK && !felkialtojelOK && !azonositoOK);
            
            if (nemekOK && felkialtojelOK && azonositoOK)
            {
                Adatsor tanuloFelvitel = new Adatsor
                {
                    Azonosito = azonosito,
                    Atlag = atlag,
                    Hianyzas = hianyzas,
                    Tavolsag = tavolsag,
                };

                string url = "http://localhost:3000/felvitel";
                string valasz = Backend.POST(url).Body(tanuloFelvitel).Send().As<string>();
                Console.WriteLine(valasz);
            }

            Console.WriteLine("Hiányzások alapján szűrt tanulók:");
            Console.Write("Add meg a hiányzási limitet: ");
            int limit = int.Parse(Console.ReadLine());
            stat.Where(x => x.Hianyzas > limit).ToList().ForEach(x => Console.WriteLine($"\t{x.Azonosito} {x.Hianyzas}"));



            Console.ReadKey();
        }

        private static bool AzonositoEllenorzes(string azonosito)
        {
            bool ok = true;
            if (azonosito.Length != 5) ok= false; // 5 karakteres? 
            if (!char.IsLetter(azonosito[0]) || !char.IsLetter(azonosito[1])) ok = false; //1-2 betű
            if (!char.IsDigit(azonosito[2]) || !char.IsDigit(azonosito[3])) ok = false;   //3-4 szám
            return ok;
        }

        private static int atlagAlatt(List<Adatsor> adatok, int kuszob)
        {
            int db = 0;
            foreach (var i in adatok) if (i.Atlag < kuszob) db++;
            return db;
        }

        private static void adatokbetolteseFajlbol(string fajlnev)
        {
            statadatok.Clear();
            if(File.Exists(fajlnev))
            {
                var sorok = File.ReadAllLines(fajlnev, Encoding.UTF8);
                foreach (var sor in sorok) 
                {
                    try
                    {
                        statadatok.Add(TanuloEllenorzes(sor));
                    }
                    catch
                    {
                        Console.WriteLine($"Hibás sor a fájlban: {sor}");
                    }
                }
            }
            else Console.WriteLine($"{fajlnev} nem létezik!");
        }

        private static Adatsor TanuloEllenorzes(string sor)
        {
            var adatok = sor.Split(';');
            return new Adatsor
            {
                Azonosito = adatok[0],
                Atlag = int.Parse(adatok[1]),
                Hianyzas = int.Parse(adatok[2]),
                Tavolsag = int.Parse(adatok[3])
            };
        }

        private static void adatokbetoltese()//beolvasás AB-ból
        {
            stat.Clear();
            string url = "http://localhost:3000/lista";
            try
            {
                stat = Backend.GET(url).Send().As<List<Adatsor>>();//listába rakom a szerver válaszát
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}