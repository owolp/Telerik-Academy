namespace LiveKaspichanNumbers
{
    using System;
    using System.Collections.Generic;

    class LiveKaspichanNumbers
    {
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

        static void Main(string[] args)
        {
            ulong inputNumber = ulong.Parse(Console.ReadLine());
            Console.WriteLine(DecToBase(256, inputNumber, BuildDigits()));
        }

        static string DecToBase(ulong @base, ulong decimalNumber, List<string> digits)
        {
            string baseNumber = string.Empty;

            if (decimalNumber == 0)
            {
                return "A";
            }

            while (decimalNumber > 0)
            {
                ulong digit = decimalNumber % @base;

                if (0 <= digit && digit <= @base)
                {
                    baseNumber = digits[(int)digit] + baseNumber;
                }

                decimalNumber /= @base;
            }

            return baseNumber;
        }
    }
}