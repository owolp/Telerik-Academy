namespace AllTasks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Task03;
    using Task01;
    using Task02;
    using Task04;
    using Task05;
    using Task06;
    using Task07;
    using Task08;
    using Task09;
    using Task11;
    using Task12;
    using Task13;

    public class StartUp
    {
        static void Main()
        {
            string task01 = @"Task 01 - Write a program that reads from the console a sequence of positive integer numbers.

            The sequence ends when empty line is entered.
            Calculate and print the sum and average of the elements of the sequence.
            Keep the sequence in List<int>.";
            Console.WriteLine(task01);
            Task01.Main();
            Console.WriteLine(new string('=', 50));

            string task02 = @"Task 02 - Write a program that reads N integers from the console and reverses them using a stack.

            Use the Stack<int> class.";

            Console.WriteLine(task02);
            Task02.Main();
            Console.WriteLine(new string('=', 50));

            string task03 = @"Task 03 - Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them in an increasing order.";
            Console.WriteLine(task03);
            Task03.Main();
            Console.WriteLine(new string('=', 50));

            string task04 = @"Task 04 - Write a method that finds the longest subsequence of equal numbers in given List and returns the result as new List<int>. Write a program to test whether the method works correctly.";
            Console.WriteLine(task04);
            Task04.Main();
            Console.WriteLine(new string('=', 50));

            string task05 = @"Task 05 - Write a program that removes from given sequence all negative numbers.";
            Console.WriteLine(task05);
            Task05.Main();
            Console.WriteLine(new string('=', 50));

            string task06 = @"Task 06 - Write a program that removes from given sequence all numbers that occur odd number of times.";
            Console.WriteLine(task06);
            Task06.Main();
            Console.WriteLine(new string('=', 50));

            string task07 = @"Task 07- Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.";
            Console.WriteLine(task07);
            Task07.Main();
            Console.WriteLine(new string('=', 50));

            string task08 = @"*Task 08 - The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.

            Write a program to find the majorant of given array (if exists).";
            Console.WriteLine(task08);
            Task08.Main();
            Console.WriteLine(new string('=', 50));

            string task11 = @"Task 11 - Implement the data structure linked list.

    Define a class ListItem<T> that has two fields: value (of type T) and NextItem (of type ListItem<T>).
    Define additionally a class LinkedList<T> with a single field FirstElement (of type ListItem<T>).
";
            Console.WriteLine(task11);
            Task11.Main();
            Console.WriteLine(new string('=', 50));

            string task12 = @"Task 12 - Implement the ADT stack as auto-resizable array.

    Resize the capacity on demand (when no space is available to add / insert a new element).

";
            Console.WriteLine(task12);
            Task12.Main();
            Console.WriteLine(new string('=', 50));

            string task13 = @"Task 13 -Implement the ADT queue as dynamic linked list.

    Use generics (LinkedQueue<T>) to allow storing different data types in the queue.
";
            Console.WriteLine(task13);
            Task13.Main();
            Console.WriteLine(new string('=', 50));
        }
    }
}
