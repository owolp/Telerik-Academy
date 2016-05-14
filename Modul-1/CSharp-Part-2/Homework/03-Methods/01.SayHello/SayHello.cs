using System;

namespace SayHello
{
    class SayHello
    {
        static string GetName()
        {
            return Console.ReadLine();
        }

        static void PrintName(string name)
        {
            Console.WriteLine("Hello, " + name + "!");
        }

        static void Main()
        {
            PrintName(GetName());
        }
    }
}