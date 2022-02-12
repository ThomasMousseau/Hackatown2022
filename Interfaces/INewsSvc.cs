using Models;

public interface INewsSvc
{
    IEnumerable<Article> GetTopNews(string topic);
}