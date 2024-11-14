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

        private void Button_Click_2024(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            var QWindow = new Question("2024", btn.Content.ToString());
            NavigationService.Navigate(QWindow);
        }

        private void Button_Click_2023(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            var QWindow = new Question("2023", btn.Content.ToString());
            NavigationService.Navigate(QWindow);
        }

        private void Button_Click_2022(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            var QWindow = new Question("2022", btn.Content.ToString());
            NavigationService.Navigate(QWindow);
        }

        private void Button_Click_2021(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            var QWindow = new Question("2021", btn.Content.ToString());
            NavigationService.Navigate(QWindow);
        }

        private void Button_Click_2019(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            var QWindow = new Question("2019", btn.Content.ToString());
            NavigationService.Navigate(QWindow);
        }

        private void Button_Click_2018(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            var QWindow = new Question("2018", btn.Content.ToString());
            NavigationService.Navigate(QWindow);
        }

        private void Button_Click_2017(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            var QWindow = new Question("2017", btn.Content.ToString());
            NavigationService.Navigate(QWindow);
        }

        private void Button_Click_2016(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            var QWindow = new Question("2016", btn.Content.ToString());
            NavigationService.Navigate(QWindow);
        }

        private void Button_Click_2015(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            var QWindow = new Question("2015", btn.Content.ToString());
            NavigationService.Navigate(QWindow);
        }

        private void Button_Click_2014(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            var QWindow = new Question("2014", btn.Content.ToString());
            NavigationService.Navigate(QWindow);
        }

        private void Button_Click_2013(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            var QWindow = new Question("2013", btn.Content.ToString());
            NavigationService.Navigate(QWindow);
        }

        private void Button_Click_2012(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            var QWindow = new Question("2012", btn.Content.ToString());
            NavigationService.Navigate(QWindow);
        }

        private void Button_Click_2011(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            var QWindow = new Question("2011", btn.Content.ToString());
            NavigationService.Navigate(QWindow);
        }

        private void Button_Click_2010(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            var QWindow = new Question("2010", btn.Content.ToString());
            NavigationService.Navigate(QWindow);
        }

        private void Button_Click_2009(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            var QWindow = new Question("2009", btn.Content.ToString());
            NavigationService.Navigate(QWindow);
        }

        private void Button_Click_2008(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            var QWindow = new Question("2008", btn.Content.ToString());
            NavigationService.Navigate(QWindow);
        }
    }
}
