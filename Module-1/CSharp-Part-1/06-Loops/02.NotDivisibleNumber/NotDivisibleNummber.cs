//02. Not Divisible Numbers
//Description
//Write a program that reads from the console a positive integer N and prints all the numbers from 1 to N not divisible by 3 or 7, on a single line, separated by a space.
//Input
//    Will always consists of one valid integer number - the number N.
//Output
//    Should always consists of the numbers from 1 to N, which are not divisible by 3 or 7, separated by a whitespace.
//Constraints
//    1 < N< 1500
//    Time limit: 0.1s
//    Memory limit: 16MB

using System;

namespace NotDivisibleNumber
{
    class NotDivisibleNummber
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                bool notDivisibleBy3 = i % 3 != 0;
                bool notDivisibleBy7 = i % 7 != 0;

                if (notDivisibleBy3 & notDivisibleBy7)
                {
                    if (i == number)
                    {
                        Console.Write("{0}", i);
                    }
                    else
                    {
                        Console.Write("{0} ", i);
                    }
                }
            }
            Console.WriteLine();
        }
    }
}