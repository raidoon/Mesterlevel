using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;

namespace WPF_Osztalypenz
{
    public partial class MainWindow : Window
    {
        int egyenleg = 0;
        bool okosszeg = false;
        string nev = "";
        int osszeg = 0;
        string fajlnev = "";
        public MainWindow()
        {
            InitializeComponent();
            adatokbetoltese();
        }

        private void adatokbetoltese()
        {
            datum.SelectedDate = DateTime.Now;
            tbnev.Text = "";
            tbosszeg.Text = "";
            egyenleg = 0;
            
            if(tbfajlnev.Text != "")
            {
                if (!File.Exists(fajlnev))
                {
                    lbuzenet.Foreground = Brushes.Red;
                    lbuzenet.Content = $"{fajlnev} nem létezik!";
                    listbox.Items.Clear();
                }
                else
                {
                    string[] fajlbol = File.ReadAllLines(fajlnev, Encoding.UTF8);
                    if (fajlbol.Length == 0)
                    {
                        lbuzenet.Foreground = Brushes.Red;
                        lbuzenet.Content = $"{fajlnev} üres!";
                    }
                    else
                    {
                        listbox.Items.Clear();
                        foreach (var i in fajlbol)
                        {
                            listbox.Items.Add(i);
                            string[] sz = i.Split(';');
                            if (sz[0] == "befizetes") egyenleg += int.Parse(sz[3]);
                            else egyenleg -= int.Parse(sz[3]);
                        }
                    }
                }
                lbegyenleg.Foreground = Brushes.Red;
                lbegyenleg.Background = Brushes.PaleGoldenrod;
                lbegyenleg.Content = $"Egyenleg:\n{egyenleg} Ft";
            }
            else
            {
                lbuzenet.Foreground = Brushes.Red;
                lbuzenet.Content = "A fájlnév nem lehet üres";
            }
        }

        private void Btadatrogzites_Click(object sender, RoutedEventArgs e)
        {
            if (tbnev.Text != "" && tbosszeg.Text != "") 
            {
                nev = tbnev.Text;
                try
                {
                    osszeg = int.Parse(tbosszeg.Text);
                    okosszeg = true;
                    if(osszeg <= 0)
                    {
                        lbuzenet.Foreground = Brushes.Red;
                        lbuzenet.Content = "A befizetett vagy kifizetett összeg nem lehet kisebb 0-nál!";
                    }
                    else
                    {
                        if (osszeg > egyenleg && radiobtkifizetes.IsChecked == true) 
                        {
                            okosszeg = false;
                            lbuzenet.Foreground = Brushes.Red;
                            lbuzenet.Content = "Az kifizetett összeg nem lehet nagyobb az egyenlegnél!";
                            
                        }
                        if (okosszeg)
                        {
                            string szoveg = "";
                            if (radiobtbefizetes.IsChecked == true) szoveg += "befizetes;";
                            else szoveg += "kifizetes;";
                            szoveg += nev += ";";
                            szoveg += datum.SelectedDate.Value.ToString("yyyy.MM.dd") + ";";
                            szoveg += tbosszeg.Text += "\n";
                            File.AppendAllText(fajlnev, szoveg);
                            adatokbetoltese();
                            lbuzenet.Foreground = Brushes.Green;
                            lbuzenet.Content = "Adat rögzítés sikeres!";
                        }
                    }
                }
                catch
                {
                    okosszeg = false;
                    lbuzenet.Foreground = Brushes.Red;
                    lbuzenet.Content = "A befizetett vagy kifizetett összeg nem egész szám!";
                }
            }
            else
            {
                lbuzenet.Foreground = Brushes.Red;
                lbuzenet.Content = "Minden adatot meg kell adni!";
            }
            
        }

        private void Tbnev_TextChanged(object sender, TextChangedEventArgs e)   {lbuzenet.Content = "";}

        private void Tbosszeg_TextChanged(object sender, TextChangedEventArgs e)    {lbuzenet.Content = "";}

        private void Tbfajlnev_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbfajlnev.Text != "")
            {
                fajlnev = tbfajlnev.Text;
                lbuzenet.Content = "";
                adatokbetoltese();
            }
            else
            {
                lbuzenet.Foreground = Brushes.Red;
                lbuzenet.Content = "A fájlnév nem lehet üres";
            }
        }
    }
}