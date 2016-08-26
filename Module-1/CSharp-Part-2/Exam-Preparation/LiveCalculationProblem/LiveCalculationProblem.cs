namespace LiveCalculationProblem
{
    using System;
    using System.Linq;

    class LiveCalculationProblem
    {
        static void Main()
        {
            var text = Console.ReadLine().Split(' ').ToArray();

            ulong decimalNumber = 0;

            for (int i = 0; i < text.Length; i++)
            {
                decimalNumber += ConvertToDec(23, text[i]);
            }

            Console.WriteLine(ConvertToSpecial(23, decimalNumber) + " = " + decimalNumber);
        }

        static ulong ConvertToDec(int @base, string baseNumber)
        {
            ulong decimalNumber = 0;

            for (int i = 0; i < baseNumber.Length; i++)
            {
                ulong digit = 0;

                if ('a' <= baseNumber[i] && baseNumber[i] <= 'w')
                {
                    digit = (ulong)baseNumber[i] - 'a';
                }

                int position = baseNumber.Length - i - 1;

                decimalNumber += digit * GetPower(@base, position);
            }

            return decimalNumber;
        }

        static string ConvertToSpecial(ulong @base, ulong decimalNumber)
        {
            string baseNumber = string.Empty;

            while (decimalNumber > 0)
            {
                ulong digit = decimalNumber % @base;

                if (0 <= digit || digit <= @base)
                {
                    baseNumber = (char)(digit + 'a') + baseNumber;
                }

                decimalNumber /= @base;
            }

            return baseNumber;
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