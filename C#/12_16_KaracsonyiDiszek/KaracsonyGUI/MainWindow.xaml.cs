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
        public static bool HarangOK = false, AngyalOK = false, FenyoOK = false;
        public MainWindow()
        {
            InitializeComponent();
            comboboxFeltoltes();
            adatokbetoltese();
        }

        private void comboboxFeltoltes()
        {
            ComboboxFeltoltes(cbharangkesz);
            ComboboxFeltoltes(cbfenyofakesz);
            ComboboxFeltoltes(cbangyalkakesz);

            ComboboxFeltoltes(cbharangeladott);
            ComboboxFeltoltes(cbfenyofaeladott);
            ComboboxFeltoltes(cbangyalkaeladott);
        }

        private void ComboboxFeltoltes(ComboBox lenyiloLista)
        {
            lenyiloLista.Items.Clear();
            for (int i = 0; i <= 20; i++) lenyiloLista.Items.Add(i);
            lenyiloLista.SelectedIndex = 0;
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

                    lista.Add($"{a.nap,-5} nap: Harang: {a.keszharang,-5}{a.eladottharang,-5}{HarangKeszletOsszesen,-5}" +
                        $" Angyal:{a.keszangyal,-5}{a.eladottangyal,-5}{AngyalKeszletOsszesen,-5}" +
                        $" Fenyő: {a.keszfenyo,-5}{a.eladottfenyo,-5}{FenyoKeszletOsszesen,-5}");
                }
                foreach (var a in lista) listbox.Items.Add(a);
                lbnapszam.Content = $"{adatok.Count + 1}.nap";
            }
            nap = adatok.Count + 1;
            lbharangkeszlet.Content = $"Harangkészlet: {HarangKeszletOsszesen}";
            lbangyalkakeszlet.Content = $"Angyalkészlet: {AngyalKeszletOsszesen}";
            lbfenyofakeszlet.Content = $"Fenyőkészlet: {FenyoKeszletOsszesen}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lbuzenet.Content = "";
            HarangKeszOsszesen = int.Parse(cbharangkesz.Text);
            HarangEladottOsszesen = int.Parse(cbharangeladott.Text);
            if (HarangEladottOsszesen > HarangKeszOsszesen + HarangKeszletOsszesen)
            {
                lbuzenet.Content += "Túl sok az eladott harang!";
                HarangOK = false;
            }
            else HarangOK = true;

            AngyalKeszOsszesen = int.Parse(cbangyalkakesz.Text);
            HarangEladottOsszesen = int.Parse(cbangyalkaeladott.Text);
            if (AngyalEladottOsszesen > AngyalKeszOsszesen + AngyalKeszletOsszesen)
            {
                lbuzenet.Content += "Túl sok az eladott angyalka!";
                AngyalOK = false;
            }
            else AngyalOK = true;

            FenyoKeszOsszesen = int.Parse(cbfenyofakesz.Text);
            FenyoEladottOsszesen = int.Parse(cbfenyofaeladott.Text);
            if (FenyoEladottOsszesen > FenyoKeszOsszesen + FenyoKeszletOsszesen)
            {
                lbuzenet.Content += "Túl sok az eladott fenyő!";
                FenyoOK = false;
            }
            else FenyoOK = true;

            if (HarangOK && FenyoOK && AngyalOK)
            {
                Adatsor ujdiszekfelvitel = new Adatsor
                {
                    nap = nap,
                    keszharang = HarangKeszOsszesen,
                    eladottharang = HarangEladottOsszesen,
                    keszangyal = AngyalKeszOsszesen,
                    eladottangyal = AngyalEladottOsszesen,
                    keszfenyo = FenyoKeszOsszesen,
                    eladottfenyo = FenyoEladottOsszesen
                };
                string url = "http://localhost:3000/ujdiszekfelvitel";
                string valasz = Backend.POST(url).Body(ujdiszekfelvitel).Send().As<string>();
                lbuzenet.Content = valasz;
                adatokbetoltese();
            }
        }
    }
}