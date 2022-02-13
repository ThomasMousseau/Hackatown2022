from datetime import date
from pytrends.request import TrendReq
import json

pytrends = TrendReq(hl='en-US', tz=360)

class Trends:

    def GetTrends():
        trend1 = pytrends.trending_searches(pn='united_states')
        trend1 = trend1[0].values.tolist()
        with open(f"./DailyTopics/{date.today()}.json", 'w') as f:
            json.dump(trend1, f)
        # trend1.to_json()

Trends.GetTrends();
    

    



