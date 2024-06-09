using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace hianyzasok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<adatsor> adatok = new List<adatsor>();
        int oraszam = 8;
        int adatokszama = 0;
        string tanulonev = "";
        string ujindok = "";    
        
        public MainWindow()
        {
            InitializeComponent();
            adatokbetoltese();
        }

        private void adatokbetoltese()
        {
            listbox1.Items.Clear();
            adatok.Clear();
            datepicker.SelectedDate= DateTime.Now;
            string[] fajlbol = File.ReadAllLines("hianyzasok.txt",Encoding.UTF8);
            for (int i = 1; i < fajlbol.Count(); i++)
            {
                adatok.Add(new adatsor(fajlbol[i]));
                /*név;dátum;óraszám;igazolt;indok
                    Nagy Lajos;2023.05.15;7;igazolt;betegség*/
            }
            adatokszama = adatok.Count();
            for (int i = 0; i < adatokszama; i++)
            {
                string sz = "";
                sz += adatok[i].nev + ";";
                sz += adatok[i].datum.ToString("yyyy.MM.dd") + ";";
                sz += adatok[i].oraszam + ";";
                sz += adatok[i].igazolt + ";";
                sz += adatok[i].indok;
                listbox1.Items.Add(sz);
            }
            cbindok.Items.Clear();
            adatok.GroupBy(x=>x.indok).ToList().ForEach(x=>cbindok.Items.Add(x.Key));
            cbindok.SelectedIndex = 0;

            cbnevek.Items.Clear();
            adatok.GroupBy(x => x.nev).ToList().ForEach(x => cbnevek.Items.Add(x.Key));
            cbnevek.SelectedIndex = 0;
        }

        private void btplusz_Click(object sender, RoutedEventArgs e)
        {
            if(oraszam<8)
            {
                oraszam++;
            }
            lbora.Content=oraszam.ToString();
        }

        private void btminusz_Click(object sender, RoutedEventArgs e)
        {
            if(oraszam>1)
            {
                oraszam--;
            }
            lbora.Content = oraszam.ToString();
        }

        private void btuj_Click(object sender, RoutedEventArgs e)
        { 
            lbhiba.Content = "";
            if (tbnev.Text != "")//név nem üres
            {
                tanulonev=tbnev.Text;
                if(tbindok.Text=="")ujindok=cbindok.Text;
                else ujindok=tbindok.Text;
                string szoveg = "";
                szoveg += tanulonev + ";";
                szoveg += datepicker.SelectedDate.Value.ToString("yyyy,MM,dd")+";";
                szoveg += lbora.Content + ";";
                if (rdbtigazolt.IsChecked == true) szoveg += "igazolt;"; else szoveg += "igazolatlan;";
                szoveg += ujindok+"\n";
                File.AppendAllText("hianyzasok.txt", szoveg);                
                lbhiba.Content = "Adatok rögzítése sikerült";
                adatokbetoltese();
            }
            else lbhiba.Content = "A nevet meg kell adni";
        }

        private void tbnev_TextChanged(object sender, TextChangedEventArgs e)   {lbhiba.Content = "";}

        private void Cbnevek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbnevek.SelectedItem != null)
            {
                int osszesIgazolt = 0;
                int osszesIgazolatlan = 0;
                string keresettNev = cbnevek.SelectedValue.ToString();
                foreach (var i in adatok)
                {
                    if (i.nev == keresettNev)
                    {
                        if (i.igazolt == "igazolt") osszesIgazolt += i.oraszam;
                        else osszesIgazolatlan += i.oraszam;
                    }
                }
                lbhianyzasok.Content = $"{keresettNev} hiányzásai\nIgazolt: {osszesIgazolt}" +
                    $"\nIgazolatlan: {osszesIgazolatlan}";
            }
        }
    }
}