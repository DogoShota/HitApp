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

        public ResultWindow(string year, string bunnya, int QCount, int rightCount,  List<string> resList, List<string> AnsList, bool randumMode=false, List<int> rumList=null)
        {
            InitializeComponent();
            this.year = year;
            this.bunnya = bunnya;
            this.QCount = QCount;
            this.rightCount = rightCount;
            this.resList = resList;
            this.AnsList = AnsList;
            this.randumMode = randumMode;
            this.rumList = rumList;

            dataSet();
            calc();

            display();
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
        }

        // 画面の表に表示する内容を設定
        private void dataSet ()
        {
            List<DataGridItems> items = new List<DataGridItems>();

            int question_count = 50;
            if (this.bunnya.Equals("医療情報システム系"))
                question_count = 60;

            if (randumMode)
            {
                for (int i = 0; i < question_count; i++)
                {
                    items.Add(new DataGridItems((rumList[i] + 1).ToString(), resList[i]));
                }
            }
            else
            {
                int first_question_num = question_count - resList.Count;
                int n = 0;
                for (int i = first_question_num; i < question_count; i++)
                {
                    items.Add(new DataGridItems((i + 1).ToString(), resList[n]));
                    n++;
                }
            }
            DataGridName.ItemsSource = items;
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
            int Qnum = int.Parse((((Button)sender).Tag as DataGridItems).item0);
            Explanation exp = new Explanation(year, bunnya, Qnum-1, AnsList);
            NavigationService.Navigate(exp);
        }
    }

    public class DataGridItems
    {
        public DataGridItems(string No, string res)
        {
            this.item0 = No;
            this.item1 = res;
        }

        public string item0 { get; set; }
        public string item1 { get; set; }
    }
}
