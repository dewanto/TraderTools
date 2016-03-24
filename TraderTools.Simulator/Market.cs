using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Linq;

namespace TraderTools.Simulator
{
    /// <summary>
    /// Stores market history.
    /// </summary>
    public class Market
    {
        public List<MarketCandle> History { get; private set; }

        public Market(List<MarketCandle> history)
        {
            History = new List<MarketCandle>(history);
            SortHistory();
        }

        /// <summary>
        /// Constructs a Market object from a CSV file in the following format:
        ///   Date, Time, Open, High, Low, Close
        /// </summary>
        /// <param name="historyTextReader"></param>
        /// <param name="delimiter"></param>
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
            SortHistory();
        }

        public void SortHistory()
        {
            //History = History.OrderBy(o => o.Time).ToList();
            History.Sort((x, y) => x.Time.CompareTo(y.Time));
        }
        
        /// <summary>
        /// Inserts a market candle, preserving time-ordering.
        /// </summary>
        /// <param name="candle"></param>
        public void AddCandle(MarketCandle candle)
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
            var dailyCandles = new List<MarketCandle>();
            var currentCandle = new MarketCandle(History[0]);
            var currentDate = currentCandle.Time.Date;

            for (int i = 0; i < History.Count - 1; i++)
            {
                if (History[i].High > currentCandle.High) currentCandle.High = History[i].High;
                if (History[i].Low < currentCandle.Low) currentCandle.Low = History[i].Low;
                
                if (History[i].Time.Date != currentDate)
                {
                    currentCandle.Close = History[i - 1].Close;
                    dailyCandles.Add(currentCandle);
                    currentCandle = new MarketCandle(History[i]);
                    currentDate = currentCandle.Time.Date;
                }
            }

            currentCandle.Close = History[History.Count - 1].Close;
            dailyCandles.Add(currentCandle);

            return dailyCandles;
        }

        public List<MarketCandle> GetWeeklyCandles()
        {
            throw new NotImplementedException();
        }

        public List<MarketCandle> GetMonthlyCandles()
        {
            var monthlyCandles = new List<MarketCandle>();
            var currentCandle = new MarketCandle(History[0]);
            var currentMonth = currentCandle.Time.Month;
            var currentYear = currentCandle.Time.Year;

            for (int i = 0; i < History.Count - 1; i++)
            {
                if (History[i].High > currentCandle.High) currentCandle.High = History[i].High;
                if (History[i].Low < currentCandle.Low) currentCandle.Low = History[i].Low;
                
                if (History[i].Time.Month != currentMonth || History[i].Time.Year != currentYear)
                {
                    currentCandle.Close = History[i - 1].Close;
                    monthlyCandles.Add(currentCandle);
                    currentCandle = new MarketCandle(History[i]);
                    currentMonth = currentCandle.Time.Month;
                    currentYear = currentCandle.Time.Year;
                }
            }

            currentCandle.Close = History[History.Count - 1].Close;
            monthlyCandles.Add(currentCandle);

            return monthlyCandles;
        }
    }
}