using System;

namespace Printing
{
    class Printing
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());
            double p = double.Parse(Console.ReadLine());

            int totalPapers = s * n;
            double totalRealms = (double)totalPapers / 500;
            double priceRealms = totalRealms * p;

            Console.WriteLine("{0:F2}", priceRealms);
        }
    }
}