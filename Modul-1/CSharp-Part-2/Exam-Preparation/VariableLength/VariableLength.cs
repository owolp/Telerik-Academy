namespace VariableLength
{
    using System;
    using System.Linq;

    class VariableLength
    {
        static string ToBinary(string x)
        {
            return Convert.ToString(byte.Parse(x), 2).PadLeft(8, '0');
        }

        static void Main()
        {
            #region old
            //var input = Console.ReadLine();
            //int[] encodedStrings = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            ////int linesLength = int.Parse(Console.ReadLine());
            ////string[] lines = new string[linesLength];

            ////for (int i = 0; i < linesLength; i++)
            ////{
            ////    lines[i] = Console.ReadLine();
            ////}

            //StringBuilder sb = new StringBuilder();
            //foreach (int number in encodedStrings)
            //{
            //    var binaryNumber = Convert.ToString(number, 2).PadLeft(8, '0');
            //    sb.Append(binaryNumber);
            //}
            ////Console.WriteLine(sb);

            //StringBuilder reversedSB = new StringBuilder();
            //for (int i = sb.Length - 1; i >= 0; i--)
            //{
            //    reversedSB.Append(sb[i]);
            //}
            ////Console.WriteLine(reversedSB);

            //BigInteger tempNumber = BigInteger.Parse(reversedSB.ToString());

            ////Console.WriteLine(tempNumber);

            //string[] encodedText = tempNumber.ToString().Split(new char[] { '0' }, StringSplitOptions.RemoveEmptyEntries);

            //Console.WriteLine();
            #endregion

            var binaryNumber = string.Join("", Console.ReadLine()
                .Split(' ')
                .Select(ToBinary)
                .ToArray());
            
            var code = binaryNumber.Split(new char[] { '0'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Length);

            int n = int.Parse(Console.ReadLine());
            char[] reversedTable = new char[n + 1];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                int index = int.Parse(line.Substring(1));
                reversedTable[index] = line[0];
            }

            foreach (int x in code)
            {
                Console.Write(reversedTable[x]);
            }

            //var text = code.Select(x => reversedTable[x])
            //    .ToArray();

            Console.WriteLine();
        }
    }
}
