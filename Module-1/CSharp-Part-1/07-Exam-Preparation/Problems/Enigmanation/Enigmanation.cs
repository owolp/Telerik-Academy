using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigmanation
{
    class Enigmanation
    {
        static void Main()
        {
            var text = Console.ReadLine();

            int position = 0;

            char symbol = text[position];

            double result = 0;
            int sum = 0;

            while (symbol != '=')
            {
                //int sum = 0;
                if (symbol == '(')
                {
                    while (symbol != ')')
                    {
                        position++;
                        int digit = text[position];
                        position++;
                        char sign = text[position];

                        switch (sign)
                        {
                            case '+': sum += digit; break;
                            case '-': sum -= digit; break;
                            case '*': sum *= digit; break;
                            case '%': sum %= digit; break;
                            default:
                                break;
                        }
                    }
                }
                position++;
                symbol = text[position];
            }

            Console.WriteLine("{0:F3}", sum);
        }
    }
}
