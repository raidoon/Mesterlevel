using System;
using System.IO;
using NetworkHelper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AB_Filmek;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_ABFilmek
{
    public partial class MainWindow : Window
    {
        static List<Adatsor> filmek = new List<Adatsor>();
        static List<Adatsor> filmekadatok = new List<Adatsor>();
        string filepath = "";
        public MainWindow()
        {
            InitializeComponent();
            comboboxfeltoltes();
            adatokbetoltese();
            adatokbetolteseFajlbol("movies.csv");
            tablazat(filmekadatok);
        }
        private void comboboxfeltoltes()
        {
            ComboboxFeltoltes(cbkiadaseve, DateTime.Now.Year, 1900);
            ComboboxFeltoltes(cbertekeles, 100, 0);
        }
        private void ComboboxFeltoltes(ComboBox lenyilolista, int kezdoertek, int vegertek)
        {
            lenyilolista.Items.Clear();
            for (int i = kezdoertek; i >= vegertek; i--) lenyilolista.Items.Add(i);
            lenyilolista.SelectedIndex = 0;
        }
        private void adatokbetoltese()
        {
            filmekadatok.Clear();
            string url = "http://localhost:3000/filmeklista";
            filmek = Backend.GET(url).Send().As<List<Adatsor>>();
        }
        private void tablazat(List<Adatsor> filmek)
        {
            datagrid.ItemsSource = null;
            datagrid.Items.Clear();
            datagrid.ItemsSource = filmek;
        }
        private void adatokbetolteseFajlbol(string fajlnev)
        {
            filmek.Clear();
            filepath = $@"..\..\..\AB_Filmek\bin\Debug\{fajlnev}";
            if (!File.Exists(filepath))
            {
                Console.WriteLine($"{filepath} nem létezik");
                return;
            }
            try
            {
                var sorok = File.ReadAllLines(filepath, Encoding.UTF8);
                foreach (var sor in sorok.Skip(1))
                {
                    var adatok = sor.Split(';');
                    if (adatok.Length == 5)
                    {
                        var film = new Adatsor
                        {
                            Id = int.Parse(adatok[0]),
                            Nev = adatok[1],
                            Kiadaseve = int.Parse(adatok[2]),
                            Bevetel = double.Parse(adatok[3].Replace('.', ',')),
                            Ertekeles = int.Parse(adatok[4]),
                        };
                        filmekadatok.Add(film);
                    }
                }
                Console.WriteLine("Sikeres fájlbeolvasás");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        private void btadatrogzites_Click(object sender, RoutedEventArgs e)
        {
            if (tbcim.Text != "" && tbbevetel.Text != "")
            {
                bool bevetelOK = false;
                double bevetel;
                bevetelOK = double.TryParse(tbbevetel.Text, out bevetel) && bevetel > 0;
                Adatsor filmfelvitel = new Adatsor
                {
                    Nev = tbcim.Text,
                    Kiadaseve = int.Parse(cbkiadaseve.Text),
                    Bevetel = bevetel,
                    Ertekeles = int.Parse(cbertekeles.Text),
                };
                string url = "http://localhost:3000/ujfilmfelvitel";
                string valasz = Backend.POST(url).Body(filmfelvitel).Send().As<string>();
                filepath = $@"..\..\..\AB_Filmek\bin\Debug\movies.csv";
                MessageBox.Show(valasz);
                MessageBox.Show("Az új film adati sikeresen rögzítve a movies.csv-be");
                File.AppendAllText(filepath, $"{filmekadatok.Max(x => x.Id + 1)};{tbcim.Text};{int.Parse(cbkiadaseve.Text)};{bevetel};{int.Parse(cbertekeles.Text)}\n");
                adatokbetoltese();
                adatokbetolteseFajlbol("movies.csv");
                tablazat(filmekadatok);
            }
            else MessageBox.Show("Minden adatot meg kell adni!");
        }
    }
}