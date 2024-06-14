using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_Csincsilla
{
    public partial class MainWindow : Window
    {
        List<Csincsillaadatok> adatok = new List<Csincsillaadatok>();
        public MainWindow()
        {
            InitializeComponent();
            adatokbetoltese();
        }
        private void adatokbetoltese()
        {
            adatok.Clear();
            string[] f = File.ReadAllLines("chi.txt", Encoding.UTF8);
            foreach (var a in f) adatok.Add(new Csincsillaadatok(a));
            datagrid.ItemsSource = adatok;
            lberedmeny.Content = ($"Összesen {adatok.Count()} db csincsilla van");
            int simidb = adatok.Where(x => x.Simi == "I").Count();
            double Simidbszazalek = (double)simidb / adatok.Count() * 100;
            lberedmeny.Content += ($"\nA csincsillák {Math.Round(Simidbszazalek, 2)}%-a szereti ha simogatják");
            dpszuletes.SelectedDate = DateTime.Now;
        }
        private void tbkereses_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbkereses.Text != "")
            {
                string keresettadat = tbkereses.Text;
                if (keresettadat == "") datagrid.ItemsSource = adatok;
                else
                {
                    var keresettlista = adatok.Where(x => x.Nev.ToLower().Contains(keresettadat.ToLower())
                                                       || x.Szul.Contains(keresettadat)).ToList();
                    datagrid.ItemsSource = keresettlista;
                }
            }
            else datagrid.ItemsSource = adatok;
        }
        private void rbsimogathato_Checked(object sender, RoutedEventArgs e)
        {
            var kersettlista = adatok.Where(x => x.Simi == "I").ToList();
            datagrid.ItemsSource = kersettlista;
        }

        private void rbnemsimogathato_Checked(object sender, RoutedEventArgs e)
        {
            var keresettlista = adatok.Where(x => x.Simi == "N").ToList();
            datagrid.ItemsSource = keresettlista;
        }

        private void btadatrogzites_Click(object sender, RoutedEventArgs e)
        {
            if (tbnev.Text != "" && tbsuly.Text != "")
            {
                try
                {
                    bool oksuly = false;
                    int sulygrammban = 0;
                    try
                    {
                        sulygrammban = int.Parse(tbsuly.Text);
                        oksuly = true;
                        if (sulygrammban <= 0)
                        {
                            oksuly = false;
                            MessageBox.Show("A súly nem lehet 0 vagy negatív");
                        }
                        if (oksuly)
                        {
                            string nev = tbnev.Text;
                            string simi = cbSimogathato.IsChecked == true ? "I" : "N";
                            string szul = dpszuletes.SelectedDate.Value.ToString("yyyy-MM-dd");
                            string sz = $"{nev};{szul};{sulygrammban};{simi}";
                            File.AppendAllText("chi.txt", sz);
                            MessageBox.Show("Adatok rögzítve");
                            adatokbetoltese();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        oksuly = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hiba történt az adatok rögzítése közben: {ex.Message}");
                }
            }
            else MessageBox.Show("Minden adatot meg kell adni!");
        }
    }
}