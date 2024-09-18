using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_utasok_adatkezelese
{
    internal class Program
    {
        public static List<adatok> adatok = new List<adatok>();
        static void Main(string[] args)
        {
            string[] fajl = File.ReadAllLines("utasadat.txt", Encoding.UTF8);
            foreach (string f in fajl) adatok.Add(new adatok(f));
            /*foreach (var i in adatok) {Console.WriteLine($"{i.MegalloSorszam,-5}{i.FelszallasDatumIdo,-15}{i.KartyaAzon,-10}
                {i.BerletTipus,-5}{i.ErvenyessegiDatum,-10}{i.ervenyessegEllenorzes()}")};*/ // ---> teszt
            
            Console.WriteLine($"Végállomástól végállomásig összesen {adatok.Count()} utas szeretett volna felszállni a buszra.");

            //hány esetben kellett a buszvezetőnek elutasítania az utas felszállását?
            int ervenytelenJegyekSzama = 0;
            foreach (var i in adatok) if (!i.ervenyessegEllenorzes()) ervenytelenJegyekSzama++;
            Console.WriteLine($"A buszvezetőnek {ervenytelenJegyekSzama} alkalommal kellett elutasítania az utas felszállását.");

            //Melyik megállóban próbált meg felszállni a legtöbb utas?
            var maxUtasSzam = adatok.GroupBy(x => x.MegalloSorszam).OrderByDescending(x => x.Count()).FirstOrDefault();
            if(maxUtasSzam!=null)  Console.WriteLine($"A {maxUtasSzam.Key}. megállóban próbált meg felszállni a legtöbb utas ({maxUtasSzam.Count()} fő).");

            //Hány ingyenes és kedvezményes bérlet volt?
            int ingyenesDB = 0, kedvezmenyesDB = 0;
            foreach (var i in adatok) if (i.ervenyessegEllenorzes())
            {
                if (i.kedvezmenyes()) kedvezmenyesDB++;
                if (i.ingyenes()) ingyenesDB++;
            }
            Console.WriteLine($"Ingyenesen utazók száma: {ingyenesDB} fő" +
                $"\nKedvezményesen utazók száma: {kedvezmenyesDB} fő");


            /*Függvény napokszama(e1:egész, h1:egész, n1: egész, e2:egész, h2: egész, n2: egész): egész
	            h1 = (h1 + 9) MOD 12s
	            e1 = e1 - h1 DIV 10
	            d1= 365*e1 + e1 DIV 4 - e1 DIV 100 + e1 DIV 400 + (h1*306 + 5) DIV 10 + n1 - 1
	            h2 = (h2 + 9) MOD 12
	            e2 = e2 - h2 DIV 10
	            d2= 365*e2 + e2 DIV 4 - e2 DIV 100 + e2 DIV 400 + (h2*306 + 5) DIV 10 + n2 - 1
	            napokszama:= d2-d1
            Függvény vége*/

            Console.ReadKey();
        }
    }
}