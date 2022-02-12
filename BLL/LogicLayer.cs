using Models;
using Interfaces;

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
        public LogicLayer(INewsSvc newsSvc)
        {
            _newsSvc = newsSvc;
        }

        public List<Topic> GetAllNews()
        {
            var topics = TOPICS; //TODO: fetch from some api

            foreach (Topic t in topics)
            {
                t.articles = _newsSvc.getTopNews(t.title).ToArray();
            }

            return topics;
        }
    }
}