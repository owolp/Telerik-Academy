namespace CSharpTaskTwo
{
    using System;

    public class TaskTwo
    {
        public static void Main()
        {
            int numberOfBuses = ReadInput();

            int numberOfBusesGroups = 0;
            int currentBusSpeed = ReadInput();
            for (int bus = 1; bus < numberOfBuses; bus++)
            {
                int nextBusSpeed = ReadInput();

                if (currentBusSpeed < nextBusSpeed)
                {
                    continue;
                }
                else
                {
                    numberOfBusesGroups += 1;
                }

                currentBusSpeed = nextBusSpeed;
            }

            if (currentBusSpeed < numberOfBuses - 1)
            {
                numberOfBusesGroups += 1;
            }

            Console.WriteLine(numberOfBusesGroups);
        }

        public static int ReadInput()
        {
            string input = Console.ReadLine();
            int inputToInt = int.Parse(input);

            return inputToInt;
        }
    }
}
