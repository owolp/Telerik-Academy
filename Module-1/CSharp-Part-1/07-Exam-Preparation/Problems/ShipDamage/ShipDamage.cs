using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipDamage
{
    class ShipDamage
    {
        static void Main()
        {
            // rectangle points
            int sX1 = Math.Abs(int.Parse(Console.ReadLine()));
            int sY1 = Math.Abs(int.Parse(Console.ReadLine()));
            int sX2 = Math.Abs(int.Parse(Console.ReadLine()));
            int sY2 = Math.Abs(int.Parse(Console.ReadLine()));

            int h = int.Parse(Console.ReadLine());

            // hit points
            int hitX1 = Math.Abs(int.Parse(Console.ReadLine()));
            int hitY1 = Math.Abs(int.Parse(Console.ReadLine()));
            int hitX2 = Math.Abs(int.Parse(Console.ReadLine()));
            int hitY2 = Math.Abs(int.Parse(Console.ReadLine()));
            int hitX3 = Math.Abs(int.Parse(Console.ReadLine()));
            int hitY3 = Math.Abs(int.Parse(Console.ReadLine()));





            bool xInside = (sX2 >= hitX1 + h) && (hitX1 + h >= sX1);
            bool yInside = (sY2 <= hitY1) && (hitY1 <= sY1);
            int result = 0;

            if (xInside && yInside)
            {
                result += 100;
                
            }
            if (xInside)
            {
                result += 50;
            }
            if (yInside)
            {
                result += 50;
            }
            if (sX2 == hitX1 || sX1 == hitX1)
            {
                result += 25;
            }
            if (sY2 == hitY1 || sY1 == hitY1)
            {
                result += 25;
            }

            xInside = (sX2 <= hitX2 + h) && (hitX2 + h <= sX1);
            yInside = (sY2 >= hitY2) && (hitY2 >= sY1);

            if (xInside && yInside)
            {
                result += 100;

            }
            if (xInside)
            {
                result += 50;
            }
            if (yInside)
            {
                result += 50;
            }
            if (sX2 == hitX2 || sX1 == hitX2)
            {
                result += 25;
            }
            if (sY2 == hitY2 || sY1 == hitY2)
            {
                result += 25;
            }

            xInside = (sX2 <= hitX3 + h) && (hitX3 + h <= sX1);
            yInside = (sY2 >= hitY3) && (hitY3 >= sY1);

            if (xInside && yInside)
            {
                result += 100;

            }
            if (xInside)
            {
                result += 50;
            }
            if (yInside)
            {
                result += 50;
            }
            if (sX2 == hitX3 || sX1 == hitX3)
            {
                result += 25;
            }
            if (sY2 == hitY3 || sY1 == hitY3)
            {
                result += 25;
            }

            Console.WriteLine(result);
        }
    }
}
