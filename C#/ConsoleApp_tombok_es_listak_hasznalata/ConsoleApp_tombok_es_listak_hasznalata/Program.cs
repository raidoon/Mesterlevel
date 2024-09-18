using System;

namespace ConsoleApp_tombok_es_listak_hasznalata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //side note: azért írok mindenhová plusz \n -eket, mert esztétikailag jobban tetszik
            int n = 5;
            string[]nevek=new string[n];
            int[]pontszamok=new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{i+1}. név: ");
                nevek[i]=Console.ReadLine();
                Console.Write($"{i+1}. pontszám: ");
                pontszamok[i]=int.Parse( Console.ReadLine() );
            }
            //ki: lista
            Console.WriteLine("\nAdatok kilistázása:");
            for (int i = 0;i < n; i++) Console.WriteLine($"{i + 1}. adat: {nevek[i]} pontszáma: {pontszamok[i]}");
            //sorbarendezés
            for (int i = 0; i<n ; i++)
            {
                int maxi = i; //maximális elem sorszáma
                for(int j = i+1; j < n; j++)
                    if (pontszamok[j] > pontszamok[maxi]) maxi= j; //a legnagyobb érték sorszámát tárolom, nem magát az értéket
                //j cikl. vége
                if(maxi!=i)
                {
                    //csere
                    int tempPontszam = pontszamok[i];
                    pontszamok[i] = pontszamok[maxi];
                    pontszamok[maxi]=tempPontszam;
                    string tempNev = nevek[i];
                    nevek[i]=nevek[maxi];
                    nevek[maxi] = tempNev;
                }
            }
            Console.WriteLine($"\nA legjobb versenyző: {nevek[0]} pontszáma: {pontszamok[0]}");
            Console.WriteLine("\n1-3 helyezett:");
            for(int i = 0;i<3;i++) Console.WriteLine($"\t{i + 1}. helyezett: {nevek[i]} ({pontszamok[i]} pont)");

            bool holtverseny = false;
            int k = 0, l = 0;
            do
            {
                l = k + 1;
                do
                {
                    if (pontszamok[l] == pontszamok[k]) holtverseny = true;
                    l++;
                }
                while ( l < n );
                k++;
            }
            while (!holtverseny && k > n - 1);
            if (holtverseny) Console.WriteLine("\nVolt holtverseny!");
            else Console.WriteLine("\nNem volt holtverseny!");

            Console.ReadKey();
        }
    }
}