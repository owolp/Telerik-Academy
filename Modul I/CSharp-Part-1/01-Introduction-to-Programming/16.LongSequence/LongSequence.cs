//16. LongSequence
//Description
//Write a program that prints the first 1000 members of the sequence: 2, -3, 4, -5, 6, -7, …
//    You might need to learn how to use loops in C# (search in Internet).
//Input
//    There is no input for this task.
//Output
//    Output the first 1000 members of the sequence, each on a separate line.
//2
//-3
//4
//-5
//6
//...
//Constraints
//    Time limit: 0.1s
//    Memory limit: 8MB

using System;

namespace LongSequence
{
    class LongSequence
    {
        static void Main()
        {
            var firstNumber = 2;
            var numbersLength = 1000;

            for (int i = 0; i < numbersLength; i++)
            {
                var number = firstNumber + i;
                if (number % 2 == 0)
                {
                    Console.WriteLine(number);
                }
                else
                {
                    Console.WriteLine("-{0}", number);
                }
            }
        }
    }
}
