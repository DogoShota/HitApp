﻿using System;
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
        Dictionary<int, string> resList = new Dictionary<int, string>();
        // 問題分、選択肢を格納するリスト
        List<string> AnsList = new List<string>();
        // ランダム出題がどうか
        bool randumMode;
        // ランダム時、月に出題する問題番号を格納
        List<int> rumList = new List<int>();
        // 解答時間を格納
        double time;

        public ResultWindow(string year, string bunnya, int QCount, int rightCount, Dictionary<int,string> resList, List<string> AnsList, double time, bool randumMode = false, List<int> rumList = null)
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
            addResult();
        }

        // 画面更新
        private void display()
        {
            showTitle.Content = year + "年度・" + bunnya;
            正解率.Text = "正解率：" + ansPercentage.ToString() + "%";

            showTime.Text = "解答時間：" + calc_time();

            if (!checkMiss())
            {
                retryButton.IsEnabled = false;
            }
        }

        // 正解率の計算
        private void calc()
        {
            double buff = (rightCount / resList.Count) * 100;
            ansPercentage = Math.Round(buff, 1, MidpointRounding.AwayFromZero);
        }

        // 解答時間を計算
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

        // 間違えた問題があるか確認
        // あったらtrue
        private bool checkMiss()
        {
            bool flag = false;
            foreach (int key in resList.Keys)
            {
                if (resList[key].Equals("×"))
                    flag = true;
            }
            
            return flag;
        }
        private void backFirstClick(object sender, RoutedEventArgs e)
        {
            var selectMain = new SelectMain();
            NavigationService.Navigate(selectMain);
        }

        private void retryClick(object sender, RoutedEventArgs e)
        {
            List<int> retryList = new List<int>();
            foreach (int key in resList.Keys)
            {
                if (resList[key].Equals("×"))
                    retryList.Add(key);
            }
            Question QWindow = new Question(year, bunnya, 1, false, retryList);
            NavigationService.Navigate(QWindow);
        }

        private void explanation(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int Qnum = int.Parse(btn.Name.Substring(1));

            Explanation exp = new Explanation(year, bunnya, Qnum - 1, AnsList);
            NavigationService.Navigate(exp);
        }

        // 結果表示用のGridを作成
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


        // 結果を表示
        private void addResult()
        {
            // 一番上のBorder
            Border firstBorder = new Border();
            firstBorder.BorderBrush = Brushes.Black;
            firstBorder.BorderThickness = new Thickness(0, 0.5, 0, 0);

            dataGrid.Children.Add(firstBorder);
            firstBorder.SetValue(Grid.RowProperty, 1);
            firstBorder.SetValue(Grid.ColumnSpanProperty, 3);


            // 結果を一覧で表示
            int n = 0;
            foreach (int key in resList.Keys)
            {
                // 問題番号
                var No = new Label();
                No.Content = key;
                No.FontSize = 24;
                No.HorizontalAlignment = HorizontalAlignment.Center;
                No.VerticalAlignment = VerticalAlignment.Center;

                // 正誤結果
                var ansRes = new Label();
                ansRes.Content = resList[key];
                ansRes.FontSize = 24;
                if (ansRes.Content.Equals("○"))
                    ansRes.Foreground = Brushes.Lime;
                else
                {
                    ansRes.Content = "✕";
                    ansRes.Foreground = Brushes.Red;
                }
                ansRes.HorizontalAlignment = HorizontalAlignment.Center;
                ansRes.VerticalAlignment = VerticalAlignment.Center;

                // 解説表示のボタン
                var expButton = new Button();
                expButton.Content = "解説";
                if (randumMode)
                    expButton.Name = "問" + key.ToString();
                else
                    expButton.Name = "問" + key.ToString();
                expButton.Click += explanation;
                expButton.Style = FindResource("QuesWinButton") as Style;

                // Border
                Border border = new Border();
                border.BorderBrush = Brushes.Black;
                border.BorderThickness = new Thickness(0, 0, 0, 0.5);

                // コントロールを追加
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
                border.SetValue(Grid.RowProperty, n + 1);
                border.SetValue(Grid.ColumnSpanProperty, 3);

                n++;
            }
        }
    }
}