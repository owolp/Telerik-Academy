//03. Divide by 7 and 5
//Description
//Write a program that does the following:
//    Reads an integer number from the console.
//    Stores in a variable if the number can be divided by 7 and 5 without remainder.
//    Prints on the console "true NUMBER" if the number is divisible without remainder by 7 and 5. Otherwise prints "false NUMBER". In place of NUMBER print the value of the input number.
//Input
//    The input will consist of a single integer value.
//Output
//    The output must always follow the format specified in the description. See the sample tests.
//Constraints
//    The input will always consist of valid integers and follow the format in the description.
//    Time limit: 0.1s
//    Memory limit: 8MB

using System;

namespace Divide
{
    class Divide
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            bool devideByFive = number % 5 == 0;
            bool devideBySeven = number % 7 == 0;
            var devide = "false";

            if (devideByFive & devideBySeven)
            {
                devide = "true";
            }

            Console.WriteLine("{0} {1}", devide, number);
        }
    }
}