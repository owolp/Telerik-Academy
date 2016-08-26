using System;

namespace ReverseNumber
{
    class ReverseNumber
    {
        static void Main()
        {
            Console.WriteLine(ReverseNum(Console.ReadLine()));
        }

        static string ReverseNum(string number)
        {
            string reversedNumber = string.Empty;

            foreach (char symbol in number)
            {
                reversedNumber = symbol + reversedNumber;
            }

            return reversedNumber;
        }
    }
}