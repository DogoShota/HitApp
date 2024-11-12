﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    /// Medical_Q.xaml の相互作用ロジック
    /// </summary>
    public partial class Question : Page
    {
        // 問題分、選択肢を格納するリスト
        List<string> AnsList = new List<string>();
        // 解答を格納するリスト
        List<string> QList = new List<string>();
        // 解いている問題が何問目か(0が一問目)
        int QCount = 0;
        // 正解数
        int rightCount = 0;

        public Question(string year, string bunnya)
        {
            InitializeComponent();
            title.Text = year + "年度・" + bunnya;

            getQuestionText();
            getQustionAnswer();
            display();
        }

        // csvから問題を取得して、リストに格納する
        private void getQuestionText ()
        {
            StreamReader csv = new StreamReader(@"../../csv/2019JS.csv");

            csv.ReadLine();// 一行とばす

            // リストに格納
            while (!csv.EndOfStream)
            {
                string line = csv.ReadLine();
                string[] values = line.Split(',');

                QList.AddRange(values);
            }

            for ( int i = 0; i < QList.Count; i++ )
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

                    QList[i] = QList[i].Substring(3, strLen-6);
                }
            }
        }

        // csvから正解を取得して、リストに格納する
        private void getQustionAnswer()
        {
            StreamReader ansCsv = new StreamReader(@"../../csv/2019JS_ans.csv");

            ansCsv.ReadLine();// 一行飛ばす
            
            // リストに格納
            while (!ansCsv.EndOfStream)
            {
                string line = ansCsv.ReadLine();
                string[] values = line.Split(',');

                AnsList.AddRange(values);
            }
        }

        // 取得した問題文、選択肢を画面に表示する
        private void display()
        {
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

                resText.Text = "";

                display();
            }
            catch (ArgumentOutOfRangeException err)
            {
                // リザルトに移動させる
                var result = new ResultWindow();
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
            
            // 選択された選択肢を取得
            Button btn = (Button)sender;
            string select = btn.Content.ToString();
            select = select.Substring(1, 1);

            string ans = AnsList[QCount * 3 + 1];

            // 正誤判定
            if (select.Equals(ans))
            {
                rightCount++;
                resText.Text = "正解";
            }else
            {
                resText.Text = "不正解";
            }
        }
    }
}

