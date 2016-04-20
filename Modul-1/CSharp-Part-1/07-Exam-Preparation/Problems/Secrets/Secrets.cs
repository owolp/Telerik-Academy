using System;
using System.Numerics;

namespace Secrets
{
    class Secrets
    {
        static void Main()
        {
            BigInteger input = BigInteger.Parse(Console.ReadLine());
            BigInteger n = input;

            if (n < 0)
            {
                n *= -1;
            }

            BigInteger specialSum = 0;
            int position = 1;

            while (n > 0)
            {
                var digit = n % 10;

                if (position % 2 == 0)
                {                                                      
                    specialSum += (digit * digit * position);
                }
                else
                {
                    specialSum += (digit * position * position);
                }
                
                position++;
                n /= 10;
            }

            Console.WriteLine(specialSum);

            BigInteger lastDigit = specialSum % 10;

            BigInteger remainder = specialSum % 26;

            if (lastDigit == 0)
            {
                Console.Write(input + " has no secret alpha-sequence");
            }
            else
            {
                BigInteger firstLetter = remainder + 1 + 64;
                for (int i = 0; i < lastDigit; i++)
                {
                    char letter = (char)firstLetter;
                    firstLetter++;
                    Console.Write(letter);
                    if (letter == 'Z')
                    {
                        firstLetter = 'A';
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
