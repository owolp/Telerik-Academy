//10. Odd and Even Product
//Description
//You are given N integers(given in a single line, separated by a space).
//    Write a program that checks whether the product of the odd elements is equal to the product of the even elements.
//    Elements are counted from 1 to N, so the first element is odd, the second is even, etc.
//Input
//    On the first line you will receive the number N
//    On the second line you will receive N numbers separated by a whitespace
//Output
//    If the two products are equal, output a string in the format "yes PRODUCT_VALUE", otherwise write on the console "no ODD_PRODUCT_VALUE EVEN_PRODUCT_VALUE"
//Constraints
//    N will always be a valid integer number in the range [4, 50]
//    All input numbers from the second line will also be valid integers
//    Time limit: 0.1s
//    Memory limit: 16MB

using System;

namespace OddAndEvenProduct
{
    class OddAndEvenProduct
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            string[] stringNumbersArray = Console.ReadLine().Split(' ');
            int[] intNumbersArray = new int[stringNumbersArray.Length];

            for (int i = 0; i < stringNumbersArray.Length; i++)
            {
                intNumbersArray[i] = Convert.ToInt32(stringNumbersArray[i]);
            }

            long productEven = 1;
            long productOdd = 1;
            
            for (int i = 0; i < intNumbersArray.Length; i++)
            {
                if (i % 2 == 0)
                {
                    productEven *= intNumbersArray[i];
                }
                else
                {
                    productOdd *= intNumbersArray[i];
                }
            }

            Console.WriteLine(productEven == productOdd ? "yes {0}" : "no {0} {1}", productEven, productOdd);
        }
    }
}