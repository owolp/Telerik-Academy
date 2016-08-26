namespace FurnitureManufacturer.Models
{
    using System;

    public static class Validator
    {
        public static void CheckIfNull(object obj, string message = null)
        {
            if (obj == null)
            {
                throw new NullReferenceException(message);
            }
        }

        public static void CheckIfStringIsNullOrEmpty(string text, string message = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new NullReferenceException(message);
            }
        }

        public static void CheckIfStringLengthIsValid(string text, int max, int min = 0, string message = null)
        {
            if (text.Length < min || max < text.Length)
            {
                throw new IndexOutOfRangeException(message);
            }
        }

        public static void CheckIfStringMinLengthIsValid(string text, int min = 0, string message = null)
        {
            if (text.Length < min)
            {
                throw new IndexOutOfRangeException(message);
            }
        }

        public static void CheckIfStringLengthIsWithExactLength(string text, int length, string message = null)
        {
            if (text.Length != length)
            {
                throw new IndexOutOfRangeException(message);
            }
        }

        public static void CheckIfStringContainsOnlyDigits(string text, string message = null)
        {
            foreach (char c in text)
            {
                if (c < '0' || c > '9')
                {
                    throw new IndexOutOfRangeException(message);
                }
                    
            }
        }
    }
}
