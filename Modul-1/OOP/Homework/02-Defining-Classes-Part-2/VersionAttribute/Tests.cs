namespace VersionAttribute
{
    using System;
    u
    [Version(1, 0)]
    public class VersionAttributeTester
    {
        public static void Main()
        {
            object[] attributes = typeof(VersionAttributeTester).GetCustomAttributes(false);
            Console.WriteLine("Version: {0}", attributes[0]);
        }
    }
}