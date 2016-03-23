using System;

namespace TraderTools.Simulator
{
    /// <summary>
    /// A snapshot of the market.
    /// </summary>
    public class MarketOHLC
    {
        public DateTime Time { get; }
        public decimal Open { get; }
        public decimal High { get; }
        public decimal Low { get; }
        public decimal Close { get; }

        public MarketOHLC(DateTime time, decimal open, decimal high, decimal low, decimal close)
        {
            Time = time;
            Open = open;
            High = high;
            Low = low;
            Close = close;
        }

        public override string ToString()
        {
           return String.Format("MarketOHLC: {0}, {1:.00000}, {2:.00000}, {3:.00000}, {4:.00000}", Time, Open, High, Low, Close);
        }
    }
}