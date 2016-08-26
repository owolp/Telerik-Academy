namespace BitArrayClass.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BitArray64 : IEnumerable<int>
    {
        public BitArray64(ulong number)
        {
            this.Number = number;
        }

        public ulong Number { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index > 63)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return (this.Number & ((ulong)1 << index)) == 0 ? 0 : 1;
                }
            }

            private set
            {
                if (index < 0 || index > 63)
                {
                    throw new IndexOutOfRangeException();
                }

                if (value != 0 && value != 1)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.Number = this.Number & ~((ulong)1 << index | (ulong)value << index);
            }
        }

        public static bool operator ==(BitArray64 firstNumber, BitArray64 secondNumber)
        {
            return firstNumber.Equals(secondNumber);
        }

        public static bool operator !=(BitArray64 firstNumber, BitArray64 secondNumber)
        {
            return !firstNumber.Equals(secondNumber);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            return this.Number.Equals((obj as BitArray64).Number);
        }

        public override int GetHashCode()
        {
            Random random = new Random();
            int hash = 7;

            hash = (hash * random.Next(1, 10)) + this.Number.GetHashCode();

            return hash;
        }
    }
}
