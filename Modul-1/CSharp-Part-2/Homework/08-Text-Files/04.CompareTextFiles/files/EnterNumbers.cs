namespace EnterNumbers
{
    using System;

    class EnterNumbers
    {
        static void Main()
        {
            string result = string.Empty;

            int[] numbers = new int[12];
            numbers[0] = 1;
            numbers[numbers.Length - 1] = 100;

            try
            {
                for (int i = 1; i < numbers.Length - 1; i++)
                {
                    numbers[i] = int.Parse(Console.ReadLine());
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Exception");
                return;
            }

            bool numbersSeqGrow = true;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (!(ReadNumber(numbers[i - 1], numbers[i])))
                {
                    numbersSeqGrow = false;
                    break;
                }
            }

            if (numbersSeqGrow)
            {
                Console.WriteLine(string.Join(" < ", numbers));
            }
            else
            {
                Console.WriteLine("Exception");
            }
        } 


        static bool ReadNumber(int start, int end)
        {
            var startIsLowerThanEnd = true;

            if (start >= end)
            {
                startIsLowerThanEnd = false;
            }

            return startIsLowerThanEnd;
        }
    }
}
