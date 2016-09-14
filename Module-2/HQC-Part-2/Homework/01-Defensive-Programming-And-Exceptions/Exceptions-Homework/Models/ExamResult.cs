namespace ExceptionsHomework.Models
{
    using Common;
    using Contracts;

    public class ExamResult : IExamResult
    {
        private int grade;
        private int minGrade;
        private int maxGrade;
        private string comments;

        public ExamResult(int grade, int minGrade, int maxGrade, string comments)
        {
            this.Grade = grade;
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            this.Comments = comments;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }

            private set
            {
                Validator.ValidateNumberIsPositive(
                    value,
                    string.Format(Constants.NumberCannotBeNegative, "Grade"));

                this.grade = value;
            }
        }

        public int MinGrade
        {
            get
            {
                return this.minGrade;
            }

            private set
            {
                Validator.ValidateNumberIsPositive(
                    value,
                    string.Format(Constants.NumberCannotBeNegative, "Min Grade"));

                this.minGrade = value;
            }
        }

        public int MaxGrade
        {
            get
            {
                return this.maxGrade;
            }

            private set
            {
                Validator.ValidateMaxGrade(
                    this.minGrade,
                    value,
                    string.Format(Constants.MaxGradeCannotBeLessThanMinGrade));

                this.maxGrade = value;
            }
        }

        public string Comments
        {
            get
            {
                return this.comments;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(
                    value,
                    string.Format(Constants.ObjectCannotBeNullOrEmpty, "Comments"));

                this.comments = value;
            }
        }
    }
}