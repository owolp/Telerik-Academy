using System;

namespace Money
{
    class Money
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());
            double p = double.Parse(Console.ReadLine());

            int paperPerStudent = n * s;
            double realmsNeeded = (double)paperPerStudent / 400;
            double realmsPrice = realmsNeeded * p;

            Console.WriteLine("{0:F3}", realmsPrice);
        }
    }
}
