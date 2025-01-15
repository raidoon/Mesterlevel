using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgysegTeszt
{
    public class MathOperations
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Subtract(int a, int b)
        {
            return a - b;
        }
        public int Multiply(int a, int b)
        {
            return a * b;
        }
        public double Divide(int a, double b)
        {
            if (b == 0)
            {
                throw new Exception("Nullával nem osztunk!");
            }
            return a / b;
        }
        static void Main(string[] args)
        {
            
        }
    }
}