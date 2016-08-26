using System;

namespace SymbolToNumber
{
    class SymbolToNumber
    {
        static void Main()
        {
            int secret = int.Parse(Console.ReadLine());

            var text = Console.ReadLine();

            int position = 0;
            char ch = text[position];

            while (true)
            {
                double result = 0;

                if (ch == '@')
                {
                    break;
                }
                else if (char.IsLetter(ch))
                {
                    result = (ch * secret) + 1000;
                }
                else if (char.IsDigit(ch))
                {
                    result = ch + secret + 500;
                }
                else
                {
                    result = ch - secret;
                }

                if (position % 2 == 0)
                {
                    result /= 100;
                    Console.WriteLine("{0:F2}", result);
                }
                else
                {
                    result *= 100;
                    Console.WriteLine(result);
                }

                position++;
                ch = text[position];
            }
        }
    }
}