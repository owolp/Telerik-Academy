namespace TestString
{
    using System;
    using System.Collections.Generic;
    using ExtentionMethods;

    public class TestString
    {
        public static void Main()
        {
            // Problem 17. Longest string
            List<string> list = new List<string>();

            list.Add("Lorem");
            list.Add("ipsum");
            list.Add("sit");
            list.Add("amet");
            list.Add("consectetur");
            list.Add("adipisicing");
            list.Add("elit");

            Console.WriteLine("Problem 17. Longest string");
            Console.WriteLine("\t{0}", list.LongestString());

            Console.WriteLine(new string('=', 50));
        }
    }
}
