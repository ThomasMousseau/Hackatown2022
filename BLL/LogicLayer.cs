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

        public async Task<List<Topic>> GetAllNews()
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

                // SUMMARIZATION
                var articles = res[i].articles.Select(x => x.content).ToArray();
                // var summaries = await _summarizationSvc.GetSummary(articles);

                // for (int j = 0; j < summaries.Length; j++)
                // for (int j = 0; j < articles.Length; j++)
                // {
                //     res[i].articles[j].summary = @"Paris (AFP) – Portuguese midfielder Xeka scored the only goal as Lille warmed up for their Champions League last 16 clash against Chelsea with a 1-0 success at Montpellier on Saturday as Lyon denied Nice a chance to move second in Ligue 1. Xeka struck with a quarter of an hour to go on the French Riviera as the reigning champions bounced back after last weekend’s humiliating 5-1 home defeat to Ligue 1 leaders Paris Saint-Germain. Nice missed the chance to pull second ahead of Marseille after a 2-0 defeat at Lyon, who move sixth.";
                // }
            }

            return res;
        }

    }
}