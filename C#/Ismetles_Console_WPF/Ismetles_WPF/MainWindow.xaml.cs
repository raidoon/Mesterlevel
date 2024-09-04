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

namespace Ismetles_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int telekszelesseg = 0, telekhossz = 0, kerulet = 0;
        bool okhossz = false, okszelesseg = false;
        public MainWindow()
        {
           InitializeComponent();
        }

        private void tb_telekszelesseg_TextChanged(object sender, TextChangedEventArgs e)
        {
            tb_kerulet.Text = "";
        }

        private void tb_telekhossz_TextChanged(object sender, TextChangedEventArgs e)
        {
            tb_kerulet.Text = "";
        }
        private void bt_szamol_Click(object sender, RoutedEventArgs e)
        {
            tb_kerulet.Text = "";
            if (tb_telekhossz.Text != "" && tb_telekszelesseg.Text != "")
            {
                okszelesseg = ellenoriz(lb_telekszelesseg, tb_telekszelesseg);
                okhossz = ellenoriz(lb_telekhossz, tb_telekhossz);
                if (okszelesseg && okhossz)
                {
                    kerulet = 2 * (int.Parse(tb_telekszelesseg.Text) + int.Parse(tb_telekhossz.Text));
                    tb_kerulet.Text = $"{kerulet} méter";
                }
            }
            else MessageBox.Show("Mindkét adatot meg kell adni!");
        }

        private bool ellenoriz(Label label, TextBox textbox)
        {
            bool ok = false;
            int szam = 0;
                try
                {
                    ok = false;
                    szam = int.Parse(textbox.Text);
                    if (szam <= 0)
                    {
                        ok = false;
                        MessageBox.Show($"{label.Content} nem lehet - vagy 0");
                    }
                    else ok = true;
                }
                catch
                {
                    ok = false;
                MessageBox.Show("Nem számot adtál meg!");
                }
            return ok;
        }
    }
}
