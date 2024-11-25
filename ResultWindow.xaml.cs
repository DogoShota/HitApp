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
        // 解答を格納するリスト
        List<string> QList = new List<string>();

        public ResultWindow(string year, string bunnya, int QCount, int rightCount,  List<string> resList, List<string> QList, List<string> AnsList)
        {
            InitializeComponent();
            this.year = year;
            this.bunnya = bunnya;
            this.QCount = QCount;
            this.rightCount = rightCount;
            this.resList = resList;
            this.QList = QList;
            this.AnsList = AnsList;

            dataSet();
            calc();

            display();
        }

        // 正解率の計算
        private void calc()
        {
            ansPercentage = (rightCount / QCount) * 100;
        }
        
        // 画面表示
        private void display()
        {
            title.Content = year + "年度・" + bunnya;
            正解率.Content = "正解率：" + ansPercentage.ToString() + "%";
        }

        // 画面の表に表示する内容を設定
        private void dataSet ()
        {
            List<DataGridItems> items = new List<DataGridItems>();

            for (int i = 0; i < resList.Count; i++)
            {
                items.Add(new DataGridItems((i + 1).ToString(), resList[i]));
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
            var QWindow = new Question(year, bunnya);
            NavigationService.Navigate(QWindow);
        }
        private void explanation(object sender, RoutedEventArgs e)
        {
            int Qnum = int.Parse((((Button)sender).Tag as DataGridItems).item0) - 1;

            Explanation exp = new Explanation(year, bunnya, Qnum, AnsList);
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
