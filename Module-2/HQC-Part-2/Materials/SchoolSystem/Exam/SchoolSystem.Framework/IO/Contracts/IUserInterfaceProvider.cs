namespace SchoolSystem.Framework.IO.Contracts
{
    public interface IUserInterfaceProvider
    {
        string ReadLine();

        void WriteLine(string message);
    }
}
