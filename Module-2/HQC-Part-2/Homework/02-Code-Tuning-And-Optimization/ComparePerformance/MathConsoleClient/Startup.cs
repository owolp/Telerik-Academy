namespace MathConsoleClient
{
    using System;
    using Math;
    using Math.Enumerators;

    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("Task 2. Compare simple Maths");
            Console.WriteLine(new string('=', 60));

            Console.WriteLine(Simple.CompareIntPerformance(SimpleOperations.Add));
            Console.WriteLine(Simple.CompareLongPerformance(SimpleOperations.Add));
            Console.WriteLine(Simple.CompareFloatPerformance(SimpleOperations.Add));
            Console.WriteLine(Simple.CompareDoublePerformance(SimpleOperations.Add));
            Console.WriteLine(Simple.CompareDecimalPerformance(SimpleOperations.Add));

            Console.WriteLine(new string('=', 60));

            Console.WriteLine(Simple.CompareIntPerformance(SimpleOperations.Divide));
            Console.WriteLine(Simple.CompareLongPerformance(SimpleOperations.Divide));
            Console.WriteLine(Simple.CompareFloatPerformance(SimpleOperations.Divide));
            Console.WriteLine(Simple.CompareDoublePerformance(SimpleOperations.Divide));
            Console.WriteLine(Simple.CompareDecimalPerformance(SimpleOperations.Divide));

            Console.WriteLine(new string('=', 60));

            Console.WriteLine(Simple.CompareIntPerformance(SimpleOperations.Multiply));
            Console.WriteLine(Simple.CompareLongPerformance(SimpleOperations.Multiply));
            Console.WriteLine(Simple.CompareFloatPerformance(SimpleOperations.Multiply));
            Console.WriteLine(Simple.CompareDoublePerformance(SimpleOperations.Multiply));
            Console.WriteLine(Simple.CompareDecimalPerformance(SimpleOperations.Multiply));

            Console.WriteLine(new string('=', 60));

            Console.WriteLine(Simple.CompareIntPerformance(SimpleOperations.Subtract));
            Console.WriteLine(Simple.CompareLongPerformance(SimpleOperations.Subtract));
            Console.WriteLine(Simple.CompareFloatPerformance(SimpleOperations.Subtract));
            Console.WriteLine(Simple.CompareDoublePerformance(SimpleOperations.Subtract));
            Console.WriteLine(Simple.CompareDecimalPerformance(SimpleOperations.Subtract));

            Console.WriteLine(new string('=', 60));
            Console.WriteLine("Task 3. Compare advanced Maths");
            Console.WriteLine(new string('=', 60));

            Console.WriteLine(Advanced.CompareFloatPerformance(AdvancedOperations.Log));
            Console.WriteLine(Advanced.CompareFloatPerformance(AdvancedOperations.Sinus));
            Console.WriteLine(Advanced.CompareFloatPerformance(AdvancedOperations.Sqrt));

            Console.WriteLine(new string('=', 60));

            Console.WriteLine(Advanced.CompareDoublePerformance(AdvancedOperations.Log));
            Console.WriteLine(Advanced.CompareDoublePerformance(AdvancedOperations.Sinus));
            Console.WriteLine(Advanced.CompareDoublePerformance(AdvancedOperations.Sqrt));

            Console.WriteLine(new string('=', 60));

            Console.WriteLine(Advanced.CompareDecimalPerformance(AdvancedOperations.Log));
            Console.WriteLine(Advanced.CompareDecimalPerformance(AdvancedOperations.Sinus));
            Console.WriteLine(Advanced.CompareDecimalPerformance(AdvancedOperations.Sqrt));

            Console.WriteLine(new string('=', 60));
        }
    }
}
