using Models;

public interface INewsSvc
{
    IEnumerable<Article> getTopNews(string topic);
}