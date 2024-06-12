using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Konzol_kutyak
{
    internal class Program
    {
        public static List<kutyanevek> nevek = new List<kutyanevek>();
        public static List<kutyafajtak> fajtak = new List<kutyafajtak>();
        public static List<kutya> kutyaadatok = new List<kutya>();
        static void Main(string[] args)
        {
            string[] f = File.ReadAllLines("KutyaNevek.csv",Encoding.UTF8);
            string[] f2 = File.ReadAllLines("KutyaFajtak.csv",Encoding.UTF8);
            string[] f3 = File.ReadAllLines("Kutyak.csv",Encoding.UTF8);

            foreach (var a in f.Skip(1)) nevek.Add(new kutyanevek(a));
            foreach (var a in f2.Skip(1)) fajtak.Add(new kutyafajtak(a));
            foreach (var a in f3.Skip(1)) kutyaadatok.Add(new kutya(a));

            for (int i = 0; i < kutyaadatok.Count(); i++)
            {
                for (int j = 0; j < fajtak.Count(); j++)
                {
                    if (kutyaadatok[i].fajtaid == fajtak[j].fajtaid)
                        kutyaadatok[i].fajtanev = fajtak[j].fajtanev;
                }
                for (int j = 0;j < nevek.Count(); j++)
                {
                    if (kutyaadatok[i].nevekid == nevek[j].id) 
                        kutyaadatok[i].kutyanev = nevek[j].kutyanev;
                }
            }
            //Console.WriteLine(kutyaadatok[0].kutyanev);
            //Console.WriteLine(kutyaadatok[0].fajtanev);
            Console.WriteLine($"3.feladat: Kutyanevek száma: {nevek.Count()}");
            
            Console.WriteLine($"6.feladat: A kutyák átlagéletkora: {Math.Round(kutyaadatok.Average(x => x.eletkor),2)}");
            
            var legidosebbKutya=kutyaadatok.OrderByDescending(x=>x.eletkor).First();
            Console.WriteLine($"7.feladat: A legidősebb kutya neve és fajtája: " +
                $"{legidosebbKutya.kutyanev}, {legidosebbKutya.fajtanev}");
            
            Console.WriteLine($"8.feladat: január 10-én vizsgált kutya fajták");
            kutyaadatok.Where(x=>x.ellenorzes.Date.Equals(DateTime.Parse("2018.01.10")))
                .GroupBy(x => x.fajtanev).ToList()
                .ForEach(x => Console.WriteLine($"\t{x.Key}: {x.Count()} kutya"));

           Dictionary<string,int> napokLista = new Dictionary<string,int>();
            foreach (var a in kutyaadatok)
            {
                string kulcs = a.ellenorzes.ToString("yyyy-MM-dd");
                if (napokLista.ContainsKey(kulcs)) napokLista[kulcs]++;
                else napokLista.Add(kulcs, 1);
            }
            var LegjobbanLeterheltNap = napokLista.OrderByDescending(x => x.Value).First();
            Console.WriteLine($"9.feladat: Legjobban leterhelt nap: {LegjobbanLeterheltNap.Key}: {LegjobbanLeterheltNap.Value} kutya");

            kutyaadatok.GroupBy(x => x.kutyanev).OrderByDescending(x => x.Count()).ToList()
                .ForEach(x => File.AppendAllText("nevstatisztika.txt", $"{x.Key};{x.Count()}\n"));

            Console.ReadKey();
        }
    }
}