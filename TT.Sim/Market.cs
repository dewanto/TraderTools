using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace TraderTools
{
    /// <summary>
    /// Stores market history.
    /// </summary>
    public class Market
    {
        public List<MarketOHLC> History { get; }

        public Market(List<MarketOHLC> history)
        {
            History = new List<MarketOHLC>(history);
        }

        public Market(TextReader historyTextReader, String delimiter = ",")
        {
            History = new List<MarketOHLC>();
            using (TextFieldParser parser = new TextFieldParser(historyTextReader))
            {
                parser.SetDelimiters(delimiter);
                while (!parser.EndOfData)
                {
                    String[] fields = parser.ReadFields();
                    String fieldTime = fields[0] + " " + fields[1];
                    DateTime time = DateTime.Parse(fieldTime);
                    decimal open = decimal.Parse(fields[2]);
                    decimal high = decimal.Parse(fields[3]);
                    decimal low = decimal.Parse(fields[4]);
                    decimal close = decimal.Parse(fields[5]);
                    MarketOHLC ohlc = new MarketOHLC(time, open, high, low, close);
                    History.Add(ohlc);
                }
            }
        }
        
        /// <summary>
        /// Inserts a market OHLC, preserving time-ordering.
        /// </summary>
        /// <param name="ohlc"></param>
        public void AddOHLC(MarketOHLC ohlc)
        {
            throw new NotImplementedException();
        }
    }
}