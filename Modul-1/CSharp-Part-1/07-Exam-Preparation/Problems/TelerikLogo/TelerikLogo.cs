using System;

namespace TelerikLogo
{
    class TelerikLogo
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int lines = n / 2 + 1;

            #region NotWorking
            //..*.......*..
            Console.Write(new string('.', lines - 1));
            Console.Write('*');
            Console.Write(new string('.', n + 2));
            Console.Write('*');
            Console.WriteLine(new string('.', lines - 1));

            //.*.*.....*.*.
            //*...*...*...*
            for (int row = 1, index1 = 1, index2 = n; row < lines; row++, index1 += 2, index2 -=2)
            {
                Console.Write(new string('.', lines - row - 1));
                Console.Write('*');
                Console.Write(new string('.', index1));
                Console.Write('*');
                Console.Write(new string('.', index2));
                Console.Write('*');
                Console.Write(new string('.', index1));
                Console.Write('*');
                Console.WriteLine(new string('.', lines - row - 1));
            }

            //.....*.*.....
            Console.Write(new string('.', n));
            Console.Write('*');
            Console.Write('.');
            Console.Write('*');
            Console.WriteLine(new string('.', n));

            //......*......
            Console.Write(new string('.', n + 1));
            Console.Write('*');
            Console.WriteLine(new string('.', n + 1));

            //.....*.*.....
            //....*...*....
            //...*.....*...
            //..*.......*..
            for (int row = 0, index = 1; row < n - 1; row++, index += 2)
            {
                Console.Write(new string('.', n - row));
                Console.Write('*');
                Console.Write(new string('.', index));
                Console.Write('*');
                Console.WriteLine(new string('.', n - row));
            }

            //...*.....*...
            //....*...*....
            //.....*.*.....
            for (int row = 0, index = n; row < lines; row++, index -= 2)
            {
                Console.Write(new string('.', row + 2));
                Console.Write('*');
                Console.Write(new string('.', index));
                Console.Write('*');
                Console.WriteLine(new string('.', row + 2));
            }


            //......*......
            Console.Write(new string('.', n + 1));
            Console.Write('*');
            Console.WriteLine(new string('.', n + 1));

            #endregion
        }
    }
}
