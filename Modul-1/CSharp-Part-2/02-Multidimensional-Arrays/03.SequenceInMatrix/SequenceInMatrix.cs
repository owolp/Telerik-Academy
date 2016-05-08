using System;

// NOT COMPLETED 
// 70/100 BGCODER
namespace SequenceInMatrix
{
    class SequenceInMatrix
    {
        static void Main(string[] args)
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

            int longestSeq = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int currentElement = matrix[row, col];
                    var currentSeq = 0;

                    #region Rewrite
                    /// left to right diagonal

                    //if (row != 0) // up left to right diagonal
                    //{
                    //    var index = 0;
                    //    for (int i = col; i > 0; i--)
                    //    {
                    //        if (currentElement == matrix[row - index, i])
                    //        {
                    //            currentSeq++;
                    //        }
                    //        else
                    //        {
                    //            currentSeq = 0;
                    //        }
                    //        index++;

                    //        if (currentSeq > longestSeq)
                    //        {
                    //            longestSeq = currentSeq;
                    //        }
                    //    }

                    //    index = 0;
                    //    for (int i = row; i >= 0; i--)
                    //    {
                    //        if (currentElement == matrix[i, col + index])
                    //        {
                    //            currentSeq++;
                    //        }
                    //        else
                    //        {
                    //            currentSeq = 0;
                    //        }

                    //        if (currentSeq > longestSeq)
                    //        {
                    //            longestSeq = currentSeq;
                    //        }
                    //    }
                    //}
                    //else // down left to right diagonal
                    //{

                    //}



                    /// right to left diagonal
                    #endregion

                    /// line
                    currentSeq = 0;
                    for (int i = 0; i < matrix.GetLength(1); i++)
                    {

                        if (currentElement == matrix[row, i])
                        {
                            currentSeq++;
                        }
                        else
                        {
                            currentSeq = 0;
                        }

                        if (currentSeq > longestSeq)
                        {
                            longestSeq = currentSeq;
                        }
                    }

                    /// column
                    currentSeq = 0;
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {

                        if (currentElement == matrix[i, col])
                        {
                            currentSeq++;
                        }
                        else
                        {
                            currentSeq = 0;
                        }

                        if (currentSeq > longestSeq)
                        {
                            longestSeq = currentSeq;
                        }
                    }
                }
            }
            Console.WriteLine(longestSeq);
        }
    }
}
