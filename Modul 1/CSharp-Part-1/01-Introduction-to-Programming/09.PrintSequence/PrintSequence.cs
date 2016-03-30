//09. Print Sequence
//Description
//Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...
//Input
//    There will be no input for this task.
//Output
//    Print on the console the first 10 members of the sequence from the description.Print each member on a separate line.
//2
//-3
//4
//-5
//...
//Constraints
//    Time limit: 0.1s
//    Memory limit: 16MB

using System;

namespace PrintSequence
{
    class PrintSequence
    {
        static void Main()
        {
            var firstNumber = 2;
            var numbersLength = 10;

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