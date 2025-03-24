using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_24_Oldtimer
{
    public class Autok
    {
        //SELECT autokid,autokrendszam,autokszin,autoknev,autokevjarat,autokar,autokkategoriaid
        public int autokid { get; set; }
        public string autokrendszam { get; set; }
        public string autokszin { get; set; }
        public string autoknev { get; set; }
        public int autokevjarat { get; set; }
        public double autokar { get; set; }
        public int autokkategoriaid { get; set; }
        public int auto_nev_hossz()
        {
            return autoknev.Length;
        }
    }
}