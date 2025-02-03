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
    /// ResultWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ResultWindow : Page
    {
        // 前画面で選択された年度と分野
        string year, bunnya;
        // 解いている問題が何問目か(0が一問目)
        int QCount;
        // 正解数
        double rightCount;
        // 正解率
        double ansPercentage;
        // 正誤結果を格納するリスト
        List<string> resList = new List<string>();
        // 問題分、選択肢を格納するリスト
        List<string> AnsList = new List<string>();
        // ランダム出題がどうか
        bool randumMode;
        // ランダム時、月に出題する問題番号を格納
        List<int> rumList = new List<int>();
        // 解答時間を格納
        double time;

        public ResultWindow(string year, string bunnya, int QCount, int rightCount, List<string> resList, List<string> AnsList, double time, bool randumMode = false, List<int> rumList = null)
        {
            InitializeComponent();
            this.year = year;
            this.bunnya = bunnya;
            this.QCount = QCount;
            this.rightCount = rightCount;
            this.resList = resList;
            this.AnsList = AnsList;
            this.time = time;
            this.randumMode = randumMode;
            this.rumList = rumList;

            calc();

            display();

            addRowRowDefinitions();
            testAdd();
        }

        // 正解率の計算
        private void calc()
        {
            double buff = (rightCount / resList.Count) * 100;
            ansPercentage = Math.Round(buff, 1, MidpointRounding.AwayFromZero);
        }

        // 画面表示
        private void display()
        {
            title.Content = year + "年度・" + bunnya;
            正解率.Text = "正解率：" + ansPercentage.ToString() + "%";

            test.Text = "解答時間：" + calc_time();
        }

        private string calc_time()
        {
            double minute = time / 60;
            double second = time % 60;

            int min = (int)minute;
            int sec = (int)second;

            string res;
            if (min == 0)
            {
                res = sec.ToString() + "秒";
            }
            else
            {
               res = min.ToString() + "分" + sec.ToString() + "秒";
            }

            return res;
        }

        private void reSelect(object sender, RoutedEventArgs e)
        {
            var selectMain = new SelectMain();
            NavigationService.Navigate(selectMain);
        }

        private void retry(object sender, RoutedEventArgs e)
        {
            switch (bunnya)
            {
                case "情報処理技術系":
                    var TechWindow = new TechnoMain(year, "情報処理技術系");
                    NavigationService.Navigate(TechWindow);
                    break;
                case "医療情報システム系":
                    var IJWindow = new SystemMain(year, "医療情報システム系");
                    NavigationService.Navigate(IJWindow);
                    break;
                case "医学・医療系":
                    var IIWindow = new MedicalMain(year, "医学・医療系");
                    NavigationService.Navigate(IIWindow);
                    break;
            }
        }
        private void explanation(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int Qnum = int.Parse(btn.Name.Substring(1));

            Explanation exp = new Explanation(year, bunnya, Qnum - 1, AnsList);
            NavigationService.Navigate(exp);
        }

        private void addRowRowDefinitions()
        {
            RowDefinition first = new RowDefinition();
            first.Height = new GridLength(20, GridUnitType.Pixel);
            dataGrid.RowDefinitions.Add(first);

            for (int i = 0; i <= resList.Count; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(40, GridUnitType.Pixel);

                dataGrid.RowDefinitions.Add(row);
            }
        }

        private void testAdd()
        {
            Border firstBorder = new Border();
            firstBorder.BorderBrush = Brushes.Black;
            firstBorder.BorderThickness = new Thickness(0, 0.5, 0, 0.5);

            dataGrid.Children.Add(firstBorder);
            firstBorder.SetValue(Grid.RowProperty, 1);
            firstBorder.SetValue(Grid.ColumnSpanProperty, 3);

            int question_count = 50;
            if (this.bunnya.Equals("医療情報システム系"))
                question_count = 60;

            int first_question_num = question_count - resList.Count;
            int n = 0;
            for (int i = first_question_num; i < question_count; i++)
            {
                var No = new Label();
                if (randumMode)
                    No.Content = rumList[i] + 1;
                else
                    No.Content = (i + 1).ToString();
                No.FontSize = 24;
                No.HorizontalAlignment = HorizontalAlignment.Center;
                No.VerticalAlignment = VerticalAlignment.Center;

                var ansRes = new Label();
                ansRes.Content = resList[n];
                ansRes.FontSize = 24;
                if (ansRes.Content.Equals("○"))
                    ansRes.Foreground = Brushes.Lime;
                else
                {
                    ansRes.Foreground = Brushes.Red;
                    ansRes.Content = "✕";
                }
                ansRes.HorizontalAlignment = HorizontalAlignment.Center;
                ansRes.VerticalAlignment = VerticalAlignment.Center;


                var expButton = new Button();
                expButton.Content = "解説";
                if (randumMode)
                    expButton.Name = "問" + (rumList[i] + 1).ToString();
                else
                    expButton.Name = "問" + (i+1).ToString();
                expButton.Click += explanation;
                expButton.Style = FindResource("QuesWinButton") as Style;

                Border border = new Border();
                border.BorderBrush = Brushes.Black;
                border.BorderThickness = new Thickness(0, 0, 0, 0.5);


                dataGrid.Children.Add(No);
                No.SetValue(Grid.RowProperty, n + 1);
                No.SetValue(Grid.ColumnProperty, 0);

                dataGrid.Children.Add(ansRes);
                ansRes.SetValue(Grid.RowProperty, n + 1);
                ansRes.SetValue(Grid.ColumnProperty, 1);

                dataGrid.Children.Add(expButton);
                expButton.SetValue(Grid.RowProperty, n + 1);
                expButton.SetValue(Grid.ColumnProperty, 2);

                dataGrid.Children.Add(border);
                border.SetValue(Grid.RowProperty, n+1);
                border.SetValue(Grid.ColumnSpanProperty, 3);

                n++;
            }
        }
    }
}