using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Xml;

namespace lotto_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] lottoszamok = new int[10, 5]; //több dimenziós tömb --> zárójelben megmondjuk hány sora és oszlopa lesz
            double[] atlagok = new double[10];
            Random r = new Random();
            int i = 0, j = 0, max = 0, min = 0;
            int paros = 0, paratlan = 0; //megszámlálás tétele
            bool volt_korabban=true;
            bool van_3al_oszthato=false; //eldöntés tétele
            Console.WriteLine("10 lottóhúzás szimulátor");
            Console.WriteLine();
            for (i = 0; i < 10; i++)
            {
                atlagok[i] = 0;//összegzés tétele
                paros = 0; paratlan = 0; max = 0; min = 91;
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
                    if(j==4) Console.Write($"{lottoszamok[i, j]} ");
                    else Console.Write($"{lottoszamok[i, j]}, ");
                    atlagok[i] += lottoszamok[i, j];
                    if (lottoszamok[i, j] % 2 == 0) paros++;
                    else paratlan++;
                }//j ciklus vége
                Console.Write($"\t|| húzások átlaga= {atlagok[i]/5:0.00}");
                Console.Write($"\t|| páros számok: {paros} db");
                Console.Write($"\t|| páratlan számok: {paratlan} db");
                int l = 0;
                van_3al_oszthato = false;
                do
                {
                    if (lottoszamok[i,l]%3==0)van_3al_oszthato=true;
                    l++;
                }
                while (!van_3al_oszthato && l < 5);
                if(van_3al_oszthato) Console.Write($"\t|| Van 3-al osztható szám, például: {lottoszamok[i,l-1]}"); //keresés tétele
                if(van_3al_oszthato) Console.Write($" sorszáma: {l}."); //kiválasztás tétele
                for (l = 0; l < 5; l++)
                {
                    if (lottoszamok[i, l] > max) max = lottoszamok[i, l];
                    if (lottoszamok[i, l] < min) min = lottoszamok[i, l];
                }
                Console.Write($"\t|| max: {max} min: {min}");
                Console.WriteLine();
            }//i ciklus vége
            Console.WriteLine("\nSorbarendezett számok:");
            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 5; j++)
                {
                    min = lottoszamok[i, j];
                    int mini = j;
                    for (int k = j+1; k < 5; k++)
                    {
                        if (lottoszamok[i, k] < min)
                        {
                            min = lottoszamok[i, k];
                            mini = k;
                        }
                    }
                    //csere
                    lottoszamok[i, mini] = lottoszamok[i, j];
                    lottoszamok[i, j] = min;
                }
                Console.Write($"\n{i+1}. húzás számai sorban: ");
                for(j = 0; j < 5; j++) Console.Write($"{lottoszamok[i,j]}, ");
            } 
            Console.ReadKey();
        } 
    } 
}