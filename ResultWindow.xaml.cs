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
            dataSet();
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
