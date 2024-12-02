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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btujdolgozo_Click(object sender, RoutedEventArgs e)
        {
            if (tbnev.Text != "" && tbber.Text != "")
            {

            }
            else MessageBox.Show("Minden adatot meg kell adni az új dolgozó felvételéhez!");
        }

        private void btujreszleg_Click(object sender, RoutedEventArgs e)
        {
            if (tbujreszleg.Text != "")
            {

            }
            else MessageBox.Show("Add meg az új részleg nevét!");
        }
    }
}