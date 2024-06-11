using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace WPF_vizsgaGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<adatsor> adatok = new List<adatsor> ();
        string[] tantargyakLista = new string[8] { "IT és hálózatok írásbeli","Programozás írásbeli",
            "Hálózatok A modul","Hálózatok B modul","Hálózatok C modul","Hálózatok D modul",
            "Szóbeli angol","Szóbeli IT" };

        public MainWindow()
        {
            InitializeComponent();
            adatokbetoltese();
        }

        private void adatokbetoltese()
        {
            adatok.Clear();
            listbox.Items.Clear();
            datagrid.ItemsSource = null;
            string[] f = File.ReadAllLines("adatok.txt",Encoding.UTF8);
            foreach (var a in f) adatok.Add(new adatsor(a));
            datagrid.ItemsSource=adatok;
            lberedmenyek.Content = $"összesen {adatok.Count()} diák vett részt a vizsgán";
            lberedmenyek.Content += $"\nsikeres vizsgát tett tanulók száma: " +
                $"{adatok.Where(x => x.Minosites != "elégtelen").Count()}";
            //6.Hozza létre a vizsgaredmenyek.txt állományt!
            //Írja ki az összes sikeres vizsga végeredményét! 
            var eredmenyekLista = adatok.Where(x => x.Minosites != "elégtelen")
                .Select(x => $"{x.Nev}\t{x.Eredmeny}\t{x.Minosites}");
            File.WriteAllLines("vizsgaeredmenyek.txt", eredmenyekLista);
        }

        private void tbkeresetttanulo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbkeresetttanulo.Text != "")
            {
                string keresett = tbkeresetttanulo.Text.ToLower();
                var talalat = adatok.FirstOrDefault(x => x.Nev.ToLower().Contains(keresett));
                if (talalat != null)
                {
                    double legjobbEredmeny = talalat.Vizsgaeredmenyek.Max();
                    int legjobbtantargyIndexe = Array.IndexOf(talalat.Vizsgaeredmenyek, legjobbEredmeny);
                    string legjobbTantargy = tantargyakLista[legjobbtantargyIndexe];
                    
                    double leggyengebbEredmeny = talalat.Vizsgaeredmenyek.Min();
                    int leggyengebbTantargyIndexe = Array.IndexOf(talalat.Vizsgaeredmenyek, leggyengebbEredmeny);
                    string leggyengebbTantargy = tantargyakLista[leggyengebbTantargyIndexe];

                    string sikeresseg = talalat.Minosites != "elégtelen" ? "sikeres" : "nem sikeres";
                    lbkereseseredmenye.Content = $"{talalat.Nev}\nlegjobb eredménye: {legjobbEredmeny} ({legjobbTantargy})" +
                        $"\nleggyengébb eredménye: {leggyengebbEredmeny} {leggyengebbTantargy}" +
                        $"\nvizsgája {sikeresseg}.";
                }
                else lbkereseseredmenye.Content = "A keresett tanuló nem található a listában";
            }
            else lbkereseseredmenye.Content = "Keresés eredménye:";
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listbox.Items.Clear();
            if (datagrid.SelectedItem != null)
            {
                adatsor kivalasztottsor = (adatsor)datagrid.SelectedItem;
                listbox.Items.Add($"{kivalasztottsor.Nev} eredményei:");
                for (int i = 0; i < tantargyakLista.Length; i++)
                {
                    listbox.Items.Add($"{tantargyakLista[i]} " +
                        $"eredménye: {kivalasztottsor.Vizsgaeredmenyek[i].ToString()}");
                }
            }
            else listbox.Items.Clear();
        }
    }
}