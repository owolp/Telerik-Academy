﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TribonacciTriangle
{
    class Program
    {
        static void Main(string[] args)
        {

            long oldest = long.Parse(Console.ReadLine()),
                middle = long.Parse(Console.ReadLine()),
                newest = long.Parse(Console.ReadLine());

            int rowsToGenerate = int.Parse(Console.ReadLine());

            Console.WriteLine(oldest);
            Console.WriteLine(middle + " " + newest);

            int currentRow = 3;
            int currentCol = 0;

            while (currentRow <= rowsToGenerate)
            {
                long currentNumber = oldest + middle + newest;

                oldest = middle;
                middle = newest;
                newest = currentNumber;

                currentCol++;

                if (currentCol < currentRow)
                {
                    Console.Write(currentNumber + " ");
                }
                else
                {
                    Console.WriteLine(currentNumber);
                    currentCol = 0;
                    currentRow++;
                }
            }
        }
    }
}
