using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

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

            //display();
        }

        private void display()
        {
            ResourceDictionary dic = new ResourceDictionary();
            dic.Source = new Uri("app.xaml", UriKind.Relative);

            TextBlock textBlock = new TextBlock();
            textBlock.Text = "2024年度";
            textBlock.FontSize = 15;
            textBlock.FontFamily = (FontFamily)dic.FindName("NotoSansMedium");
            textBlock.FontWeight = FontWeights.UltraBlack;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Center;

            Button btn1 = new Button();
            btn1.Content = "情報処理技術系";
            btn1.Margin = new Thickness(10, 3, 10, 3);
            btn1.Background = Brushes.LightGreen;
            btn1.Click += Button_Click_2024;

            Button btn2 = new Button();
            btn2.Content = "医療情報システム系";
            btn2.Margin = new Thickness(10, 3, 10, 3);
            btn2.Background = Brushes.Yellow;
            btn2.Click += Button_Click_2024;

            Button btn3 = new Button();
            btn3.Content = "医学・医療系";
            btn3.Margin = new Thickness(10, 3, 10, 3);
            btn3.Background = Brushes.Aqua;
            btn3.Click += Button_Click_2024;

            SelectTable.Children.Add(textBlock);
            SelectTable.Children.Add(btn1);
            SelectTable.Children.Add(btn2);
            SelectTable.Children.Add(btn3);

            Grid.SetRow(textBlock, 0);
            Grid.SetRow(btn1, 0);
            Grid.SetRow(btn2, 0);
            Grid.SetRow(btn3, 0);
            Grid.SetColumn(textBlock, 0);
            Grid.SetColumn(btn1, 1);
            Grid.SetColumn(btn2, 2);
            Grid.SetColumn(btn3, 3);

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var startPage = new StartWindow();
            NavigationService.Navigate(startPage);
        }

        private void Button_Click_2024(object sender, RoutedEventArgs e)
        {
            // 過去問が追加されたらコメントアウト消す
            //Button btn = (Button)sender;

            //var QWindow = new Question("2024", btn.Content.ToString());
            //NavigationService.Navigate(QWindow);
        }

        private void Button_Click_2023(object sender, RoutedEventArgs e)
        {
            // 過去問が追加されたらコメントアウト消す
            //Button btn = (Button)sender;

            //var QWindow = new Question("2023", btn.Content.ToString());
            //NavigationService.Navigate(QWindow);
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
