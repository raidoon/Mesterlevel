using System;
using System.Collections.Generic;
using NetworkHelper;
using novenyek;
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

namespace wpf_novenyek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Adatsor> adatok = new List<Adatsor>();
        public MainWindow()
        {
            InitializeComponent();
            adatokbetoltese();
            comboboxfeltoltes();
        }

        private void tablazat(List<Adatsor> lista)
        {
            datagrid.ItemsSource = null;
            datagrid.ItemsSource = lista;
        }

        private void comboboxfeltoltes()
        {
            cbszures.Items.Clear();
            cbujtipus.Items.Clear();
            cbvizigeny.Items.Clear();

            var tipusok = adatok.GroupBy(x => x.tipus).OrderBy(x => x.Key).ToList();
            var vizigenyek = adatok.GroupBy(x=> x.vizigeny).OrderBy(x=> x.Key).ToList();
            cbszures.Items.Add("minden adat");
            foreach (var i in tipusok)
            {
                cbszures.Items.Add(i.Key);
                cbujtipus.Items.Add(i.Key);
            }
            foreach (var i in vizigenyek)
            {
                cbvizigeny.Items.Add(i.Key);
            }
            cbszures.SelectedIndex = 0;
            cbujtipus.SelectedIndex = 0;
            cbvizigeny.SelectedIndex = 0;
        }

        private void adatokbetoltese()
        {
            adatok.Clear();
            string url = "http://localhost:3000/lista";
            adatok = Backend.GET(url).Send().As<List<Adatsor>>();
            tablazat(adatok);
        }

        private void tbkereses_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbkereses.Text != "")
            {
                var keresem = tbkereses.Text.ToLower();
                var talalatLista = adatok.Where(x => x.nev.ToLower().Contains(keresem)
                                                 || x.tipus.ToLower().Contains(keresem)
                                                 || x.vizigeny.ToLower().Contains(keresem)
                                                 || Convert.ToString(x.ar).Contains(keresem))
                    .ToList();
                tablazat(talalatLista);
            }
            else tablazat(adatok);
        }

        private void cbszures_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbszures.SelectedItem != null)
            {
                if(cbszures.SelectedItem.ToString() != "minden adat")
                {
                    string szures = cbszures.SelectedValue.ToString();
                    var szurtLista = adatok.Where(x => x.tipus == szures).ToList();
                    tablazat(szurtLista);
                }
                else tablazat(adatok);
            }
        }

        private void btadatrogzites_Click(object sender, RoutedEventArgs e)
        {
            if (tbar.Text != "" && tbnev.Text != "")
            {
                try
                {
                    int ar = int.Parse(tbar.Text);
                    Adatsor ujNoveny = new Adatsor
                    {
                        nev = tbnev.Text,
                        tipus = cbujtipus.SelectedValue.ToString(),
                        ar = ar,
                        vizigeny = cbvizigeny.SelectedValue.ToString(),
                    };
                    string url = "http://localhost:3000/felvitel";
                    string valasz = Backend.POST(url).Body(ujNoveny).Send().As<string>();
                    MessageBox.Show(valasz);
                    tbnev.Text = "";
                    tbar.Text = "";
                    adatokbetoltese();
                    comboboxfeltoltes();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("Minden adatot meg kell adni!");
        }
    }
}