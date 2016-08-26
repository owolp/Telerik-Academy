using System;

namespace UKFlag
{
    class UKFlag
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int row = 0; row < n / 2; row++)
            {
                Console.Write(new string('.', row));
                Console.Write('\\');
                Console.Write(new string('.', (n / 2 - row) - 1));
                Console.Write('|');
                Console.Write(new string('.', (n / 2 - row) - 1));
                Console.Write('/');
                Console.WriteLine(new string('.', row));
            }

            Console.Write(new string('-', n / 2));
            Console.Write('*');
            Console.WriteLine(new string('-', n / 2));

            for (int row = 0; row < n / 2; row++)
            {
                Console.Write(new string('.', (n / 2 - row) - 1));
                Console.Write('/');
                Console.Write(new string('.', row));
                Console.Write('|');
                Console.Write(new string('.',row));
                Console.Write('\\');
                Console.WriteLine(new string('.', (n / 2 - row) - 1));
            }
        }
    }
}