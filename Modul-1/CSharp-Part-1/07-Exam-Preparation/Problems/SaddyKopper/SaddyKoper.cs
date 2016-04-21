using System;
using System.Numerics;
// BG CODE 90/100 Time Limit
namespace SaddyKopper
{
    class SaddyKoper
    {
        static void Main()
        {
            string input = Console.ReadLine();
            BigInteger number = BigInteger.Parse(input);
            int counter = 0;

            while (number > 9)
            {
                long sumOfDigits = 0;
                BigInteger productOfSums = 1;

                number /= 10;

                while (number != 0)
                {


                    var numberAsString = Convert.ToString(number);
                    int length = numberAsString.Length;
                    int position = 0;


                    foreach (char ch in numberAsString)
                    {
                        if (position % 2 == 0)
                        {
                            sumOfDigits += ch - '0';
                        }
                        position++;
                    }

                    productOfSums *= sumOfDigits;

                    number /= 10;
                    sumOfDigits = 0;
                }
                number = productOfSums;

                counter++;
                if (counter == 10)
                {
                    break;
                }
            }

            if (counter == 10)
            {
                Console.WriteLine(number);
            }
            else
            {
                Console.WriteLine(counter);
                Console.WriteLine(number);
            }

        }
    }
}
