using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace verseny_eredmenyek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nevek = new string[10];
            int[] pontszamok = new int[10];
            string legjobb = "", masodikLegjobb = "", harmadikLegjobb = "";
            int maxPont = 0;
            int masodik = 0, harmadik = 0;
            bool volt = false;

            for (int i = 0; i < 10; i++)//be:10név + pontszám
            {
                Console.Write($"Adja meg a(z) {i+1}. versenyző nevét: ");
                nevek[i]=Console.ReadLine();
                Console.Write($"Adja meg a(z) {i+1}. versenyző pontszámát: ");
                pontszamok[i]=int.Parse(Console.ReadLine());
                if (pontszamok[i] > maxPont)
                {
                    legjobb = nevek[i];
                    maxPont = pontszamok[i];
                }
                else if (pontszamok[i] < maxPont && pontszamok[i] > masodik)
                {
                    masodikLegjobb = nevek[i];
                    masodik = pontszamok[i];
                }
                else if (pontszamok[i]< maxPont && pontszamok[i] < masodik && pontszamok[i] > harmadik)
                {
                    harmadik = pontszamok[i];
                    harmadikLegjobb = nevek[i];
                }
                if (pontszamok.Contains(pontszamok[i])) volt = true;
            }

            //ki: lista
            Console.WriteLine("\nVersenyzők nevei és pontszámai:");
            for (int i = 0; i < 10; i++) Console.WriteLine($"\t{nevek[i]} - {pontszamok[i]}");

            //ki: legjobb
            Console.WriteLine($"\nA legjobb versenyző neve: {legjobb} és pontszáma: {maxPont}");

            //ki: 1-3 helyezett
            Console.WriteLine("Az első 3 helyezett, helyezési sorrendben: ");
            Console.WriteLine($"1. helyezett: {legjobb}");
            Console.WriteLine($"2. helyezett: {masodikLegjobb}");
            Console.WriteLine($"3. helyezett: {harmadikLegjobb}");

            //ki: volt-e holtverseny
            if (volt) Console.WriteLine("Volt holtverseny!");
            else Console.WriteLine("Nem volt holtverseny!"); 
            

            Console.ReadKey();
        }
    }
}
