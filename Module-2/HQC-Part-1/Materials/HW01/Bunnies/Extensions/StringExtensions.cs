namespace CodeFormatting
{
    using System;
    using System.Text;

    /// <summary>
    /// StringExtensions class 
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// SplitToSeparateWordsByUppercaseLetter must split each word by upper case letter of given string sequence
        /// </summary>
        /// <param name="sequence">string sequence</param>
        /// <returns>builder</returns>
        public static string SplitToSeparateWordsByUppercaseLetter(this string sequence)
        {
            var probableStringMargin = 10;
            var probableStringSize = sequence.Length + probableStringMargin;

            var builder = new StringBuilder(probableStringSize);

            var singleWhitespace = ' ';

            foreach (var letter in sequence)
            {
                if (char.IsUpper(letter))
                {
                    builder.Append(singleWhitespace);
                }

                builder.Append(letter);
            }

            return builder.ToString().Trim();
        }
    }
}