using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_24_Oldtimer
{
    public class Berlesek
    {
        //SELECT kategoriaknev,autokid,autokrendszam,autokszin,autoknev,autokevjarat,autokar,autokkategoriaid, berlesekid,berlesekmennyiseg,berlesekbiztositas,berlesekdatum 
        public string kategoriaknev { get; set; }
        public int autokid { get; set; }
        public string autokrendszam { get; set; }
        public string autokszin { get; set; }
        public string autoknev { get; set; }
        public int autokevjarat { get; set; }
        public double autokar { get; set; }
        public int autokkategoriaid { get; set; }
        public int berlesekid { get; set; }
        public double berlesekmennyiseg { get; set; }
        public double berlesekbiztositas { get; set; }
        public DateTime berlesekdatum { get; set; }
    }
}