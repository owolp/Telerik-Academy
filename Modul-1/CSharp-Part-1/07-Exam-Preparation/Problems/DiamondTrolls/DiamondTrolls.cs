using System;

namespace DiamondTrolls
{
    class DiamondTrolls
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int width = n * 2 + 1;
            int height = 6 + ((n - 3) / 2) *3;

            //....*******....
            int topDots = (width - n) / 2;
            Console.Write(new string('.', topDots));
            Console.Write(new string('*', n));
            Console.WriteLine(new string('.', topDots));


            //...*...*...*...
            //..*....*....*..
            //.*.....*.....*.
            int heightTop = height - n - 2;
            int secondDots = (width - 3) / 4;
            for (int row = 0; row < heightTop; row++)
            {
                Console.Write(new string('.', secondDots - row));
                Console.Write('*');
                Console.Write(new string('.', secondDots + row));
                Console.Write('*');
                Console.Write(new string('.', secondDots + row));
                Console.Write('*');
                Console.WriteLine(new string('.', secondDots - row));
            }


            //***************
            Console.WriteLine(new string('*', width));


            //.*.....*.....*.
            //..*....*....*..
            //...*...*...*...
            //....*..*..*....
            //.....*.*.*.....
            //......***......
            int bottomDots = n - 2;
            for (int row = 0; row < n - 1; row++)
            {
                Console.Write(new string('.', row + 1));
                Console.Write('*');
                Console.Write(new string('.', bottomDots - row));
                Console.Write('*');
                Console.Write(new string('.', bottomDots - row));
                Console.Write('*');
                Console.WriteLine(new string('.', row + 1));
            }

            //.......*.......
            Console.Write(new string('.', n));
            Console.Write('*');
            Console.WriteLine(new string('.', n));
        }
    }
}