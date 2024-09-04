using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telefon_Console_WPF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo lenyomott_gomb = new ConsoleKeyInfo();
            string telefonszam = ""; //begépelt értékek
            string szamok = "0123456789"; //érvényes karakterek
            int db = 0;
            do
            {
                db = 0;
                telefonszam = "";
                Console.Write("Kérem a telefonszámot (a 06 után!): ");
                do
                {
                    lenyomott_gomb=Console.ReadKey(true);
                    if (szamok.Contains(lenyomott_gomb.KeyChar))
                    {
                        db++;
                        Console.Write($"{lenyomott_gomb.KeyChar}");
                        telefonszam += lenyomott_gomb.KeyChar;
                    }
                }
                while (db < 9);
                Console.WriteLine($"\nA megadott telefonszám: 06{telefonszam}");
                Console.WriteLine("Kilépés ESC billentyűre!");
                lenyomott_gomb =Console.ReadKey(true); //ha volt billentyű leütés, akkor az a változóba került
            }
            while (lenyomott_gomb.Key != ConsoleKey.Escape); //esc billentyűre fog kilépni
        }
    }
}
