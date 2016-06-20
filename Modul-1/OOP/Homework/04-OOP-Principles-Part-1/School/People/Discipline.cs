namespace School.People
{
    using System.Collections.Generic;
    using Enumerators;
    using Interfaces;

    public class Discipline : ICommentable
    {
        private DisciplineSubject name;
        private int numberOfLectures;
        private int numberOfExercises;
        private string comment;
        private List<Student> students;
        private List<Teacher> teachers;

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

        public string CommentBox
        {
            get { return this.comment; }
            set { this.comment = value; }
        }

        public List<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }

        public List<Teacher> Teachers
        {
            get { return this.teachers; }
            set { this.teachers = value; }
        }

        public int NumberOfExercises
        {
            get { return this.numberOfExercises; }
            set { this.numberOfExercises = value; }
        }

        public int NumberOfLectures
        {
            get { return this.numberOfLectures; }
            set { this.numberOfLectures = value; }
        }

        public DisciplineSubject Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }
}
