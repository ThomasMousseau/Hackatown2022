//using DeepAI;
using Interfaces;

namespace Services {
    public class SummarizationSvc : ISummarizationSvc
    {
        //DeepAI_API api;
        public SummarizationSvc() {
            //api = new DeepAI_API(apiKey: "1eb17c59-d463-4e0d-8932-b68d21c4b003");
        }
        public string GetSummary(string content)
        {
            //StandardApiResponse resp = api.callStandardApi("summarization", new {
            //  text = content,
            // });
            //return api.objectAsJsonString(resp);
            return string.Empty;
        }
    }
}