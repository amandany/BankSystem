using System.Collections;
using System.Collections.Generic;

namespace BankSystem
{
    public class StocksAndBonds : IEnumerable
    {
        public Dictionary<string, InfoStocks> stock = new Dictionary<string, InfoStocks>()
        {
            { "1", new InfoStocks { ID = 1, current = 360, name = "AppleInc.", risePerDay = 3 } },
            { "2", new InfoStocks { ID = 2, current = 280, name = "AMD", risePerDay = 2.8 } },
            { "3", new InfoStocks { ID = 3, current = 120, name = "SberBank", risePerDay = 0.8} },
            { "4", new InfoStocks { ID = 4, current = 85, name = "VTB", risePerDay = 2.2} },
            { "5", new InfoStocks { ID = 5, current = 290, name = "Intel Inc.", risePerDay = 3.2}}
        };

        public class InfoStocks
        {
            public int ID { get; set; }
            public int current { get; set; }
            public string name { get; set; }
            public double risePerDay { get; set; }
        }

        public IEnumerator GetEnumerator()
        {
            return stock.GetEnumerator();
        }
    }
}