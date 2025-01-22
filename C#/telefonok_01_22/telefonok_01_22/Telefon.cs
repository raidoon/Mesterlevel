using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telefonok_01_22
{
    public class Telefon
    {
        public string modell {  get; set; }
        public string gyarto { get; set; }
        public int eladasiar { get; set; }
        public int kiadaseve { get; set; }
        public string kepes5g { get; set; }
        // 4. feladat: "regi" tagfüggvény
        public string regi()
        {
            if (kiadaseve <= 2021)
                return "régebbi";
            else
                return "újabb";
        }
    }
}