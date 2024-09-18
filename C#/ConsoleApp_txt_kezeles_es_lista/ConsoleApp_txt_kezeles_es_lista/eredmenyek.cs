using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_txt_kezeles_es_lista
{
    public class eredmenyek
    {
        public string nev { get;set; }
        public int pontszam { get;set; }
        public eredmenyek(string sor)
        {
            string[] n = sor.Split(' ');
            nev = n[0];
            pontszam = int.Parse(n[1]);
        }
    }
}