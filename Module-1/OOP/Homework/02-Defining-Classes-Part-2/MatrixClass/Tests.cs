namespace MatrixClass
{
    using System;

    public class Tests
    {
        // Problem 8. Matrix
        // Define a class Matrix<T> to hold a matrix of numbers(e.g.integers, floats, decimals).
        private static Matrix<int> firstMatrix = new Matrix<int>(2, 8);
        private static Matrix<int> secondMatrix = new Matrix<int>(2, 8);
        private static Matrix<int> thirdMatrix = new Matrix<int>(3, 2);

        public Matrix<int> FirstMatrix { get; private set; }

        public static void Main()
        {
            firstMatrix.FillTheMatrix();
            secondMatrix.FillTheMatrix();
            thirdMatrix.FillTheMatrix();

            Console.WriteLine("First matrix:");
            Console.WriteLine(firstMatrix);
            Console.WriteLine();

            Console.WriteLine("Second matrix");
            Console.WriteLine(secondMatrix);
            Console.WriteLine();

            // Problem 10. Matrix operations
            Console.WriteLine("Addition:");
            var addition = firstMatrix + secondMatrix;
            Console.WriteLine(firstMatrix + secondMatrix);
            Console.WriteLine();

            Console.WriteLine("Subtraction:");
            var subtraction = firstMatrix - secondMatrix;
            Console.WriteLine(subtraction);
            Console.WriteLine();

            Console.WriteLine("Multiplication:");
            var multiplication = firstMatrix * thirdMatrix;
            Console.WriteLine(multiplication);
            Console.WriteLine();

            Console.WriteLine("True or False (contains zero == False)");
            firstMatrix[0, 0] = 0;
            var trueOrFalse = firstMatrix ? "True" : "False";
            Console.WriteLine(trueOrFalse);
            Console.WriteLine();

            // Problem 11. Version attribute
            Type type = typeof(Matrix<int>);
            object[] attribute = type.GetCustomAttributes(false);
            foreach (var item in attribute)
            {
                Console.WriteLine(item);
            }
        }
    }
}
