namespace NorthWindData.Models
{
    using System.Collections.Generic;

    public class Country
    {
        private ICollection<City> cities;

        public Country()
        {
            // HashSet се използва защото е по-бърз от List()
            // HashSet няма индексация, но не и трябва
            this.Cities = new HashSet<City>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        // Добавяме тази колекция заради релацията със City
        // ICollection заради Add, Remove и т.н.
        public virtual ICollection<City> Cities
        {
            get
            {
                return this.cities;
            }

            set
            {
                this.cities = value;
            }
        }
    }
}