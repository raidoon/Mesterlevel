using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace ConsoleApp_Furdo
{
    internal class Program
    {
        public static List<Adatsor> adatok = new List<Adatsor>();
        static void Main(string[] args)
        {
            int uszoda = 0, szauna = 0, medence = 0, strand = 0, egyReszleg = 0, kilencHat = 0, kilencTizenhat = 0, tizenhatHusz = 0;
            string sz = "";
            Dictionary<string,int> reszlegSzam = new Dictionary<string,int>();
            Dictionary<string,int> statisztika = new Dictionary<string,int>();
            Dictionary<string,int> lista = new Dictionary<string,int>();
            List<string> szaunak = new List<string>();
            string[] f = File.ReadAllLines("furdoadat.txt",Encoding.UTF8);
            foreach (var i in f) adatok.Add(new Adatsor(i));
            Console.WriteLine("2. feladat");
            Console.WriteLine($"Az első vendég {adatok[0].ido}-kor lépett ki az öltözőből.");
            foreach (var item in adatok)
            {
                //Console.WriteLine($"{item.ido}");
                //0 = belépés || 1 = kilépés
                if (item.vendegAzonosito == adatok[adatok.Count - 1].vendegAzonosito && item.reszlegAzonosito == 0 && item.kiBeLepo == 1) 
                    Console.WriteLine($"Az utolsó vendég {item.ido}-kor lépett ki az öltözőből.");
                if (item.reszlegAzonosito != 0 && item.kiBeLepo == 0)
                {
                    if (reszlegSzam.ContainsKey(Convert.ToString(item.vendegAzonosito))) reszlegSzam[Convert.ToString(item.vendegAzonosito)]++;
                    else reszlegSzam[Convert.ToString(item.vendegAzonosito)] = 1;
                }
                if (item.ora >= 6 && item.ora < 9)
                {
                    if (statisztika.ContainsKey(Convert.ToString(item.vendegAzonosito)));
                    else statisztika[Convert.ToString(item.vendegAzonosito)] = 6;
                }
                if(item.ora>=9 && item.ora < 16)
                {
                    if (statisztika.ContainsKey(Convert.ToString(item.vendegAzonosito)));
                    else statisztika[Convert.ToString(item.vendegAzonosito)] = 9;
                }
                if (item.ora >= 16 && item.ora < 20)
                {
                    if (statisztika.ContainsKey(Convert.ToString(item.vendegAzonosito))) ;
                    else statisztika[Convert.ToString(item.vendegAzonosito)] = 16;
                }
                if(item.reszlegAzonosito == 1)
                {
                    if (lista.ContainsKey(Convert.ToString(item.vendegAzonosito)));
                    else lista[Convert.ToString(item.vendegAzonosito)] = 1;
                }
                if(item.reszlegAzonosito == 2)
                {
                    if (lista.ContainsKey(Convert.ToString(item.vendegAzonosito)));
                    else lista[Convert.ToString(item.vendegAzonosito)] = 2;
                    sz += $"{item.vendegAzonosito} {item.ora}:{item.perc}:{item.masodperc}\n";
                }
                if(item.reszlegAzonosito == 3)
                {
                    if (lista.ContainsKey(Convert.ToString(item.vendegAzonosito)));
                    else lista[Convert.ToString(item.vendegAzonosito)] = 3;
                }
                if(item.reszlegAzonosito == 4)
                {
                    if (lista.ContainsKey(Convert.ToString(item.vendegAzonosito)));
                    else lista[Convert.ToString(item.vendegAzonosito)] = 4;
                }
                
            }
            Console.WriteLine("\n3. feladat");
            foreach (var i in reszlegSzam)
            {
                if (i.Value == 1) egyReszleg++;
            }
            Console.WriteLine($"A fürdőben {egyReszleg} vendég járt csak egy részlegen.");
            Console.WriteLine("\n4. feladat");
            Dictionary<string,int> sajt = new Dictionary<string,int>();
            foreach(var i in adatok)
            {
                
            }
            Console.WriteLine("A legtöbb időt eltöltő vendég:");

            Console.WriteLine("\n5. feladat");
            foreach(var i in statisztika)
            {
                if (i.Value == 6) kilencHat++;
                if (i.Value == 9) kilencTizenhat++;
                if (i.Value == 16) tizenhatHusz++;
            }
            Console.WriteLine($"6-9 óra között {kilencHat} vendég");
            Console.WriteLine($"9-16 óra között {kilencTizenhat} vendég");
            Console.WriteLine($"16-20 óra között {tizenhatHusz} vendég");
            
            File.WriteAllText("szauna.txt", sz);
            
            string[] f2 = File.ReadAllLines("szauna.txt", Encoding.UTF8);


            Console.WriteLine("\n7. feladat");
            foreach(var i in lista)
            {
                //Console.WriteLine(i);
                //reszleg 0-oltozo, 1-uszoda, 2-szauna, 3-gyogyvizes, 4-strand
                if (i.Value == 1) uszoda++;
                else if (i.Value == 2) szauna++;
                else if (i.Value == 3) medence++;
                else if (i.Value == 4) strand++;
            }
            Console.WriteLine($"Uszoda: {uszoda}\nSzaunák: {szauna}\nGyógyvizes medencék: {medence}\nStrand: {strand}");
            //foreach (var i in lista2) Console.WriteLine(i);

            Console.ReadKey();
        }
    }
}