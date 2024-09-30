using System.Collections.Generic;
using System.Windows;
using NetworkHelper;
using ConsoleApp_berek;

namespace WpfApp_berek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string url = "http://localhost:3000/dolgozok_lekerdez";
        public MainWindow()
        {
            InitializeComponent();
            adatokbetoltese();
        }

        private void adatokbetoltese()
        {
            List<Adatsor> adatok = Backend.GET(url).Send().As<List<Adatsor>>();
            datagrid.ItemsSource = adatok;
        }
    }
}