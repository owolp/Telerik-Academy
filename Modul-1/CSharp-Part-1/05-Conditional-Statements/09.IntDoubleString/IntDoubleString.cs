//09. Int, Double, String
//Description
//Write a program that, depending on the first line of the input, reads an int, double or string variable.
//    If the variable is int or double, the program increases it by one.
//    If the variable is a string, the program appends* at the end.
//    Print the result at the console. Use switch statement.
//Input
//    On the first line you will receive the type of input as string in the following form:
//        integer for int
//        real for double
//        text for string
//    On the second line you will be given the value of the variable.
//Output
//    Write a single line on the console - the value transformed according to the rules from the description.
//        Print all double variables with exactly 2-digits precision after the floating point. Example: 0.99
//Constraints
//    The input will always be valid and in the described format.
//    All input numbers will be between -1000 and 1000.
//    Time limit: 0.1s
//    Memory limit: 16MB

using System;
using System.Threading;
using System.Globalization;

namespace IntDoubleString
{
    class IntDoubleString
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var variableValue = Console.ReadLine();
            string line;

            switch (variableValue)
            {
                case "integer":
                    line = Console.ReadLine();
                    int intValue = int.Parse(line);
                    intValue++;
                    Console.WriteLine(intValue);
                    break;
                case "real":
                    line = Console.ReadLine();
                    line = line.Replace(',', '.');
                    double doubleValue = double.Parse(line);
                    doubleValue++;
                    Console.WriteLine("{0:F2}",doubleValue);
                    break;
                case "text":
                    var stringValue = Console.ReadLine();
                    stringValue = stringValue + "*";
                    Console.WriteLine(stringValue);
                    break;
                default:
                    break;
            }
        }
    }
}