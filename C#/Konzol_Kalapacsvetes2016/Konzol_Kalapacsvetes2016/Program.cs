using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzol_Kalapacsvetes2016
{
    internal class Program
    {
        public static List<Versenyzo> adatok = new List<Versenyzo>();
        static void Main(string[] args)
        {
            string[] f = File.ReadAllLines("kalapacsvetes2016.txt",Encoding.UTF8);
            foreach (var i in f) adatok.Add(new Versenyzo(i));
            foreach (var a in adatok)
            {
                Console.Write($"{a.Nev,-25}{a.Orszag,-20}");
                for (int i = 0; i < a.Dobasok.Count(); i++) Console.Write($"{a.Dobasok[i],-7}");
                Console.WriteLine();
            }
            Console.WriteLine($"5.feladat: Döntőbe jutott versenyzők száma: {adatok.Count()}");
            int DontotFolytathatott = adatok.Count(x=>x.Dobasok.Count()>3);
            Console.WriteLine($"6.feladat: A 3. dobás után {adatok.Count(x=>x.Dobasok.Count()>3)}" +
                                                        $" versenyző folytathatta a döntőt");
            Console.WriteLine($"7.feladat: Statisztika (név;érvényes dobás;sikertelen dobás; legjobb dobás)");
            Dictionary<string, double> vegeredmeny = new Dictionary<string, double>();
            foreach (var a in adatok)
            {
                if (a.Dobasok.Count() > 3)
                {
                    int ErvenyesDobasok = a.Dobasok.Count(d => d != "x");
                    int ErvenytelenDobasok = a.Dobasok.Count(d => d == "x");
                    double LegjobbDobas = a.Dobasok.Where(d => d != "x").Max(d => double.Parse(d));
                    Console.WriteLine($"\t{a.Nev};{ErvenyesDobasok};{ErvenyesDobasok};{LegjobbDobas} m");
                    vegeredmeny.Add(a.Nev, LegjobbDobas);
                }
            }

            /*adatok.Where(x => x.Orszag == "Magyarország").ToList()
                .ForEach(x=> Console.WriteLine($"8.feladat:" +
                $" A magyar versenyző {x.Nev} {vegeredmeny.Where(n=> n.Key == x.Nev).ToList()}. lett"));*/
            
            Console.WriteLine("Végeredmény:");
            int j = 0;
            var magyarVersenyzo = adatok.FirstOrDefault(x => x.Orszag == "Magyarország");
            if (magyarVersenyzo != null)
            {
                var helyezes = adatok.Count(x => x.Dobasok.Count > 3 &&
                    x.Dobasok.Where(d => d != "x").Max(d => double.Parse(d)) >
                        magyarVersenyzo.Dobasok.Where(d => d != "x").Max(d => double.Parse(d)));
                Console.WriteLine($"A magyar versenyző Pars Krisztián {helyezes+1}. lett");
            }
            
            foreach (var v in vegeredmeny.OrderByDescending(x => x.Value))
            {
                j++;
                Console.WriteLine($"\t{j} helyezés: {v.Key,-25}: {v.Value}");
            }

            double eredmeny;
            string szoveg = "";
            File.WriteAllText("kalapacsvetes2016inch.txt", "Eredmények inch-ben\n");
            foreach (var a in adatok)
            {
                szoveg = $"{a.Nev};{a.Orszag};";
                foreach (var k in a.Dobasok)
                {
                    if (k != "x")
                    {
                        eredmeny = double.Parse(k) * 100 / 2.54; //1 coll = 2.54 cm 
                        szoveg += $"{Math.Round(eredmeny, 3)};";
                    }
                    else szoveg += "x";
                }
                szoveg += "\n";
                File.AppendAllText("kalapacsvetes2016inch.txt", szoveg);
            }
            Console.ReadKey();
        }
    }
}