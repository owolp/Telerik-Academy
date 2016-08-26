using System;
using System.Linq;

namespace IncreasingAbsoluteDifferences
{
    class IncreasingAbsoluteDifferences
    {
        static void Main()
        {
            int t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                Console.WriteLine((FindSeqOfAbsDiff(ReadArray())));
            }
        }

        static int[] ReadArray()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            return numbers;
        }

        static bool FindSeqOfAbsDiff(int[] numbers)
        {
            bool answer = true;

            int[] seqArr = new int[numbers.Length - 1];

            for (int i = 0; i < seqArr.Length; i++)
            {
                seqArr[i] = Math.Abs(numbers[i] - numbers[i + 1]);
            }

            answer = FindIncSeq(seqArr);

            return answer;
        }

        static bool FindIncSeq(int[] seqArr)
        {
            bool answer = true;

            for (int i = 1; i < seqArr.Length; i++)
            {
                int absDiff = seqArr[i] - seqArr[i - 1];

                if (0 > absDiff || absDiff > 1)
                {
                    return answer = false;
                }
            }

            return answer;
        }
    }
}