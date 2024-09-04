using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primszamok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int szam = 0;
            Console.Write("Meddig írjam ki a prímszámokat: ");
            szam = int.Parse(Console.ReadLine());
            Console.WriteLine($"A prímszámok {szam}-ig:");
            for (int i = 2; i < szam; i++)
            {
                bool prim = true;
                for(int j = 2; j < i && prim; j++)
                {
                    if (i % j == 0) prim = false;
                }
                if(prim) Console.Write($"{i}, ");
            }
            Console.ReadKey();
        }
    }
}
