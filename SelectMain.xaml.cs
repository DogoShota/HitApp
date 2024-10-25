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

namespace HitApp
{
    /// <summary>
    /// SelectMain.xaml の相互作用ロジック
    /// </summary>
    public partial class SelectMain : Page
    {
        public SelectMain()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var startPage = new StartWindow();
            NavigationService.Navigate(startPage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var medicalMain = new MedicalMain();
            NavigationService.Navigate(medicalMain);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var technoMain = new TechnoMain();
            NavigationService.Navigate(technoMain);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var systemMain = new SystemMain();
            NavigationService.Navigate(systemMain);
        }
    }
}
