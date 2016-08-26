namespace ExtentionMethods
{
    using System;
    using System.Text;

    public static class SubstringExtentions
    {
        // Problem 1. StringBuilder.Substring
        public static StringBuilder Substring(this StringBuilder sb, int index, int length)
        {
            SubstringValidation(sb, index, length);

            var result = new StringBuilder();
            for (int position = 0; position < length; position++)
            {
                result.Append(sb[index + position]);
            }

            return result;
        }

        public static void SubstringValidation(StringBuilder sb, int index, int length)
        {
            if (index > sb.Length)
            {
                throw new IndexOutOfRangeException("The provided index is out of range.");
            }

            if (index + length >= sb.Length)
            {
                throw new IndexOutOfRangeException("The provided index and length is out of range.");
            }

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("The index can not be a negative number.");
            }

            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("The length can not be a negative number.");
            }
        }
    }
}