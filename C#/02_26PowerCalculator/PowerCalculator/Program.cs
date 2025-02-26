using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Calculator
{
    public class PowerCalculator
    {
        public double CalculatePower(int basee, int exponent)
        {
            if (exponent == 0 && basee > 0) return 1; //TestZeroExponent
            else if (basee == 0 && exponent > 0) return 0; //TestZeroBasePositiveExponent
            else if (basee == 0 && exponent == 0) return 1; //TestZeroBaseZeroExponent
            else if (basee == 1) return 1; //TestOneBaseAnyExponent
            else //osszes tobbi
            {
                double res = 1;
                int y = Math.Abs(exponent);
                for (int i = 0; i < y; i++)
                {
                    res  *= basee;
                }
                return exponent > 0 ? res : 1 / res; //ha exponent negativ akkor reciprok
            }
        }
        static void Main(string[] args)
        {
            var calculator = new PowerCalculator();
            Console.Write("Add meg az első számot: ");
            int.TryParse(Console.ReadLine(), out int a);
            Console.Write("Add meg a második számot: ");
            int.TryParse(Console.ReadLine(),out int b);
            Console.WriteLine($"Az eredmény: {calculator.CalculatePower(a,b)}");
            Console.ReadKey(); 
        }
    }
}