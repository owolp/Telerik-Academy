using System;
using System.Linq;

namespace GetLargestNumber
{
    class GetLargestNumber
    {
        static void Main()
        {
            string[] numbers = GetNumbersArr();

            int a = int.Parse(numbers[0]);
            int b = int.Parse(numbers[1]);
            int c = int.Parse(numbers[2]);

            int max = GetMax(c, GetMax(a, b));

            Console.WriteLine(max);
        }

        static string[] GetNumbersArr()
        {
            var input = Console.ReadLine();

            string[] numbers = input.Split(' ').ToArray();

            return numbers;
        }

        static int GetMax(int firstNumber, int secondNumber)

        {
            return (firstNumber > secondNumber ? firstNumber : secondNumber);
        }
    }
}