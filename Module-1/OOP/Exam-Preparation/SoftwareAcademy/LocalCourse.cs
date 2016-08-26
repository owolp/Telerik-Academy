using System;
using System.Text;

namespace SoftwareAcademy
{
    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public LocalCourse(string name, ITeacher teacher, string lab)
            : base(name, teacher)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                Validator.CheckIfStringIsNullOrEmpty(
                    value,
                    string.Format(
                        GlobalErrorMessages.StringCannotBeNullOrEmpty,
                        "Lab name"));
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Lab");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());

            result.AppendFormat("; Lab={0}", this.Lab);

            return result.ToString().Trim();
        }
    }
}
