namespace MethodsConsoleClient
{
    using System;
    using Methods.Models;

    public class Startup
    {
        public static void Main()
        {
            var triangle = new Triangle(3, 4, 5);
            Console.WriteLine(triangle.CalculateArea());

            var method = new Method();

            var numberToDigit = method.NumberToDigit(5);
            Console.WriteLine(numberToDigit);

            var maxNumber = method.FindMax(5, -1, 3, 2, 14, 2, 3);
            Console.WriteLine(maxNumber);

            var firstPrintAsNumber = method.PrintAsNumber(1.3, "f");
            Console.WriteLine(firstPrintAsNumber);

            var secondPrintAsNumber = method.PrintAsNumber(0.75, "%");
            Console.WriteLine(secondPrintAsNumber);

            var thirdPrintAsNumber = method.PrintAsNumber(2.30, "r");
            Console.WriteLine(thirdPrintAsNumber);

            var calculatedDistance = method.CalcDistance(3, -1, 3, 2.5);
            Console.WriteLine(calculatedDistance);

            Student firstStudent = new Student("Peter", "Ivanov", "From Sofia, born at 17.03.1992");
            Student secondStudent = new Student("Stella", "Markova", "From Vidin, gamer, high results, born at 03.11.1993");

            Console.WriteLine($"{firstStudent.FirstName} older than {secondStudent.FirstName} -> {firstStudent.IsOlderThan(secondStudent)}");
        }
    }
}
