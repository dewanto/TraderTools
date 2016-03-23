using System;

namespace TraderTools.Simulator
{
    public abstract class Order
    {
        public DateTime TimePlaced { get; }

        public Order(DateTime timePlaced)
        {
            TimePlaced = timePlaced;
        }
    }
}