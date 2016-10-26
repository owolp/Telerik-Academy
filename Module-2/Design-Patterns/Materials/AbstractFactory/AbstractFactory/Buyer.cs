namespace AbstractFactory
{
    using System;
    using Factories.Contracts;
    using Models.Contracts;

    public class Buyer
    {
        private ISmartphoneFactory smartphoneFactory;

        public Buyer(ISmartphoneFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException();
            }

            this.smartphoneFactory = factory;
        }

        private IFlagmantSmartphone BuyFlagmantSmartphone()
        {
            return this.smartphoneFactory.CreateFlagmantSmarthphone();
        }

        private IRegularSmartphone BuyRegularSmartphone()
        {
            return this.smartphoneFactory.CreateRegularSmarthphone();
        }
    }
}