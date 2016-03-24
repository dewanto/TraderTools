using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraderTools.Simulator.Traders
{
        /// <summary>
        /// A simple strategy on the daily timeframe.
        /// Buy rules:
        ///   (1) Latest candle is bullish with body larger than previous two bodies
        ///   (2) Previous candle is bearish
        /// Sell rules:
        ///   (1) Latest candle is bearish with body larger than previous two bodies
        ///   (2) Previous candle is bullish
        /// </summary>
        /// <returns></returns>
    class SimpleTrader1 : Trader
    {
        private List<MarketCandle> _dailyCandles;
        public SimpleTrader1(Account account, Market market, int startingCandleNum = 0) : base(account, market, startingCandleNum)
        {
            _dailyCandles = market.GetDailyCandles();
        }
        
        public override List<Order> Analyze()
        {
            var orders = new List<Order>();

            if (_currentCandleNum < 2) return orders;
            if (_currentCandleNum == _dailyCandles.Count - 1) return orders;

            var currentCandle = _dailyCandles[_currentCandleNum];
            var prevCandle = _dailyCandles[_currentCandleNum - 1];
            var prevPrevCandle = _dailyCandles[_currentCandleNum - 2];
            var nextCandle = _dailyCandles[_currentCandleNum + 1];

            if (currentCandle.IsBullish())
            {
                // Check if body larger than previous two candles
                if (!(currentCandle.Body > prevCandle.Body && currentCandle.Body > prevPrevCandle.Body)) return orders;

                // Check if previous candle was bearish
                if (!prevCandle.IsBearish()) return orders;

                orders.Add(new BuyOrder(nextCandle.Time));
            }
            else
            {
                // Check if body larger than previous two candles
                if (!(currentCandle.Body > prevCandle.Body && currentCandle.Body > prevPrevCandle.Body)) return orders;

                // Check if previous candle was bullish
                if (!prevCandle.IsBullish()) return orders;

                orders.Add(new SellOrder(nextCandle.Time));
            }

            return orders;
        }

        public override void StepForward()
        {
            throw new NotImplementedException();
        }
    }
}
