using System;

namespace TextToNumber
{
    class TextToNumber
    {
        static void Main()
        {
            int m = int.Parse(Console.ReadLine());
            var text = Console.ReadLine();

            int position = 0;
            char ch = text[position];
            double result = 0;

            while (ch != '@')
            {
                if (char.IsDigit(ch))
                {
                    result *= char.GetNumericValue(ch);
                }
                else if (char.IsLetter(ch))
                {
                    if (ch >= 'A' && ch <= 'Z')
                    {
                        var value = ch - 'A';
                        result += value;
                    }
                    else
                    {
                        var value = ch - 'a';
                        result += value;
                    }
                }
                else
                {
                    result %= m;
                }


                position++;
                ch = text[position];
            }
            Console.WriteLine(result);
        }
    }
}