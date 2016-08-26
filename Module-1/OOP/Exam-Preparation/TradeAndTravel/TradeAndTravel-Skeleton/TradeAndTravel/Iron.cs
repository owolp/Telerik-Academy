namespace TradeAndTravel
{
    public class Iron : Item
    {
        private const int InitialIronValue = 3;

        public Iron(string name, Location location = null)
            : base(name, Iron.InitialIronValue, ItemType.Iron, location)
        {
        }
    }
}
