using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.CompilerServices;

namespace WpfApp_Parkolohaz
{
    public partial class MainWindow : Window
    {
        List<Adatsor> adatok = new List<Adatsor>();
        public MainWindow()
        {
            /*A parkolóháznak 3 emelete és minden emeleten 20 parkolóhelye van. 
            A program kezelje az autók parkolását, kihajtását, valamint biztosítson különböző keresési és rendezési lehetőségeket.
            A program indításakor egy parkolo.txt fájlból olvassa be a parkoló aktuális állapotát. Ha a fájl nem létezik, hozzon létre egy üres parkolóházat.
            Minden változtatás után a program mentse az aktuális parkolóállapotot a parkolo.txt fájlba! 
            Válassz listából és hajtsd végre annak megfelelően:
            - új autó parkoltatása egy adott parkolóhelyre. 
            - autó kihajtása egy adott parkolóhelyről
            - adott rendszám alapján keresés, hogy megtudjuk melyik parkolóhelyen van az autó
            - adott szintre parkolt autók listázása
            - autók listázása rendszám szerint rendezve
            - autók listázása parkolóhely szerint rendezve
            - kilépés

            txt: 
            emelet;hely;renszám
            1;5;SAS-424*/
            InitializeComponent();
            adatokbetoltese();
        }

        private void adatokbetoltese()
        {
            adatok.Clear();
            cbszint.Items.Clear();
            cbemelet.Items.Clear();
            cbparkolohely.Items.Clear();
            string[] f = File.ReadAllLines("parkolo.txt");
            foreach (var line in f) adatok.Add(new Adatsor(line));
            for (int i = 1; i < 4; i++) cbszint.Items.Add(i);
            for (int i = 1; i < 4; i++) cbemelet.Items.Add(i);
            for (int i = 1; i < 21; i++) cbparkolohely.Items.Add(i);
            cbszint.SelectedIndex = 0;
            cbemelet.SelectedIndex = 0;
            cbparkolohely.SelectedIndex = 0;
            tablazatBetoltes(adatok);
        }

        private void tablazatBetoltes(List<Adatsor> lista)
        {
            datagrid.ItemsSource = lista;
        }

        private void tbrendszam_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbrendszam.Text != "")
            {
                string keresett = tbrendszam.Text.ToLower();
                tablazatBetoltes(adatok.Where(x => x.rendszam.Contains(keresett.ToLower())).ToList());
            }
            else tablazatBetoltes(adatok);
        }

        private void cbszint_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int keresett = Convert.ToInt32(cbszint.SelectedItem);
            tablazatBetoltes(adatok.Where(x=> x.emelet == keresett).ToList());
        }

        private void btujparkolas_Click(object sender, RoutedEventArgs e)
        {
            int emelet = Convert.ToInt32(cbemelet.SelectedItem);
            int parkolohely = Convert.ToInt32(cbparkolohely.SelectedItem);
            adatok.Where(x=> x.emelet == emelet && x.hely ==  parkolohely).ToList();
            if(parkolohely==0)
            {
                lbszabad.Content = "A parkolóhely szabad!";
                lbszabad.Background = Brushes.Green;
            }
            else
            {
                lbszabad.Content = "A parkolóhely foglalt!";
                lbszabad.Background= Brushes.Red;
            }
            if (tbrendszam.Text != "")
            {
                string ujrsz = tbrendszam.Text;
                foreach (var i in adatok)
                {
                    
                }
            }
            else MessageBox.Show("Meg kell adnod az autó rendszámát!");
        }
    }
}