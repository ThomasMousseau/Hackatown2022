using Models;
using Interfaces;
using Services;

namespace Logic
{
    public class LogicLayer: ILogicLayer
    {

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
                importance = index + 1,
                articles = new Article[]{} 
            });

            foreach (Topic t in topics)
            {
                t.articles = _newsSvc.GetTopNews(t.title).ToArray();
            }

            var res = topics.OrderBy(x => x.articles?.Length)
            .Reverse()
            .Take(10).ToList();
            
            return res;
        }

    }
}