namespace CodeFormatting.Contracts
{
    /// <summary>
    /// Interface IWriter
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// Write method in the interface wich must be inplement
        /// </summary>
        /// <param name="message">string message</param>
        void Write(string message);

        /// <summary>
        /// WriteLine method in the interface wich must be inplement
        /// </summary>
        /// <param name="message">string message</param>
        void WriteLine(string message);
    }
}