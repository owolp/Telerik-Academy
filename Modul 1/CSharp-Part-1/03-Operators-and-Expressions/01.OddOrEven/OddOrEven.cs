//01. Odd or Even
//Description
//Write a program that reads an integer from the console, uses an expression to check if given integer is odd or even, and prints "even NUMBER" or "odd NUMBER",
//where you should print the input number's value instead of NUMBER.
//Input
//    On the single input line you will receive an integer number.
//Output
//    Output a single line - if the number is even, output even, followed by a whitespace and the value of the number. Otherwise, print odd, again followed by a whitespace and the number's value. 
//See the sample tests.
//Constraints
//    The input number will always be a valid integer number.
//    The input number will always be in the range [-30, 30].
//    Time limit: 0.1s
//    Memory limit: 8MB

using System;

namespace OddOrEven
{
    class OddOrEven
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            if (number % 2 == 0)
            {
                Console.WriteLine("even {0}", number);
            }
            else
            {
                Console.WriteLine("odd {0}", number);
            }
        }
    }
}