using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraderTools
{
    /// <summary>
    /// A snapshot of the market.
    /// </summary>
    class MarketOHLC
    {
        public DateTime Time { get; }
        public float Open { get; }
        public float High { get; }
        public float Low { get; }
        public float Close { get; }

        public MarketOHLC(DateTime time, float open, float high, float low, float close)
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