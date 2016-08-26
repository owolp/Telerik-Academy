using System;
using System.Text;
public class Program
{
    public static void Main()
    {
        var words = Console.ReadLine().Split(' ');
        foreach (var word in words)
        {
            // 17 to decimal
            ulong numInDec = 0;
            for (int i = 0; i < word.Length; i++)
            {
                numInDec *= 17;
                numInDec += (ulong)(word[i] - 'a');
            }

            // decimal to 26
            var sb = new StringBuilder();
            while(numInDec > 0)
            {
                sb.Insert(0, (char)((numInDec % 26) + 'a'));
                numInDec /= 26;
            }

            Console.Write(sb.ToString() + " ");
        }
        Console.WriteLine();
    }
}
