using System;

namespace PeaceOfCake
{
    class PeaceOfCake
    {
        static void Main()
        {
            long a = long.Parse(Console.ReadLine());
            long b = long.Parse(Console.ReadLine());
            long c = long.Parse(Console.ReadLine());
            long d = long.Parse(Console.ReadLine());

            if (b != d)
            {
                a *= d;
                c *= b;
            }

            decimal sum = (decimal)(a + c) / (b * d);

            if (sum > 1)
            {
                Console.WriteLine((long)sum);
            }
            else
            {
                Console.WriteLine("{0:F22}", sum);
            }

            Console.WriteLine((a + c) + "/" + (b * d));
        }
    }
}