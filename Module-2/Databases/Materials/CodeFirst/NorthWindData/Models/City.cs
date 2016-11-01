namespace NorthWindData.Models
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }

        // Navigation Property
        // Има релация между City и Country
        public virtual Country Country { get; set; }
    }
}