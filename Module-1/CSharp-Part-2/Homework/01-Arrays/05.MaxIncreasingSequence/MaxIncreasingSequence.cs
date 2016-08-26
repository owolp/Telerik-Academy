using System;

namespace MaxIncreasingSequence
{
    class MaxIncreasingSequence
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int currentIncSeq = numbers[0];
            int maxIncSeq = 0;

            int currentCounter = 1;
            int maxCounter = 0;

            for (int i = 1; i < n; i++)
            {
                if (numbers[i] > numbers[i - 1])
                {
                    currentIncSeq += numbers[i];

                    if (currentIncSeq > maxIncSeq)
                    {
                        maxIncSeq = currentIncSeq;
                        currentCounter++;
                        if (currentCounter > maxCounter)
                        {
                            maxCounter = currentCounter;
                        }
                    }
                }
                else
                {
                    currentIncSeq = numbers[i];
                    maxIncSeq = 0;
                    currentCounter = 1;
                }
            }
            Console.WriteLine(maxCounter);
        }
    }
}