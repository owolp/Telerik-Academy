namespace TestBitArrayClass
{
    using System;
    using BitArrayClass.Models;

    public class TestBitArrayClass
    {
        public static void Main()
        {
            BitArray64 firstArray = new BitArray64(1u);
            BitArray64 secondArray = new BitArray64(2u);
            BitArray64 thirdArray = new BitArray64(1u);

            Console.WriteLine(new string('=', 50));

            // Problem 5. 64 Bit array Equals()
            Console.WriteLine("Problem 5. 64 Bit array Equals()\n");
            Console.WriteLine("FirstArray.Equals(SecondArray) = {0}", firstArray.Equals(secondArray));
            Console.WriteLine("FirstArray.Equals(ThirdArray) = {0}\n", firstArray.Equals(thirdArray));

            Console.WriteLine(new string('-', 20));

            // Problem 5. 64 Bit array GetHashCode()
            Console.WriteLine("Problem 5. 64 Bit array GetHashCode()\n");
            Console.WriteLine("HashCode First Array: {0}", firstArray.GetHashCode());
            Console.WriteLine("HashCode Second Array: {0}\n", secondArray.GetHashCode());

            Console.WriteLine(new string('-', 20));

            // Problem 5. 64 Bit array == and !=
            Console.WriteLine("Problem 5. 64 Bit array == and !=\n");
            Console.WriteLine("== and !=\n");
            Console.WriteLine("FirstArray == SecondArray: {0}", firstArray == secondArray);
            Console.WriteLine("FirstArray == SecondArray: {0}\n", firstArray != secondArray);
        }
    }
}
