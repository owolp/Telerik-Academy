using System;
using System.Text;
// 0/100 BGCODER

namespace NumberAsArray
{
    class NumberAsArray
    {
        static void Main()
        {
            string arrSizes  = Console.ReadLine().Replace(" ", string.Empty);
            string firstArr = Console.ReadLine().Replace(" ", string.Empty);
            string secondArr = Console.ReadLine().Replace(" ", string.Empty);

            int firstNumber = ConvertToInt(firstArr);
            int secondNumber = ConvertToInt(secondArr);

            int length = BiggerLength(arrSizes);
            int sum = firstNumber + secondNumber;
            StringBuilder result = ConvertResult(sum, length);

            string resultAsString = Convert.ToString(result);
            
            Console.WriteLine(resultAsString.Trim());
        }

        static int ConvertToInt(string stringArr)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = stringArr.Length - 1; i >= 0; i--)
            {
                sb.Append(stringArr[i]);
            }

            int number = int.Parse(sb.ToString());

            return number;
        }

        static StringBuilder ConvertResult(int sum, int length)
        {
            StringBuilder sb = new StringBuilder();

            string sumAsString = Convert.ToString(sum);

            int index = sumAsString.Length - 1;

            for (int i = 0; i < length; i++)
            {
                if (i >= sumAsString.Length)
                {
                    sb.Append("0").Append(" ");
                }
                else
                {
                    sb.Append(sumAsString[index]).Append(" ");
                    index--;
                }
            }

            return sb;
        }

        static int BiggerLength(string arrSizes)
        {
            int firstArrSize = arrSizes[0] - '0';
            int secondArrSize = arrSizes[1] - '0';

            return firstArrSize > secondArrSize ? firstArrSize : secondArrSize;
        }
    }
}