using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                if (adatok[i].reszleg == 0 && adatok[i].kibe == 1)
                {
                    if (new TimeSpan(9, 0, 0) > adatok[i].ido) reggel++;
                    else if (new TimeSpan(16, 0, 0) > adatok[i].ido) napkozben++;
                    else este++;
                }
            }
            Console.WriteLine($"\n5.feladat:\n\t6-9 óra között {reggel} vendég érkezett." +
                                            $"\n\t9-16 óra között {napkozben} vendég érkezett." +
                                            $"\n\t16-20 óra között {este} vendég érkezett.");
            /*FileStream kifajl = new FileStream("szauna.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(kifajl);
            cv = 0;
            while (cv < db)
            {
                TimeSpan szaunaido = new TimeSpan(0, 0, 0);
                while (adatok[cv].vendegid == adatok[cv + 1].vendegid)
                {
                    if (adatok[cv].reszleg == 2)
                    {
                        szaunaido += adatok[cv + 1].ido - adatok[cv].ido;
                        cv++;
                    }
                }
                if(szaunaido>new TimeSpan(0, 0, 0))
                {
                    sw.WriteLine($"{adatok[cv].vendegid} {szaunaido}");  
                }
                cv++;
            }
            sw.Close();
            kifajl.Close();
            */
            Console.WriteLine("\n6.feladat: A fájlba írás sikeresen megtörtént.");
            Boolean r1 = false, r2 = false, r3 = false, r4 = false;
            int dbr1 = 0, dbr2 = 0, dbr3 = 0, dbr4 = 0;
            cv = 0;
            while (cv < db)
            {
                while (adatok[cv].vendegid == adatok[cv+1].vendegid)
                {
                    switch(adatok[cv].vendegid)
                    {
                        case 1:
                        {
                            if (!r1)
                            {
                                dbr1++;
                                r1 = true;
                            }
                            break;
                        }
                        case 2:
                        {
                            if (!r2)
                            {
                                dbr2++;
                                r2 = true;
                            }
                            break;
                        }
                        case 3:
                        {
                            if (!r3)
                            {
                                dbr3++;
                                r3 = true;
                            }
                            break;
                        }
                        case 4:
                        {
                            if (!r4)
                            {
                                dbr4++;
                                r4 = true;
                            }
                            break;
                        }
                    }
                    cv++;
                }
                r1 = false; r2 = false; r3 = false; r4 = false;
                cv++;
            }
            Console.WriteLine($"\n7.feladat:\n\tUszodák: {dbr1}\n\tSzaunák: {dbr2}\n\tGyógyvizes medencék: {dbr3}\n\tStrand részleg: {dbr4}");
            Console.ReadKey();
        }
    }
}