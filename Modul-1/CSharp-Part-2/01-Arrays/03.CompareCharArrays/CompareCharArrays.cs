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

            if (firstArray.Length > secondArray.Length)
            {
                symbol = '>';
                Console.WriteLine(symbol);
                return;
            }
            else if (firstArray.Length < secondArray.Length)
            {
                symbol = '<';
                Console.WriteLine(symbol);
                return;
            }

            int length = Math.Min(firstArray.Length, secondArray.Length);

            bool equal = true;

            for (int i = 0; i < length; i++)
            {
                var firstArraySymbol = firstArray[i];
                var secondArraySymbol = secondArray[i];

                if (firstArraySymbol - 'a' < 0 && 0 <= secondArraySymbol - 'a')
                {
                    symbol = '>';
                    equal = false;
                }
                else if (secondArraySymbol - 'a' < 0 && 0 <= firstArraySymbol - 'a')
                {
                    symbol = '<';
                    equal = false;
                }
                else
                {
                    if (firstArraySymbol < secondArraySymbol)
                    {
                        symbol = '<';
                        equal = false;
                    }
                    else if (firstArraySymbol > secondArraySymbol)
                    {
                        symbol = '>';
                        equal = false;
                    }
                }
            }

            Console.WriteLine(equal == true ? "=" : "{0}", symbol);
        }
    }
}