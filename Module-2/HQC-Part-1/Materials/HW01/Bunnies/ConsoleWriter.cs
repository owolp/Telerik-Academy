namespace CodeFormatting
{
    using System;
    using CodeFormatting.Contracts;

    /// <summary>
    /// class ConsoleWriter implement the interface IWriter
    /// </summary>
    public class ConsoleWriter : IWriter
    {
        /// <summary>
        /// The method Write take one param and print the message on the console on the same line.
        /// </summary>
        /// <param name="message">string message</param>
        public void Write(string message)
        {
            Console.Write(message);
        }

        /// <summary>
        /// The method Write take one param and print the message on the console on a new line.
        /// </summary>
        /// <param name="message">string message</param>
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}