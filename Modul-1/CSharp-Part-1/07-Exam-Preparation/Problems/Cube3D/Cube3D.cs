using System;

namespace Cube3D
{
    class Cube3D
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            //::::::     
            Console.Write(new string(':', n));
            Console.WriteLine(new string(' ', n - 1));

            //:    ::
            //:    :|:   
            //:    :||:  
            //:    :|||: 
            for (int row = 0; row < n - 2; row++)
            {
                Console.Write(':');
                Console.Write(new string(' ', n - 2));
                Console.Write(':');
                Console.Write(new string('|', row));
                Console.Write(':');
                Console.WriteLine(new string(' ', n - 2));
            }

            //::::::||||:
            Console.Write(new string(':', n));
            Console.Write(new string('|', n - 2));
            Console.WriteLine(':');

            // :----:|||:
            //  :----:||:
            //   :----:|:
            //    :----::
            for (int row = 0; row < n - 2; row++)
            {
                Console.Write(new string(' ', row + 1));
                Console.Write(':');
                Console.Write(new string('-', n - 2));
                Console.Write(':');
                Console.Write(new string('|', n - 3 - row));
                Console.WriteLine(':');
            }

            //     ::::::
            Console.Write(new string(' ', n - 1));
            Console.WriteLine(new string(':', n));
        }
    }
}
