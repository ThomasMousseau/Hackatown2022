
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
        public NewsSvc()
        {
            // init with your API key
            _newsApiClient = new NewsApiClient("732b4d63a382437eb0df2bd765cc2712"); 
        }

        public IEnumerable<Models.Article> getTopNews(string topic)
        {
            IEnumerable<Models.Article> articles = Enumerable.Empty<Models.Article>();

            var articlesResponse = _newsApiClient.GetEverything(new EverythingRequest
            {
                Q = topic,
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                From = new DateTime(2022, 2, 11)
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
                    publicationDate = x.PublishedAt
                });
            }

            return articles;
        }

        public float l2rCalc() //voir la partie ClientApp pour changer number -> float
        {
            return 0.0f;
        }
    }
}
