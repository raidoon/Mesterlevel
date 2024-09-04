using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace oktato_program
{
    internal class Program
    {
        public static int valasz = 0, a = 0, b = 0, muvelet = 0, db = 1;
        public static string muveletjel = "";
        static void Main(string[] args)
        {
            //mennyi [véletlen szám x] + [véletlen szám y] = [kérje be a választ] 10x csinálja meg
            // plusz és minusz is véletlen legyen
            //max 20ig legyenek a véletlen számok
            int eredmeny = 0, pontszam = 0;
            Random r = new Random();
            Console.WriteLine("Összeadás és kivonás ellenőrző program (10 feladat)");

            for (int i = 0; i < 10; i++)
            {
                a = r.Next(20);
                b = r.Next(20);
                muvelet = r.Next(2);
                switch (muvelet)
                {
                    case 0: muveletjel = "+";eredmeny = a + b; break;
                        case 1: muveletjel = "-";eredmeny= a - b; break;
                }
                bool okszam = false;
                do okszam = szambekeres();
                while (!okszam);
                if (eredmeny == valasz)
                {
                    pontszam++;
                    Console.WriteLine("A válasz helyes!");
                }
                else Console.WriteLine($"A helyes válasz: {a} {muveletjel} {b} = {eredmeny}");
            }
            switch (pontszam)
            {
                case 0:
                case 1:
                case 2:
                    Console.WriteLine("Elégtelen"); break;
                case 3:
                case 4: Console.WriteLine("Elégséges"); break;
                case 5:
                case 6:
                    Console.WriteLine("Közepes"); break;
                case 7:
                case 8:
                    Console.WriteLine("Jó"); break;
                case 9:
                case 10:
                    Console.WriteLine("Jeles"); break;
            }
            Console.WriteLine("A tesztnek vége!");
            Console.ReadKey();
        }

        private static bool szambekeres()
        {
            bool ok = false;
            do
            {
                try
                {
                    Console.Write($"{db}.kérdés: \n\tMennyi {a} {muveletjel} {b} = ");
                    valasz = Convert.ToInt32(Console.ReadLine());
                    ok = true;
                    db++;
                }
                catch (Exception ex) 
                { 
                    Console.WriteLine(ex.Message);
                    ok = false;
                }
            }
            while (!ok);
            return ok;
        }
    }
}
