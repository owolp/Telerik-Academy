using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task09
{
    public class Task09
    {
        public static void Main()
        {
            int n = 10;
            var sequence = new Queue<int>();
            int counter = 0;
            int lastNumber = n;
            sequence.Enqueue(n);

            for (int i = 1; i <= 50; i++)
            {
                lastNumber = sequence.Dequeue();
                Console.WriteLine($"{i,2} -> {lastNumber,2} ");

                if (counter < 50)
                {
                    sequence.Enqueue(lastNumber + 1);
                    sequence.Enqueue((2 * lastNumber) + 1);
                    sequence.Enqueue(lastNumber + 2);
                }
                counter += 3;
            }
        }
    }
}
