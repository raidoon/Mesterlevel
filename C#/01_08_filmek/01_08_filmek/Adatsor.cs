using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_08_filmek
{
    public class Adatsor
    {
        /*A Serious Man;2009;30.68;64
        Across the Universe;2007;29.37;84*/
        public string nev { get; set; }
        public int kiadtak { get; set; }
        public double bevetel { get; set; }
        public int ertekeles { get; set; }
        public Adatsor(string sor)
        {
            string[] s = sor.Split(';');
            nev = s[0];
            kiadtak = int.Parse(s[1]);
            bevetel = double.Parse(s[2].Replace('.', ','));
            ertekeles = int.Parse(s[3]);
        }
    }
}