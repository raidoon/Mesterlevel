using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace footgolf
{
    internal class adatsor
    {
        //Albert Laszlo;Felnott ferfi;HOLE HUNTERS;0;0;10;10;0;0;0;10
        public string Nev { get; set; }
        public string Kategoria { get; set; }
        public string Egyesulet { get; set; }
        public byte[] Pontok { get; set; }//tömb
        public adatsor(string sor)
        {
            string[] sz = sor.Split(';');
            Nev = sz[0];
            Kategoria = sz[1];
            Egyesulet = sz[2];
            Pontok = new byte[8];//tömb elemeinek száma 8 (verseny nyolc fordulójában szerzett pontszám)
            for (int i = 0; i < Pontok.Length; i++)
            {
                Pontok[i] = byte.Parse(sz[i + 3]);
            }
        }
        public int osszpontszamfuggveny
        {
            get
            {
                int osszpontszamok = 0;
                Array.Sort(Pontok);//pontok sorbarendezése(A versenyző legrosszabb két eredménye kiesik az összpontszámból.
                                   //A maradék hat pontszámot össze kell adni.)
                for (int i = 2; i < Pontok.Length; i++)//legrosszabb két eredménye kiesik
                {
                    osszpontszamok += Pontok[i];//A maradék hat pontszámot össze kell adni.
                }
                //Ha a versenyző legrosszabb egy vagy két eredménye nem nulla,
                //akkor a versenyzőnek az összpontszámába bele kell számítani azt a 10 pont bónuszt, amelyet ezekben a fordulókban megkapott. 
                if (Pontok[0] != 0) osszpontszamok += 10;
                if (Pontok[1] != 0) osszpontszamok += 10;
                return osszpontszamok;
            }
        }

    }
}