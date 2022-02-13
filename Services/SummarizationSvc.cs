using Azure;
using Interfaces;
using Azure.AI.TextAnalytics;


namespace Services {
    public class SummarizationSvc : ISummarizationSvc
    {
        private readonly AzureKeyCredential credentials;
        private readonly Uri endpoint;
        private readonly TextAnalyticsClient _client;
        public SummarizationSvc() {
            credentials = new AzureKeyCredential("1dde6efad47f443485ec69b357bb68c3");
            endpoint = new Uri("https://hackatown2022.cognitiveservices.azure.com/");
            _client = new TextAnalyticsClient(endpoint, credentials);
        }
        // public async Task<string> GetSummary(string content)
        public string GetSummary(string content)
        {
            // var batchInput = new List<string>
            // {
            //     content
            // };
        
            // TextAnalyticsActions actions = new TextAnalyticsActions()
            // {
            //     ExtractSummaryActions = new List<ExtractSummaryAction>() { new ExtractSummaryAction() }
            // };

            // AnalyzeActionsOperation operation = await _client.StartAnalyzeActionsAsync(batchInput, actions);
            // await operation.WaitForCompletionAsync();

            // await foreach (AnalyzeActionsResult documentsInPage in operation.Value)
            // {
            //     IReadOnlyCollection<ExtractSummaryActionResult> summaryResults = documentsInPage.ExtractSummaryResults;
        
            //     foreach (ExtractSummaryActionResult summaryActionResults in summaryResults)
            //     {
            //         if (summaryActionResults.HasError)
            //         {
            //             continue;
            //         }
        
            //         foreach (ExtractSummaryResult documentResults in summaryActionResults.DocumentsResults)
            //         {
            //             if (documentResults.HasError)
            //             {
            //                 continue;
            //             }
        
            //             Console.WriteLine($"  Extracted the following {documentResults.Sentences.Count} sentence(s):");
            //             Console.WriteLine();
        
            //             foreach (SummarySentence sentence in documentResults.Sentences)
            //             {
            //                 Console.WriteLine($"  Sentence: {sentence.Text}");
            //                 Console.WriteLine();
            //             }
            //         }
            //     }
            // }
            return "";
        }
    }
}