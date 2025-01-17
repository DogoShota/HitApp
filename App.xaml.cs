using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HitApp
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {

        public App ()
        {
            InitializeComponent();
        }

        public static int old_year
        {
            get {  return HitApp.Properties.Settings.Default.old_year; }
        }

        public static int new_year
        {
            get { return HitApp.Properties.Settings.Default.new_year; }
        }
    }
}
