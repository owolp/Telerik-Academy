namespace ExceptionsHomework.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Validator
    {
        public static void ValidateArrayLength<T>(IList<T> value, string message = null)
        {
            if (value.Count == 0)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateIntRange(int value, int min, int max, string message = null)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateNull(object value, string message)
        {
            if (value == null)
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void CheckIfStringIsNullOrEmpty(string text, string message = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new NullReferenceException(message);
            }
        }

        public static void ValidateNumberIsPositive(int value, string message = null)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(message);
            }
        }

        public static void ValidateGrade(int grade, int minGrade, int maxGrade, string message = null)
        {
            if (grade < minGrade || maxGrade < grade)
            {
                throw new ArgumentOutOfRangeException(message);
            }
        }

        public static void ValidateMaxGrade(int minGrade, int maxGrade, string message = null)
        {
            if (maxGrade <= minGrade)
            {
                throw new ArgumentOutOfRangeException(message);
            }
        }
    }
}
