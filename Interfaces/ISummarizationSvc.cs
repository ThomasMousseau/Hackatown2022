namespace Interfaces {
    public interface ISummarizationSvc {
        Task<string[]> GetSummary(string[] content);

    }
}