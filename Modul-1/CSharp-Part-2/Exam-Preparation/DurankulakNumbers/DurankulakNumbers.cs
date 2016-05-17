using System;
using System.Collections.Generic;

namespace DurankulakNumbers
{
    class DurankulakNumbers
    {
        static void Main()
        {
            Console.WriteLine(ConvertToDec(168, ConvertToBase(Console.ReadLine(), BuildDigits())));           
        }

        public static List<string> BuildDigits()
        {
            List<string> digits = new List<string>();
            for (char digit = 'A'; digit <= 'Z'; digit++)
            {
                digits.Add("" + digit);
            }
            for (char prefix = 'a'; prefix <= 'z'; prefix++)
            {
                for (char suffix = 'A'; suffix <= 'Z'; suffix++)
                {
                    string digit = "" + prefix + suffix;
                    digits.Add(digit);
                }
            }
            return digits;
        }

        static ulong ConvertToDec(int @base, List<ulong> numbers)
        {
            ulong decimalNumber = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                int position = numbers.Count - i - 1;
                decimalNumber += numbers[i] * GetPower(@base, position);
            }

            return decimalNumber;
        }

        static List<ulong> ConvertToBase(string baseNumber, List<string> digits)
        {
            string partialInput = string.Empty;
            List<ulong> numbers = new List<ulong>();

            for (int i = 0; i < baseNumber.Length; i++)
            {
                partialInput += baseNumber[i];

                if (digits.Contains(partialInput))
                {
                    int index = digits.IndexOf(partialInput);

                    numbers.Add((ulong)index);

                    partialInput = string.Empty;
                }
            }

            return numbers;
        }

        static ulong GetPower(int @base, int position)
        {
            ulong result = 1;

            for (int i = 0; i < position; i++)
            {
                result *= (ulong)@base;
            }

            return result;
        }
    }
}