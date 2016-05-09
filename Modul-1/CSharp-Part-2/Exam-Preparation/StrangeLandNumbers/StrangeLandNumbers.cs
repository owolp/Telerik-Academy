using System;
using System.Linq;
using System.Text;

namespace StrangeLandNumbers
{
    class StrangeLandNumbers
    {
        static void Main()
        {
            var inputString = Console.ReadLine();

            string[] words = ConvertToStringArr(inputString);

            ulong sum = 0;
            int baseSystem = 7;

            int index = words.Length - 1;
            for (int i = 0; i < words.Length; i++)
            {
                ulong word = (ulong)(GetValue(words[index]) * Math.Pow(baseSystem, i));
                sum += word;
                index--;
            }
            Console.WriteLine(sum);
        }

        static string[] ConvertToStringArr(string inputString)
        {
            var word = "";
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < inputString.Length; i++)
            {
                char letter = inputString[i];

                if (letter == 'f')
                {
                    sb.AppendFormat("{0} ", word);
                    word = "f";
                }
                else if ((letter == 'b' || letter == 'o' || letter == 'm' || letter == 'l' || letter == 'p' || letter == 'h') && word != string.Empty)
                {
                    sb.AppendFormat("{0} ", word);
                    word = Convert.ToString(letter);
                }
                else if (i == inputString.Length - 1)
                {
                    word += letter;
                    sb.AppendFormat("{0}", word);
                }
                else
                {
                    word += letter;
                }
            }

            string outputString = Convert.ToString(sb);
            string[] words = outputString.Split(' ').ToArray();

            return words;
        }

        static ulong GetValue(string word)
        {
            ulong value = 0;

            switch (word)
            {
                case "f":
                    value = 0;
                    break;
                case "bIN":
                    value = 1;
                    break;
                case "oBJEC":
                    value = 2;
                    break;
                case "mNTRAVL":
                    value = 3;
                    break;
                case "lPVKNQ":
                    value = 4;
                    break;
                case "pNWE":
                    value = 5;
                    break;
                case "hT":
                    value = 6;
                    break;
                default:
                    break;
            }

            return value;
        }
    }
}
