using System;
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
        int QCount = 0;
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
        }

        private void display()
        {
            Qnum.Text = " 問" + QList[0];
            monndai.Text = QList[1];
            selection1.Text = QList[2];
            selection2.Text = QList[3];
            selection3.Text = QList[4];
            selection4.Text = QList[5];
            selection5.Text = QList[6];
        }
    }
}

