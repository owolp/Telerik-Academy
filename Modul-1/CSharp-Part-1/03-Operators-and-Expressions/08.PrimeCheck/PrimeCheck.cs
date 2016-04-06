//08. Prime Check
//Description
//Write a program that reads an integer N(which will always be less than 100 or equal) and uses an expression to check if given N is prime(i.e.it is divisible without remainder only to itself and 1).
//    Note: You should check if the number is positive
//Input
//    On the only input line you will receive the number N.
//Output
//    Output true if the number is prime and false otherwise.
//Constraints
//    N will always be a valid 32-bit integer number, which will be less than 100 or equal.
//    Time limit: 0.1s
//    Memory limit: 8MB

using System;

namespace PrimeCheck
{
    class PrimeCheck
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            int remainder = 0;
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    remainder++;
                }
            }

            var answer = "false";
            if (remainder == 2)
            {
                answer = "true";
            }

            Console.WriteLine(answer);
        }
    }
}