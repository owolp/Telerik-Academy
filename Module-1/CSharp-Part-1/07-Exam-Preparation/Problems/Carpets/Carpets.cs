using System;

namespace Carpets
{
    class Carpets
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int center = n / 2;
            //...../\.....
            //..../  \....
            //.../ /\ \...
            //../ /  \ \..
            //./ / /\ \ \.
            /// / /  \ \ \
            for (int row = 0; row < n / 2; row++)
            {
                Console.Write(new string('.', center - 1 - row));

                for (int i = 0; i <= row; i++)
                {                   
                    if (i % 2 == 0)
                    {
                        Console.Write('/');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }

                for (int i = row; i >= 0; i--)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write('\\');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }

                Console.WriteLine(new string('.', center - 1 - row));               
            }

            //\ \ \  / / /
            //.\ \ \/ / /.
            //..\ \  / /..
            //...\ \/ /...
            //....\  /....
            //.....\/.....
            for (int row = 1; row <= n / 2; row++)
            {
                Console.Write(new string('.', row - 1));

                for (int i = 0; i <= center - row; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write('\\');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                    
                }

                for (int i = center - row; i >= 0; i--)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write('/');
                    }
                    else
                    {
                        Console.Write(' ');
                    }

                }

                Console.WriteLine(new string('.', row - 1));
            }
        }
    }
}
