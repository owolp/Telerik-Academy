namespace BunnyFactory
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Text;

    class BunnyFactory
    {
        static void Main()
        {
            List<long> cages = ReadInput();

            BigInteger sum = 0;
            BigInteger product = 1;

            int index = 0;

            while (true)
            {
                StringBuilder sb = new StringBuilder();

                var length = 0;

                if (length + cages[0] > cages.Count)
                {
                    break;
                }
                else
                {
                    for (int i = 0; i <= index; i++)
                    {
                        length += (int)cages[i];
                    }
                }

                if (length >= cages.Count)
                {
                    break;
                }

                for (int i = index + 1; i < length + index + 1; i++)
                {
                    sum += cages[i];
                    product *= cages[i];
                }

                sb.Append(sum).Append(product);

                for (int i = length + index + 1; i < cages.Count; i++)
                {
                    sb.Append(cages[i]);
                }

                string sbToString = sb.ToString();

                cages.Clear();

                foreach (char digit in sbToString)
                {
                    cages.Add(digit - '0');
                }

                cages.RemoveAll(item => item == 0);
                cages.RemoveAll(item => item == 1);

                sum = 0;
                product = 1;
                index++;
            }

            Console.WriteLine(string.Join(" ", cages));
        }

        static List<long> ReadInput()
        {
            List<long> cages = new List<long>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }
                cages.Add(long.Parse(input));
            }

            return cages;
        }
    }
}