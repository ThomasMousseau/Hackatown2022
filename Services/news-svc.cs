
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System;

public class NewsSvc
{
    private readonly NewsApiClient _newsApiClient;
    public NewsSvc()
    {
        // init with your API key
        _newsApiClient = new NewsApiClient("732b4d63a382437eb0df2bd765cc2712"); 
    }
    

    public Object getTopNews()
    {
        var articlesResponse = _newsApiClient.GetEverything(new EverythingRequest
        {
            Q = "Apple",
            SortBy = SortBys.Popularity,
            Language = Languages.EN,
            From = new DateTime(2018, 1, 25)
        });
        if (articlesResponse.Status != Statuses.Ok)
        {
            // total results found
            Console.WriteLine(articlesResponse.TotalResults);
            // here's the first 20
            foreach (var article in articlesResponse.Articles)
            {
                // title
                Console.WriteLine(article.Title);
                // author
                Console.WriteLine(article.Author);
                // description
                Console.WriteLine(article.Description);
                // url
                Console.WriteLine(article.Url);
                // published at
                Console.WriteLine(article.PublishedAt);
            }
        }
        return new {
            test = "test"
        };
    }
}

   

