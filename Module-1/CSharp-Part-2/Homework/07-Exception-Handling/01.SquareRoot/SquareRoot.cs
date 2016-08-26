namespace SquareRoot
{
    using System;

    class SquareRoot
    {
        static void Main()
        {
            try
            {
                var number = double.Parse(Console.ReadLine());

                var sqrt = Math.Sqrt(number).ToString("F3");

                if (sqrt == "NaN")
                {
                    throw new FormatException();
                }
                else
                {
                    Console.WriteLine(sqrt);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }


    }
}