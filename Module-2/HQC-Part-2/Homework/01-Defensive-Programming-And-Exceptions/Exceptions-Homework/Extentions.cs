namespace ExceptionsHomework
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Common;

    public class Extentions
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            Validator.ValidateNull(
                arr,
                string.Format(Constants.ObjectCannotBeNull, "Array"));

            Validator.ValidateNumberIsPositive(
                    startIndex,
                    string.Format(Constants.NumberCannotBeNegative, "Start index"));

            Validator.ValidateNumberIsPositive(
                count,
                string.Format(Constants.NumberCannotBeNegative, "Count"));

            if (startIndex + count > arr.Length)
            {
                throw new IndexOutOfRangeException("Start index and count cannot be more than the array length");
            }

            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            Validator.CheckIfStringIsNullOrEmpty(
                    str,
                    string.Format(Constants.ObjectCannotBeNullOrEmpty, "String"));

            Validator.ValidateNumberIsPositive(
                   count,
                   string.Format(Constants.NumberCannotBeNegative, "Count"));

            if (count > str.Length)
            {
                throw new ArgumentOutOfRangeException("Count cannot be greater than the string length.");
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }

        public static bool CheckPrime(int number)
        {
            double length = Math.Sqrt(number);
            for (int divisor = 2; divisor <= length; divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
