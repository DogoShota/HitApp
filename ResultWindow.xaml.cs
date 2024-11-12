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
        int Qnum;
        // 正解数
        double rightCount;
        // 正解率
        double ansPercentage;
        // 正誤結果を格納するリスト
        List<string> resList = new List<string>();

        public ResultWindow(string year, string bunnya, int Qnum, int rightCount,  List<string> resList)
        {
            InitializeComponent();
            this.year = year;
            this.bunnya = bunnya;
            this.Qnum = Qnum;
            this.rightCount = rightCount;
            this.resList = resList;

            dataSet();
            calc();

            display();
        }

        // 正解率の計算
        private void calc()
        {
            ansPercentage = (rightCount / Qnum) * 100;
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
                items.Add(new DataGridItems((i + 1).ToString(), resList[i], "a"));
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

    }

    public class DataGridItems
    {
        public DataGridItems(string No, string res, string exp)
        {
            this.item0 = No;
            this.item1 = res;
            this.item2 = exp;
        }

        public string item0 { get; set; }
        public string item1 { get; set; }
        public string item2 { get; set; }
    }
}
