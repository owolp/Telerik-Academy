using System;
using System.Collections.Generic;

namespace EnglishDigit
{
    class EnglishDigit
    {
        static void Main()
        {
            Console.WriteLine(DigitToWord[GetLastDigit(ReadNumber())]);
        }

        static Dictionary<int, string> DigitToWord = new Dictionary<int, string>()
        {
            { 1, "one"},
            { 2, "two"},
            { 3, "three"},
            { 4, "four"},
            { 5, "five"},
            { 6, "six"},
            { 7, "seven"},
            { 8, "eight"},
            { 9, "nine"},
            { 0, "zero"}
        };

        static int ReadNumber()
        {
            return int.Parse(Console.ReadLine());
        }

        static int GetLastDigit(int number)
        {
            return number % 10;
        }
    }
}