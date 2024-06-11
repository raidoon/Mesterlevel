using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzol_Kalapacsvetes2016
{
    internal class Versenyzo
    {
        //Wagner Domingos;Brazília;x;71,97;72,28
        //Ivan Cihan; Fehéroroszország;76,13;77,43;73,48;x;77,79;76,34
        public string Nev { get; set; }
        public string Orszag { get; set; }
        public List<string> Dobasok { get; set; }
        public Versenyzo(string sor)
        {
            string[] sz = sor.Split(';');
            Nev = sz[0];
            Orszag = sz[1];
            Dobasok = sz.Skip(2).ToList();
        }
    }
}