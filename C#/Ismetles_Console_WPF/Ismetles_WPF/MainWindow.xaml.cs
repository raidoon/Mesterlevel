using System;
using System.IO;
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

namespace Ismetles_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            if (tb_telekszelesseg.Text!=null && tb_telekhossz.Text != null)
            {
                int telekszelesseg = Convert.ToInt32(tb_telekszelesseg.Text);
            }
        }

        private void bt_szamol_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
