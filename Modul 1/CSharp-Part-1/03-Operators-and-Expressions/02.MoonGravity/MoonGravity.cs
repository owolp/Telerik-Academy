//02. Moon Gravity
//Description
//The gravitational field of the Moon is approximately 17% of that on the Earth.
//    Write a program that calculates the weight of a man on the moon by a given weight W(as a floating-point number) on the Earth.
//    The weight W should be read from the console.
//Input
//    The input will consist of a single line containing a single floating-point number - the weight W.
//Output
//    Output a single floating-point value - how much a man with the weight W on Earth will weigh on the Moon.Output all values with exactly 3-digit precision after the floating point.
//       Hint: You can use the built-in .NET functionality
//Constraints
//   The input weight will always be a valid floating-point number, always between 0 and 1000, exclusive.
//   Time limit: 0.1s
//   Memory limit: 8MB


using System;
using System.Threading;
using System.Globalization;

namespace MoonGravity
{
    class MoonGravity
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var line = Console.ReadLine();
            line = line.Replace(',', '.');
            float weightOnEarth = float.Parse(line);
            float moonGravity = 0.17F;
            float weightOnMoon = weightOnEarth * moonGravity;
            Console.WriteLine("{0:F3}",weightOnMoon);
        }
    }
}