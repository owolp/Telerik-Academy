using System;
using System.Text;

class MagicWordsTestGenerator
{
    static Random rnd = new Random();

    static void Main()
    {
        int n = 65535;
        int minLen = 1;
        int maxLen = 5;

        string word = GenerateRandomWord(minLen, maxLen);
        Console.Write(word);
        for (int i = 1; i < n; i++)
        {
            word = GenerateRandomWord(minLen, maxLen);
            Console.Write(" ");
            Console.Write(word);
        }
        Console.WriteLine();
    }

    static string GenerateRandomWord(int minLen, int maxLen)
    {
        StringBuilder word = new StringBuilder();
        int len = rnd.Next(minLen, maxLen + 1);
        for (int i = 0; i < len; i++)
        {
            char ch = (char) ('a' + rnd.Next('z' - 'a' + 1));
            if (rnd.Next(3) == 0)
            {
                ch = char.ToUpper(ch);
            }
            word.Append(ch);
        }
        return word.ToString();
    }
}
