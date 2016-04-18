using System;

namespace FirTree
{
    class FirTree
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            //.......*.......
            //......***......
            //.....*****.....
            //....*******....
            //...*********...
            //..***********..
            //.*************.
            //***************
            for (int row = 0, index = 1; row < n - 1; row++, index += 2)
            {
                Console.Write(new string('.', n - 2 - row));
                Console.Write(new string('*', index));
                Console.WriteLine(new string('.', n - 2 - row));
            }

            //.......*.......
            Console.Write(new string('.', n - 2));
            Console.Write('*');
            Console.WriteLine(new string('.', n - 2));
        }
    }
}