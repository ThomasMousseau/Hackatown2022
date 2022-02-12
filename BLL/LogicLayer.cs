using Models;
using Interfaces;
using Services;

namespace Logic
{
    public class LogicLayer: ILogicLayer
    {
        readonly List<Topic> TOPICS = new List<Topic>(){
            new Topic() {
                title = "Apple",
                importance = 1,
                articles = new Article[] {}
            },
            new Topic() {
                title = "Joe Biden",
                importance = 2,
                articles = new Article[] {}

            },
            new Topic() {
                title = "Joe Rogan",
                importance = 3,
                articles = new Article[] {}
            }
        };

        private readonly INewsSvc _newsSvc;
        private readonly ITrendSvc _trendSvc;
        public LogicLayer(INewsSvc newsSvc, ITrendSvc trendSvc)
        {
            _newsSvc = newsSvc;
            _trendSvc = trendSvc;
        }

        public List<Topic> GetAllNews()
        {
            //var topics = TOPICS; //en vrai on veut que TOPICS soit une liste de string venant de GoogleTrends.Py API
            var topics = _trendSvc.GetNameTopics().Select((x, index) => new Topic(){
                title = x,
                importance = index + 1
            }).Take(10).ToList();

            foreach (Topic t in topics)
            {
                t.articles = _newsSvc.GetTopNews(t.title).ToArray();
            }

            return topics;
        }
    }
}