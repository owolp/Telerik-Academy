using System;

namespace Task12
{
    public class Task12
    {
        public static void Main()
        {
            var stackArray = new CustomStack<int>();

            for (int i = 1; i <= 100; i++)
            {
                stackArray.Push(i);
            }

            Console.WriteLine("Total Elements Count : {0}", stackArray.Count());
            stackArray.Push(999);
            Console.WriteLine("Total Elements Count : {0}", stackArray.Count());
            Console.WriteLine(stackArray.Pop());
            Console.WriteLine(stackArray.Pop());
            Console.WriteLine(stackArray.Pop());
            Console.WriteLine(stackArray.Pop());
            Console.WriteLine("Total Elements Count : {0}", stackArray.Count());
        }
    }

    public class CustomStack<T>
    {
        private T[] stackArray;
        private int counter = 0;

        public CustomStack()
        {
            stackArray = new T[2];
        }

        public void Push(T item)
        {
            if (counter + 1 >= stackArray.Length)
            {
                ResizeArray();
            }

            stackArray[counter] = item;
            counter++;
        }

        public T Pop()
        {
            if (counter - 1 < 0)
            {
                throw new NullReferenceException("Cannot remove element from empty Stack");
            }

            counter--;
            return stackArray[counter];
        }

        public int Count()
        {
            return counter;
        }

        private void ResizeArray()
        {
            T[] newArray = new T[stackArray.Length * 2];

            for (int i = 0; i < stackArray.Length; i++)
            {
                newArray[i] = stackArray[i];
            }

            stackArray = new T[newArray.Length];
 
            Array.Copy(newArray, stackArray, newArray.Length);
        }
    }
}
