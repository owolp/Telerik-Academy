namespace NorthWindData.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }
    }
}