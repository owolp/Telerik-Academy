using System;

public class Program
{
    public static void Main()
    {
        var t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            var line = Console.ReadLine();
            var numbersAsString = line.Split(' ');
            var numbers = new long[numbersAsString.Length];
            for (int j = 0; j < numbersAsString.Length; j++)
            {
                numbers[j] = int.Parse(numbersAsString[j]);
            }

            var answer = IsDecreasing(numbers);
            Console.WriteLine(answer);
        }
    }

    private static bool IsDecreasing(long[] numbers)
    {
        if (numbers.Length <= 2)
        {
            return true;
        }

        long last = Math.Abs(numbers[1] - numbers[0]);
        for (int i = 2; i < numbers.Length; i++)
        {
            long diff = Math.Abs(numbers[i] - numbers[i - 1]);
            if (last - diff != 1 && last - diff != 0)
            {
                return false;
            }

            last = diff;
        }

        return true;
    }
}
