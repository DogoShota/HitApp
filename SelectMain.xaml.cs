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
using HitApp.config;

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

            display();
        }

        private void display()
        {
            Config conf = new Config();
            Dictionary<string, DateTime> test = conf.get_test_day();

            testday.Text = test["testDay"].ToString("yyyy/MM/dd");
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
            Button btn = (Button)sender;
            string bunnya = btn.Content.ToString();
            switch (bunnya)
            {
                case "情報処理技術系":
                    var TechWindow = new TechnoMain("2023", "情報処理技術系");
                    NavigationService.Navigate(TechWindow);
                    break;
                case "医療情報システム系":
                    var IJWindow = new SystemMain("2023", "医療情報システム系");
                    NavigationService.Navigate(IJWindow);
                    break;
                case "医学・医療系":
                    var IIWindow = new MedicalMain("2023", "医学・医療系");
                    NavigationService.Navigate(IIWindow);
                    break;
            }
        }

        private void Button_Click_2022(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string bunnya = btn.Content.ToString();
            switch (bunnya)
            {
                case "情報処理技術系":
                    var TechWindow = new TechnoMain("2022", "情報処理技術系");
                    NavigationService.Navigate(TechWindow);
                    break;
                case "医療情報システム系":
                    var IJWindow = new SystemMain("2022", "医療情報システム系");
                    NavigationService.Navigate(IJWindow);
                    break;
                case "医学・医療系":
                    var IIWindow = new MedicalMain("2022", "医学・医療系");
                    NavigationService.Navigate(IIWindow);
                    break;
            }
        }

        private void Button_Click_2021(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string bunnya = btn.Content.ToString();
            switch (bunnya)
            {
                case "情報処理技術系":
                    var TechWindow = new TechnoMain("2021", "情報処理技術系");
                    NavigationService.Navigate(TechWindow);
                    break;
                case "医療情報システム系":
                    var IJWindow = new SystemMain("2021", "医療情報システム系");
                    NavigationService.Navigate(IJWindow);
                    break;
                case "医学・医療系":
                    var IIWindow = new MedicalMain("2021", "医学・医療系");
                    NavigationService.Navigate(IIWindow);
                    break;
            }
        }

        private void Button_Click_2019(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string bunnya = btn.Content.ToString();
            switch (bunnya)
            {
                case "情報処理技術系":
                    var TechWindow = new TechnoMain("2019", "情報処理技術系");
                    NavigationService.Navigate(TechWindow);
                    break;
                case "医療情報システム系":
                    var IJWindow = new SystemMain("2019", "医療情報システム系");
                    NavigationService.Navigate(IJWindow);
                    break;
                case "医学・医療系":
                    var IIWindow = new MedicalMain("2019", "医学・医療系");
                    NavigationService.Navigate(IIWindow);
                    break;
            }
        }

        private void Button_Click_2018(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string bunnya = btn.Content.ToString();
            switch (bunnya)
            {
                case "情報処理技術系":
                    var TechWindow = new TechnoMain("2018", "情報処理技術系");
                    NavigationService.Navigate(TechWindow);
                    break;
                case "医療情報システム系":
                    var IJWindow = new SystemMain("2018", "医療情報システム系");
                    NavigationService.Navigate(IJWindow);
                    break;
                case "医学・医療系":
                    var IIWindow = new MedicalMain("2018", "医学・医療系");
                    NavigationService.Navigate(IIWindow);
                    break;
            }
        }

        private void Button_Click_2017(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string bunnya = btn.Content.ToString();
            switch (bunnya)
            {
                case "情報処理技術系":
                    var TechWindow = new TechnoMain("2017", "情報処理技術系");
                    NavigationService.Navigate(TechWindow);
                    break;
                case "医療情報システム系":
                    var IJWindow = new SystemMain("2017", "医療情報システム系");
                    NavigationService.Navigate(IJWindow);
                    break;
                case "医学・医療系":
                    var IIWindow = new MedicalMain("2017", "医学・医療系");
                    NavigationService.Navigate(IIWindow);
                    break;
            }
        }

        private void Button_Click_2016(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string bunnya = btn.Content.ToString();
            switch (bunnya)
            {
                case "情報処理技術系":
                    var TechWindow = new TechnoMain("2016", "情報処理技術系");
                    NavigationService.Navigate(TechWindow);
                    break;
                case "医療情報システム系":
                    var IJWindow = new SystemMain("2016", "医療情報システム系");
                    NavigationService.Navigate(IJWindow);
                    break;
                case "医学・医療系":
                    var IIWindow = new MedicalMain("2016", "医学・医療系");
                    NavigationService.Navigate(IIWindow);
                    break;
            }
        }

        private void Button_Click_2015(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string bunnya = btn.Content.ToString();
            switch (bunnya)
            {
                case "情報処理技術系":
                    var TechWindow = new TechnoMain("2015", "情報処理技術系");
                    NavigationService.Navigate(TechWindow);
                    break;
                case "医療情報システム系":
                    var IJWindow = new SystemMain("2015", "医療情報システム系");
                    NavigationService.Navigate(IJWindow);
                    break;
                case "医学・医療系":
                    var IIWindow = new MedicalMain("2015", "医学・医療系");
                    NavigationService.Navigate(IIWindow);
                    break;
            }
        }

        private void Button_Click_2014(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string bunnya = btn.Content.ToString();
            switch (bunnya)
            {
                case "情報処理技術系":
                    var TechWindow = new TechnoMain("2014", "情報処理技術系");
                    NavigationService.Navigate(TechWindow);
                    break;
                case "医療情報システム系":
                    var IJWindow = new SystemMain("2014", "医療情報システム系");
                    NavigationService.Navigate(IJWindow);
                    break;
                case "医学・医療系":
                    var IIWindow = new MedicalMain("2014", "医学・医療系");
                    NavigationService.Navigate(IIWindow);
                    break;
            }
        }

        private void Button_Click_2013(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string bunnya = btn.Content.ToString();
            switch (bunnya)
            {
                case "情報処理技術系":
                    var TechWindow = new TechnoMain("2013", "情報処理技術系");
                    NavigationService.Navigate(TechWindow);
                    break;
                case "医療情報システム系":
                    var IJWindow = new SystemMain("2013", "医療情報システム系");
                    NavigationService.Navigate(IJWindow);
                    break;
                case "医学・医療系":
                    var IIWindow = new MedicalMain("2013", "医学・医療系");
                    NavigationService.Navigate(IIWindow);
                    break;
            }
        }

        private void Button_Click_2012(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string bunnya = btn.Content.ToString();
            switch (bunnya)
            {
                case "情報処理技術系":
                    var TechWindow = new TechnoMain("2012", "情報処理技術系");
                    NavigationService.Navigate(TechWindow);
                    break;
                case "医療情報システム系":
                    var IJWindow = new SystemMain("2012", "医療情報システム系");
                    NavigationService.Navigate(IJWindow);
                    break;
                case "医学・医療系":
                    var IIWindow = new MedicalMain("2012", "医学・医療系");
                    NavigationService.Navigate(IIWindow);
                    break;
            }
        }

        private void Button_Click_2011(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string bunnya = btn.Content.ToString();
            switch (bunnya)
            {
                case "情報処理技術系":
                    var TechWindow = new TechnoMain("2011", "情報処理技術系");
                    NavigationService.Navigate(TechWindow);
                    break;
                case "医療情報システム系":
                    var IJWindow = new SystemMain("2011", "医療情報システム系");
                    NavigationService.Navigate(IJWindow);
                    break;
                case "医学・医療系":
                    var IIWindow = new MedicalMain("2011", "医学・医療系");
                    NavigationService.Navigate(IIWindow);
                    break;
            }
        }

        private void Button_Click_2010(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string bunnya = btn.Content.ToString();
            switch (bunnya)
            {
                case "情報処理技術系":
                    var TechWindow = new TechnoMain("2010", "情報処理技術系");
                    NavigationService.Navigate(TechWindow);
                    break;
                case "医療情報システム系":
                    var IJWindow = new SystemMain("2010", "医療情報システム系");
                    NavigationService.Navigate(IJWindow);
                    break;
                case "医学・医療系":
                    var IIWindow = new MedicalMain("2010", "医学・医療系");
                    NavigationService.Navigate(IIWindow);
                    break;
            }
        }

        private void Button_Click_2009(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string bunnya = btn.Content.ToString();
            switch (bunnya)
            {
                case "情報処理技術系":
                    var TechWindow = new TechnoMain("2009", "情報処理技術系");
                    NavigationService.Navigate(TechWindow);
                    break;
                case "医療情報システム系":
                    var IJWindow = new SystemMain("2009", "医療情報システム系");
                    NavigationService.Navigate(IJWindow);
                    break;
                case "医学・医療系":
                    var IIWindow = new MedicalMain("2009", "医学・医療系");
                    NavigationService.Navigate(IIWindow);
                    break;
            }
        }

        private void Button_Click_2008(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string bunnya = btn.Content.ToString();
            switch (bunnya)
            {
                case "情報処理技術系":
                    var TechWindow = new TechnoMain("2008", "情報処理技術系");
                    NavigationService.Navigate(TechWindow);
                    break;
                case "医療情報システム系":
                    var IJWindow = new SystemMain("2008", "医療情報システム系");
                    NavigationService.Navigate(IJWindow);
                    break;
                case "医学・医療系":
                    var IIWindow = new MedicalMain("2008", "医学・医療系");
                    NavigationService.Navigate(IIWindow);
                    break;
            }
        }
        private void Button_Click_2007(object sender, RoutedEventArgs e)
        {
            // 過去問が追加されたらコメントアウト消す
            /*Button btn = (Button)sender;
            string bunnya = btn.Content.ToString();
            switch (bunnya)
            {
                case "情報処理技術系":
                    var TechWindow = new TechnoMain("2007", "情報処理技術系");
                    NavigationService.Navigate(TechWindow);
                    break;
                case "医療情報システム系":
                    var IJWindow = new SystemMain("2007", "医療情報システム系");
                    NavigationService.Navigate(IJWindow);
                    break;
                case "医学・医療系":
                    var IIWindow = new MedicalMain("2007", "医学・医療系");
                    NavigationService.Navigate(IIWindow);
                    break;
            }*/
        }
        private void Button_Click_2006(object sender, RoutedEventArgs e)
        {
            // 過去問が追加されたらコメントアウト消す
            /*Button btn = (Button)sender;
            string bunnya = btn.Content.ToString();
            switch (bunnya)
            {
                case "情報処理技術系":
                    var TechWindow = new TechnoMain("2006", "情報処理技術系");
                    NavigationService.Navigate(TechWindow);
                    break;
                case "医療情報システム系":
                    var IJWindow = new SystemMain("2006", "医療情報システム系");
                    NavigationService.Navigate(IJWindow);
                    break;
                case "医学・医療系":
                    var IIWindow = new MedicalMain("2006", "医学・医療系");
                    NavigationService.Navigate(IIWindow);
                    break;
            }*/
        }
        private void Button_Click_2005(object sender, RoutedEventArgs e)
        {
            // 過去問が追加されたらコメントアウト消す
            /*Button btn = (Button)sender;
            string bunnya = btn.Content.ToString();
            switch (bunnya)
            {
                case "情報処理技術系":
                    var TechWindow = new TechnoMain("2005", "情報処理技術系");
                    NavigationService.Navigate(TechWindow);
                    break;
                case "医療情報システム系":
                    var IJWindow = new SystemMain("2005", "医療情報システム系");
                    NavigationService.Navigate(IJWindow);
                    break;
                case "医学・医療系":
                    var IIWindow = new MedicalMain("2005", "医学・医療系");
                    NavigationService.Navigate(IIWindow);
                    break;
            }*/
        }
        private void Button_Click_2004(object sender, RoutedEventArgs e)
        {
            // 過去問が追加されたらコメントアウト消す
            /*Button btn = (Button)sender;
            string bunnya = btn.Content.ToString();
            switch (bunnya)
            {
                case "情報処理技術系":
                    var TechWindow = new TechnoMain("2004", "情報処理技術系");
                    NavigationService.Navigate(TechWindow);
                    break;
                case "医療情報システム系":
                    var IJWindow = new SystemMain("2004", "医療情報システム系");
                    NavigationService.Navigate(IJWindow);
                    break;
                case "医学・医療系":
                    var IIWindow = new MedicalMain("2004", "医学・医療系");
                    NavigationService.Navigate(IIWindow);
                    break;
            }*/
        }
    }
}
