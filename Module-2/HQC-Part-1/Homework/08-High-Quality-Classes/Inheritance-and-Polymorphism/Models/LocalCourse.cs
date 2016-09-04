namespace InheritanceAndPolymorphism.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Common;
    using Contracts;
    using Models;

    public class LocalCourse : Course, ILocalCourse
    {
        private string laboratoryName;

        public LocalCourse(string name)
            : base(name)
        {
        }

        public LocalCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
        }

        public LocalCourse(string courseName, IList<string> students, string teacherName)
            : base(courseName, students, teacherName)
        {
        }

        public LocalCourse(string courseName, IList<string> students, string teacherName, string laboratoryName)
             : base(courseName, students, teacherName)
        {
            this.LaboratoryName = laboratoryName;
        }

        public string LaboratoryName
        {
            get
            {
                return this.laboratoryName;
            }

            set
            {
                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinNameLength,
                    Constants.MaxNameLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Laboratory name", Constants.MinNameLength, Constants.MaxNameLength));

                Validator.ValidateSymbols(
                    value,
                    Constants.NamePattern,
                    string.Format(Constants.InvalidSymbols, "Laboratory name"));

                this.laboratoryName = value;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(base.ToString());
            if (this.LaboratoryName != null)
            {
                stringBuilder.Append("; Lab = ");
                stringBuilder.Append(this.LaboratoryName);
            }

            stringBuilder.Append(" }");

            return stringBuilder.ToString();
        }
    }
}
