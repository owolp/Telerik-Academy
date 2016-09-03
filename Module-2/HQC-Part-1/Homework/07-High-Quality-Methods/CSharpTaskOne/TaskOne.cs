namespace CSharpTaskOne
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class TaskOne
    {
        private static readonly Dictionary<string, BigInteger> Dictionary = new Dictionary<string, BigInteger>()
        {
            { "cad", 0 },
            { "xoz", 1 },
            { "nop", 2 },
            { "cyk", 3 },
            { "min", 4 },
            { "mar", 5 },
            { "kon", 6 },
            { "iva", 7 },
            { "ogi", 8 },
            { "yan", 9 },
        };

        private static readonly Dictionary<BigInteger, string> ReversedDictionary = new Dictionary<BigInteger, string>()
        {
            { 0, "cad" },
            { 1, "xoz" },
            { 2, "nop" },
            { 3, "cyk" },
            { 4, "min" },
            { 5, "mar" },
            { 6, "kon" },
            { 7, "iva" },
            { 8, "ogi" },
            { 9, "yan" },
        };

        public static void Main()
        {
            var firstNumber = Console.ReadLine();
            var operation = Console.ReadLine();
            var secondNumber = Console.ReadLine();

            var firstNumberToSpecialToBase = SpecialToBase(firstNumber);
            var firstNumberBase = BigInteger.Parse(firstNumberToSpecialToBase);

            var secondNumberToSpecialBase = SpecialToBase(secondNumber);
            var secondNumberBase = BigInteger.Parse(secondNumberToSpecialBase);

            BigInteger result = 0;
            if (operation == "-")
            {
                result = firstNumberBase - secondNumberBase;
            }
            else
            {
                result = firstNumberBase + secondNumberBase;
            }

            var decToBase = DecimalToBase(10, result);
            Console.WriteLine(decToBase);
        }

        public static string SpecialToBase(string word)
        {
            string result = string.Empty;
            string partialInput = string.Empty;

            for (int i = 0; i < word.Length; i++)
            {
                var currentWord = word[i];
                partialInput += currentWord;

                var dictionaryContainsKey = Dictionary.ContainsKey(partialInput);
                if (dictionaryContainsKey)
                {
                    var dictionaryWord = Dictionary[partialInput];
                    result += dictionaryWord;
                    partialInput = string.Empty;
                }
            }

            return result;
        }

        public static string DecimalToBase(BigInteger @base, BigInteger decimalNumber)
        {
            string baseNumber = string.Empty;

            while (decimalNumber > 0)
            {
                BigInteger digit = decimalNumber % @base;

                if (digit >= 0 && digit <= @base)
                {
                    var reversedWord = ReversedDictionary[digit];
                    baseNumber = reversedWord + baseNumber;
                }

                decimalNumber /= @base;
            }

            return baseNumber;
        }
    }
}
