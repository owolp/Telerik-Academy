namespace InheritanceAndPolymorphism.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Common;
    using Contracts;
    using Models;

    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string townName;

        public OffsiteCourse(string name)
            : base(name)
        {
        }

        public OffsiteCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
        }

        public OffsiteCourse(string courseName, IList<string> students, string teacherName)
            : base(courseName, students, teacherName)
        {
        }

        public OffsiteCourse(string courseName, IList<string> students, string teacherName, string townName)
              : base(courseName, students, teacherName)
        {
            this.TownName = townName;
        }

        public string TownName
        {
            get
            {
                return this.townName;
            }

            set
            {
                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinNameLength,
                    Constants.MaxNameLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Town name", Constants.MinNameLength, Constants.MaxNameLength));

                Validator.ValidateSymbols(
                    value,
                    Constants.NamePattern,
                    string.Format(Constants.InvalidSymbols, "Town name"));

                this.townName = value;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(base.ToString());
            if (this.TownName != null)
            {
                stringBuilder.Append("; Town = ");
                stringBuilder.Append(this.TownName);
            }

            stringBuilder.Append(" }");

            return stringBuilder.ToString();
        }
    }
}
