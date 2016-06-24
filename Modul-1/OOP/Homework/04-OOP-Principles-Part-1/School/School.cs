namespace School
{
    using System.Collections.Generic;
    using Models;

    public class School
    {
        private string name;
        private List<Teacher> teachers;
        private List<Student> students;

        public School()
        {
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
        }

        public School(string name)
            : this()
        {
            this.Name = name;
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

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }
}
