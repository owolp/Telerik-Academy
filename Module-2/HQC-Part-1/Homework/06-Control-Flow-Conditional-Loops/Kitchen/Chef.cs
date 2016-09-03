namespace Kitchen
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class Chef : IChef
    {
        public IList<IVegetable> VegetablesToCook
        {
            get
            {
                return new List<IVegetable>();
            }
        }

        public IMeal CookMeal()
        {
            IPotato potato = this.GetPotato();    
            this.VegetablesToCook.Add(potato);

            ICarrot carrot = this.GetCarrot();
            this.VegetablesToCook.Add(carrot);

            IBowl bowl = this.MixVegetablesInBowl(this.VegetablesToCook);

            IMeal cookedFood = this.ServeFood(bowl);

            return cookedFood;
        }

        public IBowl MixVegetablesInBowl(IList<IVegetable> vegetables)
        {
            IBowl bowl = this.GetBowl();

            foreach (IVegetable vegetable in vegetables)
            {
                this.Peel(vegetable);
                this.Cut(vegetable);
                bowl.Add(vegetable);
            }

            return bowl;
        }

        private ICarrot GetCarrot()
        {
            throw new NotImplementedException();
        }

        private IPotato GetPotato()
        {
            throw new NotImplementedException();
        }

        private IVegetable Peel(IVegetable vegetable)
        {
            throw new NotImplementedException();
        }

        private IVegetable Cut(IVegetable vegetable)
        {
            throw new NotImplementedException();
        }

        private IBowl GetBowl()
        {
            throw new NotImplementedException();
        }

        private IMeal ServeFood(ICookware cookware)
        {
            throw new NotImplementedException();
        }
    }
}
