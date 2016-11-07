namespace Cars.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }
    }
}