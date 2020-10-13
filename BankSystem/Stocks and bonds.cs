using System.Collections;
using System.Collections.Generic;

namespace BankSystem
{
    public class StocksAndBonds : IEnumerable
    {
        public IReadOnlyDictionary <string, InfoStocks> stock = new Dictionary<string, InfoStocks>()
        {
            { "1", new InfoStocks { ID = 1, Current = 360, Name = "AppleInc.", RisePerDay = 3 } },
            { "2", new InfoStocks { ID = 2, Current = 280, Name = "AMD", RisePerDay = 2.8 } },
            { "3", new InfoStocks { ID = 3, Current = 120, Name = "SberBank", RisePerDay = 0.8} },
            { "4", new InfoStocks { ID = 4, Current = 85, Name = "VTB", RisePerDay = 2.2} },
            { "5", new InfoStocks { ID = 5, Current = 290, Name = "Intel Inc.", RisePerDay = 3.2}}
        };

        public class InfoStocks
        {
            public int ID { get; set; }
            public int Current { get; set; }
            public string Name { get; set; }
            public double RisePerDay { get; set; }
        }

        public IEnumerator GetEnumerator()
        {
            return stock.GetEnumerator();
        }
    }
}