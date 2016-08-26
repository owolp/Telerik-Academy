namespace TaskRangeExceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class InvalidRangeException<T> : ApplicationException
    {
        private const string ErrorMessage = "The value is out of range.";

        public InvalidRangeException(T start, T end)
            : base(ErrorMessage)
        {
            this.Start = start;
            this.End = end;
        }

        public T Start { get; private set; }

        public T End { get; private set; }
    }
}
