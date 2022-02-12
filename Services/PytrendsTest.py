from pytrends import TrendReq

pytrends = TrendReq(hl='en-US', tz=360)

class Trends:

    def ValuesToArray(value):
            trendList = []
            for i in value:
                trendList.append(i[0])
            return trendList

    def GetTrends():
        trend1 = pytrends.trending_searches(pn='united_states')
        trendsArray = Trends.ValuesToArray(trend1.values)
        return trendsArray

    
    



