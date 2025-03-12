using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class MathHelper
    {
        public int Add(int a, int b) { return a + b;}
        public int Subtract(int a, int b) { return a - b; }
        public int Multiply(int a, int b) { return a * b;}
        public int Divide(int a, int b) 
        {
            if (a == 0) return 0;
            else if (b == 0) throw new ArgumentException("0-ával nem lehet osztani!");
            return a / b;
        }
        

        static void Main(string[] args)
        {
            bool folytatod = true, oka = false, okb = false, muveletok = false;
            int a = 0, b = 0;
            double eredmeny = 0;
            do
            {
                try
                {
                    do
                    {
                        Console.Write("Add meg az első számot: ");
                        if (int.TryParse(Console.ReadLine(), out a)) oka = true;
                        else oka = false;
                    }
                    while (!oka);
                    do
                    {
                        Console.Write("Add meg a második számot: ");
                        if (int.TryParse(Console.ReadLine(), out b)) okb = true;
                        else okb = false;
                    }
                    while (!okb);
                    do
                    {
                        Console.Write("Válaszd ki a műveletet, amit szeretnél elvégezni(+,-,*,/): ");
                        string muvelet = Console.ReadLine();
                        if(muvelet=="+"||muvelet=="-"||muvelet=="*"||muvelet == "/")
                        {
                            muveletok=true;
                            switch (muvelet)
                            {
                                case "+": eredmeny = a+b; break;
                                case "-":eredmeny = a-b; break;
                                case "*": eredmeny=a*b; break;
                                case "/":eredmeny=a/b; break;
                            }
                        }
                        else muveletok=false;
                    }
                    while (!muveletok);
                    Console.WriteLine($"Eredmény: {eredmeny}");
                    Console.WriteLine("Folytatod? (igen/nem)");
                    string igennem = Console.ReadLine();
                    if (igennem == "igen") folytatod = true;
                    else folytatod = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                }
            }
            while (folytatod); 
        }
    }
}