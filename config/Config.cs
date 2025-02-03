using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HitApp.config
{
    internal class Config
    {
        private Dictionary<string, DateTime> get_test_day()
        {
            StreamReader raw = new StreamReader(@"config/config.json");
            string json = raw.ReadToEnd();
            Dictionary<string, string> jsonRawData = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

            Dictionary<string, DateTime> jsonData = new Dictionary<string, DateTime>();

            foreach(string key in jsonRawData.Keys)
            {
                jsonData.Add(key, DateTime.Parse(jsonRawData[key]));
            }

            return jsonData;
        }

        public string show_test_day()
        {
            string text;
            Dictionary<string, DateTime> test = get_test_day();

            DateTime today = DateTime.Today;
            if (test["testDay"] < today)
            {
                text = "設定ファイルから\n試験日を\n登録してください。";
            }
            else
            {
                TimeSpan delay = test["testDay"] - today;
                text = "試験まであと\n" + (delay.Days).ToString() + "日";
            }

            return text;
        }
    }
}
