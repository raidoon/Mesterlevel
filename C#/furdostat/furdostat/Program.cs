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
            Console.WriteLine("1.feladat:\n\tA beolvasás megtörtént!");
            Console.WriteLine($"\n2.feladat:\n\tAz első vendég {adatok[0].ido}-kor lépett ki az öltözőből.");
            int utolso = adatok[db].vendegid;
            int cv = db;
            while(utolso == adatok[cv].vendegid) cv--;
            cv++;
            Console.WriteLine($"\tAz utolsó vendég {adatok[cv].ido}-kor lépett ki az öltözőből.");
            int csakegyreszlegen = 0;
            cv = 1;
            while (cv < db)
            {
                int j = 1;
                while (adatok[cv].vendegid == adatok[cv - 1].vendegid)
                {
                    j++;
                    cv++;
                }
                if (j == 4) csakegyreszlegen++;
                cv++;
            }
            Console.WriteLine($"\n3.feladat:\n\tA fürdőben {csakegyreszlegen} vendég járt csak egy részlegen.");
            TimeSpan maxido = new TimeSpan(0, 0, 0);
            TimeSpan beido, kiido;
            int maxvendeg = 0;
            cv = 1;
            while (cv < db)
            {
                beido = adatok[cv-1].ido;
                while (adatok[cv].vendegid == adatok[cv-1].vendegid)
                {
                    cv++;
                }
                kiido = adatok[cv - 1].ido;
                if(maxido<kiido-beido)
                {
                    maxido = kiido - beido;
                    maxvendeg = cv - 1;
                }
                cv++;
            }
            Console.WriteLine($"\n4.feladat:\nA legtöbb időt eltöltő vendég:\n\t{adatok[maxvendeg].vendegid}. vendég  {maxido}");
            int reggel = 0, napkozben = 0, este = 0;
            for(int i = 0;i < db; i++)
            {

            }
            Console.ReadKey();
        }
    }
}