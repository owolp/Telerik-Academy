using System;

namespace Cube
{
    class Cube
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            //       ::::::::
            Console.Write(new string(' ', n - 1));
            Console.WriteLine(new string(':', n));

            //      ://////::
            //     ://////:X:
            //    ://////:XX:
            //   ://////:XXX:
            //  ://////:XXXX:
            // ://////:XXXXX:
            for (int row = 0; row < n - 2; row++)
            {
                Console.Write(new string(' ', n - 2 - row));
                Console.Write(':');
                Console.Write(new string('/', n - 2));
                Console.Write(':');
                Console.Write(new string('X', row));
                Console.WriteLine(':');
            }

            //::::::::XXXXXX:
            Console.Write(new string(':', n));
            Console.Write(new string('X', n - 2));
            Console.WriteLine(':');

            //:      :XXXXX:
            //:      :XXXX:
            //:      :XXX:
            for (int row = 0; row < n - 2; row++)
            {
                Console.Write(':');
                Console.Write(new string(' ', n - 2));
                Console.Write(':');
                Console.Write(new string('X', n - 3 - row));
                Console.WriteLine(':');
            }

            //::::::::       
            Console.Write(new string(':', n));
            Console.WriteLine(new string(' ', n - 1));
        }
    }
}