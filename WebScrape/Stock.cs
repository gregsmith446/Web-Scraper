using System;
namespace WebScrape
{
    // Declaring the Stock Class
    // This class has many properties: symbol, last price, change, etc.
    public class Stock
    {
        // Defining Stock Class properties
        public string Symbol { get; set; }
        public int LastPrice { get; set; }
        public string Change { get; set; }
        public string ChangePct { get; set; }
        public string Currency { get; set; }
        public string Volume { get; set; }
        public string AvgVolume { get; set; }
        public string MarketCap { get; set; }

        // Construct an array of the properties

        // Put the array into a DB
    }
}