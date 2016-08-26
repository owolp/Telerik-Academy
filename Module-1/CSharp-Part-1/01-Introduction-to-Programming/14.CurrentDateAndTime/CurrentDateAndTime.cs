//14. Current Date and Time
//Current Date and Time
//Description
//    Create a console application that prints the current date and time.Find out how in Internet.

using System;
using System.Threading;
using System.Globalization;

namespace CurrentDateAndTime
{
    class CurrentDateAndTime
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var dateTime = DateTime.Now;
            Console.WriteLine(dateTime);
        }
    }
}