using System;
    
namespace MaximalSum
{
    class MaximalSum
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ');

            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            int[,] matrix = new int[n, m];
            for (int row = 0; row < n; row++)
            {
                var index = 0;
                input = Console.ReadLine().Split(' ');

                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = int.Parse(input[index]);
                    index++;
                }
            }

            int maxSum = int.MinValue;
            int currentSum = 0;

            for (int row = 0; row <= matrix.GetLength(0) - 3; row++)
            {
                for (int col = 0; col <= matrix.GetLength(1) - 3; col++)
                {
                    currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                                 matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                                 matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }

            Console.WriteLine(maxSum);
        }
    }
}