namespace Initial
{
    using System;
    using DivisibleBy7And3;
    using TestIEnumerable;
    using TestString;
    using TestStudent;
    using TestSubstring;
    using TestTimer;

    public class Initial
    {
        public static void Main()
        {
            Action initialMethod = TestSubstring.Main;
            initialMethod += TestIEnumerable.Main;
            initialMethod += TestStudent.Main;
            initialMethod += TestString.Main;
            initialMethod += DivisibleBy7And3.Main;
            initialMethod += TestTimer.Main;

            initialMethod();
        }
    }
}
