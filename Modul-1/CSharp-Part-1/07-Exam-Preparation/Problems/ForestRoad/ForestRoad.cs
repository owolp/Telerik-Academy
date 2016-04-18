using System;

namespace ForestRoad
{
    class ForestRoad
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            //*....
            //.*...
            //..*..
            //...*.
            //....*
            for (int row = 0; row < n; row++)
            {
                Console.Write(new string('.', row));
                Console.Write('*');
                Console.WriteLine(new string('.', n - 1 - row));
            }

            //...*.
            //..*..
            //.*...
            //*....
            for (int row = 1; row <= n - 1; row++)
            {
                Console.Write(new string('.', n - 1 - row));
                Console.Write('*');
                Console.WriteLine(new string('.', row));
            }

        }
    }
}