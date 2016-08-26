using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AstrologicalDigits
{
    class AstrologicalDigits
    {
        static void Main()
        {
            var input = Console.ReadLine();
            input = Regex.Replace(input, "[^0-9]", "");
            BigInteger number = BigInteger.Parse(input);

            int sum = 0;
            do
            {
                sum = 0;
                foreach (char ch in input)
                {
                    switch (ch)
                    {
                        case '1': sum += 1; break;
                        case '2': sum += 2; break;
                        case '3': sum += 3; break;
                        case '4': sum += 4; break;
                        case '5': sum += 5; break;
                        case '6': sum += 6; break;
                        case '7': sum += 7; break;
                        case '8': sum += 8; break;
                        case '9': sum += 9; break;
                        default:
                            break;
                    }
                }
                number = sum;
                input = Convert.ToString(number);
            } while (number > 9);

            Console.WriteLine(sum);
        }
    }
}
