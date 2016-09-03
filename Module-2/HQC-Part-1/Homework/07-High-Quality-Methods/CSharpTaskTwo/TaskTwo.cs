namespace CSharpTaskTwo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TaskTwo
    {
        public static void Main()
        {
            var numbers = ReadInput().Split(' ').Select(long.Parse).ToArray();
            var input = ReadInput();

            IList<string> steps = new List<string>();
            while (input != "stop")
            {
                var tempArr = input.Split(' ').ToArray();

                foreach (var item in tempArr)
                {
                    steps.Add(item);
                }

                input = ReadInput();
            }

            int index = 0;
            long currentPosition = 0;
            long result = 0;
            IList<long> roundResults = new List<long>();

            for (int i = 0; i < steps.Count / 3; i++)
            {
                long howManyTimesToMove = long.Parse(steps[index]);
                long stepsToMove = long.Parse(steps[index + 2]);
                string direction = steps[index + 1];

                for (long timesToMove = 0; timesToMove < howManyTimesToMove; timesToMove++)
                {
                    if (direction == "right")
                    {
                        currentPosition = currentPosition + stepsToMove;

                        if (currentPosition >= (long)numbers.Count())
                        {
                            currentPosition = currentPosition % (long)numbers.Count();
                        }

                        result += numbers[currentPosition];
                    }
                    else
                    {
                        currentPosition = (currentPosition - stepsToMove) % (long)numbers.Count();

                        if (currentPosition < 0)
                        {
                            currentPosition += (long)numbers.Count();
                        }

                        result += numbers[currentPosition];
                    }
                }

                roundResults.Add(result);
                result = 0;
                index += 3;
            }

            double finalResult = 0;
            foreach (var roundResult in roundResults)
            {
                finalResult += roundResult;
            }

            var stepsCount = steps.Count / 3;
            finalResult /= stepsCount;

            Console.WriteLine("{0:F1}", finalResult);
        }

        public static string ReadInput()
        {
            var input = Console.ReadLine();

            return input;
        }
    }
}
