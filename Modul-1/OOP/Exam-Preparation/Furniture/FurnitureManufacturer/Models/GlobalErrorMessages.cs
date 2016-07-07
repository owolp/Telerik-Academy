namespace FurnitureManufacturer.Models
{
    public class GlobalErrorMessages
    {
        public const string StringCannotBeNullOrEmpty = "{0} cannot be null or empty!";
        public const string ObjectCannotBeNull = "{0} cannot be null!";
        public const string InvalidStringLength = "{0} must be between {1} and {2} symbols long!";
        public const string InvalidStringMinLength = "{0} must not be less than {1} symbols long!";
        public const string InvalidStringExactLength = "{0} must not be exactly {1} symbols long!";
        public const string InvalidStringDigits = "{0} must contains only digits!";
    }
}
