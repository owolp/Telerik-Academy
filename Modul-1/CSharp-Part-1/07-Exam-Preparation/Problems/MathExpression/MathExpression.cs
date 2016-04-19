using System;
using System.Threading;
using System.Globalization;

namespace MathExpression
{
    class MathExpression
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            decimal n = decimal.Parse(Console.ReadLine());
            decimal m = decimal.Parse(Console.ReadLine());
            decimal p = decimal.Parse(Console.ReadLine());

            decimal upperSum = (n * n) + (1 / (m * p)) + 1337;
            decimal lowerSum = n - ((decimal)128.523123123 * p);

            int mod = (int)(m % 180);
            decimal sinSum = (decimal)Math.Sin((double)mod);

            decimal result = (upperSum / lowerSum) + sinSum;

            Console.WriteLine("{0:F6}", result);

        }
    }
}