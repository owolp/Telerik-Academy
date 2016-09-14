namespace ExceptionsHomework.Models
{
    using System;
    using Abstract;
    using Common;
    using Contracts;

    public class SimpleMathExam : Exam, IMathExam
    {
        private int problemsSolved;

        public SimpleMathExam(int problemsSolved)
        {
            this.ProblemsSolved = problemsSolved;
        }

        public int ProblemsSolved
        {
            get
            {
                if (this.problemsSolved < Constants.MinimumProblemsSolved)
                {
                    return Constants.MinimumProblemsSolved;
                }
                else if (this.problemsSolved > Constants.MaximumProblemsSolved)
                {
                    return Constants.MaximumProblemsSolved;
                }

                return this.problemsSolved;
            }

            private set
            {
                this.problemsSolved = value;
            }
        }

        public override ExamResult Check()
        {
            var grade = 0;
            var resultString = string.Empty;

            switch (this.ProblemsSolved)
            {
                case 0:
                    grade = 2;
                    resultString = "Bad";
                    break;
                case 1:
                    grade = 4;
                    resultString = "Average";
                    break;
                case 2:
                    grade = 6;
                    resultString = "Good";
                    break;
                default:
                    throw new ArgumentException("Invalid number of problems solved!");
            }

            var examResult = new ExamResult(grade, Constants.MinGrade, Constants.MaxGrade, resultString);

            return examResult;
        }
    }
}