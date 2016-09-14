namespace Exceptions_ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using ExceptionsHomework;
    using ExceptionsHomework.Contracts;
    using ExceptionsHomework.Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var substr = Extentions.Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = Extentions.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(String.Join(" ", subarr));

            var allarr = Extentions.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(String.Join(" ", allarr));

            var emptyarr = Extentions.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(String.Join(" ", emptyarr));

            Console.WriteLine(Extentions.ExtractEnding("I love C#", 2));
            Console.WriteLine(Extentions.ExtractEnding("Nakov", 4));
            Console.WriteLine(Extentions.ExtractEnding("beer", 4));

            try
            {
                Console.WriteLine(Extentions.ExtractEnding("Hi", 100));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            var number23IsPrime = Extentions.CheckPrime(23);
            Console.WriteLine($"23 is prime - {number23IsPrime}");

            var number33IsPrime = Extentions.CheckPrime(33);
            Console.WriteLine($"33 is prime - {number33IsPrime}");

            var peterExams = new List<IExam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
    }
}
