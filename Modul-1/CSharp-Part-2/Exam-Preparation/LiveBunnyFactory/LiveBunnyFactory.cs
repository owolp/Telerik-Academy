namespace LiveBunnyFactory
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Text;

    class LiveBunnyFactory
    {
        static void Main()
        {
            var cages = ReadInput();

            int index = 0;

            while (true)
            {
                int length = 0;

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


                BigInteger sum = 0;
                BigInteger product = 1;

                for (int i = index + 1; i < index + length + 1; i++)
                {
                    sum += cages[i];
                    product *= cages[i];
                }

                StringBuilder leftCages = new StringBuilder();

                for (int i = index + length + 1; i < cages.Count; i++)
                {
                    leftCages.Append(cages[i]);
                }


                StringBuilder sb = new StringBuilder();
                sb.Append(sum).Append(product).Append(leftCages);
                var sbAsString = sb.ToString();

                cages.Clear();

                foreach (char digit in sbAsString)
                {
                    cages.Add(digit - '0');
                }

                cages.RemoveAll(item => item == 0 || item == 1);

                index++;
            }

            Console.WriteLine(string.Join(" ", cages));

        }

        static List<int> ReadInput()
        {
            List<int> cages = new List<int>();
            var input = Console.ReadLine();

            while (input != "END")
            {
                cages.Add(int.Parse(input));
                input = Console.ReadLine();
            }

            return cages;
        }
    }
}