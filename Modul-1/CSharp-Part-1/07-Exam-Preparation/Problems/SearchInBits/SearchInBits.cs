using System;
// 70100 BGCODER
namespace SearchInBits
{
    class SearchInBits
    {
        static void Main()
        {
            long s = long.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            int counter = 0;
            int occurences = 0;

            long[] lastFourBits = new long[4];
            for (int i = 0; i < 4; i++)
            {
                lastFourBits[i] = GetBit(s, i);
            }

            for (int i = 0; i < n; i++)
            {
                long number = long.Parse(Console.ReadLine());

                for (int position = 29; position >= 0; position--)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        var bit = GetBit(number, position - j);
                        if (bit != lastFourBits[3 - j])
                        {
                            break;
                        }
                        else
                        {
                            counter++;
                        }
                    }

                    if (counter == 4)
                    {
                        occurences++;

                    }
                    counter = 0;
                }
            }

            Console.WriteLine(occurences);
        }

        public static long GetBit(long number, int position)
        {
            long mask = 1 << position;
            long nAndMask = number & mask;
            long bit = nAndMask >> position;
            return bit;
        }
    }
}
