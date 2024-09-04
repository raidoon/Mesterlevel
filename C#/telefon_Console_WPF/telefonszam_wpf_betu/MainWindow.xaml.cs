using System;
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

namespace telefonszam_wpf_betu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool ok = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void telefonszam_TextChanged(object sender, TextChangedEventArgs e)
        {
            ok = false;
            string megadott_szam = telefonszam.Text;
            string telefonszamok = "";
            string szamok = "0123456789";
            int db = 0;
            /*if (megadott_szam.Length == 9)
            {
                for (int i = 0; i < megadott_szam.Length; i++)
                {
                    if (szamok.Contains(megadott_szam[i])) db++;
                }
                if (db == megadott_szam.Length) ok = true;
            }*/

            for (int i = 0; i < megadott_szam.Length; i++) 
            {
                if (szamok.Contains(megadott_szam[i]))
                {
                    db++;
                    telefonszamok += megadott_szam[i];
                }
            }
            telefonszam.Text=telefonszamok;
            if(db==9)ok=true;
            if (ok)
            {
                telefonszam.Background = Brushes.Green;
                telefonszam.Foreground = Brushes.White;
            }
            else
            {
                telefonszam.Background = Brushes.Red;
                telefonszam.Foreground = Brushes.White;
            }
        }
    }
}
