using System;

namespace NextDate
{
    class NextDate
    {
        static void Main()
        {
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());

            DateTime date = new DateTime(year, month, day);
            date = date.AddDays(1);

            Console.WriteLine("{0:d.M.yyyy}", date);
        }
    }
}