using System;

namespace ABC
{
    class ABC
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            //BGCoder 70/100
            //int biggestNumber = Math.Max(a, Math.Max(b, c));
            //int lowestNumber = Math.Min(a, Math.Max(b, c));

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
            Console.WriteLine("{0:F3}", sum);
        }
    }
}