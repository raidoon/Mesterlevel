using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hianyzasok
{
    internal class adatsor
    {
        /*név;dátum;óraszám;igazolt;indok
Nagy Lajos;2023.05.15;7;igazolt;betegség
Nagy Lajos;2023.05.16;7;igazolt;betegség*/
        public string nev { get; set; }
        public DateTime datum { get; set; }
        public int oraszam { get; set; }
        public string igazolt { get; set; }
        public string indok { get; set; }
        public adatsor(string sor)
        {
            string[] sorelemek = sor.Split(';');
            this.nev= sorelemek[0];
            this.datum = Convert.ToDateTime(sorelemek[1]);
            this.oraszam = Convert.ToInt32(sorelemek[2]);
            this.igazolt= sorelemek[3];
            this.indok= sorelemek[4];
        }
    }
}
