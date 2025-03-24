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
using _03_24_Oldtimer;
namespace WPF
{
    public partial class MainWindow : Window
    {
        List<Berlesek> berleseklista = new List<Berlesek>();
        List<Autok> autoklista = new List<Autok>();
        List<Kategoriak> kategorialista = new List<Kategoriak>();
        List<BerlesekOG> berlesekOGs = new List<BerlesekOG>();
        public MainWindow()
        {
            InitializeComponent();
            adatokbetoltese();
            comboboxbetoltes();
        }

        private void comboboxbetoltes()
        {
            //1
            cbautoknev.Items.Clear();
            cbkategoriaknev.Items.Clear();
            //2
            cbszin.Items.Clear();
            cbautonev.Items.Clear();
            cbevjarat.Items.Clear();
            cbkategoria.Items.Clear();
            //3
            cbauto.Items.Clear();
            cbberlesiido.Items.Clear();
            //1
            cbautoknev.Items.Add("Minden adat");
            cbkategoriaknev.Items.Add("Minden adat");
            var nevszures = berleseklista.GroupBy(x=> x.autoknev).OrderBy(x=> x.Key).ToList();
            var kategoriaszures = berleseklista.GroupBy(x => x.kategoriaknev).OrderBy(x => x.Key).ToList();
            foreach ( var nev in nevszures ) 
            { 
                cbautoknev.Items.Add(nev.Key);
                cbautonev.Items.Add(nev.Key);
            }
            foreach (var kategoria in kategoriaszures) 
            { 
                cbkategoriaknev.Items.Add(kategoria.Key);
                cbkategoria.Items.Add(kategoria.Key);
            }
            //2
            var szinek = berleseklista.GroupBy(x=> x.autokszin).OrderBy(x=> x.Key).ToList();
            for (int i = DateTime.Now.Year-25; i >= 1900; i--) { cbevjarat.Items.Add(i); } //-25 mert veterán autók
            foreach (var szin in szinek) { cbszin.Items.Add(szin.Key); }
            //3
            var autokIdSzerint = berleseklista.OrderByDescending(x => x.autokid).ToList();
            foreach (var auto in autokIdSzerint)
            {
                cbauto.Items.Add($"{auto.autokid};{auto.autoknev};{auto.autokrendszam};{auto.autokszin}");
            }
            for (int i = 1; i < 32; i++) cbberlesiido.Items.Add(i);
            //1
            cbautoknev.SelectedIndex = 0;
            cbkategoriaknev.SelectedIndex = 0;
            //2
            cbszin.SelectedIndex = 0;
            cbautonev.SelectedIndex = 0;
            cbevjarat.SelectedIndex = 0;
            cbkategoria.SelectedIndex = 0;
            //3
            cbauto.SelectedIndex = 0;
            cbberlesiido.SelectedIndex = 0;
        }

        private void adatokbetoltese()
        {
            lbberlesuzenet.Content = "";
            lbuzenet.Content = "";

            kategorialista.Clear();
            autoklista.Clear();
            berleseklista.Clear();

            kategorialista = Backend.GET("http://localhost:3000/kategoriaklista").Send().As<List<Kategoriak>>();
            autoklista = Backend.GET("http://localhost:3000/autoklista").Send().As<List<Autok>>();
            berleseklista = Backend.GET("http://localhost:3000/berleseklista").Send().As<List<Berlesek>>();
            tablazatbetoltes(berleseklista);
        }

        private void tablazatbetoltes(List<Berlesek> lista)
        {
            datagridszures.ItemsSource = null;
            datagridszures.ItemsSource = lista;
        }

        private void tbkereses_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (tbkereses.Text != "")
            {
                string keresem = tbkereses.Text.ToLower();
                var talalatok = berleseklista.Where(x => x.autoknev.ToLower().Contains(keresem)
                                     || x.autokszin.ToLower().Contains(keresem)
                                     || x.autokrendszam.ToLower().Contains(keresem)
                                     || x.kategoriaknev.ToLower().Contains(keresem)
                                     || x.autokevjarat.ToString().Contains(keresem)).ToList();
                tablazatbetoltes(talalatok);
            }
            else adatokbetoltese();
        }

        private void cbautoknev_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbautoknev.SelectedIndex != 0)
            {
                string keresem = cbautoknev.SelectedItem.ToString();
                var talalatok = berleseklista.Where(x => x.autoknev == keresem).ToList();
                tablazatbetoltes(talalatok);
            }
            else adatokbetoltese();
        }

        private void cbkategoriaknev_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbkategoriaknev.SelectedIndex != 0)
            {
                string keresem = cbkategoriaknev.SelectedItem.ToString();
                var talalatok = berleseklista.Where(x => x.kategoriaknev == keresem).ToList();
                tablazatbetoltes(talalatok);
            }
            else adatokbetoltese();
        }

        private void btberlesrogzitese_Click(object sender, RoutedEventArgs e)
        {
            if (tbbiztositas.Text != "" && datum.SelectedDate != null)
            {
                try
                {
                    //berlesekfelvitel
                    //{berlesekid,berlesekautoid,berlesekmennyiseg,berlesekbiztositas,berlesekdatum}=req.body
                    int berlid = berleseklista.OrderByDescending(x => x.berlesekid).First().berlesekid + 1;
                    int berlauotid = int.Parse(cbauto.SelectedItem.ToString().Split(';')[0]);
                    int bermennyiseg = int.Parse(cbberlesiido.SelectedItem.ToString());
                    int biztositas = int.Parse(tbbiztositas.Text);
                    DateTime berldatum = datum.SelectedDate.Value.ToUniversalTime();
                    BerlesekOG ujberles = new BerlesekOG
                    {
                        berlesekid = berlid,
                        berlesekautoid = berlauotid,
                        berlesekmennyiseg = bermennyiseg,
                        berlesekbiztositas = biztositas,
                        berlesekdatum = berldatum
                    };
                    string valasz = Backend.POST("http://localhost:3000/berlesekfelvitel").Body(ujberles).Send().As<string>();
                    adatokbetoltese();
                    lbberlesuzenet.Content = valasz;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else MessageBox.Show("Adj meg minden adatot!");
        }

        private void btujkategoria_Click(object sender, RoutedEventArgs e)
        {
            if (tbujkategoria.Text != "")
            {
                int katid = kategorialista.OrderByDescending(x => x.kategoriakid).First().kategoriakid + 1;
                Kategoriak ujkategoria = new Kategoriak
                {
                    kategoriakid = katid,
                    kategoriaknev = tbujkategoria.Text,
                };
                string valasz = Backend.POST("http://localhost:3000/kategoriakfelvitel").Body(ujkategoria).Send().As<string>();
                adatokbetoltese();
                lbuzenet.Content = valasz;
            }
            else MessageBox.Show("Írd be az új kategória nevét!");
        }

        private void btadatrogzites_Click(object sender, RoutedEventArgs e)
        {
            if (tbrendzsam.Text != "" && tbberletidij.Text != "")
            {
                try
                {
                    int autid = autoklista.OrderByDescending(x => x.autokid).First().autokid + 1;
                    string rendszam = tbrendzsam.Text;
                    string szin = "";
                    string aunev = "";
                    int evjarat = int.Parse(cbevjarat.SelectedValue.ToString());
                    int berletdij = int.Parse(tbberletidij.Text);
                    string kat = cbkategoria.SelectedItem.ToString();

                    int katid = kategorialista.Where(x=> x.kategoriaknev==kat).ToList().First().kategoriakid;

                    if (tbujszin.Text!="") szin = tbujszin.Text;
                    else szin = cbszin.SelectedItem.ToString();
                    
                    if(tbujautonev.Text!="")aunev = tbujautonev.Text;
                    else aunev = cbautonev.SelectedItem.ToString();

                    //[autokrendszam,autokszin,autoknev,autokevjarat,autokar,autokkategoriaid]
                    Autok ujauto = new Autok
                    {
                        autokid = autid,
                        autokrendszam = rendszam,
                        autokszin = szin,
                        autoknev = aunev,
                        autokevjarat = evjarat,
                        autokar = berletdij,
                        autokkategoriaid = katid,
                    };
                    string valasz = Backend.POST("http://localhost:3000/autofelvitel").Body(ujauto).Send().As<string>();
                    adatokbetoltese();
                    lbuzenet.Content = valasz;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("Minden adatot meg kell adni!");
        }
    }
}