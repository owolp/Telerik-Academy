namespace Math
{
    using System;
    using System.Diagnostics;
    using Enumerators;

    public class Advanced
    {
        private const int AddNumber = 1;
        private const int TestRepeateTimes = 1000000;

        private const string InvalidOperation = "The provided operation is not valid!";

        public static string CompareFloatPerformance(AdvancedOperations operation)
        {
            var isEnumDefined = Enum.IsDefined(typeof(AdvancedOperations), operation);

            if (!isEnumDefined)
            {
                throw new InvalidOperationException(InvalidOperation);
            }

            Stopwatch stopWatch = new Stopwatch();

            float result = 0;
            stopWatch.Start();

            for (int i = 0; i < TestRepeateTimes; i++)
            {
                switch (operation)
                {
                    case AdvancedOperations.Log:
                        result = (float)Math.Log(AddNumber);
                        break;
                    case AdvancedOperations.Sinus:
                        result = (float)Math.Sin(AddNumber);
                        break;
                    case AdvancedOperations.Sqrt:
                        result = (float)Math.Sqrt(AddNumber);
                        break;
                }
            }

            stopWatch.Stop();

            string operationAsString = operation.ToString();
            string resultAsString = result.GetType().Name.ToString();
            string toString = ToString(operationAsString, resultAsString, stopWatch);

            return toString;
        }

        public static string CompareDoublePerformance(AdvancedOperations operation)
        {
            var isEnumDefined = Enum.IsDefined(typeof(AdvancedOperations), operation);

            if (!isEnumDefined)
            {
                throw new InvalidOperationException(InvalidOperation);
            }

            Stopwatch stopWatch = new Stopwatch();

            double result = 0;
            stopWatch.Start();

            for (int i = 0; i < TestRepeateTimes; i++)
            {
                switch (operation)
                {
                    case AdvancedOperations.Log:
                        result = Math.Log(AddNumber);
                        break;
                    case AdvancedOperations.Sinus:
                        result = Math.Sin(AddNumber);
                        break;
                    case AdvancedOperations.Sqrt:
                        result = Math.Sqrt(AddNumber);
                        break;
                }
            }

            stopWatch.Stop();

            string operationAsString = operation.ToString();
            string resultAsString = result.GetType().Name.ToString();
            string toString = ToString(operationAsString, resultAsString, stopWatch);

            return toString;
        }

        public static string CompareDecimalPerformance(AdvancedOperations operation)
        {
            var isEnumDefined = Enum.IsDefined(typeof(AdvancedOperations), operation);

            if (!isEnumDefined)
            {
                throw new InvalidOperationException(InvalidOperation);
            }

            Stopwatch stopWatch = new Stopwatch();

            decimal result = 0;
            stopWatch.Start();

            for (int i = 0; i < TestRepeateTimes; i++)
            {
                switch (operation)
                {
                    case AdvancedOperations.Log:
                        result = (decimal)Math.Log(AddNumber);
                        break;
                    case AdvancedOperations.Sinus:
                        result = (decimal)Math.Sin(AddNumber);
                        break;
                    case AdvancedOperations.Sqrt:
                        result = (decimal)Math.Sqrt(AddNumber);
                        break;
                }
            }

            stopWatch.Stop();

            string operationAsString = operation.ToString();
            string resultAsString = result.GetType().Name.ToString();
            string toString = ToString(operationAsString, resultAsString, stopWatch);

            return toString;
        }

        private static string ToString(string operation, string type, Stopwatch stopWatch)
        {
            string result = $"{operation,-10} {type,-20} {stopWatch.Elapsed}";

            return result;
        }
    }
}
