namespace School.Models
{
    using System.Collections.Generic;
    using Enumerators;
    using Interfaces;

    public class Discipline : ICommentable
    {
        public Discipline()
        {
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
        }

        public Discipline(DisciplineSubject name, int numberOfLectures, int numberOfExercises)
        {
            this.Name = name;
            this.NumberOfExercises = numberOfExercises;
            this.NumberOfLectures = numberOfLectures;
        }

        public string CommentBox { get; private set; }

        public IEnumerable<Student> Students { get; private set; }

        public IEnumerable<Teacher> Teachers { get; private set; }

        public int NumberOfExercises { get; private set; }

        public int NumberOfLectures { get; private set; }

        public DisciplineSubject Name { get; private set; }
    }
}
