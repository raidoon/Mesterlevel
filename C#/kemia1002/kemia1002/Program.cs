using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetworkHelper;
using ConsoleTableExt;
using System.Linq;

namespace kemia1002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:3000/felfedezesekLista";
            List<Adatsor> adatok =Backend.GET(url).Send().As<List<Adatsor>>();
            //ConsoleTableBuilder.From(adatok).ExportAndWriteLine();
            Console.WriteLine($"{adatok.Count} kémiai elem felfedezési adatai találhatók.");
            Console.WriteLine($"Ókorban felfedezett kémiai elemek száma: {adatok.Where(x=>x.ev=="Ókor").Count()} db.");
            bool ok = false;
            string vegyjelnev;
            string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int db = 0;
            do
            {
                db = 0;
                ok = false;
                Console.Write("Kérem a vegyjelet: ");
                vegyjelnev = Console.ReadLine().ToUpper();
                if(vegyjelnev.Length==1 || vegyjelnev.Length == 2)
                {
                    for (int j = 0; j < vegyjelnev.Length; j++)
                    {
                        if (abc.Contains(vegyjelnev[j])) db++;
                    }
                    if(db==vegyjelnev.Length) ok = true;
                }
            }
            while(!ok);
            bool van = false;
            int i = 0;
            while (i < adatok.Count && adatok[i].vegyjel.ToUpper().CompareTo(vegyjelnev) != 0)
            {
                i++;
            }
            van=i<adatok.Count()?true:false;
            if (van)
            {
                Console.WriteLine($"6.feladat: Keresés" +
                    $"              \n\tAz elem vegyjele: {adatok[i].vegyjel}" +
                    $"              \n\tAz elem neve: {adatok[i].elem}" +
                    $"              \n\tRendszáma: {adatok[i].rendszam}" +
                    $"              \n\tFelfedezés éve: {adatok[i].ev}" +
                    $"              \n\tFelfedező: {adatok[i].felfedezo}");
            }
            else Console.WriteLine("6.feladat: Nincs ilyen elem az adatbázisban!");
            var sorbarendezettLista = adatok.Where(x => x.ev != "Ókor").OrderByDescending(x => x.ev).ToList();
            int legnagyobbKulonbseg = 0;
            for (i = 1; i < sorbarendezettLista.Count(); i++)
            {
                int kulonbseg = int.Parse(sorbarendezettLista[i - 1].ev) - int.Parse(sorbarendezettLista[i].ev);
                if (kulonbseg > legnagyobbKulonbseg) legnagyobbKulonbseg = kulonbseg;
            }
            Console.WriteLine($"7. feladat: {legnagyobbKulonbseg} év volt a leghosszabb időszak két elem felfedezése között.");
            Console.WriteLine("8. feladat: Statisztika");
            var evLista = adatok.Where(x => x.ev != "Ókor").GroupBy(x => x.ev).ToList();
            evLista.Where(x => x.Count() > 3).ToList().ForEach(x => Console.WriteLine($"\t{x.Key}: {x.Count()} db"));
            Console.ReadKey();
        }
    }
}