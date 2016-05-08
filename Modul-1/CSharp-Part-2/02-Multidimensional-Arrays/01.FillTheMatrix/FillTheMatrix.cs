using System;
// 75/100 BGCODER

namespace FillTheMatrix
{
    class FillTheMatrix
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var symbol = Console.ReadLine();

            switch (symbol)
            {
                #region caseA
                case "a":
                    int[,] matrixA = new int[n, n];
                    int indexA = 1;

                    for (int col = 0; col < matrixA.GetLength(1); col++)
                    {
                        for (int row = 0; row < matrixA.GetLength(0); row++)
                        {
                            matrixA[row, col] = indexA;
                            indexA++;
                        }
                    }

                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            if (col == n - 1)
                            {
                                Console.Write("{0}", matrixA[row, col]);
                            }
                            else
                            {
                                Console.Write("{0} ", matrixA[row, col]);
                            }

                        }
                        Console.WriteLine();
                    }
                    break;
                #endregion

                #region caseB
                case "b":
                    int[,] matrixB = new int[n, n];
                    int indexB = 0;
                    #region Solution1B
                    //for (int col = 0; col < matrixB.GetLength(1); col++)
                    //{
                    //    if (col % 2 == 0)
                    //    {
                    //        for (int row = 0; row < matrixB.GetLength(0); row++)
                    //        {
                    //            indexB++;
                    //            matrixB[row, col] = indexB;
                    //        }

                    //        indexB += n;
                    //    }
                    //    else
                    //    {
                    //        for (int row = 0; row < matrixB.GetLength(0); row++)
                    //        {
                    //            matrixB[row, col] = indexB;
                    //            indexB--;
                    //        }

                    //        indexB += n;
                    //    }
                    //}
                    #endregion

                    for (int col = 0; col < matrixB.GetLength(1); col++)
                    {
                        if (col % 2 == 0)
                        {
                            for (int row = 0; row < matrixB.GetLength(0); row++)
                            {
                                indexB++;
                                matrixB[row, col] = indexB;
                            }
                        }
                        else
                        {
                            for (int row = matrixB.GetLength(0) - 1; row >= 0; row--)
                            {
                                indexB++;
                                matrixB[row, col] = indexB;
                            }
                        }
                    }

                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            if (col == n - 1)
                            {
                                Console.Write("{0}", matrixB[row, col]);
                            }
                            else
                            {
                                Console.Write("{0} ", matrixB[row, col]);
                            }
                        }
                        Console.WriteLine();
                    }
                    break;
                #endregion

                #region caseC
                case "c":
                    int[,] matrixC = new int[n, n];
                    int indexC = 1;

                    // left side
                    for (int row = n - 1; row >= 0; row--)
                    {
                        for (int col = 0; col < n - row; col++)
                        {
                            matrixC[row + col, col] = indexC;
                            indexC++;
                        }
                    }

                    // right side
                    for (int col = 1; col < n; col++)
                    {
                        for (int row = 0; row < n - col; row++)
                        {
                            matrixC[row, row + col] = indexC;
                            indexC++;
                        }
                    }

                    // print matrix
                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            if (col == n - 1)
                            {
                                Console.Write("{0}", matrixC[row, col]);
                            }
                            else
                            {
                                Console.Write("{0} ", matrixC[row, col]);
                            }
                        }
                        Console.WriteLine();
                    }
                    break;
                #endregion

                default:
                    break;
            }
        }
    }
}