namespace ToyStore.Generator.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;
    using Data;

    public abstract class DataGenerator : IDataGenerator
    {
        private IRandomGenerator random;
        private ToyStoreEntities database;
        private int count;

        public DataGenerator(IRandomGenerator randomGenerator, ToyStoreEntities toyStoreEntities, int countOfGeneratedObjects)
        {
            this.random = randomGenerator;
            this.database = toyStoreEntities;
            this.count = countOfGeneratedObjects;
        }

        protected IRandomGenerator Random
        {
            get { return this.random; }
        }

        protected ToyStoreEntities Database
        {
            get { return this.database; }
        }

        protected int Count
        {
            get { return this.count; }
        }

        public abstract void Generate();
    }
}
