using Models;
using Interfaces;
using Services;

namespace Logic
{
    public class LogicLayer: ILogicLayer
    {

        private readonly INewsSvc _newsSvc;
        private readonly ITrendSvc _trendSvc;
        private readonly ISummarizationSvc _summarizationSvc;
        public LogicLayer(INewsSvc newsSvc, ITrendSvc trendSvc, ISummarizationSvc summarizationSvc)
        {
            _newsSvc = newsSvc;
            _trendSvc = trendSvc;
            _summarizationSvc = summarizationSvc;
        }

        public List<Topic> GetAllNews()
        {
            //var topics = TOPICS; //en vrai on veut que TOPICS soit une liste de string venant de GoogleTrends.Py API
            var topics = _trendSvc.GetNameTopics().Select((x) => new Topic(){
                title = x,
                importance = 1
            })
            .ToList();

            var s = _trendSvc.GetNameTopicsTwitter().Result.Trends;
            List<Topic> list = s.Select(x => new Topic()
            {
                title = x.Name,
                importance = 1,
            }).ToList();

            var allTopics = topics.Concat(list).DistinctBy(x => x.title);

            foreach (Topic t in allTopics)
            {
                t.articles = _newsSvc.GetTopNews(t.title).Where(x => x.publication != "Yahoo Entertainment" && x.publication != "Hoops Hype").ToArray();
            }

            var res = allTopics
            .OrderBy(x => x.articles?.Length)
            .Reverse()
            .Take(10)
            .ToList();

            for (int i = 0; i < res.Count; i++)
            {
                res[i].importance = i + 1;
            }

            return res;
        }

    }
}