namespace Kitchen.Contracts
{
    using System.Collections;

    public interface IBowl : ICookware
    {
        void Add(IVegetable vegetable);
    }
}
