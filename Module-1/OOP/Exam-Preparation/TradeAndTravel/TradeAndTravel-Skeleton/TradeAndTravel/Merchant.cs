using System;

namespace TradeAndTravel
{
    public class Merchant : Shopkeeper, IShopkeeper
    {
        public Merchant(string name, Location location)
            : base(name, location)
        {
        }

        public virtual void TravelTo(Location location)
        {
            this.Location = location;
        }
    }
}
