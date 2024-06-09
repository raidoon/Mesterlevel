using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzol_Balkezesek
{
    internal class adatsor
    {
        /*név;első;utolsó;súly;magasság
        Jim Abbott;1989-04-08;1999-07-21;200;75
        Kyle Abbott;1991-09-10;1996-08-24;200;76*/

        public string nev { get; set; }
        public DateTime elso { get; set; }
        public DateTime utolso { get; set;}
        public int suly { get; set; }
        public int magassag { get; set; } //inchben van
        public adatsor(string sor)
        {
            string[] sz = sor.Split(';');
            nev = sz[0];
            elso = Convert.ToDateTime(sz[1]);
            utolso = Convert.ToDateTime(sz[2]);
            suly = int.Parse(sz[3]);
            magassag = int.Parse(sz[4]);
        }
    }
}
