
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System;
//using Models.Articles
using System.Collections;

namespace Services 
{
    public class NewsSvc : INewsSvc
    {
        private readonly NewsApiClient _newsApiClient;
        DateTime today = DateTime.Now;
        public NewsSvc()
        {
            // init with your API key
            _newsApiClient = new NewsApiClient("09b9ea784f2f48aea467361746098963"); 
        }

        public IEnumerable<Models.Article> GetTopNews(string topic)
        {
            IEnumerable<Models.Article> articles = Enumerable.Empty<Models.Article>();

            var articlesResponse = _newsApiClient.GetEverything(new EverythingRequest
            {
                Q = topic,
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                From = today
            });


            if (articlesResponse.Status == Statuses.Ok)
            {
                // total results found
                Console.WriteLine(articlesResponse.TotalResults);
                // here's the first 20
                articles =  articlesResponse.Articles.Select(x => new Models.Article() {
                    publication = x.Source.Name,
                    authorName = x.Author,
                    title = x.Title,
                    thumbnail = x.UrlToImage,
                    link = x.Url,
                    publicationDate = x.PublishedAt,
                    content = x.Content
                });
            }
            else{
                //throw new Exception("L'esti de API key TABARNAK");
                // continue;
            }

            return articles;
        }

        public float l2rCalc() //voir la partie ClientApp pour changer number -> float
        {
            return 0.0f;
        }
    }
}
