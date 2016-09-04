namespace InheritanceAndPolymorphism.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Common;
    using Contracts;

    public abstract class Course : ICourse
    {
        private string name;

        private string teacherName;

        public Course(string name)
        {
            this.Name = name;
            this.Students = new List<string>();
        }

        public Course(string name, string teacherName)
            : this(name)
        {
            this.TeacherName = teacherName;
        }

        public Course(string name, IList<string> students, string teacherName)
            : this(name, teacherName)
        {
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinNameLength,
                    Constants.MaxNameLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Course name", Constants.MinNameLength, Constants.MaxNameLength));

                Validator.ValidateSymbols(
                    value,
                    Constants.NamePattern,
                    string.Format(Constants.InvalidSymbols, "Course name"));

                this.name = value;
            }
        }

        public IList<string> Students { get; set; }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinNameLength,
                    Constants.MaxNameLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Teacher name", Constants.MinNameLength, Constants.MaxNameLength));

                Validator.ValidateSymbols(
                    value,
                    Constants.NamePattern,
                    string.Format(Constants.InvalidSymbols, "Teacher name"));

                this.teacherName = value;
            }
        }

        public virtual string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            var courseTypeName = this.GetType().Name;
            var courseName = this.Name;
            stringBuilder.AppendFormat($"{courseTypeName} ( Name = {courseName}");
            if (this.TeacherName != null)
            {
                stringBuilder.Append("; Teacher = ");
                stringBuilder.Append(this.TeacherName);
            }

            stringBuilder.Append("; Students = ");
            stringBuilder.Append(this.GetStudentsAsString());
            
            return stringBuilder.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
