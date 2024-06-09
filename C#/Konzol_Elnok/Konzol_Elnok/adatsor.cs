using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzol_Elnok
{
    public class adatsor
    {
        //George Washington|1789|1797|Pártonkívüli|1732|1799
        public string nev {  get; set; }
        public int kezdet { get; set; }
        public int veg {  get; set; }
        public string part { get; set; }
        public int szuletes { get; set; }
        public int halala { get; set; } //ha él akkor 0
        public adatsor(string sor)
        {
            string[] sz = sor.Split('|');
            nev = sz[0];
            kezdet = int.Parse(sz[1]);
            veg = int.Parse(sz[2]);
            part = sz[3];
            szuletes = int.Parse(sz[4]);
            halala = int.Parse(sz[5]);
        }
    }
}
