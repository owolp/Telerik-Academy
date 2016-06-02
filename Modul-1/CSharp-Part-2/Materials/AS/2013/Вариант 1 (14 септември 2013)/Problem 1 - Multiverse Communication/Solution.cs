namespace MultiverseCommunication
{
    using System;

    public class Multiverse
    {
        // converts number from "multiverse" number to normal 13-th based number
        public static long ConvertMultiverseNumber(string input)
        {
            long result = 0;

            for (int i = 0, j = input.Length / 3 - 1; i < input.Length; i += 3, j--)
            {
                int currentDigit = ConvertDigitFromMultiverse(input.Substring(i, 3));

                result += currentDigit * PowerOfThirdteen(j);
            }

            return result;
        }

        // converts from "multiverse" digit to normal 13-th based digit
        public static int ConvertDigitFromMultiverse(string multiverseDigit)
        {
            switch (multiverseDigit)
            {
                case "CHU": return 0;
                case "TEL": return 1;
                case "OFT": return 2;
                case "IVA": return 3;
                case "EMY": return 4;
                case "VNB": return 5;
                case "POQ": return 6;
                case "ERI": return 7;
                case "CAD": return 8;
                case "K-A": return 9;
                case "IIA": return 10;
                case "YLO": return 11;
                case "PLA": return 12;
                default: throw new ArgumentException();
            }
        }

        // get the power of 13
        public static long PowerOfThirdteen(int power)
        {
            long result = 1;

            for (int i = 0; i < power; i++)
            {
                result *= 13;
            }

            return result;
        }

        public static void Main()
        {
            Console.WriteLine(ConvertMultiverseNumber(Console.ReadLine()));
        }
    }
}
