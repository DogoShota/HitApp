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
    }
}
