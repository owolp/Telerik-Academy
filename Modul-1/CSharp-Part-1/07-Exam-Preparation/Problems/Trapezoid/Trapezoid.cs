using System;

namespace Trapezoid
{
    class Trapezoid
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            //..........**********
            Console.Write(new string('.', n));
            Console.WriteLine(new string('*', n));

            //.........*.........*
            //........*..........*
            //.......*...........*
            //......*............*
            //.....*.............*
            //....*..............*
            //...*...............*
            //..*................*
            //.*.................*
            for (int row = 0; row <= n - 2; row++)
            {
                Console.Write(new string('.', n - 1 - row));
                Console.Write('*');
                Console.Write(new string('.', n - 1 + row));
                Console.WriteLine('*');
            }

            //********************
            Console.WriteLine(new string('*', 2 * n));
        }
    }
}