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
using Dolgozo_Nyilvantarto_ConsoleApp_WPF;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string urlreszleg = "http://localhost:3000/reszleglista";
        static List<Reszleg> reszlegadatok = new List<Reszleg>();
        string urldolgozo = "http://localhost:3000/dolgozolista";
        static List<Dolgozo> dolgozoadatok = new List<Dolgozo>();
        string urladatok = "http://localhost:3000/adatoklista";
        static List<Adatok> adatok = new List<Adatok>();
        public MainWindow()
        {
            InitializeComponent();
            adatokbetoltese();
        }

        private void adatokbetoltese()
        {
            adatok.Clear();
            reszlegadatok.Clear();
            dolgozoadatok.Clear();

            cbbelepes.Items.Clear();
            cbneme.Items.Clear();
            cbreszleg.Items.Clear();


            reszlegadatok = Backend.GET(urlreszleg).Send().As<List<Reszleg>>();
            dolgozoadatok = Backend.GET(urldolgozo).Send().As<List<Dolgozo>>();
            adatok = Backend.GET(urladatok).Send().As<List<Adatok>>();

            cbneme.Items.Add("férfi");
            cbneme.Items.Add("nő");
            cbneme.SelectedIndex = 0;

            reszlegadatok.Select(x => x.reszleg).ToList().ForEach(x => cbreszleg.Items.Add(x));
            cbreszleg.SelectedIndex = 0;

            for (int i = 2024; i >1800; i--) cbbelepes.Items.Add(i);
            cbbelepes.SelectedIndex = 0;


            datagrid.ItemsSource = adatok;
        }

        private void tbkereses_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbkereses.Text != "")
            {
                string keresem = tbkereses.Text;
                var lista = adatok.Where(x => x.nev.ToLower().Contains(keresem.ToLower())
                                           || x.reszleg.ToLower().Contains(keresem.ToLower())
                                           || Convert.ToString(x.ber).Contains(keresem)
                                           || Convert.ToString(x.belepes).Contains(keresem))
                    .ToList();
                datagrid.ItemsSource = lista;
            }
            else adatokbetoltese();
        }

        private void btujreszleg_Click(object sender, RoutedEventArgs e)
        {
            lbvalasz.Content = "";
            if (tbujreszleg.Text != "")
            {
                var lista = reszlegadatok.Where(x=> x.reszleg==tbujreszleg.Text).ToList();
                if (lista.Count != 0) MessageBox.Show("Ez a részleg már szerepel a részlegek között!");
                else
                {
                    Reszleg felvitel = new Reszleg
                    {
                        reszleg = tbujreszleg.Text
                    };
                    string url = "http://localhost:3000/reszlegfelvitel";
                    string valasz = Backend.POST(url).Body(felvitel).Send().As<string>();
                    lbvalasz.Content = valasz;
                    adatokbetoltese();
                }
            }
            else MessageBox.Show("Add meg az új részleg nevét!");
        }

        private void btujdolgozo_Click(object sender, RoutedEventArgs e)
        {
            lbvalasz.Content = "";
            if (tbnev.Text != "" && tbber.Text != "")
            {
                //dolgozofelvitel
                //insert into dolgozo velues (null,"${req.body.nev}","${req.body.neme}",${req.body.dolgozoreszlegid},${req.body.belepes},${req.body.ber}
                bool berok = int.TryParse(tbber.Text, out int ber) && ber > 0;
                if (!berok)
                {
                    lbvalasz.Content = "A bér nem érvényes!";
                }
                Dolgozo dolgozofelvitel = new Dolgozo
                {
                    nev = tbnev.Text,
                    neme = cbneme.SelectedValue.ToString(),
                    dolgozoreszlegid = reszlegadatok[cbreszleg.SelectedIndex].reszlegid,
                    belepes = int.Parse(cbbelepes.SelectedValue.ToString()),
                    ber = ber
                };
                string url = "http://localhost:3000/dolgozofelvitel";
                string valasz = Backend.POST(url).Body(dolgozofelvitel).Send().As<string>();
                lbvalasz.Content = valasz;
                adatokbetoltese();
            }
            else MessageBox.Show("Minden adatot meg kell adni!");
        }
    }
}