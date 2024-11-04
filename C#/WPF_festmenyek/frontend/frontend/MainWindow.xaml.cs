using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NetworkHelper;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string url = "http://localhost:3000/festmenyeklista";
        List<Adatsor> adatok = new List<Adatsor>();
        public MainWindow()
        {
            InitializeComponent();
            adatokbetoltese();
        }

        private void adatokbetoltese()
        {
            adatok.Clear();
            cbevszam.Items.Clear();
            adatok = Backend.GET(url).Send().As<List<Adatsor>>();
            datagrid.ItemsSource = adatok;
            for (int i = DateTime.Now.Year; i > 0; i--) cbevszam.Items.Add(i);
            cbevszam.SelectedIndex = 0;
        }

        private void btujfestmeny_Click(object sender, RoutedEventArgs e)
        {
            //eh_id, eh_nev, eh_festo, eh_evszam, eh_magassag, eh_szelesseg, eh_kep
            if (tbnev.Text != "" && tbfesto.Text != "" && tbkep.Text != "" && tbmagassag.Text != "" && tbszelesseg.Text != "")
            {
                bool szelessegOk = double.TryParse(tbszelesseg.Text, out double szelesseg) && szelesseg > 0;
                bool magassagOk = double.TryParse(tbmagassag.Text, out double magassag) && magassag > 0;
                if (!szelessegOk || !magassagOk)
                {
                    MessageBox.Show("A szélesség vagy a magasság érvénytelen vagy negatív");
                    return;
                }
                Adatsor felvitel = new Adatsor
                {
                    eh_nev = tbnev.Text,
                    eh_festo = tbfesto.Text,
                    eh_evszam = int.Parse(cbevszam.SelectedValue.ToString()),
                    eh_magassag = magassag,
                    eh_szelesseg = szelesseg,
                    eh_kep = tbkep.Text
                };
                //küldés a backend-nek
                string baseurl = "http://localhost:3000";
                string valasz = Backend.POST(baseurl + "/felvitel").Body(felvitel).Send().As<string>();
                MessageBox.Show(valasz);
                adatokbetoltese();
            }
            else MessageBox.Show("Minden adatot meg kell adni!");
        }

        private void bttorles_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItem != null)
            {
                Adatsor kivalasztottsor = (Adatsor)datagrid.SelectedItem;
                int id = kivalasztottsor.eh_id;
                Adatsor torles = new Adatsor
                {
                    eh_id = id
                };
                string baseurl = "http://localhost:3000";
                string valasz = Backend.DELETE(baseurl + "/torles").Body(torles).Send().As<string>();
                MessageBox.Show(valasz);
                adatokbetoltese();//dataGrid frissítése
            }
            else MessageBox.Show("Nincs kiválasztva sor a törléshez");
        }

        private void btmodositas_Click(object sender, RoutedEventArgs e)
        {
            if(datagrid.SelectedItem != null)
            {
                Adatsor kivalasztottsor = (Adatsor)datagrid.SelectedItem;
                int id = kivalasztottsor.eh_id;
                bool szelessegOk = double.TryParse(tbszelesseg.Text, out double szelesseg) && szelesseg > 0;
                bool magassagOk = double.TryParse(tbmagassag.Text, out double magassag) && magassag > 0;
                if (!szelessegOk || !magassagOk)
                {
                    MessageBox.Show("A szélesség vagy a magasság érvénytelen vagy negatív");
                    return;
                }
                //eh_id, eh_nev, eh_festo, eh_evszam, eh_magassag, eh_szelesseg, eh_kep
                Adatsor modositas = new Adatsor
                {
                    eh_id = id,
                    eh_nev = tbnev.Text,
                    eh_festo = tbfesto.Text,
                    eh_evszam = int.Parse(cbevszam.SelectedValue.ToString()),
                    eh_magassag = magassag,
                    eh_szelesseg = szelesseg,
                    eh_kep = tbkep.Text
                };
                //küldés a backend-nek
                string baseurl = "http://localhost:3000";
                string valasz = Backend.POST(baseurl + "/modositas").Body(modositas).Send().As<string>();
                MessageBox.Show(valasz);
                adatokbetoltese();//dataGrid frissítése
            }
            else MessageBox.Show("Nincs kiválasztva sor a módosításhoz");
        }
    }
}