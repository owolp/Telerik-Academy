using System;
// 80/100 BGCODER

namespace CompareCharArrays
{
    class CompareCharArrays
    {
        static void Main()
        {
            string firstString = Console.ReadLine();
            string secondString = Console.ReadLine();


            if (firstString.Length > secondString.Length)
            {
                Console.WriteLine(">");
            }
            else if (firstString.Length < secondString.Length)
            {
                Console.WriteLine("<");
            }
            else
            {
                int compare = firstString.CompareTo(secondString);

                if (compare == -1)
                {
                    Console.WriteLine("<");
                }
                else if (compare == 1)
                {
                    Console.WriteLine(">");
                }
                else
                {
                    Console.WriteLine("=");
                }
            }
        }
    }
}