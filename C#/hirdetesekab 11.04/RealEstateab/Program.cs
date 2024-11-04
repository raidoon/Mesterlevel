using System;
using NetworkHelper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:3000/hirdeteseklista";
            List<Adatsor> adatok = Backend.GET(url).Send().As<List<Adatsor>>();
            Console.WriteLine($"eladásra kínált földszinti ingatlanok átlagos alapterülete:{Math.Round(adatok.Where(x => x.emelet == 0).Average(x => x.alapterulet), 2)} m2");
            var legkozelebbi = adatok.Where(x => x.tehermentes)
                .OrderBy(x => x.DistanceTo(47.4164220114023, 19.066342425796986)).First();
            Console.WriteLine($"Mesevár ovodához legközelebbi tehermentes ingatlan" +
                $"\n\tEladó neve:{legkozelebbi.hirdetonev}" +
                $"\n\tEladó telefonszáma:{legkozelebbi.hirdetotelefon}" +
                $"\n\tAlapterület:{legkozelebbi.alapterulet}" +
                $"\n\tSzobaszám:{legkozelebbi.szobaszam}");
            var sorba = adatok.OrderByDescending(x => x.alapterulet).ToList();
            Console.WriteLine($"a legnagyobb alapterületű ingatlan adatai" +
                $"\n\tEladó neve:{sorba[0].hirdetonev}" +
                $"\n\tEladó telefonszáma:{sorba[0].hirdetotelefon}" +
                $"\n\tAlapterület:{sorba[0].alapterulet}" +
                $"\n\tSzobaszám:{sorba[0].szobaszam}");
            /*Készítsen Statisztikát a minta szerint hirdetők neve szerint a hirdetések számáról (csak az jelenjen meg aki több hirdetést adott fel)*/
            Console.WriteLine("hirdetők neve szerint a hirdetések száma");
            adatok.GroupBy(x => x.hirdetonev)//hirdetők neve szerint
                .Where(x => x.Count() >= 2)//aki több hirdetést adott fel
                .OrderByDescending(x => x.Count())
                .ToList()
                .ForEach(x => Console.WriteLine($"\t{x.Key}:{x.Count()}"));//hirdetők neve szerint a hirdetések száma
            /*. Készítsen Statisztikát a minta szerint ingatlankategóriák szerint a hirdetések számáról*/
            Console.WriteLine("ingatlankategóriák szerint a hirdetések száma");
            adatok.GroupBy(x => x.kategorianev)//ingatlankategóriák szerint                
                .OrderByDescending(x => x.Count())
                .ToList()
                .ForEach(x => Console.WriteLine($"\t{x.Key}:{x.Count()}"));//ingatlankategóriák szerint a hirdetések száma
            //Kérjen be egy nevet és írja ki a hirdetés adatait
            Console.Write("Kérek egy nevet:");
            string keresettnev = Console.ReadLine();
            int db = 0;
            foreach (var a in adatok)
                if (a.hirdetonev.ToLower().Contains(keresettnev.ToLower()))
                {
                    Console.WriteLine($"\n\tEladó neve:{a.hirdetonev}" +
                $"\n\tEladó telefonszáma:{a.hirdetotelefon}" +
                $"\n\tAlapterület:{a.alapterulet}" +
                $"\n\tKoordináta:{a.szelesseg},{a.hosszusag}" +
                $"\n\tSzobaszám:{a.szobaszam}");
                    db++;
                }
            if (db == 0) Console.WriteLine("Nincs ilyen hirdető");
            Console.ReadKey();
        }
        
    }
}
