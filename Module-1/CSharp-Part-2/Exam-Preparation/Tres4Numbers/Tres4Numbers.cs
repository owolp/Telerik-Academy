using System;
using System.Collections.Generic;
using System.Text;

namespace Tres4Numbers
{
    class Tres4Numbers
    {
        static void Main()
        {
            ulong input = ulong.Parse(Console.ReadLine());

            ulong outBase = 9;

            if (input == 0)
            {
                Console.WriteLine(Dictionary['0']);
            }
            else
            {
                Console.WriteLine(BaseToSpecial(DecToBase(outBase, input)));
            }      
        }

        static Dictionary<char, string> Dictionary = new Dictionary<char, string>()
        {
            { '0' , "LON+" },
            { '1' , "VK-" },
            { '2' , "*ACAD" },
            { '3' , "^MIM" },
            { '4' , "ERIK|" },
            { '5' , "SEY&" },
            { '6' , "EMY>>" },
            { '7' , "/TEL" },
            { '8' , "<<DON" },
        };

        static string DecToBase(ulong @base, ulong decimalNumber)
        {
            string baseNumber = string.Empty;

            while (decimalNumber > 0)
            {
                ulong digit = decimalNumber % @base;

                if (0 <= digit && digit <= @base)
                {
                    baseNumber = (char)digit - (char)0 + baseNumber;
                }

                decimalNumber /= @base;
            }

            return baseNumber;
        }

        static StringBuilder BaseToSpecial(string baseNumber)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < baseNumber.Length; i++)
            {
                sb.Append(Dictionary[baseNumber[i]]);
            }

            return sb;
        }
    }
}