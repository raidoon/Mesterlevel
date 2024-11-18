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
using System.Windows.Markup.Localizer;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ConsoleApp_vizilabda;
using NetworkHelper;

namespace WpfApp_vizilabda
{
    public partial class MainWindow : Window
    {
        string urlKapitany = "http://localhost:3000/kapitanyLista";
        string urlBajnoksag = "http://localhost:3000/bajnoksagLista";
        string urlAdatok = "http://localhost:3000/adatokLista";
        List<Kapitany> kapitanyAdatok = new List<Kapitany>();
        List<Bajnoksag> bajnoksagAdatok = new List<Bajnoksag>();
        List<Adatsor> osszesAdat = new List<Adatsor>();
        public MainWindow()
        {
            InitializeComponent();
            adatokbetoltese();
        }
        private void adatokbetoltese()
        {
            kapitanyAdatok.Clear();
            bajnoksagAdatok.Clear();
            osszesAdat.Clear();

            cbszul.Items.Clear();
            cbmeghalt.Items.Clear();
            cbev.Items.Clear();
            cbhelyezes.Items.Clear();
            cbkapitany.Items.Clear();
            cbverseny.Items.Clear();

            kapitanyAdatok = Backend.GET(urlKapitany).Send().As<List<Kapitany>>();
            bajnoksagAdatok = Backend.GET(urlBajnoksag).Send().As<List<Bajnoksag>>();
            osszesAdat = Backend.GET(urlAdatok).Send().As<List<Adatsor>>();

            cbmeghalt.Items.Add(0);
            for (int i = DateTime.Now.Year; i >= 1880; i--)
            {
                cbszul.Items.Add(i);
                cbmeghalt.Items.Add(i);
                cbev.Items.Add(i);
            }
            for (int i = 1; i < 25; i++) cbhelyezes.Items.Add(i);
            foreach (var i in kapitanyAdatok) cbkapitany.Items.Add(i.neve);
            //foreach (var i in bajnoksagAdatok) if (cbverseny.Items.Contains(i.verseny)); else cbverseny.Items.Add(i.verseny);
            bajnoksagAdatok.GroupBy(x => x.verseny).OrderBy(x => x.Key).ToList().ForEach(x => cbverseny.Items.Add(x.Key));

            cbszul.SelectedIndex = 0;
            cbmeghalt.SelectedIndex = 0;
            cbev.SelectedIndex = 0;
            cbhelyezes.SelectedIndex = 0;
            cbkapitany.SelectedIndex = 0;
            cbverseny.SelectedIndex = 0;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbnev.Text != "")
            {
                int id = kapitanyAdatok.Max(x => x.kapitany_id) + 1; //nem auto in
                Kapitany felvitel = new Kapitany
                {
                    kapitany_id = id,
                    neve = tbnev.Text,
                    szuletett=int.Parse(cbszul.SelectedValue.ToString()),
                    meghalt=int.Parse(cbszul.SelectedValue.ToString())
                };
                string url = "http://localhost:3000/kapitanyFelvitel";
                string valasz = Backend.POST(url).Body(felvitel).Send().As<string>();
                MessageBox.Show(valasz);
                adatokbetoltese();
            }
            else MessageBox.Show("Meg kell adnod a kapitány nevét!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (tbhelyszin.Text != "")
            {
                int id = bajnoksagAdatok.Max(x => x.id) + 1;
                int kapitanyid = kapitanyAdatok[cbkapitany.SelectedIndex].kapitany_id;
                Bajnoksag felvitel = new Bajnoksag
                {
                    id = id,
                    ev = int.Parse(cbev.SelectedValue.ToString()),
                    helyszin = tbhelyszin.Text,
                    helyezes = int.Parse(cbhelyezes.SelectedValue.ToString()),
                    kapitanyid = kapitanyid,
                    verseny =cbverseny.SelectedValue.ToString()
                };
                string url = "http://localhost:3000/bajnoksagFelvitel";
                string valasz = Backend.POST(url).Body(felvitel).Send().As<string>();
                MessageBox.Show(valasz);
                adatokbetoltese();
            }
            else MessageBox.Show("Meg kell adnod a bajnokság helyszínét!");
        }
    }
}