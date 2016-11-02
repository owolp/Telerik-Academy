namespace StudentSystem.Models.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Material
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}