using System;

namespace BitsToBits
{
    class BitsToBits
    {
        static void Main()
        {
            int length = int.Parse(Console.ReadLine());

            int longestZeros = 0;
            int currentZeros = 0;
            int longestOnes = 0;
            int currentOnes = 0;
            ulong previousBit = 2;

            for (int i = 0; i < length; i++)
            {
                ulong number = ulong.Parse(Console.ReadLine());

                for (int position = 29; position >= 0; position--)
                {
                    ulong currentBit = GetBit(number, position);

                    if (currentBit == 1)
                    {
                        if (previousBit == 1)
                        {
                            currentOnes++;
                            longestOnes = Math.Max(currentOnes, longestOnes);
                        }
                        else
                        {
                            currentZeros = 0;
                            currentOnes = 1;
                        }
                    }
                    else
                    {
                        if (previousBit == 0)
                        {
                            currentZeros++;
                            longestZeros = Math.Max(currentZeros, longestZeros);
                        }
                        else
                        {
                            currentOnes = 0;
                            currentZeros = 1;
                        }
                    }

                    previousBit = currentBit;
                }

            }
            Console.WriteLine(longestZeros);
            Console.WriteLine(longestOnes);
        }

        public static ulong GetBit(ulong number, int position)
        {
            ulong mask = 1U << position;
            ulong nAndMask = number & mask;
            ulong bit = nAndMask >> position;
            return bit;
        }
    }
}
