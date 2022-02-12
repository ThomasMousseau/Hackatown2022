//TWITTER-SVC.CS 
// VA DEVENIR
// GOOGLE_TRENDS-SVC.PY

using IronPython.Hosting;

namespace Services 
{
    public class TrendSvc : ITrendSvc
    {
        public List<string> GetNameTopics()
        {
            List<string> listTopic = new List<string>();   
            //instance of python engine
            var engine = Python.CreateEngine();
            //reading code from file
            var source = engine.CreateScriptSourceFromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PythonSampleIronPython.py"));
            var scope = engine.CreateScope();
            //executing script in scope
            source.Execute(scope);
            var TrendsAPI = scope.GetVariable("Trends");
            //initializing class
            var TrendsCalc = engine.Operations.CreateInstance(TrendsAPI);
            listTopic = TrendsCalc
            return listTopic;
        }
    }
}