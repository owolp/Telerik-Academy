using System;
using System.Collections.Generic;

namespace Task13
{
    public class Task13
    {
        public static void Main()
        {
            var queue = new LinkedQueue<int>();
            queue.Enqueue(1);
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Count);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            Console.WriteLine(queue.Peek());
            Console.WriteLine(queue.Count);
        }
    }

    public class LinkedQueue<T>
    {
        private LinkedList<T> linkedQueue = new LinkedList<T>();

        public T Dequeue()
        {
            if (linkedQueue.First == null)
            {
                throw new InvalidOperationException();
            }
            T firstItem = linkedQueue.First.Value;
            linkedQueue.RemoveFirst();

            return firstItem;
        }

        public void Enqueue(T item)
        {
            linkedQueue.AddLast(item);
        }

        public T Peek()
        {
            return linkedQueue.Last.Value;
        }

        public void Clear()
        {
            linkedQueue.Clear();
        }

        public int Count
        {
            get
            {
                return linkedQueue.Count;
            }
        }
    }
}
