//04. Formatting Numbers
//Description
//    Write a program that reads 3 numbers:
//        integer a(0 <= a <= 500)
//        floating-point b
//        floating-point c
//    The program then prints them in 4 virtual columns on the console.Each column should have a width of 10 characters.
//        The number a should be printed in hexadecimal, left aligned
//        Then the number a should be printed in binary form, padded with zeros.
//        The number b should be printed with 2 digits after the decimal point, right aligned.
//        The number c should be printed with 3 digits after the decimal point, left aligned.

using System;
using System.Threading;
using System.Globalization;

namespace FormattingNumbers
{
    class FormattingNumbers
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            int a = Int32.MinValue;
            while (a < 0 | a > 500)
            {
                a = int.Parse(Console.ReadLine());
            }

            var line = Console.ReadLine();
            line = line.Replace(',', '.');
            double b = double.Parse(line);

            line = Console.ReadLine();
            line = line.Replace(',', '.');
            double c = double.Parse(line);

            string numberAHex = String.Format("{0,-10:X}", a);
            string numberABinary = Convert.ToString(a, 2).PadLeft(10, '0');
            string numberBFormatted = String.Format("{0,10:F2}", b);
            string numberCFormatted = String.Format("{0,-10:F3}", c);

            Console.WriteLine("{0}|{1}|{2}|{3}|", numberAHex, numberABinary, numberBFormatted, numberCFormatted);
        }
    }
}