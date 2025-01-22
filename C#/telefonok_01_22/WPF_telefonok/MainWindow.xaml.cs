using System;
using NetworkHelper;
using telefonok_01_22;
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
using System.Runtime.Remoting.Messaging;

namespace WPF_telefonok
{
    public partial class MainWindow : Window
    {
        static List<Telefon> telefonok = new List<Telefon>();
        public MainWindow()
        {
            InitializeComponent();
            adatokbetoltese();
            tablazat();
            comboboxok();
        }

        private void comboboxok()
        {
            cbkiadaseve.Items.Clear();
            cb_gyarto.Items.Clear();
            telefonok.GroupBy(x => x.modell).OrderBy(x => x.Key).ToList().ForEach(x => cb_gyarto.Items.Add(x.Key));
            cb_gyarto.SelectedIndex = 0;
            for (int i = DateTime.Now.Year; i > 1980; i--) cbkiadaseve.Items.Add(i);
            cbkiadaseve.SelectedIndex = 0;
        }

        private void tablazat()
        {
            datagrid.ItemsSource = null;
            datagrid.ItemsSource = telefonok;
        }

        private void adatokbetoltese()
        {
            tbkiadasiar.Text = "";
            tbmodell.Text = "";
            telefonok.Clear();
            string url = "http://localhost:3000/lista";
            telefonok = Backend.GET(url).Send().As<List<Telefon>>();
        }

        private void btadatrogzites_Click(object sender, RoutedEventArgs e)
        {
            if (tbkiadasiar.Text != "" && tbmodell.Text != "")
            {
                try
                {
                    /*//INSERT INTO `telefonok`(`modell`, `gyarto`, `eladasiar`, `kiadaseve`, `kepes5g`) VALUES ('[value-1]','[value-2]','[value-3]','[value-4]','[value-5]')
                      app.post('/felvitel', (req, res) => {
                        kapcsolat()
                          connection.connect()    
                          connection.query(`INSERT INTO telefonok  VALUES ("${req.body.modell}","${req.body.gyarto}",${req.body.eladasiar},${req.body.kiadaseve},"${req.body.kepes5g}")`, (err, rows, fields) => {
                            if (err) 
                              res.send("Hiba") 
                            else 
                            res.send("Az adatok felvitele sikerült")
                          })    
                          connection.end()
                  })*/
                    string modell = tbmodell.Text;
                    int kiadasiar = int.Parse(tbkiadasiar.Text);
                    var vanIlyenModell = telefonok.Where(x => x.modell == modell).ToList();

                    if (vanIlyenModell.Count == 0)
                    {
                        Telefon ujtelefon = new Telefon
                        {
                            modell = modell,
                            gyarto = cb_gyarto.SelectedValue.ToString(),
                            eladasiar = kiadasiar,
                            kiadaseve = Convert.ToInt32(cbkiadaseve.SelectedValue),
                            kepes5g = checkbox_kepes5g.IsChecked == true ? "igen" : "nem"
                        };
                        string url = "http://localhost:3000/felvitel";
                        string valasz = Backend.POST(url).Body(ujtelefon).Send().As<string>();
                        MessageBox.Show(valasz);
                        adatokbetoltese();
                        tablazat();
                        comboboxok();
                    }
                    else MessageBox.Show("Már van ilyen modell!");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("Minden adat kötelező!");
        }
    }
}