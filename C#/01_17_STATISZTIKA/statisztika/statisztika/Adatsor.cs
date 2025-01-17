using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statisztika
{
    public class Adatsor
    {
        //`Azonosito`, `Atlag`, `Hianyzas`, `Tavolsag`
        public string Azonosito {  get; set; }
        public int Atlag { get; set; }
        public int Hianyzas { get; set; }
        public int Tavolsag { get; set; }
        internal bool Ellenorzes()
        {
            return (Atlag >= 3 && Tavolsag >= 80);
        }
    }
}