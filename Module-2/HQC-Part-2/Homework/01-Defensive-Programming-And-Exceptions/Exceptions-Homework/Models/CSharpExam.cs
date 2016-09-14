namespace ExceptionsHomework.Models
{
    using Abstract;
    using Common;
    using Contracts;

    public class CSharpExam : Exam, ICSharpExam
    {
        private int score;

        public CSharpExam(int score)
        {
            this.Score = score;
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            private set
            {
                Validator.ValidateNumberIsPositive(
                    value,
                    string.Format(Constants.NumberCannotBeNegative, "Score"));

                this.score = value;
            }
        }

        public override ExamResult Check()
        {
            Validator.ValidateIntRange(
                this.Score,
                Constants.MinExamResult,
                Constants.MaxExamResult,
                string.Format(Constants.NumberMustBeBetweenMinAndMax, "Exam score", Constants.MinExamResult, Constants.MaxExamResult));

            var examResult = new ExamResult(this.Score, Constants.MinExamResult, Constants.MaxExamResult, "Exam results calculated by score.");

            return examResult;
        }
    }
}