using System;

namespace IndexOfLetters
{
    class IndexOfLetters
    {
        static void Main()
        {
            char[] alphabet = new char[26];

            for (int i = 0; i < alphabet.Length; i++)
            {
                alphabet[i] = (char)(97 + i);
            }

            var input = Console.ReadLine();

            char[] inputArr = input.ToCharArray();

            for (int i = 0; i < inputArr.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (inputArr[i] == alphabet[j])
                    {
                        Console.WriteLine(j);
                    }
                }
            }
        }
    }
}