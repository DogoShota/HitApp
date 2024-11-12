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
        //
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
        
        private void display()
        {
            title.Content = year + "年度・" + bunnya;
            正解率.Content = "正解率：" + ansPercentage.ToString() + "%";
        }

        private void dataSet ()
        {
            List<DataGridItems> items = new List<DataGridItems>();
            items.Add(new DataGridItems("0", "○", "222"));
            items.Add(new DataGridItems("1", "○", "ccc"));
            items.Add(new DataGridItems("2", "×", "CCC"));

            DataGridName.ItemsSource = items;

        }
    }

    public class DataGridItems
    {
        public DataGridItems(string item0, string item1, string item2)
        {
            this.item0 = item0;
            this.item1 = item1;
            this.item2 = item2;
        }

        public string item0 { get; set; }
        public string item1 { get; set; }
        public string item2 { get; set; }
    }
}
