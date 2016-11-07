namespace Company.Generator.Abstract
{
    using Contracts;
    using Data;

    public abstract class DataGenerator : IDataGenerator
    {
        private IRandomGenerator random;
        private CompanyEntities database;
        private int count;

        public DataGenerator(IRandomGenerator randomGenerator, CompanyEntities entities, int countOfGeneratedObjects)
        {
            this.random = randomGenerator;
            this.database = entities;
            this.count = countOfGeneratedObjects;
        }

        protected IRandomGenerator Random
        {
            get { return this.random; }
        }

        protected CompanyEntities Database
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
