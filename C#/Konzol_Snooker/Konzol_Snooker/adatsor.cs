using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzol_Snooker
{
    internal class adatsor
    {
        public int helyezes { get; set; }
        public string nev {  get; set; }
        public string orszag { get; set; }
        public double nyeremeny { get; set; }
        public adatsor(string sor)
        {
            string[] sz = sor.Split(';');
            helyezes = int.Parse(sz[0]);
            nev = sz[1];
            orszag = sz[2];
            nyeremeny = double.Parse(sz[3]);
        }
    }
}