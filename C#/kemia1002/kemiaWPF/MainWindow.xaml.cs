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
using NetworkHelper;
using kemiaWPF;
using kemia1002;

namespace kemiaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string url = "http://localhost:3000/felfedezesekLista";
        List<Adatsor> adatok = new List<Adatsor>();
        public MainWindow()
        {
            InitializeComponent();
            adatokbetoltese();
        }

        private void adatokbetoltese()
        {
            adatok.Clear();
            cb_ev.Items.Clear();
            adatok = Backend.GET(url).Send().As<List<Adatsor>>();
            for (int i = DateTime.Now.Year; i >= 1900; i--) cb_ev.Items.Add(i);
            cb_ev.SelectedIndex = 0;
            datagrid.ItemsSource = adatok;
        }

        private void tbkereses_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbkereses.Text != "")
            {
                string keresettAdat = tbkereses.Text.ToLower();
                var keresettLista = adatok.Where(x => x.ev.ToLower().Contains(keresettAdat)
                                                    || x.elem.ToLower().Contains(keresettAdat)
                                                    || x.felfedezo.ToLower().Contains(keresettAdat)
                                                    || x.rendszam.ToString().ToLower().Contains(keresettAdat)
                                                    || x.vegyjel.ToLower().Contains(keresettAdat))
                                                                                                    .ToList();
                datagrid.ItemsSource=keresettLista;
            }
            else datagrid.ItemsSource = adatok;
        }

        private void bt_adatrogzites_Click(object sender, RoutedEventArgs e)
        {
            lb_uzenet.Content = "";
            if (tb_nev.Text != null && tb_rendszam.Text != null && tb_vegyjel.Text != null)
            {
                if (tb_felfedezo.Text == "") tb_felfedezo.Text = "Ismeretlen";
                Nagykezdobetus(tb_nev);
                Nagykezdobetus(tb_vegyjel);
            }
            else lb_uzenet.Content = "A felfedezőn kívül mindent kötelező megadni!";
        }

        private void tb_rendszam_TextChanged(object sender, TextChangedEventArgs e)
        {
            string szamok = "0123456789"; //érvényes karakterek
            string csakSzamok = "";//instant törölölni fogom, ha valaki nem számot ír be
            string begepeltErtek = tb_rendszam.Text;
            for (int i = 0; i < begepeltErtek.Length; i++)
            {
                if (szamok.Contains(begepeltErtek[i]) && csakSzamok.Length <= 3) csakSzamok += begepeltErtek[i];
            }
            tb_rendszam.Text = csakSzamok;
        }
        private void Nagykezdobetus(TextBox textbox)
        {
            string szoveg =textbox.Text;
            string ujSzoveg = "";
            for (int i = 0; i < szoveg.Length; i++)
            {
                if (i == 0) ujSzoveg += szoveg[i].ToString().ToUpper();
                else ujSzoveg += szoveg[i].ToString().ToLower();
                textbox.Text = ujSzoveg;
            }
        }
    }
}