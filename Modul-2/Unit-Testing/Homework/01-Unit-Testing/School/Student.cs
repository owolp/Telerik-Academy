namespace School
{
    using Common;

    public class Student
    {
        private string name;
        private int id;

        public Student(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            private set
            { 
                Validator.ValidateIntRange(
                    value,
                    Constants.MinIdNumber,
                    Constants.MaxIdNumber,
                    string.Format(Constants.NumberMustBeBetweenMinAndMax, "Student Id number", Constants.MinIdNumber, Constants.MaxIdNumber));

                this.id = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(
                    value,
                    string.Format(Constants.NameCannotBeNullOrEmpty, "Student Name"));

                this.name = value;
            }
        }

        private void AddToCourse(Course course)
        {
            Validator.ValidateNull(
                course,
                string.Format(Constants.ObjectCannotBeNullOrEmpty, "Course"));

            course.AddStudent(this);
        }

        private void RemoveFromCourse(Course course)
        {
            Validator.ValidateNull(
                course,
                string.Format(Constants.ObjectCannotBeNullOrEmpty, "Course"));

            course.RemoveStudent(this);
        }
    }
}
