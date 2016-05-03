using System;

namespace CompareCharArrays
{
    class CompareCharArrays
    {
        static void Main()
        {
            var input = Console.ReadLine();
            char[] firstArray = input.ToCharArray();

            input = Console.ReadLine();
            char[] secondArray = input.ToCharArray();

            char symbol = 'a';

            int length = Math.Min(firstArray.Length, secondArray.Length);

            for (int i = 0; i < length; i++)
            {
                if (firstArray.Length > secondArray.Length)
                {
                    symbol = '>';
                    break;
                }
                else if (firstArray.Length < secondArray.Length)
                {
                    symbol = '<';
                    break;
                }
                else
                {
                    if (firstArray[i] < secondArray[i])
                    {
                        symbol = '<';
                    }
                    else if (firstArray[i] > secondArray[i])
                    {
                        symbol = '>';
                    }
                    else
                    {
                        symbol = '=';
                    }
                }
            }

            Console.WriteLine(symbol);
        }
    }
}