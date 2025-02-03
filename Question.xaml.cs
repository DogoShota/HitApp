using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Converters;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;
namespace HitApp
{

    /// <summary>
    /// Question.xaml の相互作用ロジック
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
        // 問題文中の画像を格納する辞書リスト
        Dictionary<string, BitmapImage> ImageList = new Dictionary<string, BitmapImage>();
        // 解いている問題が何問目か(0が一問目)
        int QCount = 0;
        // 問題が何問目まであるか
        int maxQCount;
        // 正解数
        int rightCount = 0;
        // 正誤結果を格納するリスト
        List<string> resList = new List<string>();
        // 選択した選択肢を格納
        List<string> selects = new List<string>();
        // 解答中の問題の正解を格納
        string ans;
        // ランダム出題がどうか
        bool randumMode;
        // ランダム時、月に出題する問題番号を格納
        List<int> rumList = new List<int>();

        public Question(string year, string bunnya, int QCount, int maxQCount, bool randumMode = false)
        {
            InitializeComponent();
            this.year = year;
            this.bunnya = bunnya;
            this.QCount = QCount - 1;
            this.maxQCount = maxQCount;
            this.randumMode = randumMode;

            if (randumMode)
            {
                randumQuestion();
            }

            getQuestionText();
            getQuestionImage();
            display();

        }

        // csvから問題と正解を取得して、リストに格納する
        private void getQuestionText()
        {
            // 選択された年度、分野のcsvを取得する
            switch (year)
            {
                case "2023":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"csv/2023/2023JS.csv");
                            ansCsv = new StreamReader(@"csv/2023/2023JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"csv/2023/2023IS.csv");
                            ansCsv = new StreamReader(@"csv/2023/2023IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"csv/2023/2023II.csv");
                            ansCsv = new StreamReader(@"csv/2023/2023II.解説.csv");
                            break;
                    }
                    break;

                case "2022":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"csv/2022/2022JS.csv");
                            ansCsv = new StreamReader(@"csv/2022/2022JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"csv/2022/2022IS.csv");
                            ansCsv = new StreamReader(@"csv/2022/2022IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"csv/2022/2022II.csv");
                            ansCsv = new StreamReader(@"csv/2022/2022II.解説.csv");
                            break;
                    }
                    break;

                case "2021":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"csv/2021/2021JS.csv");
                            ansCsv = new StreamReader(@"csv/2021/2021JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"csv/2021/2021IS.csv");
                            ansCsv = new StreamReader(@"csv/2021/2021IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"csv/2021/2021II.csv");
                            ansCsv = new StreamReader(@"csv/2021/2021II.解説.csv");
                            break;
                    }
                    break;

                case "2019":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"csv/2019/2019JS.csv");
                            ansCsv = new StreamReader(@"csv/2019/2019JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"csv/2019/2019IS.csv");
                            ansCsv = new StreamReader(@"csv/2019/2019IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"csv/2019/2019II.csv");
                            ansCsv = new StreamReader(@"csv/2019/2019II.解説.csv");
                            break;
                    }
                    break;

                case "2018":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"csv/2018/2018JS.csv");
                            ansCsv = new StreamReader(@"csv/2018/2018JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"csv/2018/2018IS.csv");
                            ansCsv = new StreamReader(@"csv/2018/2018IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"csv/2018/2018II.csv");
                            ansCsv = new StreamReader(@"csv/2018/2018II.解説.csv");
                            break;
                    }
                    break;

                case "2017":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"csv/2017/2017JS.csv");
                            ansCsv = new StreamReader(@"csv/2017/2017JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"csv/2017/2017IS.csv");
                            ansCsv = new StreamReader(@"csv/2017/2017IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"csv/2017/2017II.csv");
                            ansCsv = new StreamReader(@"csv/2017/2017II.解説.csv");
                            break;
                    }
                    break;

                case "2016":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"csv/2016/2016JS.csv");
                            ansCsv = new StreamReader(@"csv/2016/2016JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"csv/2016/2016IS.csv");
                            ansCsv = new StreamReader(@"csv/2016/2016IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"csv/2016/2016II.csv");
                            ansCsv = new StreamReader(@"csv/2016/2016II.解説.csv");
                            break;
                    }
                    break;

                case "2015":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"csv/2015/2015JS.csv");
                            ansCsv = new StreamReader(@"csv/2015/2015JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"csv/2015/2015IS.csv");
                            ansCsv = new StreamReader(@"csv/2015/2015IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"csv/2015/2015II.csv");
                            ansCsv = new StreamReader(@"csv/2015/2015II.解説.csv");
                            break;
                    }
                    break;

                case "2014":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"csv/2014/2014JS.csv");
                            ansCsv = new StreamReader(@"csv/2014/2014JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"csv/2014/2014IS.csv");
                            ansCsv = new StreamReader(@"csv/2014/2014IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"csv/2014/2014II.csv");
                            ansCsv = new StreamReader(@"csv/2014/2014II.解説.csv");
                            break;
                    }
                    break;

                case "2013":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"csv/2013/2013JS.csv");
                            ansCsv = new StreamReader(@"csv/2013/2013JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"csv/2013/2013IS.csv");
                            ansCsv = new StreamReader(@"csv/2013/2013IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"csv/2013/2013II.csv");
                            ansCsv = new StreamReader(@"csv/2013/2013II.解説.csv");
                            break;
                    }
                    break;

                case "2012":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"csv/2012/2012JS.csv");
                            ansCsv = new StreamReader(@"csv/2012/2012JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"csv/2012/2012IS.csv");
                            ansCsv = new StreamReader(@"csv/2012/2012IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"csv/2012/2012II.csv");
                            ansCsv = new StreamReader(@"csv/2012/2012II.解説.csv");
                            break;
                    }
                    break;

                case "2011":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"csv/2011/2011JS.csv");
                            ansCsv = new StreamReader(@"csv/2011/2011JS.解説.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"csv/2011/2011IS.csv");
                            ansCsv = new StreamReader(@"csv/2011/2011IS.解説.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"csv/2011/2011II.csv");
                            ansCsv = new StreamReader(@"csv/2011/2011II.解説.csv");
                            break;
                    }
                    break;

                case "2010":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"csv/2010/2010JS.csv");
                            ansCsv = new StreamReader(@"csv/2010/2010JS.解答.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"csv/2010/2010IS.csv");
                            ansCsv = new StreamReader(@"csv/2010/2010IS.解答.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"csv/2010/2010II.csv");
                            ansCsv = new StreamReader(@"csv/2010/2010II.解答.csv");
                            break;
                    }
                    break;

                case "2009":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"csv/2009/2009JS.csv");
                            ansCsv = new StreamReader(@"csv/2009/2009JS.解答.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"csv/2009/2009IS.csv");
                            ansCsv = new StreamReader(@"csv/2009/2009IS.解答.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"csv/2009/2009II.csv");
                            ansCsv = new StreamReader(@"csv/2009/2009II.解答.csv");
                            break;
                    }
                    break;

                case "2008":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"csv/2008/2008JS.csv");
                            ansCsv = new StreamReader(@"csv/2008/2008JS.解答.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"csv/2008/2008IS.csv");
                            ansCsv = new StreamReader(@"csv/2008/2008IS.解答.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"csv/2008/2008II.csv");
                            ansCsv = new StreamReader(@"csv/2008/2008II.解答.csv");
                            break;
                    }
                    break;

                case "2007":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"csv/2007/2007JS.csv");
                            ansCsv = new StreamReader(@"csv/2007/2007JS.解答.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"csv/2007/2007IS.csv");
                            ansCsv = new StreamReader(@"csv/2007/2007IS.解答.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"csv/2007/2007II.csv");
                            ansCsv = new StreamReader(@"csv/2007/2007II.解答.csv");
                            break;
                    }
                    break;

                case "2006":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"csv/2006/2006JS.csv");
                            ansCsv = new StreamReader(@"csv/2006/2006JS.解答.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"csv/2006/2006IS.csv");
                            ansCsv = new StreamReader(@"csv/2006/2006IS.解答.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"csv/2006/2006II.csv");
                            ansCsv = new StreamReader(@"csv/2006/2006II.解答.csv");
                            break;
                    }
                    break;

                case "2005":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"csv/2005/2005JS.csv");
                            ansCsv = new StreamReader(@"csv/2005/2005JS.解答.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"csv/2005/2005IS.csv");
                            ansCsv = new StreamReader(@"csv/2005/2005IS.解答.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"csv/2005/2005II.csv");
                            ansCsv = new StreamReader(@"csv/2005/2005II.解答.csv");
                            break;
                    }
                    break;

                case "2004":
                    switch (bunnya)
                    {
                        case "情報処理技術系":
                            csv = new StreamReader(@"csv/2004/2004JS.csv");
                            ansCsv = new StreamReader(@"csv/2004/2004JS.解答.csv");
                            break;

                        case "医療情報システム系":
                            csv = new StreamReader(@"csv/2004/2004IS.csv");
                            ansCsv = new StreamReader(@"csv/2004/2004IS.解答.csv");
                            break;

                        case "医学・医療系":
                            csv = new StreamReader(@"csv/2004/2004II.csv");
                            ansCsv = new StreamReader(@"csv/2004/2004II.解答.csv");
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

        private void getQuestionImage()
        {
            // 画像ファイルのパス一覧を取得
            string[] paths = Directory.GetFiles(@"image", "*", SearchOption.AllDirectories);

            // 辞書型にパス名をキー、BitMapImageをバリューに設定
            foreach (string path in paths)
            {
                ImageList.Add(path.Substring(path.Length - 14), new BitmapImage(new Uri(path, UriKind.Relative)));
            }
        }

        // 取得した問題文、選択肢を画面に表示する
        private void display()
        {
            // 正解を取得
            ans = AnsList[QCount * 3 + 1];

            title.Text = year + "年度・" + bunnya;

            Qnum.Text = " 問" + QList[calc(0)];
            monndai.Text = QList[calc(1)];
            selection1.Text = QList[calc(2)];
            selection2.Text = QList[calc(3)];
            selection3.Text = QList[calc(4)];
            selection4.Text = QList[calc(5)];
            selection5.Text = QList[calc(6)];

            QcountNow.Content = (QCount + 1) + "/" + maxQCount;

            yourAns.Text = "";
            resText.Foreground = Brushes.Black;

            // 削除問題の時、次の問題にいく操作だけできるようにする
            if (monndai.Text.Equals("削除"))
            {
                // 選択肢ボタンの無効化
                selectButton1.IsEnabled = false;
                selectButton2.IsEnabled = false;
                selectButton3.IsEnabled = false;
                selectButton4.IsEnabled = false;
                selectButton5.IsEnabled = false;
                finalAnsButton.IsEnabled = false;


                nextQues.IsEnabled = true;
                expButton.IsEnabled = false;

            }
            finalAnsButton.IsEnabled = false;

            // 画像表示
            string tes = "";
            switch (bunnya)
            {
                case "情報処理技術系":
                    tes = "JS";
                    break;
                case "医療情報システム系":
                    tes = "IS";
                    break;
                case "医学・医療系":
                    tes = "II";
                    break;
            }
            try// 画像がある時
            {
                if (int.Parse(QList[calc(0)]) < 10) // 問題番号が一桁のとき
                {
                    Qimage.Source = ImageList[@"\" + year + tes + ".Q" + QList[calc(0)].ToString() + ".png"];
                }
                else // 問題番号が二桁のとき
                {
                    Qimage.Source = ImageList[year + tes + ".Q" + QList[calc(0)].ToString() + ".png"];
                }

            }
            catch// 画像がないとき
            {
                Qimage.Source = null;
            }

        }

        // 指定した問題文、選択肢を表示するための引数の計算
        private int calc(int num)
        {
            int res = QCount * 7 + num;
            if (randumMode)
            {
                res = rumList[QCount] * 7 + num;
            }
            return res;
        }

        // ランダムモードのとき、次の問題を選択する
        private void randumQuestion()
        {

            // 連番のリストを作成
            for (int i = 0; i < maxQCount; i++)
            {
                rumList.Add(i);
            }

            // 連番をランダムに並べ替え
            // リストlistをシャッフルする (for降順ランダム取り)
            Random rnd = new Random();
            for (int i = rumList.Count - 1; i > 0; i--)
            {
                var j = rnd.Next(0, i + 1); // ランダムで要素番号を１つ選ぶ（ランダム要素）
                var temp = rumList[i]; // 一番最後の要素を仮確保（temp）にいれる
                rumList[i] = rumList[j]; // ランダム要素を一番最後にいれる
                rumList[j] = temp; // 仮確保を元ランダム要素に上書き
            }

        }

        // 次の問題文を表示するためにボタンを最有効化、正誤を初期化
        // 最後の問題の場合、リザルト画面に遷移
        private void nextQuestion(object sender, RoutedEventArgs e)
        {
            QCount++;

            // リザルトに移動させる
            if (QCount == maxQCount)
            {
                ResultWindow resWindow;
                if (randumMode)
                {
                    resWindow = new ResultWindow(year, bunnya, QCount, rightCount, resList, AnsList, randumMode, rumList);
                }
                else
                {
                    resWindow = new ResultWindow(year, bunnya, QCount, rightCount, resList, AnsList);

                }
                NavigationService.Navigate(resWindow);
            }
            else
            {
                // 選択肢ボタンを有効化
                selectButton1.IsEnabled = true;
                selectButton2.IsEnabled = true;
                selectButton3.IsEnabled = true;
                selectButton4.IsEnabled = true;
                selectButton5.IsEnabled = true;
                finalAnsButton.IsEnabled = true;

                // 次の問題にいくためのボタンを無効化
                nextQues.IsEnabled = false;
                expButton.IsEnabled = false;

                resText.Content = "";
                yourAns.Text = "";

                selectButton1.IsChecked = false;
                selectButton2.IsChecked = false;
                selectButton3.IsChecked = false;
                selectButton4.IsChecked = false;
                selectButton5.IsChecked = false;

                selects.Clear();
                display();
            }

        }

        // 別のボタンを押せないようにし、正誤判定、画面に表示する
        private void selectAns(object sender, RoutedEventArgs e)
        {
            // 選択された選択肢を取得
            ToggleButton btn = (ToggleButton)sender;

            if (ans.Length == 1)// 解答がひとつ
            {
                selectButton1.IsChecked = false;
                selectButton2.IsChecked = false;
                selectButton3.IsChecked = false;
                selectButton4.IsChecked = false;
                selectButton5.IsChecked = false;

                btn.IsChecked = true;
            }
            else// 解答がふたつ
            {
                // 既に選択されている数を計算
                int selectCount = 0;
                if ((bool)selectButton1.IsChecked)
                    selectCount++;
                if ((bool)selectButton2.IsChecked)
                    selectCount++;
                if ((bool)selectButton3.IsChecked)
                    selectCount++;
                if ((bool)selectButton4.IsChecked)
                    selectCount++;
                if ((bool)selectButton5.IsChecked)
                    selectCount++;

                if (selectCount > 2)// ふたつ選ばれてたら
                {
                    btn.IsChecked = false;
                }
            }


            finalAnsButton.IsEnabled = true;
        }

        private void finalAns(object sender, RoutedEventArgs e)
        {
            // 選択肢ボタンの無効化
            selectButton1.IsEnabled = false;
            selectButton2.IsEnabled = false;
            selectButton3.IsEnabled = false;
            selectButton4.IsEnabled = false;
            selectButton5.IsEnabled = false;
            finalAnsButton.IsEnabled = false;

            // 次の問題に行くためのボタンを有効化
            nextQues.IsEnabled = true;
            expButton.IsEnabled = true;

            // 選んだ選択肢をリストに格納
            if ((bool)selectButton1.IsChecked)
                selects.Add("1");
            if ((bool)selectButton2.IsChecked)
                selects.Add("2");
            if ((bool)selectButton3.IsChecked)
                selects.Add("3");
            if ((bool)selectButton4.IsChecked)
                selects.Add("4");
            if ((bool)selectButton5.IsChecked)
                selects.Add("5");

            // 選んだ解答を表示
            string selectAns = selects[0];
            for (int i = 1; i < selects.Count; i++)
            {
                selectAns += ", " + selects[i];
            }
            yourAns.Text = selectAns;

            // 正誤判定
            if (ans.Length == 3)// 複数回答
            {
                string ans1 = ans.Substring(0, 1);
                string ans2 = ans.Substring(2);

                if (selects.Contains(ans1) && selects.Contains(ans2))
                {
                    rightCount++;
                    resText.Content = "正解";
                    resText.Foreground = Brushes.Lime;
                    resList.Add("○");
                }
                else
                {
                    resText.Content = "不正解";
                    resText.Foreground = Brushes.Red;
                    resList.Add("×");
                }
            }
            else if (ans.Length == 1)
            {
                if (selects.Contains(ans))
                {
                    rightCount++;
                    resText.Content = "正解";
                    resText.Foreground = Brushes.Lime;
                    resList.Add("○");
                }
                else
                {
                    resText.Content = "不正解";
                    resText.Foreground = Brushes.Red;
                    resList.Add("×");
                }
            }
            else
            {
                string ans1 = ans.Substring(0, 1);
                string ans2 = ans.Substring(4);
                if (selects.Contains(ans1) || selects.Contains(ans2))
                {
                    rightCount++;
                    resText.Content = "正解";
                    resList.Add("○");
                }
                else
                {
                    resText.Content = "不正解";
                    resList.Add("×");
                }
            }
        }

        private void ansDisp(object sender, RoutedEventArgs e)
        {
            // 選択肢ボタンの無効化
            selectButton1.IsEnabled = false;
            selectButton2.IsEnabled = false;
            selectButton3.IsEnabled = false;
            selectButton4.IsEnabled = false;
            selectButton5.IsEnabled = false;
            finalAnsButton.IsEnabled = false;

            // 次の問題に行くためのボタンを有効化
            nextQues.IsEnabled = true;
            expButton.IsEnabled = true;

            resText.Content = ans;
            resList.Add("×");
        }

        private void backStart(object sender, RoutedEventArgs e)
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

        private void dispExp(object sender, RoutedEventArgs e)
        {
            Explanation expWindow;
            if (randumMode)
                expWindow = new Explanation(year, bunnya, rumList[QCount], AnsList);
            else
                expWindow = new Explanation(year, bunnya, QCount, AnsList);
            NavigationService.Navigate(expWindow);
        }
    }
}

