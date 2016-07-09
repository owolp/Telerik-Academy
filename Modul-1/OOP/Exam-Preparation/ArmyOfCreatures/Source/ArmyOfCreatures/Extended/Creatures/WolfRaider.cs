namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Logic.Specialties;
    using ArmyOfCreatures.Extended.Specialties;

    public class WolfRaider : Creature
    {
        public WolfRaider()
            : base(8, 5, 10, 3.5M)
        {
            this.AddSpecialty(new DoubleDamage(7));
        }
    }
}
