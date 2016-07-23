namespace SchoolAssembly
{
    using Common;

    public class Student
    {
        private string name;
        private int idNumber;

        public Student(string name, int idNumber)
        {
            this.Name = name;
            this.IdNumber = idNumber;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, Constants.StudentNameCannotBeNull);

                this.name = value;
            }
        }

        public int IdNumber
        {
            get
            {
                return this.idNumber;
            }

            private set
            {
                Validator.ValidateIntRange(
                    value,
                    Constants.MinIdNumber,
                    Constants.MaxIdNumber,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "ID Number", Constants.MinIdNumber, Constants.MaxIdNumber));

                this.idNumber = value;
            }
        }

        public void AddToCourse(Course course)
        {
            Validator.ValidateNull(course, Constants.CourseNameCannotBeNull);

            course.AddStudent(this);
        }

        public void RemoveFromCourse(Course course)
        {
            Validator.ValidateNull(course, Constants.CourseNameCannotBeNull);

            course.RemoveStudent(this);
        }
    }
}
