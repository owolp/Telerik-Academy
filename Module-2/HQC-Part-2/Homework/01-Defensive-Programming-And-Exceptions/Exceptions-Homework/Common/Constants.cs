namespace ExceptionsHomework.Common
{
    public class Constants
    {
        public const int MinNameLength = 2;
        public const int MaxNameLength = 20;
        public const int MinArrayLength = 1;
        public const int MinGrade = 2;
        public const int MaxGrade = 6;
        public const int MinimumProblemsSolved = 0;
        public const int MaximumProblemsSolved = 10;
        public const int BadResult = 2;
        public const int AverageResult = 4;
        public const int BestResult = 6;
        public const int MinExamResult = 0;
        public const int MaxExamResult = 100;

        public const string StringMustBeBetweenMinAndMax = "{0} must be between {1} and {2} characters long!";

        public const string NumberMustBeBetweenMinAndMax = "{0} must be between {1} and {2}!";
        public const string NumberCannotBeNegative = "{0} cannot be less than 0.";

        public const string NamePattern = "^[A-Z][-a-zA-Z]+$";

        public const string ObjectCannotBeNull = "{0} cannot be null!";
        public const string ObjectCannotBeNullOrEmpty = "{0} cannot be null or empty.";

        public const string InvalidSymbols = "{0} contains invalid symbols!";

        public const string NoExamsForStudent = "The student has no exams!";

        public const string MaxGradeCannotBeLessThanMinGrade = "Max grade cannot be less or equal to min grade!";
        public const string ResultNothingDone = "{0} result: nothing done.";
    }
}
