// PARTIAL

namespace GreedyDwarf
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class GreedyDwarf
    {
        static void Main()
        {
            int[] valley = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int m = int.Parse(Console.ReadLine());

            int maxCoints = 0;

            for (int i = 0; i < m; i++)
            {
                int[] patterns = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int[] copiedValley = new int[valley.Length];
                Array.Copy(valley, copiedValley, valley.Length);

                int currentPosition = 0;
                int currentNumber = patterns[currentPosition];
                int currentCoints = 0;


                int pattern = 0;
                while (true)
                {

                    if (currentNumber == 0 || currentPosition + patterns.Length > copiedValley.Length)
                    {
                        if (currentCoints > maxCoints)
                        {
                            maxCoints = currentCoints;
                        }
                        break;
                    }

                    currentCoints += copiedValley[currentPosition];
                    copiedValley[currentPosition] = 0;

                    int nextPosition = 0;

                    if (pattern >= patterns.Length)
                    {
                        pattern = 0;
                    }

                    int positionsToMove = patterns[pattern];
                    nextPosition = currentPosition + positionsToMove;

                    if (copiedValley[nextPosition] == 0)
                    {
                        if (currentCoints > maxCoints)
                        {
                            maxCoints = currentCoints;
                        }
                        break;
                    }

                    currentCoints += copiedValley[nextPosition];
                    copiedValley[nextPosition] = 0;

                    currentPosition = nextPosition;

                    pattern++;
                }
            }



            Console.WriteLine(maxCoints);
        }
    }
}
