namespace Methods.Models
{
    using System;
    using Common;
    using Contracts;

    public class Student : IStudent
    {
        private string firstName;

        private string lastName;

        public Student(string firstName, string lastName, string additionalInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.AdditionalInfo = additionalInfo;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinNameLength,
                    Constants.MaxNameLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "First Name", Constants.MinNameLength, Constants.MaxNameLength));

                Validator.ValidateSymbols(
                    value,
                    Constants.NamePattern,
                    string.Format(Constants.InvalidSymbols, "First Name"));

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinNameLength,
                    Constants.MaxNameLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Last Name", Constants.MinNameLength, Constants.MaxNameLength));

                Validator.ValidateSymbols(
                    value,
                    Constants.NamePattern,
                    string.Format(Constants.InvalidSymbols, "Last Name"));

                this.lastName = value;
            }
        }

        public string AdditionalInfo { get; private set; }

        public bool IsOlderThan(Student comparedStudent)
        {
            Validator.ValidateNull(
                comparedStudent,
                string.Format(Constants.ObjectCannotBeNull, "Student"));

            var currentStudent = this;

            DateTime firstStudentBirthDate = this.GetBirthDay(currentStudent);
            DateTime secondStudentBirthDate = this.GetBirthDay(comparedStudent);

            var firstStudentIsOlderThanSecondStudent = firstStudentBirthDate < secondStudentBirthDate;

            return firstStudentIsOlderThanSecondStudent;
        }

        public DateTime GetBirthDay(Student student)
        {
            Validator.ValidateNull(
                student,
                string.Format(Constants.ObjectCannotBeNull, "Student"));

            DateTime date = DateTime.Parse(student.AdditionalInfo.Substring(student.AdditionalInfo.Length - 10));

            return date;
        }
    }
}
