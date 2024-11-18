using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTableExt;
using NetworkHelper;

namespace ConsoleApp_vizilabda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string urlKapitany = "http://localhost:3000/kapitanyLista";
            string urlBajnoksag = "http://localhost:3000/bajnoksagLista";
            string urlAdatok = "http://localhost:3000/adatokLista";

            List<Kapitany> kapitanyAdatok = new List<Kapitany>();
            List<Bajnoksag> bajnoksagAdatok = new List<Bajnoksag>();
            List<Adatsor> osszesAdat = new List<Adatsor>();


            kapitanyAdatok = Backend.GET(urlKapitany).Send().As<List<Kapitany>>();
            bajnoksagAdatok = Backend.GET(urlBajnoksag).Send().As<List<Bajnoksag>>();
            osszesAdat = Backend.GET(urlAdatok).Send().As<List<Adatsor>>();

            //ConsoleTableBuilder.From(kapitanyAdatok).ExportAndWriteLine();
            //ConsoleTableBuilder.From(bajnoksagAdatok).ExportAndWriteLine();
            //ConsoleTableBuilder.From(osszesAdat).ExportAndWriteLine();

            /*3.Listázza ki az összes olyan olimpia évét és helyszínét, ahol a magyar válogatott aranyérmet szerzett! 
             * A listát rendezze évszám szerint csökkenő sorrendbe! */
            Console.WriteLine("A magyar válogatottt aranyérmet szerzett");
            ConsoleTableBuilder
                .From(bajnoksagAdatok
                .Where(x => x.verseny == "Olimpia" && x.helyezes == 1)
                .OrderByDescending(x => x.ev)
                .Select(x => new { x.ev, x.helyszin })
                .ToList())
                .ExportAndWriteLine();

            /*4.Milyen világversenyeken vett részt a magyar válogatott 2008-ban? Írja ki a verseny típusát, helyszínét, az elért helyezést 
             * és a csapatkapitány nevét! */
            Console.WriteLine("A magyar válogatott 2008-as szereplései");
            ConsoleTableBuilder
                .From(osszesAdat
                .Where(x=> x.ev == 2008)
                .Select(x=>new { x.verseny, x.helyszin, x.helyezes, x.neve})
                .ToList())
                .ExportAndWriteLine();

            /*5.Hány évesek voltak a kapitányok az egyes versenyeken? Jelenítse meg a kapitány nevét, az életkorát és a verseny helyszínét!
             * A számított mező neve ’eletkor’ legyen! A listát rendezze a kapitányok neve szerint névsorba!*/
            Console.WriteLine("Kapitányok életkora a versenyeken");
            ConsoleTableBuilder
                .From(osszesAdat
                .OrderBy(x=> x.neve)
                .Select(x=> new{x.neve,életkor=(x.ev-x.szuletett),x.helyszin })
                .ToList())
                .ExportAndWriteLine();

            /*6.Összesen hány világversenyen vezették az egyes kapitányok a vízilabda válogatottat? Jelenjen meg a listában a kapitány neve, 
             * a versenyek száma. A versenyek számát tartalmazó mező neve „versenyek” legyen!
             * A listát rendezze a versenynek száma szerint csökkenő sorrendbe!*/
            Console.WriteLine("Kapitányonként a versenyek száma");
            ConsoleTableBuilder
                .From(osszesAdat
                .GroupBy(x => x.neve)
                .Select(x => new { x.Key, versenyekszáma = x.Count() })
                .OrderByDescending(x => x.versenyekszáma)
                .ToList())
                .ExportAndWriteLine();

            /*7.Írja ki azoknak a kapitányoknak a nevét és születési dátumát, akik keresztneve Dezső és vezették a válogatottat olimpián.
             * Minden kapitány neve csak egyszer szerepeljen a listában! Rendezze a listát a kapitányok neve szerint ABC sorrendbe! */
            Console.WriteLine("Azok a kapitányok, akik keresztneve Dezső és vezették a válogatott olimpián");
            ConsoleTableBuilder
                .From(osszesAdat
                .OrderBy(x => x.neve)
                .Where(x=>x.neve.Contains("Dezső")&&x.verseny=="Olimpia")
                .Select(x => new {x.neve, x.szuletett})
                .Distinct()
                .ToList())
                .ExportAndWriteLine();

            /*8.Az egyes kapitányok hány versenyen szereztek dobogós helyezést a válogatottal? A számított mezőt nevezze el ’versenyek’-re!
             * Jelenítse meg a kapitány nevét és a versenyek számát! (A helyezést ne!)
             * Rendezze a listát a versenyek száma szerint csökkenő sorrendbe! */
            Console.WriteLine("Kapitányonként a dobogós versenyek száma");
            ConsoleTableBuilder
                .From(osszesAdat
                .Where(x => x.helyezes < 3)
                .GroupBy(x => x.neve)
                .Select(x => new { x.Key, versenyekszáma = x.Count() })
                .OrderByDescending(x => x.versenyekszáma)
                .ToList())
                .ExportAndWriteLine();

            //9.Vannak olyan kapitányok, akik már elhunytak. Átlagosan hány évet éltek a régmúlt szövetségi kapitányai? 
            double atlag = 0;
            int meghaltdb = 0;
            foreach (var i in kapitanyAdatok)
            {
                if (i.meghalt != 0)
                {
                    meghaltdb++;
                    atlag += i.meghalt - i.szuletett;
                }
            }
            Console.WriteLine($"Áltagosan {Math.Round(atlag/meghaltdb,2)} évet éltek a régmúlt szövetségi kapitányai");

            //10.Azok között a kapitányok között, akik már elhunytak ki volt az 5 legidősebben távozó és hány évet éltek?
            Console.WriteLine("Az 5 legidősebben távozó kapitány és életkora");
            ConsoleTableBuilder
                .From(kapitanyAdatok
                .Select(x => new {x.neve,életkor = x.meghalt-x.szuletett})
                .OrderByDescending(x=> x.életkor)
                .Take(5)
                .ToList())
                .ExportAndWriteLine();

            /*11.Egyik szövetségi kapitány megnyerte a válogatottal az olimpiát, de sajnos a rákövetkező évben elhunyt. 
             * Hogy hívták, melyik évben halt meg, hol volt és melyik évben az olimpia? */
            Console.WriteLine("Megnyert olimpia után a rákövetkező évben meghalt");
            ConsoleTableBuilder
                .From(osszesAdat
                .Where(x=> x.verseny=="Olimpia"&&x.helyezes==1&&x.meghalt==(x.ev+1))
                .Select(x => new {x.neve,x.meghalt,x.helyszin,x.ev})
                .ToList())
                .ExportAndWriteLine();

            /*12.Listázza ki azoknak a kapitányoknak a nevét, akiknek legalább 3 világversenyen nem sikerült dobogóra juttatnia 
             * a vízilabda válogatottat! */
            Console.WriteLine("Akinek legalább 3 világversenyen nem sikerült dobogóra juttatnia a vízilabda válogatottat");
            ConsoleTableBuilder
                .From(osszesAdat
                .Where(x => x.helyezes > 3)
                .GroupBy(x => x.neve)
                .Select(x => new {x.Key,versenyekszáma = x.Count() })
                .ToList())
                .ExportAndWriteLine();

            //13.Benedek Tibor (vízilabdázó) 2020. június 18. án (47 évesen) elhunyt. Módosítsd az adatbázisban!
            /*int id = kapitanyAdatok.Where(x => x.neve == "Benedek Tibor").Select(x => x.kapitany_id).First();
            Kapitany modositas = new Kapitany
            {
                kapitany_id = id,
                meghalt = 2020
            };
            string url = "http://localhost:3000/modositas";
            string valasz = Backend.PUT(url).Body(modositas).Send().As<string>();
            Console.WriteLine(valasz);*/

            Console.ReadKey();
        }
    }
}