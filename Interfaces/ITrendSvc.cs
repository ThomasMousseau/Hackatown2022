using Models;

public interface ITrendSvc
{
    List<string> GetNameTopics();
    Task<Tweetinvi.Models.IGetTrendsAtResult> GetNameTopicsTwitter();
    //List<string> GetNameTopicsPytrends();
}