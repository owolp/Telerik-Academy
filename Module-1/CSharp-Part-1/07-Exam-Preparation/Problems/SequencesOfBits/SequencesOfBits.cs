using System;

namespace SequencesOfBits
{
    class SequencesOfBits
    {
        static void Main()
        {
            int length = int.Parse(Console.ReadLine());

            int longestSequenceOnes = 0;
            int internalSequenceOnes = 0;

            int longestSequenceZeroes = 0;
            int internalSequenceZeroes = 0;

            int mostLeftOne = -1;
            int mostRightOne = -1;

            int mostLeftZero = -1;
            int mostRightZero = -1;

            int previousBit = -1;

            for (int n = 0; n < length; n++)
            {
                int number = int.Parse(Console.ReadLine());

                for (int position = 29; position >= 0; position--)
                {
                    int currentBit = GetBit(number, position);

                    if (currentBit == 0)
                    {
                        internalSequenceZeroes++;
                        internalSequenceOnes = 0;

                        if (mostLeftZero == -1)
                        {
                            mostLeftZero = position;
                        }

                        if (previousBit == currentBit)
                        {
                            mostRightZero = position;

                        }
                    }
                    else // currentBit = 1
                    {
                        internalSequenceOnes++;
                        internalSequenceZeroes = 0;

                        if (mostLeftOne == -1)
                        {
                            mostLeftOne = position;
                        }

                        if (previousBit == currentBit)
                        {
                            mostRightOne = position;
                        }
                    }

                    //if (internalSequenceOnes > longestSequenceOnes)
                    //{
                    //    longestSequenceOnes = internalSequenceOnes;
                    //}
                    //if (internalSequenceZeroes > longestSequenceZeroes)
                    //{
                    //    longestSequenceZeroes = internalSequenceZeroes;
                    //}

                    longestSequenceOnes = Math.Max(internalSequenceOnes, longestSequenceOnes);
                    longestSequenceZeroes = Math.Max(internalSequenceZeroes, longestSequenceZeroes);

                    previousBit = currentBit;
                }
            }
            Console.WriteLine(longestSequenceOnes);
            Console.WriteLine(longestSequenceZeroes);
        }

        public static int GetBit(int number, int position)
        {
            int mask = 1 << position;
            int nAndMask = number & mask;
            int bit = nAndMask >> position;
            return bit;
        }
    }
}
