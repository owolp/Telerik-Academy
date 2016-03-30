//15. Age
//Description
//Write a program that reads your birthday(in the format MM.DD.YYYY) from the console and prints on the console how old you are you now and how old will you be after 10 years.
//Input
//    The input will always consist of a single line - a birth-date.
//Output
//    You should print two lines with one number on the each line:
//        How old are you now, on the first line.
//        How old will you be after 10 years, on the second line.
//Constraints
//    The date read from the console will always be in a valid DateTime format.
//    All dates will be earlier than 2017.
//    Time limit: 0.1s
//    Memory limit: 16MB

using System;

namespace Age
{
    class Age
    {
        static void Main()
        {
            var line = Console.ReadLine();
            DateTime birthday= DateTime.Parse(line);

            var birthdayDay = birthday.Day;
            var birthdayMonth = birthday.Month;
            var birthdayYear = birthday.Year;

            var todayDay = DateTime.Now.Day;
            var todayMonth = DateTime.Now.Month;
            var todayYear = DateTime.Now.Year;

            var currentAge = todayYear - birthdayYear;

            if (birthdayMonth > todayMonth | (birthdayMonth == todayMonth & birthdayDay > todayDay))
            {
                currentAge--;
            }

            Console.WriteLine(currentAge);
            var ageAfter10Years = currentAge + 10;
            Console.WriteLine(ageAfter10Years);
        }
    }
}