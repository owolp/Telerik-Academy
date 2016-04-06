//13. Comparing Floats
//Description
//Write a program that safely compares two floating-point numbers(double) with precision eps = 0.000001.
//Note: Two floating-point numbers a and b cannot be compared directly by a == b because of the nature of the floating-point arithmetic.
//Therefore, we assume two numbers are equal if they are more closely to each other than a fixed constant eps.
//Input
//    On the first line you will receive the first floating-point number
//    On the second line you will receive the second floating-point number
//Hint: Use double.Parse(Console.ReadLine()) to read input
//Output
//    Print true if the numbers are equal or false if they are not
//Constraints
//    Time limit: 0.1s
//    Memory limit: 8MB

using System;

namespace ComparingFloats
{
    class ComparingFloats
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            double sum = Math.Abs(a - b);

            double eps = 0.000001;

            bool result = sum < eps;

            Console.WriteLine(result == true ? "true" : "false");
        }
    }
}