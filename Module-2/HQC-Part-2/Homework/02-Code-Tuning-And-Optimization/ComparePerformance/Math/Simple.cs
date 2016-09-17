namespace Math
{
    using System;
    using System.Diagnostics;
    using Enumerators;

    public class Simple
    {
        private const int AddNumber = 1;
        private const int TestRepeateTimes = 1000000;

        private const string InvalidOperation = "The provided operation is not valid!";

        public static string CompareIntPerformance(SimpleOperations operation)
        {
            var isEnumDefined = Enum.IsDefined(typeof(SimpleOperations), operation);

            if (!isEnumDefined)
            {
                throw new InvalidOperationException(InvalidOperation);
            }

            Stopwatch stopWatch = new Stopwatch();

            int result = 0;
            stopWatch.Start();

            for (int i = 0; i < TestRepeateTimes; i++)
            {
                switch (operation)
                {
                    case SimpleOperations.Add:
                        result += AddNumber;
                        break;
                    case SimpleOperations.Divide:
                        result /= AddNumber;
                        break;
                    case SimpleOperations.Multiply:
                        result *= AddNumber;
                        break;
                    case SimpleOperations.Subtract:
                        result -= AddNumber;
                        break;                    
                }
            }

            stopWatch.Stop();

            string operationAsString = operation.ToString();
            string resultAsString = result.GetType().Name.ToString();
            string toString = ToString(operationAsString, resultAsString, stopWatch);

            return toString;
        }

        public static string CompareLongPerformance(SimpleOperations operation)
        {
            var isEnumDefined = Enum.IsDefined(typeof(SimpleOperations), operation);

            if (!isEnumDefined)
            {
                throw new InvalidOperationException(InvalidOperation);
            }

            Stopwatch stopWatch = new Stopwatch();

            long result = 0;
            stopWatch.Start();

            for (int i = 0; i < TestRepeateTimes; i++)
            {
                switch (operation)
                {
                    case SimpleOperations.Add:
                        result += AddNumber;
                        break;
                    case SimpleOperations.Divide:
                        result /= AddNumber;
                        break;
                    case SimpleOperations.Multiply:
                        result *= AddNumber;
                        break;
                    case SimpleOperations.Subtract:
                        result -= AddNumber;
                        break;
                }
            }

            stopWatch.Stop();

            string operationAsString = operation.ToString();
            string resultAsString = result.GetType().Name.ToString();
            string toString = ToString(operationAsString, resultAsString, stopWatch);

            return toString;
        }

        public static string CompareFloatPerformance(SimpleOperations operation)
        {
            var isEnumDefined = Enum.IsDefined(typeof(SimpleOperations), operation);

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
                    case SimpleOperations.Add:
                        result += AddNumber;
                        break;
                    case SimpleOperations.Divide:
                        result /= AddNumber;
                        break;
                    case SimpleOperations.Multiply:
                        result *= AddNumber;
                        break;
                    case SimpleOperations.Subtract:
                        result -= AddNumber;
                        break;
                }
            }

            stopWatch.Stop();

            string operationAsString = operation.ToString();
            string resultAsString = result.GetType().Name.ToString();
            string toString = ToString(operationAsString, resultAsString, stopWatch);

            return toString;
        }

        public static string CompareDoublePerformance(SimpleOperations operation)
        {
            var isEnumDefined = Enum.IsDefined(typeof(SimpleOperations), operation);

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
                    case SimpleOperations.Add:
                        result += AddNumber;
                        break;
                    case SimpleOperations.Divide:
                        result /= AddNumber;
                        break;
                    case SimpleOperations.Multiply:
                        result *= AddNumber;
                        break;
                    case SimpleOperations.Subtract:
                        result -= AddNumber;
                        break;
                }
            }

            stopWatch.Stop();

            string operationAsString = operation.ToString();
            string resultAsString = result.GetType().Name.ToString();
            string toString = ToString(operationAsString, resultAsString, stopWatch);

            return toString;
        }

        public static string CompareDecimalPerformance(SimpleOperations operation)
        {
            var isEnumDefined = Enum.IsDefined(typeof(SimpleOperations), operation);

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
                    case SimpleOperations.Add:
                        result += AddNumber;
                        break;
                    case SimpleOperations.Divide:
                        result /= AddNumber;
                        break;
                    case SimpleOperations.Multiply:
                        result *= AddNumber;
                        break;
                    case SimpleOperations.Subtract:
                        result -= AddNumber;
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
            string result = $"{operation, -10} {type, -20} {stopWatch.Elapsed}";

            return result;
        }
    }
}
