using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_vizsgaGUI
{
    internal class adatsor
    {
        public string Nev {  get; set; }
        public string Minosites { get; set; }
        public double Eredmeny { get; set; }
        public double[] Vizsgaeredmenyek { get; set; }

        public adatsor(string sor)
        {
            string[] sz = sor.Split(';');
            Nev = sz[0];
            Vizsgaeredmenyek = new double[8];
            for (int i = 0; i < Vizsgaeredmenyek.Length; i++)
            {
                Vizsgaeredmenyek[i] = double.Parse(sz[i + 1]) * 100;
            }
            double atlag = Math.Round(Vizsgaeredmenyek.Average(),0);
            Eredmeny= atlag;
            if (Vizsgaeredmenyek.Min() <= 50) Minosites = "elégtelen";
            else
            {
                if (atlag >= 51 && atlag <= 60) Minosites = "elégséges";
                if (atlag >= 61 && atlag <= 70) Minosites = "közepes";
                if (atlag >= 71 && atlag <= 80) Minosites = "jó";
                if (atlag >= 81) Minosites = "jeles";
            }
        }
    }
}