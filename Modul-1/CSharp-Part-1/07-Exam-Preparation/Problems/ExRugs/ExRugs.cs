using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Partial, not working


namespace ExRugs
{
    class ExRugs
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            int lines = 2 * n + 1;

            //###\...../###
            //####\.../####
            //#####\./#####


            //\#####X#####/
            if (lines - 5 - 2 * d > 2)
            {
                Console.Write(new string('.', lines - 3 - d));
            }
            Console.Write('\\');
            Console.Write(new string('#', d));
            Console.Write('X');
            Console.Write(new string('#', d));
            if ((lines - 2 * d - 1) / 2 == 1)
            {
                Console.Write('/');
            }
            else
            {
                Console.WriteLine('/');
            }
            if (lines - 5 - 2 * d > 2)
            {
                Console.WriteLine(new string('.', lines - 3 - d));
            }


            //.\#########/.
            //..\#######/..


            //...X#####X...
            Console.Write(new string('.', (lines - d - 2) / 2));
            Console.Write('X');
            Console.Write(new string('#', d));
            Console.Write('X');
            Console.WriteLine(new string('.', (lines - d - 2) / 2));

            //../#######\..
            //./#########\.


            ///#####X#####\


            //#####/.\#####
            //####/...\####
            //###/.....\###

        }
    }
}
