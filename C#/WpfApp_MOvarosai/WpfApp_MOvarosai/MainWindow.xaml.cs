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
using ConsoleApp_MOvarosai;
using NetworkHelper;

namespace WpfApp_MOvarosai
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
        
        public MainWindow()
        {
            adatokbetoltese();
            InitializeComponent();
        }

        private void adatokbetoltese()
        {
            cbmegye.Items.Clear();
        }

     

    }
}