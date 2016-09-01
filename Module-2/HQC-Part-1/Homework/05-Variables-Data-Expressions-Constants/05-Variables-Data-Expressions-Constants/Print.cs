namespace Variables_Data_Expressions_Constants
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Print
    {
        public static void Main()
        {
            double[] array = new double[] { 1, 2, 3, 4, 5 };

            IList statistics = GetStatistics(array);

            PrintStatistics(statistics);
        }

        public static void PrintStatistics(IList statistics)
        {
            foreach (var statistic in statistics)
            {
                Console.WriteLine(statistic);
            }
        }

        public static double GetAverageSum(double[] array)
        {
            double averageSum = array.Average();

            return averageSum;
        }

        public static double GetMinSum(double[] array)
        {
            double minSum = array.Min();

            return minSum;
        }

        public static double GetMaxSum(double[] array)
        {
            double maxSum = array.Max();

            return maxSum;
        }

        public static IList GetStatistics(double[] array)
        {
            IList statistics = new List<double>();

            double averageSum = GetAverageSum(array);
            statistics.Add(averageSum);

            double minSum = GetMinSum(array);
            statistics.Add(minSum);

            double maxSum = GetMinSum(array);
            statistics.Add(maxSum);

            return statistics;
        }
    }
}
