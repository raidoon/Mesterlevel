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

namespace Frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Reszleg> reszlegadatok = new List<Reszleg>();
        static List<Dolgozo> dolgozoadatok = new List<Dolgozo>();
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

            string urlreszleg = "http://localhost:3000/reszleglista";
            string urldolgozo = "http://localhost:3000/dolgozolista";
            string urladatok = "http://localhost:3000/adatoklista";

            reszlegadatok = Backend.GET(urlreszleg).Send().As<List<Reszleg>>();
            dolgozoadatok = Backend.GET(urldolgozo).Send().As<List<Dolgozo>>();
            adatok = Backend.GET(urladatok).Send().As<List<Adatok>>();

            datagrid.ItemsSource = adatok;
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}