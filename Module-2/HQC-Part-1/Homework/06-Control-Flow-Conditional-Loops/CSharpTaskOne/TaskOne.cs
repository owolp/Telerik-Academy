namespace CSharpTaskOne
{
    using System;

    public class TaskOne
    {
        private const double FirstMagicNumber = 123123123123.0;

        private const double SecondMagicNumber = 317.0;

        public static void Main()
        {
            var readBirdsFromConsole = Console.ReadLine();
            double birds = double.Parse(readBirdsFromConsole);

            var readFeathersFromConsole = Console.ReadLine();
            double feathers = double.Parse(readFeathersFromConsole);

            double averageFeathers = 0.0;

            if (birds != 0)
            {
                averageFeathers = feathers / birds;

                if (birds % 2 == 0)
                {
                    averageFeathers *= FirstMagicNumber;
                }
                else
                {
                    averageFeathers /= SecondMagicNumber;
                }
            }

            Console.WriteLine($"{averageFeathers:F4}");
        }
    }
}
