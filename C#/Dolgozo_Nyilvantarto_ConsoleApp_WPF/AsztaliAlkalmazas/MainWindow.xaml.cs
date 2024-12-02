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

namespace AsztaliAlkalmazas
{
    public partial class MainWindow : Window
    {
        static List<Reszleg> reszlegadatok = new List<Reszleg>();
        static List<Dolgozo> dolgozoadatok = new List<Dolgozo>();
        static List<Adatok> adatok = new List<Adatok>();
        public MainWindow()
        {
            adatokbetoltese();
            InitializeComponent();
        }

        private void adatokbetoltese()
        {
            reszlegadatok.Clear();
            dolgozoadatok.Clear();
            adatok.Clear();


            string urlreszleg = "http://localhost:3000/reszleglista";
            reszlegadatok = Backend.GET(urlreszleg).Send().As<List<Reszleg>>();
            string urldolgozo = "http://localhost:3000/dolgozolista";
            dolgozoadatok = Backend.GET(urldolgozo).Send().As<List<Dolgozo>>();
            string urladatok = "http://localhost:3000/adatoklista";
            adatok = Backend.GET(urladatok).Send().As<List<Adatok>>();

        }

        private void btujdolgozo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btujreszleg_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}