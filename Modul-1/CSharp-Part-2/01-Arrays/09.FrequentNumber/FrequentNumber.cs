using System;

namespace FrequentNumber
{
    class FrequentNumber
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(numbers);

            int number = numbers[0];
            int count = 1;
            int maxCount = 0;

            for (int i = 1; i < n; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    count++;

                    if (count > maxCount)
                    {
                        maxCount = count;
                        number = numbers[i];
                    }
                }
                else
                {
                    count = 1;
                }                
            }

            Console.WriteLine("{0} ({1} times)", number, maxCount);
        }
    }
}