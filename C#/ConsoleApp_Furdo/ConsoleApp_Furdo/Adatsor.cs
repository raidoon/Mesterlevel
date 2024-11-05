using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Furdo
{
    public class Adatsor
    {
        //453 0 1 6 15 27
        public int vendegAzonosito {  get; set; }
        public int reszlegAzonosito { get; set; }
        public int kiBeLepo { get; set; } 
        public string ido { get; set; }
        public int ora {  get; set; } //hh-pp-mm
        public int perc {  get; set; }
        public int masodperc {  get; set; }

        public Adatsor(string sor)
        {
            string[] s = sor.Split(' ');
            vendegAzonosito = int.Parse(s[0]);
            reszlegAzonosito=int.Parse(s[1]);
            kiBeLepo = int.Parse(s[2]);
            ido = s[3] + ":" + s[4] + ":" + s[5];
            ora = int.Parse(s[3]);
            perc = int.Parse(s[4]);
            masodperc = int.Parse(s[5]);
        }
    }
}