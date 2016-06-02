using System;

internal class Program
{
    static Random rand = new Random();
    private static void Main(string[] args)
    {
        for (int i = 1; i <= 10; i++)
        {
            int lowerBound = 0;
            if (rand.Next() % 3 < 2)
            {
                lowerBound = -50000000;
            }

            GenerateRandom(rand.Next(-200000000, 200000000), rand.Next(lowerBound, 50000000), i * 2);
        }
    }

    private static void GenerateCorrect(int start, int change, int count)
    {
        var last = start;
        for (int i = 0; i < count; i++)
        {
            Console.Write("{0} ", last);

            if (rand.Next() % 2 == 0)
            {
                last += change;
            }
            else
            {
                last -= change;
            }

            if (rand.Next() % 2 == 0 && change > 0)
            {
                change--;
            }
        }

        Console.WriteLine();
    }

    private static void GenerateRandom(int start, int change, int count)
    {
        var last = start;
        for (int i = 0; i < count; i++)
        {
            Console.Write("{0} ", last);

            if (rand.Next() % 2 == 0)
            {
                last += change;
            }
            else
            {
                last -= change;
            }

            if (rand.Next() % 2 == 0)
            {
                change--;
            }
        }

        Console.WriteLine();
    }
}
