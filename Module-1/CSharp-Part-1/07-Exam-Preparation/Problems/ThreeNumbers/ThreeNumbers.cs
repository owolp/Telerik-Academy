using System;

namespace ThreeNumbers
{
    class ThreeNumbers
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int biggestNumber = a;
            if (b > a)
            {
                if (b > c)
                {
                    biggestNumber = b;
                }
                else
                {
                    biggestNumber = c;
                }
            }
            else
            {
                if (c > a)
                {
                    biggestNumber = c;
                }
            }

            int lowestNumber = a;
            if (b < a)
            {
                if (b < c)
                {
                    lowestNumber = b;
                }
                else
                {
                    lowestNumber = c;
                }
            }
            else
            {
                if (c < a)
                {
                    lowestNumber = c;
                }
            }

            decimal sum = (decimal)(a + b + c) / 3;

            Console.WriteLine(biggestNumber);
            Console.WriteLine(lowestNumber);
            Console.WriteLine("{0:F2}", sum);
        }
    }
}
