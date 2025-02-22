﻿using HitApp.config;
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
    /// MedicalMain.xaml の相互作用ロジック
    /// </summary>
    public partial class MedicalMain : Page
    {
        string year, bunnya;
        public MedicalMain(string year, string bunnya)
        {
            InitializeComponent();
            this.year = year;
            this.bunnya = bunnya;

            display();
        }

        private void display()
        {
            title.Text = year + "年度・" + bunnya;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectMain = new SelectMain();
            NavigationService.Navigate(selectMain);
        }

        private void selectButton(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Name.Equals("randum"))
            {
                var randumWindow = new Question(this.year, this.bunnya, 1, true);
                NavigationService.Navigate(randumWindow);
            }
            else
            {
                string Qnum = btn.Name.ToString().Substring(1);

                int intQnum = int.Parse(Qnum);
                var QWindow = new Question(this.year, this.bunnya, intQnum);
                NavigationService.Navigate(QWindow);
            }
        }

    }
}
