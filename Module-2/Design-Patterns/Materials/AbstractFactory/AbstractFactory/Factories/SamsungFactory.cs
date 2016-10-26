namespace AbstractFactory.Factories
{
    using Models;
    using Models.Contracts;

    public class SamsungFactory : SmarthphoneFactory
    {
        public override IFlagmantSmartphone CreateFlagmantSmarthphone()
        {
            return new SamsungFlagmantSmartphone();
        }

        public override IRegularSmartphone CreateRegularSmarthphone()
        {
            return new SamsungRegularSmartphone();
        }
    }
}