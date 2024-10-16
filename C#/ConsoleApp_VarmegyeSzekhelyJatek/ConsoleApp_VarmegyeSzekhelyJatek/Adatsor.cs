using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_VarmegyeSzekhelyJatek
{
    internal class Adatsor
    {
        public string Szekhely { get; set; }
        public string Megye { get; set; }
        public Adatsor(string sor)
        {
            string[] strings = sor.Split(';');
            Szekhely = strings[0];
            Megye = strings[1];
        }
    }
}
