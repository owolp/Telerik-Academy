namespace TradeAndTravel
{
    public class Weapon : Item
    {
        private const int InitialArmorvalue = 10;

        public Weapon(string name, Location location = null)
            : base(name, Weapon.InitialArmorvalue, ItemType.Weapon, location)
        {
        }
    }
}
