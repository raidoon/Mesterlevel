using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_16_KaracsonyiDiszek
{
    public class Adatok
    {
        /* 1;3;0;0;0;4;0 
           2;4;0;5;-2;1;0 */
        //Az elkészített díszek száma mindig pozitív vagy 0 értékű, míg az eladott díszek száma mindig negatív vagy 0 értékű
        public int nap {  get; set; }
        public int harang { get; set; }
        public int harangEladas { get; set; }
        public int angyalka { get; set; }
        public int angyalkaEladas { get; set; }
        public int fenyofa { get; set; }
        public int fenyofaEladas { get; set; } //e 6 harang, 4 angyalka és 5 fenyőfa
        public double NapiBevetel()
        {
            const double harangAr = 1000;
            const double angyalkaAr = 1350;
            const double fenyoFaAr = 1500;

            // Bevétel: eladott díszek ára
            double bevetelek = 0;

            bevetelek += harangEladas * harangAr;
            bevetelek += angyalkaEladas * angyalkaAr;
            bevetelek += fenyofaEladas * fenyoFaAr;

            return bevetelek;
        }
        public Adatok (string sor)
        {
            string[] s = sor.Split(';');
            nap = int.Parse(s[0]);
            harang = int.Parse(s[1]);
            harangEladas = int.Parse(s[2]);
            angyalka = int.Parse(s[3]);
            angyalkaEladas = int.Parse(s[4]);
            fenyofa = int.Parse(s[5]);
            fenyofaEladas = int.Parse(s[6]);
        }
    }
}
