namespace JoroTheRabbit
{
    using System;
    using System.Linq;

    class JoroTheRabbit
    {
        static void Main()
        {
            //string[] input = Console.ReadLine().Split(new[] { ',',' '}, StringSplitOptions.RemoveEmptyEntries);
            //int[] numbers = new int[input.Length];
            //for (int i = 0; i < input.Length; i++)
            //{
            //    numbers[i] = int.Parse(input[i]);
            //}

            int[] numbers = Console.ReadLine().Split(',').Select(x => Convert.ToInt32(x)).ToArray();

            int maxLength = 0;

            for (int startIndex = 0; startIndex < numbers.Length; startIndex++)
            {
                for (int step = 1; step < numbers.Length; step++)
                {
                    int currentIndex = startIndex;
                    int nextIndex = (currentIndex + step) % numbers.Length;
                    int currentLength = 1;

                    while (nextIndex != startIndex)
                    {
                        if (numbers[currentIndex] >= numbers[nextIndex])
                        {
                            break;
                        }

                        currentLength++;
                        currentIndex = nextIndex;

                        if (currentIndex + step >= numbers.Length)
                        {
                            nextIndex = (currentIndex + step) % numbers.Length;
                        }
                        else
                        {
                            nextIndex = currentIndex + step;
                        }
                    }

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                    }

                }
            }

            Console.WriteLine(maxLength);
        }
    }
}
