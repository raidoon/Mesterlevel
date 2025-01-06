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
using karacsonyCLI;
namespace KaracsonyGUI
{
    public partial class MainWindow : Window
    {
        List<Adatsor> adatok = new List<Adatsor>();
        public static int nap = 0, 
            HarangKeszOsszesen = 0, AngyalKeszOsszesen = 0, FenyoKeszOsszesen = 0, 
            HarangEladottOsszesen = 0, AngyalEladottOsszesen = 0, FenyoEladottOsszesen = 0, 
            HarangKeszletOsszesen = 0, FenyoKeszletOsszesen = 0, AngyalKeszletOsszesen = 0;
        public static bool HarangOK = false, AngyalOK = false, FenyoOK = false
        public MainWindow()
        {
            InitializeComponent();
            adatokbetoltese();
        }

        private void adatokbetoltese()
        {
            adatok.Clear();
            listbox.Items.Clear();
            string url = "http://localhost:3000/ujdiszeklista";
            adatok = Backend.GET(url).Send().As<List<Adatsor>>();
            if (adatok.Count != 0)
            {
                HarangKeszOsszesen = 0;
                HarangEladottOsszesen = 0;
                HarangKeszletOsszesen = 0; 
                AngyalKeszOsszesen = 0;
                AngyalKeszletOsszesen = 0;
                AngyalEladottOsszesen = 0; 
                FenyoEladottOsszesen = 0;
                FenyoKeszletOsszesen = 0;
                FenyoKeszOsszesen = 0;
                List<string> lista = new List<string>();
                foreach(var a in adatok)
                {
                    HarangKeszOsszesen += a.keszharang;
                    HarangEladottOsszesen += a.eladottharang;
                    HarangKeszletOsszesen = HarangKeszOsszesen + HarangEladottOsszesen; 
                    
                    AngyalKeszOsszesen += a.keszangyal;
                    AngyalEladottOsszesen += a.eladottangyal;
                    AngyalKeszletOsszesen = AngyalKeszletOsszesen + AngyalEladottOsszesen;

                    FenyoKeszOsszesen += a.keszfenyo;
                    FenyoEladottOsszesen += a.eladottfenyo;
                    FenyoKeszletOsszesen = FenyoKeszOsszesen + FenyoEladottOsszesen;
                    lista.Add($"{a.nap,-5} nap");
                    
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}