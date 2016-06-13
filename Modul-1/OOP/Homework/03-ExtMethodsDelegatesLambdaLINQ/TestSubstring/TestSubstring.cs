namespace TestSubstring
{
    using System;
    using System.Text;
    using ExtentionMethods;

    public class TestSubstring
    {
        public static void Main()
        {
            var sb = new StringBuilder("Lorem ipsum dolor sit amet, consectetur adipisicing elit. Earum, sequi.");

            Console.WriteLine("StringBuilder:");
            Console.WriteLine("\t{0}", sb);

            Console.WriteLine("StringBuilder from index 10 with length 10");
            Console.WriteLine("\t{0}", sb.Substring(10, 10));
        }
    }
}
