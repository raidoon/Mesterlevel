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

namespace telefonszam_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool ok=false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void telefonszam_TextChanged(object sender, TextChangedEventArgs e)
        {
            ok = false;
            string telszam = telefonszam.Text;
            string szamok = "0123456789";
            int db = 0;
            if (telszam.Length == 9)
            {
                for (int i = 0; i < telszam.Length; i++)
                {
                    if (szamok.Contains(telszam[i])) db++;
                }
                if (db == telszam.Length) ok = true;
            }
            if (ok) 
            {
                telefonszam.Background=Brushes.Green;
                telefonszam.Foreground=Brushes.White;
            }
            else
            {
                telefonszam.Background = Brushes.Red;
                telefonszam.Foreground = Brushes.White;
            }
        }
    }
}
