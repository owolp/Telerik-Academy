using System;

namespace BinaryShort
{
    class BinaryShort
    {
        static void Main()
        {
            short number = short.Parse(Console.ReadLine());

            string numberAsBinary = Convert.ToString(number, 2).PadLeft(16, '0');

            Console.WriteLine(numberAsBinary);
        }
    }
}