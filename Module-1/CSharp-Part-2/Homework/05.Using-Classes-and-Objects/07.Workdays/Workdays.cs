using System;
using System.Linq;
using System.Threading;
using System.Globalization;

namespace Workdays
{
    class Workdays
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            DateTime futureDate = Convert.ToDateTime(Console.ReadLine());

            DateTime todayDate = DateTime.Today.Date;

            Console.WriteLine(GetWorkingDays(todayDate, futureDate));
        }

        static readonly DateTime[] publicHolidays =
        {
                new DateTime(2016, 1, 1),              
                new DateTime(2016, 3, 3),              
                new DateTime(2016, 4, 29),             
                new DateTime(2016, 5, 1),              
                new DateTime(2016, 5, 2),              
                new DateTime(2016, 5, 6),              
                new DateTime(2016, 5, 24),             
                new DateTime(2016, 9, 6),              
                new DateTime(2016, 9, 22),             
                new DateTime(2016, 12, 24),            
                new DateTime(2016, 12, 25),            
                new DateTime(2016, 12, 26),            
        };

        static int GetWorkingDays(DateTime todayDate, DateTime futureDate)
        {
            int workingdays = 0;

            while (todayDate <= futureDate)
            {
                if (!publicHolidays.Contains(todayDate) && todayDate.DayOfWeek != DayOfWeek.Saturday && todayDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    workingdays++;
                }
                todayDate = todayDate.AddDays(1);
            }

            return workingdays;
        }
    }
}