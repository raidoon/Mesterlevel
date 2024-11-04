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
using RealEstateab;

namespace RealEstateabWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string url = "http://localhost:3000/hirdeteseklista";
        List<Adatsor> adatok = new List<Adatsor>();
        string urlhirdetok = "http://localhost:3000/hirdetoklista";
        List<Hirdetok> hirdetok = new List<Hirdetok>();
        string urlkategoriak = "http://localhost:3000/kategoriaklista";
        List<Kategoriak> kategoriak = new List<Kategoriak>();
        List<string> telefonszamoklista = new List<string>();
        List<string> kategorialista = new List<string>();
        List<string> adatoklista = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            adatokbetoltese();
        }

        private void adatokbetoltese()
        {
            adatok.Clear();
            adatoklista.Clear();
            telefonszamoklista.Clear();
            kategorialista.Clear();
            hirdetok.Clear();
            kategoriak.Clear();
            adatok = Backend.GET(url).Send().As<List<Adatsor>>();
            hirdetok = Backend.GET(urlhirdetok).Send().As<List<Hirdetok>>();
            kategoriak = Backend.GET(urlkategoriak).Send().As<List<Kategoriak>>();
            //dataGrid.ItemsSource = adatok;
            telefonszamoklista=hirdetok.GroupBy(x=> x.hirdetotelefon).Select(x=> x.Key).ToList();
            kategorialista=kategoriak.GroupBy(x=> x.kategorianev).Select(x=> x.Key).ToList();
            cbkategoria.Items.Clear();
            cbkategoria_uj.Items.Clear();
            foreach (var k in kategoriak)
            {
                cbkategoria.Items.Add(k.kategorianev);
                cbkategoria_uj.Items.Add(k.kategorianev);
            }
            cbkategoria.SelectedIndex = 0;
            cbkategoria_uj.SelectedIndex = 0;
            cbhirdeto.Items.Clear();
            cbhirdeto_uj.Items.Clear();
            foreach (var k in hirdetok)
            {
                cbhirdeto.Items.Add(k.hirdetonev);
                cbhirdeto_uj.Items.Add(k.hirdetonev);
            }
            cbhirdeto.SelectedIndex = 0;
            cbhirdeto_uj.SelectedIndex = 0;
            cbszobaszam.Items.Clear();
            cbszobaszam_uj.Items.Clear();
            cbemelet.Items.Clear();
            cbemelet_uj.Items.Clear();
            for (int i = 0; i <= 10; i++)
            {
                cbszobaszam.Items.Add(i);
                cbemelet.Items.Add(i);
                cbszobaszam_uj.Items.Add(i);
                cbemelet_uj.Items.Add(i);
            }
            cbszobaszam.SelectedIndex = 0;
            cbemelet.SelectedIndex = 0;
            cbszobaszam_uj.SelectedIndex = 0;
            cbemelet_uj.SelectedIndex = 0;
            datePicker_uj.SelectedDate = DateTime.Now;
        }

        private void btujkep_Click(object sender, RoutedEventArgs e)
        {
            // Kép tallózása
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Képfájlok (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|Mind Files (*.*)|*.*";
            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                // A kiválasztott fájl elérési útja
                string selectedImagePath = openFileDialog.FileName;

                // A fájl neve (csak a név, nem a teljes elérési út)
                string fileName = System.IO.Path.GetFileName(selectedImagePath);

                // A fájl cél elérési útja (a "kepek" mappába másolás előtt)
                string destinationPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../../backend/hirdeteskepek/", fileName);

                try
                {
                    // Kép másolása a "kepek" mappába
                    System.IO.File.Copy(selectedImagePath, destinationPath, true);

                    tbkepnev.Text = fileName;

                    // Frissítjük az Image.Source-t a kiválasztott képre
                    string kepEleresiUt = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../../backend/hirdeteskepek/", fileName);
                    Uri uri = new Uri(kepEleresiUt, UriKind.Absolute);

                    // Újra létrehozzuk a BitmapImage-t
                    BitmapImage bitmapImage = new BitmapImage(uri);

                    // Beállítjuk az Image.Source-t
                    image.Source = bitmapImage;

                    MessageBox.Show("Kép sikeresen hozzáadva a kepek mappába!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hiba történt a kép másolása során: {ex.Message}");
                }
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                Adatsor kivalasztottsor=(Adatsor)dataGrid.SelectedItem;
                tbkepnev.Text = kivalasztottsor.kepnev;
                string kepnev = kivalasztottsor.kepnev;
                string imagepath=System.IO.Path.GetFullPath(@"../../../../backend/hirdeteskepek/"+kepnev);
                image.Source=new BitmapImage(new Uri(imagepath, UriKind.Absolute));
                cbszobaszam.SelectedValue = kivalasztottsor.szobaszam;
                tbszelesseg.Text = kivalasztottsor.szelesseg.ToString();
                tbhosszusag.Text = kivalasztottsor.hosszusag.ToString();
                cbemelet.SelectedValue = kivalasztottsor.emelet;
                tbalapterulet.Text = kivalasztottsor.alapterulet.ToString();
                tbhirdetesszoveg.Text = kivalasztottsor.hirdetesszoveg;
                cbkategoria.SelectedValue = kivalasztottsor.kategorianev;
                cbhirdeto.SelectedValue = kivalasztottsor.hirdetonev;
                if(kivalasztottsor.tehermentes=="True")checkBox.IsChecked = true;else checkBox.IsChecked = false;
                datePicker.SelectedDate = kivalasztottsor.hirdetesdatum;
            }
        }

        private void bttorles_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                Adatsor kivalasztottsor=(Adatsor)dataGrid.SelectedItem;
                int id = kivalasztottsor.hirdetesekid;//hirdetés azonosítója (WHERE)
                Adatsor torles = new Adatsor
                {
                    hirdetesekid = id
                };
                string baseurl = "http://localhost:3000";
                string valasz=Backend.DELETE(baseurl+ "/torles").Body(torles).Send().As<string>();
                MessageBox.Show(valasz);
                adatokbetoltese();//dataGrid frissítése
            }
            else MessageBox.Show("Nincs kiválasztva sor a törléshez");
        }

        private void btmodositas_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                Adatsor kivalasztottsor = (Adatsor)dataGrid.SelectedItem;
                int id = kivalasztottsor.hirdetesekid;//hirdetés azonosítója (WHERE)
                //számok ell.
                bool alapteruletok=int.TryParse(tbalapterulet.Text, out int alapterulet)&&alapterulet>0;
                if (!alapteruletok)
                {
                    MessageBox.Show("Az alaterület érvénytelen vagy negatív");
                    return;
                }
                bool szelessegok = double.TryParse(tbszelesseg.Text, out double szelesseg) && szelesseg > 0;
                bool hosszusagok = double.TryParse(tbhosszusag.Text, out double hosszusag) && hosszusag > 0;
                if (!szelessegok||!hosszusagok)
                {
                    MessageBox.Show("A szélesség vagy a hosszúság érvénytelen vagy negatív");
                    return;
                }
                //kategória és hirdető ell
                if (cbkategoria.SelectedIndex == -1 || cbhirdeto.SelectedIndex == -1)
                {
                    MessageBox.Show("Nincs kiválasztva hirdető vagy kategória");
                    return;
                }
                kivalasztottsor.kategoriaid = kategoriak[cbkategoria.SelectedIndex].kategoriakid;
                kivalasztottsor.hirdetoid = hirdetok[cbhirdeto.SelectedIndex].hirdetokid;
                kivalasztottsor.kepnev = tbkepnev.Text;
                if (tbhirdetesszoveg.Text == "")
                {
                    MessageBox.Show("Adja meg a hirdetés szövegét");
                    return;
                }
                string tehermentes = checkBox.IsChecked == true ? "True" : "False";
                if (datePicker.SelectedDate == null)
                {
                    MessageBox.Show("Válassz ki egy dátumot");
                    return;
                }
                DateTime hirdetesdatum = datePicker.SelectedDate.Value;

                Adatsor modositas = new Adatsor
                {
                    hirdetesekid = id,
                    szobaszam=int.Parse(cbszobaszam.SelectedValue.ToString()),
                    szelesseg=szelesseg,
                    hosszusag=hosszusag,
                    emelet= int.Parse(cbemelet.SelectedValue.ToString()),
                    alapterulet=alapterulet,
                    hirdetesszoveg=tbhirdetesszoveg.Text,
                    tehermentes=tehermentes,
                    kepnev=tbkepnev.Text,
                    hirdetesdatum=hirdetesdatum,
                    hirdetoid=kivalasztottsor.hirdetoid,
                    kategoriaid=kivalasztottsor.kategoriaid
                };
                //küldés a backend-nek
                string baseurl = "http://localhost:3000";
                string valasz = Backend.POST(baseurl + "/modositas").Body(modositas).Send().As<string>();
                MessageBox.Show(valasz);
                adatokbetoltese();//dataGrid frissítése

            }
            else MessageBox.Show("Nincs kiválasztva sor a módosításhoz");
        }

        private void btfelvitel_Click(object sender, RoutedEventArgs e)
        {
            if(tbhosszusag_uj.Text!=""&&tbszelesseg_uj.Text!="" && tbalapterulet_uj.Text != "" && tbhirdetesszoveg_uj.Text != "" && tbkepnev_uj.Text != "")
            {
                int id = adatok.Max(x => x.hirdetesekid) + 1;
                bool alapteruletok = int.TryParse(tbalapterulet_uj.Text, out int alapterulet) && alapterulet > 0;
                if (!alapteruletok)
                {
                    MessageBox.Show("Az alaterület érvénytelen vagy negatív");
                    return;
                }
                bool szelessegok = double.TryParse(tbszelesseg_uj.Text, out double szelesseg) && szelesseg > 0;
                bool hosszusagok = double.TryParse(tbhosszusag_uj.Text, out double hosszusag) && hosszusag > 0;
                if (!szelessegok || !hosszusagok)
                {
                    MessageBox.Show("A szélesség vagy a hosszúság érvénytelen vagy negatív");
                    return;
                }
                //kategória és hirdető ell
                if (cbkategoria_uj.SelectedIndex == -1 || cbhirdeto_uj.SelectedIndex == -1)
                {
                    MessageBox.Show("Nincs kiválasztva hirdető vagy kategória");
                    return;
                }
                int kategoriaazon = kategoriak[cbkategoria_uj.SelectedIndex].kategoriakid;
                int hirdetoazon = hirdetok[cbhirdeto_uj.SelectedIndex].hirdetokid;
                string kepneve = tbkepnev_uj.Text;
                string tehermentes = checkBox_uj.IsChecked == true ? "True" : "False";
                if (datePicker_uj.SelectedDate == null)
                {
                    MessageBox.Show("Válassz ki egy dátumot");
                    return;
                }
                DateTime hirdetesdatum = datePicker_uj.SelectedDate.Value;
                Adatsor felvitel = new Adatsor
                {
                    hirdetesekid = id,
                    szobaszam = int.Parse(cbszobaszam_uj.SelectedValue.ToString()),
                    szelesseg = szelesseg,
                    hosszusag = hosszusag,
                    emelet = int.Parse(cbemelet_uj.SelectedValue.ToString()),
                    alapterulet = alapterulet,
                    hirdetesszoveg = tbhirdetesszoveg_uj.Text,
                    tehermentes = tehermentes,
                    kepnev = tbkepnev_uj.Text,
                    hirdetesdatum = hirdetesdatum,
                    hirdetoid = hirdetoazon,
                    kategoriaid = kategoriaazon
                };
                //küldés a backend-nek
                string baseurl = "http://localhost:3000";
                string valasz = Backend.POST(baseurl + "/felvitel").Body(felvitel).Send().As<string>();
                MessageBox.Show(valasz);
                adatokbetoltese();//dataGrid frissítése

            }
            else MessageBox.Show("Minden adat kötelező");
        }

        private void btujkep_uj_Click(object sender, RoutedEventArgs e)
        {
            // Kép tallózása
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Képfájlok (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|Mind Files (*.*)|*.*";
            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                // A kiválasztott fájl elérési útja
                string selectedImagePath = openFileDialog.FileName;

                // A fájl neve (csak a név, nem a teljes elérési út)
                string fileName = System.IO.Path.GetFileName(selectedImagePath);

                // A fájl cél elérési útja (a "kepek" mappába másolás előtt)
                string destinationPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../../backend/hirdeteskepek/", fileName);
                
                try
                {
                    // Kép másolása a "kepek" mappába
                    System.IO.File.Copy(selectedImagePath, destinationPath, true);
                    
                    tbkepnev_uj.Text = fileName;
                    
                    // Frissítjük az Image.Source-t a kiválasztott képre
                    string kepEleresiUt = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../../backend/hirdeteskepek/", fileName);
                    Uri uri = new Uri(kepEleresiUt, UriKind.Absolute);
                     
                    // Újra létrehozzuk a BitmapImage-t
                    BitmapImage bitmapImage = new BitmapImage(uri);
                     
                    // Beállítjuk az Image.Source-t
                    image_uj.Source = bitmapImage;
                     
                    MessageBox.Show("Kép sikeresen hozzáadva a kepek mappába!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hiba történt a kép másolása során: {ex.Message}");
                }
            }
        }

        private void btujkategoria_Click(object sender, RoutedEventArgs e)
        {
            if (tbujkategorianev.Text != "")
            { 
                string ujkategoria=tbujkategorianev.Text;
                if (kategorialista.Contains(ujkategoria))
                {
                    MessageBox.Show("Ez a kategória már volt!");
                    return;
                }
                int id = kategoriak.Max(x => x.kategoriakid) + 1;
                Kategoriak kategoriafelvitel = new Kategoriak
                {
                    kategoriakid = id,
                    kategorianev = tbujkategorianev.Text
                };
                //küldés backendre
                string baseurl = "http://localhost:3000";
                string valasz = Backend.POST(baseurl + "/kategoriafelvitel").Body(kategoriafelvitel).Send().As<string>();
                MessageBox.Show(valasz);
                adatokbetoltese();
            } 
            else MessageBox.Show("A kategória megadása kötelező!");
        }

        private void cbkategoria_uj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btkategorianevmodositas_Click(object sender, RoutedEventArgs e)
        {
            if (tbujkategorianev.Text != "")
            {
                string ujkategoria = tbujkategorianev.Text;
                if (kategorialista.Contains(ujkategoria))
                {
                    MessageBox.Show("Ez a kategória már volt!");
                    return;
                }
                int id = kategoriak[cbkategoria_uj.SelectedIndex].kategoriakid;
                Kategoriak kategoriamodositas = new Kategoriak
                {
                    kategoriakid = id,
                    kategorianev = tbujkategorianev.Text
                };
                //küldés backendre
                string baseurl = "http://localhost:3000";
                string valasz = Backend.POST(baseurl + "/kategoriamodositas").Body(kategoriamodositas).Send().As<string>();
                MessageBox.Show(valasz);
                adatokbetoltese();
            }
            else MessageBox.Show("A kategória megadása!");
        }

        private void btujhirdeto_Click(object sender, RoutedEventArgs e)
        {
            if (tbujhirdetonev.Text != "" && tbujhirdetotelefon.Text != "")
            {
                string ujtelefon = tbujhirdetotelefon.Text;
                if (telefonszamoklista.Contains(ujtelefon))
                {
                    MessageBox.Show("Ez a telefonszám már volt!");
                    return;
                }
                int id = hirdetok.Max(x => x.hirdetokid) + 1; //új kulcs
                Hirdetok hirdetofelvitel = new Hirdetok
                {
                    hirdetokid = id,
                    hirdetonev = tbujhirdetonev.Text,
                    hirdetotelefon = ujtelefon
                };
                //küldés backendre
                string baseurl = "http://localhost:3000";
                string valasz = Backend.POST(baseurl + "/hirdetofelvitel").Body(hirdetofelvitel).Send().As<string>();
                MessageBox.Show(valasz);
                adatokbetoltese();
            }
            else MessageBox.Show("A név és telefonszám megadása kötelező!");
        }

        private void btnevtelefonmodositas_Click(object sender, RoutedEventArgs e)
        {
            if (tbujhirdetonev.Text != "" && tbujhirdetotelefon.Text != "")
            {
                string ujtelefon = tbujhirdetotelefon.Text;
                if (telefonszamoklista.Contains(ujtelefon))
                {
                    MessageBox.Show("Ez a telefonszám már volt!");
                    return;
                }
                int id = hirdetok[cbhirdeto_uj.SelectedIndex].hirdetokid;
                Hirdetok hirdetofelvitel = new Hirdetok
                {
                    hirdetokid = id,
                    hirdetonev = tbujhirdetonev.Text,
                    hirdetotelefon = ujtelefon
                };
                //küldés backendre
                string baseurl = "http://localhost:3000";
                string valasz = Backend.POST(baseurl + "/hirdetomodositas").Body(hirdetofelvitel).Send().As<string>();
                MessageBox.Show(valasz);
                adatokbetoltese();
            }
            else MessageBox.Show("A név és telefonszám megadása kötelező!");
        }

        private void cbhirdeto_uj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbhirdeto_uj.SelectedItem != null)
            {
                tbujhirdetonev.Text = cbhirdeto_uj.SelectedValue.ToString();
            }
        }

        private void btnevmodositas_Click(object sender, RoutedEventArgs e)
        {
            if (tbujhirdetonev.Text != "")
            {
                int id = hirdetok[cbhirdeto_uj.SelectedIndex].hirdetokid;
                Hirdetok hirdetonevmodositas = new Hirdetok
                {
                    hirdetokid = id,
                    hirdetonev = tbujhirdetonev.Text
                };
                //küldés backendre
                string baseurl = "http://localhost:3000";
                string valasz = Backend.POST(baseurl + "/hirdetonevmodositas").Body(hirdetonevmodositas).Send().As<string>();
                MessageBox.Show(valasz);
                adatokbetoltese();
            }
            else MessageBox.Show("A név megadása kötelező!");
        }
    }
}

