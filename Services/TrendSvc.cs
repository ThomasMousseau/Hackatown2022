//TWITTER-SVC.CS 
// VA DEVENIR
// GOOGLE_TRENDS-SVC.PY

using System.Collections;
using IronPython.Modules;
using IronPython.Hosting;
using System.Diagnostics;
using Microsoft.Scripting.Hosting;
using Newtonsoft.Json;
using Models;

namespace Services 
{
    public class TrendSvc : ITrendSvc
    {
        public List<string> GetNameTopics()
        {
            DateTime date = DateTime.Now;
            string[] listTopic = new string[]{};

            using (StreamReader file = File.OpenText(@$"./DailyTopics/{date.ToString("yyyy-MM-dd")}.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                listTopic = serializer.Deserialize(file, typeof(string[])) as string[];
            }

            return new List<string>(listTopic);
        }
    }
}