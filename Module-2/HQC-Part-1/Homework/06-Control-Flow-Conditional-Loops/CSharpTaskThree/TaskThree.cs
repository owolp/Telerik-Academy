namespace CSharpTaskThree
{
    using System;

    public class TaskThree
    {
        public static void Main()
        {
            var readLine = Console.ReadLine();
            int number = int.Parse(readLine);
            long pagesCount = 0;

            for (int i = 1; i <= number; i++)
            {
                if (i < 10)
                {
                    pagesCount += 1;
                }
                else if (10 <= i && i < 100)
                {
                    pagesCount += 2;
                }
                else if (100 <= i && i < 1000)
                {
                    pagesCount += 3;
                }
                else if (1000 <= i && i < 10000)
                {
                    pagesCount += 4;
                }
                else if (10000 <= i && i < 100000)
                {
                    pagesCount += 5;
                }
                else if (100000 <= i && i < 1000000)
                {
                    pagesCount += 6;
                }
                else if (1000000 <= i && i < 10000000)
                {
                    pagesCount += 7;
                }
                else
                {
                }
            }

            Console.WriteLine(pagesCount);
        }
    }
}
