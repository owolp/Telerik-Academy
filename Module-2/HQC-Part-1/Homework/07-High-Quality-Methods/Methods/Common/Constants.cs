namespace Methods.Common
{
    public class Constants
    {
        public const int MinNameLength = 2;
        public const int MaxNameLength = 20;
        public const int MinArrayLength = 1;

        public const string StringMustBeBetweenMinAndMax = "{0} must be between {1} and {2} characters long!";

        public const string NumberMustBeBetweenMinAndMax = "{0} must be between {1} and {2}!";
        public const string NumberMustBePositive = "{0} cannot be less than 0.";

        public const string NamePattern = "^[A-Z][-a-zA-Z]+$";

        public const string ObjectCannotBeNull = "{0} cannot be null!";

        public const string InvalidSymbols = "{0} contains invalid symbols!";
    }
}
