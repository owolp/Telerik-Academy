using System;

namespace BatGoikoTower
{
    class BatGoikoTower
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int dots = n - 1;
            int line = 2;
            int currentLine = 2;

            for (int row = 1, index = 0; row <= n; row++, index +=2)
            {
                Console.Write(new string('.', dots - row + 1));
                Console.Write('/');

                if (row % line == 0)
                {
                    Console.Write(new string('-', index));
                    line += currentLine; /*
                    by default line = 2. Once row % line == 0 (the first time it is when 2 % 2 == 0)
                    line becomes 2 + currentLine (by default 2) = 4;
                    Then we increase currentLine by 1, so it becomes 3;
                    So the next time row % line == 0 will be when row = 4, 4 % 4 == 0;
                    line becomes 4 + currentLine (which is 3);
                    So the next time row % line == 0 will be when row = 7, 7 % 7 ==0;
                    line becomes 7 + 4 = 11;
                    Then we increase currentLine by 1, so it becomes 4 and so on.
                    */
                    currentLine++;
                }
                else
                {
                    Console.Write(new string('.', index));
                }



                Console.Write('\\');
                Console.WriteLine(new string('.', dots - row + 1));
            }
        }
    }
}
