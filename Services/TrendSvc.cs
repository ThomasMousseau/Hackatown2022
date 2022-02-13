//TWITTER-SVC.CS 
// VA DEVENIR
// GOOGLE_TRENDS-SVC.PY

using Newtonsoft.Json;
using Tweetinvi;
using Tweetinvi.Parameters.TrendsClient;

namespace Services
{
    public class TrendSvc : ITrendSvc
    {
        // public List<string> GetNameTopics()
        // {
            
        // }

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

        public async Task<Tweetinvi.Models.IGetTrendsAtResult> GetNameTopicsTwitter() //
        {
            var userClient = new TwitterClient("byq6hWkTgVfQkm5tzcQvtuyed", "mENh00UilyJHEnVQUfaNtS9DXTKk0NuwaU2hX0JN9iNSm47N8b", "1351716479645978624-4t0feItzJkxIahntMOU4VOfCIOV2gq", "WmZaSk0KuOfe2nW7T1IJDRDdyxHbOWoJUdn4DvXrkEkl3");

            var worldwideWoeid = 1;
            var trendingSearches =  await userClient.Trends.GetPlaceTrendsAtAsync(new GetTrendsAtParameters(worldwideWoeid));
            return trendingSearches;
        }
    }
}