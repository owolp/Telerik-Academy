using System;

namespace TheHorror
{
    class TheHorror
    {
        static void Main()
        {
            var text = Console.ReadLine();

            int position = 1;
            int counter = 0;
            int sum = 0;

            foreach (var ch in text) // var == char
            {
                if (position % 2 != 0)
                {
                    switch (ch)
                    {
                        case '1':
                            sum += 1;
                            counter++;
                            break;
                        case '2':
                            sum += 2;
                            counter++;
                            break;
                        case '3':
                            sum += 3;
                            counter++;
                            break;
                        case '4':
                            sum += 4;
                            counter++;
                            break;
                        case '5':
                            sum += 5;
                            counter++;
                            break;
                        case '6':
                            sum += 6;
                            counter++;
                            break;
                        case '7':
                            sum += 7;
                            counter++;
                            break;
                        case '8':
                            sum += 8;
                            counter++;
                            break;
                        case '9':
                            sum += 9;
                            counter++;
                            break;
                        case '0':
                            counter++;
                            break;
                        default:
                            break;
                    }
                }
                position++;
            }
            Console.WriteLine(counter + " " + sum);
        }
    }
}