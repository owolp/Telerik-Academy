using System;

namespace Eggcelent
{
    class Eggcelent
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int width = 3 * n + 1;
            int dotsLength = n / 2 - 1;

            //.......*****.......
            Console.Write(new string('.', n + 1));
            Console.Write(new string('*', n - 1));
            Console.WriteLine(new string('.', n + 1));

            //.....*.......*.....
            //...*...........*...
            int index1 = n - 1;
            int index2 = n + 1;
            for (int row = 0; row < (n / 2) - 1; row++)
            {
                Console.Write(new string('.', index1));
                Console.Write('*');
                Console.Write(new string('.', index2));
                Console.Write('*');
                Console.WriteLine(new string('.', index1));

                index1 -= 2;
                index2 += 4;
            }
            //.*...............*.
            //.*...............*.
            for (int row = 0; row < dotsLength; row++)
            {
                Console.Write('.');
                Console.Write('*');
                Console.Write(new string('.', width - 4));
                Console.Write('*');
                Console.WriteLine('.');
            }

            //.*@.@.@.@.@*.
            Console.Write(".*@");
            for (int i = 0; i < (width - 5) / 2; i++)
            {
                Console.Write('.');
                Console.Write('@');
            }

            Console.WriteLine("*.");


            //.*.@.@.@.@.*.
            Console.Write(".*.");
            for (int i = 0; i < (width - 5) / 2; i++)
            {
                Console.Write('@');
                Console.Write('.');
            }

            Console.WriteLine("*.");


            //.*...............*.
            //.*...............*.
            for (int row = 0; row < dotsLength; row++)
            {
                Console.Write('.');
                Console.Write('*');
                Console.Write(new string('.', width - 4));
                Console.Write('*');
                Console.WriteLine('.');
            }

            //...*...........*...
            //.....*.......*.....
            index1 = 3;
            index2 = width - 8;

            for (int row = 0; row < (n / 2) - 1; row++)
            {
                Console.Write(new string('.', index1));
                Console.Write('*');
                Console.Write(new string('.', index2));
                Console.Write('*');
                Console.WriteLine(new string('.', index1));

                index1 += 2;
                index2 -= 4;
            }

            //.......*****.......
            Console.Write(new string('.', n + 1));
            Console.Write(new string('*', n - 1));
            Console.WriteLine(new string('.', n + 1));
        }
    }
}