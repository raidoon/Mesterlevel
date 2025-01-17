using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NetworkHelper;
using statisztika;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace statisztikaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Adatsor> stat = new List<Adatsor>();//AB-ból
        public MainWindow()
        {
            InitializeComponent();
            adatokbetoltese();
            tablazat(stat);
            comboboxFeltoltes();
        }

        private void comboboxFeltoltes()
        {
            cb_atlag.Items.Clear();
            for (int i = 1; i < 6; i++)
            {
                cb_atlag.Items.Add(i);
            }
            cb_atlag.SelectedIndex = 0;
        }

        private void tablazat(List<Adatsor> stat)
        {
            datagrid.ItemsSource = null;
            datagrid.Items.Clear();
            datagrid.ItemsSource = stat;
        }

        private void adatokbetoltese()
        {
            stat.Clear();
            string url = "http://localhost:3000/lista";
            try
            {
                stat = Backend.GET(url).Send().As<List<Adatsor>>();//listába rakom a szerver válaszát
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void rb_no_Checked(object sender, RoutedEventArgs e)
        {
            rb_no.IsChecked = true;
            rb_ferfi.IsChecked = false;
        }

        private void rb_ferfi_Checked(object sender, RoutedEventArgs e)
        {
            rb_ferfi.IsChecked = true;
            rb_no.IsChecked = false;
        }

        private void btadatrogzites_Click(object sender, RoutedEventArgs e)
        {
            if (tbhianyzas.Text != "" && tbtavolsag.Text != "" && monogram.Text != "")
            {
                    string nev = monogram.Text;
                    string azonosito = ""; //nev+sorszam+nem
                    //kövi sorszám 16 lesz!
                    string nem = "";
                    int atlag = 0, hianyzas = 0, tavolsag = 0;
                    if (nev.Length == 2 && char.IsLetter(nev[0]) || char.IsLetter(nev[1]))
                    {
                        if (rb_ferfi.IsChecked == true) nem = "F";
                        else nem = "N";
                        atlag = int.Parse(cb_atlag.SelectedItem.ToString());
                        hianyzas = int.Parse(tbhianyzas.Text);
                        tavolsag=int.Parse(tbtavolsag.Text);

                        int sorszam = int.Parse(stat.OrderByDescending(x => int.Parse($"{x.Azonosito[2]}{x.Azonosito[3]}")).ToList().First().Azonosito.Substring(2, 2));

                        azonosito = $"{nev}{sorszam+1}{nem}";

                        var vaneIlyenAzonosito = stat.Where(x => x.Azonosito == azonosito).ToList();
                        if (vaneIlyenAzonosito.Count == 0)
                        {
                            Adatsor tanuloFelvitel = new Adatsor
                            {
                                Azonosito = azonosito,
                                Atlag = atlag,
                                Hianyzas = hianyzas,
                                Tavolsag = tavolsag,
                            };

                            string url = "http://localhost:3000/felvitel";
                            string valasz = Backend.POST(url).Body(tanuloFelvitel).Send().As<string>();
                            Console.WriteLine(valasz);
                        MessageBox.Show("Az új tanuló sikeresen felvéve!");
                        tbhianyzas.Text = "";
                        tbtavolsag.Text = "";
                        monogram.Text = "";
                        adatokbetoltese();
                        tablazat(stat);
                        comboboxFeltoltes();
                    }
                        else MessageBox.Show("Már van ilyen tanuló!"); 
                    }
                    else MessageBox.Show("A monogram 2 db betűt jelent!");
                    
                    //----------------------------
            }
            else MessageBox.Show("Minden adatot meg kell adni!");
        }
    }
}