namespace MatrixClass
{
    using System;
    using System.Text;

    public class Matrix<T> where T : struct,
          IComparable,
          IComparable<T>,
          IConvertible,
          IEquatable<T>,
          IFormattable
    {
        // fields
        private T[,] matrix;
        private uint row;
        private uint col;

        // constructors
        public Matrix(uint row, uint col)
        {
            this.Row = row;
            this.Col = col;
            this.matrix = new T[row, col];
        }

        // properties
        public uint Row
        {
            get
            {
                return this.row;
            }

            set
            {
                this.row = value;
            }
        }

        public uint Col
        {
            get
            {
                return this.col;
            }

            set
            {
                this.col = value;
            }
        }

        // indexer
        public T this[uint row, uint col]
        {
            get
            {
                if (0 > row || row > this.Row)
                {
                    throw new IndexOutOfRangeException("The row index is out of range.");
                }

                if (0 > col || col > this.Col)
                {
                    throw new IndexOutOfRangeException("The col index is out of range.");
                }

                return this.matrix[row, col];
            }

            set
            {
                if (0 > row || row > this.Row)
                {
                    throw new IndexOutOfRangeException("The row index is out of range.");
                }

                if (0 > col || col > this.Col)
                {
                    throw new IndexOutOfRangeException("The col index is out of range.");
                }

                this.matrix[row, col] = value;
            }
        }

        // methods
        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Row != secondMatrix.Row || firstMatrix.Col != secondMatrix.Col)
            {
                throw new InvalidOperationException("The operation can not be implemented because both matrices must have the same dimensions.");
            }

            var result = new Matrix<T>(firstMatrix.Row, firstMatrix.Col);
            for (uint row = 0; row < result.Row; row++)
            {
                for (uint col = 0; col < result.Col; col++)
                {
                    result[row, col] = (dynamic)firstMatrix[row, col] + (dynamic)secondMatrix[row, col];
                }
            }

            return result;
        }

        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Row != secondMatrix.Row || firstMatrix.Col != secondMatrix.Col)
            {
                throw new InvalidOperationException("The operation can not be implemented because both matrices must have the same dimensions.");
            }

            var result = new Matrix<T>(firstMatrix.Row, firstMatrix.Col);
            for (uint row = 0; row < result.Row; row++)
            {
                for (uint col = 0; col < result.Col; col++)
                {
                    result[row, col] = (dynamic)firstMatrix[row, col] - (dynamic)secondMatrix[row, col];
                }
            }

            return result;
        }

        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Row != secondMatrix.Col)
            {
                throw new InvalidOperationException("The operation can not be implemented because both matrices must have the same dimensions for Row(first) and Col(second)");
            }

            var result = new Matrix<T>(firstMatrix.Row, secondMatrix.Col);
            for (uint row = 0; row < result.Row; row++)
            {
                for (uint col = 0; col < result.Col; col++)
                {
                    for (uint index = 0; index < result.Col; index++)
                    {
                        result[row, col] += (dynamic)firstMatrix[row, index] * (dynamic)secondMatrix[index, col];
                    }
                }
            }

            return result;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            return BooleanCheck(matrix, true);
        }

        public static bool operator false(Matrix<T> matrix)
        {
            return BooleanCheck(matrix, false);
        }

        public void FillTheMatrix()
        {
            var random = new Random();

            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 0; j < this.Col; j++)
                {
                    this.matrix[i, j] = (dynamic)random.Next(-20, 20);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (uint row = 0; row < this.Row; row++)
            {
                for (uint col = 0; col < this.Col; col++)
                {
                    stringBuilder.AppendFormat("{0, 5}", this.matrix[row, col]);
                }

                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }

        private static bool BooleanCheck(Matrix<T> matrix, bool trueOrFalse)
        {
            foreach (var element in matrix.matrix)
            {
                if (element.Equals(default(T)))
                {
                    return !trueOrFalse;
                }
            }

            return trueOrFalse;
        }
    }
}
