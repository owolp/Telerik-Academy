using System;

namespace Decoding
{
    class Decoding
    {
        static void Main()
        {
            int salt = int.Parse(Console.ReadLine());

            var text = Console.ReadLine();

            int position = 0;
            char ch = text[position];

            while (ch != '@')
            {
                double result = 0;

                if (char.IsLetter(ch))
                {
                    result = ch * salt + 1000;
                }
                else if (char.IsDigit(ch))
                {
                    result = ch + salt + 500;
                }
                else
                {
                    result = ch - salt;
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