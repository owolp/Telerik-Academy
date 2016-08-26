namespace TwoGirlsOnePath
{
    using System;
    using System.Linq;
    using System.Numerics;

    class TwoGirlsOnePath
    {
        static void Main()
        {
            long[] numbers = ReadInput();

            BigInteger totalFlowersMolly = 0;
            BigInteger totalFlowersDolly = 0;

            int indexMolly = 0;
            int indexDolly = numbers.Length - 1;

            string result = string.Empty;

            while (true)
            {

                if (numbers[indexMolly] == 0 || numbers[indexDolly] == 0)
                {
                    if (numbers[indexMolly] == 0 && numbers[indexDolly] == 0)
                    {
                        result = "Draw";
                    }
                    else if (numbers[indexMolly] == 0)
                    {
                        result = "Dolly";
                    }
                    else if (numbers[indexDolly] == 0)
                    {
                        result = "Molly";
                    }

                    totalFlowersMolly += numbers[indexMolly];
                    totalFlowersDolly += numbers[indexDolly];
                    break;
                }

                long currentFlowersMolly = numbers[indexMolly];
                long currentFlowersDolly = numbers[indexDolly];

                if (indexMolly == indexDolly)
                {
                    totalFlowersMolly += currentFlowersMolly / 2;
                    totalFlowersDolly += currentFlowersDolly / 2;
                    numbers[indexMolly] = currentFlowersMolly % 2;
                }
                else
                {
                    totalFlowersMolly += currentFlowersMolly;
                    totalFlowersDolly += currentFlowersDolly;

                    numbers[indexMolly] = 0;
                    numbers[indexDolly] = 0;
                }

                indexMolly = FindIndexMolly(indexMolly, currentFlowersMolly, numbers);
                indexDolly = FindIndexDolly(indexDolly, currentFlowersDolly, numbers);


            }

            PrintResult(result, totalFlowersMolly, totalFlowersDolly);

        }

        static long[] ReadInput()
        {
            return Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
        }

        static void PrintResult(string result, BigInteger totalFlowersMolly, BigInteger totalFlowersDolly)
        {
            Console.WriteLine(result);
            Console.WriteLine(totalFlowersMolly + " " + totalFlowersDolly);
        }

        static int FindIndexMolly(int indexMolly, BigInteger currentFlowersMolly, long[] numbers)
        {
            return (int)((indexMolly + currentFlowersMolly) % numbers.Length);
        }

        static int FindIndexDolly(int indexDolly, BigInteger currentFlowersDolly, long[] numbers)
        {
            indexDolly = (int)((indexDolly - currentFlowersDolly) % numbers.Length);
            if (indexDolly < 0)
            {
                indexDolly += numbers.Length;
            }

            return indexDolly;
        }
    }
}
