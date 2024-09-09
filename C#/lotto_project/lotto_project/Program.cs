using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lotto_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] lottoszamok = new int[10, 5]; //több dimenziós tömb --> zárójelben megmondjuk hány sora és oszlopa lesz
            Random r = new Random();
            int i = 0, j = 0;
            bool volt_korabban=true;
            Console.WriteLine("10 lottóhúzás szimulátor");
            for (i = 0; i < 10; i++)
            {
                Console.Write($"{i+1}. húzás számai: ");
                for (j = 0; j < 5; j++)
                {
                    if (j > 0)
                    {
                        do
                        {
                            lottoszamok[i, j] = r.Next(90) + 1;
                            volt_korabban = false;
                            for (int k = 0; k < j; k++)
                            {
                                if (lottoszamok[i, j] == lottoszamok[i, k]) volt_korabban = true;
                            }
                        }
                        while (volt_korabban);
                    }
                    else lottoszamok[i, j] = r.Next(90) + 1;
                    Console.Write($"{lottoszamok[i, j]}, ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}