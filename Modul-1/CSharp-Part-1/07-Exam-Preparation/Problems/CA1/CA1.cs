using System;
using System.Numerics;

namespace CA1
{
    class CA1
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int counter = 1;

            BigInteger productsBefore10 = 1;
            BigInteger productsAfter10 = 1;

            while (input != "END")
            {
                BigInteger sumChars = 1;
                if (counter % 2 == 0 && input != "0")
                {
                    foreach (char ch in input)
                    {
                        if (ch != '0')
                        {
                            sumChars *= (ch - '0');
                        }
                    }
                }

                if (counter <= 10)
                {
                    productsBefore10 *= sumChars;
                }
                else
                {
                    productsAfter10 *= sumChars;
                }

                counter++;
                input = Console.ReadLine();

            }

            Console.WriteLine(productsBefore10);
            if (counter > 10)
            {
                Console.WriteLine(productsAfter10);
            }
        }
    }
}