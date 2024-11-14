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
    /// Medical_Q.xaml の相互作用ロジック
    /// </summary>
    public partial class Question : Page
    {
        public Question(string year, string bunnya)
        {
            InitializeComponent();
            title.Text = year + "年度・" + bunnya;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var SelectMain = new SelectMain();
            NavigationService.Navigate(SelectMain);
        }
    }
}

