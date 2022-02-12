from xml.dom.minidom import TypeInfo
from pytrends.request import TrendReq

pytrends = TrendReq(hl='en-US', tz=360)

def GetTrends():
    trend1 = pytrends.trending_searches(pn='united_states')
    trendsArray = ValuesToArray(trend1.values)
    return trendsArray

def ValuesToArray(value):
    trendList = []
    for i in value:
        trendList.append(i[0])
    return trendList
    



