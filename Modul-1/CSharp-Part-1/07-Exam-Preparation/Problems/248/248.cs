using System;

namespace _248
{
    class _248
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            uint secret = uint.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            long r = 0;

            switch (secret)
            {
                case 2:
                    r = a % c;
                    break;
                case 4:
                    r = a + c;
                    break;
                case 8:
                    r = a * c;
                    break;
                default:
                    return;
            }

            double remainder = 0;

            if (r % 4 == 0)
            {
                remainder = (double)r / 4;
            }
            else
            {
                remainder = r % 4;
            }

            Console.WriteLine(remainder);
            Console.WriteLine(r);
        }
    }
}