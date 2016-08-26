using System;

namespace TripleRotationOfDigits
{
    class TripleRotationOfDigits
    {
        static void Main()
        {
            int k = int.Parse(Console.ReadLine());

            int result = 0;

            if (k < 10)
            {
                Console.WriteLine(k);
            }
            else
            {
                int lastDigit = k % 10;
                k /= 10;
                string kAsString = Convert.ToString(k);
                kAsString = lastDigit + kAsString;
                result = int.Parse(kAsString);

                lastDigit = result % 10;
                result /= 10;
                kAsString = Convert.ToString(result);
                kAsString = lastDigit + kAsString;
                result = int.Parse(kAsString);

                lastDigit = result % 10;
                result /= 10;
                kAsString = Convert.ToString(result);
                if (kAsString == "0")
                {
                    result = lastDigit;
                }
                else
                {
                    kAsString = lastDigit + kAsString;
                    result = int.Parse(kAsString);
                }


                Console.WriteLine(result);
            }

        }
    }
}