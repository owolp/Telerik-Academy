using System;

namespace RandomNumbers
{
    class RandomNumbers
    {
        static void Main()
        {
            Random number = new Random();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(number.Next(100, 200));
            }
        }
    }
}