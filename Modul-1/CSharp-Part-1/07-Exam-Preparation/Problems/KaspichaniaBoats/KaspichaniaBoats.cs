using System;

namespace KaspichaniaBoats
{
    class KaspichaniaBoats
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int width = n * 2 + 1;
            int height = 6 + ((n - 3) / 2) * 3;

            //.......*.......
            Console.Write(new string('.', n));
            Console.Write('*');
            Console.WriteLine(new string('.', n));


            //......***......
            Console.Write(new string('.', n - 1));
            Console.Write(new string('*', 3));
            Console.WriteLine(new string('.', n - 1));


            //.....*.*.*.....
            //....*..*..*....
            //...*...*...*...
            //..*....*....*..
            //.*.....*.....*.
            int heightTop = n - 2;
            for (int row = 1; row <= heightTop; row++)
            {
                Console.Write(new string('.', n - 1 - row));
                Console.Write('*');
                Console.Write(new string('.', row));
                Console.Write('*');
                Console.Write(new string('.', row));
                Console.Write('*');
                Console.WriteLine(new string('.', n - 1 - row));
            }

            //***************
            Console.WriteLine(new string('*', width));


            //.*.....*.....*.
            //..*....*....*..
            //...*...*...*...
            int heightBottom = height - heightTop - 4;
            for (int row = 1; row <= heightBottom ; row++)
            {
                Console.Write(new string('.', row));
                Console.Write('*');
                Console.Write(new string('.', n - 1 - row));
                Console.Write('*');
                Console.Write(new string('.', n - 1 - row));
                Console.Write('*');
                Console.WriteLine(new string('.', row));
            }


            //....*******....
            int bottomDots = (width - n) / 2;
            Console.Write(new string('.', bottomDots));
            Console.Write(new string('*', n));
            Console.WriteLine(new string('.', bottomDots));
        }
    }
}
