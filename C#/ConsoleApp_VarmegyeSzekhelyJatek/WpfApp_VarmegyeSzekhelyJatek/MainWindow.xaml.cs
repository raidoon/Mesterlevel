using System;
using System.IO;
using ConsoleApp_VarmegyeSzekhelyJatek;
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

namespace WpfApp_VarmegyeSzekhelyJatek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Adatsor> adatok = new List<Adatsor>();
        Random r = new Random();
        double jotipp = 0;
        int n = 0, valaszok = 0, j =0,i=0,szam=0;
        int[] indexek = new int[20];
        string tipp = "";
        public MainWindow()
        {
            InitializeComponent();
            adatokbetoltese();
        }

        private void adatokbetoltese()
        {
            bt_tipp.IsEnabled = false;
            adatok.Clear();
            string[] f = File.ReadAllLines(@"..\..\..\ConsoleApp_VarmegyeSzekhelyJatek\bin\Debug\varmegyeszekhelyek2023.txt", Encoding.UTF8);
            foreach (string line in f.Skip(1)) adatok.Add(new Adatsor(line));
            listbox.Items.Clear();
            foreach (var a in adatok) listbox.Items.Add(a.Megye);
            cb_n.Items.Clear();
            for (i = 2; i <= adatok.Count(); i++) cb_n.Items.Add(i);
            cb_n.SelectedIndex = 0;
            lb_jatekszabaly.Content = $"Játékszabályok\nA játékban {adatok.Count()} vármegyéből választhatunk ki N darabot\nÖnnek a vármegyék vármegyeszékhelyeit kell kitalálnia!";
        }

        private void bt_jatekinditasa_Click(object sender, RoutedEventArgs e)
        {
            bt_tipp.IsEnabled = true;
            lb_eredmeny.Content = "";
            n=Convert.ToInt32(cb_n.Text);
            j = 0; szam = 0; i = 0; jotipp = 0; valaszok = 0;
            indexek[0] = r.Next(19);
            bool van = false;
            while (j < n)
            {
                van = false;
                szam = r.Next(19); // második szám
                for (i = 0; i < j; i++) if (indexek[i] == szam) van = true;
                if (!van)
                {
                    indexek[j] = szam;
                    j++;
                }
            }
            int leghosszabb = adatok[indexek[0]].Szekhely.Length;
            int legrovidebb = adatok[indexek[0]].Szekhely.Length;
            for (int i = 0; i < n; i++)
            {
                if (adatok[indexek[i]].Szekhely.Length > leghosszabb) leghosszabb = adatok[indexek[i]].Szekhely.Length;
                if (adatok[indexek[i]].Szekhely.Length < legrovidebb) legrovidebb = adatok[indexek[i]].Szekhely.Length;
            }
            lb_segitseg.Content= "Segítség:";
            lb_segitseg.Content+=$"\nA válaszok közül a legrövidebb vármegyeszékhely neve {legrovidebb} karakteres";
            lb_segitseg.Content+=$"\nA válaszok közül a leghosszabb vármegyeszékhely neve {leghosszabb} karakteres";
            feladatkiiras();
        }

        private void feladatkiiras()
        {
            lb_megye.Content=$"{adatok[indexek[valaszok]].Megye} ----> {adatok[indexek[valaszok]].Szekhely[0]}";
            tb_szekhely.Text = adatok[indexek[valaszok]].Szekhely[0].ToString();
        }

        private void bt_tipp_Click(object sender, RoutedEventArgs e)
        {
            if (tb_szekhely.Text != "")
            {
                tipp=tb_szekhely.Text;
                if (tipp == adatok[indexek[valaszok]].Szekhely) jotipp++;
                valaszok++;
                if (valaszok < n) feladatkiiras();
                if (valaszok >= n)
                {
                    lb_eredmeny.Content=$"8.feladat: Értékelés\nÖn {jotipp} vármegyeszékhely nevét találta el!" +
                        $"\nTeljesítménye {Math.Round(jotipp / n * 100, 2)}%-os";
                    bt_tipp.IsEnabled=false;
                }
            }
            else MessageBox.Show("Nem írtál be tippet!");
        }
    }
}