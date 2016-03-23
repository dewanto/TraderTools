using System;

namespace TraderTools.Simulator
{
    /// <summary>
    /// N.B. LimitOrders "become" MarketOrders when the limit/stop price is hit
    /// </summary>
    class LimitOrder : Order
    {
        public LimitOrder(DateTime timePlaced) : base(timePlaced)
        {

        }
    }
}
