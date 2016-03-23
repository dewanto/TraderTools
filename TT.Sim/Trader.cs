using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.Sim
{
    /// <summary>
    /// Trades a market using a given strategy.
    /// </summary>
    public abstract class Trader
    {
        private Account _account;
        private Market _market;
        private List<Order> _orders;

        public Trader(Account account, Market market)
        {
            _account = account;
            _market = market;
            _orders = new List<Order>();
        }
    }
}