namespace CSharpTaskFour
{
    using System;

    public class TaskFour
    {
        public static void Main()
        {
            var readSize = Console.ReadLine();
            int size = int.Parse(readSize);

            var readSpecialCharacter = Console.ReadLine();
            char specialCharacter = char.Parse(readSpecialCharacter);
            char symbol = (char)specialCharacter;

            int firstRowLength = size / 2 - 1;
            for (int row = 0; row < firstRowLength; row++)
            {
                Console.Write(new string(' ', row));
                Console.Write(new string(symbol, size - row));
                Console.Write(new string(' ', size));
                Console.Write(new string(symbol, size - row));
                Console.WriteLine(new string(' ', row));

            }

            int secondRowLength = size / 2 + 2;
            Console.Write(new string(' ', firstRowLength));
            Console.Write(new string(symbol, secondRowLength));
            Console.Write(new string(' ', firstRowLength));
            Console.Write(symbol);
            Console.Write(new string(' ', 1));
            Console.Write(symbol);
            Console.Write(new string(' ', firstRowLength));
            Console.Write(new string(symbol, secondRowLength));
            Console.WriteLine(new string(' ', firstRowLength));

            int thirdRowLength = (firstRowLength + secondRowLength) / 3;
            for (int row = 1; row <= thirdRowLength; row++)
            {
                Console.Write(new string(' ', size / 2));
                Console.Write(new string(symbol, (2 * size) + 1));
                Console.WriteLine(new string(' ', size / 2));
            }

            int fourthRowLength = firstRowLength;
            for (int row = 0; row <= fourthRowLength; row++)
            {
                Console.Write(new string(' ', size + 1 + row));
                Console.Write(new string(symbol, (size - 2) - (2 * row)));
                Console.WriteLine(new string(' ', size + 1 + row));
            }
        }
    }
}
