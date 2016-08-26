using System;

namespace AngryFemaleGPS
{
    class AngryFemaleGPS
    {
        static void Main()
        {
            var input = Console.ReadLine();
            long n = long.Parse(input);
            n = Math.Abs(n);

            long evenSum = 0;
            long oddSum = 0;

            while (n > 0)
            {
                var number = n % 10;

                if (number % 2 == 0)
                {
                    evenSum += number;
                }
                else
                {
                    oddSum += number;
                }

                n /= 10;
            }

            string direction;
            long sum = 0;

            if (evenSum > oddSum)
            {
                direction = "right";
                sum = evenSum;
            }
            else if (oddSum > evenSum)
            {
                direction = "left";
                sum = oddSum;
            }
            else
            {
                direction = "straight";
                sum = evenSum;
            }

            Console.WriteLine(direction + " " + sum);
        }
    }
}