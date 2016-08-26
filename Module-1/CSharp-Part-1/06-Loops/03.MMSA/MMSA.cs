//03. MMSA(Min, Max, Sum, Average) of N Numbers
//Description
//Write a program that reads from the console a sequence of N integer numbers and returns the minimal, the maximal number, the sum and the average of all numbers
//(displayed with 2 digits after the decimal point).
//    The input starts by the number N(alone in a line) followed by N lines, each holding an integer number.
//   The output is like in the examples below.
//Input
//   On the first line, you will receive the number N.
//   On each of the next N lines, you will receive a single floating-point number.
//Output
//   You output must always consist of exactly 4 lines - the minimal element on the first line, the maximal on the second, the sum on the third and the average on the fourth,
//in the following format:
//min= 3
//max= 6
//sum= 9
//avg= 4.5
//Constraints
//    1 <= N <= 1000
//    All numbers will be valid floating-point numbers that will be in the range [-10000, 10000]
//    Time limit: 0.1s
//   Memory limit: 16MB

using System;
using System.Threading;
using System.Globalization;

namespace MMSA
{
    class MMSA
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            int sequence = int.Parse(Console.ReadLine());

            double minValue = 0;
            double maxValue = 0;
            double sum = 0;
            double average = 0;


            for (int i = 0; i < sequence; i++)
            {
                var line = Console.ReadLine();
                line = line.Replace(',', '.');
                double number = double.Parse(line);

                if (i == 0)
                {
                    minValue = number;
                    maxValue = number;
                }
                else if (number < minValue)
                {
                    minValue = number;
                }
                else if (number > maxValue)
                {
                    maxValue = number;
                }

                sum += number;
            }
            average = sum / sequence;
            Console.WriteLine("min={0:F2}\n" +
                              "max={1:F2}\n" +
                              "sum={2:F2}\n" +
                              "avg={3:F2}\n", minValue, maxValue, sum, average);
        }
    }
}