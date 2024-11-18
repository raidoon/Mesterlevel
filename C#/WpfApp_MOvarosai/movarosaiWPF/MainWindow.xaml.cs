using ConsoleApp_MOvarosai;
using NetworkHelper;
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

namespace movarosaiWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string urlmegye = "http://localhost:3000/megyeLista";
        List<Megye> megyeAdatok = new List<Megye>();
        
            
        string urlvaros = "http://localhost:3000/varosLista";
        List<Varos> varosAdatok = new List<Varos>();
        
        string urlvarostipus = "http://localhost:3000/varostipusLista";
        List<Varostipus> varostipusAdatok = new List<Varostipus>();

        List<string> jarasLista = new List<string>();
        List<string> kistersegLista = new List<string>();
        
        public MainWindow()
        {
            InitializeComponent();
            adatokbetoltese();
        }

        private void adatokbetoltese()
        {
            megyeAdatok.Clear();
            varostipusAdatok.Clear();
            varosAdatok.Clear();

            jarasLista.Clear();
            cbjaras.Items.Clear();

            cbmegye.Items.Clear();
            cbujmegye.Items.Clear();

            cbvarostipus.Items.Clear();
            cbujvarostipus.Items.Clear();

            cbkisterseg.Items.Clear();
            kistersegLista.Clear();

            megyeAdatok = Backend.GET(urlmegye).Send().As<List<Megye>>();
            varostipusAdatok = Backend.GET(urlvarostipus).Send().As<List<Varostipus>>();
            varosAdatok = Backend.GET(urlvaros).Send().As<List<Varos>>();

            foreach (var i in megyeAdatok)
            {
                cbmegye.Items.Add(i.mnev);
                cbujmegye.Items.Add(i.mnev);
            }
            cbmegye.SelectedIndex = 0;
            cbujmegye.SelectedIndex = 0;

            foreach (var i in varostipusAdatok)
            {
                cbvarostipus.Items.Add(i.vtip);
                cbujvarostipus.Items.Add(i.vtip);
            }
            cbvarostipus.SelectedIndex = 0;
            cbujvarostipus.SelectedIndex = 0;

            varosAdatok.GroupBy(x => x.jaras).OrderBy(x => x.Key).ToList().ForEach(x => jarasLista.Add(x.Key));
            varosAdatok.GroupBy(x => x.kisterseg).OrderBy(x => x.Key).ToList().ForEach(x => cbkisterseg.Items.Add(x.Key));

            foreach (var i in jarasLista) if (i != "") cbjaras.Items.Add(i);
            cbjaras.SelectedIndex = 0;
            cbkisterseg.SelectedIndex = 0;

            tablazat(varosAdatok);
        }

        private void tablazat(List<Varos> lista)
        {
            datagrid.ItemsSource = null;
            datagrid.ItemsSource = lista;
        }

        private void tbkereses_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbkereses.Text != "")
                tablazat(varosAdatok.Where(x => x.vnev.ToLower().Contains(tbkereses.Text.ToLower())
                                             || x.mnev.ToLower().Contains(tbkereses.Text.ToLower())
                                             || x.kisterseg.ToLower().Contains(tbkereses.Text.ToLower())
                                             || x.jaras.ToLower().Contains(tbkereses.Text.ToLower()))
                                                    .ToList());
            else tablazat(varosAdatok);
        }

        private void tbadatrogzites_Click(object sender, RoutedEventArgs e)
        {
            if (tbujvaros.Text != "" && tbnepesseg.Text != "" && tbterulet.Text != "")
            {
                int id = varosAdatok.Max(x => x.varos_id) + 1;
                bool okNepesseg = int.TryParse(tbnepesseg.Text, out int nepesseg) && nepesseg > 0;
                bool okTerulet = double.TryParse(tbterulet.Text, out double terulet) && terulet > 0;

                if (!okNepesseg)
                {
                    MessageBox.Show("A népesség érvénytelen vagy negatív!");
                    return;
                }
                else if (!okTerulet)
                {
                    MessageBox.Show("A terület érvénytelen vagy negatív!");
                    return;
                }
                //idegen kulcsok meghatározása
                int vtipid = varostipusAdatok[cbujvarostipus.SelectedIndex].vtipid_id;
                int megyeid = megyeAdatok[cbujmegye.SelectedIndex].megye_id;
                /*
                Varos felvitel = new Varos
                {
                    varos_id = id,
                    vnev = tbujvaros.Text,
                    vtipid = vtipid,
                    megyeid = megyeid,
                    jaras = cbjaras.SelectedValue.ToString(),
                    kisterseg = cbkisterseg.SelectedValue.ToString(),
                    nepesseg = nepesseg,
                    terulet = terulet
                };
                string url = "http://localhost:3000";
                string valasz = Backend.POST(url + "/felvitel").Body(felvitel).Send().As<string>();
                MessageBox.Show(valasz);
                adatokbetoltese();*/
                
            }
            else MessageBox.Show("Minden adatot meg kell adni!");
        }

        private void bttorles_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItem != null)
            {
                Varos kivalasztottSor = (Varos)datagrid.SelectedItem;
                int id=kivalasztottSor.varos_id;
                Varos torles = new Varos
                {
                    varos_id = id
                };
                string url = "http://localhost:3000";
                string valasz = Backend.DELETE(url + "/torles").Body(torles).Send().As<string>();
                MessageBox.Show(valasz);
                adatokbetoltese();
            }
            else MessageBox.Show("A törléshez válassz ki egy sort!");
        }

        private void btmindenadat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbmegye_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbmegye.SelectedItem != null) tablazat(varosAdatok.Where(x => x.mnev == cbmegye.SelectedItem.ToString()).ToList());
        }

        private void cbvarostipus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbvarostipus.SelectedItem != null) tablazat(varosAdatok.Where(x => x.vnev == cbvarostipus.SelectedItem.ToString()).ToList());
        }
    }
}