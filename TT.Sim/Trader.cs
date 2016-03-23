using System.Collections.Generic;

namespace TraderTools.Simulator
{
    /// <summary>
    /// Trades a market using a given strategy.
    /// </summary>
    public abstract class Trader
    {
        private Account _account;
        private Market _market;
        private int _currentOHLCNum;
        private List<Order> _currentOrders;
        private List<Order> _completedOrders;

        public Trader(Account account, Market market, int startingOHLCNum = 0)
        {
            _account = account;
            _market = market;
            _currentOHLCNum = startingOHLCNum;
            _currentOrders = new List<Order>();
            _completedOrders = new List<Order>();
        }

        public abstract List<Order> Analyze();
        public abstract void UpdateOrders();
    }
}