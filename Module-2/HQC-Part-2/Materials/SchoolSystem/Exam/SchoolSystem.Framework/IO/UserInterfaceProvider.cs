using System;

using SchoolSystem.Framework.IO.Contracts;

namespace SchoolSystem.Framework.IO
{
    public class UserInterfaceProvider : IUserInterfaceProvider
    {
        private readonly Func<string> readMethod;
        private readonly Action<string> writeMethod;

        public UserInterfaceProvider(Func<string> readMethod, Action<string> writeMethod)
        {
            if (readMethod == null)
            {
                throw new ArgumentNullException(nameof(readMethod));
            }

            if (writeMethod == null)
            {
                throw new ArgumentNullException(nameof(writeMethod));
            }

            this.readMethod = readMethod;
            this.writeMethod = writeMethod;
        }

        public string ReadLine()
        {
            var readLine = this.readMethod.Invoke();
            return readLine;
        }

        public void WriteLine(string message)
        {
            this.writeMethod.Invoke(message);
        }
    }
}
