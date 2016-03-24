using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace TraderTools.Simulator
{
    /// <summary>
    /// Stores market history.
    /// </summary>
    public class Market
    {
        public List<MarketCandle> History { get; }

        public Market(List<MarketCandle> history)
        {
            History = new List<MarketCandle>(history);
        }

        public Market(TextReader historyTextReader, String delimiter = ",")
        {
            History = new List<MarketCandle>();
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
                    MarketCandle candle = new MarketCandle(time, open, high, low, close);
                    History.Add(candle);
                }
            }
        }
        
        /// <summary>
        /// Inserts a market candle, preserving time-ordering.
        /// </summary>
        /// <param name="candle"></param>
        public void Addcandle(MarketCandle candle)
        {
            throw new NotImplementedException();
        }

        public List<MarketCandle> Get1MinuteCandles()
        {
            throw new NotImplementedException();
        }

        public List<MarketCandle> Get5MinuteCandles()
        {
            throw new NotImplementedException();
        }

        public List<MarketCandle> Get15MinuteCandles()
        {
            throw new NotImplementedException();
        }

        public List<MarketCandle> Get30MinuteCandles()
        {
            throw new NotImplementedException();
        }

        public List<MarketCandle> Get1HourCandles()
        {
            throw new NotImplementedException();
        }

        public List<MarketCandle> Get4HourCandles()
        {
            throw new NotImplementedException();
        }

        public List<MarketCandle> GetDailyCandles()
        {
            throw new NotImplementedException();
        }

        public List<MarketCandle> GetWeeklyCandles()
        {
            throw new NotImplementedException();
        }

        public List<MarketCandle> GetMonthlyCandles()
        {
            throw new NotImplementedException();
        }
    }
}