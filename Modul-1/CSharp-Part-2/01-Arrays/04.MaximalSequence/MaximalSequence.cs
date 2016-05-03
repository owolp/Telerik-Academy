using System;

namespace MaximalSequence
{
    class MaximalSequence
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int counter = 1;
            int maxSequence = 0;

            for (int i = 1; i < n; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    counter++;
                    if (counter > maxSequence)
                    {
                        maxSequence = counter;
                    }
                }
                else
                {
                    counter = 1;
                }
            }

            Console.WriteLine(maxSequence);
        }
    }
}