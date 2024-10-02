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
            adatok = Backend.GET(url).Send().As<List<Adatsor>>();
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
    }
}