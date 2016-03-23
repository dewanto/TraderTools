using System.Collections.Generic;

namespace TT.Sim
{
    /// <summary>
    /// Trades a market using a given strategy.
    /// </summary>
    public abstract class Trader
    {
        private Account _account;
        private Market _market;
        private List<Order> _currentOrders;
        private List<Order> _completedOrders;

        public Trader(Account account, Market market)
        {
            _account = account;
            _market = market;
            _currentOrders = new List<Order>();
            _completedOrders = new List<Order>();
        }
    }
}