namespace TradeAndTravel
{
    public class Wood : Item
    {
        private const int InitialWoodvalue = 2;

        public Wood(string name, Location location = null)
            : base(name, Wood.InitialWoodvalue, ItemType.Wood, location)
        {
        }

        public override void UpdateWithInteraction(string interaction)
        {
            if (this.Value > 0)
            {
                this.Value--;
            }
        }
    }
}
