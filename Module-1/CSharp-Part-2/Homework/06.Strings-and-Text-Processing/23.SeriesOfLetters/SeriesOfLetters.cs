namespace SeriesOfLetters
{
    using System;
    using System.Text;

    class SeriesOfLetters
    {
        static void Main()
        {
            var input = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            char digitIndex = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] != digitIndex)
                {
                    sb.Append(digitIndex);
                }

                digitIndex = input[i];
            }

            sb.Append(input[input.Length - 1]);

            Console.WriteLine(sb);
        } 
    }
}