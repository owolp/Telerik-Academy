//08. Digit as Word
//Description
//Write a program that read a digit(0-9) from the console, and depending on the input, shows the digit as a word(in English).
//    Print "not a digit" in case of invalid input.
//    Use a switch statement.
//Input
//    The input consists of one line only, which contains the digit.
//Output
//    Output a single line - should the input be a valid digits, print the English word for the digits.Otherwise, print "not a digit".
//Constraints
//    The input will never be an empty line.
//    Time limit: 0.1s
//    Memory limit: 16MB

using System;

namespace DigitAsWord
{
    class DigitAsWord
    {
        static void Main()
        {
            string digit = Console.ReadLine();
            string digitAsWord;

            switch (digit)
            {
                case "0":
                    digitAsWord = "zero";
                    break;
                case "1":
                    digitAsWord = "one";
                    break;
                case "2":
                    digitAsWord = "two";
                    break;
                case "3":
                    digitAsWord = "three";
                    break;
                case "4":
                    digitAsWord = "four";
                    break;
                case "5":
                    digitAsWord = "five";
                    break;
                case "6":
                    digitAsWord = "six";
                    break;
                case "7":
                    digitAsWord = "seven";
                    break;
                case "8":
                    digitAsWord = "eight";
                    break;
                case "9":
                    digitAsWord = "nine";
                    break;
                default:
                    digitAsWord = "not a digit";
                    break;
            }

            Console.WriteLine(digitAsWord);
        }
    }
}