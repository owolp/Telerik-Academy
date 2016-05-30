namespace CorrectBrackets
{
    using System;

    class CorrectBrackets
    {
        static void Main()
        {
            Console.WriteLine(CheckCorrectness(Console.ReadLine()));
        }

        static string CheckCorrectness(string expression)
        {
            var sumLeftBracket = 0;
            var sumRightBracket = 0;

            foreach (char symbol in expression)
            {
                if (symbol == '(')
                {
                    sumLeftBracket++;
                }
                else if (symbol == ')')
                {
                    sumRightBracket++;
                }
            }

            return sumLeftBracket == sumRightBracket ? "Correct" : "Incorrect";
        }
    }
}