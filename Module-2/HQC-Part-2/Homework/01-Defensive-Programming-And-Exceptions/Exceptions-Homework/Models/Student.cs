namespace ExceptionsHomework.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Contracts;

    public class Student : IStudent
    {
        private string firstName;
        private string lastName;
        private IList<IExam> exams;

        public Student(string firstName, string lastName, IList<IExam> exams)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Exams = exams;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(
                value,
                string.Format(Constants.ObjectCannotBeNullOrEmpty, "First name"));
                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinNameLength,
                    Constants.MaxNameLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "First name", Constants.MinNameLength, Constants.MaxNameLength));

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
                Validator.CheckIfStringIsNullOrEmpty(
                    value,
                    string.Format(Constants.ObjectCannotBeNullOrEmpty, "Last name"));
                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinNameLength,
                    Constants.MaxNameLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Last name", Constants.MinNameLength, Constants.MaxNameLength));

                this.lastName = value;
            }
        }

        public IList<IExam> Exams
        {
            get
            {
                return this.exams;
            }

            private set
            {
                Validator.ValidateNull(
                    value,
                    string.Format(Constants.ObjectCannotBeNull, "Exams"));

                this.exams = value;
            }
        }

        public IList<ExamResult> CheckExams()
        {
            Validator.ValidateNull(this.Exams, string.Format(Constants.ObjectCannotBeNull, "Exams list"));
            Validator.ValidateArrayLength(this.Exams, Constants.NoExamsForStudent);

            IList<ExamResult> results = new List<ExamResult>();
            for (int i = 0; i < this.Exams.Count; i++)
            {
                var checkedExam = this.Exams[i].Check();
                results.Add(checkedExam);
            }

            return results;
        }

        public double CalcAverageExamResultInPercents()
        {
            Validator.ValidateNull(this.Exams, string.Format(Constants.ObjectCannotBeNull, "Exams list"));
            Validator.ValidateArrayLength(this.Exams, Constants.NoExamsForStudent);

            double[] examScore = new double[this.Exams.Count];

            IList<ExamResult> examResults = this.CheckExams();
            for (int i = 0; i < examResults.Count; i++)
            {
                examScore[i] = ((double)examResults[i].Grade - examResults[i].MinGrade) /
                    (examResults[i].MaxGrade - examResults[i].MinGrade);
            }

            double examScoreAverage = examScore.Average();

            return examScoreAverage;
        }
    }
}