using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_csv_kezeles
{
    public class eredmenyek
    {
        public string nev { get; set; }
        public double pontszam { get; set; }
        public eredmenyek(string sor)
        {
            string[] n = sor.Split(';');
            nev = n[0];
            pontszam = double.Parse(n[1].Replace('.',','));
        }
    }
}
