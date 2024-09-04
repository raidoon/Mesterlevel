using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ismetles_Console_WPF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int telekszelesseg = 0, telekhossz = 0, kerulet = 0;
            Console.WriteLine("Telek kerületének kiszámítása");
            telekszelesseg = szambe("telek szélessége:");
            while (telekszelesseg <= 0); //a telekszélessége pozitív szám kell, hogy legyen

            Console.ReadKey();
        }

        private static int szambe(string szoveg)
        {
            int szam = 0;
            bool ok = false;
            do
            {
                try
                {
                    ok = false;
                    Console.Write(szoveg);
                    szam = Convert.ToInt32(Console.ReadLine());
                    if (szam <= 0)
                    {
                        ok = false;
                        Console.WriteLine(szoveg + " nem lehet - vagy 0!");
                    }
                    else ok = true;
                }
                catch
                {
                    ok = false;
                    Console.WriteLine(szoveg + " nem szám!");
                }
            }
            while (!ok);
            return szam;
        }
    }
}
