using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace TT.Sim
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

        public List<MarketOHLC> Get1MinuteCandles()
        {
            throw new NotImplementedException();
        }

        public List<MarketOHLC> Get5MinuteCandles()
        {
            throw new NotImplementedException();
        }

        public List<MarketOHLC> Get15MinuteCandles()
        {
            throw new NotImplementedException();
        }

        public List<MarketOHLC> Get30MinuteCandles()
        {
            throw new NotImplementedException();
        }

        public List<MarketOHLC> Get1HourCandles()
        {
            throw new NotImplementedException();
        }

        public List<MarketOHLC> Get4HourCandles()
        {
            throw new NotImplementedException();
        }

        public List<MarketOHLC> GetDailyCandles()
        {
            throw new NotImplementedException();
        }

        public List<MarketOHLC> GetWeeklyCandles()
        {
            throw new NotImplementedException();
        }

        public List<MarketOHLC> GetMonthlyCandles()
        {
            throw new NotImplementedException();
        }
    }
}