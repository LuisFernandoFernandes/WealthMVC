public class QuoteResponse
{
    public List<Result> result { get; set; }
    public object error { get; set; }
}

public class Result
{
    public string language { get; set; }
    public string region { get; set; }
    public string quoteType { get; set; }
    public string typeDisp { get; set; }
    public string quoteSourceName { get; set; }
    public bool triggerable { get; set; }
    public string customPriceAlertConfidence { get; set; }
    public string currency { get; set; }
    public string marketState { get; set; }
    public double epsCurrentYear { get; set; }
    public double priceEpsCurrentYear { get; set; }
    public object sharesOutstanding { get; set; }
    public double bookValue { get; set; }
    public double fiftyDayAverage { get; set; }
    public double fiftyDayAverageChange { get; set; }
    public double fiftyDayAverageChangePercent { get; set; }
    public double twoHundredDayAverage { get; set; }
    public double twoHundredDayAverageChange { get; set; }
    public double twoHundredDayAverageChangePercent { get; set; }
    public object marketCap { get; set; }
    public double forwardPE { get; set; }
    public double priceToBook { get; set; }
    public int sourceInterval { get; set; }
    public int exchangeDataDelayedBy { get; set; }
    public double pageViewGrowthWeekly { get; set; }
    public string averageAnalystRating { get; set; }
    public bool tradeable { get; set; }
    public string exchange { get; set; }
    public string shortName { get; set; }
    public string longName { get; set; }
    public string messageBoardId { get; set; }
    public string exchangeTimezoneName { get; set; }
    public string exchangeTimezoneShortName { get; set; }
    public int gmtOffSetMilliseconds { get; set; }
    public string market { get; set; }
    public bool esgPopulated { get; set; }
    public object firstTradeDateMilliseconds { get; set; }
    public int priceHint { get; set; }
    public double postMarketChangePercent { get; set; }
    public int postMarketTime { get; set; }
    public double postMarketPrice { get; set; }
    public double postMarketChange { get; set; }
    public double regularMarketChange { get; set; }
    public double regularMarketChangePercent { get; set; }
    public int regularMarketTime { get; set; }
    public double regularMarketPrice { get; set; }
    public double regularMarketDayHigh { get; set; }
    public string regularMarketDayRange { get; set; }
    public double regularMarketDayLow { get; set; }
    public int regularMarketVolume { get; set; }
    public double regularMarketPreviousClose { get; set; }
    public double bid { get; set; }
    public double ask { get; set; }
    public int bidSize { get; set; }
    public int askSize { get; set; }
    public string fullExchangeName { get; set; }
    public string financialCurrency { get; set; }
    public double regularMarketOpen { get; set; }
    public int averageDailyVolume3Month { get; set; }
    public int averageDailyVolume10Day { get; set; }
    public double fiftyTwoWeekLowChange { get; set; }
    public double fiftyTwoWeekLowChangePercent { get; set; }
    public string fiftyTwoWeekRange { get; set; }
    public double fiftyTwoWeekHighChange { get; set; }
    public double fiftyTwoWeekHighChangePercent { get; set; }
    public double fiftyTwoWeekLow { get; set; }
    public double fiftyTwoWeekHigh { get; set; }
    public int dividendDate { get; set; }
    public int earningsTimestamp { get; set; }
    public int earningsTimestampStart { get; set; }
    public int earningsTimestampEnd { get; set; }
    public double trailingAnnualDividendRate { get; set; }
    public double trailingPE { get; set; }
    public double trailingAnnualDividendYield { get; set; }
    public double epsTrailingTwelveMonths { get; set; }
    public double epsForward { get; set; }
    public string displayName { get; set; }
    public string symbol { get; set; }
    public double? ytdReturn { get; set; }
    public double? trailingThreeMonthReturns { get; set; }
    public double? trailingThreeMonthNavReturns { get; set; }
}

public class Root
{
    public QuoteResponse quoteResponse { get; set; }
}















//using Newtonsoft.Json;

//namespace WealthMVC.Models
//{
//    public class QuoteResponse
//    {
//        public Quote Quote { get; set; }
//    }

//    public class Quote
//    {
//        public QuoteResult[] Result { get; set; }
//    }

//    public class QuoteResult
//    {

//        public QuoteData QuoteData { get; set; }
//    }

//    public class QuoteData
//    {

//        [JsonProperty("symbol")]
//        public string Symbol { get; set; }

//        [JsonProperty("regularMarketPrice")]
//        public string RegularMarketPrice { get; set; }

//        [JsonProperty("fullExchangeName")]
//        public string FullExchangeName { get; set; }

//        //[JsonProperty("ask")]
//        //public string Ask { get; set; }

//        //[JsonProperty("askSize")]
//        //public string AskSize { get; set; }

//        //[JsonProperty("Bid")]
//        //public string Bid { get; set; }

//        //[JsonProperty("bidSize")]
//        //public string BidSize { get; set; }

//        //[JsonProperty("currency")]
//        //public string Currency { get; set; }


//        //[JsonProperty("quoteType")]
//        //public string QuoteType { get; set; }

//        //[JsonProperty("region")]
//        //public string Region { get; set; }

//        //[JsonProperty("language")]
//        //public string Language { get; set; }

//        #region Dados Retornados
//        //USADOS
//        //"ask": 117.27,
//        //"askSize": 8,
//        //"bid": 117.25,
//        //"bidSize": 22,
//        //"currency": "USD",
//        //"fullExchangeName": "NasdaqGS",
//        //"regularMarketPrice": 117.32,
//        //"symbol": "AAPL",
//        //"quoteType": "EQUITY",
//        //"region": "US",
//        //"language": "en-US",

//        //NÃO USADOS
//        //"averageDailyVolume10Day": 233119800,
//        //"averageDailyVolume3Month": 170533131,
//        //"bookValue": 4.218,
//        //"displayName": "Apple",
//        //"dividendDate": 1597276800,
//        //"earningsTimestamp": 1596126600,
//        //"earningsTimestampEnd": 1604318400,
//        //"earningsTimestampStart": 1603882740,
//        //"epsCurrentYear": 3.23,
//        //"epsForward": 3.86,
//        //"epsTrailingTwelveMonths": 3.296,
//        //"esgPopulated": false,
//        //"exchange": "NMS",
//        //"exchangeDataDelayedBy": 0,
//        //"exchangeTimezoneName": "America/New_York",
//        //"exchangeTimezoneShortName": "EDT",
//        //"fiftyDayAverage": 112.823425,
//        //"fiftyDayAverageChange": 4.4965744,
//        //"fiftyDayAverageChangePercent": 0.03985497,
//        //"fiftyTwoWeekHigh": 137.98,
//        //"fiftyTwoWeekHighChange": -20.659996,
//        //"fiftyTwoWeekHighChangePercent": -0.14973181,
//        //"fiftyTwoWeekLow": 53.1525,
//        //"fiftyTwoWeekLowChange": 64.167496,
//        //"fiftyTwoWeekLowChangePercent": 1.2072338,
//        //"fiftyTwoWeekRange": "53.1525 - 137.98",
//        //"financialCurrency": "USD",
//        //"firstTradeDateMilliseconds": 345479400000,
//        //"forwardPE": 30.393784,
//        //"gmtOffSetMilliseconds": -14400000,
//        //"longName": "Apple Inc.",
//        //"market": "us_market",
//        //"marketCap": 2006465249280,
//        //"marketState": "POST",
//        //"messageBoardId": "finmb_24937",
//        //"postMarketChange": -0.25,
//        //"postMarketChangePercent": -0.2130924,
//        //"postMarketPrice": 117.07,
//        //"postMarketTime": 1599686591,
//        //"priceEpsCurrentYear": 36.32198,
//        //"priceHint": 2,
//        //"priceToBook": 27.81413,
//        //"quoteSourceName": "Nasdaq Real Time Price",
//        //"regularMarketChange": 4.5,
//        //"regularMarketChangePercent": 3.9886546,
//        //"regularMarketDayHigh": 119.14,
//        //"regularMarketDayLow": 115.26,
//        //"regularMarketDayRange": "115.26 - 119.14",
//        //"regularMarketOpen": 117.26,
//        //"regularMarketPreviousClose": 112.82,
//        //"regularMarketTime": 1599681602,
//        //"regularMarketVolume": 168404235,
//        //"sharesOutstanding": 17102499840,
//        //"shortName": "Apple Inc.",
//        //"sourceInterval": 15,
//        //"tradeable": false,
//        //"trailingAnnualDividendRate": 0.782,
//        //"trailingAnnualDividendYield": 0.0069313953,
//        //"trailingPE": 35.59466,
//        //"triggerable": true,
//        //"twoHundredDayAverage": 85.99835,
//        //"twoHundredDayAverageChange": 31.321648,
//        //"twoHundredDayAverageChangePercent": 0.3642122
//        #endregion

//    }
//}

