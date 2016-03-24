using System;

namespace TraderTools.Simulator
{
    /// <summary>
    /// A price "candle" with candle (open, high, low, close) data over a period of time.
    /// </summary>
    public class MarketCandle
    {
        public DateTime Time { get; }
        public decimal Open { get; }
        public decimal High { get; }
        public decimal Low { get; }
        public decimal Close { get; }

        public MarketCandle(DateTime time, decimal open, decimal high, decimal low, decimal close)
        {
            Time = time;
            Open = open;
            High = high;
            Low = low;
            Close = close;
        }

        public override string ToString()
        {
           return String.Format("MarketCandle: {0}, {1:.00000}, {2:.00000}, {3:.00000}, {4:.00000}", Time, Open, High, Low, Close);
        }
    }
}