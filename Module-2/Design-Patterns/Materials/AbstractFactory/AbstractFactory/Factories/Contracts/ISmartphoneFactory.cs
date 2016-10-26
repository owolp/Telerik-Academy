namespace AbstractFactory.Factories.Contracts
{
    using AbstractFactory.Models.Contracts;

    public interface ISmartphoneFactory
    {
        IFlagmantSmartphone CreateFlagmantSmarthphone();

        IRegularSmartphone CreateRegularSmarthphone();
    }
}