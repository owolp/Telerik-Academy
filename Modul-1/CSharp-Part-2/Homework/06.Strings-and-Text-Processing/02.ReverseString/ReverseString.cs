namespace ReverseString
{
    using System;

    class ReverseString
    {
        static void Main()
        {
            Console.WriteLine(StringReverser(Console.ReadLine())); ;
        }

        static string StringReverser(string input)
        {
            char[] arr = input.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}