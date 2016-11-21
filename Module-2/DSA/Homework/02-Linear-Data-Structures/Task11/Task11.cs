using System;
using System.Collections;
using System.Collections.Generic;

namespace Task11
{
    public class Task11
    {
        public static void Main()
        {
            var linkedList = new LinkedList<int>();

            linkedList.Add(1);
            linkedList.Add(10);
            linkedList.Add(100);

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Total Elements Count: {linkedList.Count()}");
        }

        public class ListItem<T>
        {
            public T Value { get; set; }

            public ListItem<T> NextItem { get; set; }
        }

        public class LinkedList<T> : IEnumerable<T>
        {
            private int counter;

            public ListItem<T> FirstElement { get; set; }

            public ListItem<T> CurrentElement { get; set; }

            public LinkedList()
            {
                this.CurrentElement = null;
                this.FirstElement = null;
            }

            public void Add(T item)
            {
                ListItem<T> newElement = new ListItem<T>();
                newElement.Value = item;
                newElement.NextItem = CurrentElement;
                CurrentElement = newElement;

                counter++;
            }

            public int Count()
            {
                return counter;
            }

            public IEnumerator<T> GetEnumerator()
            {
                this.FirstElement = this.CurrentElement;

                while (CurrentElement != null)
                {
                    yield return CurrentElement.Value;
                    CurrentElement = CurrentElement.NextItem;
                }

                this.CurrentElement = this.FirstElement;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }
    }
}