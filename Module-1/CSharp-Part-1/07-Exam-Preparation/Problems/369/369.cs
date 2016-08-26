using System;

namespace _369
{
    class _369
    {
        static void Main()
        {
            long a = long.Parse(Console.ReadLine());
            long code = int.Parse(Console.ReadLine());
            long c = long.Parse(Console.ReadLine());

            long r = 0;

            switch (code)
            {
                case 3:
                    r = a + c;
                    break;
                case 6:
                    r = a * c;
                    break;
                case 9:
                    r = a % c;
                    break;
                default:
                    return;
            }

            double remainder = 0;

            if (r % 3 == 0)
            {
                remainder = r / 3;
            }
            else
            {
                remainder = r % 3;
            }

            Console.WriteLine(remainder);
            Console.WriteLine(r);
        }
    }
}