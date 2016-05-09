using System;

namespace NineGagNumbers
{
    class NineGagNumbers
    {
        static void Main()
        {
            var input = Console.ReadLine();

            ulong baseIn = 9;

            string numberAsString = ConvertToString(input);

            ulong result = GetSum(numberAsString, baseIn);

            Console.WriteLine(result);
        }

        static string ConvertToString(string input)
        {
            string partialInput = string.Empty;
            string nineSystemNumber = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                partialInput += input[i];

                string currentDigit = GetValue(partialInput);

                if (currentDigit != "no")
                {
                    nineSystemNumber += currentDigit;
                    partialInput = string.Empty;
                }
            }

            return nineSystemNumber;
        }

        static string GetValue(string word)
        {
            string result = "no";
            switch (word)
            {
                case "-!": result = "0"; break;
                case "**": result = "1"; break;
                case "!!!": result = "2"; break;
                case "&&": result = "3"; break;
                case "&-": result = "4"; break;
                case "!-": result = "5"; break;
                case "*!!!": result = "6"; break;
                case "&*!": result = "7"; break;
                case "!!**!-": result = "8"; break;
                default:
                    break;
            }

            return result;
        }

        static ulong GetPower(ulong baseIn, int power)
        {
            ulong result = 1;

            for (int i = 0; i < power; i++)
            {
                result *= baseIn;
            }

            return result;
        }

        static ulong GetSum(string words, ulong baseIn)
        {
            ulong sum = 0;
            int power = 0;

            for (int i = words.Length - 1; i >= 0; i--)
            {
                ulong digit = ulong.Parse(words[i].ToString());
                sum += (digit * GetPower(baseIn, power));
                power++;
            }

            return sum;
        }
    }
}
