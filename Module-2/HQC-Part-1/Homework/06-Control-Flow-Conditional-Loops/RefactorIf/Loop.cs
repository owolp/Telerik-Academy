namespace RefactorIf
{
    using System;

    public class Loop
    {
        public void CheckSomething(int[] numbers, int expectedValue)
        {
            bool isFound = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentValue = numbers[i];

                if (currentValue == expectedValue)
                {
                    isFound = true;
                }
                else
                {
                }

                Console.WriteLine(currentValue);
            }

            if (isFound)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
