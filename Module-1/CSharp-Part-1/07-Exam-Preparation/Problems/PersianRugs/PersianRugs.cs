using System;

namespace PersianRugs
{
    class PersianRugs
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            int width = 2 * n + 1;

            //\  \.../  /
            //#\  \./  /#
            //##\     /##
            //###\   /###
            //####\ /####
            for (int row = 0; row < n; row++)
            {
                Console.Write(new string('#', row));
                Console.Write('\\');
                if (width - 2 * d - 2 - 2 * row >= 3)
                {
                    Console.Write(new string(' ', d));
                    Console.Write('\\');
                    Console.Write(new string('.', width - 2 * d - 4 - 2 * row));
                    Console.Write('/');
                    Console.Write(new string(' ', d));

                }
                else
                {
                    Console.Write(new string(' ', width - 2 * row - 2));
                }
                Console.Write('/');
                Console.WriteLine(new string('#', row));
            }

            //#####X#####
            Console.Write(new string('#', n));
            Console.Write('X');
            Console.WriteLine(new string('#', n));

            //####/ \####
            //###/   \###
            //##/     \##
            //#/  /.\  \#
            ///  /...\  \
            for (int row = n - 1; row >= 0; row--)
            {
                Console.Write(new string('#', row));
                Console.Write('/');
                if (width - 2 * d - 2 - 2 * row >= 3)
                {
                    Console.Write(new string(' ', d));
                    Console.Write('/');
                    Console.Write(new string('.', width - 2 * d - 4 - 2 * row));
                    Console.Write('\\');
                    Console.Write(new string(' ', d));

                }
                else
                {
                    Console.Write(new string(' ', width - 2 * row - 2));
                }
                Console.Write('\\');
                Console.WriteLine(new string('#', row));
            }
        }
    }
}
