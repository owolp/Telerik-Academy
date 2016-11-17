using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var head = new LinkedListItem<int> { Value = 5 };
            var next = new LinkedListItem<int> { Value = 123 };
            head.Next = next;
            var next2 = new LinkedListItem<int> { Value = 1234 };
            next.Next = next2;
            next2.Next = null;

            var currentItem = head;

            while (currentItem != null)
            {
                Console.WriteLine(currentItem.Value);
                currentItem = currentItem.Next;
            }
        }
    }

    public class LinkedListItem<T>
    {
        public T Value { get; set; }

        public LinkedListItem<T> Next { get; set; }
    }
}
