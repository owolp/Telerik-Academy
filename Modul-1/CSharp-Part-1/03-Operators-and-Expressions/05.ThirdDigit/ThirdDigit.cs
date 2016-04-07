//05. Third digit
//Description
//Write a program that reads an integer N from the console and prints true if the third digit of the N is 7, or "false THIRD_DIGIT", where you should print the third digits of N.
//    The counting is done from right to left, meaning 123456's third digit is 4.
//Input
//    The input will always consist of exactly one line, containing the number N.
//Output
//    The output should be a single line - print whether the third digit is 7, following the format described above.
//Constraints
//    N will always be valid non-negative integer number.
//    Time limit: 0.1s
//    Memory limit: 8MB

using System;

namespace ThirdDigit
{
    class ThirdDigit
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            number /= 100;
            number %= 10;

            Console.WriteLine(number == 7 ? "true" : "false");
        }
    }
}