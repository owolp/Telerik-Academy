namespace StudentSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models.Models;

    public class StudentSystemDbContext : DbContext
    {
        public StudentSystemDbContext()
            : base("StudentSystemDb")
        {
        }

        public IDbSet<Homework> Homeworks { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Material> Materials { get; set; }

        public IDbSet<Student> Students { get; set; }
    }
}
