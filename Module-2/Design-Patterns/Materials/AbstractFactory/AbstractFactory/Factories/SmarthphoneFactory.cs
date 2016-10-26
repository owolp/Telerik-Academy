namespace AbstractFactory.Factories
{
    using Contracts;
    using Models.Contracts;

    public abstract class SmarthphoneFactory : ISmartphoneFactory
    {
        public abstract IFlagmantSmartphone CreateFlagmantSmarthphone();

        public abstract IRegularSmartphone CreateRegularSmarthphone();
    }
}