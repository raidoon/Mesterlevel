using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_Parkolohaz
{
    public class Adatsor
    {
        ///emelet; hely;renszám ---> 1;5;SAS-424
        public int emelet {  get; set; }
        public int hely {  get; set; }
        public string rendszam { get; set; }
        public bool behajtas { get; set; }
        public bool kihajtas { get; set; }
        public Adatsor(string sor)
        {
            string[] s = sor.Split(';');
            emelet = int.Parse(s[0]);
            hely = int.Parse(s[1]);
            rendszam = s[2];
            behajtas = hajtas(int.Parse(s[3]));
            kihajtas = hajtas(int.Parse(s[4]));
        }

        private bool hajtas(int x)
        {
            if(x == 0) return false;
            else return true;
        }
    }
}