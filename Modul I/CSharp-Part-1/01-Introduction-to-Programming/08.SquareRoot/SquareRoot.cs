//08. Square Root
//Description
//Write a program that calculates the square root of the number 12345 and prints it on the console.
//Input
//    There is no input for this task.
//Output
//    Write a single number on the console - the square root of the number 12345.
//Constraints
//    Time limit: 0.1s
//    Memory limit: 16MB

using System;
using System.Threading;
using System.Globalization;


namespace SquareRoot
{
    class SquareRoot
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var number = 12345;
            var numberSquareRoot = Math.Sqrt(number);
            Console.WriteLine(numberSquareRoot);
        }
    }
}
