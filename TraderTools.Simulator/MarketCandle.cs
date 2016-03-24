using System;

namespace TraderTools.Simulator
{
    /// <summary>
    /// A price "candle" with OHLC (open, high, low, close) data over a period of time.
    /// </summary>
    public class MarketCandle
    {
        public DateTime Time { get; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }

        public MarketCandle(MarketCandle candle)
        {
            Time = candle.Time;
            Open = candle.Open;
            High = candle.High;
            Low = candle.Low;
            Close = candle.Close;
        }

        public MarketCandle(DateTime time, decimal open, decimal high, decimal low, decimal close)
        {
            Time = time;
            Open = open;
            High = high;
            Low = low;
            Close = close;
        }

        public bool IsBullish()
        {
            return Close > Open;
        }

        public bool IsBearish()
        {
            return Close < Open;
        }

        public override string ToString()
        {
           return String.Format("MarketCandle: {0}, {1:.00000}, {2:.00000}, {3:.00000}, {4:.00000}", Time, Open, High, Low, Close);
        }
    }
}