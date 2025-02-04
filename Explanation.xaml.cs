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
    /// Explanation.xaml の相互作用ロジック
    /// </summary>
    public partial class Explanation : Page
    {
        string year, bunnya;
        // 表示する問題番号
        int QCount;
        // 問題分、選択肢を格納するリスト
        List<string> AnsList = new List<string>();
        public Explanation(string year, string bunnya, int QCount, List<string> AnsList)
        {
            InitializeComponent();
            this.year = year;
            this.bunnya = bunnya;
            this.QCount = QCount;
            this.AnsList = AnsList;

            display();
        }

        private void display ()
        {
            title.Text = year + "年度・" + bunnya;
            QnumText.Text = "問" + AnsList[QCount * 3];

            ansText.Text = AnsList[QCount * 3 + 1];
            expText.Text = AnsList[QCount * 3 + 2];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
