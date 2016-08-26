using System;

namespace FillTheMatrix
{
    class FillTheMatrix
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var symbol = Console.ReadLine();

            int[,] matrix = new int[n, n];
            int index = 1;

            switch (symbol)
            {
                #region caseA
                case "a":
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            matrix[row, col] = index;
                            index++;
                        }
                    }
                    break;
                #endregion

                #region caseB
                case "b":
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (col % 2 == 0)
                        {
                            for (int row = 0; row < matrix.GetLength(0); row++)
                            {
                                matrix[row, col] = index;
                                index++;
                            }
                        }
                        else
                        {
                            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                            {
                                matrix[row, col] = index;
                                index++;
                            }
                        }
                    }
                    break;
                #endregion

                #region caseC
                case "c":
                    // left side
                    for (int row = n - 1; row >= 0; row--)
                    {
                        for (int col = 0; col < n - row; col++)
                        {
                            matrix[row + col, col] = index;
                            index++;
                        }
                    }

                    // right side
                    for (int col = 1; col < n; col++)
                    {
                        for (int row = 0; row < n - col; row++)
                        {
                            matrix[row, row + col] = index;
                            index++;
                        }
                    }
                    break;
                #endregion

                #region caseD
                case "d":
                    int start = 0;
                    int stop = n;

                    while (stop - start >= 1)
                    {
                        for (int i = start; i < stop; i++)
                        {
                            matrix[i, start] = index;
                            index++;
                        }
                        for (int j = start + 1; j < stop; j++)
                        {
                            matrix[stop - 1, j] = index;
                            index++;
                        }
                        for (int k = stop - 2; k >= start; k--)
                        {
                            matrix[k, stop - 1] = index;
                            index++;
                        }
                        for (int l = stop - 2; l >= start + 1; l--)
                        {
                            matrix[start, l] = index;
                            index++;
                        }

                        start++;
                        stop--;
                    }
                    break;
                    #endregion
            }

            // print matrix
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col == n - 1)
                    {
                        Console.Write("{0}", matrix[row, col]);
                    }
                    else
                    {
                        Console.Write("{0} ", matrix[row, col]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}