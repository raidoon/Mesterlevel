using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzol_Kosar
{
    internal class kosarAdatok
    {
        //hazai;idegen;hazai_pont;idegen_pont;helyszín;időpont
        //7up Joventut; Adecco Estudiantes;81;73;Palacio Mun.De Deportes De Badalona;2005-04-03
        public string Hazai { get; set; }
        public string Idegen { get; set; }
        public int HazaiPont { get; set; }
        public int IdegenPont { get; set; }
        public string Helyszin { get; set; }
        public DateTime Idopont { get; set; }
        public kosarAdatok(string sor)
        {
            string[] sz = sor.Split(';');
            Hazai = sz[0];
            Idegen = sz[1];
            HazaiPont = int.Parse(sz[2]);
            IdegenPont = int.Parse(sz[3]);
            Helyszin = sz[4];
            Idopont = Convert.ToDateTime(sz[5]);
        }
    }
}