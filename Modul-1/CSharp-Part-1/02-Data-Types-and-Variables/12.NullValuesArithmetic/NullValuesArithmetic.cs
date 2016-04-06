//12. Null Values Arithmetic
//Null Values Arithmetic
//Description
//Create a program that assigns null values to an integer and to a double variable.
//    Try to print these variables at the console.
//    Try to add some number or the null literal to these variables and print the result.

using System;

namespace NullValuesArithmetic
{
    class NullValuesArithmetic
    {
        static void Main()
        {
            int? intVar = null;
            double? doubleVar = null;
            Console.WriteLine("{0}\n{1}", intVar, doubleVar); // the blank lines shows the null value

            intVar += 10;
            doubleVar += null;
            Console.WriteLine("{0}\n{1}", intVar, doubleVar); // the blank lines shows the null value
        }
    }
}