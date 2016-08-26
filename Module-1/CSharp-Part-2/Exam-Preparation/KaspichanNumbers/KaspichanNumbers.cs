using System;
using System.Collections.Generic;

namespace KaspichanNumbers
{
    class KaspichanNumbers
    {
        static void Main()
        {
            ulong number = ulong.Parse(Console.ReadLine());

            if (number == 0)
            {
                Console.WriteLine("A");
            }
            else
            {
                Console.WriteLine(ConvertFromDecimal(256, number, BuildDigits()));
            }           
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

        static string ConvertFromDecimal(ulong @base, ulong decimalNumber, List<string> digits)
        {
            string specialNumber = string.Empty;

            while (decimalNumber > 0)
            {
                ulong digit = decimalNumber % @base;

                if (0 <= digit && digit <= 255)
                {
                    specialNumber = digits[(int)digit] + specialNumber;
                }

                decimalNumber /= @base;
            }

            return specialNumber;
        }
    }
}