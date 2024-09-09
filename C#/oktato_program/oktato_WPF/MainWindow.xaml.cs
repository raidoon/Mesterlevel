using System;
using System.Windows;

namespace oktato_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] valasz = new int[10], a=new int[10], b=new int[10], eredmenyek = new int[10];
        int muvelet = 0;
        int db = 0, i=0, pontszam = 0;
        Random r = new Random();
        string[] muveletjel = new string[10];
        public MainWindow()
        {
            InitializeComponent();
            i = 0;
            pontszam = 0;
            db = 0;
            szamgeneralas();
        }

        private void szamgeneralas()
        {
            a[i] = r.Next(20);
            b[i] = r.Next(20);
            muvelet = r.Next(2);
            switch (muvelet)
            {
                case 0: muveletjel[i] = "+"; lb_feladvany.Content = $"{i+1}. feladat: Mennyi {a[i]} + {b[i]} ="; eredmenyek[i] = a[i] + b[i]; break;
                case 1: muveletjel[i] = "-"; lb_feladvany.Content = $"{i + 1}. feladat: Mennyi {a[i]} - {b[i]} ="; eredmenyek[i] = a[i] - b[i]; break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int szam = 0;
            bool okszam = false;
            if (tb_valasz.Text != "")
            {
                try
                {
                    szam = int.Parse(tb_valasz.Text);
                    okszam = true;
                    valasz[i] = szam;
                }
                catch 
                { 
                    MessageBox.Show("Nem számot adtál meg!");
                    okszam=false;
                }
                if (okszam)
                {
                    if (valasz[i] == eredmenyek[i])
                    {
                        pontszam++;
                        lb_eredmeny.Content = "A válasz helyes!";
                    }
                    else lb_eredmeny.Content = $"A helyes válasz: {a[i]} {muveletjel[i]} {b[i]} = {eredmenyek[i]}";
                    i++;
                    szamgeneralas();
                }
            }
            else MessageBox.Show("Elfelejtettél választ írni! :)");
            if (i == 9)
            {
                switch (pontszam)
                {
                    case 0:
                    case 1:
                    case 2:
                        lb_eredmeny.Content="Elégtelen"; break;
                    case 3:
                    case 4: lb_eredmeny.Content="Elégséges"; break;
                    case 5:
                    case 6:
                        lb_eredmeny.Content="Közepes"; break;
                    case 7:
                    case 8:
                        lb_eredmeny.Content = "Jó"; break;
                    case 9:
                    case 10:
                        lb_eredmeny.Content = "Jeles"; break;
                }
                bt_ertekel.IsEnabled = false;
                lb_eredmeny.Content += "\nHelyes válaszok:";
                for (int i = 0; i < 9; i++)
                {
                    lb_eredmeny.Content += $"\n{i + 1}. feladat: {a[i]} {muveletjel[i]} {b[i]} = {eredmenyek[i]}";
                }
            }
        }
    }
}