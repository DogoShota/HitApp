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
        public ResultWindow()
        {
            InitializeComponent();
            test();
        }

        private void test ()
        {
            List<DataGridItems> items = new List<DataGridItems>();
            items.Add(new DataGridItems("000", "111", "222"));
            items.Add(new DataGridItems("aaa", "bbb", "ccc"));
            items.Add(new DataGridItems("AAA", "BBB", "CCC"));

            DataGridName.ItemsSource = items;

        }
    }

    public class DataGridItems
    {
        public DataGridItems(string items0, string items1, string items2)
        {
            this.No = items0;
            this.正解 = items1;
            this.解説 = items2;
        }

        public string No { get; set; }
        public string 正解 { get; set; }
        public string 解説 { get; set; }
    }
}
