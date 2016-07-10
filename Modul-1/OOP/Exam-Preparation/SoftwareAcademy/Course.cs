namespace SoftwareAcademy
{
    using System.Collections.Generic;
    using System.Text;
    public abstract class Course : ICourse
    {
        private string name;

        public Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.Topics = new List<string>();
        }

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
                        "Course name"));

                this.name = value;
            }
        }

        public ITeacher Teacher { get; set; }

        public IList<string> Topics { get; private set; }

        public void AddTopic(string topic)
        {
            Validator.CheckIfStringIsNullOrEmpty(
                topic,
                string.Format(
                    GlobalErrorMessages.StringCannotBeNullOrEmpty,
                    "Topic name"));

            this.Topics.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("{0}: Name={1}", this.GetType().Name, this.Name);

            if (this.Teacher != null)
            {
                result.AppendFormat("; Teacher={0}", this.Teacher.Name);
            }

            if (this.Topics.Count != 0)
            {
                result.AppendFormat("; Topics=[{0}]", string.Join(", ", this.Topics));
            }

            return result.ToString().Trim();
        }
    }
}
