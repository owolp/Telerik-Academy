using System;
using System.Text;

class MagicWordsTestGenerator
{
    static Random rnd = new Random();

    static void Main()
    {
        int n = 253;
        int minLen = 1;
        int maxLen = 70;

        Console.WriteLine(n);
        for (int i = 0; i < n; i++)
        {
            string word = GenerateRandomWord(minLen, maxLen);
            Console.WriteLine(word);
        }
    }

    static string GenerateRandomWord(int minLen, int maxLen)
    {
        StringBuilder word = new StringBuilder();
        int len = rnd.Next(minLen, maxLen + 1);
        for (int i = 0; i < len; i++)
        {
            char ch = (char) ('a' + rnd.Next('z' - 'a' + 1));
            word.Append(ch);
        }
        return word.ToString();
    }
}
