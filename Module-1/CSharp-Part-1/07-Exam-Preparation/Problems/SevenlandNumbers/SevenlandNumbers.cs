using System;

namespace SevenlandNumbers
{
    class SevenlandNumbers
    {
        static void Main()
        {
            int k = int.Parse(Console.ReadLine());
            int result = k + 1;

            int firstDigit = k % 10;
            k /= 10;
            int secondDigit = k % 10;
            k /= 10;
            int thirdDigit = k % 10;

            if (firstDigit == 6)
            {
                firstDigit = 0;
                secondDigit++;
                if (secondDigit == 7)
                {
                    secondDigit = 0;
                    thirdDigit++;
                    if (thirdDigit == 7)
                    {
                        thirdDigit = 10;
                    }
                }
                result = 1 * firstDigit + 10 * secondDigit + 100 * thirdDigit;
            }

            Console.WriteLine(result);
        }
    }
}