﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public Stopwatch sw;

        public Config()
        {
            sw = new Stopwatch();
        }

        public void sw_start()
        {
            sw.Start();
        }

        public void sw_stop()
        {
            sw.Stop();
        }

        public Dictionary<string, DateTime> get_test_day()
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
                string schedule_day = "試験日は" + test["testDay"].ToString("yyyy/MM/dd") + "です。";
                string delay_day = "残り" + (delay.Days).ToString() + "日です。";

                text = schedule_day + "\n" + delay_day;
            }

            return text;
        }


    }
}
