namespace SubStringInText
{
    using System;

    class SubStringInText
    {
        static void Main()
        {
            Console.WriteLine(CheckStringOccurances(Console.ReadLine(), Console.ReadLine()));
        }

        static int CheckStringOccurances(string pattern, string text)
        {
            int stringCounter = 0;
            int index = 0;

            while (true)
            {
                int position = text.IndexOf(pattern, index, StringComparison.InvariantCultureIgnoreCase);

                if (position == -1)
                {
                    break;
                }

                index = position + 1;
                stringCounter++;
            }

            return stringCounter;
        }
    }
}