using System;

namespace NeuronMapping
{
    class NeuronMapping
    {
        static void Main()
        {
            while (true)
            {
                long number = long.Parse(Console.ReadLine());

                if (number == -1)
                {
                    break;
                }
                if (number == 0)
                {
                    Console.WriteLine("0");
                    continue;
                }

                int mostLeftPosition = -1;
                int mostRightPosition = -1;

                for (int i = 0; i < 32; i++)
                {
                    long currentBit = GetBit(number, i);

                    if (currentBit == 1 && mostRightPosition == -1)
                    {
                        mostRightPosition = i;
                    }

                    if (currentBit == 1)
                    {
                        mostLeftPosition = i;
                    }
                }

                long result = 0;
                for (int i = mostRightPosition + 1; i < mostLeftPosition; i++)
                {
                    long currentBit = GetBit(number, i);

                    if (currentBit == 0)
                    {
                        result = SetBitToOne(result, i);
                    }
                }
                Console.WriteLine(result);
            }
        }

        public static long GetBit(long number, int position)
        {
            long mask = 1 << position;
            long nAndMask = number & mask;
            long bit = nAndMask >> position;
            return bit;
        }

        public static long SetBitToOne(long number, int position)
        {
            long mask = 1 << position;
            long result = number | mask;
            return result;
        }

        //public static long SetBitToZero(long number, int position)
        //{
        //    long mask = ~(1 << position);
        //    long result = number & mask;
        //    return result;
        //}
    }
}
