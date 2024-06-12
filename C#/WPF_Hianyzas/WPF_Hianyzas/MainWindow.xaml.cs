using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;

namespace WPF_Hianyzas
{
    public partial class MainWindow : Window
    {
        string nev = "";
        int oraszam = 0;
        public MainWindow()
        {
            InitializeComponent();
            adatokbetoltese();
        }

        private void adatokbetoltese()
        {
            listbox.Items.Clear();
            cbindoklas.Items.Clear();
            datum.SelectedDate = DateTime.Now;
            
            string[] fajlbol = File.ReadAllLines("hianyzas.txt", Encoding.UTF8);
            foreach (var i in fajlbol.Skip(1))
            {                
                listbox.Items.Add(i);
                string[] sz = i.Split(';');
                if (!cbindoklas.Items.Contains(sz[4])) cbindoklas.Items.Add(sz[4]);
            }
            tbnev.Text = "";
            tboraszam.Text = "";
            cbindoklas.SelectedIndex = 0;

            if (tbnev.Text != "") nev = tbnev.Text;
        }

        private void Btadatrogzites_Click(object sender, RoutedEventArgs e)
        {
            if(tbnev.Text !="" && tboraszam.Text != "")
            {
                nev = tbnev.Text;
                if (int.Parse(tboraszam.Text) > 0)
                {
                    //név;dátum;óraszám;igazolt;indok
                    string szoveg = "";
                    szoveg += nev += ";";
                    szoveg += datum.SelectedDate.Value.ToString("yyyy.MM.dd") + ";";
                    szoveg += tboraszam.Text += ";";
                    if (radiobuttonIgazolt.IsChecked == true) szoveg += "igazolt;";
                    else szoveg += "igazolatlan;";
                    szoveg += cbindoklas.SelectedItem.ToString() + "\n";
                    File.AppendAllText("hianyzas.txt", szoveg);
                    adatokbetoltese();
                    lbuzenet.Foreground = Brushes.Green;
                    lbuzenet.Content = "Sikeres adatrögzítés!";
                }
                else lbuzenet.Content = "Az óraszámnak minimum 1-nek kell lennie!";
            }
            else lbuzenet.Content = "Minden adatot meg kell adni!";
        }

        private void Tbnev_TextChanged(object sender, TextChangedEventArgs e)
        {
            lbuzenet.Foreground = Brushes.Red;
            lbuzenet.Content = "";
        }

        private void Tboraszam_TextChanged(object sender, TextChangedEventArgs e)
        {
            lbuzenet.Foreground = Brushes.Red;
            lbuzenet.Content = "";
        }
    }
}