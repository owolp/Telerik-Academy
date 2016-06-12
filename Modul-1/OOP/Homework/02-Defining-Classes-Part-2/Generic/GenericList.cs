namespace Generic
{
    using System;
    using System.Linq;
    using System.Text;

    public class GenericList<T> where T : IComparable<T>
    {
        // fields
        private T[] data;
        private uint nextIndex;

        // constructors
        public GenericList(int initialCapacity)
        {
            this.Data = new T[initialCapacity];
            this.UsedPlaces = 0;
        }

        // properties
        public T[] Data
        {
            get
            {
                return this.data;
            }

            set
            {
                this.data = value;
            }
        }

        public uint UsedPlaces
        {
            get
            {
                return this.nextIndex;
            }

            set
            {
                this.nextIndex = value;
            }
        }

        // indexer
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.data.Length)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }

                return this.data[index];
            }

            private set
            {
                if (index < 0 || index >= this.data.Length)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }

                this.data[index] = value;
            }
        }

        // methods
        public void AddElement(T element)
        {
            if (this.data.Length == this.nextIndex)
            {
                this.AutoGrow();
            }

            this.data[this.nextIndex] = element;
            this.nextIndex++;
        }     

        public void ClearData()
        {
            this.data = new T[this.data.Length];
        }

        public void RemoveByIndex(int index)
        {
            if (index < 0 || index >= this.data.Length)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            // -1 in order when the array is full to be able to remove an entry
            for (int i = index; i < this.nextIndex - 1; i++) 
            {
                this.data[i] = this.data[i + 1];
            }

            this.data[this.data.Length - 1] = default(T);
            this.nextIndex--;
        }

        public void InsertByIndex(int index, T element)
        {
            if (index < 0 || index >= this.data.Length)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            if (this.data.Length == this.nextIndex)
            {
                this.AutoGrow();
            }

            for (uint i = this.nextIndex - 1; i >= index; i--)
            {
                this.data[i + 1] = this.data[i];
            }

            this.data[index] = element;
        }

        public uint FindElement(T element)
        {
            return (uint)Array.IndexOf(this.data, element);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < this.nextIndex; i++)
            {
                stringBuilder.Append(this.data[i] + ", ");
            }

            return stringBuilder.ToString().Trim(new[] { ',', ' ' });
        }

        public T Min()
        {
            // with LINQ
            return this.data.Min();
        }

        public T Max()
        {
            // without LINQ
            if (this.nextIndex == 0)
            {
                throw new ArgumentException("The array is empty.");
            }

            T max = this.data[0];

            foreach (T element in this.data)
            {
                if (max.CompareTo(element) < 0)
                {
                    max = element;
                }
            }

            return max;
        }

        // Problem 6. Auto-grow
        // Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it.
        private void AutoGrow()
        {
            var newData = new T[this.data.Length * 2];

            for (int i = 0; i < this.data.Length; i++)
            {
                newData[i] = this.data[i];
            }

            this.data = newData;
        }
    }
}
