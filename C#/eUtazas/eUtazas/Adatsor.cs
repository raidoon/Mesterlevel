using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUtazas
{
    internal class Adatsor
    {
        /*0 20190326-0700 4170861 NYB 20190404
         0 20190326-0700 6915170 FEB 20210101
         0 20190326-0700 4953658 FEB 20210101
         0 20190326-0700 3073247 FEB 20190413*/
        public int megalloSorszama {  get; set; }
        public int felszallasDatuma { get; set; }
        public int felszallasOraPerc {  get; set; }
        public int cardAzon {  get; set; }
        public string cardTipus {  get; set; }
        public int cardFelhasznalhato { get; set; }
        public int vanJegye {  get; set; }
        public Adatsor(string sor)
        {
            string[] n = sor.Split(' ');
            megalloSorszama = int.Parse(n[0]);
            felszallasDatuma = int.Parse(n[1].Split('-')[0]);
            felszallasOraPerc = int.Parse(n[1].Split('-')[1]);
            cardAzon = int.Parse(n[2]);
            cardTipus = n[3];
            cardFelhasznalhato = int.Parse(n[4]);
            //20190326-20210101
            if (cardFelhasznalhato.ToString().Length==8) vanJegye = 0; else vanJegye = 1;
        }
    }
}