namespace StringLength
{
    using System;

    class StringLength
    {
        static void Main()
        {
            // 100/100
            Console.WriteLine(Console.ReadLine().Replace(@"\", string.Empty).PadRight(20, '*'));

            //85/100
            Console.WriteLine(Console.ReadLine().PadRight(20, '*'));
        }
    }
}