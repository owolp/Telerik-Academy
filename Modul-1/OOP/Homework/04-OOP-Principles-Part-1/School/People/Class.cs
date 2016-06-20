namespace School.People
{
    using System.Collections.Generic;
    using Enumerators;
    using Interfaces;

    public class Class : ICommentable
    {
        private ClassId uniqueTextId;
        private string comment;
        private List<Student> students;
        private List<Teacher> teachers;

        public Class()
        {
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
        }

        public Class(ClassId uniqueTextId)
            : this()
        {
            this.UniqueTextId = uniqueTextId;
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

        public string CommentBox
        {
            get { return this.comment; }
            set { this.comment = value; }
        }

        public ClassId UniqueTextId
        {
            get { return this.uniqueTextId; }
            set { this.uniqueTextId = value; }
        }
    }
}
