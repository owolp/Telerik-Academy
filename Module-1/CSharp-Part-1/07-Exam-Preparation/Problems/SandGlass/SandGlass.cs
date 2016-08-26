using System;

namespace SandGlass
{
    class SandGlass
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int lines = n / 2;
            //*******
            //.*****.
            //..***..
            for (int row = 0, index = 0; row < lines; row++, index += 2)
            {
                Console.Write(new string('.', row));
                Console.Write(new string('*', n - index));
                Console.WriteLine(new string('.', row));
            }

            //...*...
            Console.Write(new string('.', lines));
            Console.Write('*');
            Console.WriteLine(new string('.', lines));

            //..***..
            //.*****.
            //*******
            for (int row = lines, index = 3; row > 0; row--, index += 2)
            {
                Console.Write(new string('.', row - 1));
                Console.Write(new string('*', index));
                Console.WriteLine(new string('.', row - 1));
            }
        }
    }
}
