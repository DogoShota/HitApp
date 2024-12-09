﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Medical_Q.xaml の相互作用ロジック
    /// </summary>
    public partial class Question : Page
    {
        // 前画面で選択された年度と分野
        string year, bunnya;
        // 取得するcsvを格納する変数
        StreamReader csv, ansCsv;
        // 問題分、選択肢を格納するリスト
        List<string> AnsList = new List<string>();
        // 解答を格納するリスト
        List<string> QList = new List<string>();
        // 解いている問題が何問目か(0が一問目)
        int QCount = 0;
        // 正解数
        int rightCount = 0;
        // 正誤結果を格納するリスト
        List<string> resList = new List<string>();

        public Question(string year, string bunnya)
        {
            InitializeComponent();
            this.year = year;
            this.bunnya = bunnya;

            getQuestionText();
            display();
        }

        // csvから問題と正解を取得して、リストに格納する
        private void getQuestionText ()
        {
            // 選択された年度、分野のcsvを取得する
            switch (year)
            {
                case "2023":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"../../csv/2023JS.csv");
                            ansCsv = new StreamReader(@"../../csv/2023JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"../../csv/2023IS.csv");
                            ansCsv = new StreamReader(@"../../csv/2023IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"../../csv/2023II.csv");
                            ansCsv = new StreamReader(@"../../csv/2023II.解説.csv");
                            break;
                    }
                    break;

                case "2022":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"../../csv/2022JS.csv");
                            ansCsv = new StreamReader(@"../../csv/2022JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"../../csv/2022IS.csv");
                            ansCsv = new StreamReader(@"../../csv/2022IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"../../csv/2022II.csv");
                            ansCsv = new StreamReader(@"../../csv/2022II.解説.csv");
                            break;
                    }
                    break;

                case "2021":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"../../csv/2021JS.csv");
                            ansCsv = new StreamReader(@"../../csv/2021JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"../../csv/2021IS.csv");
                            ansCsv = new StreamReader(@"../../csv/2021IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"../../csv/2021II.csv");
                            ansCsv = new StreamReader(@"../../csv/2021II.解説.csv");
                            break;
                    }
                    break;

                case "2019":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"../../csv/2019JS.csv");
                            ansCsv = new StreamReader(@"../../csv/2019JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"../../csv/2019IS.csv");
                            ansCsv = new StreamReader(@"../../csv/2019IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"../../csv/2019II.csv");
                            ansCsv = new StreamReader(@"../../csv/2019II.解説.csv");
                            break;
                    }
                    break;

                case "2018":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"../../csv/2018JS.csv");
                            ansCsv = new StreamReader(@"../../csv/2018JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"../../csv/2018IS.csv");
                            ansCsv = new StreamReader(@"../../csv/2018IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"../../csv/2018II.csv");
                            ansCsv = new StreamReader(@"../../csv/2018II.解説.csv");
                            break;
                    }
                    break;

                case "2017":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"../../csv/2017JS.csv");
                            ansCsv = new StreamReader(@"../../csv/2017JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"../../csv/2017IS.csv");
                            ansCsv = new StreamReader(@"../../csv/2017IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"../../csv/2017II.csv");
                            ansCsv = new StreamReader(@"../../csv/2017II.解説.csv");
                            break;
                    }
                    break;

                case "2016":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"../../csv/2016JS.csv");
                            ansCsv = new StreamReader(@"../../csv/2016JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"../../csv/2016IS.csv");
                            ansCsv = new StreamReader(@"../../csv/2016IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"../../csv/2016II.csv");
                            ansCsv = new StreamReader(@"../../csv/2016II.解説.csv");
                            break;
                    }
                    break;

                case "2015":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"../../csv/2015JS.csv");
                            ansCsv = new StreamReader(@"../../csv/2015JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"../../csv/2015IS.csv");
                            ansCsv = new StreamReader(@"../../csv/2015IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"../../csv/2015II.csv");
                            ansCsv = new StreamReader(@"../../csv/2015II.解説.csv");
                            break;
                    }
                    break;

                case "2014":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"../../csv/2014JS.csv");
                            ansCsv = new StreamReader(@"../../csv/2014JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"../../csv/2014IS.csv");
                            ansCsv = new StreamReader(@"../../csv/2014IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"../../csv/2014II.csv");
                            ansCsv = new StreamReader(@"../../csv/2014II.解説.csv");
                            break;
                    }
                    break;

                case "2013":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"../../csv/2013JS.csv");
                            ansCsv = new StreamReader(@"../../csv/2013JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"../../csv/2013IS.csv");
                            ansCsv = new StreamReader(@"../../csv/2013IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"../../csv/2013II.csv");
                            ansCsv = new StreamReader(@"../../csv/2013II.解説.csv");
                            break;
                    }
                    break;

                case "2012":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"../../csv/2012JS.csv");
                            ansCsv = new StreamReader(@"../../csv/2012JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"../../csv/2012IS.csv");
                            ansCsv = new StreamReader(@"../../csv/2012IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"../../csv/2012II.csv");
                            ansCsv = new StreamReader(@"../../csv/2012II.解説.csv");
                            break;
                    }
                    break;

                case "2011":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"../../csv/2011JS.csv");
                            ansCsv = new StreamReader(@"../../csv/2011JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"../../csv/2011IS.csv");
                            ansCsv = new StreamReader(@"../../csv/2011IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"../../csv/2011II.csv");
                            ansCsv = new StreamReader(@"../../csv/2011II.解説.csv");
                            break;
                    }
                    break;

                case "2010":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"../../csv/2010JS.csv");
                            // ansCsv = new StreamReader(@"../../csv/2010JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"../../csv/2010IS.csv");
                            // ansCsv = new StreamReader(@"../../csv/2010IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"../../csv/2010II.csv");
                            //ansCsv = new StreamReader(@"../../csv/2010II.解説.csv");
                            break;
                    }
                    break;

                case "2009":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"../../csv/2009JS.csv");
                            // ansCsv = new StreamReader(@"../../csv/2009JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"../../csv/2009IS.csv");
                            // ansCsv = new StreamReader(@"../../csv/2009IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"../../csv/2009II.csv");
                            // ansCsv = new StreamReader(@"../../csv/2009II.解説.csv");
                            break;
                    }
                    break;

                case "2008":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"../../csv/2008JS.csv");
                            // ansCsv = new StreamReader(@"../../csv/2008JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"../../csv/2008IS.csv");
                            // ansCsv = new StreamReader(@"../../csv/2008IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"../../csv/2008II.csv");
                            // ansCsv = new StreamReader(@"../../csv/2008II.解説.csv");
                            break;
                    }
                    break;
            }

            // 一行とばす
            csv.ReadLine();
            ansCsv.ReadLine();

            // 問題文csvをリストに格納
            while (!csv.EndOfStream)
            {
                string line = csv.ReadLine();
                string[] values = line.Split(',');

                QList.AddRange(values);
            }

            // 解答例csvをリストに格納
            while (!ansCsv.EndOfStream)
            {
                string ansLine = ansCsv.ReadLine();
                string[] ansValues = ansLine.Split(',');

                AnsList.AddRange(ansValues);
            }

            // 「'」がある問題文が正しく表示されるために整形する
            for (int i = 0; i < QList.Count; i++)
            {
                if (QList[i] != string.Empty && QList[i].TrimStart()[0] == '"')
                {
                    // もう一回ダブルクォーテーションが出てくるまで要素を結合
                    while (QList[i].TrimEnd()[QList[i].TrimEnd().Length - 1] != '"')
                    {
                        QList[i] = QList[i] + "," + QList[i + 1];

                        //結合したら要素を削除する
                        QList.RemoveAt(i + 1);
                    }
                    int strLen = QList[i].Length;

                    QList[i] = QList[i].Substring(3, strLen - 6);
                }
            }
            // 解答用
            for (int i = 0; i < AnsList.Count; i++)
            {
                if (AnsList[i] != string.Empty && AnsList[i].TrimStart()[0] == '"')
                {
                    // もう一回ダブルクォーテーションが出てくるまで要素を結合
                    while (AnsList[i].TrimEnd()[AnsList[i].TrimEnd().Length - 1] != '"')
                    {
                        AnsList[i] = AnsList[i] + "," + AnsList[i + 1];

                        //結合したら要素を削除する
                        AnsList.RemoveAt(i + 1);
                    }
                    int strLen = AnsList[i].Length;

                    AnsList[i] = AnsList[i].Substring(3, strLen - 6);
                }
            }
        }

        // 取得した問題文、選択肢を画面に表示する
        private void display()
        {
            title.Text = year + "年度・" + bunnya;

            Qnum.Text = " 問" + QList[calc(0)];
            monndai.Text = QList[calc(1)];
            selection1.Text = QList[calc(2)];
            selection2.Text = QList[calc(3)];
            selection3.Text = QList[calc(4)];
            selection4.Text = QList[calc(5)];
            selection5.Text = QList[calc(6)];
        }

        // 指定した問題文、選択肢を表示するための引数の計算
        private int calc (int num)
        {
            return QCount * 7 + num;
        }

        // 次の問題文を表示するためにボタンを最有効化、正誤を初期化
        // 最後の問題の場合、リザルト画面に遷移
        private void nextQuestion(object sender, RoutedEventArgs e)
        {
            QCount++;

            try
            {
                // 選択肢ボタンを有効化
                selectButton1.IsEnabled = true;
                selectButton2.IsEnabled = true;
                selectButton3.IsEnabled = true;
                selectButton4.IsEnabled = true;
                selectButton5.IsEnabled = true;

                // 次の問題にいくためのボタンを無効化
                nextQues.IsEnabled = false;
                expButton.IsEnabled = false;


                resText.Text = "";

                display();
            }
            catch (ArgumentOutOfRangeException)
            {
                // リザルトに移動させる
                var result = new ResultWindow(year, bunnya, QCount, rightCount, resList, QList, AnsList);
                NavigationService.Navigate(result);
            }
        }

        // 別のボタンを押せないようにし、正誤判定、画面に表示する
        private void selectAns(object sender, RoutedEventArgs e)
        {
            // 選択肢ボタンの無効化
            selectButton1.IsEnabled = false;
            selectButton2.IsEnabled = false;
            selectButton3.IsEnabled = false;
            selectButton4.IsEnabled = false;
            selectButton5.IsEnabled = false;

            // 次の問題に行くためのボタンを有効化
            nextQues.IsEnabled = true;
            expButton.IsEnabled = true;
            
            // 選択された選択肢を取得
            Button btn = (Button)sender;
            string select = btn.Content.ToString();
            select = select.Substring(1, 1);

            string ans = AnsList[QCount * 3 + 1];

            // 正誤判定
            if (ans.Length == 1)
            {
                if (select.Equals(ans))
                {
                    rightCount++;
                    resText.Text = "正解";
                    resList.Add("○");
                }else
                {
                    resText.Text = "不正解";
                    resList.Add("×");
                }
            }else
            {
                string ans1 = ans.Substring(0, 1);
                string ans2 = ans.Substring(4);
                if (select.Equals(ans1) || select.Equals(ans2))
                {
                    rightCount++;
                    resText.Text = "正解";
                    resList.Add("○");
                }else
                {
                    resText.Text = "不正解";
                    resList.Add("×");
                }
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var SelectMain = new SelectMain();
            NavigationService.Navigate(SelectMain);
        }

        private void dispExp(object sender, RoutedEventArgs e)
        {
            var Explanation = new Explanation(year, bunnya, QCount, AnsList);
            NavigationService.Navigate(Explanation);
        }
    }
}

