using System;

namespace TT.Sim
{
    abstract class Order
    {
        public DateTime TimePlaced { get; }

        public Order(DateTime timePlaced)
        {
            TimePlaced = timePlaced;
        }
    }
}