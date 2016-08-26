using System;
using System.Collections.Generic;

namespace Anacci
{
    class Anacci
    {
        static void Main()
        {
            List<int> numbers = new List<int>();

            for (int i = 0; i < 2; i++)
            {
                var input = char.Parse(Console.ReadLine());
                int number = input - 64;
                numbers.Add(number);
            }

            int lines = int.Parse(Console.ReadLine());

            int numbersLength = 2 * lines - 1;
            int position = 2;

            for (int i = 0; i < numbersLength - 2; i++)
            {
                var temp = numbers[position - 1] + numbers[position - 2];
                if (temp > 26)
                {
                    temp %= 26;
                }
                int number = temp;
                numbers.Add(number);
                position++;
            }

            char firstLetter = (char)(numbers[0] + 64);
            Console.WriteLine(firstLetter);

            if (lines > 1)
            {
                char secondLetter = (char)(numbers[1] + 64);
                char thirdLetter = (char)(numbers[2] + 64);
                Console.WriteLine(secondLetter + "" + thirdLetter);

                int space = 1;
                int index = 3;
                for (int i = 0; i < lines - 2; i++)
                {
                    if (i == lines - 1)
                    {
                        firstLetter = (char)(numbers[index] + 64);
                    }
                    else
                    {
                        firstLetter = (char)(numbers[index] + 64);
                        secondLetter = (char)(numbers[index + 1] + 64);
                        index += 2;
                    }
                    Console.WriteLine(firstLetter + new string(' ', space) + secondLetter);
                    space++;
                }
            }
        }
    }
}
