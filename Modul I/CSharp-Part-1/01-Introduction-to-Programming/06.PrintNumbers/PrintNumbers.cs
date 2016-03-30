//06. Print Numbers
//Description
//Write a program that prints the numbers 1, 101 and 1001, each on a separate line.Submit the code at the contest in www.bgcoder.com.
//Input
//    There is no input for this task.
//Output
//    You program should print the numbers 1, 101 and 1001 on three separate lines.
//Constraints
//    Time limit: 0.1s
//    Memory limit: 16MB

using System;

namespace PrintNumbers
{
    class PrintNumbers
    {
        static void Main()
        {
            var number1 = 1;
            var number2 = 101;
            var number3 = 1001;
            Console.WriteLine("{0}\n{1}\n{2}", number1, number2, number3);
        }
    }
}
