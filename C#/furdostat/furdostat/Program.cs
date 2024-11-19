using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furdostat
{
    internal class Program
    {
        struct furdovendegadat
        {
            public int vendegid;
            public byte reszleg;
            public byte kibe;
            public TimeSpan ido;
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("furdoadat.txt");
            furdovendegadat[] adatok = new furdovendegadat[800];
            int db = 0;
            byte ora, perc, sec;
            while(!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(' ');
                adatok[db].vendegid = int.Parse(sor[0]);
                adatok[db].reszleg = byte.Parse(sor[1]);
                adatok[db].kibe = byte.Parse(sor[2]);
                ora = byte.Parse(sor[3]);
                perc = byte.Parse(sor[4]);
                sec = byte.Parse(sor[5]);
                adatok[db].ido = new TimeSpan(ora, perc, sec);
                db++;
            }
            db--;
            sr.Close();
            Console.WriteLine("1.feladat:\tA beolvasás megtörtént!");
            Console.ReadKey();
        }
    }
}