namespace SoftwareAcademy
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Teacher : ITeacher
    {
        private string name;

        public Teacher(string name)
        {
            this.Name = name;
            this.Courses = new List<ICourse>();
        }

        public IList<ICourse> Courses { get; private set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.CheckIfStringIsNullOrEmpty(
                    value,
                    string.Format(
                        GlobalErrorMessages.StringCannotBeNullOrEmpty,
                        "Teacher name"));

                this.name = value;
            }
        }

        public void AddCourse(ICourse course)
        {
            Validator.CheckIfNull(
                course,
                string.Format(
                    GlobalErrorMessages.ObjectCannotBeNull,
                    "Course"));

            this.Courses.Add(course);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("Teacher: Name={0}", this.name);

            if (this.Courses.Count != 0)
            {
                result.AppendFormat("; Courses=[{0}]", string.Join(", ", this.Courses.Select(c => c.Name)));
            }

            return result.ToString().Trim();
        }
    }
}
