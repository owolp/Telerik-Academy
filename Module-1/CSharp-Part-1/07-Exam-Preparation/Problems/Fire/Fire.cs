using System;

namespace Fire
{
    class Fire
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int firstSide = n / 2;
            int secondSide = n / 4;
            int thirdSide = firstSide;

            //.....##.....
            //....#..#....
            //...#....#...
            //..#......#..
            //.#........#.
            //#..........#
            for (int row = 0, index = 0; row < firstSide; row++, index += 2)
            {
                Console.Write(new string('.', firstSide - 1 - row));
                Console.Write('#');
                Console.Write(new string('.', index));
                Console.Write('#');
                Console.WriteLine(new string('.', firstSide - 1 - row));
            }

            //#..........#
            //.#........#.
            //..#......#..
            for (int row = 0; row < secondSide; row++)
            {
                Console.Write(new string('.', row));
                Console.Write('#');
                Console.Write(new string('.', n - 2 - 2 * row));
                Console.Write('#');
                Console.WriteLine(new string('.', row));

            }

            //------------
            Console.WriteLine(new string('-', n));

            //\\\\\\//////
            //.\\\\\/////.
            //..\\\\////..
            //...\\\///...
            //....\\//....
            //.....\/.....

            for (int row = 0; row < thirdSide; row++)
            {
                Console.Write(new string('.', row));
                Console.Write(new string('\\', thirdSide - row));
                Console.Write(new string('/', thirdSide - row));
                Console.WriteLine(new string('.', row));
            }
        }
    }
}
