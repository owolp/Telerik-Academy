namespace AbstractFactory.Factories
{
    using Models;
    using Models.Contracts;

    public class LgFactory : SmarthphoneFactory
    {
        public override IFlagmantSmartphone CreateFlagmantSmarthphone()
        {
            return new LgFlagmantSmartphone();
        }

        public override IRegularSmartphone CreateRegularSmarthphone()
        {
            return new LgRegularSmartphone();
        }
    }
}