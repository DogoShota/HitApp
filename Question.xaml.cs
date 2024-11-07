using System;
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
        List<string> QList = new List<string>();
        // 解いている問題が何問目か
        int QCount = 2;
        // 正解数
        int rightCount = 0;

        public Question(string year, string bunnya)
        {
            InitializeComponent();
            title.Text = year + "年度・" + bunnya;

            getText();
            display();
        }

        private void getText ()
        {
            StreamReader csv = new StreamReader(@"../../csv/2019JS.csv");

            csv.ReadLine();// 一行とばす
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

        private int calc (int num)
        {
            return QCount * 7 + num;
        }
    }
}

